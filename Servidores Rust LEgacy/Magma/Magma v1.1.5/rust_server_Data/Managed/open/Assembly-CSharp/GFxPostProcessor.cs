using System;
using UnityEngine;

// Token: 0x020002C7 RID: 711
[global::UnityEngine.RequireComponent(typeof(global::GFxCameraDepthTextureControl))]
public abstract class GFxPostProcessor : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060018BA RID: 6330 RVA: 0x0005FF1C File Offset: 0x0005E11C
	internal GFxPostProcessor(global::GFxPostProcessor.Kind kind)
	{
		this.kind = kind;
	}

	// Token: 0x060018BB RID: 6331 RVA: 0x0005FF2C File Offset: 0x0005E12C
	// Note: this type is marked as 'beforefieldinit'.
	static GFxPostProcessor()
	{
	}

	// Token: 0x170006B7 RID: 1719
	// (get) Token: 0x060018BC RID: 6332 RVA: 0x0005FF34 File Offset: 0x0005E134
	public bool hdr
	{
		get
		{
			bool result;
			try
			{
				result = this.camera.hdr;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x0005FF84 File Offset: 0x0005E184
	private void OnEnable()
	{
		if (this._imageEffectsSetup != null)
		{
			global::System.Array.Resize<global::GFxImageEffect>(ref this._imageEffects, this._imageEffectsSetup.Length);
			global::System.Array.Resize<global::GFxImageEffect>(ref this._imageEffectsActive, this._imageEffectsSetup.Length);
			for (int i = 0; i < this._imageEffectsSetup.Length; i++)
			{
				this._imageEffects[i] = this._imageEffectsSetup[i].Summon(this);
			}
			int num = 0;
			for (int j = 0; j < this._imageEffectsSetup.Length; j++)
			{
				if (!global::GFxPostProcessor.r_imageeffects || !this._imageEffects[j].supported)
				{
					using (this.depthTextureControl.LockChanges())
					{
						this.ShutdownNotSupported(ref this._imageEffects[j]);
						while (++j < this._imageEffectsSetup.Length)
						{
							if (this._imageEffects[j].supported)
							{
								this._imageEffectsActive[num++] = this._imageEffects[j];
							}
							else
							{
								this.ShutdownNotSupported(ref this._imageEffects[j]);
							}
						}
					}
					global::System.Array.Resize<global::GFxImageEffect>(ref this._imageEffectsActive, num);
					global::System.Array.Resize<global::GFxImageEffect>(ref this._imageEffects, num);
					if (num != 0)
					{
						for (int k = 0; k < num; k++)
						{
							this._imageEffects[k] = this._imageEffectsActive[k];
						}
					}
					break;
				}
				this._imageEffectsActive[num++] = this._imageEffects[j];
			}
		}
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x00060130 File Offset: 0x0005E330
	private void ShutdownNotSupported(ref global::GFxImageEffect effect)
	{
		effect.Shutdown(ref effect);
		effect = null;
	}

	// Token: 0x060018BF RID: 6335 RVA: 0x00060140 File Offset: 0x0005E340
	private void OnDisable()
	{
		if (this._imageEffects != null)
		{
			using (this.depthTextureControl.LockChanges())
			{
				this.imageEffectActiveCount = 0;
				for (int i = 0; i < this._imageEffects.Length; i++)
				{
					if (this._imageEffects[i])
					{
						this._imageEffects[i].Shutdown(ref this._imageEffects[i]);
					}
					this._imageEffects[i] = null;
					this._imageEffectsActive[i] = null;
				}
			}
		}
	}

	// Token: 0x060018C0 RID: 6336 RVA: 0x000601F0 File Offset: 0x0005E3F0
	protected void Reset()
	{
		this.camera = base.camera;
		this.depthTextureControl = base.GetComponent<global::GFxCameraDepthTextureControl>();
	}

	// Token: 0x060018C1 RID: 6337 RVA: 0x0006020C File Offset: 0x0005E40C
	protected void DoRenderImage(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		int num;
		if (!global::GFxPostProcessor.r_imageeffects || this._imageEffects == null || (num = this._imageEffects.Length) == 0)
		{
			global::UnityEngine.Graphics.Blit(src, dst);
			base.enabled = false;
		}
		else
		{
			this.imageEffectActiveCount = 0;
			for (int i = 0; i < num; i++)
			{
				if (this._imageEffects[i].allow)
				{
					this._imageEffectsActive[this.imageEffectActiveCount++] = this._imageEffects[i];
				}
			}
			switch (this.imageEffectActiveCount)
			{
			case 0:
				global::UnityEngine.Graphics.Blit(src, dst);
				break;
			case 1:
				if (!this._imageEffectsActive[0].Apply(src, dst))
				{
					global::UnityEngine.Graphics.Blit(src, dst);
				}
				break;
			case 2:
				using (global::GFxImageEffect.Scratch scratch = new global::GFxImageEffect.Scratch(src.width, src.height, src.depth, src.format))
				{
					if (this._imageEffectsActive[0].Apply(src, scratch.target))
					{
						if (!this._imageEffectsActive[1].Apply(scratch.target, dst))
						{
							global::UnityEngine.Graphics.Blit(scratch.target, dst);
						}
						break;
					}
				}
				if (!this._imageEffectsActive[1].Apply(src, dst))
				{
					global::UnityEngine.Graphics.Blit(src, dst);
				}
				break;
			default:
				using (global::GFxImageEffect.Scratch scratch2 = new global::GFxImageEffect.Scratch(src.width, src.height, src.depth, src.format))
				{
					using (global::GFxImageEffect.Scratch scratch3 = new global::GFxImageEffect.Scratch(src.width, src.height, src.depth, src.format))
					{
						global::UnityEngine.RenderTexture renderTexture = src;
						global::UnityEngine.RenderTexture target = scratch2.target;
						bool flag = false;
						for (int j = 0; j < this.imageEffectActiveCount; j++)
						{
							if (this._imageEffectsActive[j].Apply(renderTexture, target))
							{
								flag = !flag;
								if (flag)
								{
									renderTexture = scratch2.target;
									target = scratch3.target;
								}
								else
								{
									renderTexture = scratch3.target;
									target = scratch2.target;
								}
							}
						}
						global::UnityEngine.Graphics.Blit(renderTexture, dst);
					}
				}
				break;
			}
		}
	}

	// Token: 0x04000E06 RID: 3590
	[global::PrefetchComponent]
	public global::UnityEngine.Camera camera;

	// Token: 0x04000E07 RID: 3591
	[global::PrefetchComponent]
	public global::GFxCameraDepthTextureControl depthTextureControl;

	// Token: 0x04000E08 RID: 3592
	[global::UnityEngine.SerializeField]
	private global::GFxImageEffect[] _imageEffectsSetup;

	// Token: 0x04000E09 RID: 3593
	private global::GFxImageEffect[] _imageEffects;

	// Token: 0x04000E0A RID: 3594
	private global::GFxImageEffect[] _imageEffectsActive;

	// Token: 0x04000E0B RID: 3595
	private int imageEffectActiveCount;

	// Token: 0x04000E0C RID: 3596
	private static bool r_imageeffects = true;

	// Token: 0x04000E0D RID: 3597
	[global::System.NonSerialized]
	public readonly global::GFxPostProcessor.Kind kind;

	// Token: 0x020002C8 RID: 712
	public enum Kind : byte
	{
		// Token: 0x04000E0F RID: 3599
		Undefined,
		// Token: 0x04000E10 RID: 3600
		UndefinedLDR,
		// Token: 0x04000E11 RID: 3601
		Transparent,
		// Token: 0x04000E12 RID: 3602
		TransparentLDR,
		// Token: 0x04000E13 RID: 3603
		Opaque,
		// Token: 0x04000E14 RID: 3604
		OpaqueLDR
	}
}
