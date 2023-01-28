using System;
using UnityEngine;

// Token: 0x02000547 RID: 1351
public class RPOSWorkbenchWindow : global::RPOSWindow
{
	// Token: 0x06002E16 RID: 11798 RVA: 0x000AF254 File Offset: 0x000AD454
	public RPOSWorkbenchWindow()
	{
	}

	// Token: 0x06002E17 RID: 11799 RVA: 0x000AF25C File Offset: 0x000AD45C
	public void SetWorkbench(global::WorkBench workbenchObj)
	{
		this._myWorkBench = workbenchObj;
		this.Initialize();
	}

	// Token: 0x06002E18 RID: 11800 RVA: 0x000AF26C File Offset: 0x000AD46C
	protected override void WindowAwake()
	{
		base.WindowAwake();
		global::UIEventListener uieventListener = global::UIEventListener.Get(this.actionButton.gameObject);
		global::UIEventListener uieventListener2 = uieventListener;
		uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.ActionButtonClicked));
		global::UIEventListener uieventListener3 = global::UIEventListener.Get(this.takeAllButton.gameObject);
		global::UIEventListener uieventListener4 = uieventListener3;
		uieventListener4.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener4.onClick, new global::UIEventListener.VoidDelegate(this.TakeAllButtonClicked));
	}

	// Token: 0x06002E19 RID: 11801 RVA: 0x000AF2E8 File Offset: 0x000AD4E8
	public void Initialize()
	{
		global::RPOSInvCellManager componentInChildren = base.GetComponentInChildren<global::RPOSInvCellManager>();
		componentInChildren.SetInventory(this._myWorkBench.GetComponent<global::Inventory>(), false);
	}

	// Token: 0x06002E1A RID: 11802 RVA: 0x000AF310 File Offset: 0x000AD510
	protected override void OnWindowClosed()
	{
		base.OnWindowClosed();
		this.WorkbenchClosed();
	}

	// Token: 0x06002E1B RID: 11803 RVA: 0x000AF320 File Offset: 0x000AD520
	protected override void OnRPOSClosed()
	{
		base.OnRPOSClosed();
		this.WorkbenchClosed();
	}

	// Token: 0x06002E1C RID: 11804 RVA: 0x000AF330 File Offset: 0x000AD530
	public virtual void WorkbenchClosed()
	{
		if (this._myWorkBench)
		{
			this._myWorkBench.ClientClosedWorkbenchWindow();
		}
		global::UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06002E1D RID: 11805 RVA: 0x000AF364 File Offset: 0x000AD564
	protected override void OnExternalClose()
	{
		this.WorkbenchClosed();
	}

	// Token: 0x06002E1E RID: 11806 RVA: 0x000AF36C File Offset: 0x000AD56C
	public void BenchUpdate()
	{
		if (!this._myWorkBench)
		{
			global::UnityEngine.Debug.Log("NO BENCH!?!?!");
		}
		if (this._myWorkBench.IsWorking())
		{
			this.startSound.Play();
			this.actionButton.GetComponentInChildren<global::UILabel>().text = "Cancel";
			this.takeAllButton.enabled = false;
			this.SetCellsLocked(true);
		}
		else
		{
			this.actionButton.GetComponentInChildren<global::UILabel>().text = "Start";
			this.takeAllButton.enabled = true;
			this.SetCellsLocked(false);
			if (this._myWorkBench._inventory.IsSlotOccupied(0xC))
			{
				this.finishedSound.Play();
			}
		}
	}

	// Token: 0x06002E1F RID: 11807 RVA: 0x000AF428 File Offset: 0x000AD628
	private void SetCellsLocked(bool isLocked)
	{
		global::RPOSInvCellManager componentInChildren = base.GetComponentInChildren<global::RPOSInvCellManager>();
		for (int i = 0; i < componentInChildren._inventoryCells.Length; i++)
		{
			global::RPOSInventoryCell rposinventoryCell = componentInChildren._inventoryCells[i];
			if (rposinventoryCell)
			{
				rposinventoryCell.SetItemLocked(isLocked);
			}
		}
	}

	// Token: 0x06002E20 RID: 11808 RVA: 0x000AF470 File Offset: 0x000AD670
	private void TakeAllButtonClicked(global::UnityEngine.GameObject go)
	{
		this._myWorkBench.networkView.RPC("TakeAll", 0, new object[0]);
	}

	// Token: 0x06002E21 RID: 11809 RVA: 0x000AF490 File Offset: 0x000AD690
	private void ActionButtonClicked(global::UnityEngine.GameObject go)
	{
		global::UnityEngine.Debug.Log("Action button clicked");
		this._myWorkBench.networkView.RPC("DoAction", 0, new object[0]);
		global::UnityEngine.Debug.Log("Action post");
	}

	// Token: 0x06002E22 RID: 11810 RVA: 0x000AF4D0 File Offset: 0x000AD6D0
	public void Update()
	{
		if (this._myWorkBench && this._myWorkBench.IsWorking())
		{
			this.percentLabel.enabled = true;
			this.progressBar.sliderValue = this._myWorkBench.GetFractionComplete();
			this.percentLabel.text = (global::UnityEngine.Mathf.Clamp01(this._myWorkBench.GetFractionComplete()) * 100f).ToString("N0") + "%";
		}
		else
		{
			this.percentLabel.enabled = false;
			this.progressBar.sliderValue = 0f;
		}
	}

	// Token: 0x040017D0 RID: 6096
	private global::WorkBench _myWorkBench;

	// Token: 0x040017D1 RID: 6097
	public global::UIButton actionButton;

	// Token: 0x040017D2 RID: 6098
	public global::UIButton takeAllButton;

	// Token: 0x040017D3 RID: 6099
	public global::UISlider progressBar;

	// Token: 0x040017D4 RID: 6100
	public global::UILabel percentLabel;

	// Token: 0x040017D5 RID: 6101
	public global::UnityEngine.AudioClip startSound;

	// Token: 0x040017D6 RID: 6102
	public global::UnityEngine.AudioClip finishedSound;
}
