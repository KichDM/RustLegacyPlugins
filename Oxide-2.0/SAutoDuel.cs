using System;
using UnityEngine;
using RustExtended;
using Oxide.Core;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("SAutoDuel", "Sh1ne", "1.0.5")]
    class SAutoDuel : RustLegacyPlugin
    {
        // Для корректной работы нужна зона с флагом ивент

        /* Конфиг */
        const string chatName = "Дуэль";

        /* Время для ответа на запрос (в секундах) */
        const int timeForAnswer = 30;

        /* Время на подготовку к дуэли (в секундах) */
        const int timeForPrepare = 20;

        /* Время на поединок (в секундах) */
        const int timeForDuel = 80;

        /* Цвет ошибок */
        const string errorColor = "[COLOR #FE2E2E]";

        /* Цвет выделения важного */
        const string selectColor = "[COLOR #FFA500]";

        /* Минимальная сумма для дуэли */
        const int minDuelAmount = 100;

        /* Экипировка */
        static object[][] equipment = new object[][]
        {
            //            Тип ячейки инвентаря          Название предмета       Количество
            //           [Belt, Armor, Default]                 -                 1-250

            new object[]{ Inventory.Slot.Kind.Belt,     "P250",                 1   },
            new object[]{ Inventory.Slot.Kind.Belt,     "9mm Ammo",             100  },
            new object[]{ Inventory.Slot.Kind.Belt,     "Small Medkit",         2   },
            new object[]{ Inventory.Slot.Kind.Armor,    "Leather Helmet",       2   },
			new object[]{ Inventory.Slot.Kind.Armor,    "Leather Vest",       1   },
			new object[]{ Inventory.Slot.Kind.Armor,    "Leather Pants",       1   },
			new object[]{ Inventory.Slot.Kind.Armor,    "Leather Boots",       1   }
        };

        /* Сообщение при /duel */
        static string[] helpMsg = new string[]
        {
            "Команды плагина на Дуэли:",
            "/duel info - общая информация о дуэлях (читать всем)",
            "/duel go <ник> <сумма> - отправить игроку запрос на дуэль",
            "/duel accept <ник> - принять запрос от игрока",
            "/duel deny <ник> - отклонить запрос от игрока"
        };

        /* Сообщение при /duel info */
        static string[] infoMsg = new string[]
        {
            "Информация:",
            "1. После телепортации ваш инвентарь будет очищен",
            "2. Если время на дуэль выйдет, то победитель - тот, у кого больше HP",
            "3. Если HP одинаковое, то победитель выбирается рандомно"
        };

        static string[] adminMsg = new string[]
        {
            $"{errorColor}*/duel point 1 - поставить точку телепорта для первого игрока",
            $"{errorColor}*/duel point 2 - поставить точку телепорта для второго игрока"
        };

        /* Список всех сообщений */
        static Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            /* Errors */
            { "player_not_found",   errorColor + "Не удалось найти игрока с таким ником на сервере!" },
            { "numbers_only",       errorColor + "Последний параметр должен быть числом!" },
            { "bad_params",         errorColor + "Неправильные параметры команды! /duel - список команд" },
            { "already_member",     errorColor + "Сначала дождитесь окончания предыдущей дуэли!" },            
            { "already_duel",       errorColor + "У вас уже идет дуэль с этим человеком!" },
            { "target_already",     errorColor + "Ваш соперник уже на дуэли!" },           
            { "not_enough_money",   errorColor + "У вас недостаточно средств на балансе! Ваш баланс: [color green]{0}$" },
            { "target_timeout",     errorColor + "{0} не успел ответить на ваш запрос!" },
            { "player_timeout",     errorColor + "Вы не успели ответить на запрос {0}!" },
            { "request_not_found",  errorColor + "Запрос игрока не найден!" },
            { "target_cancelled",   errorColor + "{0} отменил дуэль!" },
            { "arena_unaviable",    errorColor + "Арена уже занята кем-то другим, попробуйте позже!" },
            { "cant_deny_duel",     errorColor + "Вы уже приняли дуэль!" },
            { "target_deny",        errorColor + "{0} отменил ваш запрос!" },
            { "target_leave",       errorColor + "Ваш соперник вышел с сервера. Дуэль отменена!" },
            { "request_himself",    errorColor + "Вы не можете вызвать на дуэль себя!" },
            { "bad_amount",         errorColor + "Сумма должна быть не меньше чем {0}$" },

            /* Messages */
            { "duel_point_placed",  "Вы успешно поставили точку {0} на координатах {1}" },
            { "request_sended",     "Вы отправили запрос на дуэль " + selectColor + "{0}[color clear] на [color green]{1}$[color clear]. После телепортации инвентарь будет очищен!" },
            { "request_getted_1",   "{0} отправил вам запрос на дуэль на [color green]{1}$[color clear]. У вас есть {2} секунд чтобы его принять." },
			{ "request_getted_2",   "Для принятия напишите /duel accept <ник>! При телепортации инвентарь будет очищен!" },
            { "deny_success",       "Вы отменили запрос {0}" },
            { "accept_success",     "Вы приняли запрос на дуэль. У вас есть " + selectColor + "{0}[color clear] секунд для подготовки к дуэли!" },
            { "target_accepted",    "{0} принял ваш запрос на дуэль. У вас есть {1} секунд для подготовки к дуэли!" },
            { "duel_started",       "Дуэль началась! Ваш противник " + selectColor + "{0}[color clear]. У вас есть " + selectColor + "{1}[color clear] секунд на поединок." },
            { "duel_countdown",     "У вас осталось " + selectColor + "{0}[color clear] секунд до окончания дуэли!" },
            { "duel_winner",        "Игрок " + selectColor + "{0}[color clear] победил "+ selectColor +"{1}[color clear] на дуэли и получает [color green]{2}$[color clear]" },
        };
        
        /* Переменнные класса TDuel */
        class TDuel
        {
            public ulong amount;
            public NetUser initiator;
            public NetUser target;
            public bool accepted;
            public bool finished;

            public void Finish(NetUser winner)
            {
                if (finished == false)
                {
					finished = true;
					
                    if (initiator != null)
                    {
                        ClearInventory(initiator);
                        Character character1; Character.FindByUser(initiator.userID, out character1);
                        if (character1 != null) TakeDamage.KillSelf((IDBase)character1);                        
                    }

                    if (target != null)
                    {
                        ClearInventory(target);
                        Character character2; Character.FindByUser(target.userID, out character2);
                        if (character2 != null) TakeDamage.KillSelf((IDBase)character2);
                    }

                    if (winner != null)
                    {
                        NetUser loser; string loserName = "соперника";
                        if (initiator == winner) loser = target; else loser = initiator;
                        if (loser != null) loserName = loser.displayName;
                        Broadcast.MessageAll(string.Format(messages["duel_winner"], winner.displayName, loserName, amount * 2));
                        Economy.BalanceAdd(winner.userID, amount * 2);
                    }                    
                }

                if (duels.Contains(this)) duels.Remove(this);
            }

            public static bool isAnyMember(NetUser player, bool acceptedOnly = false)
            {
                foreach (TDuel duel in duels)
                {
                    if (duel.initiator == player || duel.target == player)
                    {
                        if (acceptedOnly)
                        {
                            if (duel.accepted) return true;
                        }
                        else return true;                        
                    }
                }
                return false;
            }
            
            public static TDuel getByMembers(NetUser p1, NetUser p2)
            {
                foreach (TDuel duel in duels)
                {
                    if ((duel.initiator == p1 && duel.target == p2) || (duel.target == p1 && duel.initiator == p2))
                    {
                        return duel;
                    }
                }
                return null;
            }
        }
        static List<TDuel> duels = new List<TDuel>();

        /* Переменные класса PluginData */
        struct DuelData
        {
            public string spawnPoint1;
            public string spawnPoint2;
        }

        class PluginData
        {
            public DuelData duelData;
            //...
        }

        PluginData pluginData;
        RustServerManagement management;

        bool config_is_right = false;
        bool arena_is_free = true;

        /* Hooks */

        void Loaded()
        {
            pluginData = Interface.GetMod().DataFileSystem.ReadObject<PluginData>("SAutoDuel");
        }

        void OnServerInitialized()
        {
            management = RustServerManagement.Get();
        }

        void OnKilled(TakeDamage takedamage, DamageEvent damage)
        {
            if (damage.victim.client == null) return;
            NetUser netUser = damage.victim.client.netUser;

            if (TDuel.isAnyMember(netUser, true))
            {
                TDuel userDuel = null;
                foreach (TDuel duel in duels)
                {
                    if (duel.initiator == netUser || duel.target == netUser)
                    {
                        if (duel.accepted && !duel.finished)
                        {
                            userDuel = duel;
                            break;
                        }
                    }
                }

				if (userDuel != null)
				{
					NetUser winner = (netUser == userDuel.initiator) ? userDuel.target : userDuel.initiator;
					arena_is_free = true;
					userDuel.Finish(winner);					
				}
            }
        }

        void OnPlayerDisconnect(uLink.NetworkPlayer netPlayer)
        {
            if (netPlayer == null) return;
            NetUser netUser = (NetUser)netPlayer.GetLocalData();
            if (netUser != null)
            {
                if (TDuel.isAnyMember(netUser, true))
                {
                    TDuel userDuel = null;
                    foreach (TDuel duel in duels)
                    {
                        if (duel.initiator == netUser || duel.target == netUser)
                        {
                            if (duel.accepted)
                            {
                                userDuel = duel;
                                break;
                            }
                        }
                    }

                    ClearInventory(netUser);
                    NetUser winner = (netUser == userDuel.initiator) ? userDuel.target : userDuel.initiator;
                    userDuel.Finish(winner);                    
                    arena_is_free = true;
                }
            }
        }

        /* Code */

        void SavePluginData()
        {
            Interface.GetMod().DataFileSystem.WriteObject("SAutoDuel", pluginData);
        }   

        [ChatCommand("duel")]
        void cmdDuel(NetUser netUser, string command, string[] args)
        {
            string text = $"Command [{netUser.displayName}:{netUser.userID}] /" + command;
            foreach (string s in args) text += " " + s;
            Helper.LogChat(text, true);            

            if (args.Length == 0)
            {
                foreach (string msg in helpMsg)
                {
                    rust.SendChatMessage(netUser, chatName, msg);
                }

                if (netUser.CanAdmin())
                {
                    foreach (string msg in adminMsg)
                    {
                        rust.SendChatMessage(netUser, chatName, msg);
                    }
                }
                return;
            }

            switch (args[0])
            {
                case "info":
                    cmdInfo(netUser, args);
                    return;
                case "go":
                    cmdGoDuel(netUser, args);
                    return;
                case "accept":
                    cmdAcceptDuel(netUser, args);
                    return;
                case "deny":
                    cmdDenyDuel(netUser, args);
                    return;
                case "point":
                    cmdPoint(netUser, args);
                    return;
            }

            rust.SendChatMessage(netUser, chatName, messages["bad_params"]);
        }

        /* function /duel info */
        void cmdInfo(NetUser netUser, string[] args)
        {
            foreach (string msg in infoMsg)
            {
                rust.SendChatMessage(netUser, chatName, msg);
            }
        }

        /* function /duel go <nick> <amount> */
        void cmdGoDuel(NetUser netUser, string[] args)
        {
            if (args.Length != 3)
            {
                rust.SendChatMessage(netUser, chatName, messages["bad_params"]);
                return;
            }

            if (!arena_is_free)
            {
                rust.SendChatMessage(netUser, chatName, messages["arena_unaviable"]);
                return;
            }

            if (TDuel.isAnyMember(netUser, true))
            {
                rust.SendChatMessage(netUser, chatName, messages["already_member"]);
                return;
            }

            /* Проверка соперника */

            PlayerClient targetClient = Helper.GetPlayerClient(args[1]);
            if (targetClient == null)
            {
                rust.SendChatMessage(netUser, chatName, messages["player_not_found"]);
                return;
            }

            if (targetClient.netUser == netUser)
            {
                rust.SendChatMessage(netUser, chatName, messages["request_himself"]);
                return;
            }

            if (TDuel.getByMembers(netUser, targetClient.netUser) != null)
            {
                rust.SendChatMessage(netUser, chatName, messages["already_duel"]);
                return;
            }

            if (TDuel.isAnyMember(targetClient.netUser, true))
            {
                rust.SendChatMessage(netUser, chatName, messages["target_already"]);
                return;
            }

            /* Проверка баланса */
            ulong amount = 1000;
            try
            {
                amount = ulong.Parse(args[2]);
            }
            catch
            {
                rust.SendChatMessage(netUser, chatName, messages["numbers_only"]);
                return;
            }

            if (amount < minDuelAmount)
            {
                rust.SendChatMessage(netUser, chatName, string.Format(messages["bad_amount"], minDuelAmount));
                return;
            }

            ulong balance = Economy.GetBalance(netUser.userID);
            if (balance < amount)
            {
                rust.SendChatMessage(netUser, chatName, string.Format(messages["not_enough_money"], balance));
                return;
            }

            /* Инициализация */

            TDuel duel = new TDuel { amount = amount, initiator = netUser, target = targetClient.netUser, accepted = false, finished = false };
            duels.Add(duel);

            rust.SendChatMessage(netUser, chatName, string.Format(messages["request_sended"], targetClient.netUser.displayName, amount));
            rust.SendChatMessage(targetClient.netUser, chatName, string.Format(messages["request_getted_1"], netUser.displayName, amount, timeForPrepare));
			rust.SendChatMessage(targetClient.netUser, chatName, string.Format(messages["request_getted_2"]));

            timer.Once(timeForAnswer, () =>
            {
                if (duel != null && duel.accepted == false)
                {
                    if (netUser != null && targetClient.netUser != null && targetClient.netUser.playerClient != null)
                    {
                        rust.SendChatMessage(netUser, chatName, string.Format(messages["target_timeout"], targetClient.netUser.displayName));
                        rust.SendChatMessage(targetClient.netUser, chatName, string.Format(messages["player_timeout"], netUser.displayName));
                    }
                    duels.Remove(duel);
                }
            });
        }

        /* function /duel accept <nick> */
        void cmdAcceptDuel(NetUser netUser, string[] args)
        {
            if (args.Length != 2)
            {
                rust.SendChatMessage(netUser, chatName, messages["bad_params"]);
                return;
            }

            if (!arena_is_free)
            {
                rust.SendChatMessage(netUser, chatName, messages["arena_unaviable"]);
                return;
            }

            if (TDuel.isAnyMember(netUser, true))
            {
                rust.SendChatMessage(netUser, chatName, messages["already_member"]);
                return;
            }

            /* Проверка соперника */
            PlayerClient targetClient = Helper.GetPlayerClient(args[1]);
            if (targetClient == null)
            {
                rust.SendChatMessage(netUser, chatName, messages["player_not_found"]);
                return;
            }

            if (TDuel.isAnyMember(targetClient.netUser, true))
            {
                rust.SendChatMessage(netUser, chatName, messages["target_already"]);
                return;
            }

            /* Получаем дуэль */
            TDuel duel = TDuel.getByMembers(netUser, targetClient.netUser);
            if (duel == null)
            {
                rust.SendChatMessage(netUser, chatName, messages["request_not_found"]);
                return;
            }          

            rust.SendChatMessage(netUser, chatName, string.Format(messages["accept_success"], timeForPrepare));
            rust.SendChatMessage(targetClient.netUser, chatName, string.Format(messages["target_accepted"], netUser.displayName, timeForPrepare));

            /* Принимаем дуэль */
            duel.accepted = true;

            /* Функция старта дуэли */
            timer.Once(timeForPrepare, () => {
                startDuel(duel);
            });
        }

        /* function /duel deny <nick> */
        void cmdDenyDuel(NetUser netUser, string[] args)
        {
            if (args.Length != 2)
            {
                rust.SendChatMessage(netUser, chatName, messages["bad_params"]);
                return;
            }

            /* Проверка соперника */
            PlayerClient targetClient = Helper.GetPlayerClient(args[1]);
            if (targetClient == null)
            {
                rust.SendChatMessage(netUser, chatName, messages["player_not_found"]);
                return;
            }

            /* Получаем дуэль */
            TDuel duel = TDuel.getByMembers(netUser, targetClient.netUser);
            if (duel == null)
            {
                rust.SendChatMessage(netUser, chatName, messages["request_not_found"]);
                return;
            }

            if (duel.accepted)
            {
                rust.SendChatMessage(netUser, chatName, messages["cant_deny_duel"]);
                return;
            }

            rust.SendChatMessage(netUser, chatName, string.Format(messages["deny_success"], targetClient.netUser.displayName));
            rust.SendChatMessage(targetClient.netUser, chatName, string.Format(messages["target_deny"], netUser.displayName));

            duels.Remove(duel);
        }

        /* function /duel point <1 | 2> */
        void cmdPoint(NetUser netUser, string[] args)
        {
            if (args.Length != 2 || !netUser.CanAdmin())
            {
                rust.SendChatMessage(netUser, chatName, messages["bad_params"]);
                return;
            }

            Character character; Character.FindByUser(netUser.userID, out character);

            if (args[1] == "1")
            {
                pluginData.duelData.spawnPoint1 = character.transform.position.ToString();                
                rust.SendChatMessage(netUser, chatName, string.Format(messages["duel_point_placed"], 1, pluginData.duelData.spawnPoint1));
                SavePluginData();
            }
            else if (args[1] == "2")
            {
                pluginData.duelData.spawnPoint2 = character.transform.position.ToString();
                rust.SendChatMessage(netUser, chatName, string.Format(messages["duel_point_placed"], 2, pluginData.duelData.spawnPoint2));
                SavePluginData();
            }
            else
            { 
                rust.SendChatMessage(netUser, chatName, messages["bad_params"]);
                return;
            }
        }

        void startDuel(TDuel duel)
        {
            if (!arena_is_free)
            {                
                rust.SendChatMessage(duel.target, chatName, messages["arena_unaviable"]);
                duels.Remove(duel);
                return;
            }

            if (duel.initiator == null)
            {
                rust.SendChatMessage(duel.target, chatName, messages["target_leave"]);
                duels.Remove(duel);
                return;
            }

            if (duel.target == null)
            {
                rust.SendChatMessage(duel.initiator, chatName, messages["target_leave"]);
                duels.Remove(duel);
                return;
            }

            ulong amount = duel.amount;
            if (Economy.GetBalance(duel.initiator.userID) < amount)
            {
                rust.SendChatMessage(duel.target, chatName, string.Format(messages["target_cancelled"], duel.initiator.displayName));
                rust.SendChatMessage(duel.initiator, chatName, string.Format(messages["not_enough_money"], Economy.GetBalance(duel.initiator.userID)));
                duels.Remove(duel);
                return;
            }

            if (Economy.GetBalance(duel.target.userID) < amount)
            {
                rust.SendChatMessage(duel.initiator, chatName, string.Format(messages["target_cancelled"], duel.target.displayName));
                rust.SendChatMessage(duel.target, chatName, string.Format(messages["not_enough_money"], Economy.GetBalance(duel.target.userID)));
                duels.Remove(duel);
                return;
            }

            Economy.BalanceSub(duel.initiator.userID, amount);
            Economy.BalanceSub(duel.target.userID, amount);

            arena_is_free = false;

            ClearInventory(duel.initiator);
            ClearInventory(duel.target);

            management.TeleportPlayerToWorld(duel.initiator.networkPlayer, ParseVector3(pluginData.duelData.spawnPoint1));
            management.TeleportPlayerToWorld(duel.target.networkPlayer, ParseVector3(pluginData.duelData.spawnPoint2));

            EquipForDuel(duel.target);
            EquipForDuel(duel.initiator);

            rust.SendChatMessage(duel.initiator, chatName, string.Format(messages["duel_started"], duel.target.displayName, timeForDuel));
            rust.SendChatMessage(duel.target, chatName, string.Format(messages["duel_started"], duel.initiator.displayName, timeForDuel));

            for (int i = timeForDuel / 10; i > 0; i--)
            {
                int t = i * 10;
                timer.Once(t, () =>
                {
                    if (!duel.finished)
                    {
                        if (duel.initiator != null)
                            rust.SendChatMessage(duel.initiator, chatName, string.Format(messages["duel_countdown"], timeForDuel - t));

                        if (duel.target != null)
                            rust.SendChatMessage(duel.target, chatName, string.Format(messages["duel_countdown"], timeForDuel - t));
                    }
                });
            }

            timer.Once(timeForDuel, () => {
                if (duel != null && !duel.finished)
                {
                    if (duel.initiator == null)
                    {
                        if (duel.target != null)
                        {
                            // UPD (25.01.2019): Внутри Finish вызывается duels.Remove(this)
                            duel.Finish(duel.target);                                                        
                        }
                        // UPD (25.01.2019): Но в случае выхода обоих игроков с сервера duels.Remove наверное не вызовется? Проверь как-нибудь)                                                
                        // UDP (04.07.2019): Вроде пофиксил, добавил этот ELSE
                        else
                        {
                            duel.Finish(null);
                        }

                        arena_is_free = true;
                    }
					else if (duel.target == null)
                    {
                        duel.Finish(duel.initiator);
                        arena_is_free = true;
                    }
					else
					{
						Character character1; Character.FindByUser(duel.initiator.userID, out character1);
						Character character2; Character.FindByUser(duel.target.userID, out character2);

                        if (character1 != null && character2 != null)
                        {
                            if (character1.health > character2.health)
                            {
                                duel.Finish(duel.initiator);
                            }
                            else if (character1.health < character2.health)
                            {
                                duel.Finish(duel.target);
                            }
                            else if (character1.health == character2.health)
                            {
                                int random = UnityEngine.Random.Range(1, 3);
                                if (random == 1)
                                {
                                    duel.Finish(duel.initiator);
                                }
                                else
                                {
                                    duel.Finish(duel.target);
                                }
                            }
                        }
						arena_is_free = true;
					}
                }
            });
        }

        static void ClearInventory(NetUser netUser)
        {
            if (netUser != null && netUser.playerClient != null && netUser.playerClient.rootControllable != null && netUser.playerClient.rootControllable.idMain != null)
            {
                netUser.playerClient.rootControllable.idMain.GetComponent<Inventory>().Clear();
            }
        }

        static void EquipForDuel(NetUser netUser)
        {
            var inv = netUser.playerClient.controllable.controller.character.GetComponent<PlayerInventory>();
            foreach (object[] arr in equipment)
            {
                if (arr == null || arr.Length != 3) continue;
                ItemDataBlock item = DatablockDictionary.GetByName((string)arr[1]);
                Inventory.Slot.Preference slot = Inventory.Slot.Preference.Define((Inventory.Slot.Kind)arr[0]);
                Helper.GiveItem(inv, item, slot, (int)arr[2], -1);
            }
        }

        Vector3 ParseVector3(string text)
        {
            string split = ",";
            if (text.Contains(split))
            {
                Vector3 vector = Vector3.zero;
                string[] cords = text.Replace(" ", "").Replace("(", "").Replace(")", "").Split(new char[] { ',' });
                if (cords.Length >= 3)
                {
                    vector.x = float.Parse(cords[0]);
                    vector.y = float.Parse(cords[1]);
                    vector.z = float.Parse(cords[2]);
                }
                return vector;
            }
            return Vector3.zero;
        }
    }
}