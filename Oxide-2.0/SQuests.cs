using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using Oxide.Core;
using System.Collections;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("SQuests", "Sh1ne", "1.0.0")]
    class SQuests : RustLegacyPlugin
    {
        string ChatName = "Квесты";
        
        #region [Vars] Color config
        string cmain = "[COLOR # FFFFFF]";
        string ctext = "[COLOR # FFFFFF]";
        string cmoney = "[COLOR # 00FF00]";
        string cxp = "[COLOR # FFFF00]";
		      string crew = "[COLOR # 05E0FF]";
        string ccompleted = "[COLOR # FFFFFF]";
		      string questkon = "[COLOR # FFE200]";
        string cnow = "[COLOR # 00BFFF]";

        string ccancelled = "[COLOR # FE2E2E]";
        string cerror = "[COLOR # FE2E2E]";

        string ccompleteNow = "[COLOR # 00FF00]";

        string cligreen = "[COLOR # C8FE2E]";
        #endregion

        static Dictionary<int, Quest> quests = new Dictionary<int, Quest>();
        static Dictionary<ulong, EachUser> users = new Dictionary<ulong, EachUser>();
        

        #region [CLASS] Template of Quest and EachUser
        class Quest
        {
            public int minRank;             //Минимальный ранг для выполнения квеста = 0; Если > 0, добавляй в конец
            public int minLevel;            //Минимальный уровень для выполнения квеста = 0; Если > 0, добавляй в конец

            public string taskText;         //Текст, который выводится игроку
            public int interval;            //Интервал в секундах, через который можно снова выполнить квест

            public int actionType;          //Тип действия, которое нужно выполнить = 1;
            public float countActions;      //Количество для actionType = 1;
            public string argument;         //Примечание (Предмет, который скрафтить)

            public ulong rewardXP;          //Награда XP = 0;
            public ulong rewardMoney;       //Награда $ = 0;
        }

        class EachUser
        {
            public int quest = -1;
            public Dictionary<int, string> completed = new Dictionary<int, string>();
            public Dictionary<int, float> actionsCompleted = new Dictionary<int, float>();
        }
        #endregion

        #region [FUNCTION] GetUserData(ulong userID) - Return or create EachUserData for player
        EachUser GetUserData(ulong userID)
        {
            EachUser data;
            if (!users.TryGetValue(userID, out data))
            {
                data = new EachUser();
                users.Add(userID, data);
            }
            return data;
        }
        #endregion

        #region [FUNCTION] SecondsToTime(int seconds) - Return string: %d days %d hours %d mins %d sec
        string SecondsToTime(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            string time = string.Empty;
            if (timeSpan.Days > 0) time += $"{timeSpan.Days} дней ";
            if (timeSpan.Hours > 0) time += $"{timeSpan.Hours} часов ";
            if (timeSpan.Minutes > 0) time += $"{timeSpan.Minutes} минут ";
            if (timeSpan.Seconds > 0) time += $"{timeSpan.Seconds} секунд";
            if (time == string.Empty) time = "0 секунд";
            return time;
        }
        #endregion

        #region [HOOK] Loaded(): Load Config, Load EachUserData
        void Loaded()
        {
            /*
            - Список действий:
            Убить игрока - 1
            Убить волка - 2
            Убить медведя - 3
            Убить мутант волка - 4
            Убить мутант медведя - 5
            Убить кабана - 6
            Убить кролика - 7
            Убить курицу - 8
            Разрушить строение взрывчаткой - 9 (граната) или 10 (С4)
            Крафт - 11
            - Лут ящиков:
            12 - оружейный
            13 - сопля
            14 - обычный ящик
            20 - зелёный ящик
            21 - красный ящик
            - Добыча
            15 - Дерево
            16 - Камень
            17 - Железная руда
            18 - Серная руда
            19 - Пробежать дистанцию (лучше не надо)
            */
            quests = Interface.GetMod().DataFileSystem.ReadObject<Dictionary<int, Quest>>("SQuestsConfig");
            users = Interface.GetMod().DataFileSystem.ReadObject<Dictionary<ulong, EachUser>>("SQuestsUserData");
            quests.Add(1, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Убить 25 красных волков",
                interval = 10800,
                actionType = 4,
                countActions = 25,
                rewardMoney = 1000
            });
            quests.Add(2, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Убить 25 красных медведей",
                interval = 10800,
                actionType = 5,
                countActions = 25,
                rewardMoney = 1000
            });
            quests.Add(3, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Залутать 20 деревянных ящиков",
                interval = 10800,
                actionType = 14,
                countActions = 20,
                rewardMoney = 1500
            });
            quests.Add(4, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Залутать 20 зелёных ящиков",
                interval = 10800,
                actionType = 20,
                countActions = 20,
                rewardMoney = 1750
            });
            quests.Add(5, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Залутать 15 оружейных ящиков",
                interval = 10800,
                actionType = 13,
                countActions = 15,
                rewardMoney = 2000
            });
            quests.Add(6, new Quest()			
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Убить 100 красных волков",
                interval = 10800,
                actionType = 4,
                countActions = 100,
                rewardMoney = 9000
            });
            quests.Add(7, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Убить 100 красных медведей",
                interval = 10800,
                actionType = 5,
                countActions = 100,
                rewardMoney = 9000
            });
            quests.Add(8, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Залутать 100 деревянных ящиков",
                interval = 10800,
                actionType = 14,
                countActions = 100,
                rewardMoney = 10000
            });
            quests.Add(9, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Залутать 100 зелёных ящиков",
                interval = 10800,
                actionType = 20,
                countActions = 100,
                rewardMoney = 13000
            });
            quests.Add(10, new Quest()
            {
                minRank = 0,
                minLevel = 0,
                taskText = "Залутать 100 оружейных ящиков",
                interval = 10800,
                actionType = 13,
                countActions = 100,
                rewardMoney = 15000
            });				
        }
        #endregion

        #region [FUNCTION] SavePluginData()
        void SavePluginData()
        {
            Interface.GetMod().DataFileSystem.WriteObject("SQuestsUserData", users);
        }
        #endregion

        #region [ChatCommand("q")] Handler of command /q
        [ChatCommand("q")]
        void cmdQuest(NetUser netUser, string command, string[] args)
        {
            string text = $"Command [{netUser.displayName}:{netUser.userID}] /" + command;
            foreach (string s in args) text += " " + s;
            Helper.LogChat(text, true);
            TradeZoneOnly(netUser);

            if (args.Length == 0)
            {
                cmdWriteInfo(netUser);
                return;
            }

            switch (args[0].ToLower())
            {
                case "cancel":
                    cmdCancel(netUser);
                    return;
                case "help":
                    cmdHelp(netUser);
                    return;
                case "stat":
                    cmdStat(netUser);
                    return;
                case "complete":
                    cmdCompleteQuest(netUser);
                    return;
            }

            if (args.Length == 1)
            {
                int questID;
                try
                {
                    questID = Int32.Parse(args[0]);
                }
                catch
                {
                    return;
                }
                cmdTakeQuest(netUser, questID);
                return;
            }
        }
        #endregion

        /* Functions */
        #region [FUNCTION] [Command] /q - Выводит список доступных квестов
        void cmdWriteInfo(NetUser netUser)
        {
            foreach (KeyValuePair<int, Quest> eachQuest in quests)
            {
                int questID = eachQuest.Key;
                Quest quest = eachQuest.Value;

                EachUser user = GetUserData(netUser.userID);
                UserData userData = Users.GetBySteamID(netUser.userID);

                if (userData.Rank >= quest.minRank)
                {
                    ClanData clan = Clans.Find(netUser.userID);
                    if (clan != null && clan.Level.Id < quest.minLevel) continue;

                    bool writeReward = true, ended = false;
                    string ending = string.Empty;
                    string ctaskText = ctext;

                    if (user.completed.ContainsKey(questID))
                    {
                        if (quest.interval != -1)
                        {
                            DateTime completedTime = DateTime.Parse(user.completed[questID]);
                            TimeSpan passed = DateTime.Now - completedTime;

                            if ((int)passed.TotalSeconds < quest.interval)
                            {
                                int secondsLeft = quest.interval - (int)passed.TotalSeconds;
                                string timeLeft = SecondsToTime(secondsLeft);
                                ending = $"{cmain}будет доступен через {cligreen}{timeLeft}";
                                ctaskText = cmain;
                                writeReward = false;
                            }
                        }
                        else
                        {
                            ending = $"{ccompleted}Завершен";
                            ctaskText = cmain;
                            writeReward = false;
                            ended = true;
                        }
                    }

                    if (writeReward)
                    {
                        string reward = string.Empty;
                        if (quest.rewardMoney > 0) reward += $"{cmoney}{quest.rewardMoney}$";
                        if (quest.rewardXP > 0)
                        {
                            if (reward != string.Empty) reward += $"{cmain} и ";
                            reward += $"{cxp}{quest.rewardXP} XP";
                        }
                        ending = $"{crew}Награда {reward}";
                    }

                    if (user.quest == questID)
                    {
                        ending = $"{cnow}Текущее задание";
                    }

                    if (!ended)
                        rust.SendChatMessage(netUser, ChatName, $"{crew}{questID}. {ctaskText}{quest.taskText}{cmain} - {ending}");
                }
            }
            rust.SendChatMessage(netUser, ChatName, $"{cmain}Взять квест - {cligreen}/q <номер квеста>{cmain}, отменить квест - {cligreen}/q cancel");
            rust.SendChatMessage(netUser, ChatName, $"{cmain}Посмотреть свой прогресс выполнения квеста - {cligreen}/q stat");
        }
        #endregion

        #region [FUNCTION] [Command] /q cancel - Отменяет текущий квест
        void cmdCancel(NetUser netUser)
        {
            EachUser user = GetUserData(netUser.userID);
            if (user.quest != -1)
            {
                rust.SendChatMessage(netUser, ChatName, $"{cmain}- {cmain}Вы {ccancelled}отменили {cmain}квест под номером {crew}{user.quest}");
                user.quest = -1;
                SavePluginData();
                return;
            }
            rust.SendChatMessage(netUser, ChatName, $"{cerror}Вы не выбрали квест!");
        }
        #endregion

        #region [FUNCTION] [Command] /q <номер> - Взять квест
        void cmdTakeQuest(NetUser netUser, int questID)
        {
            EachUser user = GetUserData(netUser.userID);
            UserData userData = Users.GetBySteamID(netUser.userID);

            if (user.quest != -1)
            {
                rust.SendChatMessage(netUser, ChatName, $"{cmain}У вас уже взят квест под номером {crew}{user.quest}. {cmain}Чтобы отменить, напишите {crew}/q cancel");
                return;
            }

            if (quests.ContainsKey(questID))
            {
                Quest quest = quests[questID];

                if (user.completed.ContainsKey(questID))
                {
                    if (quest.interval == -1)
                    {
                        rust.SendChatMessage(netUser, ChatName, $"{cmain}Вы уже {ccompleted}выполняли {cmain}квест под номером {crew}{questID}");
                        return;
                    }
                    else
                    {
                        DateTime completedTime = DateTime.Parse(user.completed[questID]);
                        TimeSpan passed = DateTime.Now - completedTime;

                        if ((int)passed.TotalSeconds < quest.interval)
                        {
                            string timeLeft = $"{quest.interval - (int)passed.TotalSeconds}";
                            rust.SendChatMessage(netUser, ChatName, $"{cmain}Вы сможете повторно взять этот квест через {crew}{timeLeft} {cmain}секунд");
                            return;
                        }
                    }
                }

                ClanData clan = Clans.Find(netUser.userID);
                if (clan != null && clan.Level.Id < quest.minLevel) return;

                if (userData.Rank >= quest.minRank)
                {
                    user.quest = questID;
                    SavePluginData();
                    rust.SendChatMessage(netUser, ChatName, $"{ctext}- {ctext}Вы взяли квест {crew}{quest.taskText}");
                }
            }
            else
            {
                rust.SendChatMessage(netUser, ChatName, $"{cmain}Не удалось найти квест под номером {crew}{questID}!");
                return;
            }
        }
        #endregion

        #region [FUNCTION] [Command] /q help - Выводит список доступных комманд
        void cmdHelp(NetUser netUser)
        {
            rust.SendChatMessage(netUser, ChatName, $"{cmain}Доступные комманды: {crew}/q, /q <номер>, /q stat, /q cancel");
        }
        #endregion

        #region [FUNCTION] [Command] /q stat - Информация о текущем квесте
        void cmdStat(NetUser netUser)
        {
            EachUser user = GetUserData(netUser.userID);

            if (user.quest != -1)
            {
                Quest quest = quests[user.quest];
                int percent = 0;

                if (user.actionsCompleted.ContainsKey(user.quest))
                    percent = (int)((user.actionsCompleted[user.quest] / quest.countActions) * 100f);

                rust.SendChatMessage(netUser, ChatName, $"{cmain}Сейчас вы выполняете квест под номером {crew}{user.quest}");
                rust.SendChatMessage(netUser, ChatName, $"{cmain}Квест выполнен на {crew}{percent}%");
                rust.SendChatMessage(netUser, ChatName, $"{cmain}Ваша задача: {crew}{quest.taskText}");
            }
            else
                rust.SendChatMessage(netUser, ChatName, $"{cmain}Вы не взяли квест!");
        }
        #endregion

        #region [Admin] [FUNCTION] [Command] /q complete - Завершить квест
        void cmdCompleteQuest(NetUser netUser)
        {
            if (!netUser.CanAdmin()) return;

            EachUser user = GetUserData(netUser.userID);
            if (user.quest != -1)
                CompleteQuest(netUser, user.quest);
            else
                rust.SendChatMessage(netUser, ChatName, $"{cmain}Вы не взяли квест!");
        }
        #endregion

        /* Hooks */
        #region [HOOK] [OnKilled] (Type: 1 - 10) 
        void OnKilled(TakeDamage damage, DamageEvent evt)
        {
            if (evt.amount < damage.health) return;

            NetUser netUser = evt.attacker.client?.netUser ?? null;
            if (netUser == null) return;

            EachUser user = GetUserData(netUser.userID);
            if (user.quest == -1) return;

            Quest quest = quests[user.quest];

            #region [Type 1] Kill player
            if (quest.actionType == 1 && damage is HumanBodyTakeDamage)
            {
                NetUser victim = evt.victim.client?.netUser ?? null;
                if (victim == null || netUser == victim) return;

                CompleteAction(netUser);
                return;
            }
            #endregion

            #region [Type 2-8] Kill: Wolf, Bear, Mutant Wolf, Mutant Bear, Boar, Rabbit, Chicken
            if (quest.actionType >= 2 && quest.actionType <= 8)
            {
                Character victim = evt.victim.character ?? null;
                if (victim != null)
                {
                    int action = -1;
                    switch (Helper.NiceName(victim.name))
                    {
                        case "Wolf": action = 2; break;
                        case "Bear": action = 3; break;
                        case "Mutant Wolf": action = 4; break;
                        case "Mutant Bear": action = 5; break;
                        case "Boar": action = 6; break;
                        case "Rabbit": action = 7; break;
                        case "Chicken": action = 8; break;
                    }

                    if (quest.actionType == action)
                        CompleteAction(netUser);
                }
                return;
            }
            #endregion

            #region [Type 9-10] Blow structure with F1 Grenade or Explosive Charge
            if (quest.actionType == 9 || quest.actionType == 10)
            {
                if (evt.victim.idMain is StructureComponent)
                {
                    if (evt.damageTypes == DamageTypeFlags.damage_explosion)
                    {
                        if (evt.amount < 150f)
                            CompleteAction(netUser);
                        else
                            CompleteAction(netUser);
                    }
                }
                return;
            }
            #endregion
        }
        #endregion

        #region [HOOK] [OnItemCraft] [Type 11] Craft item
        void OnItemCraft(CraftingInventory inventory, BlueprintDataBlock blueprint, int amount, ulong startTime)
        {
            NetUser netUser = NetUser.Find(inventory.networkView.owner);
            PlayerInventory playerInv = inventory as PlayerInventory;
            if (playerInv == null || netUser == null) return;

            EachUser user = GetUserData(netUser.userID);
            if (user.quest == -1) return;

            Quest quest = quests[user.quest];
            if (quest.actionType == 11 && blueprint.resultItem.name == quest.argument)
            {
                CompleteAction(netUser, amount);
            }
        }
        #endregion

        #region [HOOK] [OnLoot] (Type 12 - 14)
        Dictionary<int, Vector3> boxList = new Dictionary<int, Vector3>();

        void OnItemRemoved(Inventory fromInv, int slot, IInventoryItem item)
        {
            if (fromInv == null) return;

            LootableObject lootable = fromInv.GetComponent<LootableObject>();
            if (lootable != null && lootable.destroyOnEmpty && lootable.NumberOfSlots == 12)
            {
                int boxID = lootable.networkViewID.id;
                if (boxID == 0) return;

                if (boxList.ContainsKey(boxID) && boxList[boxID] != lootable.transform.position)
                {
                    boxList.Remove(boxID);
                }

                if (!boxList.ContainsKey(boxID))
                {
                    foreach (PlayerClient player in PlayerClient.All)
                    {
                        if (player != null && fromInv.IsAnAuthorizedLooter(player.netPlayer))
                        {
                            string lootName = lootable.name.Replace("(Clone)", "");

                            EachUser user = GetUserData(player.userID);
                            if (user.quest == -1) return;

                            Quest quest = quests[user.quest];

                            #region [Type 12] Loot SupplyCrate
                            if (quest.actionType == 12 && lootName == "SupplyCrate")
                            {
                                CompleteAction(player.netUser);
                                boxList.Add(boxID, lootable.transform.position);
                            }
                            #endregion

                            #region [Type 13] Loot WeaponLootBox
                            if (quest.actionType == 13 && lootName == "WeaponLootBox")
                            {
                                CompleteAction(player.netUser);
                                boxList.Add(boxID, lootable.transform.position);
                            }
                            #endregion

                            #region [Type 14] Loot any LootBox
                            if (quest.actionType == 14 && lootName == "BoxLoot")
                            {
                                CompleteAction(player.netUser);
                                boxList.Add(boxID, lootable.transform.position);
                            }
                            if (quest.actionType == 20 && lootName == "AmmoLootBox")
                            {
                                CompleteAction(player.netUser);
                                boxList.Add(boxID, lootable.transform.position);
                            }
                            if (quest.actionType == 21 && lootName == "MedicalLootBox")
                            {
                                CompleteAction(player.netUser);
                                boxList.Add(boxID, lootable.transform.position);
                            }
                            #endregion
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region [HOOK] [OnGather] (Type 15 - 18)
        void OnGather(Inventory reciever, ResourceTarget obj, ResourceGivePair item, int collected)
        {
            if (item == null || reciever == null || obj == null || collected < 1 || reciever.networkView.owner == null) return;
            NetUser netUser = NetUser.Find(reciever.networkView.owner);
            if (netUser == null) return;
            EachUser user = GetUserData(netUser.userID);
            if (user.quest == -1) return;
            ClanData clan = Clans.Find(netUser.userID);

            Quest quest = quests[user.quest];

            #region [Type 15] Gather amount of Wood
            if (quest.actionType == 15 && item.ResourceItemName == "Wood")
            {
                int bonus = (int)(collected * clan.Level.BonusGatheringWood / 100);
                CompleteAction(netUser, bonus + collected);
            }
            #endregion

            #region [Type 16] Gather amount of Stones
            if (quest.actionType == 16 && item.ResourceItemName == "Stones")
            {
                int bonus = (int)(collected * clan.Level.BonusGatheringWood / 100);
                CompleteAction(netUser, bonus + collected);
            }
            #endregion

            #region [Type 17] Gather amount of Metal Ore
            if (quest.actionType == 17 && item.ResourceItemName == "Metal Ore")
            {
                int bonus = (int)(collected * clan.Level.BonusGatheringWood / 100);
                CompleteAction(netUser, bonus + collected);
            }
            #endregion

            #region [Type 18] Gather amount of Sulfur Ore
            if (quest.actionType == 18 && item.ResourceItemName == "Sulfur Ore")
            {
                int bonus = (int)(collected * clan.Level.BonusGatheringWood / 100);
                CompleteAction(netUser, bonus + collected);
            }
            #endregion
        }
        #endregion

        #region [HOOK] [GetClientMove] [Type 19] Run amount distance
        void OnGetClientMove(HumanController controller, Vector3 origin)
        {
            if (controller == null) return;
            NetUser netUser = controller.netUser;
            if (netUser == null) return;

            EachUser user = GetUserData(netUser.userID);
            if (user.quest == -1) return;

            Quest quest = quests[user.quest];

            if (quest.actionType != 19) return;

            float distance = Vector3.Distance(netUser.playerClient.controllable.character.transform.position, origin);
            if (distance > 1f && distance < 15f)
            {
                CompleteAction(netUser, distance);
            }
        }
        #endregion

        /* Other */
        #region [Function] CompleteAction(netUser, questID) - Вызывать из хуков
        void CompleteAction(NetUser netUser, float count = 1)
        {
            EachUser user = GetUserData(netUser.userID);
            int questID = user.quest;
            if (questID == -1) return;

            //Увеличить количество выполненых действий
            IncCompletedActions(user, questID, count);

            Quest quest = quests[questID];
            if (quest.countActions == 1)
            {
                CompleteQuest(netUser, questID);
                return;
            }

            if (quest.countActions > 1)
            {
                if (user.actionsCompleted.ContainsKey(questID))
                {
                    if (user.actionsCompleted[questID] >= quest.countActions)
                    {
                        CompleteQuest(netUser, questID);
                    }
                }
            }
        }

        void ClearCompletedActions(EachUser user, int questID)
        {
            if (user.actionsCompleted.ContainsKey(questID))
            {
                user.actionsCompleted.Remove(questID);
            }
            SavePluginData();
        }

        void IncCompletedActions(EachUser user, int questID, float count = 1)
        {
            if (user.actionsCompleted.ContainsKey(questID))
                user.actionsCompleted[questID] += count;
            else
                user.actionsCompleted.Add(questID, count);

            SavePluginData();
        }
        #endregion

        #region [Private][Function] CompleteQuest(netUser, questID) - Не вызывать
        private void CompleteQuest(NetUser netUser, int questID)
        {
            EachUser user = GetUserData(netUser.userID);
            UserData userData = Users.GetBySteamID(netUser.userID);

            if (user.quest == questID)
            {
                user.quest = -1;
                ClearCompletedActions(user, questID);

                Quest quest = quests[questID];

                ClanData clan = Clans.Find(netUser.userID);
                if (clan != null) clan.Experience += quest.rewardXP;

                Economy.Get(netUser.userID).Balance += quest.rewardMoney;

                if (user.completed.ContainsKey(questID))
                {
                    user.completed[questID] = DateTime.Now.ToString();
                }
                else
                {
                    user.completed.Add(questID, DateTime.Now.ToString());
                }

                rust.SendChatMessage(netUser, ChatName, $"{cmain}Вы {ccompleteNow}выполнили {cmain}квест {ctext}{quest.taskText}. {ccompleteNow}");

                string reward = string.Empty;
                if (quest.rewardMoney > 0) reward += $"{cmoney}{quest.rewardMoney}$";
                if (quest.rewardXP > 0)
                {
                    if (reward != string.Empty) reward += $"{cmain} и ";
                    reward += $"{cxp}{quest.rewardXP} XP";
                }

                if (reward != string.Empty)
                    rust.SendChatMessage(netUser, ChatName, $"{cmain}Вы получили награду {reward}");
                SavePluginData();
            }
        }
        #endregion
    }
}