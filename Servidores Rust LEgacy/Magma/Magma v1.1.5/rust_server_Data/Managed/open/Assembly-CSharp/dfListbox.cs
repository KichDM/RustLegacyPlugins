using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000821 RID: 2081
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Listbox")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfListbox : global::dfInteractiveBase, global::IDFMultiRender
{
	// Token: 0x06004660 RID: 18016 RVA: 0x00102504 File Offset: 0x00100704
	public dfListbox()
	{
	}

	// Token: 0x1400004B RID: 75
	// (add) Token: 0x06004661 RID: 18017 RVA: 0x001025C8 File Offset: 0x001007C8
	// (remove) Token: 0x06004662 RID: 18018 RVA: 0x001025E4 File Offset: 0x001007E4
	public event global::PropertyChangedEventHandler<int> SelectedIndexChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.SelectedIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Combine(this.SelectedIndexChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.SelectedIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Remove(this.SelectedIndexChanged, value);
		}
	}

	// Token: 0x1400004C RID: 76
	// (add) Token: 0x06004663 RID: 18019 RVA: 0x00102600 File Offset: 0x00100800
	// (remove) Token: 0x06004664 RID: 18020 RVA: 0x0010261C File Offset: 0x0010081C
	public event global::PropertyChangedEventHandler<int> ItemClicked
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ItemClicked = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Combine(this.ItemClicked, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ItemClicked = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Remove(this.ItemClicked, value);
		}
	}

	// Token: 0x17000D17 RID: 3351
	// (get) Token: 0x06004665 RID: 18021 RVA: 0x00102638 File Offset: 0x00100838
	// (set) Token: 0x06004666 RID: 18022 RVA: 0x0010267C File Offset: 0x0010087C
	public global::dfFontBase Font
	{
		get
		{
			if (this.font == null)
			{
				global::dfGUIManager manager = base.GetManager();
				if (manager != null)
				{
					this.font = manager.DefaultFont;
				}
			}
			return this.font;
		}
		set
		{
			if (value != this.font)
			{
				this.font = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D18 RID: 3352
	// (get) Token: 0x06004667 RID: 18023 RVA: 0x0010269C File Offset: 0x0010089C
	// (set) Token: 0x06004668 RID: 18024 RVA: 0x001026A4 File Offset: 0x001008A4
	public float ScrollPosition
	{
		get
		{
			return this.scrollPosition;
		}
		set
		{
			if (!global::UnityEngine.Mathf.Approximately(value, this.scrollPosition))
			{
				this.scrollPosition = this.constrainScrollPosition(value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D19 RID: 3353
	// (get) Token: 0x06004669 RID: 18025 RVA: 0x001026D8 File Offset: 0x001008D8
	// (set) Token: 0x0600466A RID: 18026 RVA: 0x001026E0 File Offset: 0x001008E0
	public global::UnityEngine.TextAlignment ItemAlignment
	{
		get
		{
			return this.itemAlignment;
		}
		set
		{
			if (value != this.itemAlignment)
			{
				this.itemAlignment = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D1A RID: 3354
	// (get) Token: 0x0600466B RID: 18027 RVA: 0x001026FC File Offset: 0x001008FC
	// (set) Token: 0x0600466C RID: 18028 RVA: 0x00102704 File Offset: 0x00100904
	public string ItemHighlight
	{
		get
		{
			return this.itemHighlight;
		}
		set
		{
			if (value != this.itemHighlight)
			{
				this.itemHighlight = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D1B RID: 3355
	// (get) Token: 0x0600466D RID: 18029 RVA: 0x00102724 File Offset: 0x00100924
	// (set) Token: 0x0600466E RID: 18030 RVA: 0x0010272C File Offset: 0x0010092C
	public string ItemHover
	{
		get
		{
			return this.itemHover;
		}
		set
		{
			if (value != this.itemHover)
			{
				this.itemHover = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D1C RID: 3356
	// (get) Token: 0x0600466F RID: 18031 RVA: 0x0010274C File Offset: 0x0010094C
	public string SelectedItem
	{
		get
		{
			if (this.selectedIndex == -1)
			{
				return null;
			}
			return this.items[this.selectedIndex];
		}
	}

	// Token: 0x17000D1D RID: 3357
	// (get) Token: 0x06004670 RID: 18032 RVA: 0x0010276C File Offset: 0x0010096C
	// (set) Token: 0x06004671 RID: 18033 RVA: 0x0010277C File Offset: 0x0010097C
	public string SelectedValue
	{
		get
		{
			return this.items[this.selectedIndex];
		}
		set
		{
			this.selectedIndex = -1;
			for (int i = 0; i < this.items.Length; i++)
			{
				if (this.items[i] == value)
				{
					this.selectedIndex = i;
					break;
				}
			}
		}
	}

	// Token: 0x17000D1E RID: 3358
	// (get) Token: 0x06004672 RID: 18034 RVA: 0x001027C8 File Offset: 0x001009C8
	// (set) Token: 0x06004673 RID: 18035 RVA: 0x001027D0 File Offset: 0x001009D0
	public int SelectedIndex
	{
		get
		{
			return this.selectedIndex;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(-1, value);
			value = global::UnityEngine.Mathf.Min(this.items.Length - 1, value);
			if (value != this.selectedIndex)
			{
				this.selectedIndex = value;
				this.EnsureVisible(value);
				this.OnSelectedIndexChanged();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D1F RID: 3359
	// (get) Token: 0x06004674 RID: 18036 RVA: 0x00102820 File Offset: 0x00100A20
	// (set) Token: 0x06004675 RID: 18037 RVA: 0x00102840 File Offset: 0x00100A40
	public global::UnityEngine.RectOffset ItemPadding
	{
		get
		{
			if (this.itemPadding == null)
			{
				this.itemPadding = new global::UnityEngine.RectOffset();
			}
			return this.itemPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!value.Equals(this.itemPadding))
			{
				this.itemPadding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D20 RID: 3360
	// (get) Token: 0x06004676 RID: 18038 RVA: 0x00102874 File Offset: 0x00100A74
	// (set) Token: 0x06004677 RID: 18039 RVA: 0x0010287C File Offset: 0x00100A7C
	public global::UnityEngine.Color32 ItemTextColor
	{
		get
		{
			return this.itemTextColor;
		}
		set
		{
			if (!value.Equals(this.itemTextColor))
			{
				this.itemTextColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D21 RID: 3361
	// (get) Token: 0x06004678 RID: 18040 RVA: 0x001028B4 File Offset: 0x00100AB4
	// (set) Token: 0x06004679 RID: 18041 RVA: 0x001028BC File Offset: 0x00100ABC
	public float ItemTextScale
	{
		get
		{
			return this.itemTextScale;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0.1f, value);
			if (!global::UnityEngine.Mathf.Approximately(this.itemTextScale, value))
			{
				this.itemTextScale = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D22 RID: 3362
	// (get) Token: 0x0600467A RID: 18042 RVA: 0x001028EC File Offset: 0x00100AEC
	// (set) Token: 0x0600467B RID: 18043 RVA: 0x001028F4 File Offset: 0x00100AF4
	public int ItemHeight
	{
		get
		{
			return this.itemHeight;
		}
		set
		{
			this.scrollPosition = 0f;
			value = global::UnityEngine.Mathf.Max(1, value);
			if (value != this.itemHeight)
			{
				this.itemHeight = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D23 RID: 3363
	// (get) Token: 0x0600467C RID: 18044 RVA: 0x00102924 File Offset: 0x00100B24
	// (set) Token: 0x0600467D RID: 18045 RVA: 0x00102944 File Offset: 0x00100B44
	public string[] Items
	{
		get
		{
			if (this.items == null)
			{
				this.items = new string[0];
			}
			return this.items;
		}
		set
		{
			if (value != this.items)
			{
				this.scrollPosition = 0f;
				if (value == null)
				{
					value = new string[0];
				}
				this.items = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D24 RID: 3364
	// (get) Token: 0x0600467E RID: 18046 RVA: 0x00102984 File Offset: 0x00100B84
	// (set) Token: 0x0600467F RID: 18047 RVA: 0x0010298C File Offset: 0x00100B8C
	public global::dfScrollbar Scrollbar
	{
		get
		{
			return this.scrollbar;
		}
		set
		{
			this.scrollPosition = 0f;
			if (value != this.scrollbar)
			{
				this.detachScrollbarEvents();
				this.scrollbar = value;
				this.attachScrollbarEvents();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D25 RID: 3365
	// (get) Token: 0x06004680 RID: 18048 RVA: 0x001029C4 File Offset: 0x00100BC4
	// (set) Token: 0x06004681 RID: 18049 RVA: 0x001029E4 File Offset: 0x00100BE4
	public global::UnityEngine.RectOffset ListPadding
	{
		get
		{
			if (this.listPadding == null)
			{
				this.listPadding = new global::UnityEngine.RectOffset();
			}
			return this.listPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.listPadding))
			{
				this.listPadding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D26 RID: 3366
	// (get) Token: 0x06004682 RID: 18050 RVA: 0x00102A18 File Offset: 0x00100C18
	// (set) Token: 0x06004683 RID: 18051 RVA: 0x00102A20 File Offset: 0x00100C20
	public bool Shadow
	{
		get
		{
			return this.shadow;
		}
		set
		{
			if (value != this.shadow)
			{
				this.shadow = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D27 RID: 3367
	// (get) Token: 0x06004684 RID: 18052 RVA: 0x00102A3C File Offset: 0x00100C3C
	// (set) Token: 0x06004685 RID: 18053 RVA: 0x00102A44 File Offset: 0x00100C44
	public global::UnityEngine.Color32 ShadowColor
	{
		get
		{
			return this.shadowColor;
		}
		set
		{
			if (!value.Equals(this.shadowColor))
			{
				this.shadowColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D28 RID: 3368
	// (get) Token: 0x06004686 RID: 18054 RVA: 0x00102A7C File Offset: 0x00100C7C
	// (set) Token: 0x06004687 RID: 18055 RVA: 0x00102A84 File Offset: 0x00100C84
	public global::UnityEngine.Vector2 ShadowOffset
	{
		get
		{
			return this.shadowOffset;
		}
		set
		{
			if (value != this.shadowOffset)
			{
				this.shadowOffset = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D29 RID: 3369
	// (get) Token: 0x06004688 RID: 18056 RVA: 0x00102AA4 File Offset: 0x00100CA4
	// (set) Token: 0x06004689 RID: 18057 RVA: 0x00102AAC File Offset: 0x00100CAC
	public bool AnimateHover
	{
		get
		{
			return this.animateHover;
		}
		set
		{
			this.animateHover = value;
		}
	}

	// Token: 0x17000D2A RID: 3370
	// (get) Token: 0x0600468A RID: 18058 RVA: 0x00102AB8 File Offset: 0x00100CB8
	// (set) Token: 0x0600468B RID: 18059 RVA: 0x00102AC0 File Offset: 0x00100CC0
	public global::dfTextScaleMode TextScaleMode
	{
		get
		{
			return this.textScaleMode;
		}
		set
		{
			this.textScaleMode = value;
			this.Invalidate();
		}
	}

	// Token: 0x0600468C RID: 18060 RVA: 0x00102AD0 File Offset: 0x00100CD0
	public override void Awake()
	{
		base.Awake();
		this.startSize = base.Size;
	}

	// Token: 0x0600468D RID: 18061 RVA: 0x00102AE4 File Offset: 0x00100CE4
	public override void Update()
	{
		base.Update();
		if (this.size.magnitude == 0f)
		{
			this.size = new global::UnityEngine.Vector2(200f, 150f);
		}
		if (this.animateHover && this.hoverIndex != -1)
		{
			float num = (float)(this.hoverIndex * this.itemHeight) * base.PixelsToUnits();
			if (global::UnityEngine.Mathf.Abs(this.hoverTweenLocation - num) < 1f)
			{
				this.Invalidate();
			}
		}
		if (this.isControlInvalidated)
		{
			this.synchronizeScrollbar();
		}
	}

	// Token: 0x0600468E RID: 18062 RVA: 0x00102B7C File Offset: 0x00100D7C
	public override void LateUpdate()
	{
		base.LateUpdate();
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		this.attachScrollbarEvents();
	}

	// Token: 0x0600468F RID: 18063 RVA: 0x00102B98 File Offset: 0x00100D98
	public override void OnDestroy()
	{
		base.OnDestroy();
		this.detachScrollbarEvents();
	}

	// Token: 0x06004690 RID: 18064 RVA: 0x00102BA8 File Offset: 0x00100DA8
	public override void OnDisable()
	{
		base.OnDisable();
		this.detachScrollbarEvents();
	}

	// Token: 0x06004691 RID: 18065 RVA: 0x00102BB8 File Offset: 0x00100DB8
	protected internal virtual void OnSelectedIndexChanged()
	{
		base.SignalHierarchy("OnSelectedIndexChanged", new object[]
		{
			this.selectedIndex
		});
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, this.selectedIndex);
		}
	}

	// Token: 0x06004692 RID: 18066 RVA: 0x00102BF8 File Offset: 0x00100DF8
	protected internal virtual void OnItemClicked()
	{
		base.Signal("OnItemClicked", new object[]
		{
			this.selectedIndex
		});
		if (this.ItemClicked != null)
		{
			this.ItemClicked(this, this.selectedIndex);
		}
	}

	// Token: 0x06004693 RID: 18067 RVA: 0x00102C38 File Offset: 0x00100E38
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		base.OnMouseMove(args);
		if (!(args is global::dfTouchEventArgs))
		{
			this.updateItemHover(args);
			return;
		}
		if (global::UnityEngine.Mathf.Abs(args.Position.y - this.touchStartPosition.y) < (float)(this.itemHeight / 2))
		{
			return;
		}
		this.ScrollPosition = global::UnityEngine.Mathf.Max(0f, this.ScrollPosition + args.MoveDelta.y);
		this.synchronizeScrollbar();
		this.hoverIndex = -1;
	}

	// Token: 0x06004694 RID: 18068 RVA: 0x00102CC0 File Offset: 0x00100EC0
	protected internal override void OnMouseEnter(global::dfMouseEventArgs args)
	{
		base.OnMouseEnter(args);
		this.touchStartPosition = args.Position;
	}

	// Token: 0x06004695 RID: 18069 RVA: 0x00102CD8 File Offset: 0x00100ED8
	protected internal override void OnMouseLeave(global::dfMouseEventArgs args)
	{
		base.OnMouseLeave(args);
		this.hoverIndex = -1;
	}

	// Token: 0x06004696 RID: 18070 RVA: 0x00102CE8 File Offset: 0x00100EE8
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		base.OnMouseWheel(args);
		this.ScrollPosition = global::UnityEngine.Mathf.Max(0f, this.ScrollPosition - (float)((int)args.WheelDelta * this.ItemHeight));
		this.synchronizeScrollbar();
		this.updateItemHover(args);
	}

	// Token: 0x06004697 RID: 18071 RVA: 0x00102D30 File Offset: 0x00100F30
	protected internal override void OnMouseUp(global::dfMouseEventArgs args)
	{
		this.hoverIndex = -1;
		base.OnMouseUp(args);
		if (args is global::dfTouchEventArgs && global::UnityEngine.Mathf.Abs(args.Position.y - this.touchStartPosition.y) < (float)this.itemHeight)
		{
			this.selectItemUnderMouse(args);
		}
	}

	// Token: 0x06004698 RID: 18072 RVA: 0x00102D88 File Offset: 0x00100F88
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		base.OnMouseDown(args);
		if (args is global::dfTouchEventArgs)
		{
			this.touchStartPosition = args.Position;
			return;
		}
		this.selectItemUnderMouse(args);
	}

	// Token: 0x06004699 RID: 18073 RVA: 0x00102DBC File Offset: 0x00100FBC
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		switch (args.KeyCode)
		{
		case 0x111:
			this.SelectedIndex = global::UnityEngine.Mathf.Max(0, this.selectedIndex - 1);
			break;
		case 0x112:
			this.SelectedIndex++;
			break;
		case 0x116:
			this.SelectedIndex = 0;
			break;
		case 0x117:
			this.SelectedIndex = this.items.Length;
			break;
		case 0x118:
		{
			int num = this.SelectedIndex - global::UnityEngine.Mathf.FloorToInt((this.size.y - (float)this.listPadding.vertical) / (float)this.itemHeight);
			this.SelectedIndex = global::UnityEngine.Mathf.Max(0, num);
			break;
		}
		case 0x119:
			this.SelectedIndex += global::UnityEngine.Mathf.FloorToInt((this.size.y - (float)this.listPadding.vertical) / (float)this.itemHeight);
			break;
		}
		base.OnKeyDown(args);
	}

	// Token: 0x0600469A RID: 18074 RVA: 0x00102ED0 File Offset: 0x001010D0
	public void EnsureVisible(int index)
	{
		int num = index * this.ItemHeight;
		if (this.scrollPosition > (float)num)
		{
			this.ScrollPosition = (float)num;
		}
		float num2 = this.size.y - (float)this.listPadding.vertical;
		if (this.scrollPosition + num2 < (float)(num + this.itemHeight))
		{
			this.ScrollPosition = (float)num - num2 + (float)this.itemHeight;
		}
	}

	// Token: 0x0600469B RID: 18075 RVA: 0x00102F3C File Offset: 0x0010113C
	private void selectItemUnderMouse(global::dfMouseEventArgs args)
	{
		float num = this.pivot.TransformToUpperLeft(base.Size).y + ((float)(-(float)this.itemHeight) * ((float)this.selectedIndex - this.scrollPosition) - (float)this.listPadding.top);
		float num2 = ((float)this.selectedIndex - this.scrollPosition + 1f) * (float)this.itemHeight + (float)this.listPadding.vertical;
		float num3 = num2 - this.size.y;
		if (num3 > 0f)
		{
			num += num3;
		}
		float num4 = base.GetHitPosition(args).y - (float)this.listPadding.top;
		if (num4 < 0f || num4 > this.size.y - (float)this.listPadding.bottom)
		{
			return;
		}
		this.SelectedIndex = (int)((this.scrollPosition + num4) / (float)this.itemHeight);
		this.OnItemClicked();
	}

	// Token: 0x0600469C RID: 18076 RVA: 0x00103038 File Offset: 0x00101238
	private void renderHover()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		bool flag = base.Atlas == null || !base.IsEnabled || this.hoverIndex < 0 || this.hoverIndex > this.items.Length - 1 || string.IsNullOrEmpty(this.ItemHover);
		if (flag)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = base.Atlas[this.ItemHover];
		if (itemInfo == null)
		{
			return;
		}
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 offset;
		offset..ctor(vector.x + (float)this.listPadding.left, vector.y - (float)this.listPadding.top + this.scrollPosition, 0f);
		float num = base.PixelsToUnits();
		int num2 = this.hoverIndex * this.itemHeight;
		if (this.animateHover)
		{
			float num3 = global::UnityEngine.Mathf.Abs(this.hoverTweenLocation - (float)num2);
			float num4 = (this.size.y - (float)this.listPadding.vertical) * 0.5f;
			if (num3 > num4)
			{
				this.hoverTweenLocation = (float)num2 + global::UnityEngine.Mathf.Sign(this.hoverTweenLocation - (float)num2) * num4;
			}
			float num5 = global::UnityEngine.Time.deltaTime / num * 2f;
			this.hoverTweenLocation = global::UnityEngine.Mathf.MoveTowards(this.hoverTweenLocation, (float)num2, num5);
		}
		else
		{
			this.hoverTweenLocation = (float)num2;
		}
		offset.y -= this.hoverTweenLocation.Quantize(num);
		global::UnityEngine.Color32 color = base.ApplyOpacity(this.color);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = 1f,
			pixelsToUnits = base.PixelsToUnits(),
			size = new global::UnityEngine.Vector3(this.size.x - (float)this.listPadding.horizontal, (float)this.itemHeight),
			spriteInfo = itemInfo,
			offset = offset
		};
		if (itemInfo.border.horizontal > 0 || itemInfo.border.vertical > 0)
		{
			global::dfSlicedSprite.renderSprite(this.renderData, options);
		}
		else
		{
			global::dfSprite.renderSprite(this.renderData, options);
		}
		if ((float)num2 != this.hoverTweenLocation)
		{
			this.Invalidate();
		}
	}

	// Token: 0x0600469D RID: 18077 RVA: 0x001032BC File Offset: 0x001014BC
	private void renderSelection()
	{
		if (base.Atlas == null || this.selectedIndex < 0)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = base.Atlas[this.ItemHighlight];
		if (itemInfo == null)
		{
			return;
		}
		float pixelsToUnits = base.PixelsToUnits();
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 offset;
		offset..ctor(vector.x + (float)this.listPadding.left, vector.y - (float)this.listPadding.top + this.scrollPosition, 0f);
		offset.y -= (float)(this.selectedIndex * this.itemHeight);
		global::UnityEngine.Color32 color = base.ApplyOpacity(this.color);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = 1f,
			pixelsToUnits = pixelsToUnits,
			size = new global::UnityEngine.Vector3(this.size.x - (float)this.listPadding.horizontal, (float)this.itemHeight),
			spriteInfo = itemInfo,
			offset = offset
		};
		if (itemInfo.border.horizontal > 0 || itemInfo.border.vertical > 0)
		{
			global::dfSlicedSprite.renderSprite(this.renderData, options);
		}
		else
		{
			global::dfSprite.renderSprite(this.renderData, options);
		}
	}

	// Token: 0x0600469E RID: 18078 RVA: 0x00103440 File Offset: 0x00101640
	private float getTextScaleMultiplier()
	{
		if (this.textScaleMode == global::dfTextScaleMode.None || !global::UnityEngine.Application.isPlaying)
		{
			return 1f;
		}
		if (this.textScaleMode == global::dfTextScaleMode.ScreenResolution)
		{
			return (float)global::UnityEngine.Screen.height / (float)this.manager.FixedHeight;
		}
		return base.Size.y / this.startSize.y;
	}

	// Token: 0x0600469F RID: 18079 RVA: 0x001034A4 File Offset: 0x001016A4
	private void renderItems(global::dfRenderData buffer)
	{
		if (this.font == null || this.items == null || this.items.Length == 0)
		{
			return;
		}
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector2 maxSize;
		maxSize..ctor(this.size.x - (float)this.itemPadding.horizontal - (float)this.listPadding.horizontal, (float)(this.itemHeight - this.itemPadding.vertical));
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vectorOffset = new global::UnityEngine.Vector3(vector.x + (float)this.itemPadding.left + (float)this.listPadding.left, vector.y - (float)this.itemPadding.top - (float)this.listPadding.top, 0f) * num;
		vectorOffset.y += this.scrollPosition * num;
		global::UnityEngine.Color32 defaultColor = (!base.IsEnabled) ? base.DisabledColor : this.ItemTextColor;
		float num2 = vector.y * num;
		float num3 = num2 - this.size.y * num;
		for (int i = 0; i < this.items.Length; i++)
		{
			using (global::dfFontRendererBase dfFontRendererBase = this.font.ObtainRenderer())
			{
				dfFontRendererBase.WordWrap = false;
				dfFontRendererBase.MaxSize = maxSize;
				dfFontRendererBase.PixelRatio = num;
				dfFontRendererBase.TextScale = this.ItemTextScale * this.getTextScaleMultiplier();
				dfFontRendererBase.VectorOffset = vectorOffset;
				dfFontRendererBase.MultiLine = false;
				dfFontRendererBase.TextAlign = this.ItemAlignment;
				dfFontRendererBase.ProcessMarkup = true;
				dfFontRendererBase.DefaultColor = defaultColor;
				dfFontRendererBase.OverrideMarkupColors = false;
				dfFontRendererBase.Opacity = base.CalculateOpacity();
				dfFontRendererBase.Shadow = this.Shadow;
				dfFontRendererBase.ShadowColor = this.ShadowColor;
				dfFontRendererBase.ShadowOffset = this.ShadowOffset;
				global::dfDynamicFont.DynamicFontRenderer dynamicFontRenderer = dfFontRendererBase as global::dfDynamicFont.DynamicFontRenderer;
				if (dynamicFontRenderer != null)
				{
					dynamicFontRenderer.SpriteAtlas = base.Atlas;
					dynamicFontRenderer.SpriteBuffer = this.renderData;
				}
				if (vectorOffset.y - (float)this.itemHeight * num <= num2)
				{
					dfFontRendererBase.Render(this.items[i], buffer);
				}
				vectorOffset.y -= (float)this.itemHeight * num;
				dfFontRendererBase.VectorOffset = vectorOffset;
				if (vectorOffset.y < num3)
				{
					break;
				}
			}
		}
	}

	// Token: 0x060046A0 RID: 18080 RVA: 0x0010374C File Offset: 0x0010194C
	private void clipQuads(global::dfRenderData buffer, int startIndex)
	{
		global::dfList<global::UnityEngine.Vector3> vertices = buffer.Vertices;
		global::dfList<global::UnityEngine.Vector2> uv = buffer.UV;
		float num = base.PixelsToUnits();
		float num2 = (base.Pivot.TransformToUpperLeft(base.Size).y - (float)this.listPadding.top) * num;
		float num3 = num2 - (this.size.y - (float)this.listPadding.vertical) * num;
		for (int i = startIndex; i < vertices.Count; i += 4)
		{
			global::UnityEngine.Vector3 value = vertices[i];
			global::UnityEngine.Vector3 value2 = vertices[i + 1];
			global::UnityEngine.Vector3 value3 = vertices[i + 2];
			global::UnityEngine.Vector3 value4 = vertices[i + 3];
			float num4 = value.y - value4.y;
			if (value4.y < num3)
			{
				float num5 = 1f - global::UnityEngine.Mathf.Abs(-num3 + value.y) / num4;
				global::dfList<global::UnityEngine.Vector3> dfList = vertices;
				int index = i;
				value..ctor(value.x, global::UnityEngine.Mathf.Max(value.y, num3), value2.z);
				dfList[index] = value;
				global::dfList<global::UnityEngine.Vector3> dfList2 = vertices;
				int index2 = i + 1;
				value2..ctor(value2.x, global::UnityEngine.Mathf.Max(value2.y, num3), value2.z);
				dfList2[index2] = value2;
				global::dfList<global::UnityEngine.Vector3> dfList3 = vertices;
				int index3 = i + 2;
				value3..ctor(value3.x, global::UnityEngine.Mathf.Max(value3.y, num3), value3.z);
				dfList3[index3] = value3;
				global::dfList<global::UnityEngine.Vector3> dfList4 = vertices;
				int index4 = i + 3;
				value4..ctor(value4.x, global::UnityEngine.Mathf.Max(value4.y, num3), value4.z);
				dfList4[index4] = value4;
				float num6 = global::UnityEngine.Mathf.Lerp(uv[i + 3].y, uv[i].y, num5);
				uv[i + 3] = new global::UnityEngine.Vector2(uv[i + 3].x, num6);
				uv[i + 2] = new global::UnityEngine.Vector2(uv[i + 2].x, num6);
				num4 = global::UnityEngine.Mathf.Abs(value4.y - value.y);
			}
			if (value.y > num2)
			{
				float num7 = global::UnityEngine.Mathf.Abs(num2 - value.y) / num4;
				vertices[i] = new global::UnityEngine.Vector3(value.x, global::UnityEngine.Mathf.Min(num2, value.y), value.z);
				vertices[i + 1] = new global::UnityEngine.Vector3(value2.x, global::UnityEngine.Mathf.Min(num2, value2.y), value2.z);
				vertices[i + 2] = new global::UnityEngine.Vector3(value3.x, global::UnityEngine.Mathf.Min(num2, value3.y), value3.z);
				vertices[i + 3] = new global::UnityEngine.Vector3(value4.x, global::UnityEngine.Mathf.Min(num2, value4.y), value4.z);
				float num8 = global::UnityEngine.Mathf.Lerp(uv[i].y, uv[i + 3].y, num7);
				uv[i] = new global::UnityEngine.Vector2(uv[i].x, num8);
				uv[i + 1] = new global::UnityEngine.Vector2(uv[i + 1].x, num8);
			}
		}
	}

	// Token: 0x060046A1 RID: 18081 RVA: 0x00103AB8 File Offset: 0x00101CB8
	private void updateItemHover(global::dfMouseEventArgs args)
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		global::UnityEngine.Ray ray = args.Ray;
		global::UnityEngine.RaycastHit raycastHit;
		if (!base.collider.Raycast(ray, ref raycastHit, 1000f))
		{
			this.hoverIndex = -1;
			this.hoverTweenLocation = 0f;
			return;
		}
		global::UnityEngine.Vector2 vector;
		base.GetHitPosition(ray, out vector);
		float num = base.Pivot.TransformToUpperLeft(base.Size).y + ((float)(-(float)this.itemHeight) * ((float)this.selectedIndex - this.scrollPosition) - (float)this.listPadding.top);
		float num2 = ((float)this.selectedIndex - this.scrollPosition + 1f) * (float)this.itemHeight + (float)this.listPadding.vertical;
		float num3 = num2 - this.size.y;
		if (num3 > 0f)
		{
			num += num3;
		}
		float num4 = vector.y - (float)this.listPadding.top;
		int num5 = (int)(this.scrollPosition + num4) / this.itemHeight;
		if (num5 != this.hoverIndex)
		{
			this.hoverIndex = num5;
			this.Invalidate();
		}
	}

	// Token: 0x060046A2 RID: 18082 RVA: 0x00103BE0 File Offset: 0x00101DE0
	private float constrainScrollPosition(float value)
	{
		value = global::UnityEngine.Mathf.Max(0f, value);
		int num = this.items.Length * this.itemHeight;
		float num2 = this.size.y - (float)this.listPadding.vertical;
		if ((float)num < num2)
		{
			return 0f;
		}
		return global::UnityEngine.Mathf.Min(value, (float)num - num2);
	}

	// Token: 0x060046A3 RID: 18083 RVA: 0x00103C3C File Offset: 0x00101E3C
	private void attachScrollbarEvents()
	{
		if (this.scrollbar == null || this.eventsAttached)
		{
			return;
		}
		this.eventsAttached = true;
		this.scrollbar.ValueChanged += this.scrollbar_ValueChanged;
		this.scrollbar.GotFocus += this.scrollbar_GotFocus;
	}

	// Token: 0x060046A4 RID: 18084 RVA: 0x00103C9C File Offset: 0x00101E9C
	private void detachScrollbarEvents()
	{
		if (this.scrollbar == null || !this.eventsAttached)
		{
			return;
		}
		this.eventsAttached = false;
		this.scrollbar.ValueChanged -= this.scrollbar_ValueChanged;
		this.scrollbar.GotFocus -= this.scrollbar_GotFocus;
	}

	// Token: 0x060046A5 RID: 18085 RVA: 0x00103CFC File Offset: 0x00101EFC
	private void scrollbar_GotFocus(global::dfControl control, global::dfFocusEventArgs args)
	{
		base.Focus();
	}

	// Token: 0x060046A6 RID: 18086 RVA: 0x00103D04 File Offset: 0x00101F04
	private void scrollbar_ValueChanged(global::dfControl control, float value)
	{
		this.ScrollPosition = value;
	}

	// Token: 0x060046A7 RID: 18087 RVA: 0x00103D10 File Offset: 0x00101F10
	private void synchronizeScrollbar()
	{
		if (this.scrollbar == null)
		{
			return;
		}
		int num = this.items.Length * this.itemHeight;
		float scrollSize = this.size.y - (float)this.listPadding.vertical;
		this.scrollbar.IncrementAmount = (float)this.itemHeight;
		this.scrollbar.MinValue = 0f;
		this.scrollbar.MaxValue = (float)num;
		this.scrollbar.ScrollSize = scrollSize;
		this.scrollbar.Value = this.scrollPosition;
	}

	// Token: 0x060046A8 RID: 18088 RVA: 0x00103DA4 File Offset: 0x00101FA4
	public global::dfList<global::dfRenderData> RenderMultiple()
	{
		if (base.Atlas == null || this.Font == null)
		{
			return null;
		}
		if (!this.isVisible)
		{
			return null;
		}
		if (this.renderData == null)
		{
			this.renderData = global::dfRenderData.Obtain();
			this.textRenderData = global::dfRenderData.Obtain();
			this.isControlInvalidated = true;
		}
		if (!this.isControlInvalidated)
		{
			for (int i = 0; i < this.buffers.Count; i++)
			{
				this.buffers[i].Transform = base.transform.localToWorldMatrix;
			}
			return this.buffers;
		}
		this.buffers.Clear();
		this.renderData.Clear();
		this.renderData.Material = base.Atlas.Material;
		this.renderData.Transform = base.transform.localToWorldMatrix;
		this.buffers.Add(this.renderData);
		this.textRenderData.Clear();
		this.textRenderData.Material = base.Atlas.Material;
		this.textRenderData.Transform = base.transform.localToWorldMatrix;
		this.buffers.Add(this.textRenderData);
		this.renderBackground();
		int count = this.renderData.Vertices.Count;
		this.renderHover();
		this.renderSelection();
		this.renderItems(this.textRenderData);
		this.clipQuads(this.renderData, count);
		this.clipQuads(this.textRenderData, 0);
		this.isControlInvalidated = false;
		this.updateCollider();
		return this.buffers;
	}

	// Token: 0x04002602 RID: 9730
	[global::UnityEngine.SerializeField]
	protected global::dfFontBase font;

	// Token: 0x04002603 RID: 9731
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset listPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002604 RID: 9732
	[global::UnityEngine.SerializeField]
	protected int selectedIndex = -1;

	// Token: 0x04002605 RID: 9733
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 itemTextColor = global::UnityEngine.Color.white;

	// Token: 0x04002606 RID: 9734
	[global::UnityEngine.SerializeField]
	protected float itemTextScale = 1f;

	// Token: 0x04002607 RID: 9735
	[global::UnityEngine.SerializeField]
	protected int itemHeight = 0x19;

	// Token: 0x04002608 RID: 9736
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset itemPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002609 RID: 9737
	[global::UnityEngine.SerializeField]
	protected string[] items = new string[0];

	// Token: 0x0400260A RID: 9738
	[global::UnityEngine.SerializeField]
	protected string itemHighlight = string.Empty;

	// Token: 0x0400260B RID: 9739
	[global::UnityEngine.SerializeField]
	protected string itemHover = string.Empty;

	// Token: 0x0400260C RID: 9740
	[global::UnityEngine.SerializeField]
	protected global::dfScrollbar scrollbar;

	// Token: 0x0400260D RID: 9741
	[global::UnityEngine.SerializeField]
	protected bool animateHover;

	// Token: 0x0400260E RID: 9742
	[global::UnityEngine.SerializeField]
	protected bool shadow;

	// Token: 0x0400260F RID: 9743
	[global::UnityEngine.SerializeField]
	protected global::dfTextScaleMode textScaleMode;

	// Token: 0x04002610 RID: 9744
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 shadowColor = global::UnityEngine.Color.black;

	// Token: 0x04002611 RID: 9745
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 shadowOffset = new global::UnityEngine.Vector2(1f, -1f);

	// Token: 0x04002612 RID: 9746
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.TextAlignment itemAlignment;

	// Token: 0x04002613 RID: 9747
	private bool eventsAttached;

	// Token: 0x04002614 RID: 9748
	private float scrollPosition;

	// Token: 0x04002615 RID: 9749
	private int hoverIndex = -1;

	// Token: 0x04002616 RID: 9750
	private float hoverTweenLocation;

	// Token: 0x04002617 RID: 9751
	private global::UnityEngine.Vector2 touchStartPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002618 RID: 9752
	private global::UnityEngine.Vector2 startSize = global::UnityEngine.Vector2.zero;

	// Token: 0x04002619 RID: 9753
	private global::dfRenderData textRenderData;

	// Token: 0x0400261A RID: 9754
	private global::dfList<global::dfRenderData> buffers = global::dfList<global::dfRenderData>.Obtain();

	// Token: 0x0400261B RID: 9755
	private global::PropertyChangedEventHandler<int> SelectedIndexChanged;

	// Token: 0x0400261C RID: 9756
	private global::PropertyChangedEventHandler<int> ItemClicked;
}
