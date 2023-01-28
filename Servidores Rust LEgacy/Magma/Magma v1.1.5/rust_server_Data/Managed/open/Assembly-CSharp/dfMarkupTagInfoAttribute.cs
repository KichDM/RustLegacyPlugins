using System;
using System.Runtime.CompilerServices;

// Token: 0x02000864 RID: 2148
[global::System.AttributeUsage(global::System.AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class dfMarkupTagInfoAttribute : global::System.Attribute
{
	// Token: 0x06004A86 RID: 19078 RVA: 0x001184D8 File Offset: 0x001166D8
	public dfMarkupTagInfoAttribute(string tagName)
	{
		this.TagName = tagName;
	}

	// Token: 0x17000DF3 RID: 3571
	// (get) Token: 0x06004A87 RID: 19079 RVA: 0x001184E8 File Offset: 0x001166E8
	// (set) Token: 0x06004A88 RID: 19080 RVA: 0x001184F0 File Offset: 0x001166F0
	public string TagName
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TagName>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<TagName>k__BackingField = value;
		}
	}

	// Token: 0x040027B1 RID: 10161
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <TagName>k__BackingField;
}
