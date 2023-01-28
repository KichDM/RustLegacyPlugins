using System;
using UnityEngine;

// Token: 0x02000873 RID: 2163
[global::dfMarkupTagInfo("li")]
public class dfMarkupTagListItem : global::dfMarkupTag
{
	// Token: 0x06004AE5 RID: 19173 RVA: 0x00119EE4 File Offset: 0x001180E4
	public dfMarkupTagListItem() : base("li")
	{
	}

	// Token: 0x06004AE6 RID: 19174 RVA: 0x00119EF4 File Offset: 0x001180F4
	public dfMarkupTagListItem(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004AE7 RID: 19175 RVA: 0x00119F00 File Offset: 0x00118100
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		if (base.ChildNodes.Count == 0)
		{
			return;
		}
		float x = container.Size.x;
		global::dfMarkupBox dfMarkupBox = new global::dfMarkupBox(this, global::dfMarkupDisplayType.listItem, style);
		dfMarkupBox.Margins.top = 0xA;
		container.AddChild(dfMarkupBox);
		global::dfMarkupTagList dfMarkupTagList = base.Parent as global::dfMarkupTagList;
		if (dfMarkupTagList == null)
		{
			base._PerformLayoutImpl(container, style);
			return;
		}
		style.VerticalAlign = global::dfMarkupVerticalAlign.Baseline;
		string text = "•";
		if (dfMarkupTagList.TagName == "ol")
		{
			text = container.Children.Count + ".";
		}
		global::dfMarkupStyle style2 = style;
		style2.VerticalAlign = global::dfMarkupVerticalAlign.Baseline;
		style2.Align = global::dfMarkupTextAlign.Right;
		global::dfMarkupBoxText dfMarkupBoxText = global::dfMarkupBoxText.Obtain(this, global::dfMarkupDisplayType.inlineBlock, style2);
		dfMarkupBoxText.SetText(text);
		dfMarkupBoxText.Width = dfMarkupTagList.BulletWidth;
		dfMarkupBoxText.Margins.left = style.FontSize * 2;
		dfMarkupBox.AddChild(dfMarkupBoxText);
		global::dfMarkupBox dfMarkupBox2 = new global::dfMarkupBox(this, global::dfMarkupDisplayType.inlineBlock, style);
		int fontSize = style.FontSize;
		float num = x - dfMarkupBoxText.Size.x - (float)dfMarkupBoxText.Margins.left - (float)fontSize;
		dfMarkupBox2.Size = new global::UnityEngine.Vector2(num, (float)fontSize);
		dfMarkupBox2.Margins.left = (int)((float)style.FontSize * 0.5f);
		dfMarkupBox.AddChild(dfMarkupBox2);
		for (int i = 0; i < base.ChildNodes.Count; i++)
		{
			base.ChildNodes[i].PerformLayout(dfMarkupBox2, style);
		}
		dfMarkupBox2.FitToContents(false);
		dfMarkupBox2.Parent.FitToContents(false);
		dfMarkupBox.FitToContents(false);
	}
}
