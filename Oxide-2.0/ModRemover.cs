using System;
using System.Collections.Generic;
using RustExtended;

// ReSharper disable InlineOutVariableDeclaration

namespace Oxide.Plugins
{
    [Info("ModRemover", "vk.com/redux_mod", 1.0)]
    class ModRemover : RustLegacyPlugin
    {
        private readonly string _prefix = "Разбор";
        private const ulong Price = 1000;

        private readonly Dictionary<string, string> _fixNameMod = new Dictionary<string, string>
        {
            {"Laser", "Laser Sight"},
            {"Lamp", "Flashlight Mod"},
            {"Sight", "Holo sight"},
            {"Audio", "Silencer"},
            {"Other", ""}
        };

        [ChatCommand("mod")]
        void mod_cmd(NetUser netuser, string command, string[] args)
        {
            var inv = netuser.playerClient.controllable.GetComponent<Inventory>();
            if(inv == null) return;
            var economy = Economy.Get(netuser.userID);
            if(economy == null) return;
            if(economy.Balance < Price) { Broadcast.Message(netuser, $"[COLOR#3C99E7]Вам не хватает {Price - economy.Balance}{Economy.CurrencySign} для заказа услуги.", _prefix); return; }
            if (inv.activeItem == null) { Broadcast.Message(netuser, "[COLOR#3C99E7]Вы должны взять в руки оружие с которого нужно снять моды", _prefix); return; }
            if (!(inv.activeItem.datablock as BulletWeaponDataBlock)) { Broadcast.Message(netuser, "[COLOR#3C99E7]Вы должны взять в руки оружие с которого нужно снять моды", _prefix); return;}
            IInventoryItem item;
            if (inv.GetItem(inv.activeItem.slot, out item))
            {
                var mod = item as IHeldItem;
                var slot = inv.activeItem.slot;
                var name = item.datablock.name;
                var qty = Convert.ToInt32(item.uses);
                if (qty == 0)
                {
                    Broadcast.Message(netuser, "[COLOR#E73C5B]Вам нужно зарядить [COLOR#5AD91F]патроны в оружие!");
                    return;
                }
                var condition = Convert.ToSingle(item.condition);
                var modslots = "";
                if (mod != null)
                {
                    modslots = mod.totalModSlots.ToString();
                    var mods = mod.modFlags.ToString();
                    var nameMod = mods.Split(',');
                    foreach (var d in nameMod)
                    {
                        var byName = DatablockDictionary.GetByName(_fixNameMod[d.Trim()]);
                        if (byName != null)
                        {
                            inv.AddItemAmount(byName as ItemModDataBlock, 1);
                        }
                    }
                }
                inv.RemoveItem(slot);
                AddItemToSlot(inv, name, slot, qty);
                IInventoryItem itemmod;
                if (inv.GetItem(slot, out itemmod))
                {
                    itemmod.SetCondition(condition);
                    if (Convert.ToInt32(modslots) != 0)
                    {
                        var m = itemmod as IHeldItem;
                        m?.SetTotalModSlotCount(Convert.ToInt32(modslots));
                    }
                }
                Broadcast.Message(netuser, $"[COLOR#9C3CE7]Вы сняли все моды с  [COLOR#1FD9B1]\"{name}\"");
                economy.Balance -= Price;
            }
        }

        private void AddItemToSlot(Inventory inv, string name, int slot, int amount)
        {
            var byName = DatablockDictionary.GetByName(name);
            if (byName == null) return;
            var belt = Inventory.Slot.Kind.Default;
            if (slot > 0x1d && slot < 0x24)
            {
                belt = Inventory.Slot.Kind.Belt;
            }
            else if (slot >= 0x24 && slot < 40)
            {
                belt = Inventory.Slot.Kind.Armor;
            }
            inv.AddItemSomehow(byName, belt, slot, amount);
        }
    }
}