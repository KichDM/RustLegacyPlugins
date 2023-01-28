using System;
using UnityEngine;

// Token: 0x0200087E RID: 2174
public class dfAnimatedFloat : global::dfAnimatedValue<float>
{
	// Token: 0x06004B4D RID: 19277 RVA: 0x0011BC40 File Offset: 0x00119E40
	public dfAnimatedFloat(float StartValue, float EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B4E RID: 19278 RVA: 0x0011BC4C File Offset: 0x00119E4C
	protected override float Lerp(float startValue, float endValue, float time)
	{
		return global::UnityEngine.Mathf.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B4F RID: 19279 RVA: 0x0011BC58 File Offset: 0x00119E58
	public static implicit operator global::dfAnimatedFloat(float value)
	{
		return new global::dfAnimatedFloat(value, value, 0f);
	}
}
