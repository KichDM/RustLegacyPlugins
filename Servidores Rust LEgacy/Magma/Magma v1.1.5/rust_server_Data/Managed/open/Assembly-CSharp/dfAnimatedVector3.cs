using System;
using UnityEngine;

// Token: 0x02000880 RID: 2176
public class dfAnimatedVector3 : global::dfAnimatedValue<global::UnityEngine.Vector3>
{
	// Token: 0x06004B53 RID: 19283 RVA: 0x0011BC98 File Offset: 0x00119E98
	public dfAnimatedVector3(global::UnityEngine.Vector3 StartValue, global::UnityEngine.Vector3 EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B54 RID: 19284 RVA: 0x0011BCA4 File Offset: 0x00119EA4
	protected override global::UnityEngine.Vector3 Lerp(global::UnityEngine.Vector3 startValue, global::UnityEngine.Vector3 endValue, float time)
	{
		return global::UnityEngine.Vector3.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B55 RID: 19285 RVA: 0x0011BCB0 File Offset: 0x00119EB0
	public static implicit operator global::dfAnimatedVector3(global::UnityEngine.Vector3 value)
	{
		return new global::dfAnimatedVector3(value, value, 0f);
	}
}
