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
    [Info("Paper", "BaNDiT", "7.7.7")]
    class Paper : RustLegacyPlugin
	 
	{
  
	[ChatCommand("paper")]
			void ob(NetUser netuser, string command, string[] args)
		{
			string nameOut = "Paper"; // 
			int QuantityOut;////////
			////
			var one = DatablockDictionary.GetByName("P250");
			var onep = DatablockDictionary.GetByName("9mm Ammo");
			////
			var two = DatablockDictionary.GetByName("MP5A4");
			var twop = DatablockDictionary.GetByName("9mm Ammo");
			////
			var three = DatablockDictionary.GetByName("M4");
			var threep = DatablockDictionary.GetByName("556 Ammo");
			////
			var four = DatablockDictionary.GetByName("Bolt Action Rifle");
			var fourp = DatablockDictionary.GetByName("556 Ammo");
			/////
			var five = DatablockDictionary.GetByName("Explosive Charge");
            /////
            var six = DatablockDictionary.GetByName("Shotgun");
            var sixp = DatablockDictionary.GetByName("Shotgun Shells");
			ItemDataBlock ItemOut = DatablockDictionary.GetByName(nameOut);
			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			int SoldAmount = RustExtended.Helper.InventoryItemCount(inventory, ItemOut);
			if (args.Length==0)
			{
				SendReply(netuser, "___________ [COLOR#42AAFF]ОБМЕН БУМАГИ [COLOR#FFFFFF]___________");
                SendReply(netuser, "12 [COLOR#32CD32]Paper [COLOR#FFFFFF]= [COLOR#32CD32]P250 [COLOR#FFFFFF]50 патрон. [COLOR#42AAFF]/paper 1");
                SendReply(netuser, "20 [COLOR#32CD32]Paper [COLOR#FFFFFF]= [COLOR#32CD32]MP5A4 [COLOR#FFFFFF]75 патрон. [COLOR#42AAFF]/paper 2");
                SendReply(netuser, "60 [COLOR#32CD32]Paper [COLOR#FFFFFF]= [COLOR#32CD32]M4 [COLOR#FFFFFF]100 патрон. [COLOR#42AAFF]/paper 3");
                SendReply(netuser, "80 [COLOR#32CD32]Paper [COLOR#FFFFFF]= [COLOR#32CD32]Bolt Action Rifle [COLOR#FFFFFF]50 патрон. [COLOR#42AAFF]/paper 4");
				SendReply(netuser, "40 [COLOR#32CD32]Paper [COLOR#FFFFFF]= [COLOR#32CD32]Shotgun [COLOR#FFFFFF]25 патрон. [COLOR#42AAFF]/paper 5");
                SendReply(netuser, "150 [COLOR#32CD32]Paper [COLOR#FFFFFF]= [COLOR#32CD32]Explosive Charge [COLOR#FFFFFF]2 штук. [COLOR#42AAFF]/paper 6");
				SendReply(netuser, "___________ [COLOR#42AAFF]ОБМЕН БУМАГИ [COLOR#FFFFFF]___________");
			}
			if ((args.Length>0)&&(args[0].ToString() == "1" || args[0].ToString() == "2"||args[0].ToString() == "3"||args[0].ToString() == "4"||args[0].ToString() == "5"||args[0].ToString() == "6"))
			{
				if (args[0].ToString() == "1" || args[0].ToString() == "2"||args[0].ToString() == "3"||args[0].ToString() == "4"||args[0].ToString() == "5"||args[0].ToString() == "6")
				{
					if (args[0].ToString() == "1")
					{
						QuantityOut=12;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(one, 1);
								inventory.AddItemAmount(onep, 50);
								rust.InventoryNotice(netuser, "Откройте инвентарь." );
							}else rust.InventoryNotice(netuser, "Не хватает бумаги." );
					}
					else if (args[0].ToString() == "2")
					{
						QuantityOut=20;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(two, 1);
								inventory.AddItemAmount(twop, 75);
								
								rust.InventoryNotice(netuser, "Откройте инвентарь." );
							}else rust.InventoryNotice(netuser, "Не хватает бумаги." );
					}
					else if (args[0].ToString() == "3")
					{
						QuantityOut=60;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(three, 1);
								inventory.AddItemAmount(threep, 100);
								
								rust.InventoryNotice(netuser, "Откройте инвентарь." );
							}else rust.InventoryNotice(netuser, "Не хватает бумаги." );
					}
					else if (args[0].ToString() == "4")
					{
						QuantityOut=80;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(four, 1);
								inventory.AddItemAmount(fourp, 50);
								
								rust.InventoryNotice(netuser, "Откройте инвентарь." );
							}else rust.InventoryNotice(netuser, "Не хватает бумаги." );
					}
                    else if (args[0].ToString() == "5")
					{
						QuantityOut=40;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(six, 1);
								inventory.AddItemAmount(sixp, 25);
								
								rust.InventoryNotice(netuser, "Откройте инвентарь." );
							}else rust.InventoryNotice(netuser, "Не хватает бумаги." );
					}

					else if (args[0].ToString() == "6")
					{
						QuantityOut=150;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(five, 2);								
								rust.InventoryNotice(netuser, "Откройте инвентарь." );
							}else rust.InventoryNotice(netuser, "Не хватает бумаги." );
					}
				}
			}

		}

}
}