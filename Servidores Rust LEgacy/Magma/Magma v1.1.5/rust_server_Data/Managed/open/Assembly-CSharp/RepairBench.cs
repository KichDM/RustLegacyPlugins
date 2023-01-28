using System;
using Rust;
using uLink;
using UnityEngine;

// Token: 0x02000794 RID: 1940
[global::NGCAutoAddScript]
public class RepairBench : global::IDLocal
{
	// Token: 0x0600408A RID: 16522 RVA: 0x000E6DF8 File Offset: 0x000E4FF8
	public RepairBench()
	{
	}

	// Token: 0x0600408B RID: 16523 RVA: 0x000E6E00 File Offset: 0x000E5000
	public bool CanRepair(global::Inventory ingredientInv)
	{
		global::IInventoryItem repairItem = this.GetRepairItem();
		if (repairItem == null || !repairItem.datablock.isRepairable)
		{
			return false;
		}
		if (!repairItem.IsDamaged())
		{
			return false;
		}
		global::BlueprintDataBlock blueprintDataBlock;
		if (global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(repairItem.datablock, out blueprintDataBlock))
		{
			for (int i = 0; i < blueprintDataBlock.ingredients.Length; i++)
			{
				global::BlueprintDataBlock.IngredientEntry ingredientEntry = blueprintDataBlock.ingredients[i];
				int num = global::UnityEngine.Mathf.CeilToInt((float)blueprintDataBlock.ingredients[i].amount * this.GetResourceScalar());
				if (num > 0 && ingredientInv.CanConsume(blueprintDataBlock.ingredients[i].Ingredient, num) <= 0)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600408C RID: 16524 RVA: 0x000E6EB8 File Offset: 0x000E50B8
	public bool CompleteRepair(global::Inventory ingredientInv)
	{
		if (!this.CanRepair(ingredientInv))
		{
			return false;
		}
		global::IInventoryItem repairItem = this.GetRepairItem();
		global::BlueprintDataBlock blueprintDataBlock;
		if (!global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(repairItem.datablock, out blueprintDataBlock))
		{
			return false;
		}
		for (int i = 0; i < blueprintDataBlock.ingredients.Length; i++)
		{
			global::BlueprintDataBlock.IngredientEntry ingredientEntry = blueprintDataBlock.ingredients[i];
			int j = global::UnityEngine.Mathf.RoundToInt((float)blueprintDataBlock.ingredients[i].amount * this.GetResourceScalar());
			if (j > 0)
			{
				while (j > 0)
				{
					int num = 0;
					global::IInventoryItem inventoryItem = ingredientInv.FindItem(ingredientEntry.Ingredient, out num);
					if (inventoryItem == null)
					{
						return false;
					}
					if (inventoryItem.Consume(ref j))
					{
						ingredientInv.RemoveItem(inventoryItem.slot);
					}
				}
			}
		}
		float num2 = repairItem.maxcondition - repairItem.condition;
		float num3 = num2 * 0.2f + 0.05f;
		repairItem.SetMaxCondition(repairItem.maxcondition - num3);
		repairItem.SetCondition(repairItem.maxcondition);
		return true;
	}

	// Token: 0x0600408D RID: 16525 RVA: 0x000E6FBC File Offset: 0x000E51BC
	public global::IInventoryItem GetRepairItem()
	{
		global::IInventoryItem result;
		base.GetComponent<global::Inventory>().GetItem(0, out result);
		return result;
	}

	// Token: 0x0600408E RID: 16526 RVA: 0x000E6FDC File Offset: 0x000E51DC
	public bool HasRepairItem()
	{
		return this.GetRepairItem() != null;
	}

	// Token: 0x0600408F RID: 16527 RVA: 0x000E6FEC File Offset: 0x000E51EC
	public float GetResourceScalar()
	{
		global::IInventoryItem repairItem = this.GetRepairItem();
		if (repairItem == null)
		{
			return 0f;
		}
		return (repairItem.maxcondition - repairItem.condition) * 0.5f;
	}

	// Token: 0x06004090 RID: 16528 RVA: 0x000E7020 File Offset: 0x000E5220
	[global::UnityEngine.RPC]
	protected void DoRepair(global::uLink.NetworkMessageInfo info)
	{
		global::PlayerClient playerClient;
		if (global::PlayerClient.Find(info.sender, out playerClient) && playerClient.controllable)
		{
			global::Inventory component = playerClient.controllable.GetComponent<global::Inventory>();
			if (this.CompleteRepair(component))
			{
				global::Rust.Notice.Popup(info.sender, "", "Repaired Item!", 4f);
			}
			else
			{
				global::Rust.Notice.Popup(info.sender, "", "could not repair item", 4f);
			}
		}
	}
}
