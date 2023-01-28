using System;

// Token: 0x02000877 RID: 2167
[global::dfMarkupTagInfo("em")]
[global::dfMarkupTagInfo("i")]
public class dfMarkupTagItalic : global::dfMarkupTag
{
	// Token: 0x06004AF2 RID: 19186 RVA: 0x0011A484 File Offset: 0x00118684
	public dfMarkupTagItalic() : base("i")
	{
	}

	// Token: 0x06004AF3 RID: 19187 RVA: 0x0011A494 File Offset: 0x00118694
	public dfMarkupTagItalic(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004AF4 RID: 19188 RVA: 0x0011A4A0 File Offset: 0x001186A0
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		style = base.applyTextStyleAttributes(style);
		if (style.FontStyle == null)
		{
			style.FontStyle = 2;
		}
		else if (style.FontStyle == 1)
		{
			style.FontStyle = 3;
		}
		base._PerformLayoutImpl(container, style);
	}
}
