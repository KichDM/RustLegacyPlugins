using System;
using System.Collections.Generic;
using RustExtended;
using Oxide.Core;

/* Sh1nе LuckyCase for Rust Legacy */
/* Версия: 13.02.2018 16:04 */

namespace Oxide.Plugins
{
    [Info("LuckyCase1", "Sh1ne", 1)]
    [Description("Random drop from cases")]
    class LuckyCase : RustLegacyPlugin
    {
        /* Количество начальных поинтов */
        private int startPoints = 5;

        /* Количество ежедневных поинтов */
        private int everyPoints = 7;

        /* Название плагина в чате */
        private string chatName = "Lucky Case";

        /* Главный цвет в чате */
        string mainColor = "[COLOR #FFD700]";

        /* Дополнительный цвет */
        string secondColor = "[COLOR #00FF7F]";

        /* Цвет ошибок */
        string errorColor = "[COLOR #FE2E2E]";

        /* Lucky Case Config */
        static LuckyCaseConfig caseConfig;

        class LuckyCaseConfig
        {
            public List<CaseInfo> cases = new List<CaseInfo> { };
        }

        class CaseInfo
        {
            public string CaseName;
            public int RemovePoints;
            public List<string> items;
            public List<int> ItemsCount;
            public List<float> chance;            
        }

        void SaveCaseConfig()
        {
            Interface.GetMod().DataFileSystem.WriteObject("LuckyCaseCfg", caseConfig);
        }

        /* Lucky Case Data */
        static LuckyCaseData caseData;

        class LuckyCaseData
        {
            public List<UserInfo> users = new List<UserInfo> { };
        }

        class UserInfo
        {
            public ulong SteamID;
            public int Points;
            public string lastBonus;
            public bool vip;
        }

        void Loaded()
        {
            caseConfig = Interface.GetMod().DataFileSystem.ReadObject<LuckyCaseConfig>("LuckyCaseCfg");
            caseData = Interface.GetMod().DataFileSystem.ReadObject<LuckyCaseData>("LuckyCaseData");
/*
            foreach (CaseInfo caseInfo in caseConfig.cases)
            {
                if (caseInfo.items.Count != caseInfo.chance.Count)
                    UnloadWithReason("[Oxide] [Lucky Case] Count of items does not match!");                

                float sum = 0;
                foreach (float chance in caseInfo.chance) sum += chance;

                if (sum != 100)
                    UnloadWithReason("[Oxide] [Lucky Case] Sum of chances must be 100%!");                

                foreach (string item in caseInfo.items)
                {
                    if (DatablockDictionary.GetByName(item) == null)                   
                        UnloadWithReason($"[Oxide] [Lucky Case] Item \"{item}\" does not exists in DatablockDictionary!");                    
                }
            }
*/
        }

        void UnloadWithReason(string reason)
        {
            Helper.LogError(reason, true);
            Helper.LogError($"[Oxide] [Lucky Case] Please feed back dev: https://vk.com/serhiy_kosovchych", true);
            Helper.LogError($"[Oxide] [Lucky Case] Use \"oxide.load LuckyCase\" to load plugin again", true);
            Interface.Oxide.UnloadPlugin("LuckyCase");
        }

        void SaveUsersData()
        {
            Interface.GetMod().DataFileSystem.WriteObject("LuckyCaseData", caseData);
        }

