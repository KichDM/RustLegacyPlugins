using System;
using UnityEngine;

// Token: 0x02000345 RID: 837
public interface IStateInterpolatorWithLinearVelocity
{
	// Token: 0x06001C30 RID: 7216
	bool SampleWorldVelocity(double timeStamp, out global::UnityEngine.Vector3 linear);

	// Token: 0x06001C31 RID: 7217
	bool SampleWorldVelocity(out global::UnityEngine.Vector3 linear);
}
