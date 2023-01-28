using System;
using System.Collections;
using UnityEngine;

// Token: 0x020009B3 RID: 2483
public class TreeExplosion : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005355 RID: 21333 RVA: 0x0015E24C File Offset: 0x0015C44C
	public TreeExplosion()
	{
	}

	// Token: 0x06005356 RID: 21334 RVA: 0x0015E26C File Offset: 0x0015C46C
	private void Explode()
	{
		global::UnityEngine.Object.Instantiate(this.Explosion, base.transform.position, global::UnityEngine.Quaternion.identity);
		global::UnityEngine.TerrainData terrainData = global::UnityEngine.Terrain.activeTerrain.terrainData;
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		foreach (global::UnityEngine.TreeInstance treeInstance in terrainData.treeInstances)
		{
			float num = global::UnityEngine.Vector3.Distance(global::UnityEngine.Vector3.Scale(treeInstance.position, terrainData.size) + global::UnityEngine.Terrain.activeTerrain.transform.position, base.transform.position);
			if (num < this.BlastRange)
			{
				global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate(this.DeadReplace, global::UnityEngine.Vector3.Scale(treeInstance.position, terrainData.size) + global::UnityEngine.Terrain.activeTerrain.transform.position, global::UnityEngine.Quaternion.identity) as global::UnityEngine.GameObject;
				gameObject.rigidbody.maxAngularVelocity = 1f;
				gameObject.rigidbody.AddExplosionForce(this.BlastForce, base.transform.position, 20f + this.BlastRange * 5f, -20f);
			}
			else
			{
				arrayList.Add(treeInstance);
			}
		}
		terrainData.treeInstances = (global::UnityEngine.TreeInstance[])arrayList.ToArray(typeof(global::UnityEngine.TreeInstance));
	}

	// Token: 0x06005357 RID: 21335 RVA: 0x0015E3C8 File Offset: 0x0015C5C8
	private void Update()
	{
		if (global::UnityEngine.Input.GetButtonDown("Fire1"))
		{
			this.Explode();
		}
	}

	// Token: 0x040030E1 RID: 12513
	public float BlastRange = 30f;

	// Token: 0x040030E2 RID: 12514
	public float BlastForce = 30000f;

	// Token: 0x040030E3 RID: 12515
	public global::UnityEngine.GameObject DeadReplace;

	// Token: 0x040030E4 RID: 12516
	public global::UnityEngine.GameObject Explosion;
}
