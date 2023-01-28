using System;
using System.Collections.Generic;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x02000956 RID: 2390
[global::UnityEngine.AddComponentMenu("NGUI/UI/Label")]
[global::UnityEngine.ExecuteInEditMode]
public class UILabel : global::UIWidget
{
	// Token: 0x06005136 RID: 20790 RVA: 0x00141020 File Offset: 0x0013F220
	public UILabel() : base(global::UIWidget.WidgetFlags.CustomRelativeSize | global::UIWidget.WidgetFlags.CustomMaterialGet)
	{
	}

	// Token: 0x17000F17 RID: 3863
	// (get) Token: 0x06005137 RID: 20791 RVA: 0x001410CC File Offset: 0x0013F2CC
	private global::System.Collections.Generic.List<global::UITextMarkup> markups
	{
		get
		{
			global::System.Collections.Generic.List<global::UITextMarkup> result;
			if ((result = this._markups) == null)
			{
				result = (this._markups = new global::System.Collections.Generic.List<global::UITextMarkup>());
			}
			return result;
		}
	}

	// Token: 0x17000F18 RID: 3864
	// (get) Token: 0x06005138 RID: 20792 RVA: 0x001410F4 File Offset: 0x0013F2F4
	// (set) Token: 0x06005139 RID: 20793 RVA: 0x001410FC File Offset: 0x0013F2FC
	public bool invisibleHack
	{
		get
		{
			return this.mInvisibleHack;
		}
		set
		{
			if (this.mInvisibleHack != value)
			{
				this.mInvisibleHack = value;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x0600513A RID: 20794 RVA: 0x00141118 File Offset: 0x0013F318
	private bool PendingChanges()
	{
		return this.mShouldBeProcessed || this.mLastText != this.text || this.mInvisibleHack != this.mLastInvisibleHack || this.mLastWidth != this.mMaxLineWidth || this.mLastEncoding != this.mEncoding || this.mLastCount != this.mMaxLineCount || this.mLastPass != this.mPassword || this.mLastShow != this.mShowLastChar || this.mLastEffect != this.mEffectStyle || this.mLastColor != this.mEffectColor;
	}

	// Token: 0x0600513B RID: 20795 RVA: 0x001411D4 File Offset: 0x0013F3D4
	private void ApplyChanges()
	{
		this.mShouldBeProcessed = false;
		this.mLastText = this.text;
		this.mLastInvisibleHack = this.mInvisibleHack;
		this.mLastWidth = this.mMaxLineWidth;
		this.mLastEncoding = this.mEncoding;
		this.mLastCount = this.mMaxLineCount;
		this.mLastPass = this.mPassword;
		this.mLastShow = this.mShowLastChar;
		this.mLastEffect = this.mEffectStyle;
		this.mLastColor = this.mEffectColor;
	}

	// Token: 0x0600513C RID: 20796 RVA: 0x00141254 File Offset: 0x0013F454
	private void ForceChanges()
	{
		base.ChangedAuto();
		this.mShouldBeProcessed = true;
	}

	// Token: 0x17000F19 RID: 3865
	// (get) Token: 0x0600513D RID: 20797 RVA: 0x00141264 File Offset: 0x0013F464
	// (set) Token: 0x0600513E RID: 20798 RVA: 0x0014126C File Offset: 0x0013F46C
	public global::UIFont font
	{
		get
		{
			return this.mFont;
		}
		set
		{
			if (this.mFont != value)
			{
				this.mFont = value;
				base.baseMaterial = ((!(this.mFont != null)) ? null : ((global::UIMaterial)this.mFont.material));
				base.ChangedAuto();
				this.ForceChanges();
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000F1A RID: 3866
	// (get) Token: 0x0600513F RID: 20799 RVA: 0x001412D0 File Offset: 0x0013F4D0
	// (set) Token: 0x06005140 RID: 20800 RVA: 0x001412D8 File Offset: 0x0013F4D8
	public string text
	{
		get
		{
			return this.mText;
		}
		set
		{
			if (value != null && this.mText != value)
			{
				this.mText = value;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F1B RID: 3867
	// (get) Token: 0x06005141 RID: 20801 RVA: 0x0014130C File Offset: 0x0013F50C
	// (set) Token: 0x06005142 RID: 20802 RVA: 0x00141314 File Offset: 0x0013F514
	public bool supportEncoding
	{
		get
		{
			return this.mEncoding;
		}
		set
		{
			if (this.mEncoding != value)
			{
				this.mEncoding = value;
				this.ForceChanges();
				if (value)
				{
					this.mPassword = false;
				}
			}
		}
	}

	// Token: 0x17000F1C RID: 3868
	// (get) Token: 0x06005143 RID: 20803 RVA: 0x00141348 File Offset: 0x0013F548
	// (set) Token: 0x06005144 RID: 20804 RVA: 0x00141350 File Offset: 0x0013F550
	public bool overflowRight
	{
		get
		{
			return this.mOverflowRight;
		}
		set
		{
			if (this.mOverflowRight != value)
			{
				this.mOverflowRight = value;
				global::UIWidget.Pivot pivot = base.pivot;
				switch (pivot)
				{
				case global::UIWidget.Pivot.TopLeft:
				case global::UIWidget.Pivot.Left:
					break;
				default:
					if (pivot != global::UIWidget.Pivot.BottomLeft)
					{
						return;
					}
					break;
				}
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F1D RID: 3869
	// (get) Token: 0x06005145 RID: 20805 RVA: 0x001413A4 File Offset: 0x0013F5A4
	// (set) Token: 0x06005146 RID: 20806 RVA: 0x001413AC File Offset: 0x0013F5AC
	public global::UIFont.SymbolStyle symbolStyle
	{
		get
		{
			return this.mSymbols;
		}
		set
		{
			if (this.mSymbols != value)
			{
				this.mSymbols = value;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F1E RID: 3870
	// (get) Token: 0x06005147 RID: 20807 RVA: 0x001413C8 File Offset: 0x0013F5C8
	// (set) Token: 0x06005148 RID: 20808 RVA: 0x001413D0 File Offset: 0x0013F5D0
	public int lineWidth
	{
		get
		{
			return this.mMaxLineWidth;
		}
		set
		{
			if (this.mMaxLineWidth != value)
			{
				this.mMaxLineWidth = value;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F1F RID: 3871
	// (get) Token: 0x06005149 RID: 20809 RVA: 0x001413EC File Offset: 0x0013F5EC
	// (set) Token: 0x0600514A RID: 20810 RVA: 0x001413FC File Offset: 0x0013F5FC
	public bool multiLine
	{
		get
		{
			return this.mMaxLineCount != 1;
		}
		set
		{
			if (this.mMaxLineCount != 1 != value)
			{
				this.mMaxLineCount = ((!value) ? 1 : 0);
				this.ForceChanges();
				if (value)
				{
					this.mPassword = false;
				}
			}
		}
	}

	// Token: 0x17000F20 RID: 3872
	// (get) Token: 0x0600514B RID: 20811 RVA: 0x00141444 File Offset: 0x0013F644
	// (set) Token: 0x0600514C RID: 20812 RVA: 0x0014144C File Offset: 0x0013F64C
	public int maxLineCount
	{
		get
		{
			return this.mMaxLineCount;
		}
		set
		{
			if (this.mMaxLineCount != value)
			{
				this.mMaxLineCount = global::UnityEngine.Mathf.Max(value, 0);
				this.ForceChanges();
				if (value == 1)
				{
					this.mPassword = false;
				}
			}
		}
	}

	// Token: 0x17000F21 RID: 3873
	// (get) Token: 0x0600514D RID: 20813 RVA: 0x0014147C File Offset: 0x0013F67C
	// (set) Token: 0x0600514E RID: 20814 RVA: 0x00141484 File Offset: 0x0013F684
	public bool password
	{
		get
		{
			return this.mPassword;
		}
		set
		{
			if (this.mPassword != value)
			{
				this.mPassword = value;
				this.mMaxLineCount = 1;
				this.mEncoding = false;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F22 RID: 3874
	// (get) Token: 0x0600514F RID: 20815 RVA: 0x001414B0 File Offset: 0x0013F6B0
	// (set) Token: 0x06005150 RID: 20816 RVA: 0x001414B8 File Offset: 0x0013F6B8
	public bool showLastPasswordChar
	{
		get
		{
			return this.mShowLastChar;
		}
		set
		{
			if (this.mShowLastChar != value)
			{
				this.mShowLastChar = value;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F23 RID: 3875
	// (get) Token: 0x06005151 RID: 20817 RVA: 0x001414D4 File Offset: 0x0013F6D4
	// (set) Token: 0x06005152 RID: 20818 RVA: 0x001414DC File Offset: 0x0013F6DC
	public global::UILabel.Effect effectStyle
	{
		get
		{
			return this.mEffectStyle;
		}
		set
		{
			if (this.mEffectStyle != value)
			{
				this.mEffectStyle = value;
				this.ForceChanges();
			}
		}
	}

	// Token: 0x17000F24 RID: 3876
	// (get) Token: 0x06005153 RID: 20819 RVA: 0x001414F8 File Offset: 0x0013F6F8
	// (set) Token: 0x06005154 RID: 20820 RVA: 0x00141500 File Offset: 0x0013F700
	public global::UnityEngine.Color effectColor
	{
		get
		{
			return this.mEffectColor;
		}
		set
		{
			if (this.mEffectColor != value)
			{
				this.mEffectColor = value;
				if (this.mEffectStyle != global::UILabel.Effect.None)
				{
					this.ForceChanges();
				}
			}
		}
	}

	// Token: 0x17000F25 RID: 3877
	// (get) Token: 0x06005155 RID: 20821 RVA: 0x0014152C File Offset: 0x0013F72C
	public string processedText
	{
		get
		{
			if (this.mLastScale != base.cachedTransform.localScale)
			{
				this.mLastScale = base.cachedTransform.localScale;
				this.mShouldBeProcessed = true;
			}
			if (this.PendingChanges())
			{
				this.ProcessText();
			}
			return this.mProcessedText;
		}
	}

	// Token: 0x17000F26 RID: 3878
	// (get) Token: 0x06005156 RID: 20822 RVA: 0x00141584 File Offset: 0x0013F784
	// (set) Token: 0x06005157 RID: 20823 RVA: 0x0014158C File Offset: 0x0013F78C
	public global::UnityEngine.Color highlightTextColor
	{
		get
		{
			return this.mHighlightTextColor;
		}
		set
		{
			if (this.mHighlightTextColor != value)
			{
				bool flag = (this.hasSelection && this.mHighlightColor.a > 0f) || value.a > 0f;
				this.mHighlightTextColor = value;
				if (flag)
				{
					this.ForceChanges();
				}
			}
		}
	}

	// Token: 0x17000F27 RID: 3879
	// (get) Token: 0x06005158 RID: 20824 RVA: 0x001415F0 File Offset: 0x0013F7F0
	// (set) Token: 0x06005159 RID: 20825 RVA: 0x001415F8 File Offset: 0x0013F7F8
	public global::UnityEngine.Color highlightColor
	{
		get
		{
			return this.mHighlightColor;
		}
		set
		{
			if (this.mHighlightColor != value)
			{
				bool flag = (this.hasSelection && this.mHighlightChar != '\0' && this.mHighlightColor.a > 0f) || value.a > 0f;
				this.mHighlightColor = value;
				if (flag)
				{
					this.ForceChanges();
				}
			}
		}
	}

	// Token: 0x17000F28 RID: 3880
	// (get) Token: 0x0600515A RID: 20826 RVA: 0x00141668 File Offset: 0x0013F868
	// (set) Token: 0x0600515B RID: 20827 RVA: 0x00141670 File Offset: 0x0013F870
	public char highlightChar
	{
		get
		{
			return this.mHighlightChar;
		}
		set
		{
			if (this.mHighlightChar != value)
			{
				bool flag = this.hasSelection && this.mHighlightColor.a > 0f;
				this.mHighlightChar = value;
				if (flag)
				{
					this.ForceChanges();
				}
			}
		}
	}

	// Token: 0x17000F29 RID: 3881
	// (get) Token: 0x0600515C RID: 20828 RVA: 0x001416C0 File Offset: 0x0013F8C0
	// (set) Token: 0x0600515D RID: 20829 RVA: 0x001416C8 File Offset: 0x0013F8C8
	public float highlightCharSplit
	{
		get
		{
			return this.mHighlightCharSplit;
		}
		set
		{
			if (value > 1f)
			{
				value = 1f;
			}
			else if (value < 0f)
			{
				value = 0f;
			}
			if (this.mHighlightCharSplit != value)
			{
				bool flag = this.hasSelection && this.mHighlightColor.a > 0f && this.mHighlightChar != '\0';
				this.mHighlightCharSplit = value;
				if (flag)
				{
					this.ForceChanges();
				}
			}
		}
	}

	// Token: 0x17000F2A RID: 3882
	// (get) Token: 0x0600515E RID: 20830 RVA: 0x00141750 File Offset: 0x0013F950
	// (set) Token: 0x0600515F RID: 20831 RVA: 0x00141758 File Offset: 0x0013F958
	public char carratChar
	{
		get
		{
			return this.mCarratChar;
		}
		set
		{
			if (this.mCarratChar != value)
			{
				bool shouldShowCarrat = this.shouldShowCarrat;
				this.mCarratChar = value;
				if (shouldShowCarrat)
				{
					this.ForceChanges();
				}
			}
		}
	}

	// Token: 0x17000F2B RID: 3883
	// (get) Token: 0x06005160 RID: 20832 RVA: 0x0014178C File Offset: 0x0013F98C
	public bool hasSelection
	{
		get
		{
			return this.mSelection.hasSelection;
		}
	}

	// Token: 0x17000F2C RID: 3884
	// (get) Token: 0x06005161 RID: 20833 RVA: 0x0014179C File Offset: 0x0013F99C
	public bool shouldShowCarrat
	{
		get
		{
			return this.mSelection.showCarrat;
		}
	}

	// Token: 0x17000F2D RID: 3885
	// (get) Token: 0x06005162 RID: 20834 RVA: 0x001417AC File Offset: 0x0013F9AC
	public bool drawingCarrat
	{
		get
		{
			return this.mCarratChar != '\0' && this.mSelection.showCarrat;
		}
	}

	// Token: 0x17000F2E RID: 3886
	// (get) Token: 0x06005163 RID: 20835 RVA: 0x001417C8 File Offset: 0x0013F9C8
	public global::UITextPosition carratPosition
	{
		get
		{
			return this.mSelection.carratPos;
		}
	}

	// Token: 0x17000F2F RID: 3887
	// (get) Token: 0x06005164 RID: 20836 RVA: 0x001417D8 File Offset: 0x0013F9D8
	public global::UITextPosition selectPosition
	{
		get
		{
			return this.mSelection.selectPos;
		}
	}

	// Token: 0x17000F30 RID: 3888
	// (get) Token: 0x06005165 RID: 20837 RVA: 0x001417E8 File Offset: 0x0013F9E8
	private bool highlightWouldBeVisibleIfOn
	{
		get
		{
			return (this.mHighlightChar != '\0' && this.mHighlightColor.a > 0f) || this.mHighlightTextColor != base.color;
		}
	}

	// Token: 0x17000F31 RID: 3889
	// (get) Token: 0x06005166 RID: 20838 RVA: 0x0014182C File Offset: 0x0013FA2C
	private bool carratWouldBeVisibleIfOn
	{
		get
		{
			return this.mCarratChar != '\0';
		}
	}

	// Token: 0x17000F32 RID: 3890
	// (get) Token: 0x06005167 RID: 20839 RVA: 0x0014183C File Offset: 0x0013FA3C
	// (set) Token: 0x06005168 RID: 20840 RVA: 0x00141844 File Offset: 0x0013FA44
	public global::UITextSelection selection
	{
		get
		{
			return this.mSelection;
		}
		set
		{
			global::UITextSelection.Change changesTo = this.mSelection.GetChangesTo(ref value);
			this.mSelection = value;
			switch (changesTo)
			{
			case global::UITextSelection.Change.NoneToCarrat:
			case global::UITextSelection.Change.CarratMove:
			case global::UITextSelection.Change.CarratToNone:
				if (this.carratWouldBeVisibleIfOn)
				{
					this.ForceChanges();
				}
				break;
			case global::UITextSelection.Change.CarratToSelection:
			case global::UITextSelection.Change.SelectionToCarrat:
				if (this.carratWouldBeVisibleIfOn || this.highlightWouldBeVisibleIfOn)
				{
					this.ForceChanges();
				}
				break;
			case global::UITextSelection.Change.SelectionAdjusted:
			case global::UITextSelection.Change.NoneToSelection:
			case global::UITextSelection.Change.SelectionToNone:
				if (this.highlightWouldBeVisibleIfOn)
				{
					this.ForceChanges();
				}
				break;
			}
		}
	}

	// Token: 0x17000F33 RID: 3891
	// (get) Token: 0x06005169 RID: 20841 RVA: 0x001418EC File Offset: 0x0013FAEC
	// (set) Token: 0x0600516A RID: 20842 RVA: 0x0014193C File Offset: 0x0013FB3C
	public new global::UIMaterial material
	{
		get
		{
			global::UIMaterial uimaterial = base.baseMaterial;
			if (uimaterial == null)
			{
				uimaterial = ((!(this.mFont != null)) ? null : ((global::UIMaterial)this.mFont.material));
				this.material = uimaterial;
			}
			return uimaterial;
		}
		set
		{
			base.material = value;
		}
	}

	// Token: 0x17000F34 RID: 3892
	// (get) Token: 0x0600516B RID: 20843 RVA: 0x00141948 File Offset: 0x0013FB48
	protected override global::UIMaterial customMaterial
	{
		get
		{
			return this.material;
		}
	}

	// Token: 0x17000F35 RID: 3893
	// (get) Token: 0x0600516C RID: 20844 RVA: 0x00141950 File Offset: 0x0013FB50
	public new global::UnityEngine.Vector2 relativeSize
	{
		get
		{
			if (this.mFont == null)
			{
				return global::UnityEngine.Vector3.one;
			}
			if (this.PendingChanges())
			{
				this.ProcessText();
			}
			return this.mSize;
		}
	}

	// Token: 0x0600516D RID: 20845 RVA: 0x00141998 File Offset: 0x0013FB98
	protected override void GetCustomVector2s(int start, int end, global::UIWidget.WidgetFlags[] flags, global::UnityEngine.Vector2[] v)
	{
		for (int i = 0; i < end; i++)
		{
			if (flags[i] == global::UIWidget.WidgetFlags.CustomRelativeSize)
			{
				v[i] = this.relativeSize;
			}
			else
			{
				base.GetCustomVector2s(i, i + 1, flags, v);
			}
		}
	}

	// Token: 0x0600516E RID: 20846 RVA: 0x001419E8 File Offset: 0x0013FBE8
	protected override void OnStart()
	{
		if (this.mLineWidth > 0f)
		{
			this.mMaxLineWidth = global::UnityEngine.Mathf.RoundToInt(this.mLineWidth);
			this.mLineWidth = 0f;
		}
		if (!this.mMultiline)
		{
			this.mMaxLineCount = 1;
			this.mMultiline = true;
		}
	}

	// Token: 0x0600516F RID: 20847 RVA: 0x00141A3C File Offset: 0x0013FC3C
	public override void MarkAsChanged()
	{
		this.ForceChanges();
		base.MarkAsChanged();
	}

	// Token: 0x06005170 RID: 20848 RVA: 0x00141A4C File Offset: 0x0013FC4C
	private void ProcessText()
	{
		base.ChangedAuto();
		this.mLastText = this.mText;
		this.markups.Clear();
		string a = this.mProcessedText;
		this.mProcessedText = this.mText;
		if (this.mPassword)
		{
			this.mProcessedText = this.mFont.WrapText(this.markups, this.mProcessedText, 100000f, 1, false, global::UIFont.SymbolStyle.None);
			string text = string.Empty;
			if (this.mShowLastChar)
			{
				int i = 1;
				int length = this.mProcessedText.Length;
				while (i < length)
				{
					text += "*";
					i++;
				}
				if (this.mProcessedText.Length > 0)
				{
					text += this.mProcessedText[this.mProcessedText.Length - 1];
				}
			}
			else
			{
				int j = 0;
				int length2 = this.mProcessedText.Length;
				while (j < length2)
				{
					text += "*";
					j++;
				}
			}
			this.mProcessedText = text;
		}
		else if (this.mMaxLineWidth > 0)
		{
			this.mProcessedText = this.mFont.WrapText(this.markups, this.mProcessedText, (float)this.mMaxLineWidth / base.cachedTransform.localScale.x, this.mMaxLineCount, this.mEncoding, this.mSymbols);
		}
		else if (this.mMaxLineCount > 0)
		{
			this.mProcessedText = this.mFont.WrapText(this.markups, this.mProcessedText, 100000f, this.mMaxLineCount, this.mEncoding, this.mSymbols);
		}
		this.mSize = (string.IsNullOrEmpty(this.mProcessedText) ? global::UnityEngine.Vector2.one : this.mFont.CalculatePrintedSize(this.mProcessedText, this.mEncoding, this.mSymbols));
		float x = base.cachedTransform.localScale.x;
		this.mSize.x = global::UnityEngine.Mathf.Max(this.mSize.x, (!(this.mFont != null) || x <= 1f) ? 1f : ((float)this.lineWidth / x));
		this.mSize.y = global::UnityEngine.Mathf.Max(this.mSize.y, 1f);
		if (a != this.mProcessedText)
		{
			this.mSelection = default(global::UITextSelection);
		}
		this.ApplyChanges();
	}

	// Token: 0x06005171 RID: 20849 RVA: 0x00141CF4 File Offset: 0x0013FEF4
	public int CalculateTextPosition(global::UnityEngine.Space space, global::UnityEngine.Vector3[] points, global::UITextPosition[] positions)
	{
		if (!this.mFont)
		{
			return -1;
		}
		string processedText = this.processedText;
		int num;
		if (space == 1)
		{
			num = this.mFont.CalculatePlacement(points, positions, processedText);
		}
		else
		{
			num = this.mFont.CalculatePlacement(points, positions, processedText, base.cachedTransform.worldToLocalMatrix);
		}
		int num2 = -1;
		for (int i = 0; i < num; i++)
		{
			this.ConvertProcessedTextPosition(ref positions[i], ref num2);
		}
		return num;
	}

	// Token: 0x06005172 RID: 20850 RVA: 0x00141D74 File Offset: 0x0013FF74
	public void MakePositionPerfect()
	{
		float num = (!(this.font.atlas != null)) ? 1f : this.font.atlas.pixelSize;
		global::UnityEngine.Vector3 localScale = base.cachedTransform.localScale;
		if (this.mFont.size == global::UnityEngine.Mathf.RoundToInt(localScale.x / num) && this.mFont.size == global::UnityEngine.Mathf.RoundToInt(localScale.y / num) && base.cachedTransform.localRotation == global::UnityEngine.Quaternion.identity)
		{
			global::UnityEngine.Vector2 vector = this.relativeSize * localScale.x;
			int num2 = global::UnityEngine.Mathf.RoundToInt(vector.x / num);
			int num3 = global::UnityEngine.Mathf.RoundToInt(vector.y / num);
			global::UnityEngine.Vector3 localPosition = base.cachedTransform.localPosition;
			localPosition.x = (float)global::UnityEngine.Mathf.FloorToInt(localPosition.x / num);
			localPosition.y = (float)global::UnityEngine.Mathf.CeilToInt(localPosition.y / num);
			localPosition.z = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.z);
			if (num2 % 2 == 1 && (base.pivot == global::UIWidget.Pivot.Top || base.pivot == global::UIWidget.Pivot.Center || base.pivot == global::UIWidget.Pivot.Bottom))
			{
				localPosition.x += 0.5f;
			}
			if (num3 % 2 == 1 && (base.pivot == global::UIWidget.Pivot.Left || base.pivot == global::UIWidget.Pivot.Center || base.pivot == global::UIWidget.Pivot.Right))
			{
				localPosition.y -= 0.5f;
			}
			localPosition.x *= num;
			localPosition.y *= num;
			if (base.cachedTransform.localPosition != localPosition)
			{
				base.cachedTransform.localPosition = localPosition;
			}
		}
	}

	// Token: 0x06005173 RID: 20851 RVA: 0x00141F58 File Offset: 0x00140158
	public override void MakePixelPerfect()
	{
		if (this.mFont != null)
		{
			float num = (!(this.font.atlas != null)) ? 1f : this.font.atlas.pixelSize;
			global::UnityEngine.Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = (float)this.mFont.size * num;
			localScale.y = localScale.x;
			localScale.z = 1f;
			global::UnityEngine.Vector2 vector = this.relativeSize * localScale.x;
			int num2 = global::UnityEngine.Mathf.RoundToInt(vector.x / num);
			int num3 = global::UnityEngine.Mathf.RoundToInt(vector.y / num);
			global::UnityEngine.Vector3 localPosition = base.cachedTransform.localPosition;
			localPosition.x = (float)global::UnityEngine.Mathf.FloorToInt(localPosition.x / num);
			localPosition.y = (float)global::UnityEngine.Mathf.CeilToInt(localPosition.y / num);
			localPosition.z = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.z);
			if (base.cachedTransform.localRotation == global::UnityEngine.Quaternion.identity)
			{
				if (num2 % 2 == 1 && (base.pivot == global::UIWidget.Pivot.Top || base.pivot == global::UIWidget.Pivot.Center || base.pivot == global::UIWidget.Pivot.Bottom))
				{
					localPosition.x += 0.5f;
				}
				if (num3 % 2 == 1 && (base.pivot == global::UIWidget.Pivot.Left || base.pivot == global::UIWidget.Pivot.Center || base.pivot == global::UIWidget.Pivot.Right))
				{
					localPosition.y -= 0.5f;
				}
			}
			localPosition.x *= num;
			localPosition.y *= num;
			base.cachedTransform.localPosition = localPosition;
			base.cachedTransform.localScale = localScale;
		}
		else
		{
			base.MakePixelPerfect();
		}
	}

	// Token: 0x06005174 RID: 20852 RVA: 0x00142140 File Offset: 0x00140340
	public override void OnFill(global::NGUI.Meshing.MeshBuffer m)
	{
		if (this.mFont == null)
		{
			return;
		}
		global::UnityEngine.Color normalColor = (!this.mInvisibleHack) ? base.color : global::UnityEngine.Color.clear;
		this.MakePositionPerfect();
		global::UIWidget.Pivot pivot = base.pivot;
		int vSize = m.vSize;
		if (pivot == global::UIWidget.Pivot.Left || pivot == global::UIWidget.Pivot.TopLeft || pivot == global::UIWidget.Pivot.BottomLeft)
		{
			if (this.mOverflowRight)
			{
				this.mFont.Print(this.processedText, normalColor, m, this.mEncoding, this.mSymbols, global::UIFont.Alignment.LeftOverflowRight, global::UnityEngine.Mathf.RoundToInt(this.relativeSize.x * (float)this.mFont.size), ref this.mSelection, this.mCarratChar, this.mHighlightTextColor, this.mHighlightColor, this.mHighlightChar, this.mHighlightCharSplit);
			}
			else
			{
				this.mFont.Print(this.processedText, normalColor, m, this.mEncoding, this.mSymbols, global::UIFont.Alignment.Left, 0, ref this.mSelection, this.mCarratChar, this.mHighlightTextColor, this.mHighlightColor, this.mHighlightChar, this.mHighlightCharSplit);
			}
		}
		else if (pivot == global::UIWidget.Pivot.Right || pivot == global::UIWidget.Pivot.TopRight || pivot == global::UIWidget.Pivot.BottomRight)
		{
			this.mFont.Print(this.processedText, normalColor, m, this.mEncoding, this.mSymbols, global::UIFont.Alignment.Right, global::UnityEngine.Mathf.RoundToInt(this.relativeSize.x * (float)this.mFont.size), ref this.mSelection, this.mCarratChar, this.mHighlightTextColor, this.mHighlightColor, this.mHighlightChar, this.mHighlightCharSplit);
		}
		else
		{
			this.mFont.Print(this.processedText, normalColor, m, this.mEncoding, this.mSymbols, global::UIFont.Alignment.Center, global::UnityEngine.Mathf.RoundToInt(this.relativeSize.x * (float)this.mFont.size), ref this.mSelection, this.mCarratChar, this.mHighlightTextColor, this.mHighlightColor, this.mHighlightChar, this.mHighlightCharSplit);
		}
		m.ApplyEffect(base.cachedTransform, vSize, this.effectStyle, this.effectColor, (float)this.mFont.size);
	}

	// Token: 0x06005175 RID: 20853 RVA: 0x0014236C File Offset: 0x0014056C
	public void UnionProcessedChanges(string newProcessedText)
	{
		this.text = newProcessedText;
	}

	// Token: 0x06005176 RID: 20854 RVA: 0x00142378 File Offset: 0x00140578
	private void ConvertProcessedTextPosition(ref global::UITextPosition p, ref int markupCount)
	{
		if (markupCount == -1)
		{
			markupCount = this.markups.Count;
		}
		if (markupCount == 0)
		{
			return;
		}
		global::UITextMarkup uitextMarkup = this.markups[0];
		int num = 0;
		while (p.position <= uitextMarkup.index)
		{
			switch (uitextMarkup.mod)
			{
			case global::UITextMod.End:
				p.deformed = (short)(this.mText.Length - uitextMarkup.index);
				break;
			case global::UITextMod.Removed:
				p.deformed += 1;
				if (++num < markupCount)
				{
					uitextMarkup = this.markups[num];
					continue;
				}
				break;
			case global::UITextMod.Replaced:
				if (++num < markupCount)
				{
					uitextMarkup = this.markups[num];
					continue;
				}
				break;
			case global::UITextMod.Added:
				p.deformed -= 1;
				if (++num < markupCount)
				{
					uitextMarkup = this.markups[num];
					continue;
				}
				break;
			default:
				if (++num < markupCount)
				{
					uitextMarkup = this.markups[num];
					continue;
				}
				break;
			}
			break;
		}
	}

	// Token: 0x06005177 RID: 20855 RVA: 0x001424BC File Offset: 0x001406BC
	public void GetProcessedIndices(ref int start, ref int end)
	{
		int count = this.markups.Count;
		if (count == 0 || this.markups[0].index > end)
		{
			return;
		}
		int num = start;
		int num2 = end;
		int num3 = 0;
		while (this.markups[num3].index <= start)
		{
			switch (this.markups[num3].mod)
			{
			case global::UITextMod.End:
				num2 = this.mProcessedText.Length - 1;
				return;
			case global::UITextMod.Removed:
				num--;
				num2--;
				break;
			case global::UITextMod.Added:
				num++;
				num2++;
				break;
			}
			if (++num3 >= count)
			{
				start = num;
				end = num2;
				return;
			}
		}
		while (this.markups[num3].index <= end)
		{
			switch (this.markups[num3].mod)
			{
			case global::UITextMod.End:
				num2 = this.mProcessedText.Length - 1;
				return;
			case global::UITextMod.Removed:
				num2--;
				break;
			case global::UITextMod.Added:
				num2++;
				break;
			}
			if (++num3 >= count)
			{
				break;
			}
		}
		start = num;
		end = num2;
	}

	// Token: 0x06005178 RID: 20856 RVA: 0x0014261C File Offset: 0x0014081C
	private static void CountLinesGetColumn(string text, int inPos, out int pos, out int lines, out int column, out global::UITextRegion region)
	{
		if (inPos < 0)
		{
			region = global::UITextRegion.Before;
			pos = 0;
			lines = 0;
			column = 0;
		}
		else if (inPos == 0)
		{
			pos = 0;
			lines = 0;
			column = 0;
			region = global::UITextRegion.Pre;
		}
		else
		{
			if (inPos > text.Length)
			{
				region = global::UITextRegion.End;
				pos = text.Length;
			}
			else if (inPos == text.Length)
			{
				region = global::UITextRegion.Past;
				pos = inPos;
			}
			else
			{
				region = global::UITextRegion.Inside;
				pos = inPos;
			}
			int num = text.IndexOf('\n', 0, pos);
			if (num == -1)
			{
				lines = 0;
				column = pos;
			}
			else
			{
				int num2 = num;
				lines = 1;
				while (++num < pos)
				{
					num = text.IndexOf('\n', num, pos - num);
					if (num == -1)
					{
						break;
					}
					lines++;
					num2 = num;
				}
				column = pos - (num2 + 1);
			}
		}
	}

	// Token: 0x06005179 RID: 20857 RVA: 0x001426FC File Offset: 0x001408FC
	public global::UITextPosition ConvertUnprocessedPosition(int position)
	{
		string processedText = this.processedText;
		int count = this.markups.Count;
		int num = position;
		if (count > 0)
		{
			int num2 = 0;
			global::UITextMarkup uitextMarkup = this.markups[num2];
			while (uitextMarkup.index <= position)
			{
				switch (uitextMarkup.mod)
				{
				case global::UITextMod.End:
					position -= num - uitextMarkup.index;
					num2 = count;
					break;
				case global::UITextMod.Removed:
					position--;
					break;
				case global::UITextMod.Added:
					position++;
					break;
				}
				if (++num2 >= count)
				{
					break;
				}
				uitextMarkup = this.markups[num2];
			}
		}
		global::UITextPosition result;
		global::UILabel.CountLinesGetColumn(processedText, position, out result.position, out result.line, out result.column, out result.region);
		result.uniformRegion = result.region;
		result.deformed = (short)(num - result.position);
		return result;
	}

	// Token: 0x0600517A RID: 20858 RVA: 0x001427FC File Offset: 0x001409FC
	public global::UITextSelection ConvertUnprocessedSelection(int carratPos, int selectPos)
	{
		global::UITextSelection result;
		result.carratPos = this.ConvertUnprocessedPosition(carratPos);
		if (carratPos == selectPos)
		{
			result.selectPos = result.carratPos;
		}
		else
		{
			result.selectPos = this.ConvertUnprocessedPosition(selectPos);
		}
		return result;
	}

	// Token: 0x04002DEB RID: 11755
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIFont mFont;

	// Token: 0x04002DEC RID: 11756
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string mText = string.Empty;

	// Token: 0x04002DED RID: 11757
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mMaxLineWidth;

	// Token: 0x04002DEE RID: 11758
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mEncoding = true;

	// Token: 0x04002DEF RID: 11759
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mMaxLineCount;

	// Token: 0x04002DF0 RID: 11760
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mPassword;

	// Token: 0x04002DF1 RID: 11761
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mShowLastChar;

	// Token: 0x04002DF2 RID: 11762
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mOverflowRight;

	// Token: 0x04002DF3 RID: 11763
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UILabel.Effect mEffectStyle;

	// Token: 0x04002DF4 RID: 11764
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color mEffectColor = global::UnityEngine.Color.black;

	// Token: 0x04002DF5 RID: 11765
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIFont.SymbolStyle mSymbols = global::UIFont.SymbolStyle.Uncolored;

	// Token: 0x04002DF6 RID: 11766
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private char mCarratChar = '|';

	// Token: 0x04002DF7 RID: 11767
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color mHighlightTextColor = global::UnityEngine.Color.cyan;

	// Token: 0x04002DF8 RID: 11768
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color mHighlightColor = global::UnityEngine.Color.black;

	// Token: 0x04002DF9 RID: 11769
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private char mHighlightChar = '|';

	// Token: 0x04002DFA RID: 11770
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float mHighlightCharSplit = 0.5f;

	// Token: 0x04002DFB RID: 11771
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float mLineWidth;

	// Token: 0x04002DFC RID: 11772
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mMultiline = true;

	// Token: 0x04002DFD RID: 11773
	private global::UnityEngine.Vector3? lastQueryPos;

	// Token: 0x04002DFE RID: 11774
	private bool mShouldBeProcessed = true;

	// Token: 0x04002DFF RID: 11775
	private string mProcessedText;

	// Token: 0x04002E00 RID: 11776
	private global::UITextSelection mSelection;

	// Token: 0x04002E01 RID: 11777
	private global::UnityEngine.Vector3 mLastScale = global::UnityEngine.Vector3.one;

	// Token: 0x04002E02 RID: 11778
	private string mLastText = string.Empty;

	// Token: 0x04002E03 RID: 11779
	private int mLastWidth;

	// Token: 0x04002E04 RID: 11780
	private bool mLastEncoding = true;

	// Token: 0x04002E05 RID: 11781
	private int mLastCount;

	// Token: 0x04002E06 RID: 11782
	private bool mLastPass;

	// Token: 0x04002E07 RID: 11783
	private bool mLastShow;

	// Token: 0x04002E08 RID: 11784
	private bool mInvisibleHack;

	// Token: 0x04002E09 RID: 11785
	private bool mLastInvisibleHack;

	// Token: 0x04002E0A RID: 11786
	private global::UILabel.Effect mLastEffect;

	// Token: 0x04002E0B RID: 11787
	private global::UnityEngine.Color mLastColor = global::UnityEngine.Color.black;

	// Token: 0x04002E0C RID: 11788
	private global::UnityEngine.Vector3 mSize = global::UnityEngine.Vector3.zero;

	// Token: 0x04002E0D RID: 11789
	private global::System.Collections.Generic.List<global::UITextMarkup> _markups;

	// Token: 0x02000957 RID: 2391
	public enum Effect
	{
		// Token: 0x04002E0F RID: 11791
		None,
		// Token: 0x04002E10 RID: 11792
		Shadow,
		// Token: 0x04002E11 RID: 11793
		Outline
	}
}
