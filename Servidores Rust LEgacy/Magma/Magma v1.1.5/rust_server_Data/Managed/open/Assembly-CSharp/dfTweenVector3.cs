using System;
using UnityEngine;

// Token: 0x0200089A RID: 2202
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Vector3")]
public class dfTweenVector3 : global::dfTweenComponent<global::UnityEngine.Vector3>
{
	// Token: 0x06004C2E RID: 19502 RVA: 0x0011E270 File Offset: 0x0011C470
	public dfTweenVector3()
	{
	}

	// Token: 0x06004C2F RID: 19503 RVA: 0x0011E278 File Offset: 0x0011C478
	public override global::UnityEngine.Vector3 offset(global::UnityEngine.Vector3 lhs, global::UnityEngine.Vector3 rhs)
	{
		return lhs + rhs;
	}

	// Token: 0x06004C30 RID: 19504 RVA: 0x0011E284 File Offset: 0x0011C484
	public override global::UnityEngine.Vector3 evaluate(global::UnityEngine.Vector3 startValue, global::UnityEngine.Vector3 endValue, float time)
	{
		return new global::UnityEngine.Vector3(global::dfTweenComponent<global::UnityEngine.Vector3>.Lerp(startValue.x, endValue.x, time), global::dfTweenComponent<global::UnityEngine.Vector3>.Lerp(startValue.y, endValue.y, time), global::dfTweenComponent<global::UnityEngine.Vector3>.Lerp(startValue.z, endValue.z, time));
	}
}
