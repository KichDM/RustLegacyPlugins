using System;

namespace Facepunch.Attributes
{
	// Token: 0x020004EC RID: 1260
	[global::System.Flags]
	public enum PrefabLookupKinds
	{
		// Token: 0x0400160F RID: 5647
		Controllable = 4,
		// Token: 0x04001610 RID: 5648
		Character = 6,
		// Token: 0x04001611 RID: 5649
		NetMain = 7,
		// Token: 0x04001612 RID: 5650
		NGC = 8,
		// Token: 0x04001613 RID: 5651
		Net = 0xF,
		// Token: 0x04001614 RID: 5652
		Bundled = 0x10,
		// Token: 0x04001615 RID: 5653
		All = 0x1F
	}
}
