using System;

namespace Facepunch.Procedural
{
	// Token: 0x02000608 RID: 1544
	[global::System.Flags]
	public enum ClockStatus : byte
	{
		// Token: 0x04001B85 RID: 7045
		Elapsed = 1,
		// Token: 0x04001B86 RID: 7046
		WillElapse = 2,
		// Token: 0x04001B87 RID: 7047
		DidElapse = 3,
		// Token: 0x04001B88 RID: 7048
		Negative = 4,
		// Token: 0x04001B89 RID: 7049
		Unset = 0
	}
}
