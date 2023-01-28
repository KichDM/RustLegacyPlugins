using System;
using System.Threading;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public sealed class GFxImageEffect_ToneMapping : global::GFxImageEffect
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x0005F360 File Offset: 0x0005D560
	public GFxImageEffect_ToneMapping()
	{
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x0005F48C File Offset: 0x0005D68C
	// Note: this type is marked as 'beforefieldinit'.
	static GFxImageEffect_ToneMapping()
	{
	}

	// Token: 0x170006B6 RID: 1718
	// (get) Token: 0x060018B2 RID: 6322 RVA: 0x0005F4A0 File Offset: 0x0005D6A0
	public sealed override bool allow
	{
		get
		{
			return global::GFxImageEffect_ToneMapping.r_tonemapping;
		}
	}

	// Token: 0x060018B3 RID: 6323 RVA: 0x0005F4A8 File Offset: 0x0005D6A8
	private bool CheckResources()
	{
		bool flag = false;
		if (global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.tonemapper, ref this.tonemapMaterial), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.bucketee, ref this.bucketeeMaterial), ref flag))
		{
			if (!this.curveTex && this.type == global::GFxImageEffect_ToneMapping.TonemapperType.UserCurve)
			{
				this.curveTex = new global::UnityEngine.Texture2D(0x100, 1, 5, false, true)
				{
					hideFlags = 4
				};
				this.curveTex.filterMode = 1;
				this.curveTex.wrapMode = 1;
				this.curveTex.hideFlags = 4;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060018B4 RID: 6324 RVA: 0x0005F554 File Offset: 0x0005D754
	public float UpdateCurve()
	{
		float num = 1f;
		if (this.remapCurve == null || this.remapCurve.keys.Length < 1)
		{
			this.remapCurve = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
			{
				new global::UnityEngine.Keyframe(0f, 0f),
				new global::UnityEngine.Keyframe(2f, 1f)
			});
			if (this.remapCurve == null)
			{
				return 1f;
			}
		}
		if (this.remapCurve.length != 0)
		{
			num = this.remapCurve[this.remapCurve.length - 1].time;
		}
		global::UnityEngine.Color color;
		color..ctor(0f, 0f, 0f);
		for (float num2 = 0f; num2 <= 1f; num2 += 0.003921569f)
		{
			color.r = this.remapCurve.Evaluate(num2 * 1f * num);
			color.g = (color.b = color.r);
			this.curveTex.SetPixel(global::UnityEngine.Mathf.FloorToInt(num2 * 255f), 0, color);
		}
		this.curveTex.Apply();
		return 1f / num;
	}

	// Token: 0x060018B5 RID: 6325 RVA: 0x0005F6A4 File Offset: 0x0005D8A4
	private bool CreateInternalRenderTexture()
	{
		if (this.rt)
		{
			return false;
		}
		this.rtFormat = ((!global::UnityEngine.SystemInfo.SupportsRenderTextureFormat(0xD)) ? 2 : 0xD);
		this.rt = new global::UnityEngine.RenderTexture(1, 1, 0, this.rtFormat)
		{
			hideFlags = 4
		};
		return true;
	}

	// Token: 0x060018B6 RID: 6326 RVA: 0x0005F6FC File Offset: 0x0005D8FC
	protected sealed override void Configure()
	{
		this.supported = (base.Support(global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget) && this.CheckResources());
	}

	// Token: 0x060018B7 RID: 6327 RVA: 0x0005F71C File Offset: 0x0005D91C
	protected sealed override void DeConfigure()
	{
		if (this.rt)
		{
			global::UnityEngine.Object.DestroyImmediate(this.rt);
			this.rt = null;
		}
		if (this.curveTex)
		{
			global::UnityEngine.Object.DestroyImmediate(this.curveTex);
			this.curveTex = null;
		}
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x0005F770 File Offset: 0x0005D970
	private bool HistogramBlit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		if (this.wantNewBuckets)
		{
			int width = src.width;
			int height = src.height;
			if (!this.bucketRT)
			{
				this.bucketRT = new global::UnityEngine.RenderTexture(width, height, 0, 7)
				{
					hideFlags = 4
				};
			}
			else if (this.bucketRT.width != width || this.bucketRT.height != height)
			{
				global::UnityEngine.Object.DestroyImmediate(this.bucketRT);
				this.bucketRT = new global::UnityEngine.RenderTexture(width, height, 0, 7)
				{
					hideFlags = 4
				};
			}
			global::UnityEngine.Matrix4x4 matrix4x;
			matrix4x.m00 = this.bucketMin;
			matrix4x.m01 = this.bucket1;
			matrix4x.m02 = this.bucket2;
			matrix4x.m03 = this.bucket3;
			matrix4x.m10 = this.bucket4;
			matrix4x.m11 = this.bucket5;
			matrix4x.m12 = this.bucket6;
			matrix4x.m13 = this.bucket7;
			matrix4x.m20 = this.bucket8;
			matrix4x.m21 = this.bucket9;
			matrix4x.m22 = this.bucket10;
			matrix4x.m23 = this.bucket11;
			matrix4x.m30 = this.bucket12;
			matrix4x.m31 = this.bucket13;
			matrix4x.m32 = this.bucket14;
			matrix4x.m33 = this.bucket15;
			this.bucketeeMaterial.SetMatrix("_BucketVars", matrix4x);
			this.bucketeeMaterial.SetFloat("_BucketVar16", this.bucketMax);
			global::UnityEngine.FilterMode filterMode = src.filterMode;
			if (filterMode != null)
			{
				try
				{
					src.filterMode = 0;
					global::UnityEngine.Graphics.Blit(src, this.bucketRT, this.bucketeeMaterial, 0);
				}
				finally
				{
					src.filterMode = filterMode;
				}
			}
			else
			{
				global::UnityEngine.Graphics.Blit(src, this.bucketRT, this.bucketeeMaterial, 0);
			}
			if (!this.bucketT)
			{
				this.bucketT = new global::UnityEngine.Texture2D(width, height, 3, false)
				{
					hideFlags = 4
				};
			}
			else if (this.bucketT.width != width || this.bucketT.height != height)
			{
				global::UnityEngine.Object.DestroyImmediate(this.bucketT);
				this.bucketT = new global::UnityEngine.Texture2D(width, height, 3, false)
				{
					hideFlags = 4
				};
			}
			global::UnityEngine.RenderTexture active = global::UnityEngine.RenderTexture.active;
			try
			{
				global::UnityEngine.RenderTexture.active = this.bucketRT;
				if (this.posX >= width)
				{
					this.posX = 0;
				}
				if (this.posY >= height)
				{
					this.posY = 0;
				}
				int num;
				if (this.posX + 8 > width)
				{
					num = 8 - (this.posX + 8 - width);
				}
				else
				{
					num = 8;
				}
				int num2;
				if (this.posY + 8 > height)
				{
					num2 = 8 - (this.posY + 8 - height);
				}
				else
				{
					num2 = 8;
				}
				this.bucketT.ReadPixels(new global::UnityEngine.Rect((float)this.posX, (float)this.posY, (float)num, (float)num2), this.posX, this.posY, false);
				this.posX += num;
				if (this.posX == width)
				{
					this.posX = 0;
					this.posY += num2;
					if (this.posY == height)
					{
						this.bucketT.Apply();
						this.posY = 0;
					}
				}
			}
			finally
			{
				global::UnityEngine.RenderTexture.active = active;
			}
		}
		global::UnityEngine.Graphics.Blit(src, dst);
		return true;
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x0005FB14 File Offset: 0x0005DD14
	protected sealed override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		float num = this.exposureAdjustment * global::GFxImageEffect_ToneMapping.global_exposure_scale;
		num = ((num >= 0.001f) ? num : 0.001f);
		switch (this.type)
		{
		case global::GFxImageEffect_ToneMapping.TonemapperType.SimpleReinhard:
			this.tonemapMaterial.SetFloat("_ExposureAdjustment", num);
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 6);
			return true;
		case global::GFxImageEffect_ToneMapping.TonemapperType.UserCurve:
		{
			float num2 = this.UpdateCurve();
			this.tonemapMaterial.SetFloat("_RangeScale", num2);
			this.tonemapMaterial.SetTexture("_Curve", this.curveTex);
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 4);
			return true;
		}
		case global::GFxImageEffect_ToneMapping.TonemapperType.Hable:
			this.tonemapMaterial.SetFloat("_ExposureAdjustment", num);
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 5);
			return true;
		case global::GFxImageEffect_ToneMapping.TonemapperType.Photographic:
			this.tonemapMaterial.SetFloat("_ExposureAdjustment", num);
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 8);
			return true;
		case global::GFxImageEffect_ToneMapping.TonemapperType.OptimizedHejiDawson:
			this.tonemapMaterial.SetFloat("_ExposureAdjustment", 0.5f * num);
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 7);
			return true;
		case global::GFxImageEffect_ToneMapping.TonemapperType.Histogram:
			return this.HistogramBlit(src, dst);
		case global::GFxImageEffect_ToneMapping.TonemapperType.None:
			global::UnityEngine.Graphics.Blit(src, dst);
			return true;
		}
		this.CreateInternalRenderTexture();
		global::UnityEngine.RenderTexture temporary = global::UnityEngine.RenderTexture.GetTemporary((int)this.adaptiveTextureSize, (int)this.adaptiveTextureSize, 0, this.rtFormat);
		global::UnityEngine.Graphics.Blit(src, temporary);
		int num3 = (int)global::UnityEngine.Mathf.Log((float)temporary.width * 1f, 2f);
		int num4 = 2;
		global::System.Array.Resize<global::UnityEngine.RenderTexture>(ref this.rtArray, num3);
		global::UnityEngine.RenderTexture[] array = this.rtArray;
		for (int i = 0; i < num3; i++)
		{
			array[i] = global::UnityEngine.RenderTexture.GetTemporary(temporary.width / num4, temporary.width / num4, 0, this.rtFormat);
			num4 *= 2;
		}
		global::UnityEngine.RenderTexture renderTexture = array[num3 - 1];
		global::UnityEngine.Graphics.Blit(temporary, array[0], this.tonemapMaterial, 1);
		global::GFxImageEffect_ToneMapping.TonemapperType tonemapperType = this.type;
		if (tonemapperType != global::GFxImageEffect_ToneMapping.TonemapperType.AdaptiveReinhard)
		{
			if (tonemapperType == global::GFxImageEffect_ToneMapping.TonemapperType.AdaptiveReinhardAutoWhite)
			{
				for (int j = 0; j < num3 - 1; j++)
				{
					global::UnityEngine.Graphics.Blit(array[j], array[j + 1], this.tonemapMaterial, 9);
					renderTexture = array[j + 1];
				}
			}
		}
		else
		{
			for (int k = 0; k < num3 - 1; k++)
			{
				global::UnityEngine.Graphics.Blit(array[k], array[k + 1]);
				renderTexture = array[k + 1];
			}
		}
		this.adaptionSpeed = ((this.adaptionSpeed >= 0.001f) ? this.adaptionSpeed : 0.001f);
		this.tonemapMaterial.SetFloat("_AdaptionSpeed", this.adaptionSpeed);
		global::UnityEngine.Graphics.Blit(renderTexture, this.rt, this.tonemapMaterial, 2);
		this.middleGrey = ((this.middleGrey >= 0.001f) ? this.middleGrey : 0.001f);
		this.tonemapMaterial.SetVector("_HdrParams", new global::UnityEngine.Vector4(this.middleGrey, this.middleGrey, this.middleGrey, this.white * this.white));
		this.tonemapMaterial.SetTexture("_SmallTex", this.rt);
		this.tonemapMaterial.SetVector("_ExposureMinMax", new global::UnityEngine.Vector4(this.exposureMin, this.exposureMax, 0f, 0f));
		if (this.type == global::GFxImageEffect_ToneMapping.TonemapperType.AdaptiveReinhard)
		{
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 0);
		}
		else if (this.type == global::GFxImageEffect_ToneMapping.TonemapperType.AdaptiveReinhardAutoWhite)
		{
			global::UnityEngine.Graphics.Blit(src, dst, this.tonemapMaterial, 0xA);
		}
		else
		{
			global::UnityEngine.Debug.LogError("No valid adaptive tonemapper type found!");
			global::UnityEngine.Graphics.Blit(src, dst);
		}
		for (int l = 0; l < num3; l++)
		{
			global::UnityEngine.RenderTexture.ReleaseTemporary(array[l]);
			array[l] = null;
		}
		global::UnityEngine.RenderTexture.ReleaseTemporary(temporary);
		return true;
	}

	// Token: 0x04000DC6 RID: 3526
	private const int bucketFrame = 8;

	// Token: 0x04000DC7 RID: 3527
	public static float global_exposure_scale = 1f;

	// Token: 0x04000DC8 RID: 3528
	public global::GFxImageEffect_ToneMapping.TonemapperType type = global::GFxImageEffect_ToneMapping.TonemapperType.Photographic;

	// Token: 0x04000DC9 RID: 3529
	public global::GFxImageEffect_ToneMapping.AdaptiveTexSize adaptiveTextureSize = global::GFxImageEffect_ToneMapping.AdaptiveTexSize.Square256;

	// Token: 0x04000DCA RID: 3530
	public global::UnityEngine.AnimationCurve remapCurve;

	// Token: 0x04000DCB RID: 3531
	private global::UnityEngine.Texture2D curveTex;

	// Token: 0x04000DCC RID: 3532
	public float exposureAdjustment = 1.5f;

	// Token: 0x04000DCD RID: 3533
	public float exposureMin = float.NegativeInfinity;

	// Token: 0x04000DCE RID: 3534
	public float exposureMax = float.PositiveInfinity;

	// Token: 0x04000DCF RID: 3535
	public float middleGrey = 0.4f;

	// Token: 0x04000DD0 RID: 3536
	public float white = 2f;

	// Token: 0x04000DD1 RID: 3537
	public float adaptionSpeed = 1.5f;

	// Token: 0x04000DD2 RID: 3538
	public global::UnityEngine.Shader tonemapper;

	// Token: 0x04000DD3 RID: 3539
	public global::UnityEngine.Shader bucketee;

	// Token: 0x04000DD4 RID: 3540
	private global::UnityEngine.Material bucketeeMaterial;

	// Token: 0x04000DD5 RID: 3541
	private global::UnityEngine.RenderTextureFormat rtFormat = 2;

	// Token: 0x04000DD6 RID: 3542
	public float bucketMin;

	// Token: 0x04000DD7 RID: 3543
	public float bucket1 = 0.5f;

	// Token: 0x04000DD8 RID: 3544
	public float bucket2 = 0.6f;

	// Token: 0x04000DD9 RID: 3545
	public float bucket3 = 0.75f;

	// Token: 0x04000DDA RID: 3546
	public float bucket4 = 0.95f;

	// Token: 0x04000DDB RID: 3547
	public float bucket5 = 1.2f;

	// Token: 0x04000DDC RID: 3548
	public float bucket6 = 1.4f;

	// Token: 0x04000DDD RID: 3549
	public float bucket7 = 1.6f;

	// Token: 0x04000DDE RID: 3550
	public float bucket8 = 1.8f;

	// Token: 0x04000DDF RID: 3551
	public float bucket9 = 2f;

	// Token: 0x04000DE0 RID: 3552
	public float bucket10 = 2.3f;

	// Token: 0x04000DE1 RID: 3553
	public float bucket11 = 2.5f;

	// Token: 0x04000DE2 RID: 3554
	public float bucket12 = 3f;

	// Token: 0x04000DE3 RID: 3555
	public float bucket13 = 3.2f;

	// Token: 0x04000DE4 RID: 3556
	public float bucket14 = 3.5f;

	// Token: 0x04000DE5 RID: 3557
	public float bucket15 = 3.7f;

	// Token: 0x04000DE6 RID: 3558
	public float bucketMax = 4f;

	// Token: 0x04000DE7 RID: 3559
	[global::System.NonSerialized]
	public bool validRenderTextureFormat = true;

	// Token: 0x04000DE8 RID: 3560
	private global::UnityEngine.Material tonemapMaterial;

	// Token: 0x04000DE9 RID: 3561
	private global::UnityEngine.RenderTexture rt;

	// Token: 0x04000DEA RID: 3562
	internal static bool r_tonemapping = true;

	// Token: 0x04000DEB RID: 3563
	private global::System.Threading.Thread histogramThread;

	// Token: 0x04000DEC RID: 3564
	private object histogramThreadLock;

	// Token: 0x04000DED RID: 3565
	private bool wantNewBuckets = true;

	// Token: 0x04000DEE RID: 3566
	private global::UnityEngine.RenderTexture bucketRT;

	// Token: 0x04000DEF RID: 3567
	private global::UnityEngine.Texture2D bucketT;

	// Token: 0x04000DF0 RID: 3568
	private global::UnityEngine.Color32[] bucketPixels;

	// Token: 0x04000DF1 RID: 3569
	private int posX;

	// Token: 0x04000DF2 RID: 3570
	private int posY;

	// Token: 0x04000DF3 RID: 3571
	private global::UnityEngine.RenderTexture[] rtArray;

	// Token: 0x020002C5 RID: 709
	public enum TonemapperType
	{
		// Token: 0x04000DF5 RID: 3573
		SimpleReinhard,
		// Token: 0x04000DF6 RID: 3574
		UserCurve,
		// Token: 0x04000DF7 RID: 3575
		Hable,
		// Token: 0x04000DF8 RID: 3576
		Photographic,
		// Token: 0x04000DF9 RID: 3577
		OptimizedHejiDawson,
		// Token: 0x04000DFA RID: 3578
		AdaptiveReinhard,
		// Token: 0x04000DFB RID: 3579
		AdaptiveReinhardAutoWhite,
		// Token: 0x04000DFC RID: 3580
		Histogram,
		// Token: 0x04000DFD RID: 3581
		None = 9
	}

	// Token: 0x020002C6 RID: 710
	public enum AdaptiveTexSize
	{
		// Token: 0x04000DFF RID: 3583
		Square16 = 0x10,
		// Token: 0x04000E00 RID: 3584
		Square32 = 0x20,
		// Token: 0x04000E01 RID: 3585
		Square64 = 0x40,
		// Token: 0x04000E02 RID: 3586
		Square128 = 0x80,
		// Token: 0x04000E03 RID: 3587
		Square256 = 0x100,
		// Token: 0x04000E04 RID: 3588
		Square512 = 0x200,
		// Token: 0x04000E05 RID: 3589
		Square1024 = 0x400
	}
}
