// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
// Reference: Google.ProtocolBuffers
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Libraries.Covalence;
using RustProto;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("Weapon Razbor", "Faized", "2.0.1", ResourceId = 941)]
    class Razbor : RustLegacyPlugin
    {
        IInventoryItem item;
        void Init()
        {
            Puts("Plugin Loaded!");
        }
private const ulong Price = 150;
        ItemDataBlock GetItemDataBlock(string itemname)
        {
            ItemDataBlock datablock = DatablockDictionary.GetByName(itemname);
            return datablock;
        }

        public static ItemDataBlock GetCurrentEquippedItem(Character controller)
        {
            Inventory component = controller.GetComponent<Inventory>();
            if ((object) component != (object) null && component.activeItem != null && (object) component.activeItem.datablock != (object) null)
            return (ItemDataBlock) component.activeItem.datablock;
            return (ItemDataBlock) null;
        }

        public static Inventory GetCurrentEquippedInventory(Character controller)
        {
            Inventory component = controller.GetComponent<Inventory>();
            if ((object) component != (object) null && component.activeItem != null && (object) component.activeItem.datablock != (object) null)
            return (Inventory) component;
            return (Inventory) null;
        }

        [ChatCommand("razbor")]
        void Test(NetUser netuser, string command, string[] args)
        {
						            var economy = Economy.Get(netuser.userID);
            if(economy == null) return;
            if(economy.Balance < Price) { Broadcast.Message(netuser, $"[COLOR#3C99E7]Вам не хватает [color green]{Price - economy.Balance}{Economy.CurrencySign} [COLOR#3C99E7]для заказа услуги."); return; }
            var weapondata = GetCurrentEquippedItem(netuser.playerClient.controllable.GetComponent<Character>());
            var inventory = GetCurrentEquippedInventory(netuser.playerClient.controllable.GetComponent<Character>());
            UserData userData = Users.GetBySteamID(netuser.playerClient.userID);

            if(weapondata == null) 
            {
                rust.SendChatMessage(netuser, "Разбор", "[color#FFFF00]Возьмите[color#FF0000] оружие[color#FFFF00] в руки");
                return;
            }
            else if(weapondata.ToString() == "P250 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#FF0000]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot); 
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 10);
                return;
            }
            else if(weapondata.ToString() == "P250 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 6);
                return;
            }
            else if(weapondata.ToString() == "M4 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 25); 
                return;
            }
            else if(weapondata.ToString() == "M4 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 15); 
                return;
            }
            else if(weapondata.ToString() == "Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 10); 
                return;
            }
            else if(weapondata.ToString() == "Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 6); 
                return;
            }
            else if(weapondata.ToString() == "MP5A4 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 25, 10);
                return;
            }
            else if(weapondata.ToString() == "MP5A4 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 25, 150);
                return;
            }
            else if(weapondata.ToString() == "9mm Pistol (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 8);
                return;
            }
            else if(weapondata.ToString() == "9mm Pistol (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 5);
                return;
            }
            else if(weapondata.ToString() == "Bolt Action Rifle (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 20);
                inventory.AddItem(GetItemDataBlock("Leather"), 26, 15);
                inventory.AddItem(GetItemDataBlock("Wood"), 27, 25);
                return;
            }
            else if(weapondata.ToString() == "Bolt Action Rifle (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 15);
                inventory.AddItem(GetItemDataBlock("Leather"), 26, 10);
                inventory.AddItem(GetItemDataBlock("Wood"), 27, 25);
                return;
            }
            else if(weapondata.ToString() == "Pipe Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Wood"), 25, 15);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 26, 20);
                return;
            }
            else if(weapondata.ToString() == "Pipe Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Wood"), 25, 25);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 26, 20);
                return;
            }
            else if(weapondata.ToString() == "Revolver (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Cloth"), 25, 5);
                inventory.AddItem(GetItemDataBlock("Wood"), 26, 45);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 28, 50);
                return;
            }
            else if(weapondata.ToString() == "Revolver (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
				economy.Balance -= Price;
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Оружие[color#FFFF00] было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Cloth"), 25, 5);
                inventory.AddItem(GetItemDataBlock("Wood"), 26, 30);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 28, 40);
                return;
            }
            else 
            {
                rust.SendChatMessage(netuser, "Разбор", "[color#C71585]Это нельзя разобрать");
                return;
            }
        }
    }
} 