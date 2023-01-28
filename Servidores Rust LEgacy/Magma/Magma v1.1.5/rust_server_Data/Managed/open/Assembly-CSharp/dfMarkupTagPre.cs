using System;

// Token: 0x02000878 RID: 2168
[global::dfMarkupTagInfo("pre")]
public class dfMarkupTagPre : global::dfMarkupTag
{
	// Token: 0x06004AF5 RID: 19189 RVA: 0x0011A4EC File Offset: 0x001186EC
	public dfMarkupTagPre() : base("pre")
	{
	}

	// Token: 0x06004AF6 RID: 19190 RVA: 0x0011A4FC File Offset: 0x001186FC
	public dfMarkupTagPre(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004AF7 RID: 19191 RVA: 0x0011A508 File Offset: 0x00118708
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		style = base.applyTextStyleAttributes(style);
		style.PreserveWhitespace = true;
		style.Preformatted = true;
		if (style.Align == global::dfMarkupTextAlign.Justify)
		{
			style.Align = global::dfMarkupTextAlign.Left;
		}
		global::dfMarkupBox dfMarkupBox;
		if (style.BackgroundColor.a > 0.1f)
		{
			global::dfMarkupBoxSprite dfMarkupBoxSprite = new global::dfMarkupBoxSprite(this, global::dfMarkupDisplayType.block, style);
			dfMarkupBoxSprite.LoadImage(base.Owner.Atlas, base.Owner.BlankTextureSprite);
			dfMarkupBoxSprite.Style.Color = style.BackgroundColor;
			dfMarkupBox = dfMarkupBoxSprite;
		}
		else
		{
			dfMarkupBox = new global::dfMarkupBox(this, global::dfMarkupDisplayType.block, style);
		}
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
		dfMarkupBox.FitToContents(false);
	}
}
