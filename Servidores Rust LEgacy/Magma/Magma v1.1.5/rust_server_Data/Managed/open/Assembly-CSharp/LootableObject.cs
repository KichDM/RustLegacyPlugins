using System;
using Facepunch;
using Rust;
using uLink;
using UnityEngine;

// Token: 0x02000790 RID: 1936
[global::NGCAutoAddScript]
[global::UnityEngine.RequireComponent(typeof(global::Inventory))]
public class LootableObject : global::IDLocal, global::IUseable, global::IContextRequestable, global::IContextRequestableQuick, global::IContextRequestableText, global::IContextRequestablePointText, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IUseable>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06004058 RID: 16472 RVA: 0x000E614C File Offset: 0x000E434C
	public LootableObject()
	{
	}

	// Token: 0x06004059 RID: 16473 RVA: 0x000E615C File Offset: 0x000E435C
	global::ContextExecution global::IContextRequestable.ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick;
	}

	// Token: 0x0600405A RID: 16474 RVA: 0x000E6160 File Offset: 0x000E4360
	global::ContextResponse global::IContextRequestableQuick.ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		return this.ContextRespond_OpenLoot(controllable, timestamp);
	}

	// Token: 0x17000C01 RID: 3073
	// (get) Token: 0x0600405B RID: 16475 RVA: 0x000E616C File Offset: 0x000E436C
	// (set) Token: 0x0600405C RID: 16476 RVA: 0x000E617C File Offset: 0x000E437C
	public global::LootSpawnList _spawnList
	{
		get
		{
			return this._lootSpawnListName.list;
		}
		set
		{
			this._lootSpawnListName.list = value;
		}
	}

	// Token: 0x0600405D RID: 16477 RVA: 0x000E618C File Offset: 0x000E438C
	protected void Awake()
	{
		global::ServerHelper.SetupForServer(base.gameObject);
		if (!this.lateSized && !this._inventory.TryToInitializeSize(this.NumberOfSlots))
		{
			this.NumberOfSlots = this._inventory.slotCount;
		}
	}

	// Token: 0x0600405E RID: 16478 RVA: 0x000E61D8 File Offset: 0x000E43D8
	protected virtual void InitializeServerState(global::uLink.NetworkMessageInfo info, bool ngc, global::UnityEngine.MonoBehaviour networkView)
	{
		this.TryAddLoot();
		this.ResetInvokes();
	}

	// Token: 0x0600405F RID: 16479 RVA: 0x000E61E8 File Offset: 0x000E43E8
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.InitializeServerState(info, false, info.networkView);
	}

	// Token: 0x06004060 RID: 16480 RVA: 0x000E61F8 File Offset: 0x000E43F8
	protected void NGC_OnInstantiate(global::NGCView view)
	{
		this.InitializeServerState(view.creation, true, view);
	}

	// Token: 0x06004061 RID: 16481 RVA: 0x000E6208 File Offset: 0x000E4408
	private void TryAddLoot()
	{
		if (this._spawnList == null || (this._useable && this._useable.occupied))
		{
			return;
		}
		if (this._inventory.anyOccupiedSlots)
		{
			return;
		}
		if (this._spawnList)
		{
			this._inventory.Clear();
			this._spawnList.PopulateInventory(this._inventory);
		}
	}

	// Token: 0x06004062 RID: 16482 RVA: 0x000E6284 File Offset: 0x000E4484
	public void OnUseEnter(global::Useable use)
	{
		this._useable = use;
		this._currentlyUsingPlayer = global::Facepunch.NetworkView.Get(use.user).owner;
		this._inventory.AddNetListener(this._currentlyUsingPlayer);
		this.SendCurrentLooter();
		this.CancelInvokes();
		base.InvokeRepeating("RadialCheck", 0f, 10f);
	}

	// Token: 0x06004063 RID: 16483 RVA: 0x000E62E4 File Offset: 0x000E44E4
	public void OnUseExit(global::Useable use, global::UseExitReason reason)
	{
		this._inventory.RemoveNetListener(this._currentlyUsingPlayer);
		this._currentlyUsingPlayer = global::uLink.NetworkPlayer.unassigned;
		this.SendCurrentLooter();
		this.ResetInvokes();
		base.CancelInvoke("RadialCheck");
		if ((this.lifeTime > 0f || this.destroyOnEmpty) && !this._inventory.anyOccupiedSlots)
		{
			this.DestroyInExit();
		}
	}

	// Token: 0x06004064 RID: 16484 RVA: 0x000E6358 File Offset: 0x000E4558
	[global::UnityEngine.RPC]
	protected void SetLooter(global::uLink.NetworkPlayer ply)
	{
		this.occupierText = null;
		if (ply == global::uLink.NetworkPlayer.unassigned)
		{
			this.ClearLooter();
		}
		else
		{
			if (ply == global::NetCull.player)
			{
				if (!this.thisClientIsInWindow)
				{
					try
					{
						this._currentlyUsingPlayer = ply;
						global::RPOS.OpenLootWindow(this);
						this.thisClientIsInWindow = true;
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogError(ex, this);
						global::NetCull.RPC(this, "StopLooting", 0);
						this.thisClientIsInWindow = false;
						ply = global::uLink.NetworkPlayer.unassigned;
					}
				}
			}
			else if (this._currentlyUsingPlayer == global::NetCull.player && global::NetCull.player != global::uLink.NetworkPlayer.unassigned)
			{
				this.ClearLooter();
			}
			this._currentlyUsingPlayer = ply;
		}
	}

	// Token: 0x06004065 RID: 16485 RVA: 0x000E643C File Offset: 0x000E463C
	[global::UnityEngine.RPC]
	protected void ClearLooter()
	{
		this.occupierText = null;
		this._currentlyUsingPlayer = global::uLink.NetworkPlayer.unassigned;
		if (this.thisClientIsInWindow)
		{
			try
			{
				global::RPOS.CloseLootWindow();
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(ex);
			}
			finally
			{
				this.thisClientIsInWindow = false;
			}
		}
	}

	// Token: 0x06004066 RID: 16486 RVA: 0x000E64B8 File Offset: 0x000E46B8
	[global::UnityEngine.RPC]
	protected void TakeAll()
	{
		if (!this._useable.user)
		{
			return;
		}
		global::NetUser netUser = this._useable.user.netUser;
		if (netUser != null)
		{
			global::FeedbackLog.Start(global::FeedbackLog.TYPE.SimpleExploit);
			global::FeedbackLog.Writer.Write("takealldupe");
			global::FeedbackLog.Writer.Write(netUser.userID);
			global::FeedbackLog.End(global::FeedbackLog.TYPE.SimpleExploit);
		}
	}

	// Token: 0x06004067 RID: 16487 RVA: 0x000E6520 File Offset: 0x000E4720
	[global::UnityEngine.RPC]
	protected void StopLooting(global::uLink.NetworkMessageInfo info)
	{
		if (this._currentlyUsingPlayer == info.sender)
		{
			this._useable.Eject();
		}
	}

	// Token: 0x06004068 RID: 16488 RVA: 0x000E6550 File Offset: 0x000E4750
	public void ClientClosedLootWindow()
	{
		try
		{
			if (this.IsLocalLooting())
			{
				global::NetCull.RPC(this, "StopLooting", 0);
			}
		}
		finally
		{
			if (this.thisClientIsInWindow)
			{
				this.thisClientIsInWindow = false;
			}
		}
	}

	// Token: 0x06004069 RID: 16489 RVA: 0x000E65AC File Offset: 0x000E47AC
	public bool IsLocked(global::Controllable controllable)
	{
		global::LockableObject component = base.GetComponent<global::LockableObject>();
		return !(component == null) && !component.HasAccess(controllable);
	}

	// Token: 0x0600406A RID: 16490 RVA: 0x000E65D8 File Offset: 0x000E47D8
	public string GetLockedString(global::Controllable controllable)
	{
		global::LockableObject component = base.GetComponent<global::LockableObject>();
		if (component == null)
		{
			return string.Empty;
		}
		return component.GetLockedStringForPopup(controllable);
	}

	// Token: 0x0600406B RID: 16491 RVA: 0x000E6608 File Offset: 0x000E4808
	protected virtual global::ContextResponse ContextRespond_OpenLoot(global::Controllable controllable, ulong timestamp)
	{
		if (this.accessLocked)
		{
			return global::ContextResponse.FailBreak;
		}
		if (this.IsLocked(controllable))
		{
			string lockedString = this.GetLockedString(controllable);
			if (!string.IsNullOrEmpty(lockedString))
			{
				global::Rust.Notice.Popup(controllable.netPlayer, "", lockedString, 5f);
			}
			return global::ContextResponse.FailBreak;
		}
		return global::ContextRequestable.UseableForwardFromContextRespond(this, controllable, this._useable);
	}

	// Token: 0x0600406C RID: 16492 RVA: 0x000E6668 File Offset: 0x000E4868
	public virtual string ContextText(global::Controllable localControllable)
	{
		if (this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned)
		{
			return "Search";
		}
		if (this.occupierText == null)
		{
			global::PlayerClient playerClient;
			if (!global::PlayerClient.Find(this._currentlyUsingPlayer, out playerClient))
			{
				this.occupierText = "Occupied";
			}
			else
			{
				this.occupierText = string.Format("Occupied by {0}", playerClient.userName);
			}
		}
		return this.occupierText;
	}

	// Token: 0x0600406D RID: 16493 RVA: 0x000E66DC File Offset: 0x000E48DC
	private void DelayedDestroy()
	{
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x0600406E RID: 16494 RVA: 0x000E66EC File Offset: 0x000E48EC
	protected void OnDestroy()
	{
		global::UseableUtility.OnDestroy(this, this._useable);
	}

	// Token: 0x0600406F RID: 16495 RVA: 0x000E66FC File Offset: 0x000E48FC
	public bool IsLocalLooting()
	{
		return this.thisClientIsInWindow || (this._currentlyUsingPlayer == global::NetCull.player && this._currentlyUsingPlayer != global::uLink.NetworkPlayer.unassigned);
	}

	// Token: 0x06004070 RID: 16496 RVA: 0x000E6740 File Offset: 0x000E4940
	protected void SendCurrentLooter()
	{
		if (this.sentSetLooter)
		{
			if (this._currentlyUsingPlayer == this.sentLooter && this._currentlyUsingPlayer != global::uLink.NetworkPlayer.unassigned)
			{
				return;
			}
			global::NetCull.RemoveRPCsByName(global::NetEntityID.Get(this), "SetLooter");
		}
		if (this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned)
		{
			global::NetCull.RPC(this, "ClearLooter", 1);
			this.sentLooter = global::uLink.NetworkPlayer.unassigned;
			this.sentSetLooter = false;
		}
		else
		{
			global::NetCull.RPC<global::uLink.NetworkPlayer>(this, "SetLooter", 5, this._currentlyUsingPlayer);
			this.sentLooter = this._currentlyUsingPlayer;
			this.sentSetLooter = true;
		}
	}

	// Token: 0x06004071 RID: 16497 RVA: 0x000E67F4 File Offset: 0x000E49F4
	protected void DestroyInExit()
	{
		if (this.sentSetLooter)
		{
			global::NetCull.RemoveRPCsByName(base.networkView, "SetLooter");
			this.sentLooter = global::uLink.NetworkPlayer.unassigned;
			this.sentSetLooter = false;
		}
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x06004072 RID: 16498 RVA: 0x000E683C File Offset: 0x000E4A3C
	public void CancelInvokes()
	{
		if (this.LootCycle > 0f)
		{
			base.CancelInvoke("TryAddLoot");
		}
		if (this.lifeTime > 0f)
		{
			base.CancelInvoke("DelayedDestroy");
		}
	}

	// Token: 0x06004073 RID: 16499 RVA: 0x000E6880 File Offset: 0x000E4A80
	public void ResetInvokes()
	{
		if (this.LootCycle > 0f)
		{
			base.InvokeRepeating("TryAddLoot", 0f, this.LootCycle);
		}
		if (this.lifeTime > 0f)
		{
			base.Invoke("DelayedDestroy", this.lifeTime);
		}
	}

	// Token: 0x06004074 RID: 16500 RVA: 0x000E68D4 File Offset: 0x000E4AD4
	public void RadialCheck()
	{
		if (this._useable.user && global::UnityEngine.Vector3.Distance(this._useable.user.transform.position, base.transform.position) > 5f)
		{
			this._useable.Eject();
			base.CancelInvoke("RadialCheck");
		}
	}

	// Token: 0x06004075 RID: 16501 RVA: 0x000E693C File Offset: 0x000E4B3C
	public virtual bool ContextTextPoint(out global::UnityEngine.Vector3 worldPoint)
	{
		if (global::ContextRequestable.PointUtil.SpriteOrOrigin(base.transform, out worldPoint))
		{
			worldPoint.y += 0.15f;
			return true;
		}
		return true;
	}

	// Token: 0x04002184 RID: 8580
	private const string kAnimation_OpenIdle = "opened idle";

	// Token: 0x04002185 RID: 8581
	private const string kAnimation_Open = "open";

	// Token: 0x04002186 RID: 8582
	private const string kAnimation_CloseIdle = "closed idle";

	// Token: 0x04002187 RID: 8583
	private const string kAnimation_Close = "close";

	// Token: 0x04002188 RID: 8584
	[global::UnityEngine.SerializeField]
	private global::LootSpawnListReference _lootSpawnListName;

	// Token: 0x04002189 RID: 8585
	public float LootCycle;

	// Token: 0x0400218A RID: 8586
	public float lifeTime;

	// Token: 0x0400218B RID: 8587
	[global::PrefetchComponent]
	public global::Inventory _inventory;

	// Token: 0x0400218C RID: 8588
	private global::Useable _useable;

	// Token: 0x0400218D RID: 8589
	protected global::uLink.NetworkPlayer _currentlyUsingPlayer;

	// Token: 0x0400218E RID: 8590
	public bool destroyOnEmpty;

	// Token: 0x0400218F RID: 8591
	public int NumberOfSlots = 0xC;

	// Token: 0x04002190 RID: 8592
	public bool lateSized;

	// Token: 0x04002191 RID: 8593
	[global::System.NonSerialized]
	public bool accessLocked;

	// Token: 0x04002192 RID: 8594
	public global::RPOSLootWindow lootWindowOverride;

	// Token: 0x04002193 RID: 8595
	private bool thisClientIsInWindow;

	// Token: 0x04002194 RID: 8596
	protected string occupierText;

	// Token: 0x04002195 RID: 8597
	private bool sentSetLooter;

	// Token: 0x04002196 RID: 8598
	private global::uLink.NetworkPlayer sentLooter;
}
