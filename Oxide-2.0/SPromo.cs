using System;
using Oxide.Core.Plugins;
using System.Collections.Generic;
using UnityEngine;
using RustExtended;
using Oxide.Plugins;
using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("SPromo", "hostfun", "1.0.0")]
    class SPromo : RustLegacyPlugin
    {
        #region Классы
        class PromoInfo
        {
            public string Name;
            public int MaxUses;
            public Dictionary<string, int> Items;
        }

        class ActivationsInfo
        {
            public int AlreadyUses;
            public List<ulong> PlayersActivated;
        }

        class PluginData
        {
            public List<PromoInfo> PromoInfo = new List<PromoInfo>();

            // string: Название промокода
            public Dictionary<string, ActivationsInfo> ActivationsInfo = new Dictionary<string, ActivationsInfo>();
        }
        #endregion

        public string chatName = "Промокоды";
        PluginData pluginData;

        void Loaded()
        {
            LoadPluginData();
        }

        void LoadPluginData()
        {
            pluginData = Interface.GetMod().DataFileSystem.ReadObject<PluginData>("SPromo");
            if (pluginData.PromoInfo.Count == 0)
            {
                pluginData.PromoInfo.Add(
                    new PromoInfo
                    {
                        Name = "Default",
                        MaxUses = 0,
                        Items = new Dictionary<string, int> {
                            { "Torch", 1 },
                            { "Rock", 1 }
                        }
                    }                
                );
                SavePluginData();
            }
        }

        void SavePluginData()
        {
            Interface.GetMod().DataFileSystem.WriteObject("SPromo", pluginData);
        }

        [ChatCommand("promo")]
        void cmdPromo(NetUser netUser, string command, string[] args)
        {
            if (args.Length == 1)
            {
                if (netUser.CanAdmin())
                {
                    switch (args[0])
                    {
                        case "reload":
                            LoadPluginData();
                            rust.SendChatMessage(netUser, chatName, $"Плагин перезагружен!");
                            return;

                        case "wipe":
                            pluginData.ActivationsInfo.Clear();
                            SavePluginData();
                            rust.SendChatMessage(netUser, chatName, $"Данные об активациях были очищены!");
                            return;
                    }
                }

                string promoName = args[0].ToLower();
                foreach (var x in pluginData.PromoInfo)
                {
                    if (promoName == x.Name.ToLower())
                    {
                        if (!pluginData.ActivationsInfo.ContainsKey(x.Name))
                            pluginData.ActivationsInfo.Add(x.Name, new ActivationsInfo { AlreadyUses = 0, PlayersActivated = new List<ulong>() });

                        var promoData = pluginData.ActivationsInfo[x.Name];

                        if (promoData.AlreadyUses >= x.MaxUses)
                        {
                            rust.SendChatMessage(netUser, chatName, $"Вы не можете использовать данный промокод, т.к. у него исчерпан лимит активаций ({promoData.AlreadyUses}/{x.MaxUses})");
                            return;
                        }

                        if (promoData.PlayersActivated.Contains(netUser.userID))
                        {
                            rust.SendChatMessage(netUser, chatName, $"Вы больше не можете активировать данный промокод, т.к. активировали его ранее!");
                            return;
                        }

                        foreach (var pair in x.Items)
                        {
                            ItemDataBlock item = DatablockDictionary.GetByName(pair.Key);
                            Helper.GiveItem(netUser.playerClient, item, pair.Value, -1);
                        }

                        ++promoData.AlreadyUses;
                        promoData.PlayersActivated.Add(netUser.userID);
                        SavePluginData();

                        rust.SendChatMessage(netUser, chatName, $"Вы успешно активировали промокод и получили предметы!");
                        return;
                    }
                }

                rust.SendChatMessage(netUser, chatName, $"Промокод \"{args[0]}\" не найден!");
                return;
            }

            rust.SendChatMessage(netUser, chatName, $"Активация промокода: /promo <название>");
            if (netUser.CanAdmin())
            {
                rust.SendChatMessage(netUser, chatName, $"[Админ] Перезагрузить конфиг: /promo reload");
                rust.SendChatMessage(netUser, chatName, $"[Админ] Удалить данные об активациях: /promo wipe");
            }
        }
    }
}