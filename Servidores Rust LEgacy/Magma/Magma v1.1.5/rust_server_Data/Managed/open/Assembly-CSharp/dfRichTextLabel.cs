using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200087C RID: 2172
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Rich Text Label")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfRichTextLabel : global::dfControl, global::IDFMultiRender
{
	// Token: 0x06004B03 RID: 19203 RVA: 0x0011AA34 File Offset: 0x00118C34
	public dfRichTextLabel()
	{
	}

	// Token: 0x06004B04 RID: 19204 RVA: 0x0011AAAC File Offset: 0x00118CAC
	// Note: this type is marked as 'beforefieldinit'.
	static dfRichTextLabel()
	{
	}

	// Token: 0x14000061 RID: 97
	// (add) Token: 0x06004B05 RID: 19205 RVA: 0x0011AABC File Offset: 0x00118CBC
	// (remove) Token: 0x06004B06 RID: 19206 RVA: 0x0011AAD8 File Offset: 0x00118CD8
	public event global::PropertyChangedEventHandler<string> TextChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TextChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Combine(this.TextChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TextChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Remove(this.TextChanged, value);
		}
	}

	// Token: 0x14000062 RID: 98
	// (add) Token: 0x06004B07 RID: 19207 RVA: 0x0011AAF4 File Offset: 0x00118CF4
	// (remove) Token: 0x06004B08 RID: 19208 RVA: 0x0011AB10 File Offset: 0x00118D10
	public event global::PropertyChangedEventHandler<global::UnityEngine.Vector2> ScrollPositionChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ScrollPositionChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Combine(this.ScrollPositionChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ScrollPositionChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Remove(this.ScrollPositionChanged, value);
		}
	}

	// Token: 0x14000063 RID: 99
	// (add) Token: 0x06004B09 RID: 19209 RVA: 0x0011AB2C File Offset: 0x00118D2C
	// (remove) Token: 0x06004B0A RID: 19210 RVA: 0x0011AB48 File Offset: 0x00118D48
	public event global::dfRichTextLabel.LinkClickEventHandler LinkClicked
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.LinkClicked = (global::dfRichTextLabel.LinkClickEventHandler)global::System.Delegate.Combine(this.LinkClicked, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.LinkClicked = (global::dfRichTextLabel.LinkClickEventHandler)global::System.Delegate.Remove(this.LinkClicked, value);
		}
	}

	// Token: 0x17000E05 RID: 3589
	// (get) Token: 0x06004B0B RID: 19211 RVA: 0x0011AB64 File Offset: 0x00118D64
	// (set) Token: 0x06004B0C RID: 19212 RVA: 0x0011ABAC File Offset: 0x00118DAC
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

	// Token: 0x17000E06 RID: 3590
	// (get) Token: 0x06004B0D RID: 19213 RVA: 0x0011ABCC File Offset: 0x00118DCC
	// (set) Token: 0x06004B0E RID: 19214 RVA: 0x0011ABD4 File Offset: 0x00118DD4
	public global::dfDynamicFont Font
	{
		get
		{
			return this.font;
		}
		set
		{
			if (value != this.font)
			{
				this.font = value;
				this.LineHeight = value.FontSize;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000E07 RID: 3591
	// (get) Token: 0x06004B0F RID: 19215 RVA: 0x0011AC0C File Offset: 0x00118E0C
	// (set) Token: 0x06004B10 RID: 19216 RVA: 0x0011AC14 File Offset: 0x00118E14
	public string BlankTextureSprite
	{
		get
		{
			return this.blankTextureSprite;
		}
		set
		{
			if (value != this.blankTextureSprite)
			{
				this.blankTextureSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000E08 RID: 3592
	// (get) Token: 0x06004B11 RID: 19217 RVA: 0x0011AC34 File Offset: 0x00118E34
	// (set) Token: 0x06004B12 RID: 19218 RVA: 0x0011AC3C File Offset: 0x00118E3C
	public string Text
	{
		get
		{
			return this.text;
		}
		set
		{
			value = base.getLocalizedValue(value);
			if (!string.Equals(this.text, value))
			{
				this.text = value;
				this.scrollPosition = global::UnityEngine.Vector2.zero;
				this.Invalidate();
				this.OnTextChanged();
			}
		}
	}

	// Token: 0x17000E09 RID: 3593
	// (get) Token: 0x06004B13 RID: 19219 RVA: 0x0011AC84 File Offset: 0x00118E84
	// (set) Token: 0x06004B14 RID: 19220 RVA: 0x0011AC8C File Offset: 0x00118E8C
	public int FontSize
	{
		get
		{
			return this.fontSize;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(6, value);
			if (value != this.fontSize)
			{
				this.fontSize = value;
				this.Invalidate();
			}
			this.LineHeight = value;
		}
	}

	// Token: 0x17000E0A RID: 3594
	// (get) Token: 0x06004B15 RID: 19221 RVA: 0x0011ACB8 File Offset: 0x00118EB8
	// (set) Token: 0x06004B16 RID: 19222 RVA: 0x0011ACC0 File Offset: 0x00118EC0
	public int LineHeight
	{
		get
		{
			return this.lineheight;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(this.FontSize, value);
			if (value != this.lineheight)
			{
				this.lineheight = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000E0B RID: 3595
	// (get) Token: 0x06004B17 RID: 19223 RVA: 0x0011ACEC File Offset: 0x00118EEC
	// (set) Token: 0x06004B18 RID: 19224 RVA: 0x0011ACF4 File Offset: 0x00118EF4
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

	// Token: 0x17000E0C RID: 3596
	// (get) Token: 0x06004B19 RID: 19225 RVA: 0x0011AD04 File Offset: 0x00118F04
	// (set) Token: 0x06004B1A RID: 19226 RVA: 0x0011AD0C File Offset: 0x00118F0C
	public bool PreserveWhitespace
	{
		get
		{
			return this.preserveWhitespace;
		}
		set
		{
			if (value != this.preserveWhitespace)
			{
				this.preserveWhitespace = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000E0D RID: 3597
	// (get) Token: 0x06004B1B RID: 19227 RVA: 0x0011AD28 File Offset: 0x00118F28
	// (set) Token: 0x06004B1C RID: 19228 RVA: 0x0011AD30 File Offset: 0x00118F30
	public global::UnityEngine.FontStyle FontStyle
	{
		get
		{
			return this.fontStyle;
		}
		set
		{
			if (value != this.fontStyle)
			{
				this.fontStyle = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000E0E RID: 3598
	// (get) Token: 0x06004B1D RID: 19229 RVA: 0x0011AD4C File Offset: 0x00118F4C
	// (set) Token: 0x06004B1E RID: 19230 RVA: 0x0011AD54 File Offset: 0x00118F54
	public global::dfMarkupTextAlign TextAlignment
	{
		get
		{
			return this.align;
		}
		set
		{
			if (value != this.align)
			{
				this.align = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000E0F RID: 3599
	// (get) Token: 0x06004B1F RID: 19231 RVA: 0x0011AD70 File Offset: 0x00118F70
	// (set) Token: 0x06004B20 RID: 19232 RVA: 0x0011AD78 File Offset: 0x00118F78
	public bool AllowScrolling
	{
		get
		{
			return this.allowScrolling;
		}
		set
		{
			this.allowScrolling = value;
			if (!value)
			{
				this.ScrollPosition = global::UnityEngine.Vector2.zero;
			}
		}
	}

	// Token: 0x17000E10 RID: 3600
	// (get) Token: 0x06004B21 RID: 19233 RVA: 0x0011AD94 File Offset: 0x00118F94
	// (set) Token: 0x06004B22 RID: 19234 RVA: 0x0011AD9C File Offset: 0x00118F9C
	public global::UnityEngine.Vector2 ScrollPosition
	{
		get
		{
			return this.scrollPosition;
		}
		set
		{
			if (!this.allowScrolling)
			{
				value = global::UnityEngine.Vector2.zero;
			}
			global::UnityEngine.Vector2 vector = this.ContentSize - base.Size;
			value = global::UnityEngine.Vector2.Min(vector, value);
			value = global::UnityEngine.Vector2.Max(global::UnityEngine.Vector2.zero, value);
			value = value.RoundToInt();
			if ((value - this.scrollPosition).sqrMagnitude > 1E-45f)
			{
				this.scrollPosition = value;
				this.updateScrollbars();
				this.OnScrollPositionChanged();
			}
		}
	}

	// Token: 0x17000E11 RID: 3601
	// (get) Token: 0x06004B23 RID: 19235 RVA: 0x0011AE1C File Offset: 0x0011901C
	// (set) Token: 0x06004B24 RID: 19236 RVA: 0x0011AE24 File Offset: 0x00119024
	public global::dfScrollbar HorizontalScrollbar
	{
		get
		{
			return this.horzScrollbar;
		}
		set
		{
			this.horzScrollbar = value;
			this.updateScrollbars();
		}
	}

	// Token: 0x17000E12 RID: 3602
	// (get) Token: 0x06004B25 RID: 19237 RVA: 0x0011AE34 File Offset: 0x00119034
	// (set) Token: 0x06004B26 RID: 19238 RVA: 0x0011AE3C File Offset: 0x0011903C
	public global::dfScrollbar VerticalScrollbar
	{
		get
		{
			return this.vertScrollbar;
		}
		set
		{
			this.vertScrollbar = value;
			this.updateScrollbars();
		}
	}

	// Token: 0x17000E13 RID: 3603
	// (get) Token: 0x06004B27 RID: 19239 RVA: 0x0011AE4C File Offset: 0x0011904C
	public global::UnityEngine.Vector2 ContentSize
	{
		get
		{
			if (this.viewportBox != null)
			{
				return this.viewportBox.Size;
			}
			return base.Size;
		}
	}

	// Token: 0x17000E14 RID: 3604
	// (get) Token: 0x06004B28 RID: 19240 RVA: 0x0011AE6C File Offset: 0x0011906C
	// (set) Token: 0x06004B29 RID: 19241 RVA: 0x0011AE74 File Offset: 0x00119074
	public bool UseScrollMomentum
	{
		get
		{
			return this.useScrollMomentum;
		}
		set
		{
			this.useScrollMomentum = value;
			this.scrollMomentum = global::UnityEngine.Vector2.zero;
		}
	}

	// Token: 0x06004B2A RID: 19242 RVA: 0x0011AE88 File Offset: 0x00119088
	protected internal override void OnLocalize()
	{
		base.OnLocalize();
		this.Text = base.getLocalizedValue(this.text);
	}

	// Token: 0x06004B2B RID: 19243 RVA: 0x0011AEA4 File Offset: 0x001190A4
	public override void Invalidate()
	{
		base.Invalidate();
		this.isMarkupInvalidated = true;
	}

	// Token: 0x06004B2C RID: 19244 RVA: 0x0011AEB4 File Offset: 0x001190B4
	public override void Awake()
	{
		base.Awake();
		this.startSize = base.Size;
	}

	// Token: 0x06004B2D RID: 19245 RVA: 0x0011AEC8 File Offset: 0x001190C8
	public override void OnEnable()
	{
		base.OnEnable();
		if (this.size.sqrMagnitude <= 1E-45f)
		{
			base.Size = new global::UnityEngine.Vector2(320f, 200f);
			int lineHeight = 0x10;
			this.LineHeight = lineHeight;
			this.FontSize = lineHeight;
		}
	}

	// Token: 0x06004B2E RID: 19246 RVA: 0x0011AF18 File Offset: 0x00119118
	public override void Update()
	{
		base.Update();
		if (this.useScrollMomentum && !this.isMouseDown && this.scrollMomentum.magnitude > 0.1f)
		{
			this.ScrollPosition += this.scrollMomentum;
			this.scrollMomentum *= 0.95f - global::UnityEngine.Time.deltaTime;
		}
	}

	// Token: 0x06004B2F RID: 19247 RVA: 0x0011AF8C File Offset: 0x0011918C
	public override void LateUpdate()
	{
		base.LateUpdate();
		this.initialize();
	}

	// Token: 0x06004B30 RID: 19248 RVA: 0x0011AF9C File Offset: 0x0011919C
	protected internal void OnTextChanged()
	{
		this.Invalidate();
		base.Signal("OnTextChanged", new object[]
		{
			this.text
		});
		if (this.TextChanged != null)
		{
			this.TextChanged(this, this.text);
		}
	}

	// Token: 0x06004B31 RID: 19249 RVA: 0x0011AFE8 File Offset: 0x001191E8
	protected internal void OnScrollPositionChanged()
	{
		base.Invalidate();
		base.SignalHierarchy("OnScrollPositionChanged", new object[]
		{
			this.ScrollPosition
		});
		if (this.ScrollPositionChanged != null)
		{
			this.ScrollPositionChanged(this, this.ScrollPosition);
		}
	}

	// Token: 0x06004B32 RID: 19250 RVA: 0x0011B038 File Offset: 0x00119238
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (args.Used)
		{
			base.OnKeyDown(args);
			return;
		}
		int num = this.FontSize;
		int num2 = this.FontSize;
		if (args.KeyCode == 0x114)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2((float)(-(float)num), 0f);
			args.Use();
		}
		else if (args.KeyCode == 0x113)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2((float)num, 0f);
			args.Use();
		}
		else if (args.KeyCode == 0x111)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2(0f, (float)(-(float)num2));
			args.Use();
		}
		else if (args.KeyCode == 0x112)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2(0f, (float)num2);
			args.Use();
		}
		base.OnKeyDown(args);
	}

	// Token: 0x06004B33 RID: 19251 RVA: 0x0011B14C File Offset: 0x0011934C
	internal override void OnDragEnd(global::dfDragEventArgs args)
	{
		base.OnDragEnd(args);
		this.isMouseDown = false;
	}

	// Token: 0x06004B34 RID: 19252 RVA: 0x0011B15C File Offset: 0x0011935C
	protected internal override void OnMouseEnter(global::dfMouseEventArgs args)
	{
		base.OnMouseEnter(args);
		this.touchStartPosition = args.Position;
	}

	// Token: 0x06004B35 RID: 19253 RVA: 0x0011B174 File Offset: 0x00119374
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		base.OnMouseDown(args);
		this.mouseDownTag = this.hitTestTag(args);
		this.mouseDownScrollPosition = this.scrollPosition;
		this.scrollMomentum = global::UnityEngine.Vector2.zero;
		this.touchStartPosition = args.Position;
		this.isMouseDown = true;
	}

	// Token: 0x06004B36 RID: 19254 RVA: 0x0011B1C0 File Offset: 0x001193C0
	protected internal override void OnMouseUp(global::dfMouseEventArgs args)
	{
		base.OnMouseUp(args);
		this.isMouseDown = false;
		if (global::UnityEngine.Vector2.Distance(this.scrollPosition, this.mouseDownScrollPosition) <= 2f && this.hitTestTag(args) == this.mouseDownTag)
		{
			global::dfMarkupTag dfMarkupTag = this.mouseDownTag;
			while (dfMarkupTag != null && !(dfMarkupTag is global::dfMarkupTagAnchor))
			{
				dfMarkupTag = (dfMarkupTag.Parent as global::dfMarkupTag);
			}
			if (dfMarkupTag is global::dfMarkupTagAnchor)
			{
				base.Signal("OnLinkClicked", new object[]
				{
					dfMarkupTag
				});
				if (this.LinkClicked != null)
				{
					this.LinkClicked(this, dfMarkupTag as global::dfMarkupTagAnchor);
				}
			}
		}
		this.mouseDownTag = null;
		this.mouseDownScrollPosition = this.scrollPosition;
	}

	// Token: 0x06004B37 RID: 19255 RVA: 0x0011B284 File Offset: 0x00119484
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		base.OnMouseMove(args);
		if (!this.allowScrolling)
		{
			return;
		}
		bool flag = args is global::dfTouchEventArgs || this.isMouseDown;
		if (flag && (args.Position - this.touchStartPosition).magnitude > 5f)
		{
			global::UnityEngine.Vector2 vector = args.MoveDelta.Scale(-1f, 1f);
			this.ScrollPosition += vector;
			this.scrollMomentum = (this.scrollMomentum + vector) * 0.5f;
		}
	}

	// Token: 0x06004B38 RID: 19256 RVA: 0x0011B328 File Offset: 0x00119528
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		try
		{
			if (!args.Used && this.allowScrolling)
			{
				int num = (!this.UseScrollMomentum) ? 3 : 1;
				float num2 = (!(this.vertScrollbar != null)) ? ((float)(this.FontSize * num)) : this.vertScrollbar.IncrementAmount;
				this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, this.scrollPosition.y - num2 * args.WheelDelta);
				this.scrollMomentum = new global::UnityEngine.Vector2(0f, -num2 * args.WheelDelta);
				args.Use();
				base.Signal("OnMouseWheel", new object[]
				{
					args
				});
			}
		}
		finally
		{
			base.OnMouseWheel(args);
		}
	}

	// Token: 0x06004B39 RID: 19257 RVA: 0x0011B418 File Offset: 0x00119618
	public void ScrollToTop()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, 0f);
	}

	// Token: 0x06004B3A RID: 19258 RVA: 0x0011B438 File Offset: 0x00119638
	public void ScrollToBottom()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, 2.1474836E+09f);
	}

	// Token: 0x06004B3B RID: 19259 RVA: 0x0011B458 File Offset: 0x00119658
	public void ScrollToLeft()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(0f, this.scrollPosition.y);
	}

	// Token: 0x06004B3C RID: 19260 RVA: 0x0011B478 File Offset: 0x00119678
	public void ScrollToRight()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(2.1474836E+09f, this.scrollPosition.y);
	}

	// Token: 0x06004B3D RID: 19261 RVA: 0x0011B498 File Offset: 0x00119698
	public global::dfList<global::dfRenderData> RenderMultiple()
	{
		if (!this.isVisible || this.Font == null)
		{
			return null;
		}
		if (!this.isControlInvalidated && this.viewportBox != null)
		{
			this.buffers.Clear();
			this.gatherRenderBuffers(this.viewportBox, this.buffers);
			return this.buffers;
		}
		global::dfList<global::dfRenderData> result;
		try
		{
			if (this.isMarkupInvalidated)
			{
				this.isMarkupInvalidated = false;
				this.processMarkup();
			}
			this.viewportBox.FitToContents(false);
			this.updateScrollbars();
			this.buffers.Clear();
			this.gatherRenderBuffers(this.viewportBox, this.buffers);
			result = this.buffers;
		}
		finally
		{
			this.isControlInvalidated = false;
		}
		return result;
	}

	// Token: 0x06004B3E RID: 19262 RVA: 0x0011B57C File Offset: 0x0011977C
	private global::dfMarkupTag hitTestTag(global::dfMouseEventArgs args)
	{
		global::UnityEngine.Vector2 point = base.GetHitPosition(args) + this.scrollPosition;
		global::dfMarkupBox dfMarkupBox = this.viewportBox.HitTest(point);
		if (dfMarkupBox != null)
		{
			global::dfMarkupElement dfMarkupElement = dfMarkupBox.Element;
			while (dfMarkupElement != null && !(dfMarkupElement is global::dfMarkupTag))
			{
				dfMarkupElement = dfMarkupElement.Parent;
			}
			return dfMarkupElement as global::dfMarkupTag;
		}
		return null;
	}

	// Token: 0x06004B3F RID: 19263 RVA: 0x0011B5DC File Offset: 0x001197DC
	private void processMarkup()
	{
		this.releaseMarkupReferences();
		this.elements = global::dfMarkupParser.Parse(this, this.text);
		float textScaleMultiplier = this.getTextScaleMultiplier();
		int num = global::UnityEngine.Mathf.CeilToInt((float)this.FontSize * textScaleMultiplier);
		int lineHeight = global::UnityEngine.Mathf.CeilToInt((float)this.LineHeight * textScaleMultiplier);
		global::dfMarkupStyle style = new global::dfMarkupStyle
		{
			Host = this,
			Atlas = this.Atlas,
			Font = this.Font,
			FontSize = num,
			FontStyle = this.FontStyle,
			LineHeight = lineHeight,
			Color = base.ApplyOpacity(base.Color),
			Opacity = base.CalculateOpacity(),
			Align = this.TextAlignment,
			PreserveWhitespace = this.preserveWhitespace
		};
		this.viewportBox = new global::dfMarkupBox(null, global::dfMarkupDisplayType.block, style)
		{
			Size = base.Size
		};
		for (int i = 0; i < this.elements.Count; i++)
		{
			global::dfMarkupElement dfMarkupElement = this.elements[i];
			if (dfMarkupElement != null)
			{
				dfMarkupElement.PerformLayout(this.viewportBox, style);
			}
		}
	}

	// Token: 0x06004B40 RID: 19264 RVA: 0x0011B718 File Offset: 0x00119918
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

	// Token: 0x06004B41 RID: 19265 RVA: 0x0011B77C File Offset: 0x0011997C
	private void releaseMarkupReferences()
	{
		this.mouseDownTag = null;
		if (this.viewportBox != null)
		{
			this.viewportBox.Release();
		}
		if (this.elements != null)
		{
			for (int i = 0; i < this.elements.Count; i++)
			{
				this.elements[i].Release();
			}
			this.elements.Release();
		}
	}

	// Token: 0x06004B42 RID: 19266 RVA: 0x0011B7EC File Offset: 0x001199EC
	[global::UnityEngine.HideInInspector]
	private void initialize()
	{
		if (this.initialized)
		{
			return;
		}
		this.initialized = true;
		if (global::UnityEngine.Application.isPlaying)
		{
			if (this.horzScrollbar != null)
			{
				this.horzScrollbar.ValueChanged += this.horzScroll_ValueChanged;
			}
			if (this.vertScrollbar != null)
			{
				this.vertScrollbar.ValueChanged += this.vertScroll_ValueChanged;
			}
		}
		this.Invalidate();
		this.ScrollPosition = global::UnityEngine.Vector2.zero;
		this.updateScrollbars();
	}

	// Token: 0x06004B43 RID: 19267 RVA: 0x0011B880 File Offset: 0x00119A80
	private void vertScroll_ValueChanged(global::dfControl control, float value)
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, value);
	}

	// Token: 0x06004B44 RID: 19268 RVA: 0x0011B89C File Offset: 0x00119A9C
	private void horzScroll_ValueChanged(global::dfControl control, float value)
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(value, this.ScrollPosition.y);
	}

	// Token: 0x06004B45 RID: 19269 RVA: 0x0011B8C4 File Offset: 0x00119AC4
	private void updateScrollbars()
	{
		if (this.horzScrollbar != null)
		{
			this.horzScrollbar.MinValue = 0f;
			this.horzScrollbar.MaxValue = this.ContentSize.x;
			this.horzScrollbar.ScrollSize = base.Size.x;
			this.horzScrollbar.Value = this.ScrollPosition.x;
		}
		if (this.vertScrollbar != null)
		{
			this.vertScrollbar.MinValue = 0f;
			this.vertScrollbar.MaxValue = this.ContentSize.y;
			this.vertScrollbar.ScrollSize = base.Size.y;
			this.vertScrollbar.Value = this.ScrollPosition.y;
		}
	}

	// Token: 0x06004B46 RID: 19270 RVA: 0x0011B9AC File Offset: 0x00119BAC
	private void gatherRenderBuffers(global::dfMarkupBox box, global::dfList<global::dfRenderData> buffers)
	{
		global::dfIntersectionType viewportIntersection = this.getViewportIntersection(box);
		if (viewportIntersection == global::dfIntersectionType.None)
		{
			return;
		}
		global::dfRenderData dfRenderData = box.Render();
		if (dfRenderData != null)
		{
			if (dfRenderData.Material == null && this.atlas != null)
			{
				dfRenderData.Material = this.atlas.Material;
			}
			float num = base.PixelsToUnits();
			global::UnityEngine.Vector2 vector = -this.scrollPosition.Scale(1f, -1f).RoundToInt();
			global::UnityEngine.Vector3 vector2 = vector + box.GetOffset().Scale(1f, -1f) + this.pivot.TransformToUpperLeft(base.Size);
			global::dfList<global::UnityEngine.Vector3> vertices = dfRenderData.Vertices;
			global::UnityEngine.Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			for (int i = 0; i < dfRenderData.Vertices.Count; i++)
			{
				vertices[i] = localToWorldMatrix.MultiplyPoint((vector2 + vertices[i]) * num);
			}
			if (viewportIntersection == global::dfIntersectionType.Intersecting)
			{
				this.clipToViewport(dfRenderData);
			}
			buffers.Add(dfRenderData);
		}
		for (int j = 0; j < box.Children.Count; j++)
		{
			this.gatherRenderBuffers(box.Children[j], buffers);
		}
	}

	// Token: 0x06004B47 RID: 19271 RVA: 0x0011BB0C File Offset: 0x00119D0C
	private global::dfIntersectionType getViewportIntersection(global::dfMarkupBox box)
	{
		if (box.Display == global::dfMarkupDisplayType.none)
		{
			return global::dfIntersectionType.None;
		}
		global::UnityEngine.Vector2 size = base.Size;
		global::UnityEngine.Vector2 vector = box.GetOffset() - this.scrollPosition;
		global::UnityEngine.Vector2 vector2 = vector + box.Size;
		if (vector2.x <= 0f || vector2.y <= 0f)
		{
			return global::dfIntersectionType.None;
		}
		if (vector.x >= size.x || vector.y >= size.y)
		{
			return global::dfIntersectionType.None;
		}
		if (vector.x < 0f || vector.y < 0f || vector2.x > size.x || vector2.y > size.y)
		{
			return global::dfIntersectionType.Intersecting;
		}
		return global::dfIntersectionType.Inside;
	}

	// Token: 0x06004B48 RID: 19272 RVA: 0x0011BBE8 File Offset: 0x00119DE8
	private void clipToViewport(global::dfRenderData renderData)
	{
		global::UnityEngine.Plane[] clippingPlanes = this.GetClippingPlanes();
		global::UnityEngine.Material material = renderData.Material;
		global::UnityEngine.Matrix4x4 transform = renderData.Transform;
		global::dfRichTextLabel.clipBuffer.Clear();
		global::dfClippingUtil.Clip(clippingPlanes, renderData, global::dfRichTextLabel.clipBuffer);
		renderData.Clear();
		renderData.Merge(global::dfRichTextLabel.clipBuffer, false);
		renderData.Material = material;
		renderData.Transform = transform;
	}

	// Token: 0x040027F2 RID: 10226
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x040027F3 RID: 10227
	[global::UnityEngine.SerializeField]
	protected global::dfDynamicFont font;

	// Token: 0x040027F4 RID: 10228
	[global::UnityEngine.SerializeField]
	protected string text = "Rich Text Label";

	// Token: 0x040027F5 RID: 10229
	[global::UnityEngine.SerializeField]
	protected int fontSize = 0x10;

	// Token: 0x040027F6 RID: 10230
	[global::UnityEngine.SerializeField]
	protected int lineheight = 0x10;

	// Token: 0x040027F7 RID: 10231
	[global::UnityEngine.SerializeField]
	protected global::dfTextScaleMode textScaleMode;

	// Token: 0x040027F8 RID: 10232
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.FontStyle fontStyle;

	// Token: 0x040027F9 RID: 10233
	[global::UnityEngine.SerializeField]
	protected bool preserveWhitespace;

	// Token: 0x040027FA RID: 10234
	[global::UnityEngine.SerializeField]
	protected string blankTextureSprite;

	// Token: 0x040027FB RID: 10235
	[global::UnityEngine.SerializeField]
	protected global::dfMarkupTextAlign align;

	// Token: 0x040027FC RID: 10236
	[global::UnityEngine.SerializeField]
	protected bool allowScrolling;

	// Token: 0x040027FD RID: 10237
	[global::UnityEngine.SerializeField]
	protected global::dfScrollbar horzScrollbar;

	// Token: 0x040027FE RID: 10238
	[global::UnityEngine.SerializeField]
	protected global::dfScrollbar vertScrollbar;

	// Token: 0x040027FF RID: 10239
	[global::UnityEngine.SerializeField]
	protected bool useScrollMomentum;

	// Token: 0x04002800 RID: 10240
	private static global::dfRenderData clipBuffer = new global::dfRenderData(0x20);

	// Token: 0x04002801 RID: 10241
	private global::dfList<global::dfRenderData> buffers = new global::dfList<global::dfRenderData>();

	// Token: 0x04002802 RID: 10242
	private global::dfList<global::dfMarkupElement> elements;

	// Token: 0x04002803 RID: 10243
	private global::dfMarkupBox viewportBox;

	// Token: 0x04002804 RID: 10244
	private global::dfMarkupTag mouseDownTag;

	// Token: 0x04002805 RID: 10245
	private global::UnityEngine.Vector2 mouseDownScrollPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002806 RID: 10246
	private global::UnityEngine.Vector2 scrollPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002807 RID: 10247
	private bool initialized;

	// Token: 0x04002808 RID: 10248
	private bool isMouseDown;

	// Token: 0x04002809 RID: 10249
	private global::UnityEngine.Vector2 touchStartPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x0400280A RID: 10250
	private global::UnityEngine.Vector2 scrollMomentum = global::UnityEngine.Vector2.zero;

	// Token: 0x0400280B RID: 10251
	private bool isMarkupInvalidated = true;

	// Token: 0x0400280C RID: 10252
	private global::UnityEngine.Vector2 startSize = global::UnityEngine.Vector2.zero;

	// Token: 0x0400280D RID: 10253
	private global::PropertyChangedEventHandler<string> TextChanged;

	// Token: 0x0400280E RID: 10254
	private global::PropertyChangedEventHandler<global::UnityEngine.Vector2> ScrollPositionChanged;

	// Token: 0x0400280F RID: 10255
	private global::dfRichTextLabel.LinkClickEventHandler LinkClicked;

	// Token: 0x0200087D RID: 2173
	// (Invoke) Token: 0x06004B4A RID: 19274
	[global::dfEventCategory("Markup")]
	public delegate void LinkClickEventHandler(global::dfRichTextLabel sender, global::dfMarkupTagAnchor tag);
}
