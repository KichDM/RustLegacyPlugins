using System;
using UnityEngine;

// Token: 0x020007A2 RID: 1954
public class SceneChildMeshes : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004110 RID: 16656 RVA: 0x000E998C File Offset: 0x000E7B8C
	public SceneChildMeshes()
	{
	}

	// Token: 0x06004111 RID: 16657 RVA: 0x000E9994 File Offset: 0x000E7B94
	private static global::SceneChildMeshes GetMapSingleton(bool canCreate)
	{
		if (!global::SceneChildMeshes.lastFound)
		{
			global::UnityEngine.Object[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::SceneChildMeshes));
			if (array.Length == 0)
			{
				if (canCreate)
				{
					global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("__Scene Child Meshes", new global::System.Type[]
					{
						typeof(global::SceneChildMeshes)
					})
					{
						hideFlags = 1
					};
					global::SceneChildMeshes.lastFound = gameObject.GetComponent<global::SceneChildMeshes>();
				}
			}
			else
			{
				global::SceneChildMeshes.lastFound = (global::SceneChildMeshes)array[0];
			}
		}
		return global::SceneChildMeshes.lastFound;
	}

	// Token: 0x040021E5 RID: 8677
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Mesh[] sceneMeshes;

	// Token: 0x040021E6 RID: 8678
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Mesh[] treeMeshes;

	// Token: 0x040021E7 RID: 8679
	private static global::SceneChildMeshes lastFound;
}
