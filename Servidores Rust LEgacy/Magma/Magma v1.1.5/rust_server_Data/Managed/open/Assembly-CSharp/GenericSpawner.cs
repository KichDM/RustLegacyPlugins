using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005FE RID: 1534
public class GenericSpawner : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600313F RID: 12607 RVA: 0x000BC7E0 File Offset: 0x000BA9E0
	public GenericSpawner()
	{
	}

	// Token: 0x06003140 RID: 12608 RVA: 0x000BC800 File Offset: 0x000BAA00
	// Note: this type is marked as 'beforefieldinit'.
	static GenericSpawner()
	{
	}

	// Token: 0x06003141 RID: 12609 RVA: 0x000BC804 File Offset: 0x000BAA04
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.3f, 0.3f, 1f, 0.5f);
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.radius);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x06003142 RID: 12610 RVA: 0x000BC870 File Offset: 0x000BAA70
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.radius);
	}

	// Token: 0x06003143 RID: 12611 RVA: 0x000BC8A0 File Offset: 0x000BAAA0
	private void OnServerLoad()
	{
		if (this.spawnListObjectOverride != null)
		{
			this._spawnList = this.spawnListObjectOverride.GetCopy();
		}
		this.initialSpawn = true;
		this.initialSpawn = false;
		base.InvokeRepeating("SpawnThink", this.thinkDelay + global::GenericSpawner.spawnStagger, this.thinkDelay);
		base.Invoke("SpawnThink", 5f + global::GenericSpawner.spawnStagger);
		global::GenericSpawner.spawnStagger += global::UnityEngine.Random.Range(1f, 2f);
	}

	// Token: 0x06003144 RID: 12612 RVA: 0x000BC92C File Offset: 0x000BAB2C
	public void SpawnThink()
	{
		foreach (global::GenericSpawnerSpawnList.GenericSpawnInstance genericSpawnInstance in this._spawnList)
		{
			int num = genericSpawnInstance.targetPopulation - genericSpawnInstance.GetNumActive();
			if (num > 0)
			{
				num = ((!this.initialSpawn) ? global::UnityEngine.Random.Range(1, global::UnityEngine.Mathf.Min(num, genericSpawnInstance.numToSpawnPerTick) + 1) : genericSpawnInstance.targetPopulation);
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						this.SpawnGeneric(genericSpawnInstance);
					}
				}
			}
		}
	}

	// Token: 0x06003145 RID: 12613 RVA: 0x000BC9F4 File Offset: 0x000BABF4
	public global::UnityEngine.GameObject SpawnGeneric(global::GenericSpawnerSpawnList.GenericSpawnInstance inst)
	{
		bool flag = false;
		int num = 0;
		while (!flag && num < 0xF)
		{
			global::UnityEngine.Vector3 startPos = base.transform.position + global::UnityEngine.Random.insideUnitSphere * this.radius;
			startPos.y = base.transform.position.y;
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(new global::UnityEngine.Vector3(0f, global::UnityEngine.Random.Range(0f, 360f), 0f));
			global::UnityEngine.Vector3 vector;
			if (inst.useNavmeshSample && global::TransformHelpers.GetGroundInfoNavMesh(startPos, out vector, 15f, -1))
			{
				startPos = vector;
			}
			global::UnityEngine.Vector3 position;
			global::UnityEngine.Vector3 up;
			if (global::TransformHelpers.GetGroundInfoTerrainOnly(startPos, 300f, out position, out up))
			{
				position.y += 0.05f;
				quaternion = global::TransformHelpers.LookRotationForcedUp(quaternion * global::UnityEngine.Vector3.forward, up);
				global::UnityEngine.GameObject gameObject;
				if (inst.forceStaticInstantiate || inst.prefabName.StartsWith(";"))
				{
					gameObject = global::NetCull.InstantiateStatic(inst.prefabName, position, quaternion);
				}
				else
				{
					gameObject = global::NetCull.InstantiateDynamic(inst.prefabName, position, quaternion);
				}
				if (gameObject)
				{
					inst.spawned.Add(gameObject);
					gameObject.SendMessage("SetSpawner", base.gameObject);
				}
				return gameObject;
			}
		}
		if (!flag)
		{
			global::UnityEngine.Debug.Log("ERROR! Giving up spawning of instance :" + inst.prefabName);
		}
		return null;
	}

	// Token: 0x06003146 RID: 12614 RVA: 0x000BCB6C File Offset: 0x000BAD6C
	public void WasKilled(global::UnityEngine.GameObject obj)
	{
		foreach (global::GenericSpawnerSpawnList.GenericSpawnInstance genericSpawnInstance in this._spawnList)
		{
			foreach (global::UnityEngine.GameObject gameObject in genericSpawnInstance.spawned)
			{
				if (obj == gameObject)
				{
					genericSpawnInstance.spawned.Remove(obj);
					return;
				}
			}
		}
	}

	// Token: 0x04001B68 RID: 7016
	private static float spawnStagger;

	// Token: 0x04001B69 RID: 7017
	public float radius = 40f;

	// Token: 0x04001B6A RID: 7018
	public float thinkDelay = 60f;

	// Token: 0x04001B6B RID: 7019
	public bool initialSpawn;

	// Token: 0x04001B6C RID: 7020
	[global::UnityEngine.SerializeField]
	public global::System.Collections.Generic.List<global::GenericSpawnerSpawnList.GenericSpawnInstance> _spawnList;

	// Token: 0x04001B6D RID: 7021
	public global::GenericSpawnerSpawnList spawnListObjectOverride;
}
