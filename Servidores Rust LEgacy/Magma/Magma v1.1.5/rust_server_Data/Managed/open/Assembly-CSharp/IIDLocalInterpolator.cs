using System;
using UnityEngine;

// Token: 0x02000344 RID: 836
internal interface IIDLocalInterpolator
{
	// Token: 0x170007C1 RID: 1985
	// (get) Token: 0x06001C2D RID: 7213
	global::IDMain idMain { get; }

	// Token: 0x170007C2 RID: 1986
	// (get) Token: 0x06001C2E RID: 7214
	global::IDLocal self { get; }

	// Token: 0x06001C2F RID: 7215
	void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp);
}
