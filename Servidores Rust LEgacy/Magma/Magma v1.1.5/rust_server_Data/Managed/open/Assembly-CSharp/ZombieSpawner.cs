using System;
using uLink;
using UnityEngine;

// Token: 0x0200061B RID: 1563
public class ZombieSpawner : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060031AF RID: 12719 RVA: 0x000BEC74 File Offset: 0x000BCE74
	private ZombieSpawner()
	{
		this.zombiePrefabs = new string[]
		{
			"npc_zombie"
		};
	}

	// Token: 0x060031B0 RID: 12720 RVA: 0x000BECBC File Offset: 0x000BCEBC
	private void OnServerLoad()
	{
		base.InvokeRepeating("SpawnThink", 0f, this.thinkDelay);
	}

	// Token: 0x060031B1 RID: 12721 RVA: 0x000BECD4 File Offset: 0x000BCED4
	private static void zomspawnthink()
	{
		foreach (global::UnityEngine.Object @object in global::UnityEngine.Object.FindObjectsOfType(typeof(global::ZombieSpawner)))
		{
			if (@object)
			{
				((global::ZombieSpawner)@object).SpawnThink();
			}
		}
	}

	// Token: 0x060031B2 RID: 12722 RVA: 0x000BED20 File Offset: 0x000BCF20
	public int GetNumActiveZombies()
	{
		return this.numActiveZombies;
	}

	// Token: 0x060031B3 RID: 12723 RVA: 0x000BED28 File Offset: 0x000BCF28
	public void SpawnThink()
	{
		int num = this.targetPopulation - this.GetNumActiveZombies();
		if (num <= 0)
		{
			return;
		}
		num = global::UnityEngine.Random.Range(0, num + 1);
		if (num > 0)
		{
			int num2 = 0;
			for (int i = 0; i <= num; i++)
			{
				if (!this.SpawnZombie())
				{
					if (this.GetNumActiveZombies() == 0)
					{
						this.exaustCount++;
					}
					if (++num2 >= 4)
					{
						if (this.exaustCount >= 0x64)
						{
							global::UnityEngine.Debug.LogWarning(string.Format("Zombie Spawner {0}({3:X}) at {1} hasn't been able to generate a single zombie over {2} calls to SpawnThink.\r\n\tThe spawner is probably not positioned well enough over a navmesh!", new object[]
							{
								this,
								base.transform.position,
								this.exaustCount,
								base.GetInstanceID()
							}), this);
							this.exaustCount = 0;
						}
						break;
					}
					i--;
				}
				else
				{
					this.exaustCount = 0;
				}
			}
		}
	}

	// Token: 0x060031B4 RID: 12724 RVA: 0x000BEE14 File Offset: 0x000BD014
	public void ZombieDeath()
	{
		this.numActiveZombies--;
	}

	// Token: 0x060031B5 RID: 12725 RVA: 0x000BEE24 File Offset: 0x000BD024
	private bool SpawnZombie(ref global::UnityEngine.Vector3 pos, ref global::UnityEngine.Quaternion rot, out global::Character zombie)
	{
		return this.SpawnZombie(ref pos, ref rot, this.zombiePrefabs[global::UnityEngine.Random.Range(0, this.zombiePrefabs.Length)], out zombie);
	}

	// Token: 0x060031B6 RID: 12726 RVA: 0x000BEE44 File Offset: 0x000BD044
	private bool SpawnZombie(ref global::UnityEngine.Vector3 pos, ref global::UnityEngine.Quaternion rot, string zombiePrefab, out global::Character zombie)
	{
		zombie = global::Character.SummonCharacter(global::uLink.NetworkPlayer.server, zombiePrefab, pos, rot);
		if (zombie)
		{
			zombie.SendMessage("SetSpawner", this);
			this.numActiveZombies++;
			return true;
		}
		zombie = null;
		return false;
	}

	// Token: 0x060031B7 RID: 12727 RVA: 0x000BEEA0 File Offset: 0x000BD0A0
	public bool SpawnZombie(out global::Character zombie)
	{
		return this.SpawnZombie(this.zombiePrefabs[global::UnityEngine.Random.Range(0, this.zombiePrefabs.Length)], out zombie);
	}

	// Token: 0x060031B8 RID: 12728 RVA: 0x000BEEC0 File Offset: 0x000BD0C0
	private int FindSpawnPoint(float random0, float random1, out global::UnityEngine.Vector3 groundPos)
	{
		global::UnityEngine.Vector3 position = base.transform.position;
		float num = random0 * 3.1415927f;
		float num2 = random1 * 2f;
		float num3 = global::UnityEngine.Mathf.Cos(num);
		float num4 = global::UnityEngine.Mathf.Sin(num);
		for (int i = 0; i < 8; i++)
		{
			float num5 = ((num2 + (float)i / 4f) % 2f - 1f) * this.radius;
			global::UnityEngine.Vector3 startPos;
			startPos.y = position.y;
			startPos.x = position.x + num4 * num5;
			startPos.z = position.z + num3 * num5;
			if (global::TransformHelpers.GetGroundInfoNavMesh(startPos, out groundPos))
			{
				return i;
			}
		}
		groundPos.y = position.y;
		groundPos.x = position.x + num4 * (num2 - 1f) * this.radius;
		groundPos.z = position.z + num3 * (num2 - 1f) * this.radius;
		return 8;
	}

	// Token: 0x060031B9 RID: 12729 RVA: 0x000BEFC0 File Offset: 0x000BD1C0
	private bool SpawnZombie(string zombiePrefab, out global::Character zombie)
	{
		global::UnityEngine.Vector3 vector;
		if (this.FindSpawnPoint(global::UnityEngine.Random.value, global::UnityEngine.Random.value, out vector) < 8)
		{
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(0f, global::UnityEngine.Random.value * 360f, 0f);
			return this.SpawnZombie(ref vector, ref quaternion, zombiePrefab, out zombie);
		}
		zombie = null;
		return false;
	}

	// Token: 0x060031BA RID: 12730 RVA: 0x000BF014 File Offset: 0x000BD214
	private bool SpawnZombie()
	{
		global::Character character;
		return this.SpawnZombie(out character);
	}

	// Token: 0x060031BB RID: 12731 RVA: 0x000BF02C File Offset: 0x000BD22C
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.3f, 0.3f, 0.3f, 0.5f);
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.radius);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x04001BCB RID: 7115
	private const int maxAttemptsPerFramePerSpawner = 4;

	// Token: 0x04001BCC RID: 7116
	public string[] zombiePrefabs;

	// Token: 0x04001BCD RID: 7117
	[global::System.NonSerialized]
	private int numActiveZombies;

	// Token: 0x04001BCE RID: 7118
	public int targetPopulation = 0xA;

	// Token: 0x04001BCF RID: 7119
	public float radius = 40f;

	// Token: 0x04001BD0 RID: 7120
	public float thinkDelay = 60f;

	// Token: 0x04001BD1 RID: 7121
	[global::System.NonSerialized]
	private int exaustCount;
}
