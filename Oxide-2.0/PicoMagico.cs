// Reference: RustExtended
// Reference: USAC
using System;
using Oxide.Core.Plugins;
using System.Collections.Generic;
using UnityEngine;
using RustExtended;
using Oxide.Plugins;


namespace Oxide.Plugins
{
    [Info("MagicPickaxe", "Sh1ne", "1.0.0")]
    class PicoMagico : RustLegacyPlugin
    {
        // Номера рангов, которым доступна способность Магическая Кирка (ресурсы переплавляются сами)
        int[] RanksId = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        // Сколько выдавать метал фрагментов вместо руды
        int MetalFragmentsCount = 10;

        // Сколько выдавать сульфура вместо руды
        int SulfurCount = 10;

        ItemDataBlock MetalFragmentsDatablock, SulfurDatablock;

        void OnServerInitialized()
        {
            MetalFragmentsDatablock = DatablockDictionary.GetByName("Metal Fragments");
            SulfurDatablock = DatablockDictionary.GetByName("Sulfur");
        }

        int OnGather(Inventory receiver, ResourceTarget obj, ResourceGivePair item, int collected)
        {
            if (item == null || receiver == null || obj == null || collected < 1 || receiver.networkView.owner == null)
                return collected;

            if (obj.type != ResourceTarget.ResourceTargetType.Rock1
                && obj.type != ResourceTarget.ResourceTargetType.Rock2
                && obj.type != ResourceTarget.ResourceTargetType.Rock3)
                return collected;

            NetUser netUser = NetUser.Find(receiver.networkView.owner);

            if (netUser == null || netUser.playerClient == null)
                return collected;

            UserData userData = Users.GetBySteamID(netUser.playerClient.userID);

            if (Array.IndexOf(RanksId, userData.Rank) == -1)
                return collected;

            if (receiver.activeItem == null || receiver.activeItem.datablock.name != "Hatchet")
                if (receiver.activeItem == null || receiver.activeItem.datablock.name != "Uber Hatchet")
                    if (receiver.activeItem == null || receiver.activeItem.datablock.name != "Pick Axe")
                        return collected;

            int gatherCount = 2;
            string gatherItemName;
            ItemDataBlock gatherItemDatablock;
            if (item.ResourceItemName == "Metal Ore")
            {
                gatherCount = MetalFragmentsCount;
                gatherItemName = "Metal Fragments";
                gatherItemDatablock = MetalFragmentsDatablock;
            }
            else if (item.ResourceItemName == "Sulfur Ore")
            {
                gatherCount = SulfurCount;
                gatherItemName = "Sulfur";
                gatherItemDatablock = SulfurDatablock;
            }
            else
            {
                return collected;
            }

            collected *= gatherCount;
            int received = receiver.AddItemAmount(gatherItemDatablock, collected);
            if (received < collected)
            {
                // Get gathering bonuses of clan system //
                int bonus = 0; if (userData == null || userData.Clan == null) { /* None */ }
                else bonus = (int)(collected * userData.Clan.Level.BonusGatheringRock / 100);

                // Default gathering //
                int amount = collected - received; item.Subtract(amount);
                obj.gatherProgress -= amount;

                if (bonus > 0) bonus -= receiver.AddItemAmount(gatherItemDatablock, bonus * gatherCount);

                Rust.Notice.Inventory(receiver.networkView.owner, (amount + bonus).ToString() + " x " + gatherItemName);
                obj.SendMessage("ResourcesGathered", SendMessageOptions.DontRequireReceiver);

                // Clan experience from gather resources //
                if (userData != null && userData.Clan != null)
                {
                    float GainExperience = 0;
                    if (item.ResourceItemName.Equals("Metal Fragments", StringComparison.OrdinalIgnoreCase)) GainExperience = amount * 2;
                    else if (item.ResourceItemName.Equals("Sulfur", StringComparison.OrdinalIgnoreCase)) GainExperience = amount * 2;
                    if (GainExperience < 0) GainExperience = 0;
                    else if (GainExperience >= 3.0f)
                    {
                        GainExperience = Math.Abs(GainExperience * Clans.ExperienceMultiplier); userData.Clan.Experience += (ulong)GainExperience;
                        if (userData.Clan.Members[userData].Has(ClanMemberFlags.expdetails))
                        {
                            Broadcast.Message(receiver.networkView.owner, RustExtended.Config.GetMessage("Clan.Experience.Gather").Replace("%EXPERIENCE%", GainExperience.ToString("N0")).Replace("%RESOURCE_NAME%", item.ResourceItemName));
                        }
                    }
                }
            }
            else
            {
                obj.gatherProgress = 0;
                Rust.Notice.Popup(receiver.networkView.owner, "", "Inventory full. You can't gather.", 4f);
            }

            return 0;
        }
    }
}