using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000062 RID: 98
public class TreeColliderAdd : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060002C9 RID: 713 RVA: 0x0000E010 File Offset: 0x0000C210
	public TreeColliderAdd()
	{
	}

	// Token: 0x060002CA RID: 714 RVA: 0x0000E024 File Offset: 0x0000C224
	private void Start()
	{
		this.terrainData = this.terrain.terrainData;
		this.lastPos = base.transform.position;
		this.treeColliderPool = new global::System.Collections.Generic.List<global::UnityEngine.GameObject>();
		this.usedCollidersPool = new global::System.Collections.Generic.List<global::UnityEngine.GameObject>();
		this.convertedTreePositions = new global::UnityEngine.Vector3[this.terrainData.treeInstances.Length];
		int num = 0;
		foreach (global::UnityEngine.TreeInstance treeInstance in this.terrainData.treeInstances)
		{
			this.convertedTreePositions[num] = global::UnityEngine.Vector3.Scale(treeInstance.position, this.terrainData.size) + this.terrain.transform.position;
			num++;
		}
		global::UnityEngine.Debug.Log("Tree instances length:" + this.terrainData.treeInstances.Length);
		for (int j = 0; j < this.pooledColliders; j++)
		{
			global::UnityEngine.GameObject item = global::UnityEngine.Object.Instantiate(this.treeColliderPrefab, new global::UnityEngine.Vector3(0f, -20000f, 0f), global::UnityEngine.Quaternion.identity) as global::UnityEngine.GameObject;
			this.treeColliderPool.Add(item);
		}
	}

	// Token: 0x060002CB RID: 715 RVA: 0x0000E168 File Offset: 0x0000C368
	public global::UnityEngine.GameObject GetFreeTreeCollider()
	{
		if (this.treeColliderPool.Count > 0)
		{
			global::UnityEngine.GameObject result = this.treeColliderPool[0];
			this.treeColliderPool.RemoveAt(0);
			return result;
		}
		return null;
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
	private void Update()
	{
		global::UnityEngine.Vector3 position = base.transform.position;
		if (global::UnityEngine.Vector3.Distance(position, this.lastPos) >= 100f)
		{
			this.AddNewColliders();
			this.lastPos = position;
		}
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0000E1E0 File Offset: 0x0000C3E0
	private void CleanupOldColliders()
	{
		foreach (global::UnityEngine.GameObject item in this.usedCollidersPool)
		{
			this.treeColliderPool.Add(item);
		}
		this.usedCollidersPool.Clear();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x0000E258 File Offset: 0x0000C458
	private void AddNewColliders()
	{
		this.CleanupOldColliders();
		global::UnityEngine.Vector3 position = base.transform.position;
		int num = 0;
		int num2 = 0;
		int num3 = this.treeColliderPool.Count;
		int i = 0;
		int num4 = this.convertedTreePositions.Length;
		while (i < num4)
		{
			global::UnityEngine.Vector3 vector;
			vector.x = this.convertedTreePositions[i].x - position.x;
			vector.y = this.convertedTreePositions[i].y - position.y;
			vector.z = this.convertedTreePositions[i].z - position.z;
			float num5 = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
			if (num5 <= 40000f)
			{
				global::UnityEngine.GameObject freeTreeCollider = this.GetFreeTreeCollider();
				if (!freeTreeCollider)
				{
					return;
				}
				global::UnityEngine.Vector3 vector2 = this.convertedTreePositions[i];
				freeTreeCollider.transform.position = vector2;
				this.usedCollidersPool.Add(freeTreeCollider);
				this.convertedTreePositions[i] = this.convertedTreePositions[num2];
				this.convertedTreePositions[num2++] = vector2;
				if (--num3 == 0)
				{
					break;
				}
			}
			num++;
			i++;
		}
	}

	// Token: 0x040001E5 RID: 485
	public global::UnityEngine.Terrain terrain;

	// Token: 0x040001E6 RID: 486
	private global::UnityEngine.TerrainData terrainData;

	// Token: 0x040001E7 RID: 487
	public global::UnityEngine.Vector3 lastPos;

	// Token: 0x040001E8 RID: 488
	public global::UnityEngine.GameObject treeColliderPrefab;

	// Token: 0x040001E9 RID: 489
	private int pooledColliders = 0x1F4;

	// Token: 0x040001EA RID: 490
	private global::System.Collections.Generic.List<global::UnityEngine.GameObject> treeColliderPool;

	// Token: 0x040001EB RID: 491
	private global::System.Collections.Generic.List<global::UnityEngine.GameObject> usedCollidersPool;

	// Token: 0x040001EC RID: 492
	private global::UnityEngine.Vector3[] convertedTreePositions;
}
