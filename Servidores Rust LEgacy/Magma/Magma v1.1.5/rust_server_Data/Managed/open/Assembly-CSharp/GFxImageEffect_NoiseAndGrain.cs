using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
public sealed class GFxImageEffect_NoiseAndGrain : global::GFxImageEffect
{
	// Token: 0x06001891 RID: 6289 RVA: 0x0005E034 File Offset: 0x0005C234
	public GFxImageEffect_NoiseAndGrain()
	{
	}

	// Token: 0x06001892 RID: 6290 RVA: 0x0005E0B4 File Offset: 0x0005C2B4
	// Note: this type is marked as 'beforefieldinit'.
	static GFxImageEffect_NoiseAndGrain()
	{
	}

	// Token: 0x06001893 RID: 6291 RVA: 0x0005E0C8 File Offset: 0x0005C2C8
	private bool CheckResources()
	{
		bool flag = false;
		return global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.noiseShader, ref this.noiseMaterial), ref flag);
	}

	// Token: 0x170006B2 RID: 1714
	// (get) Token: 0x06001894 RID: 6292 RVA: 0x0005E0F8 File Offset: 0x0005C2F8
	public override bool allow
	{
		get
		{
			return global::GFxImageEffect_NoiseAndGrain.r_noisegrain && this.strength * global::GFxImageEffect_NoiseAndGrain.strengthMult > 0.01f;
		}
	}

	// Token: 0x06001895 RID: 6293 RVA: 0x0005E128 File Offset: 0x0005C328
	protected override void Configure()
	{
		this.supported = (base.Support((global::GFxImageEffect.Caps.Bits)5) && this.CheckResources());
	}

	// Token: 0x06001896 RID: 6294 RVA: 0x0005E148 File Offset: 0x0005C348
	protected override void DeConfigure()
	{
	}

	// Token: 0x06001897 RID: 6295 RVA: 0x0005E14C File Offset: 0x0005C34C
	protected override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		this.noiseMaterial.SetVector("_NoisePerChannel", new global::UnityEngine.Vector3(this.redChannelNoise, this.greenChannelNoise, this.blueChannelNoise));
		this.noiseMaterial.SetVector("_NoiseTilingPerChannel", new global::UnityEngine.Vector3(this.redChannelTiling, this.greenChannelTiling, this.blueChannelTiling));
		this.noiseMaterial.SetVector("_NoiseAmount", new global::UnityEngine.Vector3(this.strength * global::GFxImageEffect_NoiseAndGrain.strengthMult, this.blackIntensity, this.whiteIntensity));
		this.noiseMaterial.SetTexture("_NoiseTex", this.noiseTexture);
		if (this.noiseTexture.filterMode != this.filterMode)
		{
			global::UnityEngine.FilterMode filterMode = this.noiseTexture.filterMode;
			try
			{
				this.noiseTexture.filterMode = this.filterMode;
				global::GFxImageEffect_NoiseAndGrain.DrawNoiseQuadGrid(src, dst, this.noiseMaterial, this.noiseTexture, 0);
			}
			finally
			{
				this.noiseTexture.filterMode = filterMode;
			}
		}
		else
		{
			global::GFxImageEffect_NoiseAndGrain.DrawNoiseQuadGrid(src, dst, this.noiseMaterial, this.noiseTexture, 0);
		}
		return true;
	}

	// Token: 0x06001898 RID: 6296 RVA: 0x0005E288 File Offset: 0x0005C488
	private static void DrawNoiseQuadGrid(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst, global::UnityEngine.Material fxMaterial, global::UnityEngine.Texture2D noise, int passNr)
	{
		global::UnityEngine.RenderTexture.active = dst;
		float num = (float)noise.width * 1f;
		float num2 = num;
		int width = src.width;
		float num3 = 1f * (float)width / num2;
		fxMaterial.SetTexture("_MainTex", src);
		global::UnityEngine.GL.PushMatrix();
		global::UnityEngine.GL.LoadOrtho();
		float num4 = 1f * (float)width / (1f * (float)src.height);
		float num5 = 1f / num3;
		float num6 = num5 * num4;
		float num7 = num2 / ((float)noise.width * 1f);
		fxMaterial.SetPass(passNr);
		global::UnityEngine.GL.Begin(7);
		for (float num8 = 0f; num8 < 1f; num8 += num5)
		{
			for (float num9 = 0f; num9 < 1f; num9 += num6)
			{
				float num10 = global::UnityEngine.Random.Range(0f, 1f);
				float num11 = global::UnityEngine.Random.Range(0f, 1f);
				num10 = global::UnityEngine.Mathf.Floor(num10 * num) / num;
				num11 = global::UnityEngine.Mathf.Floor(num11 * num) / num;
				float num12 = 1f / num;
				global::UnityEngine.GL.MultiTexCoord2(0, num10, num11);
				global::UnityEngine.GL.MultiTexCoord2(1, 0f, 0f);
				global::UnityEngine.GL.Vertex3(num8, num9, 0.1f);
				global::UnityEngine.GL.MultiTexCoord2(0, num10 + num7 * num12, num11);
				global::UnityEngine.GL.MultiTexCoord2(1, 1f, 0f);
				global::UnityEngine.GL.Vertex3(num8 + num5, num9, 0.1f);
				global::UnityEngine.GL.MultiTexCoord2(0, num10 + num7 * num12, num11 + num7 * num12);
				global::UnityEngine.GL.MultiTexCoord2(1, 1f, 1f);
				global::UnityEngine.GL.Vertex3(num8 + num5, num9 + num6, 0.1f);
				global::UnityEngine.GL.MultiTexCoord2(0, num10, num11 + num7 * num12);
				global::UnityEngine.GL.MultiTexCoord2(1, 0f, 1f);
				global::UnityEngine.GL.Vertex3(num8, num9 + num6, 0.1f);
			}
		}
		global::UnityEngine.GL.End();
		global::UnityEngine.GL.PopMatrix();
	}

	// Token: 0x04000D89 RID: 3465
	public float strength = 1f;

	// Token: 0x04000D8A RID: 3466
	public float blackIntensity = 1f;

	// Token: 0x04000D8B RID: 3467
	public float whiteIntensity = 1f;

	// Token: 0x04000D8C RID: 3468
	public float redChannelNoise = 0.975f;

	// Token: 0x04000D8D RID: 3469
	public float greenChannelNoise = 0.875f;

	// Token: 0x04000D8E RID: 3470
	public float blueChannelNoise = 1.2f;

	// Token: 0x04000D8F RID: 3471
	public float redChannelTiling = 24f;

	// Token: 0x04000D90 RID: 3472
	public float greenChannelTiling = 28f;

	// Token: 0x04000D91 RID: 3473
	public float blueChannelTiling = 34f;

	// Token: 0x04000D92 RID: 3474
	public global::UnityEngine.FilterMode filterMode = 1;

	// Token: 0x04000D93 RID: 3475
	public global::UnityEngine.Shader noiseShader;

	// Token: 0x04000D94 RID: 3476
	public global::UnityEngine.Texture2D noiseTexture;

	// Token: 0x04000D95 RID: 3477
	private global::UnityEngine.Material noiseMaterial;

	// Token: 0x04000D96 RID: 3478
	internal static bool r_noisegrain = true;

	// Token: 0x04000D97 RID: 3479
	public static float strengthMult = 1f;
}
