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
    using Rust;
    using RustExtended;

    #pragma warning disable 0618 // отключение предупреждений об устаревших методах

    namespace Oxide.Plugins
    {
        [Info("Gereather", "Atamg1994", "1.0")]
        class Gereather : RustLegacyPlugin
        {
         public static string[] colinet;
         public static string[] result;
         public static string[] bonus = {
		 	//Ранк:Рейт//
               "3:2",
               "4:2",
               "5:2",
               "6:3",          
               "7:4",   
			   "8:4",   
			   "9:5",   
			   "10:4",   
               "14:",     			   
           };
            void OnGather(Inventory reciever,ResourceTarget resurce,ResourceGivePair res,int col){NetUser netUser = NetUser.Find(reciever.networkView.owner);int mul = 1;foreach (string s in bonus){string[] colinet = new string[] { ":" };result = s.Split(colinet, StringSplitOptions.RemoveEmptyEntries);if (Users.Database.ContainsKey(netUser.userID) && Users.Database[netUser.userID].Rank == Convert.ToInt32(result[0])){ mul =  Convert.ToInt32(result[1]);col = col * mul;int num3 = reciever.AddItemAmount(res.ResourceItemDataBlock, col);if (num3 < col){ Notice.Inventory(reciever.networkView.owner, (col).ToString() + " x " + res.ResourceItemName);}else{SendReply(netUser, "Инвентарь полный ");}}}}}          
    }
