using System;

// Token: 0x02000879 RID: 2169
[global::dfMarkupTagInfo("br")]
public class dfMarkupTagBr : global::dfMarkupTag
{
	// Token: 0x06004AF8 RID: 19192 RVA: 0x0011A610 File Offset: 0x00118810
	public dfMarkupTagBr() : base("br")
	{
		this.IsClosedTag = true;
	}

	// Token: 0x06004AF9 RID: 19193 RVA: 0x0011A624 File Offset: 0x00118824
	public dfMarkupTagBr(global::dfMarkupTag original) : base(original)
	{
		this.IsClosedTag = true;
	}

	// Token: 0x06004AFA RID: 19194 RVA: 0x0011A634 File Offset: 0x00118834
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		container.AddLineBreak();
	}
}
