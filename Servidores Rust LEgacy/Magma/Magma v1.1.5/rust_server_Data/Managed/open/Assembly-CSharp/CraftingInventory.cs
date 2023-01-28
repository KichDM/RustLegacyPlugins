using System;
using System.Collections.Generic;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000637 RID: 1591
public class CraftingInventory : global::Inventory
{
	// Token: 0x0600325E RID: 12894 RVA: 0x000C0B88 File Offset: 0x000BED88
	public CraftingInventory()
	{
	}

	// Token: 0x0600325F RID: 12895 RVA: 0x000C0B90 File Offset: 0x000BED90
	// Note: this type is marked as 'beforefieldinit'.
	static CraftingInventory()
	{
	}

	// Token: 0x06003260 RID: 12896 RVA: 0x000C0B9C File Offset: 0x000BED9C
	public void CraftThink()
	{
		this.TrySendWorkBenchInfo();
		if (this.isCrafting && this.crafting.blueprint.RequireWorkbench && !this.AtWorkBench())
		{
			this.CancelCrafting();
		}
		if (this.crafting.inProgress)
		{
			double time = global::NetCull.time;
			float num = (!this.AtWorkBench()) ? 1f : global::crafting.workbench_speed;
			if (num != this.crafting.progressPerSec)
			{
				this.crafting.progressPerSec = num;
				this.UpdateCraftingDataToOwner();
			}
			float num2 = (float)(time - this._lastThinkTime);
			this.crafting.progressSeconds = global::UnityEngine.Mathf.Clamp(this.crafting.progressSeconds + this.crafting.progressPerSec * num2, 0f, this.crafting.duration);
			if (this.crafting.progressSeconds >= this.crafting.duration)
			{
				this.CompleteCrafting();
			}
			this._lastThinkTime = time;
		}
	}

