using System;
using System.Collections.Generic;
using RustExtended;
using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("RustGather", "Sh1ne and Misvor", "1.0.7")]
    [Description("Different GatherRate for different ranks")]
    class RustGather : RustLegacyPlugin
    {
        ResourceData resourceData;
        bool broadcastedNight = false;

        class ResourceData
        {
            public List<PluginInfo> PluginInfo = new List<PluginInfo> { };
        }

        class PluginInfo
        {
            public int UserRank;
            public float GatherRate;
            public float NightGatherRate;
        }

        void Loaded()
        {
            resourceData = Interface.GetMod().DataFileSystem.ReadObject<ResourceData>("GatherRankRate");
        }

        void OnFrame()
        {
			if (!Bootstrap.Initialized)
                return;
            if (EnvironmentControlCenter.Singleton.IsNight() && !broadcastedNight)
            {
                Broadcast.MessageAll("[COLOR #FF0000]Наступила ночь, рейты добычи увеличены в 10 раз!", "Рейты");
                broadcastedNight = true;
            }

            if (!EnvironmentControlCenter.Singleton.IsNight() && broadcastedNight)
            {
                Broadcast.MessageAll($"[COLOR #00FF00]Наступил день, рейты добычи восстановлены!", "Рейты");
                broadcastedNight = false;
            }
        }

        void OnGather(Inventory inv, ResourceTarget obj, ResourceGivePair rp, int num2)
        {
            NetUser netUser = NetUser.Find(inv.networkView.owner);
            UserData userData = Users.GetBySteamID(netUser.playerClient.userID);
            foreach (PluginInfo info in resourceData.PluginInfo)
            {
                if (info != null)
                {
                    if (info.UserRank == userData.Rank)
                    {
						if (info.GatherRate > 0 && (info.GatherRate > 1 || (info.NightGatherRate > 1 && EnvironmentControlCenter.Singleton.IsNight())))                        
						{
                            int count1 = (int)(num2 * (info.GatherRate - 1));
                            int count2 = 0;

                            if (info.NightGatherRate > 0 && EnvironmentControlCenter.Singleton.IsNight()) 
                                count2 = (int)(num2 * (info.NightGatherRate - 1));

                            int count = count1 + count2;

                            inv.AddItemAmount(rp.ResourceItemDataBlock, count);
                            rust.InventoryNotice(netUser, $"Бонус {count} x {rp.ResourceItemDataBlock.name}");
                        }
                        break;
                    }
                }
            }       
        }
    }
}
