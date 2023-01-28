using System;
using System.Collections.Generic;
using Facepunch;
using Magma;
using UnityEngine;

// Token: 0x020006C2 RID: 1730
public class DatablockDictionary
{
	// Token: 0x06003B3A RID: 15162 RVA: 0x000D247C File Offset: 0x000D067C
	public DatablockDictionary()
	{
	}

	// Token: 0x17000B1A RID: 2842
	// (get) Token: 0x06003B3B RID: 15163 RVA: 0x000D2484 File Offset: 0x000D0684
	public static global::ItemDataBlock[] All
	{
		get
		{
			return global::DatablockDictionary._all;
		}
	}

	// Token: 0x06003B3C RID: 15164 RVA: 0x000D248C File Offset: 0x000D068C
	public static void TryInitialize()
	{
		if (!global::DatablockDictionary.initializedAtLeastOnce)
		{
			global::DatablockDictionary.Initialize();
		}
	}

	// Token: 0x06003B3D RID: 15165 RVA: 0x000D24A0 File Offset: 0x000D06A0
	public static void Initialize()
	{
		global::DatablockDictionary._dataBlocks = new global::System.Collections.Generic.Dictionary<string, int>();
		global::DatablockDictionary._dataBlocksByUniqueID = new global::System.Collections.Generic.Dictionary<int, int>();
		global::DatablockDictionary._lootSpawnLists = new global::System.Collections.Generic.Dictionary<string, global::LootSpawnList>();
		global::System.Collections.Generic.List<global::ItemDataBlock> list = new global::System.Collections.Generic.List<global::ItemDataBlock>();
		global::System.Collections.Generic.HashSet<global::ItemDataBlock> hashSet = new global::System.Collections.Generic.HashSet<global::ItemDataBlock>();
		foreach (global::ItemDataBlock item in global::Facepunch.Bundling.LoadAll<global::ItemDataBlock>())
		{
			if (hashSet.Add(item))
			{
				list.Add(item);
			}
		}
		global::DatablockDictionary._all = global::Magma.Hooks.ItemsLoaded(list, global::DatablockDictionary._dataBlocks, global::DatablockDictionary._dataBlocksByUniqueID);
		foreach (global::LootSpawnList lootSpawnList in global::Facepunch.Bundling.LoadAll<global::LootSpawnList>())
		{
			global::DatablockDictionary._lootSpawnLists.Add(lootSpawnList.name, lootSpawnList);
		}
		global::DatablockDictionary._lootSpawnLists = global::Magma.Hooks.TablesLoaded(global::DatablockDictionary._lootSpawnLists);
		global::DatablockDictionary.initializedAtLeastOnce = true;
	}

	// Token: 0x06003B3E RID: 15166 RVA: 0x000D2574 File Offset: 0x000D0774
	public static global::ItemDataBlock GetByUniqueID(int uniqueID)
	{
		int num;
		if (!global::DatablockDictionary._dataBlocksByUniqueID.TryGetValue(uniqueID, out num))
		{
			return null;
		}
		return global::DatablockDictionary._all[num];
	}

	// Token: 0x06003B3F RID: 15167 RVA: 0x000D259C File Offset: 0x000D079C
	public static global::ItemDataBlock GetByName(string name)
	{
		int num;
		if (!global::DatablockDictionary._dataBlocks.TryGetValue(name, out num))
		{
			return null;
		}
		return global::DatablockDictionary._all[num];
	}

	// Token: 0x06003B40 RID: 15168 RVA: 0x000D25C4 File Offset: 0x000D07C4
	public static global::LootSpawnList GetLootSpawnListByName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		global::LootSpawnList result;
		if (!global::DatablockDictionary._lootSpawnLists.TryGetValue(name, out result))
		{
			global::UnityEngine.Debug.LogError("Theres no loot spawn list with name " + name);
		}
		return result;
	}

	// Token: 0x06003B41 RID: 15169 RVA: 0x000D2604 File Offset: 0x000D0804
	public static TArmorModel GetArmorModelByUniqueID<TArmorModel>(int uniqueID) where TArmorModel : global::ArmorModel, new()
	{
		global::ArmorDataBlock armorDataBlock = global::DatablockDictionary.GetByUniqueID(uniqueID) as global::ArmorDataBlock;
		if (!armorDataBlock)
		{
			return (TArmorModel)((object)null);
		}
		return armorDataBlock.GetArmorModel<TArmorModel>();
	}

	// Token: 0x06003B42 RID: 15170 RVA: 0x000D2638 File Offset: 0x000D0838
	public static global::ArmorModel GetArmorModelByUniqueID(int uniqueID, global::ArmorModelSlot slot)
	{
		global::ArmorDataBlock armorDataBlock = global::DatablockDictionary.GetByUniqueID(uniqueID) as global::ArmorDataBlock;
		if (!armorDataBlock)
		{
			return null;
		}
		return armorDataBlock.GetArmorModel(slot);
	}

	// Token: 0x04001E46 RID: 7750
	private const int expectedDBListLength = 0xE;

	// Token: 0x04001E47 RID: 7751
	private static global::System.Collections.Generic.Dictionary<string, int> _dataBlocks;

	// Token: 0x04001E48 RID: 7752
	private static global::System.Collections.Generic.Dictionary<int, int> _dataBlocksByUniqueID;

	// Token: 0x04001E49 RID: 7753
	private static global::ItemDataBlock[] _all;

	// Token: 0x04001E4A RID: 7754
	public static global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> _lootSpawnLists;

	// Token: 0x04001E4B RID: 7755
	private static bool initializedAtLeastOnce;
}
