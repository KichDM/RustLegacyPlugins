using System;
using UnityEngine;

// Token: 0x02000791 RID: 1937
public class LootableObjectSpawner : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004076 RID: 16502 RVA: 0x000E6970 File Offset: 0x000E4B70
	public LootableObjectSpawner()
	{
	}

	// Token: 0x06004077 RID: 16503 RVA: 0x000E6998 File Offset: 0x000E4B98
	private void Awake()
	{
		if (this._lootableChances == null || this._lootableChances.Length == 0)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
	}

	// Token: 0x06004078 RID: 16504 RVA: 0x000E69CC File Offset: 0x000E4BCC
	private void OnServerLoad()
	{
		if (this.spawnOnStart)
		{
			this.SpawnLootable();
		}
		else
		{
			base.Invoke("SpawnLootable", this.spawnTimeMax * 60f);
		}
	}

	// Token: 0x06004079 RID: 16505 RVA: 0x000E6A08 File Offset: 0x000E4C08
	private global::UnityEngine.GameObject SpawnLootable()
	{
		float num = global::UnityEngine.Random.Range(this.spawnTimeMin, this.spawnTimeMax);
		base.CancelInvoke("SpawnLootable");
		base.Invoke("SpawnLootable", num * 60f);
		if (this._mySpawnedLootable != null)
		{
			return null;
		}
		global::LootableObject lootableObject = global::LootableObjectSpawner.RandomPick(this._lootableChances);
		if (lootableObject == null)
		{
			global::UnityEngine.Debug.Log("MAJOR WTF");
		}
		global::UnityEngine.Vector3 position;
		global::UnityEngine.Vector3 vector;
		base.transform.GetGroundInfo(out position, out vector);
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.LookRotation(vector);
		global::UnityEngine.Quaternion quaternion2 = global::UnityEngine.Quaternion.Inverse(lootableObject.transform.GetChild(0).localRotation);
		global::LootableObject lootableObject2 = global::NetCull.InstantiateStatic<global::LootableObject>(lootableObject, position, quaternion * quaternion2);
		this._mySpawnedLootable = lootableObject2.gameObject;
		return lootableObject2.gameObject;
	}

	// Token: 0x0600407A RID: 16506 RVA: 0x000E6AD0 File Offset: 0x000E4CD0
	public static global::LootableObject RandomPick(global::LootableObjectSpawner.ChancePick[] array)
	{
		float num = 0f;
		foreach (global::LootableObjectSpawner.ChancePick chancePick in array)
		{
			num += chancePick.weight;
		}
		if (num == 0f)
		{
			return null;
		}
		float num2 = global::UnityEngine.Random.Range(0f, num);
		foreach (global::LootableObjectSpawner.ChancePick chancePick2 in array)
		{
			if ((num2 -= chancePick2.weight) <= 0f)
			{
				return chancePick2.obj;
			}
		}
		return array[array.Length - 1].obj;
	}

	// Token: 0x0600407B RID: 16507 RVA: 0x000E6B70 File Offset: 0x000E4D70
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawSphere(base.transform.position, 0.5f);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
		global::UnityEngine.Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1f);
	}

	// Token: 0x0600407C RID: 16508 RVA: 0x000E6BDC File Offset: 0x000E4DDC
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawSphere(base.transform.position, 0.5f);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
		global::UnityEngine.Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1f);
	}

	// Token: 0x04002197 RID: 8599
	public global::LootableObjectSpawner.ChancePick[] _lootableChances;

	// Token: 0x04002198 RID: 8600
	public bool spawnOnStart = true;

	// Token: 0x04002199 RID: 8601
	public float spawnTimeMin = 5f;

	// Token: 0x0400219A RID: 8602
	public float spawnTimeMax = 10f;

	// Token: 0x0400219B RID: 8603
	[global::System.NonSerialized]
	private global::UnityEngine.GameObject _mySpawnedLootable;

	// Token: 0x02000792 RID: 1938
	[global::System.Serializable]
	public class ChancePick
	{
		// Token: 0x0600407D RID: 16509 RVA: 0x000E6C48 File Offset: 0x000E4E48
		public ChancePick()
		{
		}

		// Token: 0x0400219C RID: 8604
		public global::LootableObject obj;

		// Token: 0x0400219D RID: 8605
		public float weight;
	}
}
