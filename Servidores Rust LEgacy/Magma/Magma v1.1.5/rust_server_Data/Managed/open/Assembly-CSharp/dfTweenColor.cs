using System;
using UnityEngine;

// Token: 0x0200088A RID: 2186
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Color")]
public class dfTweenColor : global::dfTweenComponent<global::UnityEngine.Color>
{
	// Token: 0x06004B96 RID: 19350 RVA: 0x0011C820 File Offset: 0x0011AA20
	public dfTweenColor()
	{
	}

	// Token: 0x06004B97 RID: 19351 RVA: 0x0011C828 File Offset: 0x0011AA28
	public override global::UnityEngine.Color offset(global::UnityEngine.Color lhs, global::UnityEngine.Color rhs)
	{
		return lhs + rhs;
	}

	// Token: 0x06004B98 RID: 19352 RVA: 0x0011C834 File Offset: 0x0011AA34
	public override global::UnityEngine.Color evaluate(global::UnityEngine.Color startValue, global::UnityEngine.Color endValue, float time)
	{
		global::UnityEngine.Vector4 vector = startValue;
		global::UnityEngine.Vector4 vector2 = endValue;
		global::UnityEngine.Vector4 vector3;
		vector3..ctor(global::dfTweenComponent<global::UnityEngine.Color>.Lerp(vector.x, vector2.x, time), global::dfTweenComponent<global::UnityEngine.Color>.Lerp(vector.y, vector2.y, time), global::dfTweenComponent<global::UnityEngine.Color>.Lerp(vector.z, vector2.z, time), global::dfTweenComponent<global::UnityEngine.Color>.Lerp(vector.w, vector2.w, time));
		return vector3;
	}
}
