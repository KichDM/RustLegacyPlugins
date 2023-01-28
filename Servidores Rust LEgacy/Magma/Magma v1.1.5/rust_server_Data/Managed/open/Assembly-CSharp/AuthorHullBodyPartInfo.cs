using System;
using UnityEngine;

// Token: 0x02000035 RID: 53
[global::System.Serializable]
public class AuthorHullBodyPartInfo
{
	// Token: 0x060001F3 RID: 499 RVA: 0x00009338 File Offset: 0x00007538
	public AuthorHullBodyPartInfo()
	{
	}

	// Token: 0x04000133 RID: 307
	public global::UnityEngine.Transform transform;

	// Token: 0x04000134 RID: 308
	public string rootPath;

	// Token: 0x04000135 RID: 309
	public global::AuthorChHit hit;

	// Token: 0x04000136 RID: 310
	public global::AuthorChJoint joint;
}
