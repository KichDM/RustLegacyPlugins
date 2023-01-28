using System;
using UnityEngine;

// Token: 0x02000899 RID: 2201
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Vector2")]
public class dfTweenVector2 : global::dfTweenComponent<global::UnityEngine.Vector2>
{
	// Token: 0x06004C2B RID: 19499 RVA: 0x0011E22C File Offset: 0x0011C42C
	public dfTweenVector2()
	{
	}

	// Token: 0x06004C2C RID: 19500 RVA: 0x0011E234 File Offset: 0x0011C434
	public override global::UnityEngine.Vector2 offset(global::UnityEngine.Vector2 lhs, global::UnityEngine.Vector2 rhs)
	{
		return lhs + rhs;
	}

	// Token: 0x06004C2D RID: 19501 RVA: 0x0011E240 File Offset: 0x0011C440
	public override global::UnityEngine.Vector2 evaluate(global::UnityEngine.Vector2 startValue, global::UnityEngine.Vector2 endValue, float time)
	{
		return new global::UnityEngine.Vector2(global::dfTweenComponent<global::UnityEngine.Vector2>.Lerp(startValue.x, endValue.x, time), global::dfTweenComponent<global::UnityEngine.Vector2>.Lerp(startValue.y, endValue.y, time));
	}
}
