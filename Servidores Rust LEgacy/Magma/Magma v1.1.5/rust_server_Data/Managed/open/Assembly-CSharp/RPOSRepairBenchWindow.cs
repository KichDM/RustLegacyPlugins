using System;
using UnityEngine;

// Token: 0x0200053E RID: 1342
public class RPOSRepairBenchWindow : global::RPOSLootWindow
{
	// Token: 0x06002D8E RID: 11662 RVA: 0x000AD61C File Offset: 0x000AB81C
	public RPOSRepairBenchWindow()
	{
	}

	// Token: 0x06002D8F RID: 11663 RVA: 0x000AD624 File Offset: 0x000AB824
	protected override void WindowAwake()
	{
		base.WindowAwake();
		global::UIEventListener uieventListener = global::UIEventListener.Get(this.repairButton.gameObject);
		global::UIEventListener uieventListener2 = uieventListener;
		uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.RepairButtonClicked));
		this.ClearRepairItem();
	}

	// Token: 0x06002D90 RID: 11664 RVA: 0x000AD670 File Offset: 0x000AB870
	private void RepairButtonClicked(global::UnityEngine.GameObject go)
	{
		if (this._benchItem != null)
		{
			global::NetCull.RPC(this._bench, "DoRepair", 0);
		}
	}

	// Token: 0x06002D91 RID: 11665 RVA: 0x000AD690 File Offset: 0x000AB890
	public void Update()
	{
		global::IInventoryItem repairItem = null;
		if (this._bench)
		{
			this._bench.GetComponent<global::Inventory>().GetItem(0, out repairItem);
		}
		this.SetRepairItem(repairItem);
	}

	// Token: 0x06002D92 RID: 11666 RVA: 0x000AD6CC File Offset: 0x000AB8CC
	public void SetRepairItem(global::IInventoryItem item)
	{
		if (item == null || !item.datablock.isRepairable)
		{
			this.ClearRepairItem();
			return;
		}
		this._benchItem = item;
		this.UpdateGUIAmounts();
	}

	// Token: 0x06002D93 RID: 11667 RVA: 0x000AD704 File Offset: 0x000AB904
	public void ClearRepairItem()
	{
		this._benchItem = null;
		this.UpdateGUIAmounts();
	}

	// Token: 0x06002D94 RID: 11668 RVA: 0x000AD714 File Offset: 0x000AB914
	public void UpdateGUIAmounts()
	{
		if (this._benchItem == null)
		{
			foreach (global::UILabel uilabel in this._amountLabels)
			{
				uilabel.text = string.Empty;
				uilabel.color = global::UnityEngine.Color.white;
			}
			this.needsLabel.enabled = false;
			this.conditionLabel.enabled = false;
			this.repairButton.gameObject.SetActive(false);
		}
		else
		{
			global::Controllable controllable = global::PlayerClient.GetLocalPlayer().controllable;
			if (controllable == null)
			{
				return;
			}
			global::Inventory component = controllable.GetComponent<global::Inventory>();
			int num = 0;
			if (this._benchItem.IsDamaged())
			{
				global::BlueprintDataBlock blueprintDataBlock;
				if (global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(this._benchItem.datablock, out blueprintDataBlock))
				{
					for (int j = 0; j < blueprintDataBlock.ingredients.Length; j++)
					{
						if (num >= this._amountLabels.Length)
						{
							break;
						}
						global::BlueprintDataBlock.IngredientEntry ingredientEntry = blueprintDataBlock.ingredients[j];
						int num2 = global::UnityEngine.Mathf.CeilToInt((float)blueprintDataBlock.ingredients[j].amount * this._bench.GetResourceScalar());
						if (num2 > 0)
						{
							bool flag = component.CanConsume(blueprintDataBlock.ingredients[j].Ingredient, num2) > 0;
							this._amountLabels[num].text = num2 + " " + blueprintDataBlock.ingredients[j].Ingredient.name;
							this._amountLabels[num].color = ((!flag) ? global::UnityEngine.Color.red : global::UnityEngine.Color.green);
							num++;
						}
					}
				}
				this.needsLabel.color = global::UnityEngine.Color.white;
				this.needsLabel.enabled = true;
				this.conditionLabel.enabled = true;
				this.repairButton.gameObject.SetActive(true);
				string str = (this._benchItem.condition * 100f).ToString("0");
				string str2 = (this._benchItem.maxcondition * 100f).ToString("0");
				this.conditionLabel.text = "Condition : " + str + "/" + str2;
				this.conditionLabel.color = ((this._benchItem.condition >= 0.6f) ? global::UnityEngine.Color.green : global::UnityEngine.Color.yellow);
				if (this._benchItem.IsBroken())
				{
					this.conditionLabel.color = global::UnityEngine.Color.red;
				}
			}
			else
			{
				this.needsLabel.text = "Does not need repairs";
				this.needsLabel.color = global::UnityEngine.Color.green;
				this.needsLabel.enabled = true;
				string str3 = (this._benchItem.condition * 100f).ToString("0");
				string str4 = (this._benchItem.maxcondition * 100f).ToString("0");
				this.conditionLabel.text = "Condition : " + str3 + "/" + str4;
				this.conditionLabel.color = global::UnityEngine.Color.green;
				this.conditionLabel.enabled = true;
				this.repairButton.gameObject.SetActive(false);
				foreach (global::UILabel uilabel2 in this._amountLabels)
				{
					uilabel2.text = string.Empty;
					uilabel2.color = global::UnityEngine.Color.white;
				}
			}
		}
	}

	// Token: 0x06002D95 RID: 11669 RVA: 0x000ADAA4 File Offset: 0x000ABCA4
	public override void SetLootable(global::LootableObject lootable, bool doInit)
	{
		base.SetLootable(lootable, doInit);
		this._bench = lootable.GetComponent<global::RepairBench>();
	}

	// Token: 0x04001781 RID: 6017
	private global::RepairBench _bench;

	// Token: 0x04001782 RID: 6018
	private global::IInventoryItem _benchItem;

	// Token: 0x04001783 RID: 6019
	public global::UILabel[] _amountLabels;

	// Token: 0x04001784 RID: 6020
	public global::UIButton repairButton;

	// Token: 0x04001785 RID: 6021
	public global::UILabel conditionLabel;

	// Token: 0x04001786 RID: 6022
	public global::UILabel needsLabel;
}
