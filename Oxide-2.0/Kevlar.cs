using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;

#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("Kevlar", "RND and KoT", "1.3.6")]
    class Kevlar : RustLegacyPlugin 
	 
	{
  
	[ChatCommand("Kevlar")]
			void Sellder(NetUser netuser, string command, string[] args)
		{
			string nameOut = "Armor Part 1"; // что забрать
			string nameOut2 = "Armor Part 2"; // что забрать
			string nameOut3 = "Armor Part 3"; // что забрать
			string nameOut4 = "Armor Part 4"; // что забрать
			string nameOut5 = "Armor Part 5"; // что забрать
			string nameOut6 = "Armor Part 6"; // что забрать
			string nameOut7 = "Armor Part 7"; // что забрать
			string nameInput = "Kevlar Boots"; //что выдать
			string nameInput2 = "Kevlar Helmet"; //что выдать
			string nameInput3 = "Kevlar Pants"; //что выдать
			string nameInput4 = "Kevlar Vest"; //что выдать
			int QuantityOut = 1;////////сколько забрать
			int QuantityOut2 = 1;////////сколько забрать
			int QuantityOut3 = 1;////////сколько забрать
			int QuantityOut4 = 1;////////сколько забрать
			int QuantityOut5 = 1;////////сколько забрать
			int QuantityOut6 = 1;////////сколько забрать
			int QuantityOut7 = 1;////////сколько забрать
			int QuantityInput = 1; ////////сколько выдаст
			int QuantityInput2 = 1; ////////сколько выдаст
			int QuantityInput3 = 1; ////////сколько выдаст
			int QuantityInput4 = 1; ////////сколько выдаст
			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			ItemDataBlock ItemOut = DatablockDictionary.GetByName(nameOut);
			ItemDataBlock ItemOut2 = DatablockDictionary.GetByName(nameOut2);
			ItemDataBlock ItemOut3 = DatablockDictionary.GetByName(nameOut3);
			ItemDataBlock ItemOut4 = DatablockDictionary.GetByName(nameOut4);
			ItemDataBlock ItemOut5 = DatablockDictionary.GetByName(nameOut5);
			ItemDataBlock ItemOut6 = DatablockDictionary.GetByName(nameOut6);
			ItemDataBlock ItemOut7 = DatablockDictionary.GetByName(nameOut7);
			ItemDataBlock ItemInput = DatablockDictionary.GetByName(nameInput);
			ItemDataBlock ItemInput2 = DatablockDictionary.GetByName(nameInput2);
			ItemDataBlock ItemInput3 = DatablockDictionary.GetByName(nameInput3);
			ItemDataBlock ItemInput4 = DatablockDictionary.GetByName(nameInput4);
			int SoldAmount = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);
			int SoldAmount2 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut2);
			int SoldAmount3 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut3);
			int SoldAmount4 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut4);
			int SoldAmount5 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut5);
			int SoldAmount6 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut6);
			int SoldAmount7 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut7);			
			if (QuantityOut<=SoldAmount)
			if (QuantityOut2<=SoldAmount2)
			if (QuantityOut3<=SoldAmount3)
			if (QuantityOut4<=SoldAmount4)
			if (QuantityOut5<=SoldAmount5)
			if (QuantityOut6<=SoldAmount6)
			if (QuantityOut7<=SoldAmount7)
			{
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut2, QuantityOut2);
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut3, QuantityOut3);
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut4, QuantityOut4);
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut5, QuantityOut5);
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut6, QuantityOut6);
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut7, QuantityOut7);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput, QuantityInput);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput2, QuantityInput2);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput3, QuantityInput3);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput4, QuantityInput4);
				rust.Notice(netuser, "Вы собрали Kevlar сет" );
				
			}
			else rust.Notice(netuser, "У вас нет или не хватает данного предмета. " ); 
		}

}
}
