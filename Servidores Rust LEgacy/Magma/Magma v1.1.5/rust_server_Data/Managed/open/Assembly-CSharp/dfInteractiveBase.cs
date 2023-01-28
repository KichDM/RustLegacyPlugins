using System;
using UnityEngine;

// Token: 0x0200081A RID: 2074
[global::System.Serializable]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfInteractiveBase : global::dfControl
{
	// Token: 0x060045B2 RID: 17842 RVA: 0x000FFC58 File Offset: 0x000FDE58
	public dfInteractiveBase()
	{
	}

	// Token: 0x17000CEE RID: 3310
	// (get) Token: 0x060045B3 RID: 17843 RVA: 0x000FFC60 File Offset: 0x000FDE60
	// (set) Token: 0x060045B4 RID: 17844 RVA: 0x000FFCA8 File Offset: 0x000FDEA8
	public global::dfAtlas Atlas
	{
		get
		{
			if (this.atlas == null)
			{
				global::dfGUIManager manager = base.GetManager();
				if (manager != null)
				{
					return this.atlas = manager.DefaultAtlas;
				}
			}
			return this.atlas;
		}
		set
		{
			if (!global::dfAtlas.Equals(value, this.atlas))
			{
				this.atlas = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CEF RID: 3311
	// (get) Token: 0x060045B5 RID: 17845 RVA: 0x000FFCC8 File Offset: 0x000FDEC8
	// (set) Token: 0x060045B6 RID: 17846 RVA: 0x000FFCD0 File Offset: 0x000FDED0
	public string BackgroundSprite
	{
		get
		{
			return this.backgroundSprite;
		}
		set
		{
			if (value != this.backgroundSprite)
			{
				this.backgroundSprite = value;
				this.setDefaultSize(value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CF0 RID: 3312
	// (get) Token: 0x060045B7 RID: 17847 RVA: 0x000FFCF8 File Offset: 0x000FDEF8
	// (set) Token: 0x060045B8 RID: 17848 RVA: 0x000FFD00 File Offset: 0x000FDF00
	public string DisabledSprite
	{
		get
		{
			return this.disabledSprite;
		}
		set
		{
			if (value != this.disabledSprite)
			{
				this.disabledSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CF1 RID: 3313
	// (get) Token: 0x060045B9 RID: 17849 RVA: 0x000FFD20 File Offset: 0x000FDF20
	// (set) Token: 0x060045BA RID: 17850 RVA: 0x000FFD28 File Offset: 0x000FDF28
	public string FocusSprite
	{
		get
		{
			return this.focusSprite;
		}
		set
		{
			if (value != this.focusSprite)
			{
				this.focusSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CF2 RID: 3314
	// (get) Token: 0x060045BB RID: 17851 RVA: 0x000FFD48 File Offset: 0x000FDF48
	// (set) Token: 0x060045BC RID: 17852 RVA: 0x000FFD50 File Offset: 0x000FDF50
	public string HoverSprite
	{
		get
		{
			return this.hoverSprite;
		}
		set
		{
			if (value != this.hoverSprite)
			{
				this.hoverSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CF3 RID: 3315
	// (get) Token: 0x060045BD RID: 17853 RVA: 0x000FFD70 File Offset: 0x000FDF70
	public override bool CanFocus
	{
		get
		{
			return (base.IsEnabled && base.IsVisible) || base.CanFocus;
		}
	}

	// Token: 0x060045BE RID: 17854 RVA: 0x000FFD90 File Offset: 0x000FDF90
	protected internal override void OnGotFocus(global::dfFocusEventArgs args)
	{
		base.OnGotFocus(args);
		this.Invalidate();
	}

	// Token: 0x060045BF RID: 17855 RVA: 0x000FFDA0 File Offset: 0x000FDFA0
	protected internal override void OnLostFocus(global::dfFocusEventArgs args)
	{
		base.OnLostFocus(args);
		this.Invalidate();
	}

	// Token: 0x060045C0 RID: 17856 RVA: 0x000FFDB0 File Offset: 0x000FDFB0
	protected internal override void OnMouseEnter(global::dfMouseEventArgs args)
	{
		base.OnMouseEnter(args);
		this.Invalidate();
	}

	// Token: 0x060045C1 RID: 17857 RVA: 0x000FFDC0 File Offset: 0x000FDFC0
	protected internal override void OnMouseLeave(global::dfMouseEventArgs args)
	{
		base.OnMouseLeave(args);
		this.Invalidate();
	}

	// Token: 0x060045C2 RID: 17858 RVA: 0x000FFDD0 File Offset: 0x000FDFD0
	public override global::UnityEngine.Vector2 CalculateMinimumSize()
	{
		global::dfAtlas.ItemInfo itemInfo = this.getBackgroundSprite();
		if (itemInfo == null)
		{
			return base.CalculateMinimumSize();
		}
		global::UnityEngine.RectOffset border = itemInfo.border;
		if (border.horizontal > 0 || border.vertical > 0)
		{
			return global::UnityEngine.Vector2.Max(base.CalculateMinimumSize(), new global::UnityEngine.Vector2((float)border.horizontal, (float)border.vertical));
		}
		return base.CalculateMinimumSize();
	}

	// Token: 0x060045C3 RID: 17859 RVA: 0x000FFE3C File Offset: 0x000FE03C
	protected internal virtual void renderBackground()
	{
		if (this.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.getBackgroundSprite();
		if (itemInfo == null)
		{
			return;
		}
		global::UnityEngine.Color32 color = base.ApplyOpacity(this.getActiveColor());
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = 1f,
			offset = this.pivot.TransformToUpperLeft(base.Size),
			pixelsToUnits = base.PixelsToUnits(),
			size = base.Size,
			spriteInfo = itemInfo
		};
		if (itemInfo.border.horizontal == 0 && itemInfo.border.vertical == 0)
		{
			global::dfSprite.renderSprite(this.renderData, options);
		}
		else
		{
			global::dfSlicedSprite.renderSprite(this.renderData, options);
		}
	}

	// Token: 0x060045C4 RID: 17860 RVA: 0x000FFF20 File Offset: 0x000FE120
	protected virtual global::UnityEngine.Color32 getActiveColor()
	{
		if (base.IsEnabled)
		{
			return this.color;
		}
		if (!string.IsNullOrEmpty(this.disabledSprite) && this.Atlas != null && this.Atlas[this.DisabledSprite] != null)
		{
			return this.color;
		}
		return this.disabledColor;
	}

	// Token: 0x060045C5 RID: 17861 RVA: 0x000FFF8C File Offset: 0x000FE18C
	protected internal virtual global::dfAtlas.ItemInfo getBackgroundSprite()
	{
		if (this.Atlas == null)
		{
			return null;
		}
		if (!base.IsEnabled)
		{
			global::dfAtlas.ItemInfo itemInfo = this.atlas[this.DisabledSprite];
			if (itemInfo != null)
			{
				return itemInfo;
			}
			return this.atlas[this.BackgroundSprite];
		}
		else
		{
			if (!this.HasFocus)
			{
				if (this.isMouseHovering)
				{
					global::dfAtlas.ItemInfo itemInfo2 = this.atlas[this.HoverSprite];
					if (itemInfo2 != null)
					{
						return itemInfo2;
					}
				}
				return this.Atlas[this.BackgroundSprite];
			}
			global::dfAtlas.ItemInfo itemInfo3 = this.atlas[this.FocusSprite];
			if (itemInfo3 != null)
			{
				return itemInfo3;
			}
			return this.atlas[this.BackgroundSprite];
		}
	}

	// Token: 0x060045C6 RID: 17862 RVA: 0x00100064 File Offset: 0x000FE264
	private void setDefaultSize(string spriteName)
	{
		if (this.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[spriteName];
		if (this.size == global::UnityEngine.Vector2.zero && itemInfo != null)
		{
			base.Size = itemInfo.sizeInPixels;
		}
	}

	// Token: 0x04002521 RID: 9505
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002522 RID: 9506
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x04002523 RID: 9507
	[global::UnityEngine.SerializeField]
	protected string hoverSprite;

	// Token: 0x04002524 RID: 9508
	[global::UnityEngine.SerializeField]
	protected string disabledSprite;

	// Token: 0x04002525 RID: 9509
	[global::UnityEngine.SerializeField]
	protected string focusSprite;
}
