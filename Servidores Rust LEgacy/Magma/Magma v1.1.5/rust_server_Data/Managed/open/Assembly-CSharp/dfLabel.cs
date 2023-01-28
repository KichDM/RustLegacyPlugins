using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200081B RID: 2075
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Label")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfLabel : global::dfControl, global::IDFMultiRender
{
	// Token: 0x060045C7 RID: 17863 RVA: 0x001000C0 File Offset: 0x000FE2C0
	public dfLabel()
	{
	}

	// Token: 0x1400004A RID: 74
	// (add) Token: 0x060045C8 RID: 17864 RVA: 0x00100188 File Offset: 0x000FE388
	// (remove) Token: 0x060045C9 RID: 17865 RVA: 0x001001A4 File Offset: 0x000FE3A4
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

	// Token: 0x17000CF4 RID: 3316
	// (get) Token: 0x060045CA RID: 17866 RVA: 0x001001C0 File Offset: 0x000FE3C0
	// (set) Token: 0x060045CB RID: 17867 RVA: 0x00100208 File Offset: 0x000FE408
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

	// Token: 0x17000CF5 RID: 3317
	// (get) Token: 0x060045CC RID: 17868 RVA: 0x00100228 File Offset: 0x000FE428
	// (set) Token: 0x060045CD RID: 17869 RVA: 0x0010026C File Offset: 0x000FE46C
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

	// Token: 0x17000CF6 RID: 3318
	// (get) Token: 0x060045CE RID: 17870 RVA: 0x0010028C File Offset: 0x000FE48C
	// (set) Token: 0x060045CF RID: 17871 RVA: 0x00100294 File Offset: 0x000FE494
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
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CF7 RID: 3319
	// (get) Token: 0x060045D0 RID: 17872 RVA: 0x001002B4 File Offset: 0x000FE4B4
	// (set) Token: 0x060045D1 RID: 17873 RVA: 0x001002BC File Offset: 0x000FE4BC
	public global::UnityEngine.Color32 BackgroundColor
	{
		get
		{
			return this.backgroundColor;
		}
		set
		{
			if (!object.Equals(value, this.backgroundColor))
			{
				this.backgroundColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CF8 RID: 3320
	// (get) Token: 0x060045D2 RID: 17874 RVA: 0x001002F4 File Offset: 0x000FE4F4
	// (set) Token: 0x060045D3 RID: 17875 RVA: 0x001002FC File Offset: 0x000FE4FC
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

	// Token: 0x17000CF9 RID: 3321
	// (get) Token: 0x060045D4 RID: 17876 RVA: 0x0010032C File Offset: 0x000FE52C
	// (set) Token: 0x060045D5 RID: 17877 RVA: 0x00100334 File Offset: 0x000FE534
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

	// Token: 0x17000CFA RID: 3322
	// (get) Token: 0x060045D6 RID: 17878 RVA: 0x00100344 File Offset: 0x000FE544
	// (set) Token: 0x060045D7 RID: 17879 RVA: 0x0010034C File Offset: 0x000FE54C
	public int CharacterSpacing
	{
		get
		{
			return this.charSpacing;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0, value);
			if (value != this.charSpacing)
			{
				this.charSpacing = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CFB RID: 3323
	// (get) Token: 0x060045D8 RID: 17880 RVA: 0x0010037C File Offset: 0x000FE57C
	// (set) Token: 0x060045D9 RID: 17881 RVA: 0x00100384 File Offset: 0x000FE584
	public bool ColorizeSymbols
	{
		get
		{
			return this.colorizeSymbols;
		}
		set
		{
			if (value != this.colorizeSymbols)
			{
				this.colorizeSymbols = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CFC RID: 3324
	// (get) Token: 0x060045DA RID: 17882 RVA: 0x001003A0 File Offset: 0x000FE5A0
	// (set) Token: 0x060045DB RID: 17883 RVA: 0x001003A8 File Offset: 0x000FE5A8
	public bool ProcessMarkup
	{
		get
		{
			return this.processMarkup;
		}
		set
		{
			if (value != this.processMarkup)
			{
				this.processMarkup = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CFD RID: 3325
	// (get) Token: 0x060045DC RID: 17884 RVA: 0x001003C4 File Offset: 0x000FE5C4
	// (set) Token: 0x060045DD RID: 17885 RVA: 0x001003CC File Offset: 0x000FE5CC
	public bool ShowGradient
	{
		get
		{
			return this.enableGradient;
		}
		set
		{
			if (value != this.enableGradient)
			{
				this.enableGradient = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CFE RID: 3326
	// (get) Token: 0x060045DE RID: 17886 RVA: 0x001003E8 File Offset: 0x000FE5E8
	// (set) Token: 0x060045DF RID: 17887 RVA: 0x001003F0 File Offset: 0x000FE5F0
	public global::UnityEngine.Color32 BottomColor
	{
		get
		{
			return this.bottomColor;
		}
		set
		{
			if (!this.bottomColor.Equals(value))
			{
				this.bottomColor = value;
				this.OnColorChanged();
			}
		}
	}

	// Token: 0x17000CFF RID: 3327
	// (get) Token: 0x060045E0 RID: 17888 RVA: 0x00100428 File Offset: 0x000FE628
	// (set) Token: 0x060045E1 RID: 17889 RVA: 0x00100430 File Offset: 0x000FE630
	public string Text
	{
		get
		{
			return this.text;
		}
		set
		{
			value = value.Replace("\\t", "\t").Replace("\\n", "\n");
			if (!string.Equals(value, this.text))
			{
				this.text = base.getLocalizedValue(value);
				this.OnTextChanged();
			}
		}
	}

	// Token: 0x17000D00 RID: 3328
	// (get) Token: 0x060045E2 RID: 17890 RVA: 0x00100484 File Offset: 0x000FE684
	// (set) Token: 0x060045E3 RID: 17891 RVA: 0x0010048C File Offset: 0x000FE68C
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
				if (value)
				{
					this.autoHeight = false;
				}
				this.autoSize = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D01 RID: 3329
	// (get) Token: 0x060045E4 RID: 17892 RVA: 0x001004C0 File Offset: 0x000FE6C0
	// (set) Token: 0x060045E5 RID: 17893 RVA: 0x001004DC File Offset: 0x000FE6DC
	public bool AutoHeight
	{
		get
		{
			return this.autoHeight && !this.autoSize;
		}
		set
		{
			if (value != this.autoHeight)
			{
				if (value)
				{
					this.autoSize = false;
				}
				this.autoHeight = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D02 RID: 3330
	// (get) Token: 0x060045E6 RID: 17894 RVA: 0x00100510 File Offset: 0x000FE710
	// (set) Token: 0x060045E7 RID: 17895 RVA: 0x00100518 File Offset: 0x000FE718
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

	// Token: 0x17000D03 RID: 3331
	// (get) Token: 0x060045E8 RID: 17896 RVA: 0x00100534 File Offset: 0x000FE734
	// (set) Token: 0x060045E9 RID: 17897 RVA: 0x0010053C File Offset: 0x000FE73C
	public global::UnityEngine.TextAlignment TextAlignment
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

	// Token: 0x17000D04 RID: 3332
	// (get) Token: 0x060045EA RID: 17898 RVA: 0x00100558 File Offset: 0x000FE758
	// (set) Token: 0x060045EB RID: 17899 RVA: 0x00100560 File Offset: 0x000FE760
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

	// Token: 0x17000D05 RID: 3333
	// (get) Token: 0x060045EC RID: 17900 RVA: 0x0010057C File Offset: 0x000FE77C
	// (set) Token: 0x060045ED RID: 17901 RVA: 0x00100584 File Offset: 0x000FE784
	public bool Outline
	{
		get
		{
			return this.outline;
		}
		set
		{
			if (value != this.outline)
			{
				this.outline = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D06 RID: 3334
	// (get) Token: 0x060045EE RID: 17902 RVA: 0x001005A0 File Offset: 0x000FE7A0
	// (set) Token: 0x060045EF RID: 17903 RVA: 0x001005A8 File Offset: 0x000FE7A8
	public int OutlineSize
	{
		get
		{
			return this.outlineWidth;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0, value);
			if (value != this.outlineWidth)
			{
				this.outlineWidth = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D07 RID: 3335
	// (get) Token: 0x060045F0 RID: 17904 RVA: 0x001005D8 File Offset: 0x000FE7D8
	// (set) Token: 0x060045F1 RID: 17905 RVA: 0x001005E0 File Offset: 0x000FE7E0
	public global::UnityEngine.Color32 OutlineColor
	{
		get
		{
			return this.outlineColor;
		}
		set
		{
			if (!value.Equals(this.outlineColor))
			{
				this.outlineColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D08 RID: 3336
	// (get) Token: 0x060045F2 RID: 17906 RVA: 0x00100618 File Offset: 0x000FE818
	// (set) Token: 0x060045F3 RID: 17907 RVA: 0x00100620 File Offset: 0x000FE820
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

	// Token: 0x17000D09 RID: 3337
	// (get) Token: 0x060045F4 RID: 17908 RVA: 0x0010063C File Offset: 0x000FE83C
	// (set) Token: 0x060045F5 RID: 17909 RVA: 0x00100644 File Offset: 0x000FE844
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

	// Token: 0x17000D0A RID: 3338
	// (get) Token: 0x060045F6 RID: 17910 RVA: 0x0010067C File Offset: 0x000FE87C
	// (set) Token: 0x060045F7 RID: 17911 RVA: 0x00100684 File Offset: 0x000FE884
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

	// Token: 0x17000D0B RID: 3339
	// (get) Token: 0x060045F8 RID: 17912 RVA: 0x001006A4 File Offset: 0x000FE8A4
	// (set) Token: 0x060045F9 RID: 17913 RVA: 0x001006C4 File Offset: 0x000FE8C4
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

	// Token: 0x17000D0C RID: 3340
	// (get) Token: 0x060045FA RID: 17914 RVA: 0x001006F8 File Offset: 0x000FE8F8
	// (set) Token: 0x060045FB RID: 17915 RVA: 0x00100700 File Offset: 0x000FE900
	public int TabSize
	{
		get
		{
			return this.tabSize;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0, value);
			if (value != this.tabSize)
			{
				this.tabSize = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D0D RID: 3341
	// (get) Token: 0x060045FC RID: 17916 RVA: 0x00100730 File Offset: 0x000FE930
	public global::System.Collections.Generic.List<int> TabStops
	{
		get
		{
			return this.tabStops;
		}
	}

	// Token: 0x060045FD RID: 17917 RVA: 0x00100738 File Offset: 0x000FE938
	protected internal override void OnLocalize()
	{
		base.OnLocalize();
		this.Text = base.getLocalizedValue(this.text);
	}

	// Token: 0x060045FE RID: 17918 RVA: 0x00100754 File Offset: 0x000FE954
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

	// Token: 0x060045FF RID: 17919 RVA: 0x001007A0 File Offset: 0x000FE9A0
	public override void OnEnable()
	{
		base.OnEnable();
		bool flag = this.Font != null && this.Font.IsValid;
		if (global::UnityEngine.Application.isPlaying && !flag)
		{
			this.Font = base.GetManager().DefaultFont;
		}
		if (this.size.sqrMagnitude <= 1E-45f)
		{
			base.Size = new global::UnityEngine.Vector2(150f, 25f);
		}
	}

	// Token: 0x06004600 RID: 17920 RVA: 0x00100820 File Offset: 0x000FEA20
	public override void Update()
	{
		if (this.autoSize)
		{
			this.autoHeight = false;
		}
		if (this.Font == null)
		{
			this.Font = base.GetManager().DefaultFont;
		}
		base.Update();
	}

	// Token: 0x06004601 RID: 17921 RVA: 0x00100868 File Offset: 0x000FEA68
	public override void Awake()
	{
		base.Awake();
		this.startSize = ((!global::UnityEngine.Application.isPlaying) ? global::UnityEngine.Vector2.zero : base.Size);
	}

	// Token: 0x06004602 RID: 17922 RVA: 0x0010089C File Offset: 0x000FEA9C
	public override global::UnityEngine.Vector2 CalculateMinimumSize()
	{
		if (this.Font != null)
		{
			float num = (float)this.Font.FontSize * this.TextScale * 0.75f;
			return global::UnityEngine.Vector2.Max(base.CalculateMinimumSize(), new global::UnityEngine.Vector2(num, num));
		}
		return base.CalculateMinimumSize();
	}

	// Token: 0x06004603 RID: 17923 RVA: 0x001008F0 File Offset: 0x000FEAF0
	public override void Invalidate()
	{
		base.Invalidate();
		if (this.Font == null || !this.Font.IsValid)
		{
			return;
		}
		bool flag = this.size.sqrMagnitude <= float.Epsilon;
		if (!this.autoSize && !this.autoHeight && !flag)
		{
			return;
		}
		if (string.IsNullOrEmpty(this.Text))
		{
			if (flag)
			{
				base.Size = new global::UnityEngine.Vector2(150f, 24f);
			}
			if (this.AutoSize || this.AutoHeight)
			{
				base.Height = (float)global::UnityEngine.Mathf.CeilToInt((float)this.Font.LineHeight * this.TextScale);
			}
			return;
		}
		using (global::dfFontRendererBase dfFontRendererBase = this.obtainRenderer())
		{
			global::UnityEngine.Vector2 vector = dfFontRendererBase.MeasureString(this.text).RoundToInt();
			if (this.AutoSize || flag)
			{
				this.size = vector + new global::UnityEngine.Vector2((float)this.padding.horizontal, (float)this.padding.vertical);
			}
			else if (this.AutoHeight)
			{
				this.size = new global::UnityEngine.Vector2(this.size.x, vector.y + (float)this.padding.vertical);
			}
		}
	}

	// Token: 0x06004604 RID: 17924 RVA: 0x00100A74 File Offset: 0x000FEC74
	private global::dfFontRendererBase obtainRenderer()
	{
		bool flag = base.Size.sqrMagnitude <= float.Epsilon;
		global::UnityEngine.Vector2 vector = base.Size - new global::UnityEngine.Vector2((float)this.padding.horizontal, (float)this.padding.vertical);
		global::UnityEngine.Vector2 maxSize = (!this.autoSize && !flag) ? vector : this.getAutoSizeDefault();
		if (this.autoHeight)
		{
			maxSize..ctor(vector.x, 2.1474836E+09f);
		}
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector3 vector2 = (this.pivot.TransformToUpperLeft(base.Size) + new global::UnityEngine.Vector3((float)this.padding.left, (float)(-(float)this.padding.top))) * num;
		float num2 = this.TextScale * this.getTextScaleMultiplier();
		global::dfFontRendererBase dfFontRendererBase = this.Font.ObtainRenderer();
		dfFontRendererBase.WordWrap = this.WordWrap;
		dfFontRendererBase.MaxSize = maxSize;
		dfFontRendererBase.PixelRatio = num;
		dfFontRendererBase.TextScale = num2;
		dfFontRendererBase.CharacterSpacing = this.CharacterSpacing;
		dfFontRendererBase.VectorOffset = vector2.Quantize(num);
		dfFontRendererBase.MultiLine = true;
		dfFontRendererBase.TabSize = this.TabSize;
		dfFontRendererBase.TabStops = this.TabStops;
		dfFontRendererBase.TextAlign = ((!this.autoSize) ? this.TextAlignment : 0);
		dfFontRendererBase.ColorizeSymbols = this.ColorizeSymbols;
		dfFontRendererBase.ProcessMarkup = this.ProcessMarkup;
		dfFontRendererBase.DefaultColor = ((!base.IsEnabled) ? base.DisabledColor : base.Color);
		dfFontRendererBase.BottomColor = ((!this.enableGradient) ? null : new global::UnityEngine.Color32?(this.BottomColor));
		dfFontRendererBase.OverrideMarkupColors = !base.IsEnabled;
		dfFontRendererBase.Opacity = base.CalculateOpacity();
		dfFontRendererBase.Outline = this.Outline;
		dfFontRendererBase.OutlineSize = this.OutlineSize;
		dfFontRendererBase.OutlineColor = this.OutlineColor;
		dfFontRendererBase.Shadow = this.Shadow;
		dfFontRendererBase.ShadowColor = this.ShadowColor;
		dfFontRendererBase.ShadowOffset = this.ShadowOffset;
		global::dfDynamicFont.DynamicFontRenderer dynamicFontRenderer = dfFontRendererBase as global::dfDynamicFont.DynamicFontRenderer;
		if (dynamicFontRenderer != null)
		{
			dynamicFontRenderer.SpriteAtlas = this.Atlas;
			dynamicFontRenderer.SpriteBuffer = this.renderData;
		}
		if (this.vertAlign != global::dfVerticalAlignment.Top)
		{
			dfFontRendererBase.VectorOffset = this.getVertAlignOffset(dfFontRendererBase);
		}
		return dfFontRendererBase;
	}

	// Token: 0x06004605 RID: 17925 RVA: 0x00100CFC File Offset: 0x000FEEFC
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

	// Token: 0x06004606 RID: 17926 RVA: 0x00100D70 File Offset: 0x000FEF70
	private global::UnityEngine.Vector2 getAutoSizeDefault()
	{
		float num = (this.maxSize.x <= float.Epsilon) ? 2.1474836E+09f : this.maxSize.x;
		float num2 = (this.maxSize.y <= float.Epsilon) ? 2.1474836E+09f : this.maxSize.y;
		global::UnityEngine.Vector2 result;
		result..ctor(num, num2);
		return result;
	}

	// Token: 0x06004607 RID: 17927 RVA: 0x00100DE0 File Offset: 0x000FEFE0
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

	// Token: 0x06004608 RID: 17928 RVA: 0x00100E90 File Offset: 0x000FF090
	protected internal virtual void renderBackground()
	{
		if (this.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[this.backgroundSprite];
		if (itemInfo == null)
		{
			return;
		}
		global::UnityEngine.Color32 color = base.ApplyOpacity(this.BackgroundColor);
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

	// Token: 0x06004609 RID: 17929 RVA: 0x00100F80 File Offset: 0x000FF180
	public global::dfList<global::dfRenderData> RenderMultiple()
	{
		global::dfList<global::dfRenderData> result;
		try
		{
			if (this.Atlas == null || this.Font == null || !this.isVisible || !this.Font.IsValid)
			{
				result = null;
			}
			else
			{
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
					result = this.buffers;
				}
				else
				{
					this.buffers.Clear();
					this.renderData.Clear();
					this.renderData.Material = this.Atlas.Material;
					this.renderData.Transform = base.transform.localToWorldMatrix;
					this.buffers.Add(this.renderData);
					this.textRenderData.Clear();
					this.textRenderData.Material = this.Atlas.Material;
					this.textRenderData.Transform = base.transform.localToWorldMatrix;
					this.buffers.Add(this.textRenderData);
					this.renderBackground();
					if (string.IsNullOrEmpty(this.Text))
					{
						if (this.AutoSize || this.AutoHeight)
						{
							base.Height = (float)global::UnityEngine.Mathf.CeilToInt((float)this.Font.LineHeight * this.TextScale);
						}
						result = this.buffers;
					}
					else
					{
						bool flag = this.size.sqrMagnitude <= float.Epsilon;
						using (global::dfFontRendererBase dfFontRendererBase = this.obtainRenderer())
						{
							dfFontRendererBase.Render(this.text, this.textRenderData);
							if (this.AutoSize || flag)
							{
								base.Size = (dfFontRendererBase.RenderedSize + new global::UnityEngine.Vector2((float)this.padding.horizontal, (float)this.padding.vertical)).CeilToInt();
							}
							else if (this.AutoHeight)
							{
								base.Size = new global::UnityEngine.Vector2(this.size.x, dfFontRendererBase.RenderedSize.y + (float)this.padding.vertical).CeilToInt();
							}
						}
						this.updateCollider();
						result = this.buffers;
					}
				}
			}
		}
		finally
		{
			this.isControlInvalidated = false;
		}
		return result;
	}

	// Token: 0x04002526 RID: 9510
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002527 RID: 9511
	[global::UnityEngine.SerializeField]
	protected global::dfFontBase font;

	// Token: 0x04002528 RID: 9512
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x04002529 RID: 9513
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 backgroundColor = global::UnityEngine.Color.white;

	// Token: 0x0400252A RID: 9514
	[global::UnityEngine.SerializeField]
	protected bool autoSize;

	// Token: 0x0400252B RID: 9515
	[global::UnityEngine.SerializeField]
	protected bool autoHeight;

	// Token: 0x0400252C RID: 9516
	[global::UnityEngine.SerializeField]
	protected bool wordWrap;

	// Token: 0x0400252D RID: 9517
	[global::UnityEngine.SerializeField]
	protected string text = "Label";

	// Token: 0x0400252E RID: 9518
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 bottomColor = new global::UnityEngine.Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x0400252F RID: 9519
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.TextAlignment align;

	// Token: 0x04002530 RID: 9520
	[global::UnityEngine.SerializeField]
	protected global::dfVerticalAlignment vertAlign;

	// Token: 0x04002531 RID: 9521
	[global::UnityEngine.SerializeField]
	protected float textScale = 1f;

	// Token: 0x04002532 RID: 9522
	[global::UnityEngine.SerializeField]
	protected global::dfTextScaleMode textScaleMode;

	// Token: 0x04002533 RID: 9523
	[global::UnityEngine.SerializeField]
	protected int charSpacing;

	// Token: 0x04002534 RID: 9524
	[global::UnityEngine.SerializeField]
	protected bool colorizeSymbols;

	// Token: 0x04002535 RID: 9525
	[global::UnityEngine.SerializeField]
	protected bool processMarkup;

	// Token: 0x04002536 RID: 9526
	[global::UnityEngine.SerializeField]
	protected bool outline;

	// Token: 0x04002537 RID: 9527
	[global::UnityEngine.SerializeField]
	protected int outlineWidth = 1;

	// Token: 0x04002538 RID: 9528
	[global::UnityEngine.SerializeField]
	protected bool enableGradient;

	// Token: 0x04002539 RID: 9529
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 outlineColor = global::UnityEngine.Color.black;

	// Token: 0x0400253A RID: 9530
	[global::UnityEngine.SerializeField]
	protected bool shadow;

	// Token: 0x0400253B RID: 9531
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 shadowColor = global::UnityEngine.Color.black;

	// Token: 0x0400253C RID: 9532
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 shadowOffset = new global::UnityEngine.Vector2(1f, -1f);

	// Token: 0x0400253D RID: 9533
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset padding = new global::UnityEngine.RectOffset();

	// Token: 0x0400253E RID: 9534
	[global::UnityEngine.SerializeField]
	protected int tabSize = 0x30;

	// Token: 0x0400253F RID: 9535
	[global::UnityEngine.SerializeField]
	protected global::System.Collections.Generic.List<int> tabStops = new global::System.Collections.Generic.List<int>();

	// Token: 0x04002540 RID: 9536
	private global::UnityEngine.Vector2 startSize = global::UnityEngine.Vector2.zero;

	// Token: 0x04002541 RID: 9537
	private global::dfRenderData textRenderData;

	// Token: 0x04002542 RID: 9538
	private global::dfList<global::dfRenderData> buffers = global::dfList<global::dfRenderData>.Obtain();

	// Token: 0x04002543 RID: 9539
	private global::PropertyChangedEventHandler<string> TextChanged;
}
