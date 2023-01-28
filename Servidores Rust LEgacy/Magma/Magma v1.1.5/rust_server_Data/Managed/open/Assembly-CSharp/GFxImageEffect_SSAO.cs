using System;
using UnityEngine;

// Token: 0x020002C2 RID: 706
public sealed class GFxImageEffect_SSAO : global::GFxImageEffect
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x0005EDE8 File Offset: 0x0005CFE8
	public GFxImageEffect_SSAO()
	{
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x0005EE3C File Offset: 0x0005D03C
	// Note: this type is marked as 'beforefieldinit'.
	static GFxImageEffect_SSAO()
	{
	}

	// Token: 0x170006B5 RID: 1717
	// (get) Token: 0x060018A9 RID: 6313 RVA: 0x0005EE44 File Offset: 0x0005D044
	public override bool allow
	{
		get
		{
			return global::GFxImageEffect_SSAO.r_ssao;
		}
	}

	// Token: 0x060018AA RID: 6314 RVA: 0x0005EE4C File Offset: 0x0005D04C
	protected sealed override void Configure()
	{
		this.supported = false;
		if ((byte)(this.processor.kind & global::GFxPostProcessor.Kind.Opaque) != 4)
		{
			this.noSupportReason = string.Format("Processor's kind is {0}. SSAO requires a Opaque kind", this.processor.kind);
			this.supported = false;
			return;
		}
		if (!base.Support(global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth))
		{
			this.supported = false;
			return;
		}
		if (!this.CheckResources())
		{
			this.supported = false;
			this.noSupportReason = "Could not verify resources";
			return;
		}
		if (!base.Support(global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals))
		{
			this.supported = false;
			return;
		}
		this.supported = true;
		this.ClampVars();
	}

	// Token: 0x060018AB RID: 6315 RVA: 0x0005EEF4 File Offset: 0x0005D0F4
	protected override void DeConfigure()
	{
		this._SSAO.Shutdown();
		this.pSSAOMaterial = null;
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x0005EF08 File Offset: 0x0005D108
	private void ClampVars()
	{
		this.iDownsampling = global::UnityEngine.Mathf.Clamp(this.iDownsampling, 1, 6);
		this.fRadius = global::UnityEngine.Mathf.Clamp(this.fRadius, 0.05f, 1f);
		this.fMinZ = global::UnityEngine.Mathf.Clamp(this.fMinZ, 1E-05f, 0.5f);
		this.fOcclusionIntensity = global::UnityEngine.Mathf.Clamp(this.fOcclusionIntensity, 0.5f, 4f);
		this.fOcclusionAttenuation = global::UnityEngine.Mathf.Clamp(this.fOcclusionAttenuation, 0.2f, 2f);
		this.iBlur = global::UnityEngine.Mathf.Clamp(this.iBlur, 0, 4);
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x0005EFA8 File Offset: 0x0005D1A8
	private bool CheckResources()
	{
		bool flag = false;
		if (global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.pSSAOShader, ref this.pSSAOMaterial), ref flag) && (!flag || this.pSSAOMaterial.passCount == 5))
		{
			if (flag)
			{
				this._NoiseScale = new global::GFxImageEffect.MatVarVector("_NoiseScale");
				this._FarCorner = new global::GFxImageEffect.MatVarVector("_FarCorner");
				this._Params = new global::GFxImageEffect.MatVarVector("_Params");
				this._TexelOffsetScale = new global::GFxImageEffect.MatVarVector("_TexelOffsetScale");
				this._SSAO = new global::GFxImageEffect.MatVarTexture("_SSAO");
				this.pSSAOMaterial.SetTexture("_RandomTexture", this.pRandomTexture);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x0005F05C File Offset: 0x0005D25C
	private void CopyVars()
	{
		global::GFxImageEffect_SSAO gfxImageEffect_SSAO = this.prefab as global::GFxImageEffect_SSAO;
		this.fRadius = gfxImageEffect_SSAO.fRadius;
		this.iSampleCount = gfxImageEffect_SSAO.iSampleCount;
		this.fOcclusionIntensity = gfxImageEffect_SSAO.fOcclusionIntensity;
		this.iBlur = gfxImageEffect_SSAO.iBlur;
		this.iDownsampling = gfxImageEffect_SSAO.iDownsampling;
		this.fOcclusionAttenuation = gfxImageEffect_SSAO.fOcclusionAttenuation;
		this.fMinZ = gfxImageEffect_SSAO.fMinZ;
	}

	// Token: 0x060018AF RID: 6319 RVA: 0x0005F0CC File Offset: 0x0005D2CC
	protected override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		if (!global::GFxImageEffect_SSAO.r_ssao)
		{
			return false;
		}
		global::UnityEngine.Texture texture = null;
		float fieldOfView = this.processor.camera.fieldOfView;
		float farClipPlane = this.processor.camera.farClipPlane;
		float num = global::UnityEngine.Mathf.Tan(fieldOfView * 0.017453292f * 0.5f) * farClipPlane;
		float num2 = num * this.processor.camera.aspect;
		this.pSSAOMaterial.SetVector("_FarCorner", new global::UnityEngine.Vector3(num2, num, farClipPlane));
		int num3;
		int num4;
		if (this.pRandomTexture)
		{
			num3 = this.pRandomTexture.width;
			num4 = this.pRandomTexture.height;
		}
		else
		{
			num3 = 1;
			num4 = 1;
		}
		this.pSSAOMaterial.SetVector("_Params", new global::UnityEngine.Vector4(this.fRadius, this.fMinZ, 1f / this.fOcclusionAttenuation, this.fOcclusionIntensity));
		bool flag = this.iBlur > 0;
		global::UnityEngine.RenderTexture renderTexture = global::UnityEngine.RenderTexture.GetTemporary(src.width / this.iDownsampling, src.height / this.iDownsampling, 0, src.format);
		this.pSSAOMaterial.SetVector("_NoiseScale", new global::UnityEngine.Vector3((float)renderTexture.width / (float)num3, (float)renderTexture.height / (float)num4, 0f));
		global::UnityEngine.Graphics.Blit((!flag) ? src : texture, renderTexture, this.pSSAOMaterial, (int)this.iSampleCount);
		if (flag)
		{
			global::UnityEngine.RenderTexture temporary = global::UnityEngine.RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
			this.pSSAOMaterial.SetVector("_TexelOffsetScale", new global::UnityEngine.Vector4((float)this.iBlur / (float)src.width, 0f, 0f, 0f));
			this.pSSAOMaterial.SetTexture("_SSAO", renderTexture);
			global::UnityEngine.Graphics.Blit(texture, temporary, this.pSSAOMaterial, 3);
			global::UnityEngine.RenderTexture.ReleaseTemporary(renderTexture);
			global::UnityEngine.RenderTexture temporary2 = global::UnityEngine.RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
			this.pSSAOMaterial.SetVector("_TexelOffsetScale", new global::UnityEngine.Vector4(0f, (float)this.iBlur / (float)src.height, 0f, 0f));
			this.pSSAOMaterial.SetTexture("_SSAO", temporary);
			global::UnityEngine.Graphics.Blit(src, temporary2, this.pSSAOMaterial, 3);
			global::UnityEngine.RenderTexture.ReleaseTemporary(temporary);
			renderTexture = temporary2;
		}
		this.pSSAOMaterial.SetTexture("_SSAO", renderTexture);
		global::UnityEngine.Graphics.Blit(src, dst, this.pSSAOMaterial, 4);
		global::UnityEngine.RenderTexture.ReleaseTemporary(renderTexture);
		return true;
	}

	// Token: 0x04000DB2 RID: 3506
	public float fRadius = 0.4f;

	// Token: 0x04000DB3 RID: 3507
	public global::GFxImageEffect_SSAO.SSAOSamples iSampleCount = global::GFxImageEffect_SSAO.SSAOSamples.Medium;

	// Token: 0x04000DB4 RID: 3508
	public float fOcclusionIntensity = 1.5f;

	// Token: 0x04000DB5 RID: 3509
	public int iBlur = 2;

	// Token: 0x04000DB6 RID: 3510
	public int iDownsampling = 2;

	// Token: 0x04000DB7 RID: 3511
	public float fOcclusionAttenuation = 1f;

	// Token: 0x04000DB8 RID: 3512
	public float fMinZ = 0.01f;

	// Token: 0x04000DB9 RID: 3513
	public global::UnityEngine.Shader pSSAOShader;

	// Token: 0x04000DBA RID: 3514
	private global::UnityEngine.Material pSSAOMaterial;

	// Token: 0x04000DBB RID: 3515
	public global::UnityEngine.Texture2D pRandomTexture;

	// Token: 0x04000DBC RID: 3516
	private global::GFxImageEffect.MatVarVector _NoiseScale;

	// Token: 0x04000DBD RID: 3517
	private global::GFxImageEffect.MatVarVector _FarCorner;

	// Token: 0x04000DBE RID: 3518
	private global::GFxImageEffect.MatVarVector _Params;

	// Token: 0x04000DBF RID: 3519
	private global::GFxImageEffect.MatVarVector _TexelOffsetScale;

	// Token: 0x04000DC0 RID: 3520
	private global::GFxImageEffect.MatVarTexture _SSAO;

	// Token: 0x04000DC1 RID: 3521
	internal static bool r_ssao = true;

	// Token: 0x020002C3 RID: 707
	public enum SSAOSamples
	{
		// Token: 0x04000DC3 RID: 3523
		Low,
		// Token: 0x04000DC4 RID: 3524
		Medium,
		// Token: 0x04000DC5 RID: 3525
		High
	}
}
