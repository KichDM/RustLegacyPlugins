using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Libraries;
using RustExtended;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Blockpredmet", "Unkown", 1.0)]
    class Blockpredmet : RustLegacyPlugin
    {
        IInventoryItem item;
		private Core.Configuration.DynamicConfigFile DeniedInv;
		DateTime DeniedInvtims = new DateTime(2018, 06, 17, 11, 30, 00);	//1ГОД 2МЕСЯЦ 3ДЕНЬ 4ЧАСЫ 5МИНУТЫ 6СЕК
		DateTime outputDateTimeValue;
		bool hasAccess(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
			else if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "Admin"))
			{
				return true;
			}
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }
		void LoadData()
        {
            DeniedInv = Interface.GetMod().DataFileSystem.GetDatafile("Deniedinvconfig");
        }
        void SaveData()
        {
            Interface.GetMod().DataFileSystem.SaveDatafile("Deniedinvconfig");
        }		
		void OnGetClientMove(HumanController сontroller, Vector3 newPos)
		{
			DateTime CurTime = DateTime.Now;
			if (CurTime<=DeniedInvtims)
			{				
				System.TimeSpan fulltime = DeniedInvtims.Subtract(CurTime);
				var netuser = сontroller.netUser;
				var inv = netuser.playerClient.rootControllable.idMain.GetComponent<Inventory>();
				///////////////////Разрешенные предметы
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Torch") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Rock") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Pipe") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Hatchet") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Bow") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Axe") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Revolver") ?? false))					
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Wall") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Pillar") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Foundation") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Doorway") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Window") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Stairs") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Ramp") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Ceiling") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Box") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Spike") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Shelter") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Bed") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Metal Door") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Large Wood Storage") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Furnace") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Wood Gate") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Wood Bariccade") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Wooden Door") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Wood Gateway") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Repair Bench") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Workbench") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("HandCannon") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Camp Fire") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("9mm Pistol") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("Wood Barricade") ?? false))
				if (inv != null && (!inv.activeItem?.datablock?.name?.Contains("P250") ?? false))	
				////////////////////////////////////////////
				{
					if (!hasAccess(netuser, "Admin"))
				{
					var giveup = DatablockDictionary.GetByName(inv.activeItem.datablock.name);
					int giveslot = inv.activeItem.slot;				
					if (inv.GetItem(giveslot, out item))
						{
							var mod = item as IHeldItem;
							int slot = giveslot;
							string name = item.datablock.name.ToString();
							int qty = Convert.ToInt32(item.uses);
							float condition = Convert.ToSingle(item.condition);
							string modslots = "";
							string mods = "";
							if (mod != null)
							{
								modslots = mod.totalModSlots.ToString();
								mods = mod.modFlags.ToString();
							}
							inv.RemoveItem(giveslot);
							IInventoryItem itemmod;
							AddItemToSlot(inv, name, slot, qty);
							if (inv.GetItem(slot, out itemmod))
							{
								itemmod.SetCondition(condition);
								if (Convert.ToInt32(modslots) != 0)
								{
									var m = itemmod as IHeldItem;
									m.SetTotalModSlotCount(Convert.ToInt32(modslots));
								}
							}
								string giveupe=giveup.ToString();
								int dotIndex = giveupe.IndexOfAny(new char[]{ '('});
								if (dotIndex >= 0)
								{
									giveupe = giveupe.Substring(0, dotIndex);
									rust.SendChatMessage(netuser, "RustDiablo:CLASSIC", string.Format("Запрещенно использовать "   + giveupe +   "еще "    +Convert.ToInt32(fulltime.TotalMinutes)+   " минут"));
								}
						}
				}
				}
			}
		}
		void AddItemToSlot(Inventory inv, string name, int slot, int amount)
		{
			ItemDataBlock byName = DatablockDictionary.GetByName(name);
			if (byName != null)
			{
				Inventory.Slot.Kind belt = Inventory.Slot.Kind.Default;
				if ((slot > 0x1d) && (slot < 0x24))
				{
					belt = Inventory.Slot.Kind.Belt;
				}
				else if ((slot >= 0x24) && (slot < 40))
				{
					belt = Inventory.Slot.Kind.Armor;
				}
				inv.AddItemSomehow(byName, new Inventory.Slot.Kind?(belt), slot, amount);
			}
		}		
    }
}