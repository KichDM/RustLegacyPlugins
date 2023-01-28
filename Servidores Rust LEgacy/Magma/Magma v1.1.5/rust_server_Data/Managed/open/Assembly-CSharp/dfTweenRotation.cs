using System;
using UnityEngine;

// Token: 0x02000898 RID: 2200
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Rotation")]
public class dfTweenRotation : global::dfTweenComponent<global::UnityEngine.Quaternion>
{
	// Token: 0x06004C26 RID: 19494 RVA: 0x0011E168 File Offset: 0x0011C368
	public dfTweenRotation()
	{
	}

	// Token: 0x06004C27 RID: 19495 RVA: 0x0011E170 File Offset: 0x0011C370
	public override global::UnityEngine.Quaternion offset(global::UnityEngine.Quaternion lhs, global::UnityEngine.Quaternion rhs)
	{
		return lhs * rhs;
	}

	// Token: 0x06004C28 RID: 19496 RVA: 0x0011E17C File Offset: 0x0011C37C
	public override global::UnityEngine.Quaternion evaluate(global::UnityEngine.Quaternion startValue, global::UnityEngine.Quaternion endValue, float time)
	{
		global::UnityEngine.Vector3 eulerAngles = startValue.eulerAngles;
		global::UnityEngine.Vector3 eulerAngles2 = endValue.eulerAngles;
		return global::UnityEngine.Quaternion.Euler(global::dfTweenRotation.LerpEuler(eulerAngles, eulerAngles2, time));
	}

	// Token: 0x06004C29 RID: 19497 RVA: 0x0011E1A8 File Offset: 0x0011C3A8
	private static global::UnityEngine.Vector3 LerpEuler(global::UnityEngine.Vector3 startValue, global::UnityEngine.Vector3 endValue, float time)
	{
		return new global::UnityEngine.Vector3(global::dfTweenRotation.LerpAngle(startValue.x, endValue.x, time), global::dfTweenRotation.LerpAngle(startValue.y, endValue.y, time), global::dfTweenRotation.LerpAngle(startValue.z, endValue.z, time));
	}

	// Token: 0x06004C2A RID: 19498 RVA: 0x0011E1F8 File Offset: 0x0011C3F8
	private static float LerpAngle(float startValue, float endValue, float time)
	{
		float num = global::UnityEngine.Mathf.Repeat(endValue - startValue, 360f);
		if (num > 180f)
		{
			num -= 360f;
		}
		return startValue + num * time;
	}
}
