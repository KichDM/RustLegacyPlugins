using System;
using System.Runtime.CompilerServices;

// Token: 0x02000867 RID: 2151
public class dfMarkupAttribute
{
	// Token: 0x06004A9D RID: 19101 RVA: 0x00118838 File Offset: 0x00116A38
	public dfMarkupAttribute(string name, string value)
	{
		this.Name = name;
		this.Value = value;
	}

	// Token: 0x17000DF8 RID: 3576
	// (get) Token: 0x06004A9E RID: 19102 RVA: 0x00118850 File Offset: 0x00116A50
	// (set) Token: 0x06004A9F RID: 19103 RVA: 0x00118858 File Offset: 0x00116A58
	public string Name
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Name>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Name>k__BackingField = value;
		}
	}

	// Token: 0x17000DF9 RID: 3577
	// (get) Token: 0x06004AA0 RID: 19104 RVA: 0x00118864 File Offset: 0x00116A64
	// (set) Token: 0x06004AA1 RID: 19105 RVA: 0x0011886C File Offset: 0x00116A6C
	public string Value
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x06004AA2 RID: 19106 RVA: 0x00118878 File Offset: 0x00116A78
	public override string ToString()
	{
		return string.Format("{0}='{1}'", this.Name, this.Value);
	}

	// Token: 0x040027B9 RID: 10169
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Name>k__BackingField;

	// Token: 0x040027BA RID: 10170
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Value>k__BackingField;
}
