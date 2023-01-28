﻿//==============================================================  //
// RustExtended Мод					                             //
// Полная настройка,перевод Jackson                             //
// https://vk.com/jacksonspain	 				               //
// Последняя Обнова: 02.12.2017					              //
//===========================================================//

using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using System.Collections.Generic;
using RustProto;
using RustExtended;
using Oxide.Core.Libraries;

namespace Oxide.Plugins
{
    [Info("ObmenStones", "Aspire", "1.0")]
    class ObmenStones : RustLegacyPlugin
    {
		public string chatName = "Next Level";
		[ChatCommand("ob")]
		void cmdObm(NetUser netuser, string command, string[] args)
		{
			string ID = netuser.userID.ToString();
			ItemDataBlock ItemOut = DatablockDictionary.GetByName("Stones");
			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			int SoldAmount = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);
			int QuantityOut;
			if(args.Length == 0)
				{
					rust.SendChatMessage(netuser, chatName, string.Format("1000 Stones - 250 Sulfur Ore"));
					rust.SendChatMessage(netuser, chatName, string.Format("1000 Stones - 250 Metal Ore  /ob metal "));
					rust.SendChatMessage(netuser, chatName, string.Format("100 Stones - 250 Wood ] /ob wood "));
					rust.SendChatMessage(netuser, chatName, string.Format("750 Stones - 250 Animal Fat  /ob animal "));
					return;
				}
			switch (args[0].ToLower())
			{				
			case "sulfur":
					QuantityOut=1000;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Sulfur Ore"), 250);
						rust.SendChatMessage(netuser, chatName, string.Format("Вы сдали {0} Stones и получили {1}", QuantityOut, "250 Sulfur Ore"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("У вас {0}, а нужно {1}", SoldAmount, QuantityOut));
			
				break;				
			case "metal":
					QuantityOut=1000;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Metal Ore"), 250);
						rust.SendChatMessage(netuser, chatName, string.Format("Вы сдали {0} Stones и получили {1}", QuantityOut, "250 Metal Ore"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("]У вас {0}, а нужно {1}", SoldAmount, QuantityOut));
			
				break;
			case "wood":
					QuantityOut=100;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Wood"), 250);
						rust.SendChatMessage(netuser, chatName, string.Format(" Вы сдали {0} Stones и получили {1}", QuantityOut, "250 Wood"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("У вас {0}, а нужно {1}", SoldAmount, QuantityOut));
			
				break;
			case "animal":
					QuantityOut=750;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Animal Fat"), 250);
						rust.SendChatMessage(netuser, chatName, string.Format("Вы сдали {0} Stones и получили {1}", QuantityOut, "250 Animal Fat"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("У вас {0}, а нужно {1}", SoldAmount, QuantityOut));
			
				break;
			}
		}	
		
		
	}
}