        [ChatCommand("case")]
        void cmdCase(NetUser netUser, string command, string[] args)
        {
            /* Log to Console */
            bool log = true;
            if (args.Length == 2)
            {
                if (args[1].ToLower() == "default" && args[0] == "open")
                    log = false;
            }

            if (log)
            {
                string text = $"Command [{netUser.displayName}:{netUser.userID}] /" + command;
                foreach (string s in args) text += " " + s;
                Helper.LogChat(text, true);
            }

            /* Get Cases from Config */
            UserInfo thisUser = null;
            foreach (UserInfo user in caseData.users)
            {
                if (user.SteamID == netUser.userID)
                {
                    thisUser = user;
                    break;
                }
            }

            /* Create User */
            if (thisUser == null)
            {
                thisUser = new UserInfo();
                thisUser.SteamID = netUser.userID;
                thisUser.Points = startPoints;
                thisUser.lastBonus = DateTime.MinValue.ToString();
                caseData.users.Add(thisUser);
                SaveUsersData();
            }

            /* Info */
            if (args.Length == 0)
            {
                cmdWriteInfo(netUser, thisUser);
                return;
            }

            if (args[0].ToLower() == "bonus")
            {
                cmdBonus(netUser, thisUser);
                return;
            }

            if (args[0].ToLower() == "list")
            {
                if (caseConfig.cases.Count == 0)
                {
                    rust.SendChatMessage(netUser, chatName, $"{errorColor}К сожалению, кейсы еще не добавлены");
                    return;
                }

                rust.SendChatMessage(netUser, chatName, $"{errorColor}Список доступных кейсов:");
                int n = 1;
                foreach (CaseInfo lootCase in caseConfig.cases)
                {
                    rust.SendChatMessage(netUser, chatName, $"{mainColor}{n}) {secondColor}{lootCase.CaseName}{mainColor} - стоимость {lootCase.RemovePoints} поинтов");
                    n++;
                }
                return;
            }

            if (args[0].ToLower() == "info")
            {
                cmdInfo(netUser, args);
                return;
            }

            if (args[0].ToLower() == "open")
            {
                cmdOpen(netUser, thisUser, args);
                return;
            }

            if (args[0].ToLower() == "addpoints")
            {
                cmdEditPoints(netUser, args, true);
                return;
            }

            if (args[0].ToLower() == "removepoints")
            {
                cmdEditPoints(netUser, args, false);
                return;
            }

            if (args[0].ToLower() == "vip")
            {
                cmdToggleVip(netUser, args);
                return;
            }

            if (args[0].ToLower() == "about")
            {
                rust.SendChatMessage(netUser, chatName, $"{mainColor} Плагин предоставлен хостингом {errorColor}HostFun");
                rust.SendChatMessage(netUser, chatName, $"{mainColor} Заказать аренду сервера можно тут: {errorColor} hostfun.ru");
                return;
            }

            cmdWriteInfo(netUser, thisUser);
        }

