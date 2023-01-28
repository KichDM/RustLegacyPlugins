using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public struct PosRot
{
	// Token: 0x060025C5 RID: 9669 RVA: 0x0009084C File Offset: 0x0008EA4C
	public static void Lerp(ref global::PosRot a, ref global::PosRot b, float t, out global::PosRot v)
	{
		v.position = global::UnityEngine.Vector3.Lerp(a.position, b.position, t);
		v.rotation = global::UnityEngine.Quaternion.Slerp(a.rotation, b.rotation, t);
	}

	// Token: 0x060025C6 RID: 9670 RVA: 0x0009088C File Offset: 0x0008EA8C
	public static void Lerp(ref global::PosRot a, ref global::PosRot b, double t, out global::PosRot v)
	{
		global::PosRot.Lerp(ref a, ref b, (float)t, out v);
	}

	// Token: 0x04001340 RID: 4928
	public global::UnityEngine.Vector3 position;

	// Token: 0x04001341 RID: 4929
	public global::UnityEngine.Quaternion rotation;
}
