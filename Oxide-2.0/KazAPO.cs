/*---------------------------------------------------\
Плагин               :  KazAPO                       |
Автор                :  Kazzooom                     |
Связь                :  ВК: vk.com/md4327            |
Дата создания        :  02.03.2021                   |
\----------------------------------------------------*/
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("KazAPO", "Kazzooom", "0.0.1")]
    class KazAPO : RustLegacyPlugin
	{
        static string chatName = "Rust Dark";

        [ChatCommand("armor")]
	 	void APO(NetUser netuser, string command, string[] args)

		{
	string AP = "Armor Part";
	/////
	string nameOut  = "Armor Part 1";
	string nameOut2 = "Armor Part 2";
	string nameOut3 = "Armor Part 3";
	string nameOut4 = "Armor Part 4";
	string nameOut5 = "Armor Part 5";
	string nameOut6 = "Armor Part 6";
	string nameOut7 = "Armor Part 7";
	/////
	int QuantityOut;
	/////
	var ap1   = DatablockDictionary.GetByName("Stones");
	/////
	var ap2  = DatablockDictionary.GetByName("Metal Ore");
	/////
	var ap3  = DatablockDictionary.GetByName("Sulfur Ore");
	/////
	var ap4  = DatablockDictionary.GetByName("Cloth");
	/////
	var ap5  = DatablockDictionary.GetByName("Animal Fat");
	/////
	var ap6  = DatablockDictionary.GetByName("Leather");
	/////
	var ap7  = DatablockDictionary.GetByName("Low Grade Fuel");
	/////
	ItemDataBlock ItemOut  = DatablockDictionary.GetByName(nameOut);
	ItemDataBlock ItemOut2 = DatablockDictionary.GetByName(nameOut2);
	ItemDataBlock ItemOut3 = DatablockDictionary.GetByName(nameOut3);
	ItemDataBlock ItemOut4 = DatablockDictionary.GetByName(nameOut4);
	ItemDataBlock ItemOut5 = DatablockDictionary.GetByName(nameOut5);
	ItemDataBlock ItemOut6 = DatablockDictionary.GetByName(nameOut6);
	ItemDataBlock ItemOut7 = DatablockDictionary.GetByName(nameOut7);
	Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>(); 
	int SoldAmount  = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);
	int SoldAmount2 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut2);
	int SoldAmount3 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut3);
	int SoldAmount4 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut4);
	int SoldAmount5 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut5);
	int SoldAmount6 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut6);
	int SoldAmount7 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut7);
			if (args.Length==0)
			{
			rust.SendChatMessage(netuser, chatName, string.Format("[color#00FF00]===============[COLOR#FF0000] Охота за Armor Part [COLOR#00FF00]====================="));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 1 [COLOR#FF0000]» [COLOR#4682B4]Stones x200[COLOR#FF0000] » [COLOR#4682B4](/armor 1)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 2 [COLOR#FF0000]» [COLOR#4682B4]Metal Ore x200[COLOR#FF0000] » [COLOR#4682B4](/armor 2)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 3 [COLOR#FF0000]» [COLOR#4682B4]Sulfur Ore x200[COLOR#FF0000] » [COLOR#4682B4](/armor 3)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 4 [COLOR#FF0000]» [COLOR#4682B4]Cloth x150[COLOR#FF0000] » [COLOR#4682B4](/armor 4)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 5 [COLOR#FF0000]» [COLOR#4682B4]Animal Fat x150[COLOR#FF0000] » [COLOR#4682B4](/armor 5)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 6 [COLOR#FF0000]» [COLOR#4682B4]Leather x100[COLOR#FF0000] » [COLOR#4682B4](/armor 6)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#FF0000]» [COLOR#4682B4]Armor Part 7 [COLOR#FF0000]» [COLOR#4682B4]Low Grade Fuel x150[COLOR#FF0000] » [COLOR#4682B4](/armor 7)"));
			rust.SendChatMessage(netuser, chatName, string.Format("[color#00FF00]======================================================="));	
			}
			if ((args.Length>0)&&(args[0].ToString() == "1" || args[0].ToString() == "2"||args[0].ToString() == "3"||args[0].ToString() == "4"||args[0].ToString() == "5"||args[0].ToString() == "6"||args[0].ToString() == "7"))
			{
				if (args[0].ToString() == "1" || args[0].ToString() == "2"||args[0].ToString() == "3"||args[0].ToString() == "4"||args[0].ToString() == "5"||args[0].ToString() == "6"||args[0].ToString() == "7")
				{
					if (args[0].ToString() == "1")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(ap1, 200);
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut));
					}
					else if (args[0].ToString() == "2")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount2)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut2, QuantityOut);
								inventory.AddItemAmount(ap2, 200);
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut2));					
                    }
					else if (args[0].ToString() == "3")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount3)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut3, QuantityOut);
								inventory.AddItemAmount(ap3, 200);
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut3));
					}
					else if (args[0].ToString() == "4")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount4)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut4, QuantityOut);
								inventory.AddItemAmount(ap4, 150);
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut4));
					}
                    else if (args[0].ToString() == "5")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount5)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut5, QuantityOut);
								inventory.AddItemAmount(ap5, 150);
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut5));
					}
				else if (args[0].ToString() == "6")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount6)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut6, QuantityOut);
								inventory.AddItemAmount(ap6, 100);
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut6));
					}
					else if (args[0].ToString() == "7")
					{
						QuantityOut=1;
						if (QuantityOut<=SoldAmount7)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut7, QuantityOut);
								inventory.AddItemAmount(ap7, 150);									
								rust.InventoryNotice(netuser, "Предмет обменен!" );
     		}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]У вас нету [COLOR#FF0000]{0}", nameOut7));
					}
				}
			}else rust.SendChatMessage(netuser, chatName, string.Format("[COLOR#4682B4]Нашел? [COLOR#FF0000]{0} [COLOR#4682B4]Обменяй его на Ресурсы", AP));
		}
}
}