	// Token: 0x06003261 RID: 12897 RVA: 0x000C0CA0 File Offset: 0x000BEEA0
	public void MarkWorkBench()
	{
		this._lastWorkBenchTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06003262 RID: 12898 RVA: 0x000C0CB0 File Offset: 0x000BEEB0
	public void TrySendWorkBenchInfo()
	{
		bool flag = this.AtWorkBench();
		if (flag != this._wasAtWorkbench)
		{
			base.networkView.RPC<bool>("wbi", base.networkView.owner, flag);
			this._wasAtWorkbench = flag;
		}
	}

	// Token: 0x06003263 RID: 12899 RVA: 0x000C0CF4 File Offset: 0x000BEEF4
	public bool ValidateCraftRequirements(global::BlueprintDataBlock bp)
	{
		return !bp.RequireWorkbench || this.AtWorkBench();
	}

	// Token: 0x06003264 RID: 12900 RVA: 0x000C0D14 File Offset: 0x000BEF14
	public bool AtWorkBench()
	{
		return global::UnityEngine.Time.time - this._lastWorkBenchTime <= 1f;
	}

	// Token: 0x17000A79 RID: 2681
	// (get) Token: 0x06003265 RID: 12901 RVA: 0x000C0D2C File Offset: 0x000BEF2C
	public new bool isCraftingInventory
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000A7A RID: 2682
	// (get) Token: 0x06003266 RID: 12902 RVA: 0x000C0D30 File Offset: 0x000BEF30
	public new bool isCrafting
	{
		get
		{
			return this.crafting.inProgress;
		}
	}

	// Token: 0x17000A7B RID: 2683
	// (get) Token: 0x06003267 RID: 12903 RVA: 0x000C0D40 File Offset: 0x000BEF40
	public new float? craftingCompletePercent
	{
		get
		{
			if (this.crafting.inProgress)
			{
				return new float?((float)this.crafting.percentComplete);
			}
			return null;
		}
	}

	// Token: 0x17000A7C RID: 2684
	// (get) Token: 0x06003268 RID: 12904 RVA: 0x000C0D78 File Offset: 0x000BEF78
	public new float? craftingSecondsRemaining
	{
		get
		{
			if (this.crafting.inProgress)
			{
				return new float?(this.crafting.remainingSeconds);
			}
			return null;
		}
	}

	// Token: 0x17000A7D RID: 2685
	// (get) Token: 0x06003269 RID: 12905 RVA: 0x000C0DB0 File Offset: 0x000BEFB0
	public float craftingSpeedPerSec
	{
		get
		{
			return this.crafting.progressPerSec;
		}
	}

	// Token: 0x0600326A RID: 12906 RVA: 0x000C0DC0 File Offset: 0x000BEFC0
	private static global::BlueprintDataBlock FindBlueprint(int uniqueID)
	{
		if (uniqueID == 0)
		{
			return null;
		}
		return (global::BlueprintDataBlock)global::DatablockDictionary.GetByUniqueID(uniqueID);
	}

	// Token: 0x0600326B RID: 12907 RVA: 0x000C0DD8 File Offset: 0x000BEFD8
	private void BeginCrafting()
	{
		global::CraftingInventory.allInventoriesCrafting.Add(this);
		this.registeredAsCrafting = true;
		base.Invoke("CompleteCrafting", this.crafting.remainingSeconds);
	}

	// Token: 0x0600326C RID: 12908 RVA: 0x000C0E04 File Offset: 0x000BF004
	private void EndCrafting()
	{
		if (this.registeredAsCrafting)
		{
			global::CraftingInventory.allInventoriesCrafting.Remove(this);
			this.registeredAsCrafting = false;
		}
		base.CancelInvoke("CompleteCrafting");
	}

	// Token: 0x0600326D RID: 12909 RVA: 0x000C0E30 File Offset: 0x000BF030
	protected void CompleteCrafting()
	{
		if (this.crafting.inProgress)
		{
			try
			{
				this.crafting.blueprint.CompleteWork(this.crafting.amount, this);
			}
			finally
			{
				this.crafting = default(global::CraftingSession);
				this.EndCrafting();
				this.UpdateCraftingDataToOwner();
			}
		}
	}

	// Token: 0x0600326E RID: 12910 RVA: 0x000C0EA8 File Offset: 0x000BF0A8
	protected void CancelCrafting()
	{
		if (this.crafting.inProgress)
		{
			this.crafting = default(global::CraftingSession);
			this.EndCrafting();
			this.UpdateCraftingDataToOwner();
		}
	}

	// Token: 0x0600326F RID: 12911 RVA: 0x000C0EE0 File Offset: 0x000BF0E0
	protected void StartCrafting(global::BlueprintDataBlock blueprint, int amount)
	{
		this.StartCrafting(blueprint, amount, global::NetCull.timeInMillis);
	}

	// Token: 0x06003270 RID: 12912 RVA: 0x000C0EF0 File Offset: 0x000BF0F0
	protected bool IsInstant()
	{
		global::Character character;
		global::NetUser netUser;
		return global::crafting.instant || (global::crafting.instant_admins && (character = (this.idMain as global::Character)) && character.GetNetUser(out netUser) && netUser.CanAdmin());
	}

	// Token: 0x06003271 RID: 12913 RVA: 0x000C0F44 File Offset: 0x000BF144
	protected void StartCrafting(global::BlueprintDataBlock blueprint, int amount, ulong startTime)
	{
		bool inProgress = this.crafting.inProgress;
		if (this.crafting.Restart(this, amount, blueprint, startTime))
		{
			this._lastThinkTime = global::NetCull.time;
			if (global::crafting.timescale != 1f)
			{
				this.crafting.duration = global::System.Math.Max(0.1f, this.crafting.duration * global::crafting.timescale);
			}
			if (this.IsInstant())
			{
				this.crafting.duration = 0.1f;
			}
			this.UpdateCraftingDataToOwner();
			this.BeginCrafting();
		}
	}

	// Token: 0x06003272 RID: 12914 RVA: 0x000C0FD8 File Offset: 0x000BF1D8
	protected void UpdateCraftingDataToOwner()
	{
		base.RestartNetListeners();
		global::Facepunch.NetworkView networkView = base.networkView;
		if (networkView && networkView.viewID != global::uLink.NetworkViewID.unassigned)
		{
			if (this.crafting.inProgress)
			{
				networkView.RPC("CRFU", 3, new object[]
				{
					this.crafting.startTime,
					this.crafting.duration,
					this.crafting.progressPerSec,
					this.crafting.progressSeconds,
					this.crafting.blueprint.uniqueID,
					this.crafting.amount
				});
			}
			else
			{
				networkView.RPC("CRFC", 3, new object[0]);
			}
		}
	}

	// Token: 0x06003273 RID: 12915 RVA: 0x000C10C4 File Offset: 0x000BF2C4
	protected void OnDestroy()
	{
		this.EndCrafting();
	}

	// Token: 0x06003274 RID: 12916 RVA: 0x000C10CC File Offset: 0x000BF2CC
	public static void CompleteAllCraftingInProgress()
	{
		foreach (global::CraftingInventory craftingInventory in new global::System.Collections.Generic.List<global::CraftingInventory>(global::CraftingInventory.allInventoriesCrafting))
		{
			if (craftingInventory)
			{
				craftingInventory.CompleteCrafting();
			}
		}
	}

	// Token: 0x06003275 RID: 12917 RVA: 0x000C1140 File Offset: 0x000BF340
	public static void CancelAllCraftingInProgress()
	{
		foreach (global::CraftingInventory craftingInventory in new global::System.Collections.Generic.List<global::CraftingInventory>(global::CraftingInventory.allInventoriesCrafting))
		{
			if (craftingInventory)
			{
				craftingInventory.CancelCrafting();
			}
		}
	}

	// Token: 0x06003276 RID: 12918 RVA: 0x000C11B4 File Offset: 0x000BF3B4
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void CRFX()
	{
		this.CancelCrafting();
	}

	// Token: 0x06003277 RID: 12919 RVA: 0x000C11BC File Offset: 0x000BF3BC
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void CRFU(float start, float dur, float progresspersec, float progress, int blueprintUniqueID, int amount)
	{
	}

	// Token: 0x06003278 RID: 12920 RVA: 0x000C11C0 File Offset: 0x000BF3C0
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void CRFC()
	{
	}

	// Token: 0x06003279 RID: 12921 RVA: 0x000C11C4 File Offset: 0x000BF3C4
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void CRFS(int amount, int blueprintUID, global::uLink.NetworkMessageInfo info)
	{
		this.StartCrafting(global::CraftingInventory.FindBlueprint(blueprintUID), amount, info.timestampInMillis);
	}

	// Token: 0x04001C10 RID: 7184
	private const string CompleteCraftingMethodName = "CompleteCrafting";

	// Token: 0x04001C11 RID: 7185
	private const string CancelCraftingRPC = "CRFX";

	// Token: 0x04001C12 RID: 7186
	private const string CraftNetworkUpdateRPC = "CRFU";

	// Token: 0x04001C13 RID: 7187
	private const string CraftNetworkClearRPC = "CRFC";

	// Token: 0x04001C14 RID: 7188
	private const string StartCraftingRPC = "CRFS";

	// Token: 0x04001C15 RID: 7189
	public float _lastWorkBenchTime;

	// Token: 0x04001C16 RID: 7190
	protected bool _wasAtWorkbench;

	// Token: 0x04001C17 RID: 7191
	private double _lastThinkTime;

	// Token: 0x04001C18 RID: 7192
	private global::CraftingSession crafting;

	// Token: 0x04001C19 RID: 7193
	[global::System.NonSerialized]
	private bool registeredAsCrafting;

	// Token: 0x04001C1A RID: 7194
	private static readonly global::System.Collections.Generic.HashSet<global::CraftingInventory> allInventoriesCrafting = new global::System.Collections.Generic.HashSet<global::CraftingInventory>();

	// Token: 0x04001C1B RID: 7195
	private bool craftingNow;
}
