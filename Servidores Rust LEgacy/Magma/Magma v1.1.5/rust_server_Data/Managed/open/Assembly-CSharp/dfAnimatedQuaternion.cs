using System;
using UnityEngine;

// Token: 0x02000883 RID: 2179
public class dfAnimatedQuaternion : global::dfAnimatedValue<global::UnityEngine.Quaternion>
{
	// Token: 0x06004B5C RID: 19292 RVA: 0x0011BD10 File Offset: 0x00119F10
	public dfAnimatedQuaternion(global::UnityEngine.Quaternion StartValue, global::UnityEngine.Quaternion EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B5D RID: 19293 RVA: 0x0011BD1C File Offset: 0x00119F1C
	protected override global::UnityEngine.Quaternion Lerp(global::UnityEngine.Quaternion startValue, global::UnityEngine.Quaternion endValue, float time)
	{
		return global::UnityEngine.Quaternion.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B5E RID: 19294 RVA: 0x0011BD28 File Offset: 0x00119F28
	public static implicit operator global::dfAnimatedQuaternion(global::UnityEngine.Quaternion value)
	{
		return new global::dfAnimatedQuaternion(value, value, 0f);
	}
}
