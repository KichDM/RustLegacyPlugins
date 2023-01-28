using System;
using UnityEngine;

// Token: 0x0200083A RID: 2106
public static class dfFloatExtensions
{
	// Token: 0x06004843 RID: 18499 RVA: 0x0010CE34 File Offset: 0x0010B034
	public static float Quantize(this float value, float stepSize)
	{
		if (stepSize <= 0f)
		{
			return value;
		}
		return global::UnityEngine.Mathf.Floor(value / stepSize) * stepSize;
	}

	// Token: 0x06004844 RID: 18500 RVA: 0x0010CE50 File Offset: 0x0010B050
	public static float RoundToNearest(this float value, float stepSize)
	{
		if (stepSize <= 0f)
		{
			return value;
		}
		return (float)global::UnityEngine.Mathf.RoundToInt(value / stepSize) * stepSize;
	}
}
