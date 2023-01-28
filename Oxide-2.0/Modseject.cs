using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Libraries;
using RustExtended;
using Rust;

namespace Oxide.Plugins
{
    [Info("Modseject", "Xapy", 1.0)]
    class Modseject : RustLegacyPlugin
    {
		public string chatName = "[Сервер]";
		IInventoryItem item;
		[ChatCommand("mod")]		
			void Modeject(NetUser netuser, string command, string[] args)
			{
				Inventory inv = netuser.playerClient.controllable.GetComponent<Inventory>();
				Dictionary<string, string> fixNameMod = new Dictionary<string, string>();
				fixNameMod.Add("Laser", "Laser Sight");
				fixNameMod.Add("Lamp", "Flashlight Mod");
				fixNameMod.Add("Sight", "Holo sight");
				fixNameMod.Add("Audio", "Silencer");
				fixNameMod.Add("Other", "");
				if (inv.activeItem==null){rust.SendChatMessage(netuser, chatName, string.Format("Вы должны взять в руки оружие с которого нужно снять моды")); return;}
				if (inv.GetItem(inv.activeItem.slot, out item))
                    {
                        var mod = item as IHeldItem;
                        int slot = inv.activeItem.slot;
                        string name = item.datablock.name.ToString();
                        int qty = Convert.ToInt32(item.uses);
                        float condition = Convert.ToSingle(item.condition);
                        string modslots = "";
                        string mods = "";
                        if (mod != null)
                        {
                            modslots = mod.totalModSlots.ToString();							
                            mods = mod.modFlags.ToString();
							string[] nameMod = mods.Split(',');
							foreach (var d in nameMod)
							{
								
								
								ItemDataBlock byName = DatablockDictionary.GetByName(fixNameMod[d.Trim()]);
								if (byName is ItemDataBlock)
                                    {
										inv.AddItemAmount(byName as ItemModDataBlock, 1);
										//SendReply (netuser, ""+byName);
                                    }
							}								
                        }
						inv.RemoveItem(slot);
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
						rust.SendChatMessage(netuser, chatName, string.Format("Вы сняли все моды с  \"{0}\"", name));
                    }
			}
			void AddItemToSlot(Inventory inv, string name, int slot, int amount)
			{
				if (amount == 1) amount--; 
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