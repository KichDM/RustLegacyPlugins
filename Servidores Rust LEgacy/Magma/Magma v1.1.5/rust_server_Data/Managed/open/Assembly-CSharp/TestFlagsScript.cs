using System;
using UnityEngine;

// Token: 0x020001C5 RID: 453
public class TestFlagsScript : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000D35 RID: 3381 RVA: 0x000340FC File Offset: 0x000322FC
	public TestFlagsScript()
	{
	}

	// Token: 0x04000881 RID: 2177
	public global::TestFlagsScript.E1 flags;

	// Token: 0x020001C6 RID: 454
	[global::System.Flags]
	public enum E1
	{
		// Token: 0x04000883 RID: 2179
		bit1 = 1,
		// Token: 0x04000884 RID: 2180
		bit3 = 4,
		// Token: 0x04000885 RID: 2181
		bit5 = 0x10
	}
}
