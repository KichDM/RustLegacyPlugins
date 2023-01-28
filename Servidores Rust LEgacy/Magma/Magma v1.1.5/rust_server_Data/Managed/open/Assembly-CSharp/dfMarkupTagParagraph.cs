using System;

// Token: 0x02000874 RID: 2164
[global::dfMarkupTagInfo("p")]
public class dfMarkupTagParagraph : global::dfMarkupTag
{
	// Token: 0x06004AE8 RID: 19176 RVA: 0x0011A0AC File Offset: 0x001182AC
	public dfMarkupTagParagraph() : base("p")
	{
	}

	// Token: 0x06004AE9 RID: 19177 RVA: 0x0011A0BC File Offset: 0x001182BC
	public dfMarkupTagParagraph(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004AEA RID: 19178 RVA: 0x0011A0C8 File Offset: 0x001182C8
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		if (base.ChildNodes.Count == 0)
		{
			return;
		}
		style = base.applyTextStyleAttributes(style);
		int top = (container.Children.Count != 0) ? style.LineHeight : 0;
		global::dfMarkupBox dfMarkupBox;
		if (style.BackgroundColor.a > 0.005f)
		{
			global::dfMarkupBoxSprite dfMarkupBoxSprite = new global::dfMarkupBoxSprite(this, global::dfMarkupDisplayType.block, style);
			dfMarkupBoxSprite.Atlas = base.Owner.Atlas;
			dfMarkupBoxSprite.Source = base.Owner.BlankTextureSprite;
			dfMarkupBoxSprite.Style.Color = style.BackgroundColor;
			dfMarkupBox = dfMarkupBoxSprite;
		}
		else
		{
			dfMarkupBox = new global::dfMarkupBox(this, global::dfMarkupDisplayType.block, style);
		}
		dfMarkupBox.Margins = new global::dfMarkupBorders(0, 0, top, style.LineHeight);
		global::dfMarkupAttribute dfMarkupAttribute = base.findAttribute(new string[]
		{
			"margin"
		});
		if (dfMarkupAttribute != null)
		{
			dfMarkupBox.Margins = global::dfMarkupBorders.Parse(dfMarkupAttribute.Value);
		}
		global::dfMarkupAttribute dfMarkupAttribute2 = base.findAttribute(new string[]
		{
			"padding"
		});
		if (dfMarkupAttribute2 != null)
		{
			dfMarkupBox.Padding = global::dfMarkupBorders.Parse(dfMarkupAttribute2.Value);
		}
		container.AddChild(dfMarkupBox);
		base._PerformLayoutImpl(dfMarkupBox, style);
		if (dfMarkupBox.Children.Count > 0)
		{
			dfMarkupBox.Children[dfMarkupBox.Children.Count - 1].IsNewline = true;
		}
		dfMarkupBox.FitToContents(true);
	}
}
