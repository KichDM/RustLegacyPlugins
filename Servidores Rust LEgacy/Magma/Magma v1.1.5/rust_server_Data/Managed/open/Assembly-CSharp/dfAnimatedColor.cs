using System;
using UnityEngine;

// Token: 0x02000884 RID: 2180
public class dfAnimatedColor : global::dfAnimatedValue<global::UnityEngine.Color>
{
	// Token: 0x06004B5F RID: 19295 RVA: 0x0011BD38 File Offset: 0x00119F38
	public dfAnimatedColor(global::UnityEngine.Color StartValue, global::UnityEngine.Color EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B60 RID: 19296 RVA: 0x0011BD44 File Offset: 0x00119F44
	protected override global::UnityEngine.Color Lerp(global::UnityEngine.Color startValue, global::UnityEngine.Color endValue, float time)
	{
		return global::UnityEngine.Color.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B61 RID: 19297 RVA: 0x0011BD50 File Offset: 0x00119F50
	public static implicit operator global::dfAnimatedColor(global::UnityEngine.Color value)
	{
		return new global::dfAnimatedColor(value, value, 0f);
	}
}
