using System;
using UnityEngine;

// Token: 0x020005D6 RID: 1494
public class VMOptics : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060030B7 RID: 12471 RVA: 0x000B98C4 File Offset: 0x000B7AC4
	public VMOptics()
	{
	}

	// Token: 0x060030B8 RID: 12472 RVA: 0x000B98CC File Offset: 0x000B7ACC
	private void OnDrawGizmosSelected()
	{
		this.sightOverride.DrawGizmos("sights");
	}

	// Token: 0x04001A6A RID: 6762
	public global::Socket.CameraSpace sightOverride;
}
