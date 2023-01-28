using System;

// Token: 0x02000875 RID: 2165
[global::dfMarkupTagInfo("b")]
[global::dfMarkupTagInfo("strong")]
public class dfMarkupTagBold : global::dfMarkupTag
{
	// Token: 0x06004AEB RID: 19179 RVA: 0x0011A228 File Offset: 0x00118428
	public dfMarkupTagBold() : base("b")
	{
	}

	// Token: 0x06004AEC RID: 19180 RVA: 0x0011A238 File Offset: 0x00118438
	public dfMarkupTagBold(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004AED RID: 19181 RVA: 0x0011A244 File Offset: 0x00118444
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		style = base.applyTextStyleAttributes(style);
		if (style.FontStyle == null)
		{
			style.FontStyle = 1;
		}
		else if (style.FontStyle == 2)
		{
			style.FontStyle = 3;
		}
		base._PerformLayoutImpl(container, style);
	}
}
