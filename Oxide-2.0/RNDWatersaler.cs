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
    [Info("RNDWatersaler", "lutSEfer", "1.0.0")]
    class RNDWatersaler : RustLegacyPlugin
    {
		public string chatName = "ОБМЕН";
		[ChatCommand("ob")]
		void cmdObm(NetUser netuser, string command, string[] args)
		{
			string ID = netuser.userID.ToString();
			ItemDataBlock ItemOut = DatablockDictionary.GetByName("Small Water Bottle");
			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			int SoldAmount = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);
			int QuantityOut;
			if(args.Length == 0)
				{
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]25 бутылок [COLOR#00FF00]» [COLOR#FFFFFF]P250 [color#388FFF] /ob p250  [COLOR#388FFF]"));
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]35 бутылок [COLOR#00FF00]» [COLOR#FFFFFF]MP5A4 [color#388FFF] /ob mp  [color#00FF00]"));
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]50 бутылок [COLOR#00FF00]» [COLOR#FFFFFF]M4 [color#388FFF] /ob m4  [color#00FF00]"));
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]65 бутылок [COLOR#00FF00]» [COLOR#FFFFFF]Bolt Action Rifle [color#388FFF] /ob bolt  [color#00FF00]"));
					rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]150 бутылок [COLOR#00FF00]» [COLOR#FFFFFF]Explosives 17шт [color#388FFF] /ob exp  [color#00FF00]"));
					return;
				}
			switch (args[0].ToLower())
			{
			case "p250":
					QuantityOut=25;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("P250"), 1);
						rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF] Вы сдали [COLOR#388FFF]{0}[COLOR#FFFFFF] воды и получили [COLOR#388FFF]{1}", QuantityOut, "P250"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]У вас [COLOR#388FFF]{0}[COLOR#FFFFFF] бутылок, а нужно[COLOR#388FFF] {1}", SoldAmount, QuantityOut));
				break;
			case "mp":
					QuantityOut=35;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("MP5A4"), 1);
						rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF] Вы сдали [COLOR#388FFF] {0}[COLOR#FFFFFF]воды и получили [COLOR#388FFF]{1}", QuantityOut, "MP5A4"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]У вас [COLOR#388FFF]{0} [COLOR#FFFFFF] бутылок, а нужно [COLOR#388FFF] {1}", SoldAmount, QuantityOut));
				break;				
			case "m4":
					QuantityOut=50;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("M4"), 1);
						rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF] Вы сдали [COLOR#388FFF]{0} [COLOR#FFFFFF] бутылок и получили [COLOR#388FFF]{1}", QuantityOut, "M4"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]У вас [COLOR#388FFF] {0} [COLOR#FFFFFF]бутылок, а нужно [COLOR#388FFF] {1}", SoldAmount, QuantityOut));
			
				break;				
			case "bolt":
					QuantityOut=65;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Bolt Action Rifle"), 1);
						rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF] Вы сдали [COLOR#388FFF] {0} [COLOR#FFFFFF] бутылок и получили [COLOR#388FFF] {1}", QuantityOut, "Bolt Action Rifle"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]У вас [COLOR#388FFF] {0}[COLOR#FFFFFF] бутылок, а нужно [COLOR#388FFF] {1}", SoldAmount, QuantityOut));
			
				break;
				case "exp":
					QuantityOut=150;
					if (QuantityOut<=SoldAmount)
					{
						RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
						inventory.AddItemAmount(DatablockDictionary.GetByName("Explosives"), 17);
						rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF] Вы сдали [COLOR#388FFF] {0} [COLOR#FFFFFF]бутылок и получили [COLOR#388FFF]{1}", QuantityOut, "Explosives 17 шт"));
					}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FFFFFF]У вас [COLOR#388FFF] {0} [COLOR#FFFFFF] бутылок, а нужно [COLOR#388FFF]{1}", SoldAmount, QuantityOut));
			
				break;
			}
		}	
		
		
	}
}