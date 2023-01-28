using System;
using Facepunch;
using Rust;
using UnityEngine;

// Token: 0x0200079C RID: 1948
[global::NGCAutoAddScript]
public class SleepingBag : global::DeployedRespawn, global::IContextRequestable, global::IContextRequestableQuick, global::IContextRequestableStatus, global::IContextRequestableText, global::IContextRequestablePointText, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x060040CA RID: 16586 RVA: 0x000E89A0 File Offset: 0x000E6BA0
	public SleepingBag()
	{
	}

	// Token: 0x060040CB RID: 16587 RVA: 0x000E89A8 File Offset: 0x000E6BA8
	public global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick;
	}

	// Token: 0x060040CC RID: 16588 RVA: 0x000E89AC File Offset: 0x000E6BAC
	public global::ContextResponse ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		this.PlayerUse(controllable);
		return global::ContextResponse.DoneBreak;
	}

	// Token: 0x060040CD RID: 16589 RVA: 0x000E89B8 File Offset: 0x000E6BB8
	public override void MarkSpawnedOn()
	{
		base.MarkSpawnedOn();
		global::RustServerManagement rustServerManagement = global::RustServerManagement.Get();
		int num = 0;
		for (int i = rustServerManagement.playerSpawns.Count - 1; i >= 0; i--)
		{
			global::DeployableObject deployableObject = rustServerManagement.playerSpawns[i];
			if (deployableObject.ownerID == this.ownerID && global::UnityEngine.Vector3.Distance(deployableObject.transform.position, base.transform.position) < 100f)
			{
				global::DeployedRespawn component = deployableObject.GetComponent<global::DeployedRespawn>();
				if (component)
				{
					component.NearbyRespawn();
				}
				num++;
			}
		}
		global::NetUser netUser;
		if (global::NetUser.Find(this.ownerID, out netUser))
		{
			global::Rust.Notice.Popup(netUser.networkPlayer, "", "You will not be able to spawn near here for 4 Minutes.", 7f);
		}
	}

	// Token: 0x060040CE RID: 16590 RVA: 0x000E8A80 File Offset: 0x000E6C80
	public override void NearbyRespawn()
	{
		this.lastSpawnTime = global::NetCull.time;
	}

	// Token: 0x060040CF RID: 16591 RVA: 0x000E8A90 File Offset: 0x000E6C90
	public void PlayerUse(global::Controllable controllable)
	{
		if (base.BelongsTo(controllable))
		{
			if (!this.IsValidToSpawn())
			{
				global::Rust.Notice.Popup(controllable.netPlayer, "", "Wait " + base.CooldownTimeLeft().ToString("F0") + " seconds", 4f);
				return;
			}
			global::Inventory component = controllable.GetComponent<global::Inventory>();
			if (component.AddItemAmount(global::DatablockDictionary.GetByName(this.giveItemName), 1) == 1)
			{
				global::Rust.Notice.Popup(controllable.netPlayer, "", "Your inventory is full", 4f);
				return;
			}
			global::NetCull.Destroy(base.gameObject);
		}
		else
		{
			global::Rust.Notice.Popup(controllable.netPlayer, "", "This isn't yours", 4f);
		}
	}

	// Token: 0x040021D0 RID: 8656
	public string giveItemName;
}
