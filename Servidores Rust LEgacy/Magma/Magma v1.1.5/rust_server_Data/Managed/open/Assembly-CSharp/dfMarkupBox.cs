using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200085F RID: 2143
public class dfMarkupBox
{
	// Token: 0x06004A4B RID: 19019 RVA: 0x001167CC File Offset: 0x001149CC
	private dfMarkupBox()
	{
		throw new global::System.NotImplementedException();
	}

	// Token: 0x06004A4C RID: 19020 RVA: 0x00116824 File Offset: 0x00114A24
	public dfMarkupBox(global::dfMarkupElement element, global::dfMarkupDisplayType display, global::dfMarkupStyle style)
	{
		this.Element = element;
		this.Display = display;
		this.Style = style;
		this.Baseline = style.FontSize;
	}

	// Token: 0x17000DE9 RID: 3561
	// (get) Token: 0x06004A4D RID: 19021 RVA: 0x00116898 File Offset: 0x00114A98
	// (set) Token: 0x06004A4E RID: 19022 RVA: 0x001168A0 File Offset: 0x00114AA0
	public global::dfMarkupBox Parent
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Parent>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected set
		{
			this.<Parent>k__BackingField = value;
		}
	}

	// Token: 0x17000DEA RID: 3562
	// (get) Token: 0x06004A4F RID: 19023 RVA: 0x001168AC File Offset: 0x00114AAC
	// (set) Token: 0x06004A50 RID: 19024 RVA: 0x001168B4 File Offset: 0x00114AB4
	public global::dfMarkupElement Element
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Element>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected set
		{
			this.<Element>k__BackingField = value;
		}
	}

	// Token: 0x17000DEB RID: 3563
	// (get) Token: 0x06004A51 RID: 19025 RVA: 0x001168C0 File Offset: 0x00114AC0
	public global::System.Collections.Generic.List<global::dfMarkupBox> Children
	{
		get
		{
			return this.children;
		}
	}

	// Token: 0x17000DEC RID: 3564
	// (get) Token: 0x06004A52 RID: 19026 RVA: 0x001168C8 File Offset: 0x00114AC8
	// (set) Token: 0x06004A53 RID: 19027 RVA: 0x001168D8 File Offset: 0x00114AD8
	public int Width
	{
		get
		{
			return (int)this.Size.x;
		}
		set
		{
			this.Size = new global::UnityEngine.Vector2((float)value, this.Size.y);
		}
	}

	// Token: 0x17000DED RID: 3565
	// (get) Token: 0x06004A54 RID: 19028 RVA: 0x001168F4 File Offset: 0x00114AF4
	// (set) Token: 0x06004A55 RID: 19029 RVA: 0x00116904 File Offset: 0x00114B04
	public int Height
	{
		get
		{
			return (int)this.Size.y;
		}
		set
		{
			this.Size = new global::UnityEngine.Vector2(this.Size.x, (float)value);
		}
	}

	// Token: 0x06004A56 RID: 19030 RVA: 0x00116920 File Offset: 0x00114B20
	internal global::dfMarkupBox HitTest(global::UnityEngine.Vector2 point)
	{
		global::UnityEngine.Vector2 offset = this.GetOffset();
		global::UnityEngine.Vector2 vector = offset + this.Size;
		if (point.x < offset.x || point.x > vector.x || point.y < offset.y || point.y > vector.y)
		{
			return null;
		}
		for (int i = 0; i < this.children.Count; i++)
		{
			global::dfMarkupBox dfMarkupBox = this.children[i].HitTest(point);
			if (dfMarkupBox != null)
			{
				return dfMarkupBox;
			}
		}
		return this;
	}

	// Token: 0x06004A57 RID: 19031 RVA: 0x001169C8 File Offset: 0x00114BC8
	internal global::dfRenderData Render()
	{
		global::dfRenderData result;
		try
		{
			this.endCurrentLine(false);
			result = this.OnRebuildRenderData();
		}
		finally
		{
		}
		return result;
	}

	// Token: 0x06004A58 RID: 19032 RVA: 0x00116A0C File Offset: 0x00114C0C
	public virtual global::UnityEngine.Vector2 GetOffset()
	{
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.zero;
		for (global::dfMarkupBox dfMarkupBox = this; dfMarkupBox != null; dfMarkupBox = dfMarkupBox.Parent)
		{
			vector += dfMarkupBox.Position;
		}
		return vector;
	}

	// Token: 0x06004A59 RID: 19033 RVA: 0x00116A44 File Offset: 0x00114C44
	internal void AddLineBreak()
	{
		if (this.currentLine != null)
		{
			this.currentLine.IsNewline = true;
		}
		int verticalPosition = this.getVerticalPosition(0);
		this.endCurrentLine(false);
		global::dfMarkupBox containingBlock = this.GetContainingBlock();
		this.currentLine = new global::dfMarkupBox(this.Element, global::dfMarkupDisplayType.block, this.Style)
		{
			Size = new global::UnityEngine.Vector2(containingBlock.Size.x, (float)this.Style.FontSize),
			Position = new global::UnityEngine.Vector2(0f, (float)verticalPosition),
			Parent = this
		};
		this.children.Add(this.currentLine);
	}

	// Token: 0x06004A5A RID: 19034 RVA: 0x00116AE4 File Offset: 0x00114CE4
	public virtual void AddChild(global::dfMarkupBox box)
	{
		global::dfMarkupDisplayType display = box.Display;
		bool flag = display == global::dfMarkupDisplayType.block || display == global::dfMarkupDisplayType.table || display == global::dfMarkupDisplayType.listItem || display == global::dfMarkupDisplayType.tableRow;
		if (flag)
		{
			this.addBlock(box);
		}
		else
		{
			this.addInline(box);
		}
	}

	// Token: 0x06004A5B RID: 19035 RVA: 0x00116B30 File Offset: 0x00114D30
	public virtual void Release()
	{
		for (int i = 0; i < this.children.Count; i++)
		{
			this.children[i].Release();
		}
		this.children.Clear();
		this.Element = null;
		this.Parent = null;
		this.Margins = default(global::dfMarkupBorders);
	}

	// Token: 0x06004A5C RID: 19036 RVA: 0x00116B94 File Offset: 0x00114D94
	protected virtual global::dfRenderData OnRebuildRenderData()
	{
		return null;
	}

	// Token: 0x06004A5D RID: 19037 RVA: 0x00116B98 File Offset: 0x00114D98
	protected void renderDebugBox(global::dfRenderData renderData)
	{
		global::UnityEngine.Vector3 zero = global::UnityEngine.Vector3.zero;
		global::UnityEngine.Vector3 vector = zero + global::UnityEngine.Vector3.right * this.Size.x;
		global::UnityEngine.Vector3 item = vector + global::UnityEngine.Vector3.down * this.Size.y;
		global::UnityEngine.Vector3 item2 = zero + global::UnityEngine.Vector3.down * this.Size.y;
		renderData.Vertices.Add(zero);
		renderData.Vertices.Add(vector);
		renderData.Vertices.Add(item);
		renderData.Vertices.Add(item2);
		renderData.Triangles.AddRange(new int[]
		{
			0,
			1,
			3,
			3,
			1,
			2
		});
		renderData.UV.Add(global::UnityEngine.Vector2.zero);
		renderData.UV.Add(global::UnityEngine.Vector2.zero);
		renderData.UV.Add(global::UnityEngine.Vector2.zero);
		renderData.UV.Add(global::UnityEngine.Vector2.zero);
		global::UnityEngine.Color backgroundColor = this.Style.BackgroundColor;
		renderData.Colors.Add(backgroundColor);
		renderData.Colors.Add(backgroundColor);
		renderData.Colors.Add(backgroundColor);
		renderData.Colors.Add(backgroundColor);
	}

	// Token: 0x06004A5E RID: 19038 RVA: 0x00116CE0 File Offset: 0x00114EE0
	public void FitToContents(bool recursive = false)
	{
		if (this.children.Count == 0)
		{
			this.Size = new global::UnityEngine.Vector2(this.Size.x, 0f);
			return;
		}
		this.endCurrentLine(false);
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.zero;
		for (int i = 0; i < this.children.Count; i++)
		{
			global::dfMarkupBox dfMarkupBox = this.children[i];
			vector = global::UnityEngine.Vector2.Max(vector, dfMarkupBox.Position + dfMarkupBox.Size);
		}
		this.Size = vector;
	}

	// Token: 0x06004A5F RID: 19039 RVA: 0x00116D70 File Offset: 0x00114F70
	private global::dfMarkupBox GetContainingBlock()
	{
		for (global::dfMarkupBox dfMarkupBox = this; dfMarkupBox != null; dfMarkupBox = dfMarkupBox.Parent)
		{
			global::dfMarkupDisplayType display = dfMarkupBox.Display;
			bool flag = display == global::dfMarkupDisplayType.block || display == global::dfMarkupDisplayType.inlineBlock || display == global::dfMarkupDisplayType.listItem || display == global::dfMarkupDisplayType.table || display == global::dfMarkupDisplayType.tableRow || display == global::dfMarkupDisplayType.tableCell;
			if (flag)
			{
				return dfMarkupBox;
			}
		}
		return null;
	}

	// Token: 0x06004A60 RID: 19040 RVA: 0x00116DD0 File Offset: 0x00114FD0
	private void addInline(global::dfMarkupBox box)
	{
		global::dfMarkupBorders margins = box.Margins;
		bool flag = !this.Style.Preformatted && this.currentLine != null && (float)this.currentLinePos + box.Size.x > this.currentLine.Size.x;
		if (this.currentLine == null || flag)
		{
			this.endCurrentLine(false);
			int verticalPosition = this.getVerticalPosition(margins.top);
			global::dfMarkupBox containingBlock = this.GetContainingBlock();
			if (containingBlock == null)
			{
				global::UnityEngine.Debug.LogError("Containing block not found");
				return;
			}
			global::dfDynamicFont dfDynamicFont = this.Style.Font ?? this.Style.Host.Font;
			float num = (float)dfDynamicFont.FontSize / (float)dfDynamicFont.FontSize;
			float num2 = (float)dfDynamicFont.Baseline * num;
			this.currentLine = new global::dfMarkupBox(this.Element, global::dfMarkupDisplayType.block, this.Style)
			{
				Size = new global::UnityEngine.Vector2(containingBlock.Size.x, (float)this.Style.LineHeight),
				Position = new global::UnityEngine.Vector2(0f, (float)verticalPosition),
				Parent = this,
				Baseline = (int)num2
			};
			this.children.Add(this.currentLine);
		}
		if (this.currentLinePos == 0 && !box.Style.PreserveWhitespace && box is global::dfMarkupBoxText)
		{
			global::dfMarkupBoxText dfMarkupBoxText = box as global::dfMarkupBoxText;
			if (dfMarkupBoxText.IsWhitespace)
			{
				return;
			}
		}
		global::UnityEngine.Vector2 position;
		position..ctor((float)(this.currentLinePos + margins.left), (float)margins.top);
		box.Position = position;
		box.Parent = this.currentLine;
		this.currentLine.children.Add(box);
		this.currentLinePos = (int)(position.x + box.Size.x + (float)box.Margins.right);
		float num3 = global::UnityEngine.Mathf.Max(this.currentLine.Size.x, position.x + box.Size.x);
		float num4 = global::UnityEngine.Mathf.Max(this.currentLine.Size.y, position.y + box.Size.y);
		this.currentLine.Size = new global::UnityEngine.Vector2(num3, num4);
	}

	// Token: 0x06004A61 RID: 19041 RVA: 0x00117030 File Offset: 0x00115230
	private int getVerticalPosition(int topMargin)
	{
		if (this.children.Count == 0)
		{
			return topMargin;
		}
		int num = 0;
		int index = 0;
		for (int i = 0; i < this.children.Count; i++)
		{
			global::dfMarkupBox dfMarkupBox = this.children[i];
			float num2 = dfMarkupBox.Position.y + dfMarkupBox.Size.y + (float)dfMarkupBox.Margins.bottom;
			if (num2 > (float)num)
			{
				num = (int)num2;
				index = i;
			}
		}
		global::dfMarkupBox dfMarkupBox2 = this.children[index];
		int num3 = global::UnityEngine.Mathf.Max(dfMarkupBox2.Margins.bottom, topMargin);
		return (int)(dfMarkupBox2.Position.y + dfMarkupBox2.Size.y + (float)num3);
	}

	// Token: 0x06004A62 RID: 19042 RVA: 0x001170F4 File Offset: 0x001152F4
	private void addBlock(global::dfMarkupBox box)
	{
		if (this.currentLine != null)
		{
			this.currentLine.IsNewline = true;
			this.endCurrentLine(true);
		}
		global::dfMarkupBox containingBlock = this.GetContainingBlock();
		if (box.Size.sqrMagnitude <= 1E-45f)
		{
			box.Size = new global::UnityEngine.Vector2(containingBlock.Size.x - (float)box.Margins.horizontal, (float)this.Style.FontSize);
		}
		int verticalPosition = this.getVerticalPosition(box.Margins.top);
		box.Position = new global::UnityEngine.Vector2((float)box.Margins.left, (float)verticalPosition);
		this.Size = new global::UnityEngine.Vector2(this.Size.x, global::UnityEngine.Mathf.Max(this.Size.y, box.Position.y + box.Size.y));
		box.Parent = this;
		this.children.Add(box);
	}

	// Token: 0x06004A63 RID: 19043 RVA: 0x001171E8 File Offset: 0x001153E8
	private void endCurrentLine(bool removeEmpty = false)
	{
		if (this.currentLine == null)
		{
			return;
		}
		if (this.currentLinePos == 0)
		{
			if (removeEmpty)
			{
				this.children.Remove(this.currentLine);
			}
		}
		else
		{
			this.currentLine.doHorizontalAlignment();
			this.currentLine.doVerticalAlignment();
		}
		this.currentLine = null;
		this.currentLinePos = 0;
	}

	// Token: 0x06004A64 RID: 19044 RVA: 0x00117250 File Offset: 0x00115450
	private void doVerticalAlignment()
	{
		if (this.children.Count == 0)
		{
			return;
		}
		float num = float.MinValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		this.Baseline = (int)(this.Size.y * 0.95f);
		for (int i = 0; i < this.children.Count; i++)
		{
			global::dfMarkupBox dfMarkupBox = this.children[i];
			num3 = global::UnityEngine.Mathf.Max(num3, dfMarkupBox.Position.y + (float)dfMarkupBox.Baseline);
		}
		for (int j = 0; j < this.children.Count; j++)
		{
			global::dfMarkupBox dfMarkupBox2 = this.children[j];
			global::dfMarkupVerticalAlign verticalAlign = dfMarkupBox2.Style.VerticalAlign;
			global::UnityEngine.Vector2 position = dfMarkupBox2.Position;
			if (verticalAlign == global::dfMarkupVerticalAlign.Baseline)
			{
				position.y = num3 - (float)dfMarkupBox2.Baseline;
			}
			dfMarkupBox2.Position = position;
		}
		for (int k = 0; k < this.children.Count; k++)
		{
			global::dfMarkupBox dfMarkupBox3 = this.children[k];
			global::UnityEngine.Vector2 position2 = dfMarkupBox3.Position;
			global::UnityEngine.Vector2 size = dfMarkupBox3.Size;
			num2 = global::UnityEngine.Mathf.Min(num2, position2.y);
			num = global::UnityEngine.Mathf.Max(num, position2.y + size.y);
		}
		for (int l = 0; l < this.children.Count; l++)
		{
			global::dfMarkupBox dfMarkupBox4 = this.children[l];
			global::dfMarkupVerticalAlign verticalAlign2 = dfMarkupBox4.Style.VerticalAlign;
			global::UnityEngine.Vector2 position3 = dfMarkupBox4.Position;
			global::UnityEngine.Vector2 size2 = dfMarkupBox4.Size;
			if (verticalAlign2 == global::dfMarkupVerticalAlign.Top)
			{
				position3.y = num2;
			}
			else if (verticalAlign2 == global::dfMarkupVerticalAlign.Bottom)
			{
				position3.y = num - size2.y;
			}
			else if (verticalAlign2 == global::dfMarkupVerticalAlign.Middle)
			{
				position3.y = (this.Size.y - size2.y) * 0.5f;
			}
			dfMarkupBox4.Position = position3;
		}
		int num4 = int.MaxValue;
		for (int m = 0; m < this.children.Count; m++)
		{
			num4 = global::UnityEngine.Mathf.Min(num4, (int)this.children[m].Position.y);
		}
		for (int n = 0; n < this.children.Count; n++)
		{
			global::UnityEngine.Vector2 position4 = this.children[n].Position;
			position4.y -= (float)num4;
			this.children[n].Position = position4;
		}
	}

	// Token: 0x06004A65 RID: 19045 RVA: 0x00117500 File Offset: 0x00115700
	private void doHorizontalAlignment()
	{
		if (this.Style.Align == global::dfMarkupTextAlign.Left || this.children.Count == 0)
		{
			return;
		}
		int i;
		for (i = this.children.Count - 1; i > 0; i--)
		{
			global::dfMarkupBoxText dfMarkupBoxText = this.children[i] as global::dfMarkupBoxText;
			if (dfMarkupBoxText == null || !dfMarkupBoxText.IsWhitespace)
			{
				break;
			}
		}
		if (this.Style.Align == global::dfMarkupTextAlign.Center)
		{
			float num = 0f;
			for (int j = 0; j <= i; j++)
			{
				num += this.children[j].Size.x;
			}
			float num2 = (this.Size.x - (float)this.Padding.horizontal - num) * 0.5f;
			for (int k = 0; k <= i; k++)
			{
				global::UnityEngine.Vector2 position = this.children[k].Position;
				position.x += num2;
				this.children[k].Position = position;
			}
		}
		else if (this.Style.Align == global::dfMarkupTextAlign.Right)
		{
			float num3 = this.Size.x - (float)this.Padding.horizontal;
			for (int l = i; l >= 0; l--)
			{
				global::UnityEngine.Vector2 position2 = this.children[l].Position;
				position2.x = num3 - this.children[l].Size.x;
				this.children[l].Position = position2;
				num3 -= this.children[l].Size.x;
			}
		}
		else
		{
			if (this.Style.Align != global::dfMarkupTextAlign.Justify)
			{
				throw new global::System.NotImplementedException("text-align: " + this.Style.Align + " is not implemented");
			}
			if (this.children.Count <= 1)
			{
				return;
			}
			if (this.IsNewline || this.children[this.children.Count - 1].IsNewline)
			{
				return;
			}
			float num4 = 0f;
			for (int m = 0; m <= i; m++)
			{
				global::dfMarkupBox dfMarkupBox = this.children[m];
				num4 = global::UnityEngine.Mathf.Max(num4, dfMarkupBox.Position.x + dfMarkupBox.Size.x);
			}
			float num5 = (this.Size.x - (float)this.Padding.horizontal - num4) / (float)this.children.Count;
			for (int n = 1; n <= i; n++)
			{
				this.children[n].Position += new global::UnityEngine.Vector2((float)n * num5, 0f);
			}
			global::dfMarkupBox dfMarkupBox2 = this.children[i];
			global::UnityEngine.Vector2 position3 = dfMarkupBox2.Position;
			position3.x = this.Size.x - (float)this.Padding.horizontal - dfMarkupBox2.Size.x;
			dfMarkupBox2.Position = position3;
		}
	}

	// Token: 0x04002792 RID: 10130
	public global::UnityEngine.Vector2 Position = global::UnityEngine.Vector2.zero;

	// Token: 0x04002793 RID: 10131
	public global::UnityEngine.Vector2 Size = global::UnityEngine.Vector2.zero;

	// Token: 0x04002794 RID: 10132
	public global::dfMarkupDisplayType Display;

	// Token: 0x04002795 RID: 10133
	public global::dfMarkupBorders Margins = new global::dfMarkupBorders(0, 0, 0, 0);

	// Token: 0x04002796 RID: 10134
	public global::dfMarkupBorders Padding = new global::dfMarkupBorders(0, 0, 0, 0);

	// Token: 0x04002797 RID: 10135
	public global::dfMarkupStyle Style;

	// Token: 0x04002798 RID: 10136
	public bool IsNewline;

	// Token: 0x04002799 RID: 10137
	public int Baseline;

	// Token: 0x0400279A RID: 10138
	private global::System.Collections.Generic.List<global::dfMarkupBox> children = new global::System.Collections.Generic.List<global::dfMarkupBox>();

	// Token: 0x0400279B RID: 10139
	private global::dfMarkupBox currentLine;

	// Token: 0x0400279C RID: 10140
	private int currentLinePos;

	// Token: 0x0400279D RID: 10141
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfMarkupBox <Parent>k__BackingField;

	// Token: 0x0400279E RID: 10142
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfMarkupElement <Element>k__BackingField;
}
