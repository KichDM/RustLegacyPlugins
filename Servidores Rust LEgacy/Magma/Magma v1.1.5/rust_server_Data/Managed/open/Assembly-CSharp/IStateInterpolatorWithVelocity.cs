using System;
using UnityEngine;

// Token: 0x02000347 RID: 839
public interface IStateInterpolatorWithVelocity : global::IStateInterpolatorWithLinearVelocity, global::IStateInterpolatorWithAngularVelocity
{
	// Token: 0x06001C34 RID: 7220
	bool SampleWorldVelocity(double timeStamp, out global::UnityEngine.Vector3 linear, out global::Angle2 angular);

	// Token: 0x06001C35 RID: 7221
	bool SampleWorldVelocity(out global::UnityEngine.Vector3 linear, out global::Angle2 angular);
}
