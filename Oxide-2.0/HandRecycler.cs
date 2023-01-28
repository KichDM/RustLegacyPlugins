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
    [Info("HandRecycler", "Buratchuk(143)", "2.1.0")]
	[Description("Переработает все, что можно взять в руки")]
    class HandRecycler : RustLegacyPlugin
    {
        IInventoryItem item;
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

        [ChatCommand("recycle")]
        void Test(NetUser netuser, string command, string[] args)
        {
            var weapondata = GetCurrentEquippedItem(netuser.playerClient.controllable.GetComponent<Character>());
            var inventory = GetCurrentEquippedInventory(netuser.playerClient.controllable.GetComponent<Character>());
            UserData userData = Users.GetBySteamID(netuser.playerClient.userID);
            if(weapondata == null) 
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Возьмите оружие в руки");
                return;
            }
            else if(weapondata.ToString() == "P250 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Rust Dark | Разбор]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot); 
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 12);
                return;
            }
            else if(weapondata.ToString() == "P250 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 6);
                return;
            }
            else if(weapondata.ToString() == "M4 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 30); 
                return;
            }
            else if(weapondata.ToString() == "M4 (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 15); 
                return;
            }
            else if(weapondata.ToString() == "Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 12); 
                return;
            }
            else if(weapondata.ToString() == "Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 6); 
                return;
            }
            else if(weapondata.ToString() == "MP5A4 (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
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
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 15);
                inventory.AddItem(GetItemDataBlock("Leather"), 26, 10);
                inventory.AddItem(GetItemDataBlock("Wood"), 27, 25);
                return;
            }
            else if(weapondata.ToString() == "HandCannon (StrikeGunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 10);
                return;
            }
            else if(weapondata.ToString() == "HandCannon (StrikeGunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Low Quality Metal"), 25, 5);
                return;
            }
            else if(weapondata.ToString() == "Pipe Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Wood"), 25, 50);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 26, 40);
                return;
            }
            else if(weapondata.ToString() == "Pipe Shotgun (ShotgunDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Wood"), 25, 25);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 26, 20);
                return;
            }
            else if(weapondata.ToString() == "Revolver (BulletWeaponDataBlock)" && inventory.activeItem.condition > 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Cloth"), 25, 10);
                inventory.AddItem(GetItemDataBlock("Wood"), 26, 60);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 28, 80);
                return;
            }
            else if(weapondata.ToString() == "Revolver (BulletWeaponDataBlock)" && inventory.activeItem.condition < 0.99f)
            {
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Оружие было разобрано");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItem(GetItemDataBlock("Cloth"), 25, 5);
                inventory.AddItem(GetItemDataBlock("Wood"), 26, 30);
                inventory.AddItem(GetItemDataBlock("Metal Fragments"), 28, 40);
                return;
            }
            else if(weapondata.ToString() == "Explosive Charge (DeployableItemDataBlock)")
            {
				int qnty = inventory.activeItem.uses;
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Взрывчатка была разобрана");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItemAmount(GetItemDataBlock("Explosives"), qnty * 15);
				rust.InventoryNotice(netuser,"Explosives"+qnty * 15);
                inventory.AddItemAmount(GetItemDataBlock("Flare"), qnty * 1);
				rust.InventoryNotice(netuser,"Flare"+qnty * 1);
                inventory.AddItemAmount(GetItemDataBlock("Leather"), qnty * 5);
				rust.InventoryNotice(netuser,"Leather "+qnty * 5);
                return;
            }
            else if(weapondata.ToString() == "F1 Grenade (HandGrenadeDataBlock)")
            {
				int qnty = inventory.activeItem.uses;
                rust.SendChatMessage(netuser, "[Weapon Recycler]", "[color#6FFC2E]Взрывчатка была разобрана");
                inventory.RemoveItem(inventory.activeItem.slot);
                inventory.AddItemAmount(GetItemDataBlock("Gunpowder"), qnty * 80);
                inventory.AddItemAmount(GetItemDataBlock("Metal Fragments"), qnty * 40);
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
/*
Переработаються
Stone Hatchet (MeleeWeaponDataBlock)
Hatchet (MeleeWeaponDataBlock)
Pick Axe (MeleeWeaponDataBlock)
Torch (BasicTorchItemDataBlock)
Flare (TorchItemDataBlock)
Furnace (DeployableItemDataBlock)
Large Spike Wall (DeployableItemDataBlock)
Large Wood Storage (DeployableItemDataBlock)
Metal Door (DeployableItemDataBlock)
Metal Window Bars (DeployableItemDataBlock)
Repair Bench (DeployableItemDataBlock)
Sleeping Bag (DeployableItemDataBlock)
Small Stash (DeployableItemDataBlock)
Spike Wall (DeployableItemDataBlock)
Wood Barricade (DeployableItemDataBlock)
Wood Gate (DeployableItemDataBlock)
Wood Gateway (DeployableItemDataBlock)
Wood Shelter (DeployableItemDataBlock)
Wood Storage Box (DeployableItemDataBlock)
Wooden Door (DeployableItemDataBlock)
Workbench (DeployableItemDataBlock)
Wood Ceiling (StructureComponentDataBlock)
Wood Doorway (StructureComponentDataBlock)
Wood Foundation (StructureComponentDataBlock)
Wood Pillar (StructureComponentDataBlock)
Wood Ramp (StructureComponentDataBlock)
Wood Stairs (StructureComponentDataBlock)
Wood Wall (StructureComponentDataBlock)
Wood Window (StructureComponentDataBlock)
Camp Fire (DeployableInventoryDataBlock)
Metal Ceiling (StructureComponentDataBlock)
Metal Doorway (StructureComponentDataBlock)
Metal Foundation (StructureComponentDataBlock)
Metal Pillar (StructureComponentDataBlock)
Metal Ramp (StructureComponentDataBlock)
Metal Stairs (StructureComponentDataBlock)
Metal Wall (StructureComponentDataBlock)
Metal Window (StructureComponentDataBlock)
Bed (DeployableItemDataBlock)
*/