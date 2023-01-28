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
    [Info("SupplyPatron", "Atamg1994", "0.1.9")]
    class SupplyPatron : RustLegacyPlugin 
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
  
	[ChatCommand("pp")]
			void cmdChatSs(NetUser netuser, string command, string[] args)
		{           
		    string tagChat = "Крафт Патрона"; 
			
			string nameInput = "Primed 556 Casing"; 
			int QuantityInput = 1;
			int setall = 0;
			
			string nameOut1 = "556 Ammo"; 
			int QuantityOut1 = 150;
			
			string nameOut2 = "Sulfur"; 
			int QuantityOut2 = 200;
			
			string nameOut3 = "Metal Fragments"; 
			int QuantityOut3 = 250;
			

			Inventory inventory = netuser.playerClient.controllable.GetComponent<Inventory>();
			ItemDataBlock ItemInput = DatablockDictionary.GetByName(nameInput);
			
			
			ItemDataBlock ItemOut1 = DatablockDictionary.GetByName(nameOut1);
			int SoldAmount1 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut1);
			
			
			ItemDataBlock ItemOut2 = DatablockDictionary.GetByName(nameOut2);
			int SoldAmount2 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut2);
			
			
			ItemDataBlock ItemOut3 = DatablockDictionary.GetByName(nameOut3);
			int SoldAmount3 = RustExtended.Helper.InventoryItemCount(inventory, ItemOut3);	
					
			
			if (QuantityOut1<=SoldAmount1)
			{setall++;}			
			if (QuantityOut2<=SoldAmount2)
			{setall++;}			
			if (QuantityOut3<=SoldAmount3)
			{setall++;}			

		if (setall>=3)
		{
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut1, QuantityOut1);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut2, QuantityOut2);
		RustExtended.Helper.InventoryItemRemove(inventory, ItemOut3, QuantityOut3);
		
		RustExtended.Helper.GiveItem(netuser.playerClient, ItemInput, QuantityInput);
					rust.Notice(netuser, "Вы получили Supply Signal" );
		}else{
		string filename1 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut1.name.ToString(), QuantityOut1.ToString(), SoldAmount1.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename1);
			  
		string filename2 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut2.name.ToString(), QuantityOut2.ToString(), SoldAmount2.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename2);
		
		string filename3 = string.Format("[color#FF0000]Нужно [color#00FFFF]{0} [color#00FF00]в количистве [color#9932CC]{1}  [color#00FF00]у вас есть [color#FFFF00]{2}", ItemOut3.name.ToString(), QuantityOut3.ToString(), SoldAmount3.ToString());
			  rust.SendChatMessage(netuser, tagChat, filename3);
			  
		}
		
		
		
		}

}
}
