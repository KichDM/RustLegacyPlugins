using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
public sealed class GFxImageEffect_GameFullscreen : global::GFxImageEffect
{
	// Token: 0x06001883 RID: 6275 RVA: 0x0005D5B4 File Offset: 0x0005B7B4
	public GFxImageEffect_GameFullscreen()
	{
	}

	// Token: 0x06001884 RID: 6276 RVA: 0x0005D5BC File Offset: 0x0005B7BC
	// Note: this type is marked as 'beforefieldinit'.
	static GFxImageEffect_GameFullscreen()
	{
	}

	// Token: 0x170006AD RID: 1709
	// (get) Token: 0x06001885 RID: 6277 RVA: 0x0005D678 File Offset: 0x0005B878
	// (set) Token: 0x06001886 RID: 6278 RVA: 0x0005D680 File Offset: 0x0005B880
	public static global::UnityEngine.Color autoFadeColor
	{
		get
		{
			return global::GFxImageEffect_GameFullscreen.fadeColor;
		}
		set
		{
			global::GFxImageEffect_GameFullscreen.fadeColor.r = value.r;
			global::GFxImageEffect_GameFullscreen.fadeColor.g = value.g;
			global::GFxImageEffect_GameFullscreen.fadeColor.b = value.b;
			if (value.r == value.g && value.r == value.b)
			{
				global::GFxImageEffect_GameFullscreen.tintColor.r = (global::GFxImageEffect_GameFullscreen.tintColor.g = (global::GFxImageEffect_GameFullscreen.tintColor.b = 1f));
			}
			else
			{
				float num = global::UnityEngine.Mathf.Atan2(1.7320508f * (value.g - value.b), 2f * value.r - value.g - value.b) * 57.29578f;
				if (float.IsNaN(num) || float.IsInfinity(num))
				{
					global::GFxImageEffect_GameFullscreen.tintColor.r = (global::GFxImageEffect_GameFullscreen.tintColor.g = (global::GFxImageEffect_GameFullscreen.tintColor.b = 1f));
				}
				else
				{
					float num2 = ((num >= 0f) ? num : (num + 360f)) / 60f;
					float num3 = 1f * (1f - global::UnityEngine.Mathf.Abs(num2 % 2f - 1f));
					switch (global::UnityEngine.Mathf.FloorToInt(num2) % 6)
					{
					default:
						global::GFxImageEffect_GameFullscreen.tintColor.r = 1f;
						global::GFxImageEffect_GameFullscreen.tintColor.g = num3;
						global::GFxImageEffect_GameFullscreen.tintColor.b = 0f;
						break;
					case 1:
						global::GFxImageEffect_GameFullscreen.tintColor.r = num3;
						global::GFxImageEffect_GameFullscreen.tintColor.g = 1f;
						global::GFxImageEffect_GameFullscreen.tintColor.b = 0f;
						break;
					case 2:
						global::GFxImageEffect_GameFullscreen.tintColor.r = 0f;
						global::GFxImageEffect_GameFullscreen.tintColor.g = 1f;
						global::GFxImageEffect_GameFullscreen.tintColor.b = num3;
						break;
					case 3:
						global::GFxImageEffect_GameFullscreen.tintColor.r = 0f;
						global::GFxImageEffect_GameFullscreen.tintColor.g = num3;
						global::GFxImageEffect_GameFullscreen.tintColor.b = 1f;
						break;
					case 4:
						global::GFxImageEffect_GameFullscreen.tintColor.r = num3;
						global::GFxImageEffect_GameFullscreen.tintColor.g = 0f;
						global::GFxImageEffect_GameFullscreen.tintColor.b = 1f;
						break;
					case 5:
						global::GFxImageEffect_GameFullscreen.tintColor.r = 1f;
						global::GFxImageEffect_GameFullscreen.tintColor.g = 0f;
						global::GFxImageEffect_GameFullscreen.tintColor.b = num3;
						break;
					}
				}
			}
			global::GFxImageEffect_GameFullscreen.tintColor.a = global::UnityEngine.Mathf.Clamp01(global::UnityEngine.Mathf.SmoothStep(0f, 1f, global::UnityEngine.Mathf.InverseLerp(0f, 0.5f, value.a)));
			global::GFxImageEffect_GameFullscreen.fadeColor.a = global::UnityEngine.Mathf.Clamp01(global::UnityEngine.Mathf.SmoothStep(0f, 1f, global::UnityEngine.Mathf.InverseLerp(0f, 1f, value.a)));
		}
	}

