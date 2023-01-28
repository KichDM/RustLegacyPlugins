using System;
using UnityEngine;

// Token: 0x02000568 RID: 1384
public class AdaptiveNearPlane : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EEA RID: 12010 RVA: 0x000B2CB8 File Offset: 0x000B0EB8
	public AdaptiveNearPlane()
	{
	}

	// Token: 0x04001880 RID: 6272
	public float maxNear = 0.65f;

	// Token: 0x04001881 RID: 6273
	public float minNear = 0.22f;

	// Token: 0x04001882 RID: 6274
	public float threshold = 0.05f;

	// Token: 0x04001883 RID: 6275
	public global::UnityEngine.LayerMask ignoreLayers = 0;

	// Token: 0x04001884 RID: 6276
	public global::UnityEngine.LayerMask forceLayers = 0;
}
