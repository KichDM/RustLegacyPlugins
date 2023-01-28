/*---------------------------------------------------\
Плагин               :  eat                          |
Автор                :  Unkown (vk.com/jacksonspain) |
Дата создания        :  27.03.2018                   |
Последнее обновление :  10.04.2018                   |
----------------------------------------------------*/
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

// Reference: Oxide.Ext.RustLegacy
// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers

namespace Oxide.Plugins
{
    [Info("RawChickenBreast", "Unkown", "1.0")]
    class RawChickenBreast : RustLegacyPlugin
    {
		public string chatName = "RustDiablo:CLASSIC";
		[ChatCommand("eat")]
		void cmdObm(NetUser netuser, string command, string[] args)
		{
			string ID = netuser.userID.ToString();
			ItemDataBlock ItemOut = DatablockDictionary.GetByName("Raw Chicken Breast");
			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			int SoldAmount = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);
			int QuantityOut;
			if(args.Length == 0)
				{
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]----------------------------------------[COLOR#4169E1]---------------------------------------- "));
					rust.SendChatMessage(netuser, chatName, string.Format("Из 1 сырого мяса вы получаете 1 жаренное мясо. ")); 
					rust.SendChatMessage(netuser, chatName, string.Format("Данная функция позволяет обменять сырого мяса на жаренное. ")); 
					rust.SendChatMessage(netuser, chatName, string.Format("Для использование данной функции пропишите команду /eat ")); 
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4169E1]----------------------------------------[COLOR#FFFFFF]---------------------------------------- "));
					return;
				}
			switch (args[0].ToLower())
			{				
			case "1":
					QuantityOut=1;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Cooked Chicken Breast"), 1);
						rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]Вы сдали [COLOR#4169E1] {0} [COLOR#FFFFFF]Raw Chicken Breast [COLOR#FFFFFF]и получили [COLOR#4169E1]{1}", QuantityOut, "[COLOR#4169E1]1 [COLOR#FFFFFF]Cooked Chicken Breast"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]У вас [COLOR#4169E1] {0} [COLOR#FFFFFF], а нужно [COLOR#4169E1]{1}", SoldAmount, QuantityOut));
			
				break;	
			}
		}	
		
		
	}
}