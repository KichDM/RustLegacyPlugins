using System;
using RustExtended;
using UnityEngine;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("kazino", "143 RIP", "1.0.0")]
    class PaperRolls : RustLegacyPlugin
    {
        enum PrizeType 
        { 
            Item = 0, 
            Rank = 1 
        }
        class PrizeData 
        {
            public PrizeType Type;
            public string Name;
            public int Count;
            public int Rank;
        }
        List<PrizeData> prizeList = new List<PrizeData>()
        {
            new PrizeData() { Type = PrizeType.Item, Name = "Revolver", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Pipe Shotgun", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Sulfur", Count = 50 },
		    new PrizeData() { Type = PrizeType.Item, Name = "Leather", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Metal Fragments", Count = 12 },
			new PrizeData() { Type = PrizeType.Item, Name = "Animal Fat", Count = 12 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth", Count = 17 },
			new PrizeData() { Type = PrizeType.Item, Name = "Low Grade Fuel", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Wood Planks", Count = 25 },
			new PrizeData() { Type = PrizeType.Item, Name = "Stones", Count = 125 },
		    new PrizeData() { Type = PrizeType.Item, Name = "9mm Pistol", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Metal Fragments", Count = 75 },
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 6", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Sulfur", Count = 100 },
			new PrizeData() { Type = PrizeType.Item, Name = "Charcoal", Count = 35 },
		    new PrizeData() { Type = PrizeType.Item, Name = "Leather", Count = 125 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Low Quality Metal", Count = 12 },
			new PrizeData() { Type = PrizeType.Item, Name = "Hunting Bow", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Charcoal", Count = 75 },
			new PrizeData() { Type = PrizeType.Item, Name = "Arrow", Count = 20 },
			new PrizeData() { Type = PrizeType.Item, Name = "Animal Fat", Count = 75 },
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 3", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Wood Planks", Count = 75 },
			new PrizeData() { Type = PrizeType.Item, Name = "Gunpowder", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth Pants", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth Bots", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Low Grade Fuel", Count = 25 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth Vest", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Metal Fragments", Count = 150 },
			new PrizeData() { Type = PrizeType.Item, Name = "Metal Fragments", Count = 150 },
			new PrizeData() { Type = PrizeType.Item, Name = "556 Ammo", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth Boots", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Animal Fat", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Hunting Bow", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Low Quality Metal", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Arrow", Count = 20 },
			new PrizeData() { Type = PrizeType.Item, Name = "Paper", Count = 2 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth", Count = 35 },
			new PrizeData() { Type = PrizeType.Item, Name = "Can of Beans", Count = 5 },
		    new PrizeData() { Type = PrizeType.Item, Name = "Leather", Count = 75 },
		    new PrizeData() { Type = PrizeType.Item, Name = "9mm Pistol", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 2", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Bolt Action Rifle", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Can of Tuna", Count = 5 },
			new PrizeData() { Type = PrizeType.Item, Name = "Gunpowder", Count = 25 },
			new PrizeData() { Type = PrizeType.Item, Name = "Charcoal", Count = 125 },
			new PrizeData() { Type = PrizeType.Item, Name = "556 Ammo", Count = 75 },
			new PrizeData() { Type = PrizeType.Item, Name = "Metal Fragments", Count = 250 },
			new PrizeData() { Type = PrizeType.Item, Name = "Chocolate Bar", Count = 5 },
			new PrizeData() { Type = PrizeType.Item, Name = "Hunting Bow", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cloth", Count = 125 },
			new PrizeData() { Type = PrizeType.Item, Name = "Arrow", Count = 20 },
			new PrizeData() { Type = PrizeType.Item, Name = "Low Grade Fuel", Count = 25 },		
			new PrizeData() { Type = PrizeType.Item, Name = "MP5A4 Blueprint", Count = 4 },
			new PrizeData() { Type = PrizeType.Item, Name = "P250", Count = 1 },
            new PrizeData() { Type = PrizeType.Item, Name = "M4", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Animal Fat", Count = 150 },
			new PrizeData() { Type = PrizeType.Item, Name = "Cooked Chicken Breast", Count = 10 },
			new PrizeData() { Type = PrizeType.Item, Name = "Stones", Count = 75 },
			new PrizeData() { Type = PrizeType.Item, Name = "Granola Bar", Count = 5 },
			new PrizeData() { Type = PrizeType.Item, Name = "Research Kit 1", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 4", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Leather", Count = 35 },
			new PrizeData() { Type = PrizeType.Item, Name = "Raw Chicken Breast", Count = 12 },
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 7", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Small Rations", Count = 20 },
			new PrizeData() { Type = PrizeType.Item, Name = "Small Water Bottle", Count = 3 },
			new PrizeData() { Type = PrizeType.Item, Name = "556 Ammo", Count = 32 },
		    new PrizeData() { Type = PrizeType.Item, Name = "9mm Pistol", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Stones", Count = 250 },
			new PrizeData() { Type = PrizeType.Item, Name = "Bolt Action Rifle", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Wood Planks", Count = 50 },
            new PrizeData() { Type = PrizeType.Item, Name = "Gunpowder", Count = 75 },
            new PrizeData() { Type = PrizeType.Item, Name = "9mm Ammo", Count = 50 },
            new PrizeData() { Type = PrizeType.Item, Name = "Paper", Count = 2 }, 
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 5", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "P250", Count = 1 },
            new PrizeData() { Type = PrizeType.Item, Name = "M4", Count = 1 },
            new PrizeData() { Type = PrizeType.Item, Name = "Sulfur Ore", Count = 100 },
			new PrizeData() { Type = PrizeType.Item, Name = "Large Medkit", Count = 5 },
            new PrizeData() { Type = PrizeType.Item, Name = "Metal Ore", Count = 100 },	
            new PrizeData() { Type = PrizeType.Item, Name = "Paper", Count = 4 },
			new PrizeData() { Type = PrizeType.Item, Name = "Weapon Part 1", Count = 1 },
			new PrizeData() { Type = PrizeType.Item, Name = "Low Quality Metal", Count = 50 },
			new PrizeData() { Type = PrizeType.Item, Name = "Animal Fat", Count = 125 },
			
			
			
						         
        };
        string chatname = "Rust Dark";
        
        private PrizeData GetRandomPrize()
        {
            int random = UnityEngine.Random.Range(0, prizeList.Count);
            if (prizeList[random] != null)
                return prizeList[random];
            return null;
        }
        [ChatCommand("roll")]
        void CMD_Roll(NetUser netuser, string command, string[] args)
        {
            try
            {
                Inventory inv = netuser.playerClient.rootControllable.GetComponent<Inventory>();
                UserData me = Users.GetBySteamID(netuser.userID);
                int paperCount = Helper.InventoryItemCount(inv, DatablockDictionary.GetByName("Paper"));
                if (paperCount == 0)
                {
                    rust.SendChatMessage(netuser, chatname, "Для выполнене действие нужна бумага !(Нужно 1)");
                    return;
                }
                Helper.InventoryItemRemove(inv, DatablockDictionary.GetByName("Paper"), 1);
                PrizeData prize = GetRandomPrize();
                if (prize.Type == PrizeType.Rank)
                {
                    string rank = RustExtended.Core.Ranks[prize.Rank];
                    rust.SendChatMessage(netuser, chatname, $"забрал бумагу, и дал {rank}!");
                    if (me.Rank >= prize.Rank)
                    {
                        rust.SendChatMessage(netuser, chatname, "К сожалению, у тебя уже есть такая же привелегия!");
                        return;
                    }
                    me.Rank = prize.Rank;
                    return;
                }
                else
                {
                    Helper.GiveItem(netuser.playerClient, DatablockDictionary.GetByName(prize.Name), prize.Count);
                    rust.SendChatMessage(netuser, chatname, $"Вы обменяли бумаги и получили {prize.Name} в количестве {prize.Count} шт");
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"{ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
