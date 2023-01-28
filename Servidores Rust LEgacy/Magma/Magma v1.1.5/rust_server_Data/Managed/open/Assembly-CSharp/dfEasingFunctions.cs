using System;
using UnityEngine;

// Token: 0x02000887 RID: 2183
public class dfEasingFunctions
{
	// Token: 0x06004B73 RID: 19315 RVA: 0x0011BEEC File Offset: 0x0011A0EC
	public dfEasingFunctions()
	{
	}

	// Token: 0x06004B74 RID: 19316 RVA: 0x0011BEF4 File Offset: 0x0011A0F4
	public static global::dfEasingFunctions.EasingFunction GetFunction(global::dfEasingType easeType)
	{
		switch (easeType)
		{
		case global::dfEasingType.Linear:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.linear);
		case global::dfEasingType.Bounce:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.bounce);
		case global::dfEasingType.BackEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInBack);
		case global::dfEasingType.BackEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutBack);
		case global::dfEasingType.BackEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutBack);
		case global::dfEasingType.CircEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInCirc);
		case global::dfEasingType.CircEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutCirc);
		case global::dfEasingType.CircEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutCirc);
		case global::dfEasingType.CubicEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInCubic);
		case global::dfEasingType.CubicEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutCubic);
		case global::dfEasingType.CubicEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutCubic);
		case global::dfEasingType.ExpoEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInExpo);
		case global::dfEasingType.ExpoEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutExpo);
		case global::dfEasingType.ExpoEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutExpo);
		case global::dfEasingType.QuadEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInQuad);
		case global::dfEasingType.QuadEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutQuad);
		case global::dfEasingType.QuadEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutQuad);
		case global::dfEasingType.QuartEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInQuart);
		case global::dfEasingType.QuartEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutQuart);
		case global::dfEasingType.QuartEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutQuart);
		case global::dfEasingType.QuintEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInQuint);
		case global::dfEasingType.QuintEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutQuint);
		case global::dfEasingType.QuintEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutQuint);
		case global::dfEasingType.SineEaseIn:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInSine);
		case global::dfEasingType.SineEaseOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeOutSine);
		case global::dfEasingType.SineEaseInOut:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.easeInOutSine);
		case global::dfEasingType.Spring:
			return new global::dfEasingFunctions.EasingFunction(global::dfEasingFunctions.spring);
		default:
			throw new global::System.NotImplementedException();
		}
	}

	// Token: 0x06004B75 RID: 19317 RVA: 0x0011C0E0 File Offset: 0x0011A2E0
	private static float linear(float start, float end, float time)
	{
		return global::UnityEngine.Mathf.Lerp(start, end, time);
	}

	// Token: 0x06004B76 RID: 19318 RVA: 0x0011C0EC File Offset: 0x0011A2EC
	private static float clerp(float start, float end, float time)
	{
		float num = 0f;
		float num2 = 360f;
		float num3 = global::UnityEngine.Mathf.Abs((num2 - num) / 2f);
		float result;
		if (end - start < -num3)
		{
			float num4 = (num2 - start + end) * time;
			result = start + num4;
		}
		else if (end - start > num3)
		{
			float num4 = -(num2 - end + start) * time;
			result = start + num4;
		}
		else
		{
			result = start + (end - start) * time;
		}
		return result;
	}

	// Token: 0x06004B77 RID: 19319 RVA: 0x0011C164 File Offset: 0x0011A364
	private static float spring(float start, float end, float time)
	{
		time = global::UnityEngine.Mathf.Clamp01(time);
		time = (global::UnityEngine.Mathf.Sin(time * 3.1415927f * (0.2f + 2.5f * time * time * time)) * global::UnityEngine.Mathf.Pow(1f - time, 2.2f) + time) * (1f + 1.2f * (1f - time));
		return start + (end - start) * time;
	}

	// Token: 0x06004B78 RID: 19320 RVA: 0x0011C1C8 File Offset: 0x0011A3C8
	private static float easeInQuad(float start, float end, float time)
	{
		end -= start;
		return end * time * time + start;
	}

	// Token: 0x06004B79 RID: 19321 RVA: 0x0011C1D8 File Offset: 0x0011A3D8
	private static float easeOutQuad(float start, float end, float time)
	{
		end -= start;
		return -end * time * (time - 2f) + start;
	}

	// Token: 0x06004B7A RID: 19322 RVA: 0x0011C1F0 File Offset: 0x0011A3F0
	private static float easeInOutQuad(float start, float end, float time)
	{
		time /= 0.5f;
		end -= start;
		if (time < 1f)
		{
			return end / 2f * time * time + start;
		}
		time -= 1f;
		return -end / 2f * (time * (time - 2f) - 1f) + start;
	}

	// Token: 0x06004B7B RID: 19323 RVA: 0x0011C248 File Offset: 0x0011A448
	private static float easeInCubic(float start, float end, float time)
	{
		end -= start;
		return end * time * time * time + start;
	}

	// Token: 0x06004B7C RID: 19324 RVA: 0x0011C258 File Offset: 0x0011A458
	private static float easeOutCubic(float start, float end, float time)
	{
		time -= 1f;
		end -= start;
		return end * (time * time * time + 1f) + start;
	}

	// Token: 0x06004B7D RID: 19325 RVA: 0x0011C278 File Offset: 0x0011A478
	private static float easeInOutCubic(float start, float end, float time)
	{
		time /= 0.5f;
		end -= start;
		if (time < 1f)
		{
			return end / 2f * time * time * time + start;
		}
		time -= 2f;
		return end / 2f * (time * time * time + 2f) + start;
	}

	// Token: 0x06004B7E RID: 19326 RVA: 0x0011C2CC File Offset: 0x0011A4CC
	private static float easeInQuart(float start, float end, float time)
	{
		end -= start;
		return end * time * time * time * time + start;
	}

	// Token: 0x06004B7F RID: 19327 RVA: 0x0011C2E0 File Offset: 0x0011A4E0
	private static float easeOutQuart(float start, float end, float time)
	{
		time -= 1f;
		end -= start;
		return -end * (time * time * time * time - 1f) + start;
	}

	// Token: 0x06004B80 RID: 19328 RVA: 0x0011C310 File Offset: 0x0011A510
	private static float easeInOutQuart(float start, float end, float time)
	{
		time /= 0.5f;
		end -= start;
		if (time < 1f)
		{
			return end / 2f * time * time * time * time + start;
		}
		time -= 2f;
		return -end / 2f * (time * time * time * time - 2f) + start;
	}

	// Token: 0x06004B81 RID: 19329 RVA: 0x0011C36C File Offset: 0x0011A56C
	private static float easeInQuint(float start, float end, float time)
	{
		end -= start;
		return end * time * time * time * time * time + start;
	}

	// Token: 0x06004B82 RID: 19330 RVA: 0x0011C380 File Offset: 0x0011A580
	private static float easeOutQuint(float start, float end, float time)
	{
		time -= 1f;
		end -= start;
		return end * (time * time * time * time * time + 1f) + start;
	}

	// Token: 0x06004B83 RID: 19331 RVA: 0x0011C3A4 File Offset: 0x0011A5A4
	private static float easeInOutQuint(float start, float end, float time)
	{
		time /= 0.5f;
		end -= start;
		if (time < 1f)
		{
			return end / 2f * time * time * time * time * time + start;
		}
		time -= 2f;
		return end / 2f * (time * time * time * time * time + 2f) + start;
	}

	// Token: 0x06004B84 RID: 19332 RVA: 0x0011C400 File Offset: 0x0011A600
	private static float easeInSine(float start, float end, float time)
	{
		end -= start;
		return -end * global::UnityEngine.Mathf.Cos(time / 1f * 1.5707964f) + end + start;
	}

	// Token: 0x06004B85 RID: 19333 RVA: 0x0011C420 File Offset: 0x0011A620
	private static float easeOutSine(float start, float end, float time)
	{
		end -= start;
		return end * global::UnityEngine.Mathf.Sin(time / 1f * 1.5707964f) + start;
	}

	// Token: 0x06004B86 RID: 19334 RVA: 0x0011C440 File Offset: 0x0011A640
	private static float easeInOutSine(float start, float end, float time)
	{
		end -= start;
		return -end / 2f * (global::UnityEngine.Mathf.Cos(3.1415927f * time / 1f) - 1f) + start;
	}

	// Token: 0x06004B87 RID: 19335 RVA: 0x0011C478 File Offset: 0x0011A678
	private static float easeInExpo(float start, float end, float time)
	{
		end -= start;
		return end * global::UnityEngine.Mathf.Pow(2f, 10f * (time / 1f - 1f)) + start;
	}

	// Token: 0x06004B88 RID: 19336 RVA: 0x0011C4AC File Offset: 0x0011A6AC
	private static float easeOutExpo(float start, float end, float time)
	{
		end -= start;
		return end * (-global::UnityEngine.Mathf.Pow(2f, -10f * time / 1f) + 1f) + start;
	}

	// Token: 0x06004B89 RID: 19337 RVA: 0x0011C4D8 File Offset: 0x0011A6D8
	private static float easeInOutExpo(float start, float end, float time)
	{
		time /= 0.5f;
		end -= start;
		if (time < 1f)
		{
			return end / 2f * global::UnityEngine.Mathf.Pow(2f, 10f * (time - 1f)) + start;
		}
		time -= 1f;
		return end / 2f * (-global::UnityEngine.Mathf.Pow(2f, -10f * time) + 2f) + start;
	}

	// Token: 0x06004B8A RID: 19338 RVA: 0x0011C54C File Offset: 0x0011A74C
	private static float easeInCirc(float start, float end, float time)
	{
		end -= start;
		return -end * (global::UnityEngine.Mathf.Sqrt(1f - time * time) - 1f) + start;
	}

	// Token: 0x06004B8B RID: 19339 RVA: 0x0011C56C File Offset: 0x0011A76C
	private static float easeOutCirc(float start, float end, float time)
	{
		time -= 1f;
		end -= start;
		return end * global::UnityEngine.Mathf.Sqrt(1f - time * time) + start;
	}

	// Token: 0x06004B8C RID: 19340 RVA: 0x0011C59C File Offset: 0x0011A79C
	private static float easeInOutCirc(float start, float end, float time)
	{
		time /= 0.5f;
		end -= start;
		if (time < 1f)
		{
			return -end / 2f * (global::UnityEngine.Mathf.Sqrt(1f - time * time) - 1f) + start;
		}
		time -= 2f;
		return end / 2f * (global::UnityEngine.Mathf.Sqrt(1f - time * time) + 1f) + start;
	}

	// Token: 0x06004B8D RID: 19341 RVA: 0x0011C60C File Offset: 0x0011A80C
	private static float bounce(float start, float end, float time)
	{
		time /= 1f;
		end -= start;
		if (time < 0.36363637f)
		{
			return end * (7.5625f * time * time) + start;
		}
		if (time < 0.72727275f)
		{
			time -= 0.54545456f;
			return end * (7.5625f * time * time + 0.75f) + start;
		}
		if ((double)time < 0.9090909090909091)
		{
			time -= 0.8181818f;
			return end * (7.5625f * time * time + 0.9375f) + start;
		}
		time -= 0.95454544f;
		return end * (7.5625f * time * time + 0.984375f) + start;
	}

	// Token: 0x06004B8E RID: 19342 RVA: 0x0011C6B4 File Offset: 0x0011A8B4
	private static float easeInBack(float start, float end, float time)
	{
		end -= start;
		time /= 1f;
		float num = 1.70158f;
		return end * time * time * ((num + 1f) * time - num) + start;
	}

	// Token: 0x06004B8F RID: 19343 RVA: 0x0011C6E8 File Offset: 0x0011A8E8
	private static float easeOutBack(float start, float end, float time)
	{
		float num = 1.70158f;
		end -= start;
		time = time / 1f - 1f;
		return end * (time * time * ((num + 1f) * time + num) + 1f) + start;
	}

	// Token: 0x06004B90 RID: 19344 RVA: 0x0011C728 File Offset: 0x0011A928
	private static float easeInOutBack(float start, float end, float time)
	{
		float num = 1.70158f;
		end -= start;
		time /= 0.5f;
		if (time < 1f)
		{
			num *= 1.525f;
			return end / 2f * (time * time * ((num + 1f) * time - num)) + start;
		}
		time -= 2f;
		num *= 1.525f;
		return end / 2f * (time * time * ((num + 1f) * time + num) + 2f) + start;
	}

	// Token: 0x06004B91 RID: 19345 RVA: 0x0011C7A8 File Offset: 0x0011A9A8
	private static float punch(float amplitude, float time)
	{
		if (time == 0f)
		{
			return 0f;
		}
		if (time == 1f)
		{
			return 0f;
		}
		float num = 0.3f;
		float num2 = num / 6.2831855f * global::UnityEngine.Mathf.Asin(0f);
		return amplitude * global::UnityEngine.Mathf.Pow(2f, -10f * time) * global::UnityEngine.Mathf.Sin((time * 1f - num2) * 6.2831855f / num);
	}

	// Token: 0x02000888 RID: 2184
	// (Invoke) Token: 0x06004B93 RID: 19347
	public delegate float EasingFunction(float start, float end, float time);
}
