using System;
using UnityEngine;

// Token: 0x0200088B RID: 2187
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Color32")]
public class dfTweenColor32 : global::dfTweenComponent<global::UnityEngine.Color32>
{
	// Token: 0x06004B99 RID: 19353 RVA: 0x0011C8AC File Offset: 0x0011AAAC
	public dfTweenColor32()
	{
	}

	// Token: 0x06004B9A RID: 19354 RVA: 0x0011C8B4 File Offset: 0x0011AAB4
	public override global::UnityEngine.Color32 offset(global::UnityEngine.Color32 lhs, global::UnityEngine.Color32 rhs)
	{
		return lhs + rhs;
	}

	// Token: 0x06004B9B RID: 19355 RVA: 0x0011C8CC File Offset: 0x0011AACC
	public override global::UnityEngine.Color32 evaluate(global::UnityEngine.Color32 startValue, global::UnityEngine.Color32 endValue, float time)
	{
		global::UnityEngine.Vector4 vector = startValue;
		global::UnityEngine.Vector4 vector2 = endValue;
		global::UnityEngine.Vector4 vector3;
		vector3..ctor(global::dfTweenComponent<global::UnityEngine.Color32>.Lerp(vector.x, vector2.x, time), global::dfTweenComponent<global::UnityEngine.Color32>.Lerp(vector.y, vector2.y, time), global::dfTweenComponent<global::UnityEngine.Color32>.Lerp(vector.z, vector2.z, time), global::dfTweenComponent<global::UnityEngine.Color32>.Lerp(vector.w, vector2.w, time));
		return vector3;
	}
}
