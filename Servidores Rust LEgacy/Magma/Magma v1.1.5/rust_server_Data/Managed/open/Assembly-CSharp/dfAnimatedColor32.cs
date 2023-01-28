using System;
using UnityEngine;

// Token: 0x02000885 RID: 2181
public class dfAnimatedColor32 : global::dfAnimatedValue<global::UnityEngine.Color32>
{
	// Token: 0x06004B62 RID: 19298 RVA: 0x0011BD60 File Offset: 0x00119F60
	public dfAnimatedColor32(global::UnityEngine.Color32 StartValue, global::UnityEngine.Color32 EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B63 RID: 19299 RVA: 0x0011BD6C File Offset: 0x00119F6C
	protected override global::UnityEngine.Color32 Lerp(global::UnityEngine.Color32 startValue, global::UnityEngine.Color32 endValue, float time)
	{
		return global::UnityEngine.Color.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B64 RID: 19300 RVA: 0x0011BD88 File Offset: 0x00119F88
	public static implicit operator global::dfAnimatedColor32(global::UnityEngine.Color32 value)
	{
		return new global::dfAnimatedColor32(value, value, 0f);
	}
}