	// Token: 0x170006AE RID: 1710
	// (get) Token: 0x06001887 RID: 6279 RVA: 0x0005D988 File Offset: 0x0005BB88
	public override bool allow
	{
		get
		{
			if (global::GFxImageEffect_GameFullscreen.r_gamefx)
			{
				if (global::GFxImageEffect_GameFullscreen.fadeColor.a > 0f || global::GFxImageEffect_GameFullscreen.tintColor.a > 0f)
				{
					return true;
				}
				for (int i = 0; i < 4; i++)
				{
					if (global::GFxImageEffect_GameFullscreen.overlays[i].willRender)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x06001888 RID: 6280 RVA: 0x0005D9F4 File Offset: 0x0005BBF4
	protected override void Configure()
	{
		this.supported = (base.Support((global::GFxImageEffect.Caps.Bits)5) && this.CheckResources());
	}

	// Token: 0x06001889 RID: 6281 RVA: 0x0005DA14 File Offset: 0x0005BC14
	protected override void DeConfigure()
	{
	}

	// Token: 0x0600188A RID: 6282 RVA: 0x0005DA18 File Offset: 0x0005BC18
	private bool CheckResources()
	{
		bool flag = false;
		return global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.shader, ref this.material), ref flag);
	}

	// Token: 0x0600188B RID: 6283 RVA: 0x0005DA48 File Offset: 0x0005BC48
	protected override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		this.renderCount = 0;
		if (global::GFxImageEffect_GameFullscreen.tintColor.a > 0f || global::GFxImageEffect_GameFullscreen.fadeColor.a > 0f)
		{
			this.material.SetColor("_FadeColor", global::GFxImageEffect_GameFullscreen.tintColor);
			this.material.SetColor("_SolidColor", global::GFxImageEffect_GameFullscreen.fadeColor);
			for (int i = 0; i < 4; i++)
			{
				if (global::GFxImageEffect_GameFullscreen.overlays[i].willRender)
				{
					this.material.SetFloat("_Blend", global::GFxImageEffect_GameFullscreen.overlays[i].alpha);
					this.material.SetTexture("_OverlayTex", global::GFxImageEffect_GameFullscreen.overlays[i].texture);
					global::GFxImageEffect.Scratch scratch = new global::GFxImageEffect.Scratch(src.width, src.height, 0);
					try
					{
						global::UnityEngine.Graphics.Blit(src, scratch.target, this.material, global::GFxImageEffect_GameFullscreen.overlays[i].pass);
						this.renderCount++;
						while (++i < 4)
						{
							if (global::GFxImageEffect_GameFullscreen.overlays[i].willRender)
							{
								this.material.SetFloat("_Blend", global::GFxImageEffect_GameFullscreen.overlays[i].alpha);
								this.material.SetTexture("_OverlayTex", global::GFxImageEffect_GameFullscreen.overlays[i].texture);
								global::GFxImageEffect.Scratch scratch2 = new global::GFxImageEffect.Scratch(src.width, src.height, 0);
								try
								{
									global::UnityEngine.Graphics.Blit(scratch.target, scratch2.target, this.material, global::GFxImageEffect_GameFullscreen.overlays[i].pass);
									this.renderCount++;
									global::GFxImageEffect.Scratch.Swap(ref scratch, ref scratch2);
								}
								finally
								{
									scratch2.Dispose();
								}
							}
						}
						global::UnityEngine.Graphics.Blit(scratch.target, dst, this.material, 0);
						this.renderCount++;
						return true;
					}
					finally
					{
						scratch.Dispose();
					}
				}
			}
			global::UnityEngine.Graphics.Blit(src, dst, this.material, 0);
			this.renderCount++;
			return true;
		}
		for (int j = 0; j < 4; j++)
		{
			if (global::GFxImageEffect_GameFullscreen.overlays[j].willRender)
			{
				this.material.SetFloat("_Blend", global::GFxImageEffect_GameFullscreen.overlays[j].alpha);
				this.material.SetTexture("_OverlayTex", global::GFxImageEffect_GameFullscreen.overlays[j].texture);
				int pass = global::GFxImageEffect_GameFullscreen.overlays[j].pass;
				while (++j < 4)
				{
					if (global::GFxImageEffect_GameFullscreen.overlays[j].willRender)
					{
						global::GFxImageEffect.Scratch scratch3 = new global::GFxImageEffect.Scratch(src.width, src.height, 0);
						try
						{
							global::UnityEngine.Graphics.Blit(src, scratch3.target, this.material, pass);
							this.renderCount++;
							this.material.SetFloat("_Blend", global::GFxImageEffect_GameFullscreen.overlays[j].alpha);
							this.material.SetTexture("_OverlayTex", global::GFxImageEffect_GameFullscreen.overlays[j].texture);
							pass = global::GFxImageEffect_GameFullscreen.overlays[j].pass;
							while (++j < 4)
							{
								if (global::GFxImageEffect_GameFullscreen.overlays[j].willRender)
								{
									global::GFxImageEffect.Scratch scratch4 = new global::GFxImageEffect.Scratch(src.width, src.height, 0);
									try
									{
										global::UnityEngine.Graphics.Blit(scratch3.target, scratch4.target, this.material, pass);
										this.renderCount++;
										global::GFxImageEffect.Scratch.Swap(ref scratch3, ref scratch4);
									}
									finally
									{
										scratch4.Dispose();
									}
									this.material.SetFloat("_Blend", global::GFxImageEffect_GameFullscreen.overlays[j].alpha);
									this.material.SetTexture("_OverlayTex", global::GFxImageEffect_GameFullscreen.overlays[j].texture);
									pass = global::GFxImageEffect_GameFullscreen.overlays[j].pass;
								}
							}
							global::UnityEngine.Graphics.Blit(scratch3.target, dst, this.material, pass);
							this.renderCount++;
							return true;
						}
						finally
						{
							scratch3.Dispose();
						}
					}
				}
				global::UnityEngine.Graphics.Blit(src, dst, this.material, pass);
				this.renderCount++;
				return true;
			}
		}
		return false;
	}

	// Token: 0x04000D77 RID: 3447
	private const global::UnityEngine.ScaleMode kDefaultScaleMode = 0;

	// Token: 0x04000D78 RID: 3448
	private const int kDefaultOverlayPass = 1;

	// Token: 0x04000D79 RID: 3449
	public const int kMaxOverlays = 4;

	// Token: 0x04000D7A RID: 3450
	private const float sqrtOf3 = 1.7320508f;

	// Token: 0x04000D7B RID: 3451
	public static global::UnityEngine.Color tintColor = global::UnityEngine.Color.white;

	// Token: 0x04000D7C RID: 3452
	public static global::UnityEngine.Color fadeColor = new global::UnityEngine.Color(0f, 0f, 0f, 1f);

	// Token: 0x04000D7D RID: 3453
	public static readonly global::GFxImageEffect_GameFullscreen.Overlay[] overlays = new global::GFxImageEffect_GameFullscreen.Overlay[]
	{
		new global::GFxImageEffect_GameFullscreen.Overlay
		{
			pass = 1
		},
		new global::GFxImageEffect_GameFullscreen.Overlay
		{
			pass = 1
		},
		new global::GFxImageEffect_GameFullscreen.Overlay
		{
			pass = 1
		},
		new global::GFxImageEffect_GameFullscreen.Overlay
		{
			pass = 1
		}
	};

	// Token: 0x04000D7E RID: 3454
	public global::UnityEngine.Shader shader;

	// Token: 0x04000D7F RID: 3455
	private global::UnityEngine.Material material;

	// Token: 0x04000D80 RID: 3456
	private static bool r_gamefx = true;

	// Token: 0x04000D81 RID: 3457
	private int renderCount;

	// Token: 0x020002BE RID: 702
	public struct Overlay
	{
		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x0600188C RID: 6284 RVA: 0x0005DF3C File Offset: 0x0005C13C
		public bool willRender
		{
			get
			{
				if (this.shouldDraw && !this._texture)
				{
					this.hasTex = false;
					this._texture = null;
					this.shouldDraw = false;
				}
				return this.shouldDraw;
			}
		}

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x0600188D RID: 6285 RVA: 0x0005DF80 File Offset: 0x0005C180
		// (set) Token: 0x0600188E RID: 6286 RVA: 0x0005DF88 File Offset: 0x0005C188
		public float alpha
		{
			get
			{
				return this._alpha;
			}
			set
			{
				this._alpha = value;
				bool flag = this.hasAlpha;
				this.hasAlpha = (value > 0f);
				if (flag != this.hasAlpha)
				{
					this.shouldDraw = (this.hasAlpha && this.hasTex);
				}
			}
		}

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x0600188F RID: 6287 RVA: 0x0005DFD8 File Offset: 0x0005C1D8
		// (set) Token: 0x06001890 RID: 6288 RVA: 0x0005DFE0 File Offset: 0x0005C1E0
		public global::UnityEngine.Texture2D texture
		{
			get
			{
				return this._texture;
			}
			set
			{
				this._texture = value;
				bool flag = this.hasTex;
				this.hasTex = this._texture;
				if (flag != this.hasTex)
				{
					this.shouldDraw = (this.hasTex && this.hasAlpha);
				}
			}
		}

		// Token: 0x04000D82 RID: 3458
		private global::UnityEngine.Texture2D _texture;

		// Token: 0x04000D83 RID: 3459
		private float _alpha;

		// Token: 0x04000D84 RID: 3460
		private bool hasTex;

		// Token: 0x04000D85 RID: 3461
		private bool hasAlpha;

		// Token: 0x04000D86 RID: 3462
		private bool shouldDraw;

		// Token: 0x04000D87 RID: 3463
		public int pass;

		// Token: 0x04000D88 RID: 3464
		public global::UnityEngine.ScaleMode scaleMode;
	}
}
