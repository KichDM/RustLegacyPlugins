using System;
using UnityEngine;

// Token: 0x02000777 RID: 1911
[global::NGCAutoAddScript]
public class DeployedRespawn : global::DeployableObject
{
	// Token: 0x06003F73 RID: 16243 RVA: 0x000E26FC File Offset: 0x000E08FC
	protected DeployedRespawn() : base(2)
	{
		this.lastSpawnTime = double.NegativeInfinity;
	}

	// Token: 0x06003F74 RID: 16244 RVA: 0x000E2724 File Offset: 0x000E0924
	public override void CreatorSet()
	{
		base.CreatorSet();
		this.AddToManager();
	}

	// Token: 0x06003F75 RID: 16245 RVA: 0x000E2734 File Offset: 0x000E0934
	public void AddToManager()
	{
		global::SpawnManager._spawnMan.AddPlayerSpawn(base.gameObject);
	}

	// Token: 0x06003F76 RID: 16246 RVA: 0x000E2748 File Offset: 0x000E0948
	public void RemoveFromManager()
	{
		global::SpawnManager._spawnMan.RemovePlayerSpawn(base.gameObject);
	}

	// Token: 0x06003F77 RID: 16247 RVA: 0x000E275C File Offset: 0x000E095C
	public virtual bool IsValidToSpawn()
	{
		return global::NetCull.time > this.lastSpawnTime + this.spawnDelay;
	}

	// Token: 0x06003F78 RID: 16248 RVA: 0x000E2774 File Offset: 0x000E0974
	public virtual void NearbyRespawn()
	{
		this.lastSpawnTime = global::NetCull.time;
	}

	// Token: 0x06003F79 RID: 16249 RVA: 0x000E2784 File Offset: 0x000E0984
	public virtual void MarkSpawnedOn()
	{
		this.lastSpawnTime = global::NetCull.time;
	}

	// Token: 0x06003F7A RID: 16250 RVA: 0x000E2794 File Offset: 0x000E0994
	public double CooldownTimeLeft()
	{
		return (double)global::UnityEngine.Mathf.Clamp((float)(this.lastSpawnTime + this.spawnDelay - global::NetCull.time), 0f, (float)this.spawnDelay);
	}

	// Token: 0x06003F7B RID: 16251 RVA: 0x000E27C8 File Offset: 0x000E09C8
	public virtual global::UnityEngine.Quaternion GetSpawnRot()
	{
		return base.transform.rotation;
	}

	// Token: 0x06003F7C RID: 16252 RVA: 0x000E27D8 File Offset: 0x000E09D8
	public virtual global::UnityEngine.Vector3 GetSpawnPos()
	{
		return base.transform.position;
	}

	// Token: 0x06003F7D RID: 16253 RVA: 0x000E27E8 File Offset: 0x000E09E8
	protected new void OnDestroy()
	{
		this.RemoveFromManager();
		base.OnDestroy();
	}

	// Token: 0x040020B5 RID: 8373
	public double lastSpawnTime;

	// Token: 0x040020B6 RID: 8374
	public double spawnDelay = 240.0;
}
