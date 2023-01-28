using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020001BE RID: 446
public class Assert
{
	// Token: 0x06000D14 RID: 3348 RVA: 0x000329D0 File Offset: 0x00030BD0
	public Assert()
	{
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x000329D8 File Offset: 0x00030BD8
	[global::System.Diagnostics.Conditional("UNITY_EDITOR")]
	public static void Test(bool comparison, string message = "")
	{
		if (comparison)
		{
			return;
		}
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x000329E4 File Offset: 0x00030BE4
	[global::System.Diagnostics.Conditional("UNITY_EDITOR")]
	public static void Throw(string message = "")
	{
		global::UnityEngine.Debug.LogError(message);
		global::UnityEngine.Debug.Break();
	}
}
