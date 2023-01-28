using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class BobConfiguration : global::UnityEngine.ScriptableObject
{
	// Token: 0x060017A2 RID: 6050 RVA: 0x00057C88 File Offset: 0x00055E88
	public BobConfiguration()
	{
	}

	// Token: 0x04000C43 RID: 3139
	public global::UnityEngine.Vector3 springConstant = global::UnityEngine.Vector3.one * 5f;

	// Token: 0x04000C44 RID: 3140
	public global::UnityEngine.Vector3 springDampen = global::UnityEngine.Vector3.one * 0.1f;

	// Token: 0x04000C45 RID: 3141
	public float weightMass = 5f;

	// Token: 0x04000C46 RID: 3142
	public float timeScale = 1f;

	// Token: 0x04000C47 RID: 3143
	public global::UnityEngine.Vector3 forceSpeedMultiplier = global::UnityEngine.Vector3.one;

	// Token: 0x04000C48 RID: 3144
	public global::UnityEngine.Vector3 inputForceMultiplier = global::UnityEngine.Vector3.one;

	// Token: 0x04000C49 RID: 3145
	public global::UnityEngine.Vector3 elipsoidRadii = global::UnityEngine.Vector3.one;

	// Token: 0x04000C4A RID: 3146
	public global::UnityEngine.Vector3 maxVelocity = global::UnityEngine.Vector3.one * 20f;

	// Token: 0x04000C4B RID: 3147
	public global::UnityEngine.Vector3 positionDeadzone = new global::UnityEngine.Vector3(0.0001f, 0.0001f, 0.0001f);

	// Token: 0x04000C4C RID: 3148
	public global::UnityEngine.Vector3 rotationDeadzone = new global::UnityEngine.Vector3(0.0001f, 0.0001f, 0.0001f);

	// Token: 0x04000C4D RID: 3149
	public global::UnityEngine.Vector3 angularSpringConstant = global::UnityEngine.Vector3.one * 5f;

	// Token: 0x04000C4E RID: 3150
	public global::UnityEngine.Vector3 angularSpringDampen = global::UnityEngine.Vector3.one * 0.1f;

	// Token: 0x04000C4F RID: 3151
	public float angularWeightMass = 5f;

	// Token: 0x04000C50 RID: 3152
	[global::UnityEngine.SerializeField]
	public global::BobForceCurve[] additionalCurves;

	// Token: 0x04000C51 RID: 3153
	public global::UnityEngine.AnimationCurve allowCurve;

	// Token: 0x04000C52 RID: 3154
	public global::UnityEngine.AnimationCurve forbidCurve;

	// Token: 0x04000C53 RID: 3155
	public float solveRate = 100f;

	// Token: 0x04000C54 RID: 3156
	public global::UnityEngine.Vector3 impulseForceScale = global::UnityEngine.Vector3.one;

	// Token: 0x04000C55 RID: 3157
	public float impulseForceSmooth = 0.02f;

	// Token: 0x04000C56 RID: 3158
	public float impulseForceMaxChangeAcceleration = float.PositiveInfinity;

	// Token: 0x04000C57 RID: 3159
	public global::UnityEngine.Vector3 angularImpulseForceScale = global::UnityEngine.Vector3.one;

	// Token: 0x04000C58 RID: 3160
	public float angleImpulseForceSmooth = 0.02f;

	// Token: 0x04000C59 RID: 3161
	public float angleImpulseForceMaxChangeAcceleration = float.PositiveInfinity;

	// Token: 0x04000C5A RID: 3162
	public float intermitRate = 20f;

	// Token: 0x04000C5B RID: 3163
	public global::BobAntiOutput[] antiOutputs;
}
