using System;
using UnityEngine;

// Token: 0x020002B1 RID: 689
public class GFxImageEffect_Bloom : global::GFxImageEffect
{
	// Token: 0x06001844 RID: 6212 RVA: 0x0005C14C File Offset: 0x0005A34C
	public GFxImageEffect_Bloom()
	{
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x0005C250 File Offset: 0x0005A450
	// Note: this type is marked as 'beforefieldinit'.
	static GFxImageEffect_Bloom()
	{
	}

	// Token: 0x1700069D RID: 1693
	// (get) Token: 0x06001846 RID: 6214 RVA: 0x0005C258 File Offset: 0x0005A458
	public override bool allow
	{
		get
		{
			return global::GFxImageEffect_Bloom.r_bloom;
		}
	}

	// Token: 0x06001847 RID: 6215 RVA: 0x0005C260 File Offset: 0x0005A460
	private void CopyVars()
	{
		global::GFxImageEffect_Bloom gfxImageEffect_Bloom = this.prefab as global::GFxImageEffect_Bloom;
		this.tweakMode = gfxImageEffect_Bloom.tweakMode;
		this.hdr = gfxImageEffect_Bloom.hdr;
		this.sepBlurSpread = gfxImageEffect_Bloom.sepBlurSpread;
		this.useSrcAlphaAsMask = gfxImageEffect_Bloom.useSrcAlphaAsMask;
		this.bloomIntensity = gfxImageEffect_Bloom.bloomIntensity;
		this.bloomThreshhold = gfxImageEffect_Bloom.bloomThreshhold;
		this.bloomBlurIterations = gfxImageEffect_Bloom.bloomBlurIterations;
		this.lensflares = gfxImageEffect_Bloom.lensflares;
		this.hollywoodFlareBlurIterations = gfxImageEffect_Bloom.hollywoodFlareBlurIterations;
		this.lensflareMode = gfxImageEffect_Bloom.lensflareMode;
		this.hollyStretchWidth = gfxImageEffect_Bloom.hollyStretchWidth;
		this.lensflareIntensity = gfxImageEffect_Bloom.lensflareIntensity;
		this.lensflareThreshhold = gfxImageEffect_Bloom.lensflareThreshhold;
		this.flareColorA = gfxImageEffect_Bloom.flareColorA;
		this.flareColorB = gfxImageEffect_Bloom.flareColorB;
		this.flareColorC = gfxImageEffect_Bloom.flareColorC;
		this.flareColorD = gfxImageEffect_Bloom.flareColorD;
		this.blurWidth = gfxImageEffect_Bloom.blurWidth;
		this.lensFlareVignetteMask = gfxImageEffect_Bloom.lensFlareVignetteMask;
	}

	// Token: 0x06001848 RID: 6216 RVA: 0x0005C360 File Offset: 0x0005A560
	protected sealed override void Configure()
	{
		this.requirements = (global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTarget | ((this.hdr != global::GFxImageEffect_Bloom.HDRBloomMode.On) ? global::GFxImageEffect.Caps.Required.RenderTarget : (global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget)));
		this.supported = (base.Support(this.requirements) && this.CheckResources());
	}

	// Token: 0x06001849 RID: 6217 RVA: 0x0005C3A0 File Offset: 0x0005A5A0
	protected sealed override void DeConfigure()
	{
		this.screenBlend.Shutdown();
		this.lensFlareMaterial.Shutdown();
		this.vignetteMaterial.Shutdown();
		this.separableBlurMaterial.Shutdown();
		this.addBrightStuffBlendOneOneMaterial.Shutdown();
		this.hollywoodFlaresMaterial.Shutdown();
		this.brightPassFilterMaterial.Shutdown();
	}

	// Token: 0x0600184A RID: 6218 RVA: 0x0005C3FC File Offset: 0x0005A5FC
	private bool CheckResources()
	{
		bool flag = false;
		if (global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.screenBlendShader, ref this.screenBlend.mat), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.lensFlareShader, ref this.lensFlareMaterial.mat), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.vignetteShader, ref this.vignetteMaterial.mat), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.separableBlurShader, ref this.separableBlurMaterial.mat), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.addBrightStuffOneOneShader, ref this.addBrightStuffBlendOneOneMaterial.mat), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.hollywoodFlaresShader, ref this.hollywoodFlaresMaterial.mat), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.brightPassFilterShader, ref this.brightPassFilterMaterial.mat), ref flag))
		{
			if (flag)
			{
				this.screenBlend.Initialize();
				this.lensFlareMaterial.Initialize();
				this.vignetteMaterial.Initialize();
				this.separableBlurMaterial.Initialize();
				this.addBrightStuffBlendOneOneMaterial.Initialize();
				this.hollywoodFlaresMaterial.Initialize();
				this.brightPassFilterMaterial.Initialize();
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600184B RID: 6219 RVA: 0x0005C558 File Offset: 0x0005A758
	protected sealed override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		if (!global::GFxImageEffect_Bloom.r_bloom)
		{
			return false;
		}
		global::GFxImageEffect_Bloom.BloomScreenBlendMode bloomScreenBlendMode;
		global::UnityEngine.RenderTextureFormat format;
		try
		{
			if ((this.requirements & global::GFxImageEffect.Caps.Required.RenderTargetHDR) == global::GFxImageEffect.Caps.Required.RenderTargetHDR && this.hdr != global::GFxImageEffect_Bloom.HDRBloomMode.Off && (this.hdr == global::GFxImageEffect_Bloom.HDRBloomMode.On || (src.format == 2 && this.processor.hdr)))
			{
				this.doHdr = true;
				bloomScreenBlendMode = global::GFxImageEffect_Bloom.BloomScreenBlendMode.Add;
				format = 2;
			}
			else
			{
				this.doHdr = false;
				bloomScreenBlendMode = this.screenBlendMode;
				format = 7;
			}
		}
		catch
		{
			this.doHdr = false;
			throw;
		}
		int width = src.width;
		int height = src.height;
		int width2 = width / 2;
		int height2 = height / 2;
		int width3 = width / 4;
		int height3 = height / 4;
		double num = (double)width / (double)height;
		bool result;
		using (global::GFxImageEffect.Scratch scratch = new global::GFxImageEffect.Scratch(width3, height3, 0, format))
		{
			using (global::GFxImageEffect.Scratch scratch2 = new global::GFxImageEffect.Scratch(width2, height2, 0, format))
			{
				global::UnityEngine.Graphics.Blit(src, scratch2.target, this.screenBlend.mat, 2);
				global::UnityEngine.Graphics.Blit(scratch2.target, scratch.target, this.screenBlend.mat, 2);
			}
			using (global::GFxImageEffect.Scratch scratch3 = new global::GFxImageEffect.Scratch(width3, height3, 0, format))
			{
				this.BrightFilter(this.bloomThreshhold, this.useSrcAlphaAsMask, scratch.target, scratch3.target);
				using (global::GFxImageEffect.Scratch scratch4 = new global::GFxImageEffect.Scratch(width3, height3, 0, format))
				{
					int num2 = 0;
					global::UnityEngine.RenderTexture target = scratch3.target;
					do
					{
						double num3 = (1.0 + (double)num2 * 0.5) * (double)this.sepBlurSpread;
						global::UnityEngine.Vector2 offsets;
						offsets.x = 0f;
						offsets.y = (float)(num3 * 0.001953125);
						this.separableBlurMaterial.offsets = offsets;
						global::UnityEngine.Graphics.Blit(target, scratch4.target, this.separableBlurMaterial.Bind());
						offsets.x = (float)(num3 / num * 0.001953125);
						offsets.y = 0f;
						this.separableBlurMaterial.offsets = offsets;
						global::UnityEngine.Graphics.Blit(scratch4.target, scratch.target, this.separableBlurMaterial.Bind());
						target = scratch.target;
					}
					while (++num2 < this.bloomBlurIterations);
					if (this.lensflares)
					{
						global::GFxImageEffect_Bloom.LensflareStyle34 lensflareStyle = this.lensflareMode;
						if (lensflareStyle != global::GFxImageEffect_Bloom.LensflareStyle34.Ghosting)
						{
							this.hollywoodFlaresMaterial.threshhold = new global::UnityEngine.Vector2(this.lensflareThreshhold, 1f / (1f - this.lensflareThreshhold));
							float num4 = this.flareColorA.a * this.lensflareIntensity;
							global::UnityEngine.Vector4 tintColor;
							tintColor.x = this.flareColorA.r * num4;
							tintColor.y = this.flareColorA.g * num4;
							tintColor.z = this.flareColorA.b * num4;
							tintColor.w = this.flareColorA.a * num4;
							this.hollywoodFlaresMaterial.tintColor = tintColor;
							global::UnityEngine.Graphics.Blit(scratch4.target, scratch3.target, this.hollywoodFlaresMaterial.Bind(), 2);
							global::UnityEngine.Graphics.Blit(scratch3.target, scratch4.target, this.hollywoodFlaresMaterial.mat, 3);
							this.hollywoodFlaresMaterial.offsets = new global::UnityEngine.Vector2((float)((double)(this.sepBlurSpread * 1f) / num * 0.001953125), 0f);
							this.hollywoodFlaresMaterial.stretchWidth = this.hollyStretchWidth;
							global::UnityEngine.Graphics.Blit(scratch4.target, scratch3.target, this.hollywoodFlaresMaterial.Bind(), 1);
							this.hollywoodFlaresMaterial.stretchWidth = this.hollyStretchWidth * 2f;
							global::UnityEngine.Graphics.Blit(scratch3.target, scratch4.target, this.hollywoodFlaresMaterial.Bind(), 1);
							this.hollywoodFlaresMaterial.stretchWidth = this.hollyStretchWidth * 4f;
							global::UnityEngine.Graphics.Blit(scratch4.target, scratch3.target, this.hollywoodFlaresMaterial.Bind(), 1);
							global::UnityEngine.Vector2 offsets2;
							offsets2.y = 0f;
							int i = 0;
							global::GFxImageEffect_Bloom.LensflareStyle34 lensflareStyle2 = this.lensflareMode;
							if (lensflareStyle2 != global::GFxImageEffect_Bloom.LensflareStyle34.Anamorphic)
							{
								while (i < this.hollywoodFlareBlurIterations)
								{
									offsets2.x = (float)((double)(this.hollyStretchWidth * 2f) / num * 0.001953125);
									this.separableBlurMaterial.offsets = offsets2;
									global::UnityEngine.Graphics.Blit(scratch3.target, scratch4.target, this.separableBlurMaterial.Bind());
									offsets2.x = (float)((double)(this.hollyStretchWidth * 2f) / num * 0.001953125);
									this.separableBlurMaterial.offsets = offsets2;
									global::UnityEngine.Graphics.Blit(scratch4.target, scratch3.target, this.separableBlurMaterial.Bind());
									i++;
								}
								this.Vignette(1f, scratch3.target, scratch4.target);
								this.BlendFlares(scratch4.target, scratch3.target);
								this.AddTo(1f, scratch3.target, scratch.target);
							}
							else
							{
								while (i < this.hollywoodFlareBlurIterations)
								{
									offsets2.x = (float)((double)(this.hollyStretchWidth * 2f) / num * 0.001953125);
									this.separableBlurMaterial.offsets = offsets2;
									global::UnityEngine.Graphics.Blit(scratch3.target, scratch4.target, this.separableBlurMaterial.Bind());
									offsets2.x = (float)((double)(this.hollyStretchWidth * 2f) / num * 0.001953125);
									this.separableBlurMaterial.offsets = offsets2;
									global::UnityEngine.Graphics.Blit(scratch4.target, scratch3.target, this.separableBlurMaterial.Bind());
									i++;
								}
								this.AddTo(1f, scratch3.target, scratch.target);
							}
						}
						else
						{
							this.BrightFilter(this.lensflareThreshhold, 0f, scratch.target, scratch4.target);
							this.Vignette(0.975f, scratch4.target, scratch3.target);
							this.BlendFlares(scratch3.target, scratch.target);
						}
					}
				}
			}
			this.screenBlend.intensity = this.bloomIntensity;
			this.screenBlend.colorBuffer = src;
			global::UnityEngine.Graphics.Blit(scratch.target, dst, this.screenBlend.Bind(), (int)bloomScreenBlendMode);
			result = true;
		}
		return result;
	}

	// Token: 0x0600184C RID: 6220 RVA: 0x0005CC8C File Offset: 0x0005AE8C
	private void AddTo(float intensity_, global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		this.addBrightStuffBlendOneOneMaterial.intensity = intensity_;
		global::UnityEngine.Graphics.Blit(src, dst, this.addBrightStuffBlendOneOneMaterial.Bind());
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x0005CCAC File Offset: 0x0005AEAC
	private void BlendFlares(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		global::UnityEngine.Vector4 vector;
		vector.x = this.flareColorA.r * this.lensflareIntensity;
		vector.y = this.flareColorA.g * this.lensflareIntensity;
		vector.z = this.flareColorA.b * this.lensflareIntensity;
		vector.w = this.flareColorA.a * this.lensflareIntensity;
		this.lensFlareMaterial.colorA = vector;
		vector.x = this.flareColorB.r * this.lensflareIntensity;
		vector.y = this.flareColorB.g * this.lensflareIntensity;
		vector.z = this.flareColorB.b * this.lensflareIntensity;
		vector.w = this.flareColorB.a * this.lensflareIntensity;
		this.lensFlareMaterial.colorB = vector;
		vector.x = this.flareColorC.r * this.lensflareIntensity;
		vector.y = this.flareColorC.g * this.lensflareIntensity;
		vector.z = this.flareColorC.b * this.lensflareIntensity;
		vector.w = this.flareColorC.a * this.lensflareIntensity;
		this.lensFlareMaterial.colorC = vector;
		vector.x = this.flareColorD.r * this.lensflareIntensity;
		vector.y = this.flareColorD.g * this.lensflareIntensity;
		vector.z = this.flareColorD.b * this.lensflareIntensity;
		vector.w = this.flareColorD.a * this.lensflareIntensity;
		this.lensFlareMaterial.colorD = vector;
		global::UnityEngine.Graphics.Blit(src, dst, this.lensFlareMaterial.Bind());
	}

	// Token: 0x0600184E RID: 6222 RVA: 0x0005CE8C File Offset: 0x0005B08C
	private void BrightFilter(float thresh, float useAlphaAsMask, global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		global::UnityEngine.Vector2 threshhold;
		threshhold.x = thresh;
		threshhold.y = ((!this.doHdr) ? (1f / (1f - thresh)) : 1f);
		this.brightPassFilterMaterial.threshhold = threshhold;
		this.brightPassFilterMaterial.useAlphaAsMask = useAlphaAsMask;
		global::UnityEngine.Graphics.Blit(src, dst, this.brightPassFilterMaterial.Bind());
	}

	// Token: 0x0600184F RID: 6223 RVA: 0x0005CEF8 File Offset: 0x0005B0F8
	private void Vignette(float amount, global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		if (this.lensFlareVignetteMask)
		{
			this.screenBlend.colorBuffer = this.lensFlareVignetteMask;
			global::UnityEngine.Graphics.Blit(src, dst, this.screenBlend.Bind(), 3);
		}
		else
		{
			this.vignetteMaterial.vignetteIntensity = amount;
			global::UnityEngine.Graphics.Blit(src, dst, this.vignetteMaterial.Bind());
		}
	}

	// Token: 0x04000D2D RID: 3373
	private const double oneOverBaseSize = 0.001953125;

	// Token: 0x04000D2E RID: 3374
	internal static bool r_bloom = true;

	// Token: 0x04000D2F RID: 3375
	public global::GFxImageEffect_Bloom.TweakMode34 tweakMode;

	// Token: 0x04000D30 RID: 3376
	public global::GFxImageEffect_Bloom.BloomScreenBlendMode screenBlendMode = global::GFxImageEffect_Bloom.BloomScreenBlendMode.Add;

	// Token: 0x04000D31 RID: 3377
	public global::GFxImageEffect_Bloom.HDRBloomMode hdr;

	// Token: 0x04000D32 RID: 3378
	private bool doHdr;

	// Token: 0x04000D33 RID: 3379
	public float sepBlurSpread = 1.5f;

	// Token: 0x04000D34 RID: 3380
	public float useSrcAlphaAsMask = 0.5f;

	// Token: 0x04000D35 RID: 3381
	public float bloomIntensity = 1f;

	// Token: 0x04000D36 RID: 3382
	public float bloomThreshhold = 0.5f;

	// Token: 0x04000D37 RID: 3383
	public int bloomBlurIterations = 2;

	// Token: 0x04000D38 RID: 3384
	public bool lensflares;

	// Token: 0x04000D39 RID: 3385
	public int hollywoodFlareBlurIterations = 2;

	// Token: 0x04000D3A RID: 3386
	public global::GFxImageEffect_Bloom.LensflareStyle34 lensflareMode = global::GFxImageEffect_Bloom.LensflareStyle34.Anamorphic;

	// Token: 0x04000D3B RID: 3387
	public float hollyStretchWidth = 3.5f;

	// Token: 0x04000D3C RID: 3388
	public float lensflareIntensity = 1f;

	// Token: 0x04000D3D RID: 3389
	public float lensflareThreshhold = 0.3f;

	// Token: 0x04000D3E RID: 3390
	public global::UnityEngine.Color flareColorA = new global::UnityEngine.Color(0.4f, 0.4f, 0.8f, 0.75f);

	// Token: 0x04000D3F RID: 3391
	public global::UnityEngine.Color flareColorB = new global::UnityEngine.Color(0.4f, 0.8f, 0.8f, 0.75f);

	// Token: 0x04000D40 RID: 3392
	public global::UnityEngine.Color flareColorC = new global::UnityEngine.Color(0.8f, 0.4f, 0.8f, 0.75f);

	// Token: 0x04000D41 RID: 3393
	public global::UnityEngine.Color flareColorD = new global::UnityEngine.Color(0.8f, 0.4f, 0f, 0.75f);

	// Token: 0x04000D42 RID: 3394
	public float blurWidth = 1f;

	// Token: 0x04000D43 RID: 3395
	public global::UnityEngine.Texture2D lensFlareVignetteMask;

	// Token: 0x04000D44 RID: 3396
	private global::GFxImageEffect.Caps.Required requirements;

	// Token: 0x04000D45 RID: 3397
	public global::UnityEngine.Shader lensFlareShader;

	// Token: 0x04000D46 RID: 3398
	public global::UnityEngine.Shader vignetteShader;

	// Token: 0x04000D47 RID: 3399
	public global::UnityEngine.Shader separableBlurShader;

	// Token: 0x04000D48 RID: 3400
	public global::UnityEngine.Shader addBrightStuffOneOneShader;

	// Token: 0x04000D49 RID: 3401
	public global::UnityEngine.Shader screenBlendShader;

	// Token: 0x04000D4A RID: 3402
	public global::UnityEngine.Shader hollywoodFlaresShader;

	// Token: 0x04000D4B RID: 3403
	public global::UnityEngine.Shader brightPassFilterShader;

	// Token: 0x04000D4C RID: 3404
	private global::GFxImageEffect_Bloom.LensFlareMat lensFlareMaterial;

	// Token: 0x04000D4D RID: 3405
	private global::GFxImageEffect_Bloom.VignetteMat vignetteMaterial;

	// Token: 0x04000D4E RID: 3406
	private global::GFxImageEffect_Bloom.SeperableBlurMat separableBlurMaterial;

	// Token: 0x04000D4F RID: 3407
	private global::GFxImageEffect_Bloom.AddBrightStuffOneOneMat addBrightStuffBlendOneOneMaterial;

	// Token: 0x04000D50 RID: 3408
	private global::GFxImageEffect_Bloom.ScreenBlendMat screenBlend;

	// Token: 0x04000D51 RID: 3409
	private global::GFxImageEffect_Bloom.HollywoodFlaresMat hollywoodFlaresMaterial;

	// Token: 0x04000D52 RID: 3410
	private global::GFxImageEffect_Bloom.BrightPassFilterMat brightPassFilterMaterial;

	// Token: 0x020002B2 RID: 690
	public enum LensflareStyle34
	{
		// Token: 0x04000D54 RID: 3412
		Ghosting,
		// Token: 0x04000D55 RID: 3413
		Anamorphic,
		// Token: 0x04000D56 RID: 3414
		Combined
	}

	// Token: 0x020002B3 RID: 691
	public enum TweakMode34
	{
		// Token: 0x04000D58 RID: 3416
		Basic,
		// Token: 0x04000D59 RID: 3417
		Complex
	}

	// Token: 0x020002B4 RID: 692
	public enum HDRBloomMode
	{
		// Token: 0x04000D5B RID: 3419
		Auto,
		// Token: 0x04000D5C RID: 3420
		On,
		// Token: 0x04000D5D RID: 3421
		Off
	}

	// Token: 0x020002B5 RID: 693
	public enum BloomScreenBlendMode
	{
		// Token: 0x04000D5F RID: 3423
		Screen,
		// Token: 0x04000D60 RID: 3424
		Add
	}

	// Token: 0x020002B6 RID: 694
	private struct LensFlareMat
	{
		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06001850 RID: 6224 RVA: 0x0005CF5C File Offset: 0x0005B15C
		// (set) Token: 0x06001851 RID: 6225 RVA: 0x0005CF6C File Offset: 0x0005B16C
		public global::UnityEngine.Vector4 colorA
		{
			get
			{
				return this._colorA.value;
			}
			set
			{
				this._colorA.value = value;
			}
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06001852 RID: 6226 RVA: 0x0005CF7C File Offset: 0x0005B17C
		// (set) Token: 0x06001853 RID: 6227 RVA: 0x0005CF8C File Offset: 0x0005B18C
		public global::UnityEngine.Vector4 colorB
		{
			get
			{
				return this._colorB.value;
			}
			set
			{
				this._colorB.value = value;
			}
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06001854 RID: 6228 RVA: 0x0005CF9C File Offset: 0x0005B19C
		// (set) Token: 0x06001855 RID: 6229 RVA: 0x0005CFAC File Offset: 0x0005B1AC
		public global::UnityEngine.Vector4 colorC
		{
			get
			{
				return this._colorC.value;
			}
			set
			{
				this._colorC.value = value;
			}
		}

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06001856 RID: 6230 RVA: 0x0005CFBC File Offset: 0x0005B1BC
		// (set) Token: 0x06001857 RID: 6231 RVA: 0x0005CFCC File Offset: 0x0005B1CC
		public global::UnityEngine.Vector4 colorD
		{
			get
			{
				return this._colorD.value;
			}
			set
			{
				this._colorD.value = value;
			}
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x0005CFDC File Offset: 0x0005B1DC
		public void Initialize()
		{
			this._colorA = new global::GFxImageEffect.MatVarVector("colorA");
			this._colorB = new global::GFxImageEffect.MatVarVector("colorB");
			this._colorC = new global::GFxImageEffect.MatVarVector("colorC");
			this._colorD = new global::GFxImageEffect.MatVarVector("colorD");
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x0005D02C File Offset: 0x0005B22C
		public void Shutdown()
		{
			this.mat = null;
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x0005D038 File Offset: 0x0005B238
		public global::UnityEngine.Material Bind()
		{
			this._colorA.Bind(this.mat);
			this._colorB.Bind(this.mat);
			this._colorC.Bind(this.mat);
			this._colorD.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x04000D61 RID: 3425
		public global::UnityEngine.Material mat;

		// Token: 0x04000D62 RID: 3426
		private global::GFxImageEffect.MatVarVector _colorA;

		// Token: 0x04000D63 RID: 3427
		private global::GFxImageEffect.MatVarVector _colorB;

		// Token: 0x04000D64 RID: 3428
		private global::GFxImageEffect.MatVarVector _colorC;

		// Token: 0x04000D65 RID: 3429
		private global::GFxImageEffect.MatVarVector _colorD;
	}

	// Token: 0x020002B7 RID: 695
	private struct VignetteMat
	{
		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x0600185B RID: 6235 RVA: 0x0005D090 File Offset: 0x0005B290
		// (set) Token: 0x0600185C RID: 6236 RVA: 0x0005D0A0 File Offset: 0x0005B2A0
		public float vignetteIntensity
		{
			get
			{
				return this._vignetteIntensity.value;
			}
			set
			{
				this._vignetteIntensity.value = value;
			}
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x0005D0B0 File Offset: 0x0005B2B0
		public void Initialize()
		{
			this._vignetteIntensity = new global::GFxImageEffect.MatVarFloat("vignetteIntensity");
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x0005D0C4 File Offset: 0x0005B2C4
		public global::UnityEngine.Material Bind()
		{
			this._vignetteIntensity.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x0005D0E0 File Offset: 0x0005B2E0
		public void Shutdown()
		{
			this.mat = null;
		}

		// Token: 0x04000D66 RID: 3430
		public global::UnityEngine.Material mat;

		// Token: 0x04000D67 RID: 3431
		private global::GFxImageEffect.MatVarFloat _vignetteIntensity;
	}

	// Token: 0x020002B8 RID: 696
	private struct ScreenBlendMat
	{
		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06001860 RID: 6240 RVA: 0x0005D0EC File Offset: 0x0005B2EC
		// (set) Token: 0x06001861 RID: 6241 RVA: 0x0005D0FC File Offset: 0x0005B2FC
		public float intensity
		{
			get
			{
				return this._intensity.value;
			}
			set
			{
				this._intensity.value = value;
			}
		}

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06001862 RID: 6242 RVA: 0x0005D10C File Offset: 0x0005B30C
		// (set) Token: 0x06001863 RID: 6243 RVA: 0x0005D11C File Offset: 0x0005B31C
		public global::UnityEngine.Texture colorBuffer
		{
			get
			{
				return this._ColorBuffer.value;
			}
			set
			{
				this._ColorBuffer.value = value;
			}
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x0005D12C File Offset: 0x0005B32C
		public void Initialize()
		{
			this._intensity = new global::GFxImageEffect.MatVarFloat("_Intensity");
			this._ColorBuffer = new global::GFxImageEffect.MatVarTexture("_ColorBuffer");
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x0005D15C File Offset: 0x0005B35C
		public global::UnityEngine.Material Bind()
		{
			this._intensity.Bind(this.mat);
			this._ColorBuffer.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x0005D194 File Offset: 0x0005B394
		public void Shutdown()
		{
			this.mat = null;
			this._ColorBuffer.Shutdown();
		}

		// Token: 0x04000D68 RID: 3432
		public global::UnityEngine.Material mat;

		// Token: 0x04000D69 RID: 3433
		private global::GFxImageEffect.MatVarFloat _intensity;

		// Token: 0x04000D6A RID: 3434
		private global::GFxImageEffect.MatVarTexture _ColorBuffer;
	}

	// Token: 0x020002B9 RID: 697
	private struct SeperableBlurMat
	{
		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06001867 RID: 6247 RVA: 0x0005D1A8 File Offset: 0x0005B3A8
		// (set) Token: 0x06001868 RID: 6248 RVA: 0x0005D1DC File Offset: 0x0005B3DC
		public global::UnityEngine.Vector2 offsets
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this._offsets.x;
				result.y = this._offsets.y;
				return result;
			}
			set
			{
				this._offsets.x = value.x;
				this._offsets.y = value.y;
			}
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x0005D210 File Offset: 0x0005B410
		public global::UnityEngine.Material Bind()
		{
			this._offsets.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x0005D22C File Offset: 0x0005B42C
		public void Initialize()
		{
			this._offsets = new global::GFxImageEffect.MatVarVector("offsets", default(global::UnityEngine.Vector4));
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x0005D254 File Offset: 0x0005B454
		public void Shutdown()
		{
			this.mat = null;
		}

		// Token: 0x04000D6B RID: 3435
		public global::UnityEngine.Material mat;

		// Token: 0x04000D6C RID: 3436
		private global::GFxImageEffect.MatVarVector _offsets;
	}

	// Token: 0x020002BA RID: 698
	private struct AddBrightStuffOneOneMat
	{
		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x0600186C RID: 6252 RVA: 0x0005D260 File Offset: 0x0005B460
		// (set) Token: 0x0600186D RID: 6253 RVA: 0x0005D270 File Offset: 0x0005B470
		public float intensity
		{
			get
			{
				return this._intensity.value;
			}
			set
			{
				this._intensity.value = value;
			}
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0005D280 File Offset: 0x0005B480
		public global::UnityEngine.Material Bind()
		{
			this._intensity.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x0005D29C File Offset: 0x0005B49C
		public void Initialize()
		{
			this._intensity = new global::GFxImageEffect.MatVarFloat("_Intensity");
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0005D2B0 File Offset: 0x0005B4B0
		public void Shutdown()
		{
			this.mat = null;
		}

		// Token: 0x04000D6D RID: 3437
		public global::UnityEngine.Material mat;

		// Token: 0x04000D6E RID: 3438
		private global::GFxImageEffect.MatVarFloat _intensity;
	}

	// Token: 0x020002BB RID: 699
	private struct HollywoodFlaresMat
	{
		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06001871 RID: 6257 RVA: 0x0005D2BC File Offset: 0x0005B4BC
		// (set) Token: 0x06001872 RID: 6258 RVA: 0x0005D2F0 File Offset: 0x0005B4F0
		public global::UnityEngine.Vector2 offsets
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this._offsets.x;
				result.y = this._offsets.y;
				return result;
			}
			set
			{
				this._offsets.x = value.x;
				this._offsets.y = value.y;
			}
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06001873 RID: 6259 RVA: 0x0005D324 File Offset: 0x0005B524
		// (set) Token: 0x06001874 RID: 6260 RVA: 0x0005D358 File Offset: 0x0005B558
		public global::UnityEngine.Vector2 threshhold
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this._Threshhold.x;
				result.y = this._Threshhold.y;
				return result;
			}
			set
			{
				this._Threshhold.x = value.x;
				this._Threshhold.y = value.y;
			}
		}

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001875 RID: 6261 RVA: 0x0005D38C File Offset: 0x0005B58C
		// (set) Token: 0x06001876 RID: 6262 RVA: 0x0005D39C File Offset: 0x0005B59C
		public global::UnityEngine.Vector4 tintColor
		{
			get
			{
				return this._tintColor.value;
			}
			set
			{
				this._tintColor.value = value;
			}
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06001877 RID: 6263 RVA: 0x0005D3AC File Offset: 0x0005B5AC
		// (set) Token: 0x06001878 RID: 6264 RVA: 0x0005D3BC File Offset: 0x0005B5BC
		public float stretchWidth
		{
			get
			{
				return this._stretchWidth.value;
			}
			set
			{
				this._stretchWidth.value = value;
			}
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x0005D3CC File Offset: 0x0005B5CC
		public global::UnityEngine.Material Bind()
		{
			this._offsets.Bind(this.mat);
			this._Threshhold.Bind(this.mat);
			this._tintColor.Bind(this.mat);
			this._stretchWidth.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x0600187A RID: 6266 RVA: 0x0005D424 File Offset: 0x0005B624
		public void Initialize()
		{
			this._offsets = new global::GFxImageEffect.MatVarVector("offsets", default(global::UnityEngine.Vector4));
			this._Threshhold = new global::GFxImageEffect.MatVarVector("_Threshhold", default(global::UnityEngine.Vector4));
			this._tintColor = new global::GFxImageEffect.MatVarVector("_tintColor", default(global::UnityEngine.Vector4));
			this._stretchWidth = new global::GFxImageEffect.MatVarFloat("stretchWidth", 0f);
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x0005D494 File Offset: 0x0005B694
		public void Shutdown()
		{
			this.mat = null;
		}

		// Token: 0x04000D6F RID: 3439
		public global::UnityEngine.Material mat;

		// Token: 0x04000D70 RID: 3440
		private global::GFxImageEffect.MatVarVector _offsets;

		// Token: 0x04000D71 RID: 3441
		private global::GFxImageEffect.MatVarVector _Threshhold;

		// Token: 0x04000D72 RID: 3442
		private global::GFxImageEffect.MatVarVector _tintColor;

		// Token: 0x04000D73 RID: 3443
		private global::GFxImageEffect.MatVarFloat _stretchWidth;
	}

	// Token: 0x020002BC RID: 700
	private struct BrightPassFilterMat
	{
		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x0600187C RID: 6268 RVA: 0x0005D4A0 File Offset: 0x0005B6A0
		// (set) Token: 0x0600187D RID: 6269 RVA: 0x0005D4D4 File Offset: 0x0005B6D4
		public global::UnityEngine.Vector2 threshhold
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this._threshhold.x;
				result.y = this._threshhold.y;
				return result;
			}
			set
			{
				global::UnityEngine.Vector4 value2;
				value2.x = value.x;
				value2.y = value.y;
				value2.z = (value2.w = 0f);
				this._threshhold.value = value2;
			}
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x0600187E RID: 6270 RVA: 0x0005D520 File Offset: 0x0005B720
		// (set) Token: 0x0600187F RID: 6271 RVA: 0x0005D530 File Offset: 0x0005B730
		public float useAlphaAsMask
		{
			get
			{
				return this._useSrcAlphaAsMask.value;
			}
			set
			{
				this._useSrcAlphaAsMask.value = value;
			}
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x0005D540 File Offset: 0x0005B740
		public void Initialize()
		{
			this._threshhold = new global::GFxImageEffect.MatVarVector("threshhold");
			this._useSrcAlphaAsMask = new global::GFxImageEffect.MatVarFloat("useSrcAlphaAsMask");
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x0005D570 File Offset: 0x0005B770
		public global::UnityEngine.Material Bind()
		{
			this._threshhold.Bind(this.mat);
			this._useSrcAlphaAsMask.Bind(this.mat);
			return this.mat;
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x0005D5A8 File Offset: 0x0005B7A8
		public void Shutdown()
		{
			this.mat = null;
		}

		// Token: 0x04000D74 RID: 3444
		public global::UnityEngine.Material mat;

		// Token: 0x04000D75 RID: 3445
		private global::GFxImageEffect.MatVarVector _threshhold;

		// Token: 0x04000D76 RID: 3446
		private global::GFxImageEffect.MatVarFloat _useSrcAlphaAsMask;
	}
}
