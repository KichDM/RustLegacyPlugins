using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000548 RID: 1352
public class RPOS_Craft_BlueprintList : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002E23 RID: 11811 RVA: 0x000AF578 File Offset: 0x000AD778
	public RPOS_Craft_BlueprintList()
	{
	}

	// Token: 0x06002E24 RID: 11812 RVA: 0x000AF580 File Offset: 0x000AD780
	private void Awake()
	{
	}

	// Token: 0x06002E25 RID: 11813 RVA: 0x000AF584 File Offset: 0x000AD784
	public bool AnyOfCategoryInList(global::ItemDataBlock.ItemCategory category, global::System.Collections.Generic.List<global::BlueprintDataBlock> checkList)
	{
		foreach (global::BlueprintDataBlock blueprintDataBlock in checkList)
		{
			if (blueprintDataBlock == null)
			{
				global::UnityEngine.Debug.Log("WTFFFF");
				return false;
			}
			if (blueprintDataBlock.resultItem.category == category)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002E26 RID: 11814 RVA: 0x000AF618 File Offset: 0x000AD818
	public void AddItemCategoryHeader(global::ItemDataBlock.ItemCategory category)
	{
	}

	// Token: 0x06002E27 RID: 11815 RVA: 0x000AF61C File Offset: 0x000AD81C
	public global::RPOSCraftItemEntry GetEntryByBP(global::BlueprintDataBlock bp)
	{
		foreach (object obj in base.transform)
		{
			global::RPOSCraftItemEntry component = (obj as global::UnityEngine.Transform).GetComponent<global::RPOSCraftItemEntry>();
			if (component && component.blueprint == bp)
			{
				return component;
			}
		}
		return null;
	}

	// Token: 0x06002E28 RID: 11816 RVA: 0x000AF6B4 File Offset: 0x000AD8B4
	public int AddItemsOfCategory(global::ItemDataBlock.ItemCategory category, global::System.Collections.Generic.List<global::BlueprintDataBlock> checkList, int yPos)
	{
		if (!this.AnyOfCategoryInList(category, checkList))
		{
			return yPos;
		}
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(base.gameObject, this.CategoryHeaderPrefab);
		gameObject.transform.localPosition = new global::UnityEngine.Vector3(0f, (float)yPos, -1f);
		gameObject.GetComponentInChildren<global::UILabel>().text = category.ToString();
		yPos -= 0x10;
		foreach (global::BlueprintDataBlock blueprintDataBlock in checkList)
		{
			if (blueprintDataBlock.resultItem.category == category)
			{
				global::UnityEngine.GameObject gameObject2 = global::NGUITools.AddChild(base.gameObject, this.ItemPlaquePrefab);
				gameObject2.GetComponentInChildren<global::UILabel>().text = blueprintDataBlock.resultItem.name;
				gameObject2.transform.localPosition = new global::UnityEngine.Vector3(10f, (float)yPos, -1f);
				global::UIEventListener uieventListener = global::UIEventListener.Get(gameObject2);
				global::UIEventListener uieventListener2 = uieventListener;
				uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.craftWindow.ItemClicked));
				gameObject2.GetComponent<global::RPOSCraftItemEntry>().actualItemDataBlock = blueprintDataBlock.resultItem;
				gameObject2.GetComponent<global::RPOSCraftItemEntry>().blueprint = blueprintDataBlock;
				gameObject2.GetComponent<global::RPOSCraftItemEntry>().craftWindow = this.craftWindow;
				gameObject2.GetComponent<global::RPOSCraftItemEntry>().SetSelected(false);
				yPos -= 0x10;
			}
		}
		return yPos;
	}

	// Token: 0x06002E29 RID: 11817 RVA: 0x000AF834 File Offset: 0x000ADA34
	public void UpdateItems()
	{
		global::PlayerInventory component = global::RPOS.ObservedPlayer.GetComponent<global::PlayerInventory>();
		global::System.Collections.Generic.List<global::BlueprintDataBlock> boundBPs = component.GetBoundBPs();
		int count = boundBPs.Count;
		if (boundBPs == null)
		{
			global::UnityEngine.Debug.Log("BOUND BP LIST EMPTY!!!!!");
			return;
		}
		if (this.lastNumBoundBPs == count)
		{
			return;
		}
		this.lastNumBoundBPs = count;
		foreach (object obj in base.transform)
		{
			global::UnityEngine.Object.Destroy((obj as global::UnityEngine.Transform).gameObject);
		}
		int yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Survival, boundBPs, 0);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Resource, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Medical, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Ammo, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Weapons, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Armor, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Tools, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Mods, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Parts, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Food, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Blueprint, boundBPs, yPos);
		yPos = this.AddItemsOfCategory(global::ItemDataBlock.ItemCategory.Misc, boundBPs, yPos);
		base.GetComponent<global::UIDraggablePanel>().calculateNextChange = true;
	}

	// Token: 0x040017D7 RID: 6103
	public global::UnityEngine.GameObject CategoryHeaderPrefab;

	// Token: 0x040017D8 RID: 6104
	public global::UnityEngine.GameObject ItemPlaquePrefab;

	// Token: 0x040017D9 RID: 6105
	public global::RPOSCraftWindow craftWindow;

	// Token: 0x040017DA RID: 6106
	private int lastNumBoundBPs;
}
