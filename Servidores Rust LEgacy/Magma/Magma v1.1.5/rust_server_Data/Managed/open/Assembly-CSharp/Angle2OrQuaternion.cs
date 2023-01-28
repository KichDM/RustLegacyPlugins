using System;
using UnityEngine;

// Token: 0x02000127 RID: 295
public struct Angle2OrQuaternion
{
	// Token: 0x0600074D RID: 1869 RVA: 0x000202CC File Offset: 0x0001E4CC
	public static implicit operator global::Angle2OrQuaternion(global::Angle2 v)
	{
		global::Angle2OrQuaternion result;
		result.quat = v.quat;
		return result;
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x000202E8 File Offset: 0x0001E4E8
	public static implicit operator global::Angle2OrQuaternion(global::UnityEngine.Quaternion v)
	{
		global::Angle2OrQuaternion result;
		result.quat = v;
		return result;
	}

	// Token: 0x040005D5 RID: 1493
	internal global::UnityEngine.Quaternion quat;
}
