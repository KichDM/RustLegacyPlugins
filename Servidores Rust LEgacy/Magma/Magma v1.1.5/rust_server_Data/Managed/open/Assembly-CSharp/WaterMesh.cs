using System;
using UnityEngine;

// Token: 0x020007D0 RID: 2000
public class WaterMesh : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004229 RID: 16937 RVA: 0x000F0728 File Offset: 0x000EE928
	public WaterMesh()
	{
	}

	// Token: 0x0400235B RID: 9051
	public global::WaterMesher root;

	// Token: 0x0400235C RID: 9052
	public float underFlow;

	// Token: 0x0400235D RID: 9053
	public float minDistance = 2f;

	// Token: 0x0400235E RID: 9054
	public int sensitivity = 0x100;

	// Token: 0x0400235F RID: 9055
	public bool smooth;

	// Token: 0x04002360 RID: 9056
	public bool reverseOrder;
}
