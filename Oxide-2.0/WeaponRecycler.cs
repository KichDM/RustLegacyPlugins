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
    [Info("Weapon Recycler", "Faized", "2.0.1", ResourceId = 941)]
    class WeaponRecycler : RustLegacyPlugin
    {
        IInventoryItem item;
        void Init()
        {
            Puts("Plugin Loaded!");
        }

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
            var weapondata = GetCurrentEquippedItem(netuser.playerClient.controllable.GetComponent<Character>());
            var inventory = GetCurrentEquippedInventory(netuser.playerClient.controllable.GetComponent<Character>());
            UserData userData = Users.GetBySteamID(netuser.playerClient.userID);
            if(weapondata == null) 
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Возьмите оружие в руки");
                return;
            }
            else if(weapondata.ToString() == "P250 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot); 
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 12);
                return;
            }
            else if(weapondata.ToString() == "P250 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 6);
                return;
            }
            else if(weapondata.ToString() == "M4 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 30); 
                return;
            }
            else if(weapondata.ToString() == "M4 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 15); 
                return;
            }
            else if(weapondata.ToString() == "Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 12); 
                return;
            }
            else if(weapondata.ToString() == "Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 6); 
                return;
            }
            else if(weapondata.ToString() == "MP5A4 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 25, 300);
                return;
            }
            else if(weapondata.ToString() == "MP5A4 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 25, 150);
                return;
            }
            else if(weapondata.ToString() == "9mm Pistol (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 10);
                return;
            }
            else if(weapondata.ToString() == "9mm Pistol (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 5);
                return;
            }
            else if(weapondata.ToString() == "Bolt Action Rifle (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 30);
                inventory.AddItem(GetItemDataBlock("Leather"), 26, 20);
                inventory.AddItem(GetItemDataBlock("Wood"), 27, 50);
                return;
            }
            else if(weapondata.ToString() == "Bolt Action Rifle (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 15);
                inventory.AddItem(GetItemDataBlock("Leather"), 26, 10);
                inventory.AddItem(GetItemDataBlock("Wood"), 27, 25);
                return;
            }
            else if(weapondata.ToString() == "HandCannon (StrikeGunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 10);
                return;
            }
            else if(weapondata.ToString() == "HandCannon (StrikeGunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 5);
                return;
            }
            else if(weapondata.ToString() == "Pipe Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Wood"), 25, 50);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 26, 40);
                return;
            }
            else if(weapondata.ToString() == "Pipe Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Wood"), 25, 25);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 26, 20);
                return;
            }
            else if(weapondata.ToString() == "Revolver (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Cloth"), 25, 10);
                inventory.AddItem(GetItemDataBlock("Wood"), 26, 60);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 28, 80);
                return;
            }
            else if(weapondata.ToString() == "Revolver (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Cloth"), 25, 5);
                inventory.AddItem(GetItemDataBlock("Wood"), 26, 30);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 28, 40);
                return;
            }
            else 
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Это нельзя разобрать");
                return;
            }
        }
    }
}   