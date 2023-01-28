// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
/*
Plugin DiGGeT83 UpGrade 06.06.2020
*/
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0618 // отключение предупреждений об устаревших методов

namespace Oxide.Plugins
{
    [Info("TPVPevent", "RIDDLE", "1.0.0")]
    class TPVPevent : RustLegacyPlugin
    {
        RustServerManagement mng;
        List<Vector3> listStartPosition = new List<Vector3>() // список точек
        {
            new Vector3(873, 393, -1459)
        };

        void OnServerInitialized() => mng = RustServerManagement.Get();

        [ChatCommand("event")] // команда для тп
        void cmd_tpevent(NetUser player, string command, string[] args)
        {
            TpRandom(player);
            GiveAmmo(player);
        }

        void GiveAmmo(NetUser player)
        {
            Inventory inv = player.playerClient.rootControllable.idMain.GetComponent<Inventory>();
            inv.Clear();
            inv.AddItemSomehow(DatablockDictionary.GetByName("Rockk"), Inventory.Slot.Kind.Belt, 30, 1);
            inv.AddItemSomehow(DatablockDictionary.GetByName("Torchh"), Inventory.Slot.Kind.Belt, 31, 250);
            inv.AddItemSomehow(DatablockDictionary.GetByName("Bandagee"), Inventory.Slot.Kind.Belt, 32, 3);
            IInventoryItem i; if (inv.GetItem(30, out i)) { var m = i as IHeldItem; m.SetUses(50); }
        }

        void TpRandom(NetUser player)
        {
            int num = UnityEngine.Random.Range(0, listStartPosition.Count);
            mng.TeleportPlayerToWorld(player.playerClient.netPlayer, listStartPosition[num]);
			
			timer.Once(1, ()=> // Время через которое будет новый телепорт
			{ 
				mng.TeleportPlayerToWorld(player.playerClient.netPlayer, listStartPosition[num]);
			}  );
			
            Controllable pl = player.playerClient.controllable;
            Character plChar = pl.GetComponent<Character>();
            plChar.takeDamage.GetComponent<HumanBodyTakeDamage>().SetBleedingLevel(0f);
            plChar.takeDamage.health = 100;
            TakeDamage.HurtSelf(player.playerClient.controllable.character, 0.01f);
        }

    }
}