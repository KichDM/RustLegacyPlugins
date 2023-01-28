using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class RustLoaderInstantiateOnComplete : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600025F RID: 607 RVA: 0x0000CA80 File Offset: 0x0000AC80
	public RustLoaderInstantiateOnComplete()
	{
	}

	// Token: 0x06000260 RID: 608 RVA: 0x0000CA88 File Offset: 0x0000AC88
	private void OnRustReady()
	{
		if (this.prefabs != null)
		{
			foreach (global::UnityEngine.GameObject gameObject in this.prefabs)
			{
				if (gameObject)
				{
					this.InstantiatePrefab(gameObject);
				}
			}
		}
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0000CAD4 File Offset: 0x0000ACD4
	private void InstantiatePrefab(global::UnityEngine.GameObject prefab)
	{
		try
		{
			global::UnityEngine.Object.Instantiate(prefab).name = prefab.name;
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
		}
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0000CB20 File Offset: 0x0000AD20
	private void Reset()
	{
		global::UnityEngine.Object[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::RustLoader));
		if (array.Length > 0)
		{
			((global::RustLoader)array[0]).AddMessageReceiver(base.gameObject);
		}
	}

	// Token: 0x04000190 RID: 400
	public global::UnityEngine.GameObject[] prefabs;
}
