using System;
using UnityEngine;

// Token: 0x020005AE RID: 1454
public static class CurveUtility
{
	// Token: 0x06002FEB RID: 12267 RVA: 0x000B6850 File Offset: 0x000B4A50
	public static float EvaluateClampedTime(this global::UnityEngine.AnimationCurve curve, ref float time, float advance)
	{
		int length = curve.length;
		if (curve.length == 0)
		{
			return 1f;
		}
		if (curve.length == 1)
		{
			return curve.Evaluate(0f);
		}
		if (advance > 0f)
		{
			float time2 = curve[length - 1].time;
			if (time < time2)
			{
				time += advance;
				if (time > time2)
				{
					time = time2;
				}
			}
		}
		else if (advance < 0f)
		{
			float time3 = curve[0].time;
			if (time > time3)
			{
				time += advance;
				if (time < time3)
				{
					time = time3;
				}
			}
		}
		return curve.Evaluate(time);
	}

	// Token: 0x06002FEC RID: 12268 RVA: 0x000B6908 File Offset: 0x000B4B08
	public static float GetEndTime(this global::UnityEngine.AnimationCurve curve)
	{
		if (curve.length == 0)
		{
			return 0f;
		}
		return curve[curve.length - 1].time;
	}

	// Token: 0x06002FED RID: 12269 RVA: 0x000B693C File Offset: 0x000B4B3C
	public static float GetStartTime(this global::UnityEngine.AnimationCurve curve)
	{
		if (curve.length == 0)
		{
			return 0f;
		}
		return curve[0].time;
	}
}
