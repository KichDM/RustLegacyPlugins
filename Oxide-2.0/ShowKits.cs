using RustExtended;
using System;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("ShowKits", "Sh1ne", "1.0.0")]
    class ShowKits : RustLegacyPlugin
    {
        string ChatName = RustExtended.Core.ServerName;

        int maxLength_Kits = 100;
        int maxLength_Items = 100;

        string c_avai  = "[COLOR#F2FBEF]";
        string c_list  = "[COLOR#00FFFF]";
        string c_items = "[COLOR#00FFFF]";

        string invalid = "[COLOR#FE2E2E]Неправильное использование! [COLOR#FFFFFF]Пример команды: /kits";
        string dontkit = "[COLOR#FE2E2E]Набор {0} не найден! [COLOR#FFFFFF]Список всех наборов: /kits";
        string cantkit = "[COLOR#FE2E2E]Набор {0} не доступен для вас! [COLOR#FFFFFF]Список всех наборов: /kits";
        string emptkit = "[COLOR#FE2E2E]В наборе {0} нет предметов! [COLOR#FFFFFF]Список всех наборов: /kits";

        string infokit = "[COLOR$F2FBEF]Посмотреть список всех предметов в ките: /kits <название кита>";

        [ChatCommand("kits")]
        void cmdKits(NetUser netUser, string command, string[] args)
        {
            string text = $"Command [{netUser.displayName}:{netUser.userID}] /" + command;
            foreach (string s in args) text += " " + s;
            Helper.LogChat(text, true);

            if (args.Length == 0)
            {
                cmdWriteKits(netUser);
                return;
            }

            //Command /kits <name>
            cmdKitInfo(netUser, args);
        }

        void cmdWriteKits(NetUser netUser)
        {
            UserData userData = Users.Find(netUser.userID);
            if (userData == null) return;

            bool haveKits = false;
            string AvailabledKits = $"{c_avai}Доступные киты: {c_list}";
            foreach (string Kit in RustExtended.Core.Kits.Keys)
            {
                List<string> KitList = (List<string>)RustExtended.Core.Kits[Kit];
                string KitRank = KitList.Find(K => K.ToLower().StartsWith("rank")); int Rank;
                bool KitAvailabled = (String.IsNullOrEmpty(KitRank) || !KitRank.Contains("="));
                if (!KitAvailabled) { KitRank = KitRank.Split('=')[1].Trim(); KitAvailabled = String.IsNullOrEmpty(KitRank); }
                if (!KitAvailabled) foreach (string kitRank in KitRank.Split(',')) if (KitAvailabled = (int.TryParse(kitRank, out Rank) && Rank == userData.Rank)) break;
                if (KitAvailabled)
                {
                    if ((AvailabledKits + Kit + ", ").Length >= maxLength_Kits)
                    {
                        rust.SendChatMessage(netUser, ChatName, $"{c_list}{AvailabledKits}");
                        AvailabledKits = string.Empty;
                    }
                    AvailabledKits += Kit + ", ";
                    haveKits = true;
                }
            }

            if (haveKits)
            {
                if (AvailabledKits.Length >= 2) AvailabledKits = AvailabledKits.Substring(0, AvailabledKits.Length - 2);
                rust.SendChatMessage(netUser, ChatName, $"{c_list}{AvailabledKits}");
                rust.SendChatMessage(netUser, ChatName, infokit);
            }
            else
            {
                rust.SendChatMessage(netUser, ChatName, RustExtended.Config.GetMessage("Command.Kits.NotAvailable", netUser));
                return;
            }
        }

        void cmdKitInfo(NetUser netUser, string[] args)
        {
            UserData userData = Users.Find(netUser.userID);
            if (userData == null) return;

            string Kit = args[0];
            if (!RustExtended.Core.Kits.ContainsKey(Kit))
            {
                string text = string.Format(dontkit, Kit);
                rust.SendChatMessage(netUser, ChatName, text);
                return;
            }

            List<string> KitList = (List<string>)RustExtended.Core.Kits[Kit];

            string KitRank = KitList.Find(K => K.ToLower().StartsWith("rank")); int Rank;
            bool KitAvailabled = (String.IsNullOrEmpty(KitRank) || !KitRank.Contains("="));
            if (!KitAvailabled) { KitRank = KitRank.Split('=')[1].Trim(); KitAvailabled = String.IsNullOrEmpty(KitRank); }
            if (!KitAvailabled) foreach (string kitRank in KitRank.Split(',')) if (KitAvailabled = (int.TryParse(kitRank, out Rank) && Rank == userData.Rank)) break;

            if (!KitAvailabled)
            {
                string text = string.Format(cantkit, Kit);
                rust.SendChatMessage(netUser, ChatName, text);
                return;
            }

            bool haveItems = false;
            string KitItems = $"{c_avai}Предметы из {Kit}: {c_items}";
            foreach (string VAR in KitList)
            {
                if (VAR.ToLower().StartsWith("item") && VAR.Contains("="))
                {
                    string[] Item = VAR.Split('='); if (Item.Length < 2) continue;
                    string[] KitItem = Item[1].Split(','); string ItemName = KitItem[0].Trim();
                    int Amount; if (KitItem.Length > 1) { if (!int.TryParse(KitItem[1].Trim(), out Amount)) Amount = 1; } else Amount = 1;
                    int Slots; if (KitItem.Length > 2) { if (!int.TryParse(KitItem[2].Trim(), out Slots)) Slots = -1; } else Slots = -1;

                    string KitText = $"{ItemName} x {Amount}";

                    if ((KitItems + KitText + ", ").Length >= maxLength_Items)
                    {
                        rust.SendChatMessage(netUser, ChatName, $"{c_items}{KitItems}");
                        KitItems = string.Empty;
                    }

                    KitItems += KitText + ", ";
                    haveItems = true;
                }
            }

            if (haveItems)
            {
                if (KitItems.Length >= 2) KitItems = KitItems.Substring(0, KitItems.Length - 2);
                rust.SendChatMessage(netUser, ChatName, $"{c_items}{KitItems}");
            }
            else
            {
                string text = string.Format(emptkit, Kit);
                rust.SendChatMessage(netUser, ChatName, text);
                return;
            }
        }
    }
}