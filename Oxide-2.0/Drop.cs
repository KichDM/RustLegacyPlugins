using System.Collections.Generic;
using System;
using UnityEngine;
using RustExtended;
#pragma warning disable 0618

namespace Oxide.Plugins
{
	[Info("Drop", "Buratchuk(143)", "1.0.0")]
	[Description("Возможность сбросить свой лут в сумке на землю")]
    class Drop : RustLegacyPlugin
	{
        private Dictionary<string, string> GameObjectToItemName = new Dictionary<string, string>();
		string chatPrefix = "LOOT DROP";
		
		void OnServerInitialized()
        {
            GameObjectToItemName.Add("WoodBoxLarge(Clone)", "Large Wood Storage");
            GameObjectToItemName.Add("WoodBox(Clone)", "Wood Storage Box");
            GameObjectToItemName.Add("SmallStash(Clone)", "Small Stash");
            GameObjectToItemName.Add("Campfire(Clone)", "Campfire");
            GameObjectToItemName.Add("Furnace(Clone)", "Furnace");
            GameObjectToItemName.Add("Workbench(Clone)", "Workbench");
            GameObjectToItemName.Add("RepairBench(Clone)", "Repair Bench");
        }
		
		[ChatCommand("drop")]
		void dropCmd(NetUser netuser, string cmd, string[] args)
		{
            PlayerClient Target = Helper.GetPlayerClient(netuser.userID);
            Inventory invTarget = Target.controllable.GetComponent<Inventory>();
			invTarget.DeactivateItem(); Inventory InvDropped; 
			DropHelper.DropInventoryContents(invTarget, out InvDropped);
			if(netuser != null)
			{
				InvDropped.GetComponent<LootableObject>().lifeTime = 900;
				rust.SendChatMessage(netuser, chatPrefix, "Вы успешно сбросили свой лут! Не забудьте место. У вас 15 минут!");
				Puts("Игрок "+netuser.displayName+" сбросил свой лут в точке "+Target.lastKnownPosition);
			}
			Target.controllable.GetComponent<AvatarSaveRestore>().ClearAvatar();
		}		
		
		[ChatCommand("get")]
		void getCmd(NetUser Sender, string cmd, string[] args)
		{
            GameObject objectGO = Helper.GetLookObject(Helper.GetLookRay(Sender), 10f);
            if((objectGO == null) || (!GameObjectToItemName.ContainsKey(objectGO.name)))
			{
				rust.Notice(Sender, "Это нельзя стащить!", "✘");
				return;
			}
            DeployableObject deployable = objectGO.GetComponent<DeployableObject>();
			LootableObject lootobject = deployable.GetComponent<LootableObject>();
			var boxinv = lootobject._inventory;
			if(boxinv.occupiedSlotCount > 0)
			{
				rust.Notice(Sender, "Объект должен быть пуст!", "✘");
				return;
			}
			
			Inventory inventory = Sender.playerClient.controllable.GetComponent<Inventory>();
			int slot = GetFreeSlot(inventory);
			if (slot == -1)
			{
				rust.InventoryNotice(Sender, "Нет места!");
				return;
			}
			NetCull.Destroy(deployable.gameObject);
			ItemDataBlock item = DatablockDictionary.GetByName(GameObjectToItemName[objectGO.name]);
			Helper.GiveItem(Sender.playerClient, item, 1);
			rust.Notice(Sender, "Вы стащили "+GameObjectToItemName[objectGO.name], "K");
		}
		
		int GetFreeSlot(Inventory inv)
        {
            for(int i = 0; i < inv.slotCount-4; i++)
            {
                if(inv.IsSlotVacant(i))
                {
                    return i;
                }
            }
            return -1;
        }
	}
}