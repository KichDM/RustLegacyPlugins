using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SpawnManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060025B8 RID: 9656 RVA: 0x00090270 File Offset: 0x0008E470
	public SpawnManager()
	{
	}

	// Token: 0x060025B9 RID: 9657 RVA: 0x00090278 File Offset: 0x0008E478
	public virtual void AddPlayerSpawn(global::UnityEngine.GameObject spawn)
	{
		global::ServerManagement.Get().AddPlayerSpawn(spawn);
	}

	// Token: 0x060025BA RID: 9658 RVA: 0x00090288 File Offset: 0x0008E488
	public virtual void RemovePlayerSpawn(global::UnityEngine.GameObject spawn)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (serverManagement)
		{
			serverManagement.RemovePlayerSpawn(spawn);
		}
	}

	// Token: 0x060025BB RID: 9659 RVA: 0x000902B0 File Offset: 0x0008E4B0
	private void Awake()
	{
		global::SpawnManager._spawnMan = this;
		this.InstallSpawns();
	}

	// Token: 0x060025BC RID: 9660 RVA: 0x000902C0 File Offset: 0x0008E4C0
	private void InstallSpawns()
	{
		global::SpawnManager._spawnPoints = new global::SpawnManager.SpawnData[base.transform.childCount];
		for (int i = 0; i < base.transform.childCount; i++)
		{
			global::UnityEngine.Transform child = base.transform.GetChild(i);
			global::SpawnManager._spawnPoints[i].pos = child.position;
			global::SpawnManager._spawnPoints[i].rot = child.rotation;
		}
		foreach (object obj in base.transform)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			global::UnityEngine.Object.Destroy(transform.gameObject);
		}
	}

	// Token: 0x060025BD RID: 9661 RVA: 0x000903A0 File Offset: 0x0008E5A0
	private void Update()
	{
	}

	// Token: 0x060025BE RID: 9662 RVA: 0x000903A4 File Offset: 0x0008E5A4
	public static bool RandomizeAndScanSpawnPosition(ref global::UnityEngine.Vector3 pos)
	{
		global::UnityEngine.Vector2 vector = global::UnityEngine.Random.insideUnitCircle * 10f;
		global::UnityEngine.Vector3 vector2;
		global::UnityEngine.Vector3 vector3;
		vector2.x = (vector3.x = pos.x + vector.x);
		vector3.y = pos.y + 2000f;
		vector2.y = pos.y - 500f;
		vector2.z = (vector3.z = pos.z + vector.y);
		global::UnityEngine.RaycastHit raycastHit;
		if (!global::UnityEngine.Physics.Linecast(vector3, vector2, ref raycastHit, 0x80401))
		{
			return false;
		}
		pos = raycastHit.point;
		pos.y += raycastHit.normal.y * 0.25f;
		return true;
	}

	// Token: 0x060025BF RID: 9663 RVA: 0x00090470 File Offset: 0x0008E670
	public static void GetRandomSpawn(out global::UnityEngine.Vector3 pos, out global::UnityEngine.Quaternion rot)
	{
		int num = global::UnityEngine.Random.Range(0, global::SpawnManager._spawnPoints.Length);
		pos = global::SpawnManager._spawnPoints[num].pos;
		rot = global::SpawnManager._spawnPoints[num].rot;
		global::SpawnManager.RandomizeAndScanSpawnPosition(ref pos);
	}

	// Token: 0x060025C0 RID: 9664 RVA: 0x000904C0 File Offset: 0x0008E6C0
	public static void GetClosestSpawn(global::UnityEngine.Vector3 point, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Quaternion rot)
	{
		float num = float.PositiveInfinity;
		int num2 = -1;
		for (int i = 0; i < global::SpawnManager._spawnPoints.Length; i++)
		{
			global::UnityEngine.Vector3 vector;
			vector.x = point.x - global::SpawnManager._spawnPoints[i].pos.x;
			vector.y = point.y - global::SpawnManager._spawnPoints[i].pos.y;
			vector.z = point.z - global::SpawnManager._spawnPoints[i].pos.z;
			float num3 = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
			if (num3 < num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num2 == -1)
		{
			global::SpawnManager.GetRandomSpawn(out pos, out rot);
		}
		else
		{
			pos = global::SpawnManager._spawnPoints[num2].pos;
			rot = global::SpawnManager._spawnPoints[num2].rot;
		}
		global::SpawnManager.RandomizeAndScanSpawnPosition(ref pos);
	}

	// Token: 0x060025C1 RID: 9665 RVA: 0x000905E0 File Offset: 0x0008E7E0
	public static void GetCloseSpawn(global::UnityEngine.Vector3 point, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Quaternion rot)
	{
		float num = float.PositiveInfinity;
		int num2 = -1;
		for (int i = 0; i < global::SpawnManager._spawnPoints.Length; i++)
		{
			global::UnityEngine.Vector3 vector;
			vector.x = point.x - global::SpawnManager._spawnPoints[i].pos.x;
			vector.y = point.y - global::SpawnManager._spawnPoints[i].pos.y;
			vector.z = point.z - global::SpawnManager._spawnPoints[i].pos.z;
			float num3 = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
			if (num3 < num && num3 > 40f)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num2 == -1)
		{
			global::SpawnManager.GetRandomSpawn(out pos, out rot);
		}
		else
		{
			pos = global::SpawnManager._spawnPoints[num2].pos;
			rot = global::SpawnManager._spawnPoints[num2].rot;
		}
		global::SpawnManager.RandomizeAndScanSpawnPosition(ref pos);
	}

	// Token: 0x060025C2 RID: 9666 RVA: 0x0009070C File Offset: 0x0008E90C
	public static void GetFarthestSpawn(global::UnityEngine.Vector3 point, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Quaternion rot)
	{
		float num = float.NegativeInfinity;
		int num2 = -1;
		for (int i = 0; i < global::SpawnManager._spawnPoints.Length; i++)
		{
			global::UnityEngine.Vector3 vector;
			vector.x = point.x - global::SpawnManager._spawnPoints[i].pos.x;
			vector.y = point.y - global::SpawnManager._spawnPoints[i].pos.y;
			vector.z = point.z - global::SpawnManager._spawnPoints[i].pos.z;
			float num3 = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
			if (num3 > num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num2 == -1)
		{
			global::SpawnManager.GetRandomSpawn(out pos, out rot);
		}
		else
		{
			pos = global::SpawnManager._spawnPoints[num2].pos;
			rot = global::SpawnManager._spawnPoints[num2].rot;
		}
		global::SpawnManager.RandomizeAndScanSpawnPosition(ref pos);
	}

	// Token: 0x060025C3 RID: 9667 RVA: 0x0009082C File Offset: 0x0008EA2C
	public global::SpawnManager Get()
	{
		return global::SpawnManager._spawnMan;
	}

	// Token: 0x04001338 RID: 4920
	private const float kRandomizeSpawnRadius = 10f;

	// Token: 0x04001339 RID: 4921
	public static global::SpawnManager.SpawnData[] _spawnPoints;

	// Token: 0x0400133A RID: 4922
	public static global::SpawnManager _spawnMan;

	// Token: 0x0200043C RID: 1084
	public struct SpawnData
	{
		// Token: 0x0400133B RID: 4923
		public global::UnityEngine.Vector3 pos;

		// Token: 0x0400133C RID: 4924
		public global::UnityEngine.Quaternion rot;
	}
}
