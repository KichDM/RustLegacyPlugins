using System;
using UnityEngine;

// Token: 0x0200087B RID: 2171
[global::dfMarkupTagInfo("font")]
public class dfMarkupTagFont : global::dfMarkupTag
{
	// Token: 0x06004B00 RID: 19200 RVA: 0x0011A908 File Offset: 0x00118B08
	public dfMarkupTagFont() : base("font")
	{
	}

	// Token: 0x06004B01 RID: 19201 RVA: 0x0011A918 File Offset: 0x00118B18
	public dfMarkupTagFont(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004B02 RID: 19202 RVA: 0x0011A924 File Offset: 0x00118B24
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		global::dfMarkupAttribute dfMarkupAttribute = base.findAttribute(new string[]
		{
			"name",
			"face"
		});
		if (dfMarkupAttribute != null)
		{
			style.Font = (global::dfDynamicFont.FindByName(dfMarkupAttribute.Value) ?? style.Font);
		}
		global::dfMarkupAttribute dfMarkupAttribute2 = base.findAttribute(new string[]
		{
			"size",
			"font-size"
		});
		if (dfMarkupAttribute2 != null)
		{
			style.FontSize = global::dfMarkupStyle.ParseSize(dfMarkupAttribute2.Value, style.FontSize);
		}
		global::dfMarkupAttribute dfMarkupAttribute3 = base.findAttribute(new string[]
		{
			"color"
		});
		if (dfMarkupAttribute3 != null)
		{
			style.Color = global::dfMarkupStyle.ParseColor(dfMarkupAttribute3.Value, global::UnityEngine.Color.red);
			style.Color.a = style.Opacity;
		}
		global::dfMarkupAttribute dfMarkupAttribute4 = base.findAttribute(new string[]
		{
			"style"
		});
		if (dfMarkupAttribute4 != null)
		{
			style.FontStyle = global::dfMarkupStyle.ParseFontStyle(dfMarkupAttribute4.Value, style.FontStyle);
		}
		base._PerformLayoutImpl(container, style);
	}
}
