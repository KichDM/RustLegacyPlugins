using System;
using UnityEngine;

// Token: 0x0200053C RID: 1340
public class RPOSLootWindow : global::RPOSWindowScrollable
{
	// Token: 0x06002D82 RID: 11650 RVA: 0x000AD314 File Offset: 0x000AB514
	public RPOSLootWindow()
	{
	}

	// Token: 0x06002D83 RID: 11651 RVA: 0x000AD31C File Offset: 0x000AB51C
	protected override void WindowAwake()
	{
		this.autoResetScrolling = false;
		base.WindowAwake();
		if (!this.initalized && this.myLootable)
		{
			this.Initialize();
		}
		if (this.TakeAllButton)
		{
			global::UIEventListener uieventListener = global::UIEventListener.Get(this.TakeAllButton.gameObject);
			global::UIEventListener uieventListener2 = uieventListener;
			uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.TakeAllButtonClicked));
		}
	}

	// Token: 0x06002D84 RID: 11652 RVA: 0x000AD39C File Offset: 0x000AB59C
	public virtual void SetLootable(global::LootableObject lootable, bool doInit)
	{
		this.myLootable = lootable;
		this.Initialize();
	}

	// Token: 0x06002D85 RID: 11653 RVA: 0x000AD3AC File Offset: 0x000AB5AC
	public void TakeAllButtonClicked(global::UnityEngine.GameObject go)
	{
		global::RPOS.ChangeRPOSMode(false);
		global::UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06002D86 RID: 11654 RVA: 0x000AD3C0 File Offset: 0x000AB5C0
	public void Initialize()
	{
		global::RPOSInvCellManager componentInChildren = base.GetComponentInChildren<global::RPOSInvCellManager>();
		componentInChildren.SetInventory(this.myLootable.GetComponent<global::Inventory>(), true);
		base.ResetScrolling();
	}

	// Token: 0x06002D87 RID: 11655 RVA: 0x000AD3EC File Offset: 0x000AB5EC
	protected override void OnWindowHide()
	{
		try
		{
			base.OnWindowHide();
		}
		finally
		{
			this.LootClosed();
		}
	}

	// Token: 0x06002D88 RID: 11656 RVA: 0x000AD428 File Offset: 0x000AB628
	protected override void OnRPOSClosed()
	{
		base.OnRPOSClosed();
		this.LootClosed();
	}

	// Token: 0x06002D89 RID: 11657 RVA: 0x000AD438 File Offset: 0x000AB638
	public virtual void LootClosed()
	{
		if (this.myLootable)
		{
			this.myLootable.ClientClosedLootWindow();
		}
		global::UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06002D8A RID: 11658 RVA: 0x000AD46C File Offset: 0x000AB66C
	protected override void OnExternalClose()
	{
		this.LootClosed();
	}

	// Token: 0x0400177C RID: 6012
	[global::System.NonSerialized]
	public global::LootableObject myLootable;

	// Token: 0x0400177D RID: 6013
	[global::System.NonSerialized]
	public bool initalized;

	// Token: 0x0400177E RID: 6014
	public global::UIButton TakeAllButton;
}
