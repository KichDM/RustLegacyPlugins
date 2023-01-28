using System;
using UnityEngine;

// Token: 0x020005C4 RID: 1476
public class ModelPrefabSkin : global::UnityEngine.ScriptableObject
{
	// Token: 0x0600306C RID: 12396 RVA: 0x000B86BC File Offset: 0x000B68BC
	public ModelPrefabSkin()
	{
	}

	// Token: 0x04001A1B RID: 6683
	public string prefab;

	// Token: 0x04001A1C RID: 6684
	public global::ModelPrefabSkin.Part[] parts;

	// Token: 0x04001A1D RID: 6685
	public bool once;

	// Token: 0x04001A1E RID: 6686
	[global::System.NonSerialized]
	public object editorData;

	// Token: 0x020005C5 RID: 1477
	[global::System.Serializable]
	public class Part
	{
		// Token: 0x0600306D RID: 12397 RVA: 0x000B86C4 File Offset: 0x000B68C4
		public Part()
		{
			this.path = string.Empty;
			this.mesh = string.Empty;
		}

		// Token: 0x04001A1F RID: 6687
		public string path;

		// Token: 0x04001A20 RID: 6688
		public string mesh;

		// Token: 0x04001A21 RID: 6689
		public string[] materials;
	}
}
