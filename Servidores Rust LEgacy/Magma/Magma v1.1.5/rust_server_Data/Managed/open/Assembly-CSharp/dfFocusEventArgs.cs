using System;
using System.Runtime.CompilerServices;

// Token: 0x020007F9 RID: 2041
public class dfFocusEventArgs : global::dfControlEventArgs
{
	// Token: 0x0600442B RID: 17451 RVA: 0x000F9470 File Offset: 0x000F7670
	internal dfFocusEventArgs(global::dfControl GotFocus, global::dfControl LostFocus) : base(GotFocus)
	{
		this.LostFocus = LostFocus;
	}

	// Token: 0x17000C8A RID: 3210
	// (get) Token: 0x0600442C RID: 17452 RVA: 0x000F9480 File Offset: 0x000F7680
	public global::dfControl GotFocus
	{
		get
		{
			return base.Source;
		}
	}

	// Token: 0x17000C8B RID: 3211
	// (get) Token: 0x0600442D RID: 17453 RVA: 0x000F9488 File Offset: 0x000F7688
	// (set) Token: 0x0600442E RID: 17454 RVA: 0x000F9490 File Offset: 0x000F7690
	public global::dfControl LostFocus
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<LostFocus>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<LostFocus>k__BackingField = value;
		}
	}

	// Token: 0x04002461 RID: 9313
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfControl <LostFocus>k__BackingField;
}
