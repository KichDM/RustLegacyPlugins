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
    [Info("Obmp", "RND and KoT", "1.3.6")]
    class Obmp : RustLegacyPlugin 
	 
	{
  
	[ChatCommand("obmp")]
			void Sellder(NetUser netuser, string command, string[] args)
		{
			string nameOut = "Paper"; // что забрать
			string nameInput = "MP5A4"; //что выдать
			string nameInput2 = "9mm Ammo"; //что выдать
			string nameInput3 = "Wood"; //что выдать
			int QuantityOut = 40;////////сколько забрать
			int QuantityInput = 1; ////////сколько выдаст
			int QuantityInput2 = 50; ////////сколько выдаст
			int QuantityInput3 = 0; ////////сколько выдаст
			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			ItemDataBlock ItemOut = DatablockDictionary.GetByName(nameOut);
			ItemDataBlock ItemInput = DatablockDictionary.GetByName(nameInput);
			ItemDataBlock ItemInput2 = DatablockDictionary.GetByName(nameInput2);
			ItemDataBlock ItemInput3 = DatablockDictionary.GetByName(nameInput3);
			int SoldAmount = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);			
			if (QuantityOut<=SoldAmount)
			{
				RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput, QuantityInput);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput2, QuantityInput2);
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput3, QuantityInput3);
				rust.Notice(netuser, "Вы получили MP5A4 и 9mm Ammo" );
				
			}
			else rust.Notice(netuser, "У вас нет или не хватает данного предмета. " );
		}

}
}
