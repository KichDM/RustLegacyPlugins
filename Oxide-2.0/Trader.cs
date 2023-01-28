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
    [Info("Trader", "misvor", "0.1")]
    class Trader : RustLegacyPlugin
	 
	{
  
	[ChatCommand("ob")]
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
                SendReply(netuser, "[color#00FF00]------------------Охота за листовками------------------");
                SendReply(netuser, "[color#FF4500]Собирай листовки(бумагу) и обменивай на призы.");
                SendReply(netuser, "[color#FFD700]/ob 1 [color#00FFFF]•[color#FFDEAD] 20х - P250, 50 Ammo.");
                SendReply(netuser, "[color#FFD700]/ob 2 [color#00FFFF]•[color#FFDEAD] 40х - MP5, 100 Ammo.");
                SendReply(netuser, "[color#FFD700]/ob 3 [color#00FFFF]•[color#FFDEAD] 60х - M4, 80 Ammo.");
                SendReply(netuser, "[color#FFD700]/ob 4 [color#00FFFF]•[color#FFDEAD] 80х - Bolt, 80 Ammo.");
                SendReply(netuser, "[color#FFD700]/ob 5 [color#00FFFF]•[color#FFDEAD] 55х - Shotgun, 16 Ammo.");
                SendReply(netuser, "[color#FFD700]/ob 6 [color#00FFFF]•[color#FFDEAD] 150х - C4 x5.");
                SendReply(netuser, "[color#00FF00]---------------------------------------------------------------");
			}
			if ((args.Length>0)&&(args[0].ToString() == "1" || args[0].ToString() == "2"||args[0].ToString() == "3"||args[0].ToString() == "4"||args[0].ToString() == "5"||args[0].ToString() == "6"))
			{
				if (args[0].ToString() == "1" || args[0].ToString() == "2"||args[0].ToString() == "3"||args[0].ToString() == "4"||args[0].ToString() == "5"||args[0].ToString() == "6")
				{
					if (args[0].ToString() == "1")
					{
						QuantityOut=20;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(one, 1);
								inventory.AddItemAmount(onep, 40);
								rust.InventoryNotice(netuser, "Предмет выдан!" );
							}else rust.InventoryNotice(netuser, "Недостаточно бумаги" );
					}
					else if (args[0].ToString() == "2")
					{
						QuantityOut=40;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(two, 1);
								inventory.AddItemAmount(twop, 50);
								
								rust.InventoryNotice(netuser, "Предмет выдан!" );
							}else rust.InventoryNotice(netuser, "Недостаточно бумаги" );
					}
					else if (args[0].ToString() == "3")
					{
						QuantityOut=60;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(three, 1);
								inventory.AddItemAmount(threep, 55);
								
								rust.InventoryNotice(netuser, "Предмет выдан!" );
							}else rust.InventoryNotice(netuser, "Недостаточно бумаги" );
					}
					else if (args[0].ToString() == "4")
					{
						QuantityOut=80;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(four, 1);
								inventory.AddItemAmount(fourp, 60);
								
								rust.InventoryNotice(netuser, "Предмет выдан!" );
							}else rust.InventoryNotice(netuser, "Недостаточно бумаги" );
					}
                    else if (args[0].ToString() == "5")
					{
						QuantityOut=40;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(six, 1);
								inventory.AddItemAmount(sixp, 16);
								
								rust.InventoryNotice(netuser, "Предмет выдан!" );
							}else rust.InventoryNotice(netuser, "Недостаточно бумаги" );
					}

					else if (args[0].ToString() == "6")
					{
						QuantityOut=150;
						if (QuantityOut<=SoldAmount)
							{
								RustExtended.Helper.InventoryItemRemove(inventory, ItemOut, QuantityOut);
								inventory.AddItemAmount(five, 5);								
								rust.InventoryNotice(netuser, "Предмет выдан!" );
							}else rust.InventoryNotice(netuser, "Недостаточно бумаги" );
					}
				}
			}
//			}esle rust.InventoryNotice(netuser, "Хуйня" );
		}

}
}