using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public sealed class GFxImageEffect_NoiseAndGrain4 : global::GFxImageEffect
{
	// Token: 0x06001899 RID: 6297 RVA: 0x0005E46C File Offset: 0x0005C66C
	public GFxImageEffect_NoiseAndGrain4()
	{
	}

	// Token: 0x170006B3 RID: 1715
	// (get) Token: 0x0600189A RID: 6298 RVA: 0x0005E4FC File Offset: 0x0005C6FC
	public override bool allow
	{
		get
		{
			return global::GFxImageEffect_NoiseAndGrain.r_noisegrain;
		}
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x0005E504 File Offset: 0x0005C704
	private bool CheckResources()
	{
		if (!this.noiseTexture)
		{
			return false;
		}
		bool flag = false;
		return global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.noiseShader, ref this.noiseMaterial), ref flag) && (!this.dx11Grain || !global::GFxImageEffect.Caps.Info.supportsDirectX11 || global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.dx11NoiseShader, ref this.dx11NoiseMaterial), ref flag));
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x0005E57C File Offset: 0x0005C77C
	protected override void Configure()
	{
		this.supported = (base.Support((global::GFxImageEffect.Caps.Bits)5) && this.CheckResources());
	}

	// Token: 0x0600189D RID: 6301 RVA: 0x0005E59C File Offset: 0x0005C79C
	protected override void DeConfigure()
	{
	}

	// Token: 0x0600189E RID: 6302 RVA: 0x0005E5A0 File Offset: 0x0005C7A0
	protected override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		this.softness = global::UnityEngine.Mathf.Clamp(this.softness, 0f, 0.99f);
		if (this.dx11Grain && global::GFxImageEffect.Caps.Info.supportsDirectX11)
		{
			this.dx11NoiseMaterial.SetFloat("_DX11NoiseTime", (float)global::UnityEngine.Time.frameCount);
			this.dx11NoiseMaterial.SetTexture("_NoiseTex", this.noiseTexture);
			this.dx11NoiseMaterial.SetVector("_NoisePerChannel", (!this.monochrome) ? this.intensities : global::UnityEngine.Vector3.one);
			this.dx11NoiseMaterial.SetVector("_MidGrey", new global::UnityEngine.Vector3(this.midGrey, 1f / (1f - this.midGrey), -1f / this.midGrey));
			this.dx11NoiseMaterial.SetVector("_NoiseAmount", new global::UnityEngine.Vector3(this.generalIntensity, this.blackIntensity, this.whiteIntensity) * this.intensityMultiplier);
			if (this.softness > 1E-45f)
			{
				global::UnityEngine.RenderTexture temporary = global::UnityEngine.RenderTexture.GetTemporary((int)((float)src.width * (1f - this.softness)), (int)((float)src.height * (1f - this.softness)));
				global::GFxImageEffect_NoiseAndGrain4.DrawNoiseQuadGrid(src, temporary, this.dx11NoiseMaterial, this.noiseTexture, (!this.monochrome) ? 2 : 3);
				this.dx11NoiseMaterial.SetTexture("_NoiseTex", temporary);
				global::UnityEngine.Graphics.Blit(src, dst, this.dx11NoiseMaterial, 4);
				global::UnityEngine.RenderTexture.ReleaseTemporary(temporary);
			}
			else
			{
				global::GFxImageEffect_NoiseAndGrain4.DrawNoiseQuadGrid(src, dst, this.dx11NoiseMaterial, this.noiseTexture, (!this.monochrome) ? 0 : 1);
			}
		}
		else
		{
			if (this.noiseTexture)
			{
				this.noiseTexture.wrapMode = 0;
				this.noiseTexture.filterMode = this.filterMode;
			}
			this.noiseMaterial.SetTexture("_NoiseTex", this.noiseTexture);
			this.noiseMaterial.SetVector("_NoisePerChannel", (!this.monochrome) ? this.intensities : global::UnityEngine.Vector3.one);
			this.noiseMaterial.SetVector("_NoiseTilingPerChannel", (!this.monochrome) ? this.tiling : (global::UnityEngine.Vector3.one * this.monochromeTiling));
			this.noiseMaterial.SetVector("_MidGrey", new global::UnityEngine.Vector3(this.midGrey, 1f / (1f - this.midGrey), -1f / this.midGrey));
			this.noiseMaterial.SetVector("_NoiseAmount", new global::UnityEngine.Vector3(this.generalIntensity, this.blackIntensity, this.whiteIntensity) * this.intensityMultiplier);
			if (this.softness > 1E-45f)
			{
				global::UnityEngine.RenderTexture temporary2 = global::UnityEngine.RenderTexture.GetTemporary((int)((float)src.width * (1f - this.softness)), (int)((float)src.height * (1f - this.softness)));
				global::GFxImageEffect_NoiseAndGrain4.DrawNoiseQuadGrid(src, temporary2, this.noiseMaterial, this.noiseTexture, 2);
				this.noiseMaterial.SetTexture("_NoiseTex", temporary2);
				global::UnityEngine.Graphics.Blit(src, dst, this.noiseMaterial, 1);
				global::UnityEngine.RenderTexture.ReleaseTemporary(temporary2);
			}
			else
			{
				global::GFxImageEffect_NoiseAndGrain4.DrawNoiseQuadGrid(src, dst, this.noiseMaterial, this.noiseTexture, 0);
			}
		}
		return true;
	}

	// Token: 0x0600189F RID: 6303 RVA: 0x0005E920 File Offset: 0x0005CB20
	private static void DrawNoiseQuadGrid(global::UnityEngine.RenderTexture source, global::UnityEngine.RenderTexture dest, global::UnityEngine.Material fxMaterial, global::UnityEngine.Texture2D noise, int passNr)
	{
		global::UnityEngine.RenderTexture.active = dest;
		float num = (float)noise.width;
		float num2 = (float)source.width;
		float num3 = (float)source.width / 64f;
		fxMaterial.SetTexture("_MainTex", source);
		global::UnityEngine.GL.PushMatrix();
		global::UnityEngine.GL.LoadOrtho();
		float num4 = num2 / (float)source.height;
		float num5 = 1f / num3;
		float num6 = num5 * num4;
		float num7 = num / num;
		fxMaterial.SetPass(passNr);
		float num8 = 1f / num;
		global::UnityEngine.GL.Begin(7);
		for (float num9 = 0f; num9 < 1f; num9 += num5)
		{
			for (float num10 = 0f; num10 < 1f; num10 += num6)
			{
				float num11 = global::UnityEngine.Random.Range(0f, 1f);
				float num12 = global::UnityEngine.Random.Range(0f, 1f);
				num11 = global::UnityEngine.Mathf.Floor(num11 * num) / num;
				num12 = global::UnityEngine.Mathf.Floor(num12 * num) / num;
				global::UnityEngine.GL.MultiTexCoord2(0, num11, num12);
				global::UnityEngine.GL.MultiTexCoord2(1, 0f, 0f);
				global::UnityEngine.GL.Vertex3(num9, num10, 0.1f);
				global::UnityEngine.GL.MultiTexCoord2(0, num11 + num7 * num8, num12);
				global::UnityEngine.GL.MultiTexCoord2(1, 1f, 0f);
				global::UnityEngine.GL.Vertex3(num9 + num5, num10, 0.1f);
				global::UnityEngine.GL.MultiTexCoord2(0, num11 + num7 * num8, num12 + num7 * num8);
				global::UnityEngine.GL.MultiTexCoord2(1, 1f, 1f);
				global::UnityEngine.GL.Vertex3(num9 + num5, num10 + num6, 0.1f);
				global::UnityEngine.GL.MultiTexCoord2(0, num11, num12 + num7 * num8);
				global::UnityEngine.GL.MultiTexCoord2(1, 0f, 1f);
				global::UnityEngine.GL.Vertex3(num9, num10 + num6, 0.1f);
			}
		}
		global::UnityEngine.GL.End();
		global::UnityEngine.GL.PopMatrix();
	}

	// Token: 0x04000D98 RID: 3480
	private const float TILE_AMOUNT = 64f;

	// Token: 0x04000D99 RID: 3481
	public float intensityMultiplier = 0.25f;

	// Token: 0x04000D9A RID: 3482
	public float generalIntensity = 0.5f;

	// Token: 0x04000D9B RID: 3483
	public float blackIntensity = 1f;

	// Token: 0x04000D9C RID: 3484
	public float whiteIntensity = 1f;

	// Token: 0x04000D9D RID: 3485
	public float midGrey = 0.2f;

	// Token: 0x04000D9E RID: 3486
	public bool dx11Grain;

	// Token: 0x04000D9F RID: 3487
	public float softness;

	// Token: 0x04000DA0 RID: 3488
	public bool monochrome;

	// Token: 0x04000DA1 RID: 3489
	public global::UnityEngine.Vector3 intensities = new global::UnityEngine.Vector3(1f, 1f, 1f);

	// Token: 0x04000DA2 RID: 3490
	public global::UnityEngine.Vector3 tiling = new global::UnityEngine.Vector3(64f, 64f, 64f);

	// Token: 0x04000DA3 RID: 3491
	public float monochromeTiling = 64f;

	// Token: 0x04000DA4 RID: 3492
	public global::UnityEngine.FilterMode filterMode = 1;

	// Token: 0x04000DA5 RID: 3493
	public global::UnityEngine.Texture2D noiseTexture;

	// Token: 0x04000DA6 RID: 3494
	public global::UnityEngine.Shader noiseShader;

	// Token: 0x04000DA7 RID: 3495
	private global::UnityEngine.Material noiseMaterial;

	// Token: 0x04000DA8 RID: 3496
	public global::UnityEngine.Shader dx11NoiseShader;

	// Token: 0x04000DA9 RID: 3497
	private global::UnityEngine.Material dx11NoiseMaterial;
}
