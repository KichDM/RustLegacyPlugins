using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007D6 RID: 2006
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Button")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfButton : global::dfInteractiveBase, global::IDFMultiRender
{
	// Token: 0x0600424D RID: 16973 RVA: 0x000F0F54 File Offset: 0x000EF154
	public dfButton()
	{
	}

	// Token: 0x14000020 RID: 32
	// (add) Token: 0x0600424E RID: 16974 RVA: 0x000F1054 File Offset: 0x000EF254
	// (remove) Token: 0x0600424F RID: 16975 RVA: 0x000F1070 File Offset: 0x000EF270
	public event global::PropertyChangedEventHandler<global::dfButton.ButtonState> ButtonStateChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ButtonStateChanged = (global::PropertyChangedEventHandler<global::dfButton.ButtonState>)global::System.Delegate.Combine(this.ButtonStateChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ButtonStateChanged = (global::PropertyChangedEventHandler<global::dfButton.ButtonState>)global::System.Delegate.Remove(this.ButtonStateChanged, value);
		}
	}

	// Token: 0x17000C2F RID: 3119
	// (get) Token: 0x06004250 RID: 16976 RVA: 0x000F108C File Offset: 0x000EF28C
	// (set) Token: 0x06004251 RID: 16977 RVA: 0x000F1094 File Offset: 0x000EF294
	public global::dfButton.ButtonState State
	{
		get
		{
			return this.state;
		}
		set
		{
			if (value != this.state)
			{
				this.OnButtonStateChanged(value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C30 RID: 3120
	// (get) Token: 0x06004252 RID: 16978 RVA: 0x000F10B0 File Offset: 0x000EF2B0
	// (set) Token: 0x06004253 RID: 16979 RVA: 0x000F10B8 File Offset: 0x000EF2B8
	public string PressedSprite
	{
		get
		{
			return this.pressedSprite;
		}
		set
		{
			if (value != this.pressedSprite)
			{
				this.pressedSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C31 RID: 3121
	// (get) Token: 0x06004254 RID: 16980 RVA: 0x000F10D8 File Offset: 0x000EF2D8
	// (set) Token: 0x06004255 RID: 16981 RVA: 0x000F10E0 File Offset: 0x000EF2E0
	public global::dfControl ButtonGroup
	{
		get
		{
			return this.group;
		}
		set
		{
			if (value != this.group)
			{
				this.group = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C32 RID: 3122
	// (get) Token: 0x06004256 RID: 16982 RVA: 0x000F1100 File Offset: 0x000EF300
	// (set) Token: 0x06004257 RID: 16983 RVA: 0x000F1108 File Offset: 0x000EF308
	public bool AutoSize
	{
		get
		{
			return this.autoSize;
		}
		set
		{
			if (value != this.autoSize)
			{
				this.autoSize = value;
				if (value)
				{
					this.textAlign = 0;
				}
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C33 RID: 3123
	// (get) Token: 0x06004258 RID: 16984 RVA: 0x000F113C File Offset: 0x000EF33C
	// (set) Token: 0x06004259 RID: 16985 RVA: 0x000F1154 File Offset: 0x000EF354
	public global::UnityEngine.TextAlignment TextAlignment
	{
		get
		{
			if (this.autoSize)
			{
				return 0;
			}
			return this.textAlign;
		}
		set
		{
			if (value != this.textAlign)
			{
				this.textAlign = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C34 RID: 3124
	// (get) Token: 0x0600425A RID: 16986 RVA: 0x000F1170 File Offset: 0x000EF370
	// (set) Token: 0x0600425B RID: 16987 RVA: 0x000F1178 File Offset: 0x000EF378
	public global::dfVerticalAlignment VerticalAlignment
	{
		get
		{
			return this.vertAlign;
		}
		set
		{
			if (value != this.vertAlign)
			{
				this.vertAlign = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C35 RID: 3125
	// (get) Token: 0x0600425C RID: 16988 RVA: 0x000F1194 File Offset: 0x000EF394
	// (set) Token: 0x0600425D RID: 16989 RVA: 0x000F11B4 File Offset: 0x000EF3B4
	public global::UnityEngine.RectOffset Padding
	{
		get
		{
			if (this.padding == null)
			{
				this.padding = new global::UnityEngine.RectOffset();
			}
			return this.padding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.padding))
			{
				this.padding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C36 RID: 3126
	// (get) Token: 0x0600425E RID: 16990 RVA: 0x000F11E8 File Offset: 0x000EF3E8
	// (set) Token: 0x0600425F RID: 16991 RVA: 0x000F122C File Offset: 0x000EF42C
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
			}
			this.Invalidate();
		}
	}

	// Token: 0x17000C37 RID: 3127
	// (get) Token: 0x06004260 RID: 16992 RVA: 0x000F124C File Offset: 0x000EF44C
	// (set) Token: 0x06004261 RID: 16993 RVA: 0x000F1254 File Offset: 0x000EF454
	public string Text
	{
		get
		{
			return this.text;
		}
		set
		{
			if (value != this.text)
			{
				this.text = base.getLocalizedValue(value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C38 RID: 3128
	// (get) Token: 0x06004262 RID: 16994 RVA: 0x000F1288 File Offset: 0x000EF488
	// (set) Token: 0x06004263 RID: 16995 RVA: 0x000F1290 File Offset: 0x000EF490
	public global::UnityEngine.Color32 TextColor
	{
		get
		{
			return this.textColor;
		}
		set
		{
			this.textColor = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C39 RID: 3129
	// (get) Token: 0x06004264 RID: 16996 RVA: 0x000F12A0 File Offset: 0x000EF4A0
	// (set) Token: 0x06004265 RID: 16997 RVA: 0x000F12A8 File Offset: 0x000EF4A8
	public global::UnityEngine.Color32 HoverTextColor
	{
		get
		{
			return this.hoverText;
		}
		set
		{
			this.hoverText = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C3A RID: 3130
	// (get) Token: 0x06004266 RID: 16998 RVA: 0x000F12B8 File Offset: 0x000EF4B8
	// (set) Token: 0x06004267 RID: 16999 RVA: 0x000F12C0 File Offset: 0x000EF4C0
	public global::UnityEngine.Color32 HoverBackgroundColor
	{
		get
		{
			return this.hoverColor;
		}
		set
		{
			this.hoverColor = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C3B RID: 3131
	// (get) Token: 0x06004268 RID: 17000 RVA: 0x000F12D0 File Offset: 0x000EF4D0
	// (set) Token: 0x06004269 RID: 17001 RVA: 0x000F12D8 File Offset: 0x000EF4D8
	public global::UnityEngine.Color32 PressedTextColor
	{
		get
		{
			return this.pressedText;
		}
		set
		{
			this.pressedText = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C3C RID: 3132
	// (get) Token: 0x0600426A RID: 17002 RVA: 0x000F12E8 File Offset: 0x000EF4E8
	// (set) Token: 0x0600426B RID: 17003 RVA: 0x000F12F0 File Offset: 0x000EF4F0
	public global::UnityEngine.Color32 PressedBackgroundColor
	{
		get
		{
			return this.pressedColor;
		}
		set
		{
			this.pressedColor = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C3D RID: 3133
	// (get) Token: 0x0600426C RID: 17004 RVA: 0x000F1300 File Offset: 0x000EF500
	// (set) Token: 0x0600426D RID: 17005 RVA: 0x000F1308 File Offset: 0x000EF508
	public global::UnityEngine.Color32 FocusTextColor
	{
		get
		{
			return this.focusText;
		}
		set
		{
			this.focusText = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C3E RID: 3134
	// (get) Token: 0x0600426E RID: 17006 RVA: 0x000F1318 File Offset: 0x000EF518
	// (set) Token: 0x0600426F RID: 17007 RVA: 0x000F1320 File Offset: 0x000EF520
	public global::UnityEngine.Color32 FocusBackgroundColor
	{
		get
		{
			return this.focusColor;
		}
		set
		{
			this.focusColor = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C3F RID: 3135
	// (get) Token: 0x06004270 RID: 17008 RVA: 0x000F1330 File Offset: 0x000EF530
	// (set) Token: 0x06004271 RID: 17009 RVA: 0x000F1338 File Offset: 0x000EF538
	public global::UnityEngine.Color32 DisabledTextColor
	{
		get
		{
			return this.disabledText;
		}
		set
		{
			this.disabledText = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C40 RID: 3136
	// (get) Token: 0x06004272 RID: 17010 RVA: 0x000F1348 File Offset: 0x000EF548
	// (set) Token: 0x06004273 RID: 17011 RVA: 0x000F1350 File Offset: 0x000EF550
	public float TextScale
	{
		get
		{
			return this.textScale;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0.1f, value);
			if (!global::UnityEngine.Mathf.Approximately(this.textScale, value))
			{
				this.textScale = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C41 RID: 3137
	// (get) Token: 0x06004274 RID: 17012 RVA: 0x000F1380 File Offset: 0x000EF580
	// (set) Token: 0x06004275 RID: 17013 RVA: 0x000F1388 File Offset: 0x000EF588
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

	// Token: 0x17000C42 RID: 3138
	// (get) Token: 0x06004276 RID: 17014 RVA: 0x000F1398 File Offset: 0x000EF598
	// (set) Token: 0x06004277 RID: 17015 RVA: 0x000F13A0 File Offset: 0x000EF5A0
	public bool WordWrap
	{
		get
		{
			return this.wordWrap;
		}
		set
		{
			if (value != this.wordWrap)
			{
				this.wordWrap = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C43 RID: 3139
	// (get) Token: 0x06004278 RID: 17016 RVA: 0x000F13BC File Offset: 0x000EF5BC
	// (set) Token: 0x06004279 RID: 17017 RVA: 0x000F13C4 File Offset: 0x000EF5C4
	public bool Shadow
	{
		get
		{
			return this.textShadow;
		}
		set
		{
			if (value != this.textShadow)
			{
				this.textShadow = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C44 RID: 3140
	// (get) Token: 0x0600427A RID: 17018 RVA: 0x000F13E0 File Offset: 0x000EF5E0
	// (set) Token: 0x0600427B RID: 17019 RVA: 0x000F13E8 File Offset: 0x000EF5E8
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

	// Token: 0x17000C45 RID: 3141
	// (get) Token: 0x0600427C RID: 17020 RVA: 0x000F1420 File Offset: 0x000EF620
	// (set) Token: 0x0600427D RID: 17021 RVA: 0x000F1428 File Offset: 0x000EF628
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

	// Token: 0x0600427E RID: 17022 RVA: 0x000F1448 File Offset: 0x000EF648
	protected internal override void OnLocalize()
	{
		base.OnLocalize();
		this.Text = base.getLocalizedValue(this.text);
	}

	// Token: 0x0600427F RID: 17023 RVA: 0x000F1464 File Offset: 0x000EF664
	public override void Invalidate()
	{
		base.Invalidate();
		if (this.AutoSize)
		{
			this.autoSizeToText();
		}
	}

	// Token: 0x06004280 RID: 17024 RVA: 0x000F1480 File Offset: 0x000EF680
	public override void OnEnable()
	{
		base.OnEnable();
		bool flag = this.Font != null && this.Font.IsValid;
		if (global::UnityEngine.Application.isPlaying && !flag)
		{
			this.Font = base.GetManager().DefaultFont;
		}
	}

	// Token: 0x06004281 RID: 17025 RVA: 0x000F14D4 File Offset: 0x000EF6D4
	public override void Awake()
	{
		base.Awake();
		this.startSize = base.Size;
	}

	// Token: 0x06004282 RID: 17026 RVA: 0x000F14E8 File Offset: 0x000EF6E8
	public override void Update()
	{
		base.Update();
	}

	// Token: 0x06004283 RID: 17027 RVA: 0x000F14F0 File Offset: 0x000EF6F0
	protected internal override void OnEnterFocus(global::dfFocusEventArgs args)
	{
		if (this.State != global::dfButton.ButtonState.Pressed)
		{
			this.State = global::dfButton.ButtonState.Focus;
		}
		base.OnEnterFocus(args);
	}

	// Token: 0x06004284 RID: 17028 RVA: 0x000F150C File Offset: 0x000EF70C
	protected internal override void OnLeaveFocus(global::dfFocusEventArgs args)
	{
		this.State = global::dfButton.ButtonState.Default;
		base.OnLeaveFocus(args);
	}

	// Token: 0x06004285 RID: 17029 RVA: 0x000F151C File Offset: 0x000EF71C
	protected internal override void OnKeyPress(global::dfKeyEventArgs args)
	{
		if (this.IsInteractive && args.KeyCode == 0x20)
		{
			this.OnClick(new global::dfMouseEventArgs(this, global::dfMouseButtons.Left, 1, default(global::UnityEngine.Ray), global::UnityEngine.Vector2.zero, 0f));
			return;
		}
		base.OnKeyPress(args);
	}

	// Token: 0x06004286 RID: 17030 RVA: 0x000F156C File Offset: 0x000EF76C
	protected internal override void OnClick(global::dfMouseEventArgs args)
	{
		if (this.group != null)
		{
			foreach (global::dfButton dfButton in base.transform.parent.GetComponentsInChildren<global::dfButton>())
			{
				if (dfButton != this && dfButton.ButtonGroup == this.ButtonGroup && dfButton != this)
				{
					dfButton.State = global::dfButton.ButtonState.Default;
				}
			}
			if (!base.transform.IsChildOf(this.group.transform))
			{
				base.Signal(this.group.gameObject, "OnClick", new object[]
				{
					args
				});
			}
		}
		base.OnClick(args);
	}

	// Token: 0x06004287 RID: 17031 RVA: 0x000F162C File Offset: 0x000EF82C
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		if (!(this.parent is global::dfTabstrip) || this.State != global::dfButton.ButtonState.Focus)
		{
			this.State = global::dfButton.ButtonState.Pressed;
		}
		base.OnMouseDown(args);
	}

	// Token: 0x06004288 RID: 17032 RVA: 0x000F1664 File Offset: 0x000EF864
	protected internal override void OnMouseUp(global::dfMouseEventArgs args)
	{
		if (this.isMouseHovering)
		{
			if (this.parent is global::dfTabstrip && this.ContainsFocus)
			{
				this.State = global::dfButton.ButtonState.Focus;
			}
			else
			{
				this.State = global::dfButton.ButtonState.Hover;
			}
		}
		else if (this.HasFocus)
		{
			this.State = global::dfButton.ButtonState.Focus;
		}
		else
		{
			this.State = global::dfButton.ButtonState.Default;
		}
		base.OnMouseUp(args);
	}

	// Token: 0x06004289 RID: 17033 RVA: 0x000F16D4 File Offset: 0x000EF8D4
	protected internal override void OnMouseEnter(global::dfMouseEventArgs args)
	{
		if (!(this.parent is global::dfTabstrip) || this.State != global::dfButton.ButtonState.Focus)
		{
			this.State = global::dfButton.ButtonState.Hover;
		}
		base.OnMouseEnter(args);
	}

	// Token: 0x0600428A RID: 17034 RVA: 0x000F170C File Offset: 0x000EF90C
	protected internal override void OnMouseLeave(global::dfMouseEventArgs args)
	{
		if (this.ContainsFocus)
		{
			this.State = global::dfButton.ButtonState.Focus;
		}
		else
		{
			this.State = global::dfButton.ButtonState.Default;
		}
		base.OnMouseLeave(args);
	}

	// Token: 0x0600428B RID: 17035 RVA: 0x000F1740 File Offset: 0x000EF940
	protected internal override void OnIsEnabledChanged()
	{
		if (!base.IsEnabled)
		{
			this.State = global::dfButton.ButtonState.Disabled;
		}
		else
		{
			this.State = global::dfButton.ButtonState.Default;
		}
		base.OnIsEnabledChanged();
	}

	// Token: 0x0600428C RID: 17036 RVA: 0x000F1774 File Offset: 0x000EF974
	protected virtual void OnButtonStateChanged(global::dfButton.ButtonState value)
	{
		if (!this.isEnabled && value != global::dfButton.ButtonState.Disabled)
		{
			return;
		}
		this.state = value;
		base.Signal("OnButtonStateChanged", new object[]
		{
			value
		});
		if (this.ButtonStateChanged != null)
		{
			this.ButtonStateChanged(this, value);
		}
		this.Invalidate();
	}

	// Token: 0x0600428D RID: 17037 RVA: 0x000F17D4 File Offset: 0x000EF9D4
	protected override global::UnityEngine.Color32 getActiveColor()
	{
		switch (this.State)
		{
		case global::dfButton.ButtonState.Focus:
			return this.FocusBackgroundColor;
		case global::dfButton.ButtonState.Hover:
			return this.HoverBackgroundColor;
		case global::dfButton.ButtonState.Pressed:
			return this.PressedBackgroundColor;
		case global::dfButton.ButtonState.Disabled:
			return base.DisabledColor;
		default:
			return base.Color;
		}
	}

	// Token: 0x0600428E RID: 17038 RVA: 0x000F1828 File Offset: 0x000EFA28
	private void autoSizeToText()
	{
		if (this.Font == null || !this.Font.IsValid || string.IsNullOrEmpty(this.Text))
		{
			return;
		}
		using (global::dfFontRendererBase dfFontRendererBase = this.obtainTextRenderer())
		{
			global::UnityEngine.Vector2 vector = dfFontRendererBase.MeasureString(this.Text);
			global::UnityEngine.Vector2 size;
			size..ctor(vector.x + (float)this.padding.horizontal, vector.y + (float)this.padding.vertical);
			base.Size = size;
		}
	}

	// Token: 0x0600428F RID: 17039 RVA: 0x000F18E0 File Offset: 0x000EFAE0
	private global::dfRenderData renderText()
	{
		if (this.Font == null || !this.Font.IsValid || string.IsNullOrEmpty(this.Text))
		{
			return null;
		}
		global::dfRenderData renderData = this.renderData;
		if (this.font is global::dfDynamicFont)
		{
			global::dfDynamicFont dfDynamicFont = (global::dfDynamicFont)this.font;
			renderData = this.textRenderData;
			renderData.Clear();
			renderData.Material = dfDynamicFont.Material;
		}
		using (global::dfFontRendererBase dfFontRendererBase = this.obtainTextRenderer())
		{
			dfFontRendererBase.Render(this.text, renderData);
		}
		return renderData;
	}

	// Token: 0x06004290 RID: 17040 RVA: 0x000F19A0 File Offset: 0x000EFBA0
	private global::dfFontRendererBase obtainTextRenderer()
	{
		global::UnityEngine.Vector2 vector = base.Size - new global::UnityEngine.Vector2((float)this.padding.horizontal, (float)this.padding.vertical);
		global::UnityEngine.Vector2 maxSize = (!this.autoSize) ? vector : (global::UnityEngine.Vector2.one * 2.1474836E+09f);
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector3 vector2 = (this.pivot.TransformToUpperLeft(base.Size) + new global::UnityEngine.Vector3((float)this.padding.left, (float)(-(float)this.padding.top))) * num;
		float num2 = this.TextScale * this.getTextScaleMultiplier();
		global::UnityEngine.Color32 defaultColor = base.ApplyOpacity(this.getTextColorForState());
		global::dfFontRendererBase dfFontRendererBase = this.Font.ObtainRenderer();
		dfFontRendererBase.WordWrap = this.WordWrap;
		dfFontRendererBase.MultiLine = this.WordWrap;
		dfFontRendererBase.MaxSize = maxSize;
		dfFontRendererBase.PixelRatio = num;
		dfFontRendererBase.TextScale = num2;
		dfFontRendererBase.CharacterSpacing = 0;
		dfFontRendererBase.VectorOffset = vector2.Quantize(num);
		dfFontRendererBase.TabSize = 0;
		dfFontRendererBase.TextAlign = ((!this.autoSize) ? this.TextAlignment : 0);
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
		if (this.vertAlign != global::dfVerticalAlignment.Top)
		{
			dfFontRendererBase.VectorOffset = this.getVertAlignOffset(dfFontRendererBase);
		}
		return dfFontRendererBase;
	}

	// Token: 0x06004291 RID: 17041 RVA: 0x000F1B68 File Offset: 0x000EFD68
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
		if (this.autoSize)
		{
			return 1f;
		}
		return base.Size.y / this.startSize.y;
	}

	// Token: 0x06004292 RID: 17042 RVA: 0x000F1BDC File Offset: 0x000EFDDC
	private global::UnityEngine.Color32 getTextColorForState()
	{
		if (!base.IsEnabled)
		{
			return this.DisabledTextColor;
		}
		switch (this.state)
		{
		case global::dfButton.ButtonState.Default:
			return this.TextColor;
		case global::dfButton.ButtonState.Focus:
			return this.FocusTextColor;
		case global::dfButton.ButtonState.Hover:
			return this.HoverTextColor;
		case global::dfButton.ButtonState.Pressed:
			return this.PressedTextColor;
		case global::dfButton.ButtonState.Disabled:
			return this.DisabledTextColor;
		default:
			return global::UnityEngine.Color.white;
		}
	}

	// Token: 0x06004293 RID: 17043 RVA: 0x000F1C50 File Offset: 0x000EFE50
	private global::UnityEngine.Vector3 getVertAlignOffset(global::dfFontRendererBase textRenderer)
	{
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector2 vector = textRenderer.MeasureString(this.text) * num;
		global::UnityEngine.Vector3 vectorOffset = textRenderer.VectorOffset;
		float num2 = (base.Height - (float)this.padding.vertical) * num;
		if (vector.y >= num2)
		{
			return vectorOffset;
		}
		global::dfVerticalAlignment dfVerticalAlignment = this.vertAlign;
		if (dfVerticalAlignment != global::dfVerticalAlignment.Middle)
		{
			if (dfVerticalAlignment == global::dfVerticalAlignment.Bottom)
			{
				vectorOffset.y -= num2 - vector.y;
			}
		}
		else
		{
			vectorOffset.y -= (num2 - vector.y) * 0.5f;
		}
		return vectorOffset;
	}

	// Token: 0x06004294 RID: 17044 RVA: 0x000F1D00 File Offset: 0x000EFF00
	protected internal override global::dfAtlas.ItemInfo getBackgroundSprite()
	{
		if (base.Atlas == null)
		{
			return null;
		}
		global::dfAtlas.ItemInfo itemInfo = null;
		switch (this.state)
		{
		case global::dfButton.ButtonState.Default:
			itemInfo = this.atlas[this.backgroundSprite];
			break;
		case global::dfButton.ButtonState.Focus:
			itemInfo = this.atlas[this.focusSprite];
			break;
		case global::dfButton.ButtonState.Hover:
			itemInfo = this.atlas[this.hoverSprite];
			break;
		case global::dfButton.ButtonState.Pressed:
			itemInfo = this.atlas[this.pressedSprite];
			break;
		case global::dfButton.ButtonState.Disabled:
			itemInfo = this.atlas[this.disabledSprite];
			break;
		}
		if (itemInfo == null)
		{
			itemInfo = this.atlas[this.backgroundSprite];
		}
		return itemInfo;
	}

	// Token: 0x06004295 RID: 17045 RVA: 0x000F1DDC File Offset: 0x000EFFDC
	public global::dfList<global::dfRenderData> RenderMultiple()
	{
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
		this.isControlInvalidated = false;
		this.buffers.Clear();
		this.renderData.Clear();
		if (base.Atlas != null)
		{
			this.renderData.Material = base.Atlas.Material;
			this.renderData.Transform = base.transform.localToWorldMatrix;
			this.renderBackground();
			this.buffers.Add(this.renderData);
		}
		global::dfRenderData dfRenderData = this.renderText();
		if (dfRenderData != null && dfRenderData != this.renderData)
		{
			dfRenderData.Transform = base.transform.localToWorldMatrix;
			this.buffers.Add(dfRenderData);
		}
		this.updateCollider();
		return this.buffers;
	}

	// Token: 0x04002375 RID: 9077
	[global::UnityEngine.SerializeField]
	protected global::dfFontBase font;

	// Token: 0x04002376 RID: 9078
	[global::UnityEngine.SerializeField]
	protected string pressedSprite;

	// Token: 0x04002377 RID: 9079
	[global::UnityEngine.SerializeField]
	protected global::dfButton.ButtonState state;

	// Token: 0x04002378 RID: 9080
	[global::UnityEngine.SerializeField]
	protected global::dfControl group;

	// Token: 0x04002379 RID: 9081
	[global::UnityEngine.SerializeField]
	protected string text = string.Empty;

	// Token: 0x0400237A RID: 9082
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.TextAlignment textAlign = 1;

	// Token: 0x0400237B RID: 9083
	[global::UnityEngine.SerializeField]
	protected global::dfVerticalAlignment vertAlign = global::dfVerticalAlignment.Middle;

	// Token: 0x0400237C RID: 9084
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 textColor = global::UnityEngine.Color.white;

	// Token: 0x0400237D RID: 9085
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 hoverText = global::UnityEngine.Color.white;

	// Token: 0x0400237E RID: 9086
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 pressedText = global::UnityEngine.Color.white;

	// Token: 0x0400237F RID: 9087
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 focusText = global::UnityEngine.Color.white;

	// Token: 0x04002380 RID: 9088
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 disabledText = global::UnityEngine.Color.white;

	// Token: 0x04002381 RID: 9089
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 hoverColor = global::UnityEngine.Color.white;

	// Token: 0x04002382 RID: 9090
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 pressedColor = global::UnityEngine.Color.white;

	// Token: 0x04002383 RID: 9091
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 focusColor = global::UnityEngine.Color.white;

	// Token: 0x04002384 RID: 9092
	[global::UnityEngine.SerializeField]
	protected float textScale = 1f;

	// Token: 0x04002385 RID: 9093
	[global::UnityEngine.SerializeField]
	protected global::dfTextScaleMode textScaleMode;

	// Token: 0x04002386 RID: 9094
	[global::UnityEngine.SerializeField]
	protected bool wordWrap;

	// Token: 0x04002387 RID: 9095
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset padding = new global::UnityEngine.RectOffset();

	// Token: 0x04002388 RID: 9096
	[global::UnityEngine.SerializeField]
	protected bool textShadow;

	// Token: 0x04002389 RID: 9097
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 shadowColor = global::UnityEngine.Color.black;

	// Token: 0x0400238A RID: 9098
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 shadowOffset = new global::UnityEngine.Vector2(1f, -1f);

	// Token: 0x0400238B RID: 9099
	[global::UnityEngine.SerializeField]
	protected bool autoSize;

	// Token: 0x0400238C RID: 9100
	private global::UnityEngine.Vector2 startSize = global::UnityEngine.Vector2.zero;

	// Token: 0x0400238D RID: 9101
	private global::dfRenderData textRenderData;

	// Token: 0x0400238E RID: 9102
	private global::dfList<global::dfRenderData> buffers = global::dfList<global::dfRenderData>.Obtain();

	// Token: 0x0400238F RID: 9103
	private global::PropertyChangedEventHandler<global::dfButton.ButtonState> ButtonStateChanged;

	// Token: 0x020007D7 RID: 2007
	public enum ButtonState
	{
		// Token: 0x04002391 RID: 9105
		Default,
		// Token: 0x04002392 RID: 9106
		Focus,
		// Token: 0x04002393 RID: 9107
		Hover,
		// Token: 0x04002394 RID: 9108
		Pressed,
		// Token: 0x04002395 RID: 9109
		Disabled
	}
}
