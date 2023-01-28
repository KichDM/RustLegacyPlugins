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
    [Info("Suplycraft", "Atamg1994", "0.1.9")]
    class Suplycraft : RustLegacyPlugin 
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
		
		public static string nameOut8;
        public static int QuantityOut8;
		
		public static string nameOut9;
        public static int QuantityOut9;
  
	[ChatCommand("ss")]
			void cmdChatSs(NetUser netuser, string command, string[] args)
		{           
		    string tagChat = "Supply Signal"; 
			
			string nameInput = "Supply Signal"; 
			int QuantityInput = 1;
			int setall = 0;
			
			string nameOut1 = "Paper"; 
			int QuantityOut1 = 200;
			
			string nameOut2 = "Low Quality Metal"; 
			int QuantityOut2 = 200;
			
			string nameOut3 = "Gunpowder"; 
			int QuantityOut3 = 500;
			
			string nameOut4 = "F1 Grenade"; 
			int QuantityOut4 = 1;
			
			string nameOut5 = "Explosives"; 
			int QuantityOut5 = 10;
			
			string nameOut6 = "Research Kit 1"; 
			int QuantityOut6 = 1;
			
			string nameOut7 = "Flare"; 
			int QuantityOut7 = 5;
			
			string nameOut8 = "Low Grade Fuel"; 
			int QuantityOut8 = 150;
			
			string nameOut9 = "Silencer"; 
			int QuantityOut9 = 1;

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

			ItemDataBlock ItemOut8 = DatablockDictionary.GetByName(nameOut8);
			int SoldAmount8 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut8);	

			ItemDataBlock ItemOut9 = DatablockDictionary.GetByName(nameOut9);
			int SoldAmount9 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut9);			
			
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
			if (QuantityOut8<=SoldAmount8)
			{setall++;}
			if (QuantityOut9<=SoldAmount9)
			{setall++;}

		if (setall>=9)
		{
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut1, QuantityOut1);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut2, QuantityOut2);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut3, QuantityOut3);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut4, QuantityOut4);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut5, QuantityOut5);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut6, QuantityOut6);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut7, QuantityOut7);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut8, QuantityOut8);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut9, QuantityOut9);
		
		RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput, QuantityInput);
					rust.Notice(netuser, "Вы получили Supply Signal" );
		}else{
		string filename1 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut1.name.ToString(), QuantityOut1.ToString(), SoldAmount1.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename1);
			  
		string filename2 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut2.name.ToString(), QuantityOut2.ToString(), SoldAmount2.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename2);
		
		string filename3 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut3.name.ToString(), QuantityOut3.ToString(), SoldAmount3.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename3);
			  
	    string filename4 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut4.name.ToString(), QuantityOut4.ToString(), SoldAmount4.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename4);

		string filename5 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut5.name.ToString(), QuantityOut5.ToString(), SoldAmount5.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename5);
			  
		string filename6 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut6.name.ToString(), QuantityOut6.ToString(), SoldAmount6.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename6);
			  
		string filename7 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut7.name.ToString(), QuantityOut7.ToString(), SoldAmount7.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename7);
			  
		string filename8 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut8.name.ToString(), QuantityOut8.ToString(), SoldAmount8.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename8);
			  
		string filename9 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut9.name.ToString(), QuantityOut9.ToString(), SoldAmount9.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename9);
		}
		
		
		
		}

}
}
