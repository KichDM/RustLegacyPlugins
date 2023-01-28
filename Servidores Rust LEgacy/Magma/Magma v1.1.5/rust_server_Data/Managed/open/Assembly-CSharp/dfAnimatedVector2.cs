using System;
using UnityEngine;

// Token: 0x02000882 RID: 2178
public class dfAnimatedVector2 : global::dfAnimatedValue<global::UnityEngine.Vector2>
{
	// Token: 0x06004B59 RID: 19289 RVA: 0x0011BCE8 File Offset: 0x00119EE8
	public dfAnimatedVector2(global::UnityEngine.Vector2 StartValue, global::UnityEngine.Vector2 EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B5A RID: 19290 RVA: 0x0011BCF4 File Offset: 0x00119EF4
	protected override global::UnityEngine.Vector2 Lerp(global::UnityEngine.Vector2 startValue, global::UnityEngine.Vector2 endValue, float time)
	{
		return global::UnityEngine.Vector2.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B5B RID: 19291 RVA: 0x0011BD00 File Offset: 0x00119F00
	public static implicit operator global::dfAnimatedVector2(global::UnityEngine.Vector2 value)
	{
		return new global::dfAnimatedVector2(value, value, 0f);
	}
}
