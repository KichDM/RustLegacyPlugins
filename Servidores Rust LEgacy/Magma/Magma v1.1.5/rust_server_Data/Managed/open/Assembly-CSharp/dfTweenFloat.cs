using System;
using UnityEngine;

// Token: 0x02000892 RID: 2194
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Float")]
public class dfTweenFloat : global::dfTweenComponent<float>
{
	// Token: 0x06004BF4 RID: 19444 RVA: 0x0011D9E4 File Offset: 0x0011BBE4
	public dfTweenFloat()
	{
	}

	// Token: 0x06004BF5 RID: 19445 RVA: 0x0011D9EC File Offset: 0x0011BBEC
	public override float offset(float lhs, float rhs)
	{
		return lhs + rhs;
	}

	// Token: 0x06004BF6 RID: 19446 RVA: 0x0011D9F4 File Offset: 0x0011BBF4
	public override float evaluate(float startValue, float endValue, float time)
	{
		return startValue + (endValue - startValue) * time;
	}
}
