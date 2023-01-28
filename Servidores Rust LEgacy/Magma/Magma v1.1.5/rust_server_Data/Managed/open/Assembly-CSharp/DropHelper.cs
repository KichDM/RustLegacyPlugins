using System;
using UnityEngine;

// Token: 0x020005F3 RID: 1523
public static class DropHelper
{
	// Token: 0x0600311A RID: 12570 RVA: 0x000BB70C File Offset: 0x000B990C
	public static bool DropInventoryContents(global::Inventory inventory, out global::Inventory droppedTo)
	{
		droppedTo = null;
		if (!inventory || !inventory.anyOccupiedSlots)
		{
			return false;
		}
		inventory.BlockFutureArmorUpdates();
		inventory.DeactivateItem();
		global::Character character = inventory.idMain as global::Character;
		if (!character)
		{
			return false;
		}
		bool result;
		try
		{
			global::CharacterDeathDropPrefabTrait trait = character.GetTrait<global::CharacterDeathDropPrefabTrait>();
			string instantiateString = trait.instantiateString;
			global::Inventory.Transfer[] array = inventory.GenerateOptimizedInventoryListing(global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor, true);
			if (array.Length == 0)
			{
				result = false;
			}
			else
			{
				global::UnityEngine.Vector3 position;
				global::UnityEngine.Vector3 up;
				character.transform.GetGroundInfo(out position, out up);
				global::UnityEngine.Quaternion rotation = global::TransformHelpers.LookRotationForcedUp(character.forward, up);
				global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateStatic(instantiateString, position, rotation);
				global::LootableObject component = gameObject.GetComponent<global::LootableObject>();
				if (component)
				{
					component.lifeTime = 1800f;
				}
				droppedTo = gameObject.GetComponent<global::Inventory>();
				if (!droppedTo)
				{
					global::UnityEngine.Debug.LogError("Items lost.", gameObject);
					result = false;
				}
				else
				{
					droppedTo.ResetToReport(array);
					result = true;
				}
			}
		}
		finally
		{
			if (inventory)
			{
				inventory.Clear();
			}
		}
		return result;
	}

	// Token: 0x0600311B RID: 12571 RVA: 0x000BB83C File Offset: 0x000B9A3C
	public static void DropInventoryContents(global::Inventory inventory)
	{
		global::Inventory inventory2;
		global::DropHelper.DropInventoryContents(inventory, out inventory2);
	}

	// Token: 0x0600311C RID: 12572 RVA: 0x000BB854 File Offset: 0x000B9A54
	public static bool DropItem(global::Inventory inventory, int slot, out global::ItemPickup dropped)
	{
		dropped = null;
		if (!inventory)
		{
			return false;
		}
		global::IInventoryItem inventoryItem;
		if (!inventory.GetItem(slot, out inventoryItem))
		{
			inventory.MarkSlotDirty(slot);
			return false;
		}
		if (inventoryItem.datablock.untransferable)
		{
			inventory.RemoveItem(inventoryItem);
			return false;
		}
		global::Character character = inventory.idMain as global::Character;
		if (!character)
		{
			return false;
		}
		global::CharacterItemDropPrefabTrait trait = character.GetTrait<global::CharacterItemDropPrefabTrait>();
		global::UnityEngine.Vector3 forward = character.eyesAngles.forward;
		global::UnityEngine.Vector3 arg = forward * global::UnityEngine.Random.Range(4f, 6f);
		global::UnityEngine.Vector3 position = character.eyesOrigin - new global::UnityEngine.Vector3(0f, 0.25f, 0f);
		global::UnityEngine.Quaternion rotation = global::UnityEngine.Quaternion.LookRotation(global::UnityEngine.Vector3.forward);
		global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateDynamicWithArgs<global::UnityEngine.Vector3>(trait.prefab, position, rotation, arg);
		dropped = gameObject.GetComponent<global::ItemPickup>();
		if (!dropped.SetPickupItem(inventoryItem))
		{
			global::UnityEngine.Debug.LogError(string.Format("Could not make item pickup for {0}", inventoryItem), inventory);
			global::NetCull.Destroy(gameObject);
		}
		inventory.MarkSlotDirty(slot);
		return true;
	}

	// Token: 0x0600311D RID: 12573 RVA: 0x000BB964 File Offset: 0x000B9B64
	public static void DropItem(global::Inventory inventory, int slot)
	{
		global::ItemPickup itemPickup;
		global::DropHelper.DropItem(inventory, slot, out itemPickup);
	}
}
