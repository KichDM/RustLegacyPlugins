using System;
using UnityEngine;

// Token: 0x0200099D RID: 2461
[global::UnityEngine.AddComponentMenu("Time of Day/Camera Sun Shafts")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
internal class TOD_SunShafts : global::TOD_PostEffectsBase
{
	// Token: 0x0600531D RID: 21277 RVA: 0x0015C57C File Offset: 0x0015A77C
	public TOD_SunShafts()
	{
	}

	// Token: 0x0600531E RID: 21278 RVA: 0x0015C5C8 File Offset: 0x0015A7C8
	protected void OnDisable()
	{
		if (this.sunShaftsMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.sunShaftsMaterial);
		}
		if (this.screenClearMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.screenClearMaterial);
		}
	}

	// Token: 0x0600531F RID: 21279 RVA: 0x0015C60C File Offset: 0x0015A80C
	protected override bool CheckResources()
	{
		base.CheckSupport(this.UseDepthTexture);
		this.sunShaftsMaterial = base.CheckShaderAndCreateMaterial(this.SunShaftsShader, this.sunShaftsMaterial);
		this.screenClearMaterial = base.CheckShaderAndCreateMaterial(this.ScreenClearShader, this.screenClearMaterial);
		if (!this.isSupported)
		{
			base.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06005320 RID: 21280 RVA: 0x0015C670 File Offset: 0x0015A870
	protected void OnRenderImage(global::UnityEngine.RenderTexture source, global::UnityEngine.RenderTexture destination)
	{
		if (!this.CheckResources() || !this.sky)
		{
			global::UnityEngine.Graphics.Blit(source, destination);
			return;
		}
		this.sky.Components.SunShafts = this;
		if (this.UseDepthTexture)
		{
			base.camera.depthTextureMode |= 1;
		}
		int num;
		int num2;
		if (this.Resolution == global::TOD_SunShafts.SunShaftsResolution.High)
		{
			num = source.width;
			num2 = source.height;
		}
		else if (this.Resolution == global::TOD_SunShafts.SunShaftsResolution.Normal)
		{
			num = source.width / 2;
			num2 = source.height / 2;
		}
		else
		{
			num = source.width / 4;
			num2 = source.height / 4;
		}
		global::UnityEngine.Vector3 vector = base.camera.WorldToViewportPoint(this.sky.Components.SunTransform.position);
		this.sunShaftsMaterial.SetVector("_BlurRadius4", new global::UnityEngine.Vector4(1f, 1f, 0f, 0f) * this.SunShaftBlurRadius);
		this.sunShaftsMaterial.SetVector("_SunPosition", new global::UnityEngine.Vector4(vector.x, vector.y, vector.z, this.MaxRadius));
		global::UnityEngine.RenderTexture temporary = global::UnityEngine.RenderTexture.GetTemporary(num, num2, 0);
		global::UnityEngine.RenderTexture temporary2 = global::UnityEngine.RenderTexture.GetTemporary(num, num2, 0);
		if (this.UseDepthTexture)
		{
			global::UnityEngine.Graphics.Blit(source, temporary, this.sunShaftsMaterial, 2);
		}
		else
		{
			global::UnityEngine.Graphics.Blit(source, temporary, this.sunShaftsMaterial, 3);
		}
		base.DrawBorder(temporary, this.screenClearMaterial);
		float num3 = this.SunShaftBlurRadius * 0.0013020834f;
		this.sunShaftsMaterial.SetVector("_BlurRadius4", new global::UnityEngine.Vector4(num3, num3, 0f, 0f));
		this.sunShaftsMaterial.SetVector("_SunPosition", new global::UnityEngine.Vector4(vector.x, vector.y, vector.z, this.MaxRadius));
		for (int i = 0; i < this.RadialBlurIterations; i++)
		{
			global::UnityEngine.Graphics.Blit(temporary, temporary2, this.sunShaftsMaterial, 1);
			num3 = this.SunShaftBlurRadius * (((float)i * 2f + 1f) * 6f) / 768f;
			this.sunShaftsMaterial.SetVector("_BlurRadius4", new global::UnityEngine.Vector4(num3, num3, 0f, 0f));
			global::UnityEngine.Graphics.Blit(temporary2, temporary, this.sunShaftsMaterial, 1);
			num3 = this.SunShaftBlurRadius * (((float)i * 2f + 2f) * 6f) / 768f;
			this.sunShaftsMaterial.SetVector("_BlurRadius4", new global::UnityEngine.Vector4(num3, num3, 0f, 0f));
		}
		global::UnityEngine.Vector4 vector2 = ((double)vector.z < 0.0) ? global::UnityEngine.Vector4.zero : ((1f - this.sky.Atmosphere.Fogginess) * this.SunShaftIntensity * this.sky.SunShaftColor);
		this.sunShaftsMaterial.SetVector("_SunColor", vector2);
		this.sunShaftsMaterial.SetTexture("_ColorBuffer", temporary);
		if (this.BlendMode == global::TOD_SunShafts.SunShaftsBlendMode.Screen)
		{
			global::UnityEngine.Graphics.Blit(source, destination, this.sunShaftsMaterial, 0);
		}
		else
		{
			global::UnityEngine.Graphics.Blit(source, destination, this.sunShaftsMaterial, 4);
		}
		global::UnityEngine.RenderTexture.ReleaseTemporary(temporary);
		global::UnityEngine.RenderTexture.ReleaseTemporary(temporary2);
	}

	// Token: 0x0400305B RID: 12379
	private const int PASS_DEPTH = 2;

	// Token: 0x0400305C RID: 12380
	private const int PASS_NODEPTH = 3;

	// Token: 0x0400305D RID: 12381
	private const int PASS_RADIAL = 1;

	// Token: 0x0400305E RID: 12382
	private const int PASS_SCREEN = 0;

	// Token: 0x0400305F RID: 12383
	private const int PASS_ADD = 4;

	// Token: 0x04003060 RID: 12384
	public global::TOD_Sky sky;

	// Token: 0x04003061 RID: 12385
	public global::TOD_SunShafts.SunShaftsResolution Resolution = global::TOD_SunShafts.SunShaftsResolution.Normal;

	// Token: 0x04003062 RID: 12386
	public global::TOD_SunShafts.SunShaftsBlendMode BlendMode;

	// Token: 0x04003063 RID: 12387
	public int RadialBlurIterations = 2;

	// Token: 0x04003064 RID: 12388
	public float SunShaftBlurRadius = 2f;

	// Token: 0x04003065 RID: 12389
	public float SunShaftIntensity = 1f;

	// Token: 0x04003066 RID: 12390
	public float MaxRadius = 1f;

	// Token: 0x04003067 RID: 12391
	public bool UseDepthTexture = true;

	// Token: 0x04003068 RID: 12392
	public global::UnityEngine.Shader SunShaftsShader;

	// Token: 0x04003069 RID: 12393
	public global::UnityEngine.Shader ScreenClearShader;

	// Token: 0x0400306A RID: 12394
	private global::UnityEngine.Material sunShaftsMaterial;

	// Token: 0x0400306B RID: 12395
	private global::UnityEngine.Material screenClearMaterial;

	// Token: 0x0200099E RID: 2462
	public enum SunShaftsResolution
	{
		// Token: 0x0400306D RID: 12397
		Low,
		// Token: 0x0400306E RID: 12398
		Normal,
		// Token: 0x0400306F RID: 12399
		High
	}

	// Token: 0x0200099F RID: 2463
	public enum SunShaftsBlendMode
	{
		// Token: 0x04003071 RID: 12401
		Screen,
		// Token: 0x04003072 RID: 12402
		Add
	}
}
