using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
public sealed class GFxImageEffect_AA : global::GFxImageEffect
{
	// Token: 0x0600183C RID: 6204 RVA: 0x0005BAF0 File Offset: 0x00059CF0
	public GFxImageEffect_AA()
	{
	}

	// Token: 0x0600183D RID: 6205 RVA: 0x0005BB44 File Offset: 0x00059D44
	// Note: this type is marked as 'beforefieldinit'.
	static GFxImageEffect_AA()
	{
	}

	// Token: 0x1700069B RID: 1691
	// (get) Token: 0x0600183E RID: 6206 RVA: 0x0005BB4C File Offset: 0x00059D4C
	public override bool allow
	{
		get
		{
			return global::GFxImageEffect_AA.r_ssaa;
		}
	}

	// Token: 0x1700069C RID: 1692
	// (get) Token: 0x0600183F RID: 6207 RVA: 0x0005BB54 File Offset: 0x00059D54
	private global::UnityEngine.Material aaMaterial
	{
		get
		{
			switch (this.mode)
			{
			case global::GFxImageEffect_AA.AAMode.FXAA2:
				return this.materialFXAAII;
			case global::GFxImageEffect_AA.AAMode.FXAA3Console:
				return this.materialFXAAIII;
			case global::GFxImageEffect_AA.AAMode.FXAA1PresetA:
				return this.materialFXAAPreset2;
			case global::GFxImageEffect_AA.AAMode.FXAA1PresetB:
				return this.materialFXAAPreset3;
			case global::GFxImageEffect_AA.AAMode.NFAA:
				return this.nfaa;
			case global::GFxImageEffect_AA.AAMode.SSAA:
				return this.ssaa;
			case global::GFxImageEffect_AA.AAMode.DLAA:
				return this.dlaa;
			default:
				throw new global::System.NotImplementedException();
			}
		}
	}

	// Token: 0x06001840 RID: 6208 RVA: 0x0005BBC8 File Offset: 0x00059DC8
	protected sealed override void Configure()
	{
		this.supported = (base.Support((global::GFxImageEffect.Caps.Bits)5) && this.CheckResources());
	}

	// Token: 0x06001841 RID: 6209 RVA: 0x0005BBE8 File Offset: 0x00059DE8
	protected sealed override void DeConfigure()
	{
		this.dlaa = null;
		this.ssaa = null;
		this.nfaa = null;
		this.materialFXAAII = null;
		this.materialFXAAIII = null;
		this.materialFXAAPreset2 = null;
		this.materialFXAAPreset3 = null;
	}

