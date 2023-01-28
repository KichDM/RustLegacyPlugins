using System;
using System.Collections;
using Facepunch;
using Rust;
using uLink;
using UnityEngine;

// Token: 0x020007A0 RID: 1952
[global::NGCAutoAddScript]
[global::UnityEngine.RequireComponent(typeof(global::Inventory))]
public class WorkBench : global::IDMain, global::IUseable, global::IContextRequestable, global::IContextRequestableQuick, global::IContextRequestableText, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IUseable>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x060040E7 RID: 16615 RVA: 0x000E9188 File Offset: 0x000E7388
	public WorkBench() : base(0)
	{
	}

	// Token: 0x060040E8 RID: 16616 RVA: 0x000E919C File Offset: 0x000E739C
	// Note: this type is marked as 'beforefieldinit'.
	static WorkBench()
	{
	}

	// Token: 0x17000C02 RID: 3074
	// (get) Token: 0x060040E9 RID: 16617 RVA: 0x000E91A0 File Offset: 0x000E73A0
	private static bool debug_workbench
	{
		get
		{
			return global::WorkBench._debug_workbench;
		}
	}

	// Token: 0x060040EA RID: 16618 RVA: 0x000E91A8 File Offset: 0x000E73A8
	public static void LogError<T>(T a, global::UnityEngine.Object b)
	{
		if (global::WorkBench.debug_workbench)
		{
			global::UnityEngine.Debug.LogError(a, b);
		}
	}

	// Token: 0x060040EB RID: 16619 RVA: 0x000E91C0 File Offset: 0x000E73C0
	public static void LogWarning<T>(T a, global::UnityEngine.Object b)
	{
		if (global::WorkBench.debug_workbench)
		{
			global::UnityEngine.Debug.LogWarning(a, b);
		}
	}

	// Token: 0x060040EC RID: 16620 RVA: 0x000E91D8 File Offset: 0x000E73D8
	public static void Log<T>(T a, global::UnityEngine.Object b)
	{
		if (global::WorkBench.debug_workbench)
		{
			global::UnityEngine.Debug.Log(a, b);
		}
	}

	// Token: 0x060040ED RID: 16621 RVA: 0x000E91F0 File Offset: 0x000E73F0
	public static void LogError<T>(T a)
	{
		if (global::WorkBench.debug_workbench)
		{
			global::UnityEngine.Debug.LogError(a);
		}
	}

	// Token: 0x060040EE RID: 16622 RVA: 0x000E9208 File Offset: 0x000E7408
	public static void LogWarning<T>(T a)
	{
		if (global::WorkBench.debug_workbench)
		{
			global::UnityEngine.Debug.LogWarning(a);
		}
	}

	// Token: 0x060040EF RID: 16623 RVA: 0x000E9220 File Offset: 0x000E7420
	public static void Log<T>(T a)
	{
		if (global::WorkBench.debug_workbench)
		{
			global::UnityEngine.Debug.Log(a);
		}
	}

	// Token: 0x060040F0 RID: 16624 RVA: 0x000E9238 File Offset: 0x000E7438
	protected void Awake()
	{
		this.SharedAwake();
	}

	// Token: 0x060040F1 RID: 16625 RVA: 0x000E9240 File Offset: 0x000E7440
	private void SharedAwake()
	{
		this._inventory = base.GetComponent<global::Inventory>();
		this._inventory.TryToInitializeSize(0xD);
	}

	// Token: 0x060040F2 RID: 16626 RVA: 0x000E925C File Offset: 0x000E745C
	public void OnUseEnter(global::Useable use)
	{
		this._useable = use;
		this._currentlyUsingPlayer = use.user.GetComponent<global::uLink.NetworkView>().owner;
		this._inventory.AddNetListener(this._currentlyUsingPlayer);
		this.SendCurrentUser();
		this.SendWorkStatusUpdate();
		base.InvokeRepeating("RadialCheck", 0f, 10f);
	}

	// Token: 0x060040F3 RID: 16627 RVA: 0x000E92BC File Offset: 0x000E74BC
	public void OnUseExit(global::Useable use, global::UseExitReason reason)
	{
		this._inventory.RemoveNetListener(this._currentlyUsingPlayer);
		this._currentlyUsingPlayer = global::uLink.NetworkPlayer.unassigned;
		this.SendCurrentUser();
		base.CancelInvoke("RadialCheck");
	}

	// Token: 0x060040F4 RID: 16628 RVA: 0x000E92F8 File Offset: 0x000E74F8
	public void SendCurrentUser()
	{
		global::NetEntityID entID = global::NetEntityID.Get(this);
		global::NetCull.RemoveRPCsByName(entID, "SetUser");
		global::NetCull.RPC<global::uLink.NetworkPlayer>(entID, "SetUser", 5, this._currentlyUsingPlayer);
	}

	// Token: 0x060040F5 RID: 16629 RVA: 0x000E932C File Offset: 0x000E752C
	[global::UnityEngine.RPC]
	private void SetUser(global::uLink.NetworkPlayer ply)
	{
		if (ply == global::NetCull.player)
		{
			global::RPOS.OpenWorkbenchWindow(this);
		}
		else if (this._currentlyUsingPlayer == global::NetCull.player && ply != this._currentlyUsingPlayer)
		{
			this._currentlyUsingPlayer = global::uLink.NetworkPlayer.unassigned;
			global::RPOS.CloseWorkbenchWindow();
		}
		this._currentlyUsingPlayer = ply;
	}

	// Token: 0x060040F6 RID: 16630 RVA: 0x000E9394 File Offset: 0x000E7594
	[global::UnityEngine.RPC]
	private void StopUsing(global::uLink.NetworkMessageInfo info)
	{
		if (this._currentlyUsingPlayer == info.sender)
		{
			this._useable.Eject();
		}
	}

	// Token: 0x060040F7 RID: 16631 RVA: 0x000E93C4 File Offset: 0x000E75C4
	public void ClientClosedWorkbenchWindow()
	{
		if (this.IsLocalUsing())
		{
			global::NetCull.RPC(this, "StopUsing", 0);
		}
	}

	// Token: 0x060040F8 RID: 16632 RVA: 0x000E93E0 File Offset: 0x000E75E0
	public global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick;
	}

	// Token: 0x060040F9 RID: 16633 RVA: 0x000E93E4 File Offset: 0x000E75E4
	public global::ContextResponse ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextRequestable.UseableForwardFromContextRespond(this, controllable, this._useable);
	}

	// Token: 0x060040FA RID: 16634 RVA: 0x000E93F4 File Offset: 0x000E75F4
	public string ContextText(global::Controllable localControllable)
	{
		if (this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned)
		{
			return "Use";
		}
		if (this._currentlyUsingPlayer != global::NetCull.player)
		{
			return "Occupied";
		}
		return string.Empty;
	}

	// Token: 0x060040FB RID: 16635 RVA: 0x000E9434 File Offset: 0x000E7634
	public void RadialCheck()
	{
		if (this._useable.user && global::UnityEngine.Vector3.Distance(this._useable.user.transform.position, base.transform.position) > 5f)
		{
			this._useable.Eject();
			base.CancelInvoke("RadialCheck");
		}
	}

	// Token: 0x060040FC RID: 16636 RVA: 0x000E949C File Offset: 0x000E769C
	public bool IsLocalUsing()
	{
		return this._currentlyUsingPlayer == global::NetCull.player;
	}

	// Token: 0x060040FD RID: 16637 RVA: 0x000E94B0 File Offset: 0x000E76B0
	[global::UnityEngine.RPC]
	private void DoAction()
	{
		if (this.IsWorking())
		{
			this.TryCancel();
		}
		else
		{
			this.StartWork();
		}
	}

	// Token: 0x060040FE RID: 16638 RVA: 0x000E94D0 File Offset: 0x000E76D0
	private void StartWork()
	{
		if (!this.EnsureWorkExists())
		{
			global::Rust.Notice.Popup(this._currentlyUsingPlayer, "", "You can't do anything with those items", 4f);
			return;
		}
		global::IToolItem tool = this.GetTool();
		if (tool == null)
		{
			return;
		}
		this._startTime_network = global::NetCull.time;
		this._workDuration = this.GetWorkDuration();
		base.Invoke("CompleteWork", this._workDuration);
		this._inventory.locked = true;
		tool.StartWork();
		this.SendWorkStatusUpdate();
	}

	// Token: 0x060040FF RID: 16639 RVA: 0x000E9554 File Offset: 0x000E7754
	private void SendWorkStatusUpdate()
	{
		if (this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned)
		{
			return;
		}
		float p = (float)this._startTime_network;
		global::NetCull.RPC<float, float>(this, "WorkStatusUpdate", this._currentlyUsingPlayer, p, this._workDuration);
	}

	// Token: 0x06004100 RID: 16640 RVA: 0x000E9598 File Offset: 0x000E7798
	[global::UnityEngine.RPC]
	private void WorkStatusUpdate(float startTime, float newWorkDuration)
	{
		this._startTime_network = (double)startTime;
		this._workDuration = newWorkDuration;
		global::RPOSWorkbenchWindow component = global::RPOS.GetWindowByName("Workbench").GetComponent<global::RPOSWorkbenchWindow>();
		component.BenchUpdate();
	}

	// Token: 0x06004101 RID: 16641 RVA: 0x000E95CC File Offset: 0x000E77CC
	public void TryCancel()
	{
		this.CancelWork();
	}

	// Token: 0x06004102 RID: 16642 RVA: 0x000E95D4 File Offset: 0x000E77D4
	public void CancelWork()
	{
		global::IToolItem tool = this.GetTool();
		if (tool != null)
		{
			tool.CancelWork();
		}
		this._inventory.locked = false;
		this._startTime_network = 0.0;
		this._workDuration = -1f;
		base.CancelInvoke("CompleteWork");
		this.SendWorkStatusUpdate();
	}

	// Token: 0x06004103 RID: 16643 RVA: 0x000E962C File Offset: 0x000E782C
	public void CompleteWork()
	{
		this._startTime_network = 0.0;
		this._workDuration = -1f;
		global::IToolItem tool = this.GetTool();
		if (tool != null)
		{
			tool.CompleteWork();
		}
		this._inventory.locked = false;
		this._inventory.SendAllDataToAuthorizedLooter(this._currentlyUsingPlayer, false);
		this.SendWorkStatusUpdate();
	}

	// Token: 0x06004104 RID: 16644 RVA: 0x000E968C File Offset: 0x000E788C
	public bool EnsureWorkExists()
	{
		global::IToolItem tool = this.GetTool();
		return tool != null && tool.canWork;
	}

	// Token: 0x06004105 RID: 16645 RVA: 0x000E96B4 File Offset: 0x000E78B4
	public virtual bool HasTool()
	{
		return this.GetTool() != null;
	}

	// Token: 0x06004106 RID: 16646 RVA: 0x000E96C4 File Offset: 0x000E78C4
	public virtual global::IToolItem GetTool()
	{
		return this._inventory.FindItemType<global::IToolItem>();
	}

	// Token: 0x06004107 RID: 16647 RVA: 0x000E96E0 File Offset: 0x000E78E0
	public virtual global::BlueprintDataBlock GetMatchingDBForItems()
	{
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		foreach (global::ItemDataBlock itemDataBlock in global::DatablockDictionary.All)
		{
			if (itemDataBlock is global::BlueprintDataBlock)
			{
				global::BlueprintDataBlock blueprintDataBlock = itemDataBlock as global::BlueprintDataBlock;
				bool flag = true;
				foreach (global::BlueprintDataBlock.IngredientEntry ingredientEntry in blueprintDataBlock.ingredients)
				{
					int num = 0;
					global::IInventoryItem inventoryItem = this._inventory.FindItem(ingredientEntry.Ingredient, out num);
					if (inventoryItem == null || num < ingredientEntry.amount)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					arrayList.Add(blueprintDataBlock);
				}
			}
		}
		if (arrayList.Count > 0)
		{
			global::BlueprintDataBlock result = null;
			int num2 = -1;
			foreach (object obj in arrayList)
			{
				global::BlueprintDataBlock blueprintDataBlock2 = (global::BlueprintDataBlock)obj;
				if (blueprintDataBlock2.ingredients.Length > num2)
				{
					result = blueprintDataBlock2;
					num2 = blueprintDataBlock2.ingredients.Length;
				}
			}
			return result;
		}
		return null;
	}

	// Token: 0x06004108 RID: 16648 RVA: 0x000E9830 File Offset: 0x000E7A30
	[global::UnityEngine.RPC]
	public void TakeAll()
	{
		if (this.IsWorking())
		{
			return;
		}
		if (!this._useable.user)
		{
			return;
		}
		if (this._inventory.noOccupiedSlots)
		{
			return;
		}
		global::Inventory component = this._useable.user.GetComponent<global::Inventory>();
		if (!component)
		{
			return;
		}
		this._inventory.GiveAllTo(component);
		component.SendAllDataToAuthorizedLooter(component.networkView.owner, false);
		this._inventory.SendAllDataToAuthorizedLooter(component.networkView.owner, false);
	}

	// Token: 0x06004109 RID: 16649 RVA: 0x000E98C4 File Offset: 0x000E7AC4
	public bool IsWorking()
	{
		return this._workDuration != -1f;
	}

	// Token: 0x0600410A RID: 16650 RVA: 0x000E98D8 File Offset: 0x000E7AD8
	public double GetTimePassed()
	{
		if (this._workDuration == -1f)
		{
			return -1.0;
		}
		return global::NetCull.time - this._startTime_network;
	}

	// Token: 0x0600410B RID: 16651 RVA: 0x000E990C File Offset: 0x000E7B0C
	public float GetFractionComplete()
	{
		if (!this.IsWorking())
		{
			return 0f;
		}
		return (float)(this.GetTimePassed() / (double)this._workDuration);
	}

	// Token: 0x0600410C RID: 16652 RVA: 0x000E993C File Offset: 0x000E7B3C
	public float GetWorkDuration()
	{
		global::IToolItem tool = this.GetTool();
		if (tool != null)
		{
			return tool.workDuration;
		}
		return 0f;
	}

	// Token: 0x040021DE RID: 8670
	[global::UnityEngine.HideInInspector]
	public global::Inventory _inventory;

	// Token: 0x040021DF RID: 8671
	private global::Useable _useable;

	// Token: 0x040021E0 RID: 8672
	private global::uLink.NetworkPlayer _currentlyUsingPlayer;

	// Token: 0x040021E1 RID: 8673
	private double _startTime_network;

	// Token: 0x040021E2 RID: 8674
	private float _workDuration = -1f;

	// Token: 0x040021E3 RID: 8675
	private static bool _debug_workbench;
}
