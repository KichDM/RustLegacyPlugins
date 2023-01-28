using System;
using UnityEngine;

// Token: 0x02000881 RID: 2177
public class dfAnimatedVector4 : global::dfAnimatedValue<global::UnityEngine.Vector4>
{
	// Token: 0x06004B56 RID: 19286 RVA: 0x0011BCC0 File Offset: 0x00119EC0
	public dfAnimatedVector4(global::UnityEngine.Vector4 StartValue, global::UnityEngine.Vector4 EndValue, float Time) : base(StartValue, EndValue, Time)
	{
	}

	// Token: 0x06004B57 RID: 19287 RVA: 0x0011BCCC File Offset: 0x00119ECC
	protected override global::UnityEngine.Vector4 Lerp(global::UnityEngine.Vector4 startValue, global::UnityEngine.Vector4 endValue, float time)
	{
		return global::UnityEngine.Vector4.Lerp(startValue, endValue, time);
	}

	// Token: 0x06004B58 RID: 19288 RVA: 0x0011BCD8 File Offset: 0x00119ED8
	public static implicit operator global::dfAnimatedVector4(global::UnityEngine.Vector4 value)
	{
		return new global::dfAnimatedVector4(value, value, 0f);
	}
}
