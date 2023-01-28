using System;
using UnityEngine;

// Token: 0x0200089B RID: 2203
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Vector4")]
public class dfTweenVector4 : global::dfTweenComponent<global::UnityEngine.Vector4>
{
	// Token: 0x06004C31 RID: 19505 RVA: 0x0011E2D4 File Offset: 0x0011C4D4
	public dfTweenVector4()
	{
	}

	// Token: 0x06004C32 RID: 19506 RVA: 0x0011E2DC File Offset: 0x0011C4DC
	public override global::UnityEngine.Vector4 offset(global::UnityEngine.Vector4 lhs, global::UnityEngine.Vector4 rhs)
	{
		return lhs + rhs;
	}

	// Token: 0x06004C33 RID: 19507 RVA: 0x0011E2E8 File Offset: 0x0011C4E8
	public override global::UnityEngine.Vector4 evaluate(global::UnityEngine.Vector4 startValue, global::UnityEngine.Vector4 endValue, float time)
	{
		return new global::UnityEngine.Vector4(global::dfTweenComponent<global::UnityEngine.Vector4>.Lerp(startValue.x, endValue.x, time), global::dfTweenComponent<global::UnityEngine.Vector4>.Lerp(startValue.y, endValue.y, time), global::dfTweenComponent<global::UnityEngine.Vector4>.Lerp(startValue.z, endValue.z, time), global::dfTweenComponent<global::UnityEngine.Vector4>.Lerp(startValue.w, endValue.w, time));
	}
}
