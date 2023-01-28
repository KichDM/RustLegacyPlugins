using System;

// Token: 0x02000871 RID: 2161
[global::dfMarkupTagInfo("a")]
public class dfMarkupTagAnchor : global::dfMarkupTag
{
	// Token: 0x06004ADB RID: 19163 RVA: 0x00119C40 File Offset: 0x00117E40
	public dfMarkupTagAnchor() : base("a")
	{
	}

	// Token: 0x06004ADC RID: 19164 RVA: 0x00119C50 File Offset: 0x00117E50
	public dfMarkupTagAnchor(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x17000E03 RID: 3587
	// (get) Token: 0x06004ADD RID: 19165 RVA: 0x00119C5C File Offset: 0x00117E5C
	public string HRef
	{
		get
		{
			global::dfMarkupAttribute dfMarkupAttribute = base.findAttribute(new string[]
			{
				"href"
			});
			return (dfMarkupAttribute == null) ? string.Empty : dfMarkupAttribute.Value;
		}
	}

	// Token: 0x06004ADE RID: 19166 RVA: 0x00119C94 File Offset: 0x00117E94
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		style.TextDecoration = global::dfMarkupTextDecoration.Underline;
		style = base.applyTextStyleAttributes(style);
		int i = 0;
		while (i < base.ChildNodes.Count)
		{
			global::dfMarkupElement dfMarkupElement = base.ChildNodes[i];
			if (!(dfMarkupElement is global::dfMarkupString))
			{
				goto IL_63;
			}
			global::dfMarkupString dfMarkupString = dfMarkupElement as global::dfMarkupString;
			if (!(dfMarkupString.Text == "\n"))
			{
				goto IL_63;
			}
			if (style.PreserveWhitespace)
			{
				container.AddLineBreak();
			}
			IL_6B:
			i++;
			continue;
			IL_63:
			dfMarkupElement.PerformLayout(container, style);
			goto IL_6B;
		}
	}
}