	// Token: 0x06001842 RID: 6210 RVA: 0x0005BC1C File Offset: 0x00059E1C
	private bool CheckResources()
	{
		bool flag = false;
		if (global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.ssaaShader, ref this.ssaa), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.shaderFXAAPreset2, ref this.materialFXAAPreset2), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.shaderFXAAPreset3, ref this.materialFXAAPreset3), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.shaderFXAAII, ref this.materialFXAAII), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.shaderFXAAIII, ref this.materialFXAAIII), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.nfaaShader, ref this.nfaa), ref flag) && global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.dlaaShader, ref this.dlaa), ref flag))
		{
			if (flag)
			{
				this.fxaa3_EdgeThresholdMin = new global::GFxImageEffect.MatVarFloat("_EdgeThresholdMin");
				this.fxaa3_EdgeThreshold = new global::GFxImageEffect.MatVarFloat("_EdgeThreshold");
				this.fxaa3_EdgeSharpness = new global::GFxImageEffect.MatVarFloat("_EdgeSharpness");
				this.nfaa_OffsetScale = new global::GFxImageEffect.MatVarFloat("_OffsetScale");
				this.nfaa_BlurRadius = new global::GFxImageEffect.MatVarFloat("_BlurRadius");
			}
			return true;
		}
		return false;
	}

	// Token: 0x06001843 RID: 6211 RVA: 0x0005BD58 File Offset: 0x00059F58
	protected sealed override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		if (!global::GFxImageEffect_AA.r_ssaa)
		{
			return false;
		}
		int num = -1;
		global::UnityEngine.Material material;
		bool? flag;
		int? num2;
		switch (this.mode)
		{
		case global::GFxImageEffect_AA.AAMode.FXAA2:
			material = this.materialFXAAII;
			flag = null;
			num2 = null;
			break;
		case global::GFxImageEffect_AA.AAMode.FXAA3Console:
			num2 = null;
			material = this.materialFXAAIII;
			if (material)
			{
				this.fxaa3_EdgeThresholdMin[material] = this.edgeThresholdMin;
				this.fxaa3_EdgeThreshold[material] = this.edgeThreshold;
				this.fxaa3_EdgeSharpness[material] = this.edgeSharpness;
				flag = new bool?(true);
			}
			else
			{
				flag = new bool?(false);
			}
			break;
		case global::GFxImageEffect_AA.AAMode.FXAA1PresetA:
			material = this.materialFXAAPreset2;
			if (material)
			{
				flag = new bool?(true);
				num2 = new int?(4);
			}
			else
			{
				num2 = null;
				flag = new bool?(false);
			}
			break;
		case global::GFxImageEffect_AA.AAMode.FXAA1PresetB:
			num2 = null;
			material = this.materialFXAAPreset3;
			flag = null;
			break;
		case global::GFxImageEffect_AA.AAMode.NFAA:
			material = this.nfaa;
			if (material)
			{
				flag = new bool?(true);
				num2 = new int?(0);
				this.nfaa_OffsetScale[material] = this.offsetScale;
				this.nfaa_BlurRadius[material] = this.blurRadius;
				num = ((!this.showGeneratedNormals) ? 0 : 1);
			}
			else
			{
				flag = new bool?(false);
				num2 = null;
			}
			break;
		case global::GFxImageEffect_AA.AAMode.SSAA:
			material = this.ssaa;
			flag = null;
			num2 = null;
			break;
		case global::GFxImageEffect_AA.AAMode.DLAA:
			material = this.dlaa;
			num2 = null;
			if (!material)
			{
				flag = new bool?(false);
			}
			else
			{
				flag = new bool?(true);
				int anisoLevel = src.anisoLevel;
				if (anisoLevel != 0)
				{
					try
					{
						using (global::GFxImageEffect.Scratch scratch = new global::GFxImageEffect.Scratch(src.width, src.height))
						{
							src.anisoLevel = 0;
							global::UnityEngine.Graphics.Blit(src, scratch.target, this.dlaa, 0);
							global::UnityEngine.Graphics.Blit(scratch.target, dst, this.dlaa, (!this.dlaaSharp) ? 1 : 2);
						}
					}
					finally
					{
						src.anisoLevel = anisoLevel;
					}
				}
				else
				{
					using (global::GFxImageEffect.Scratch scratch2 = new global::GFxImageEffect.Scratch(src.width, src.height))
					{
						global::UnityEngine.Graphics.Blit(src, scratch2.target, this.dlaa, 0);
						global::UnityEngine.Graphics.Blit(scratch2.target, dst, this.dlaa, (!this.dlaaSharp) ? 1 : 2);
					}
				}
				num = -2;
			}
			break;
		default:
			return false;
		}
		if (num >= -1)
		{
			if (!((flag == null) ? material : flag.Value))
			{
				return false;
			}
			int value;
			int anisoLevel2;
			if (num2 != null && (value = num2.Value) != (anisoLevel2 = src.anisoLevel))
			{
				try
				{
					src.anisoLevel = value;
					if (num > -1)
					{
						global::UnityEngine.Graphics.Blit(src, dst, material, num);
					}
					else
					{
						global::UnityEngine.Graphics.Blit(src, dst, material);
					}
				}
				finally
				{
					src.anisoLevel = anisoLevel2;
				}
			}
			else if (num > -1)
			{
				global::UnityEngine.Graphics.Blit(src, dst, material, num);
			}
			else
			{
				global::UnityEngine.Graphics.Blit(src, dst, material);
			}
		}
		return true;
	}

	// Token: 0x04000D09 RID: 3337
	internal static bool r_ssaa = true;

	// Token: 0x04000D0A RID: 3338
	public global::GFxImageEffect_AA.AAMode mode = global::GFxImageEffect_AA.AAMode.FXAA3Console;

	// Token: 0x04000D0B RID: 3339
	public bool showGeneratedNormals;

	// Token: 0x04000D0C RID: 3340
	public float offsetScale = 0.2f;

	// Token: 0x04000D0D RID: 3341
	public float blurRadius = 18f;

	// Token: 0x04000D0E RID: 3342
	public float edgeThresholdMin = 0.05f;

	// Token: 0x04000D0F RID: 3343
	public float edgeThreshold = 0.2f;

	// Token: 0x04000D10 RID: 3344
	public float edgeSharpness = 4f;

	// Token: 0x04000D11 RID: 3345
	public bool dlaaSharp;

	// Token: 0x04000D12 RID: 3346
	public global::UnityEngine.Shader ssaaShader;

	// Token: 0x04000D13 RID: 3347
	public global::UnityEngine.Shader dlaaShader;

	// Token: 0x04000D14 RID: 3348
	public global::UnityEngine.Shader nfaaShader;

	// Token: 0x04000D15 RID: 3349
	public global::UnityEngine.Shader shaderFXAAPreset2;

	// Token: 0x04000D16 RID: 3350
	public global::UnityEngine.Shader shaderFXAAPreset3;

	// Token: 0x04000D17 RID: 3351
	public global::UnityEngine.Shader shaderFXAAII;

	// Token: 0x04000D18 RID: 3352
	public global::UnityEngine.Shader shaderFXAAIII;

	// Token: 0x04000D19 RID: 3353
	private global::UnityEngine.Material ssaa;

	// Token: 0x04000D1A RID: 3354
	private global::UnityEngine.Material dlaa;

	// Token: 0x04000D1B RID: 3355
	private global::UnityEngine.Material nfaa;

	// Token: 0x04000D1C RID: 3356
	private global::UnityEngine.Material materialFXAAPreset2;

	// Token: 0x04000D1D RID: 3357
	private global::UnityEngine.Material materialFXAAPreset3;

	// Token: 0x04000D1E RID: 3358
	private global::UnityEngine.Material materialFXAAII;

	// Token: 0x04000D1F RID: 3359
	private global::UnityEngine.Material materialFXAAIII;

	// Token: 0x04000D20 RID: 3360
	private global::GFxImageEffect.MatVarFloat fxaa3_EdgeThresholdMin;

	// Token: 0x04000D21 RID: 3361
	private global::GFxImageEffect.MatVarFloat fxaa3_EdgeThreshold;

	// Token: 0x04000D22 RID: 3362
	private global::GFxImageEffect.MatVarFloat fxaa3_EdgeSharpness;

	// Token: 0x04000D23 RID: 3363
	private global::GFxImageEffect.MatVarFloat nfaa_OffsetScale;

	// Token: 0x04000D24 RID: 3364
	private global::GFxImageEffect.MatVarFloat nfaa_BlurRadius;

	// Token: 0x020002B0 RID: 688
	public enum AAMode
	{
		// Token: 0x04000D26 RID: 3366
		FXAA2,
		// Token: 0x04000D27 RID: 3367
		FXAA3Console,
		// Token: 0x04000D28 RID: 3368
		FXAA1PresetA,
		// Token: 0x04000D29 RID: 3369
		FXAA1PresetB,
		// Token: 0x04000D2A RID: 3370
		NFAA,
		// Token: 0x04000D2B RID: 3371
		SSAA,
		// Token: 0x04000D2C RID: 3372
		DLAA
	}
}
