using System;
using UnityEngine;

// Token: 0x020005C1 RID: 1473
public class CustomMeshMaker : global::UnityEngine.ScriptableObject
{
	// Token: 0x06003068 RID: 12392 RVA: 0x000B85C0 File Offset: 0x000B67C0
	public CustomMeshMaker()
	{
	}

	// Token: 0x04001A0F RID: 6671
	public global::UnityEngine.Vector3[] vertices;

	// Token: 0x04001A10 RID: 6672
	public global::UnityEngine.Vector3[] normals;

	// Token: 0x04001A11 RID: 6673
	public global::UnityEngine.Vector4[] tangents;

	// Token: 0x04001A12 RID: 6674
	public global::UnityEngine.Color[] colors;

	// Token: 0x04001A13 RID: 6675
	public global::UnityEngine.Vector2[] uv1;

	// Token: 0x04001A14 RID: 6676
	public global::UnityEngine.Vector2[] uv2;

	// Token: 0x04001A15 RID: 6677
	public int[] triangles;

	// Token: 0x04001A16 RID: 6678
	public global::UnityEngine.Bounds bounds;

	// Token: 0x04001A17 RID: 6679
	public bool optimize;

	// Token: 0x04001A18 RID: 6680
	public bool autoBound;

	// Token: 0x04001A19 RID: 6681
	public bool autoNormals;

	// Token: 0x04001A1A RID: 6682
	public string output;
}
