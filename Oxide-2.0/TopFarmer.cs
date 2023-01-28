using Newtonsoft.Json;
using Oxide.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("TopFarmer", "vk.com/redux_mod", "1.0.0")]
    internal class TopFarmer : RustLegacyPlugin
    {
        public static List<TopPlayer> TopList = new List<TopPlayer>();

        void Loaded()
        {
            if (Interface.Oxide.DataFileSystem.ExistsDatafile("TopFarmer"))
            {
                TopList = Interface.Oxide.DataFileSystem.ReadObject<List<TopPlayer>>("TopFarmer");
            }
            else
            {
                Interface.Oxide.DataFileSystem.WriteObject("TopFarmer", TopList, true);
            }
        }

        void OnServerSave()
        {
            Interface.Oxide.DataFileSystem.WriteObject("TopFarmer", TopList, true);
        }

        [Serializable]
        public class TopPlayer
        {
            [JsonProperty("Ник игрока")]
            public string UserName;
            [JsonProperty("Добыто дерева")]
            public int WoodQuantity;
            [JsonProperty("Добыто металла")]
            public int MetallQuantity;
            [JsonProperty("Добыто сульфура")]
            public int SulfurQuantity;
        }

        [HookMethod("OnGather")]
        int GatherHook(Inventory receiver, ResourceTarget obj, ResourceGivePair item, int collected)
        {
            if (item == null || receiver == null) return collected;
            var netUser = NetUser.Find(receiver.networkView.owner);
            if (netUser == null || netUser.playerClient == null)
                return collected;
            var dataBlock = netUser.playerClient.controllable.GetComponent<Inventory>().activeItem.datablock;
            if (dataBlock == null || dataBlock.name == "Uber Hatchet") return collected;
            var profile = TopList.FirstOrDefault(select => select.UserName == netUser.displayName);
            if (profile == null)
            {
                profile = new TopPlayer
                {
                    UserName = netUser.displayName,
                    MetallQuantity = 0,
                    SulfurQuantity = 0,
                    WoodQuantity = 0
                };
                TopList.Add(profile);
            }
            switch (item.ResourceItemName)
            {
                case "Metal Ore":
                    profile.MetallQuantity += collected;
                    break;
                case "Sulfur Ore":
                    profile.SulfurQuantity += collected;
                    break;
                case "Wood":
                    profile.WoodQuantity += collected;
                    break;
                default:
                    break;
            }
            return collected;
        }

        [ChatCommand("topfarm")]
        void cmdChatTest(NetUser netuser, string command, string[] args)
        {
            if (TopList == null || TopList.Count == 0) return;
            var Order = TopList.OrderByDescending(pair => pair.SulfurQuantity).ToList();
            Broadcast.Message(netuser, "Топ по добыче:");
            for (var i = 0; i < 6; i++)
            {
                if (TopList.ElementAtOrDefault(i) == null) return;
                Broadcast.Message(netuser, $"[color#FFFF00]{Order[i].UserName}[/color] [color#7FFFD4] | [COLOR#FFFFFF]Сульфура [/color][color#FFFF00]{Order[i].SulfurQuantity}[/color][color#7FFFD4]  | [COLOR#FFFFFF]Металла [/color][color#FFFF00]{Order[i].MetallQuantity}[/color][color7FFFD4]  |[COLOR#FFFFFF] Дерева [/color][color#FFFF00]{Order[i].WoodQuantity}[/color]");
            }
        }
    }
}