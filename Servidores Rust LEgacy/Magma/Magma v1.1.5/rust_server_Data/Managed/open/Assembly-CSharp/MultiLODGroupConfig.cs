using System;
using UnityEngine;

// Token: 0x02000604 RID: 1540
public class MultiLODGroupConfig : global::UnityEngine.ScriptableObject
{
	// Token: 0x06003155 RID: 12629 RVA: 0x000BCF00 File Offset: 0x000BB100
	public MultiLODGroupConfig()
	{
	}

	// Token: 0x04001B78 RID: 7032
	public const string LODGroupArray = "a";

	// Token: 0x04001B79 RID: 7033
	public const string LODFractionArray = "l";

	// Token: 0x04001B7A RID: 7034
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.LODGroup[] a;

	// Token: 0x04001B7B RID: 7035
	[global::UnityEngine.SerializeField]
	public float[] l;
}
