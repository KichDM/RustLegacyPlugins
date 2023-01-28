using System;
using UnityEngine;

// Token: 0x0200087F RID: 2175
public class dfAnimatedInt : global::dfAnimatedValue<int>
{
	// Token: 0x06004B50 RID: 19280 RVA: 0x0011BC68 File Offset: 0x00119E68
	public dfAnimatedInt(int StartValue, int EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B51 RID: 19281 RVA: 0x0011BC74 File Offset: 0x00119E74
	protected override int Lerp(int startValue, int endValue, float time)
	{
		return global::UnityEngine.Mathf.RoundToInt(global::UnityEngine.Mathf.Lerp((float)startValue, (float)endValue, time));
	}

	// Token: 0x06004B52 RID: 19282 RVA: 0x0011BC88 File Offset: 0x00119E88
	public static implicit operator global::dfAnimatedInt(int value)
	{
		return new global::dfAnimatedInt(value, value, 0f);
	}
}
