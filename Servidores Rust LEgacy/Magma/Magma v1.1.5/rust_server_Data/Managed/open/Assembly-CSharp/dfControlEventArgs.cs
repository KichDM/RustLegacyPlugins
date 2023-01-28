using System;
using System.Runtime.CompilerServices;

// Token: 0x020007F8 RID: 2040
public class dfControlEventArgs
{
	// Token: 0x06004425 RID: 17445 RVA: 0x000F942C File Offset: 0x000F762C
	internal dfControlEventArgs(global::dfControl Target)
	{
		this.Source = Target;
	}

	// Token: 0x17000C88 RID: 3208
	// (get) Token: 0x06004426 RID: 17446 RVA: 0x000F943C File Offset: 0x000F763C
	// (set) Token: 0x06004427 RID: 17447 RVA: 0x000F9444 File Offset: 0x000F7644
	public global::dfControl Source
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Source>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Source>k__BackingField = value;
		}
	}

	// Token: 0x17000C89 RID: 3209
	// (get) Token: 0x06004428 RID: 17448 RVA: 0x000F9450 File Offset: 0x000F7650
	// (set) Token: 0x06004429 RID: 17449 RVA: 0x000F9458 File Offset: 0x000F7658
	public bool Used
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Used>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Used>k__BackingField = value;
		}
	}

	// Token: 0x0600442A RID: 17450 RVA: 0x000F9464 File Offset: 0x000F7664
	public void Use()
	{
		this.Used = true;
	}

	// Token: 0x0400245F RID: 9311
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfControl <Source>k__BackingField;

	// Token: 0x04002460 RID: 9312
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <Used>k__BackingField;
}
