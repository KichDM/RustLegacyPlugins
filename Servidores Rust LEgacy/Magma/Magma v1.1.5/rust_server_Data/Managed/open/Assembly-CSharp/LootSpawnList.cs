using System;
using UnityEngine;

// Token: 0x0200071A RID: 1818
public class LootSpawnList : global::UnityEngine.ScriptableObject
{
	// Token: 0x06003DBB RID: 15803 RVA: 0x000D859C File Offset: 0x000D679C
	public LootSpawnList()
	{
	}

	// Token: 0x06003DBC RID: 15804 RVA: 0x000D85B4 File Offset: 0x000D67B4
	public void PopulateInventory(global::Inventory inven)
	{
		global::LootSpawnList.RecursiveInventoryPopulateArgs recursiveInventoryPopulateArgs;
		recursiveInventoryPopulateArgs.inventory = inven;
		recursiveInventoryPopulateArgs.spawnCount = 0;
		recursiveInventoryPopulateArgs.inventoryExausted = inven.noVacantSlots;
		if (!recursiveInventoryPopulateArgs.inventoryExausted)
		{
			this.PopulateInventory_Recurse(ref recursiveInventoryPopulateArgs);
		}
	}

	// Token: 0x06003DBD RID: 15805 RVA: 0x000D85F4 File Offset: 0x000D67F4
	private void PopulateInventory_Recurse(ref global::LootSpawnList.RecursiveInventoryPopulateArgs args)
	{
		if (this.maxPackagesToSpawn > this.LootPackages.Length)
		{
			this.maxPackagesToSpawn = this.LootPackages.Length;
		}
		int num;
		if (this.spawnOneOfEach)
		{
			num = this.LootPackages.Length;
		}
		else
		{
			num = global::UnityEngine.Random.Range(this.minPackagesToSpawn, this.maxPackagesToSpawn);
		}
		int num2 = 0;
		while (!args.inventoryExausted && num2 < num)
		{
			global::LootSpawnList.LootWeightedEntry lootWeightedEntry;
			if (this.spawnOneOfEach)
			{
				lootWeightedEntry = this.LootPackages[num2];
			}
			else
			{
				lootWeightedEntry = (global::WeightSelection.RandomPickEntry(this.LootPackages) as global::LootSpawnList.LootWeightedEntry);
			}
			if (lootWeightedEntry == null)
			{
				global::UnityEngine.Debug.Log("Massive fuckup...");
				return;
			}
			global::UnityEngine.Object obj = lootWeightedEntry.obj;
			if (obj)
			{
				if (obj is global::ItemDataBlock)
				{
					global::ItemDataBlock datablock = obj as global::ItemDataBlock;
					if (!object.ReferenceEquals(args.inventory.AddItem(datablock, global::Inventory.Slot.Preference.Define(args.spawnCount, false, global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt), global::UnityEngine.Random.Range(lootWeightedEntry.amountMin, lootWeightedEntry.amountMax + 1)), null))
					{
						args.spawnCount++;
						if (args.inventory.noVacantSlots)
						{
							args.inventoryExausted = true;
						}
					}
				}
				else if (obj is global::LootSpawnList)
				{
					((global::LootSpawnList)obj).PopulateInventory_Recurse(ref args);
				}
			}
			num2++;
		}
	}

	// Token: 0x04001F2B RID: 7979
	public global::LootSpawnList.LootWeightedEntry[] LootPackages;

	// Token: 0x04001F2C RID: 7980
	public int minPackagesToSpawn = 1;

	// Token: 0x04001F2D RID: 7981
	public int maxPackagesToSpawn = 1;

	// Token: 0x04001F2E RID: 7982
	public bool noDuplicates;

	// Token: 0x04001F2F RID: 7983
	public bool spawnOneOfEach;

	// Token: 0x0200071B RID: 1819
	[global::System.Serializable]
	public class LootWeightedEntry : global::WeightSelection.WeightedEntry
	{
		// Token: 0x06003DBE RID: 15806 RVA: 0x000D874C File Offset: 0x000D694C
		public LootWeightedEntry()
		{
		}

		// Token: 0x04001F30 RID: 7984
		public int amountMin;

		// Token: 0x04001F31 RID: 7985
		public int amountMax = 1;
	}

	// Token: 0x0200071C RID: 1820
	private struct RecursiveInventoryPopulateArgs
	{
		// Token: 0x04001F32 RID: 7986
		public global::Inventory inventory;

		// Token: 0x04001F33 RID: 7987
		public int spawnCount;

		// Token: 0x04001F34 RID: 7988
		public bool inventoryExausted;
	}
}