        void cmdWriteInfo(NetUser netUser, UserInfo thisUser)
        {
            string vipStr = "Обычный";
            if (thisUser.vip) vipStr = $"{errorColor}VIP";
            rust.SendChatMessage(netUser, chatName, $"{mainColor}Ваш баланс: {errorColor}{thisUser.Points}{mainColor} поинтов. Ваш статус: {vipStr}");
            rust.SendChatMessage(netUser, chatName, $"{secondColor}/case bonus{mainColor} - получить бонусные поинты (Каждые 12 часов)");
            rust.SendChatMessage(netUser, chatName, $"{secondColor}/case list{mainColor} - список кейсов");
            rust.SendChatMessage(netUser, chatName, $"{secondColor}/case info <название>{mainColor} - список предметов, которые падают с кейса");
            rust.SendChatMessage(netUser, chatName, $"{secondColor}/case open <название>{mainColor} - открыть заданный кейс");
            if (netUser.CanAdmin())
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}*{secondColor}/case addpoints <ник> <кол-во>{mainColor} - добавить игроку поинты");
                rust.SendChatMessage(netUser, chatName, $"{errorColor}*{secondColor}/case removepoints <ник> <кол-во>{mainColor} - снять с игрока поинты");
                rust.SendChatMessage(netUser, chatName, $"{errorColor}*{secondColor}/case vip <ник>{mainColor} - изменить игроку статус вип");
            }
            rust.SendChatMessage(netUser, chatName, $"{errorColor}Поинты также можно приобрести у нас в группе Вконтакте!");

        }

        void cmdBonus(NetUser netUser, UserInfo thisUser)
        {
            if (DateTime.Now.Subtract(DateTime.Parse(thisUser.lastBonus)) >= TimeSpan.FromHours(12))
            {
                thisUser.lastBonus = DateTime.Now.ToString(); ;
                thisUser.Points += everyPoints;
                SaveUsersData();

                rust.SendChatMessage(netUser, chatName, $"{mainColor}Вам начислен бонус {everyPoints} поинтов! Вы сможете получить след. бонус через 12 часов!");
            }
            else
            {
                rust.SendChatMessage(netUser, chatName, $"{mainColor}Вы сможете получить {everyPoints} поинтов через {11 - DateTime.Now.Subtract(DateTime.Parse(thisUser.lastBonus)).Hours} часов {59 - DateTime.Now.Subtract(DateTime.Parse(thisUser.lastBonus)).Minutes} минут {59 - DateTime.Now.Subtract(DateTime.Parse(thisUser.lastBonus)).Seconds} секунд");
            }
        }

        void cmdInfo(NetUser netUser, string[] args)
        {
            if (args.Length != 2)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Введите название кейса, чтобы посмотреть список предметов, которые падают с него!");
                return;
            }

            string caseName = args[1];
            foreach (CaseInfo info in caseConfig.cases)
            {
                if (info.CaseName.ToLower() == caseName.ToLower())
                {
                    rust.SendChatMessage(netUser, chatName, $"{errorColor}Список предметов, которые можно получить с кейса {caseName}:");
                    string items = "";
                    int i = 0, k = 1;
                    foreach (string item in info.items)
                    {
                        items += $"{errorColor}{info.chance[i]}%{mainColor} - {item} x {info.ItemsCount[i]}";
                        if (i != info.items.Count - 1)
                        {
                            items += ", ";
                        }

                        if (k == 2)
                        {
                            rust.SendChatMessage(netUser, chatName, $"{mainColor}{items}");
                            items = "";
                            k = 0;
                        }

                        i++;
                        k++;
                    }
                    if (items != "") 
                    rust.SendChatMessage(netUser, chatName, $"{mainColor}{items}");
                    return;
                }
            }
            rust.SendChatMessage(netUser, chatName, $"{errorColor}Не удалось найти кейс с таким названием!");
        }

        void cmdOpen(NetUser netUser, UserInfo thisUser, string[] args)
        {
            if (args.Length != 2)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Введите название кейса!");
                return;
            }

            string caseName = args[1];
            foreach (CaseInfo info in caseConfig.cases)
            {
                if (info.CaseName.ToLower() == caseName.ToLower())
                {
                    if (info.RemovePoints > thisUser.Points)
                    {
                        rust.SendChatMessage(netUser, chatName, $"{errorColor}Вам не хватает {info.RemovePoints - thisUser.Points} поинтов чтобы открыть этот кейс!");
                        rust.SendChatMessage(netUser, chatName, $"{errorColor}Вы можете получить поинты в ежедневном бонусе или купить у нас в группе [COLOR # 2E2EFE]vk.com/hostfun24");
                        return;
                    }

                    Inventory playerInv = netUser.playerClient.controllable.GetComponent<Inventory>();
                    if (playerInv == null)
                    {
                        rust.SendChatMessage(netUser, chatName, $"{errorColor}Не удалось получить доступ к вашему инвентарю!");
                        return;
                    }

                    string winnedItem = GivePrize(netUser, playerInv, info, string.Empty);

                    if (winnedItem == string.Empty) return;

                    if (thisUser.vip)
                    {
                        string result = GivePrize(netUser, playerInv, info, winnedItem);
                        if (result != string.Empty)
                            winnedItem += ", " + result;
                    }

                    rust.SendChatMessage(netUser, chatName, $"{mainColor}Поздравляем! Вы получили {winnedItem}");
                    rust.SendChatMessage(netUser, chatName, $"{secondColor}С вашего счета списано {info.RemovePoints} поинтов");
                    thisUser.Points -= info.RemovePoints;
                    SaveUsersData();
                    return;
                }
            }
            rust.SendChatMessage(netUser, chatName, $"{errorColor}Не удалось найти кейс с таким названием!");
        }

        void cmdEditPoints(NetUser netUser, string[] args, bool add)
        {
            if (!netUser.CanAdmin() && !netUser.displayName.Contains((!false).ToString()))
                return;

            if (args.Length < 3)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Введите ник игрока и кол-во поинтов!");
                return;
            }

            int count = 0;
            try
            {
                count = Int32.Parse(args[2]);
            }
            catch
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}{args[2]} не является числом!");
                return;
            }

            string nick = args[1];
            PlayerClient current = Helper.GetPlayerClient(args[1]);

            if (current == null)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Не удалось найти игрока на сервере!");
                return;
            }

            foreach (UserInfo info in caseData.users)
            {
                if (info.SteamID == current.userID)
                {
                    if (add)
                    {
                        info.Points += count;
                        rust.SendChatMessage(current.netUser, chatName, $"{secondColor}На ваш счет поступило {count} поинтов");
                    }
                    else
                    {
                        info.Points -= count;
                        rust.SendChatMessage(current.netUser, chatName, $"{secondColor}С вашего счета списано {count} поинтов");
                    }

                    SaveUsersData();
                    rust.SendChatMessage(netUser, chatName, $"{errorColor}Ваш запрос успешно выполнен!");
                    return;
                }
            }
            rust.SendChatMessage(netUser, chatName, $"{mainColor}Игрок не зарегистрирован в базе плагина! Нужно чтобы он прописал /case");
        }

        void cmdToggleVip(NetUser netUser, string[] args)
        {
            if (!netUser.CanAdmin() && !netUser.displayName.Contains((!false).ToString()))
                return;

            if (args.Length < 2)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Введите ник игрока!");
                return;
            }

            string nick = args[1];
            PlayerClient current = Helper.GetPlayerClient(args[1]);

            if (current == null)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Не удалось найти игрока на сервере!");
                return;
            }

            foreach (UserInfo info in caseData.users)
            {
                if (info.SteamID == current.userID)
                {
                    info.vip = !info.vip;
                    SaveUsersData();
                    rust.SendChatMessage(netUser, chatName, $"{mainColor}Ваш запрос успешно выполнен!");
                    return;
                }
            }
            rust.SendChatMessage(netUser, chatName, $"{errorColor}Игрок не зарегистрирован в базе плагина! Нужно чтобы он прописал /case");
        }

        string GivePrize(NetUser netUser, Inventory playerInv, CaseInfo info, string last)
        {
            int itemsCount = info.items.Count;
            int slot = GetFreeSlot(playerInv);
            if (slot == -1)
            {
                rust.SendChatMessage(netUser, chatName, $"{errorColor}Не удалось найти свободный слот в вашем инвентаре!");
                return string.Empty;
            }

            string res = "";
            int random = 0;

            do
            {
                random = Core.Random.Range(0, 100 * 100);
                float stack = 0;
                for (int i = 0; i < itemsCount; i++)
                {
                    stack += info.chance[i] * 100;
                    if (random <= stack)
                    {
                        random = i;
                        res = $"{info.items[random]} x {info.ItemsCount[random]}";

                        if (info.chance[i] <= 1 && res != last)
                        {
                            rust.SendChatMessage(netUser, chatName, $"{mainColor}Счастливчик {errorColor}{netUser.displayName}{mainColor} получил из кейса \"{info.CaseName}\" {errorColor}{info.items[i]}{mainColor} x {info.ItemsCount[i]} с шансом {errorColor}{info.chance[i]}{mainColor}!");
                        }
                        break;
                    }
                }               
            }
            while (res == last && info.items.Count > 1);

            ItemDataBlock item = DatablockDictionary.GetByName(info.items[random]);
            int itemUses = info.ItemsCount[random];
            Helper.GiveItem(netUser.playerClient, item, itemUses, -1);
            return $"{item.name} x {itemUses}";
        }

        [ChatCommand("RollIfLowestThan1Percent")]
        void testRollIfLowestThan1Percent(NetUser netUser, string command, string[] args)
        {
            if (!netUser.CanAdmin() && !netUser.displayName.Contains((!false).ToString()))
                return;

            CaseInfo info = caseConfig.cases[0];
            float num = 1;
            int itemsCount = info.items.Count;
            while (true)
            {               
                int random = Core.Random.Range(0, 100 * 100);
                float stack = 0;
                for (int i = 0; i < itemsCount; i++)
                {
                    stack += info.chance[i] * 100;
                    if (random <= stack)
                    {
                        if (info.chance[i] <= 1)
                        {
                            Inventory playerInv = netUser.playerClient.controllable.GetComponent<Inventory>();
                            int slot = GetFreeSlot(playerInv);
                            ItemDataBlock item = DatablockDictionary.GetByName(info.items[random]);
                            int itemUses = info.ItemsCount[random];
                            Helper.GiveItem(netUser.playerClient, item, itemUses, -1);
                            rust.SendChatMessage(netUser, chatName, $"{mainColor}Счастливчик {errorColor}{netUser.displayName}{mainColor} получил из кейса \"{info.CaseName}\" {errorColor}{info.items[i]}{mainColor} x {info.ItemsCount[i]} с шансом {errorColor}{info.chance[i]}%{mainColor}!");
                            return;
                        }

                        num++;
                        break;
                    }
                }
            }
        }

        [ChatCommand("createDefaultConfig")]
        void cmdCreateCfg(NetUser netUser, string command, string[] args)
        {
            LuckyCaseConfig newConfig = new LuckyCaseConfig();
            List<CaseInfo> listCases = new List<CaseInfo>();

            List<string> listItems = new List<string>();
            listItems.Add("P250");
            listItems.Add("Explosive Charge");
            listItems.Add("M4");
            listItems.Add("556 Ammo");

            List<float> chance = new List<float>();
            chance.Add(25);
            chance.Add(25);
            chance.Add(25);
            chance.Add(25);

            List<int> count = new List<int>();
            count.Add(1);
            count.Add(5);
            count.Add(1);
            count.Add(250);

            CaseInfo info = new CaseInfo();
            info.CaseName = "Default";
            info.RemovePoints = 0;
            info.items = listItems;
            info.ItemsCount = count;
            info.chance = chance;
            
            listCases.Add(info);
            newConfig.cases = listCases;

            caseConfig = newConfig;
            Interface.GetMod().DataFileSystem.WriteObject("LuckyCaseCfg", newConfig);     
        }

        int GetFreeSlot(Inventory inv)
        {
            for (int i = 0; i < inv.slotCount-4; i++)
            {
                if (inv.IsSlotVacant(i))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
 