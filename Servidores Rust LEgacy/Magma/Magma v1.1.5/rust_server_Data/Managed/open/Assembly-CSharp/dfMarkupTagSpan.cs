using System;
using System.Collections.Generic;

// Token: 0x02000870 RID: 2160
[global::dfMarkupTagInfo("span")]
public class dfMarkupTagSpan : global::dfMarkupTag
{
	// Token: 0x06004AD5 RID: 19157 RVA: 0x00119B4C File Offset: 0x00117D4C
	public dfMarkupTagSpan() : base("span")
	{
	}

	// Token: 0x06004AD6 RID: 19158 RVA: 0x00119B5C File Offset: 0x00117D5C
	public dfMarkupTagSpan(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x06004AD7 RID: 19159 RVA: 0x00119B68 File Offset: 0x00117D68
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupTagSpan()
	{
	}

	// Token: 0x06004AD8 RID: 19160 RVA: 0x00119B74 File Offset: 0x00117D74
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		style = base.applyTextStyleAttributes(style);
		int i = 0;
		while (i < base.ChildNodes.Count)
		{
			global::dfMarkupElement dfMarkupElement = base.ChildNodes[i];
			if (!(dfMarkupElement is global::dfMarkupString))
			{
				goto IL_5B;
			}
			global::dfMarkupString dfMarkupString = dfMarkupElement as global::dfMarkupString;
			if (!(dfMarkupString.Text == "\n"))
			{
				goto IL_5B;
			}
			if (style.PreserveWhitespace)
			{
				container.AddLineBreak();
			}
			IL_63:
			i++;
			continue;
			IL_5B:
			dfMarkupElement.PerformLayout(container, style);
			goto IL_63;
		}
	}

	// Token: 0x06004AD9 RID: 19161 RVA: 0x00119BFC File Offset: 0x00117DFC
	internal static global::dfMarkupTagSpan Obtain()
	{
		if (global::dfMarkupTagSpan.objectPool.Count > 0)
		{
			return global::dfMarkupTagSpan.objectPool.Dequeue();
		}
		return new global::dfMarkupTagSpan();
	}

	// Token: 0x06004ADA RID: 19162 RVA: 0x00119C2C File Offset: 0x00117E2C
	internal override void Release()
	{
		base.Release();
		global::dfMarkupTagSpan.objectPool.Enqueue(this);
	}

	// Token: 0x040027EF RID: 10223
	private static global::System.Collections.Generic.Queue<global::dfMarkupTagSpan> objectPool = new global::System.Collections.Generic.Queue<global::dfMarkupTagSpan>();
}
