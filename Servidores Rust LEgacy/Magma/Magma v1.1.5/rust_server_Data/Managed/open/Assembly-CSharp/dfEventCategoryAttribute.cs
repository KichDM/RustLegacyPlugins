using System;
using System.Runtime.CompilerServices;

// Token: 0x020007F7 RID: 2039
[global::System.AttributeUsage(global::System.AttributeTargets.Delegate, Inherited = true, AllowMultiple = false)]
public class dfEventCategoryAttribute : global::System.Attribute
{
	// Token: 0x06004422 RID: 17442 RVA: 0x000F9408 File Offset: 0x000F7608
	public dfEventCategoryAttribute(string category)
	{
		this.Category = category;
	}

	// Token: 0x17000C87 RID: 3207
	// (get) Token: 0x06004423 RID: 17443 RVA: 0x000F9418 File Offset: 0x000F7618
	// (set) Token: 0x06004424 RID: 17444 RVA: 0x000F9420 File Offset: 0x000F7620
	public string Category
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Category>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Category>k__BackingField = value;
		}
	}

	// Token: 0x0400245E RID: 9310
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Category>k__BackingField;
}
