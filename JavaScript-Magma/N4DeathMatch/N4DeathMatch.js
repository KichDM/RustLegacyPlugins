//Title: N4 Death Match
//Developer: Razztak
//Version: 0.4.2
//Description:Advanced Death Match Plugin
//Based on 4rk0ur (Krypton .Int (steam name) Death Match Plugin. 
//Special thanks to MidnightFS(Mike) for helping a lot with corrections/debugging.
function On_PluginInit() {
    try {
        if (!Plugin.IniExists("N4DM_config")) {
            Plugin.CreateIni("N4DM_config");
            var N4cfg = Plugin.GetIni("N4DM_config");
            N4cfg.AddSetting("Settings", "Status", false);
            N4cfg.AddSetting("Settings", "SpawnCount", 0);
            N4cfg.AddSetting("Settings", "SpawnheightCorrection", 5);
            N4cfg.Save();
        } else { //Temporary automatic update for Spawn-Height-Correction
            var N4cfg = Plugin.GetIni("N4DM_config");
            var shCoor = N4cfg.GetSetting("Settings", "SpawnheightCorrection");
            if (!shCoor) {
                N4cfg.AddSetting("Settings", "SpawnheightCorrection", 5);
                N4cfg.Save();
            }
        }
        if (!Plugin.IniExists("N4DM_score")) {
            Plugin.CreateIni("N4DM_score");
        }
        if (!Plugin.IniExists("N4DM_Players")) {
            Plugin.CreateIni("N4DM_Players");
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM On_PluginInit");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM On_PluginInit");
    }
}

function On_Command(Player, cmd, args) {
    try {
        if (cmd == "dm") {
            //***** HElP *******//
            if (args[0] == null || args[0] == "help") {
                Player.MessageFrom("[DeathMatch]", "--------- Rust Project - DeathMatch - Команды --------");
                Player.MessageFrom("[DeathMatch]", "-dm join - Подключиться к Арене");
                Player.MessageFrom("[DeathMatch]", "-dm leave - Выйти с Арены");
                Player.MessageFrom("[DeathMatch]", "-dm rank - Показать Топ 10 Игроков Арены");
                Player.MessageFrom("[DeathMatch]", "-dm reward - Показать список наград");
                Player.MessageFrom("[DeathMatch]", "-dm reward `имя приза` - Получить награду (РеГисТРоЗавИсИмО!");
                Player.MessageFrom("[DeathMatch]", "-dm score - Показать Ваши очки");
                Player.MessageFrom("[DeathMatch]", "--------- Translate and Modify by DevelopeR --------");
                if (Player.Admin) {
                    Player.MessageFrom("[DeathMatch]", "------ Rust Project - DeathMatch - Админ Команды -----");
                    Player.MessageFrom("[DeathMatch]", "-dm setspawn - Новая точка спауна");
                    Player.MessageFrom("[DeathMatch]", "-dm setspawn IDточки - изменить существующую точку спауна");
                    Player.MessageFrom("[DeathMatch]", "-dm toggle - Вкл/Выкл Арену");
                }
            }
            //***** End HElP *******//
            //***** Join Command *****//
            if (args[0] == "join") {
                var N4cfg = Plugin.GetIni("N4DM_config");
                var Status = N4cfg.GetSetting("Settings", "Status");
                if (Status == "False") {
                    Player.MessageFrom("[DeathMatch]", "[COLOR#FF0000]Сейчас Арена выключена!");
                } else if (Status == "True") {
                    JoinDM(Player);
                }
            }
            //***** End Join Command *****//
            //***** Start Leave Command *****//
            if (args[0] == "leave") {
                LeaveDM(Player);
            }
            //***** End Leave Command *****//

            if (args[0] == "score") {
                DMScore(Player);
            }

            //***** Start Toggle Command *****//
            if (args[0] == "toggle")
            {
				if(Player.Admin){
					var N4cfg = Plugin.GetIni("N4DM_config");
					var Status = N4cfg.GetSetting("Settings", "Status");
					if (Status == "True") {
						N4cfg.SetSetting("Settings", "Status", false);
						Player.Notice("Арена выключена!");
						N4cfg.Save();
					} else {
						N4cfg.SetSetting("Settings", "Status", true);
						Player.Notice("Арена включена!");
						N4cfg.Save();
					}
				}
                else
					Player.Notice("У Вас нет прав для этой команды!");
                
            }
            //***** End Toggle Command *****//
            //***** Start Set Spawn Command *****//
            if ((args[0] == "setspawn") && (Player.Admin)) {
                if (args.Length == 1) {
                    SetSpawn(Player, 0);
                } else {
                    if (isNaN(args[1])) {
                        Player.MessageFrom("[DeathMatch]", "Синтаксис: -dm setspawn <номер> напр. -dm setspawn 2");
                        Player.MessageFrom("[DeathMatch]", "Чтобы добавить новую точку: -dm setspawn");
                    } else {
                        SetSpawn(Player, args[1]);
                    }
                }
            }
            //***** End Set Spawn Command *****//
            //***** Start Delete Spawn Command *****//
            if (args[0] == "delspawn" && Player.Admin) { //Delete last spawn point
                var SpawnsINI = Plugin.GetIni("N4DM_config");
                var CountS = SpawnsINI.EnumSection("Spawns");
                if (CountS == 0) {
                    Player.MessageFrom("[DeathMatch]", "Нет точек для удаления.");
                    return;
                }
                SpawnsINI.DeleteSetting("Spawns", "Spawn" + (CountS + 1));
                //SpawnsINI.SetSetting("Settings", "Spawn" + (parseInt(CountS) - 1));
                SpawnsINI.Save();
                Player.MessageFrom("[DeathMatch]", "Вы удалили свою последнюю точку, всего точек " + (parseInt(CountS) - 1) + ".");
            }
            //***** End Delete Spawn Command *****//
            //***** Start Ranking Command *****//
            if (args[0] == "rank") {
                Ranking(Player);
            }
            //***** End Ranking Command *****//
            //***** Start Reward Command *****//
            if (args[0] == "reward") {
                if (args.Length == 1) {
                    Reward(Player, 0);
                } else if (args.Length == 2) {
                    Reward(Player, args[1]);
                }
            }
            //***** End Reward Command *****//
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM On_Command");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM On_Command");
    }
}

function On_PlayerSpawning(Player, se) {
    try {
        var PlayerINI = Plugin.GetIni("N4DM_Players");
        var DMPlayers = PlayerINI.GetSetting(Player.SteamID, "InDM");
        var N4cfg = Plugin.GetIni("N4DM_config");
        var DMStatus = N4cfg.GetSetting("Settings", "Status");
        if (!DMPlayers) {
            return;
        }

        if ((!se.CampUsed) && (DMStatus == "True")) {
            if (DMPlayers == "True") {
                var SpawnsINI = Plugin.GetIni("N4DM_config");
                var CountS = SpawnsINI.GetSetting("Settings", "SpawnCount");
                var SpawnN = getRandomInt(1, CountS)
                var SpawnP = SpawnsINI.GetSetting("Spawns", "Spawn" + SpawnN);
                var SpawnPA = SpawnP.split(",");
                se.X = SpawnPA[0];
                se.Y = SpawnPA[1];
                se.Z = SpawnPA[2];
            }
        } else if (DMStatus == "False") {
            var DMPLastKP = PlayerINI.GetSetting(Player.SteamID, "LastKnowPos");
            var DMPLastKPA = DMPLastKP.split(",");
            se.X = DMPLastKPA[0];
            se.Y = DMPLastKPA[1];
            se.Z = DMPLastKPA[2];
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM On_PlayerSpawning");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM On_PlayerSpawning");
    }
}

function On_PlayerSpawned(Player, se) {
    try {
        var PlayerINI = Plugin.GetIni("N4DM_Players");
        var DMPlayers = PlayerINI.GetSetting(Player.SteamID, "InDM");
        if (!DMPlayers) {
            return;
        }
        var N4cfg = Plugin.GetIni("N4DM_config");
        var DMStatus = N4cfg.GetSetting("Settings", "Status");
        if (DMStatus == "False" && DMPlayers == "True") {
            LeaveDM(Player);
            return;
        }
        if (se.CampUsed) {
            LeaveDM(Player);
        } else {
            if (DMPlayers == "True") {
                Player.Inventory.ClearAll();
                GiveKit(Player);
            }
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM On_PlayerSpawned");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM On_PlayerSpawned");
    }
}

function On_PlayerKilled(DeathEvent) {
    try {
        var N4DMpl = Plugin.GetIni("N4DM_Players");
        var InDM = N4DMpl.GetSetting(DeathEvent.Attacker.SteamID, "InDM");
        if (InDM == "True") {
            DeathEvent.DropItems = false;
            if (DeathEvent.Attacker.SteamID != undefined) {
                ScoreBoard(DeathEvent.Attacker, DeathEvent.Victim);
            }
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM On_PlayerKilled");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM On_PlayerKilled");
    }
}

function JoinDM(Player) {
    try {
        var PlayerINI = Plugin.GetIni("N4DM_Players");
        var DMPlayers = PlayerINI.GetSetting(Player.SteamID, "InDM");
        if (!DMPlayers) {
            PlayerINI.AddSetting(Player.SteamID, "InDM", false);
            PlayerINI.AddSetting(Player.SteamID, "Name", Player.Name);
            PlayerINI.AddSetting(Player.SteamID, "SpendPoints", 0);
            PlayerINI.Save();
            DMPlayers = PlayerINI.GetSetting(Player.SteamID, "InDM");
        }
        var SpawnsINI = Plugin.GetIni("N4DM_config");
        var chkSpawn = SpawnsINI.GetSetting("Settings", "SpawnCount");
        if (chkSpawn == 0) {
            Player.MessageFrom("[DeathMatch]", "Точки спауна не заданы! Пожалуйста, сообщите об этом Администратору.");
            Player.Notice("Точки спауна не заданы! Пожалуйста, сообщите об этом Администратору.");
            return;
        }
        //If player is not in Death Match, add player.
        if (DMPlayers == "False") {
            PlayerINI.AddSetting(Player.SteamID, "LastKnowPos", Player.X + "," + Player.Y + "," + Player.Z);
            PlayerINI.Save();
            SavePlayerInv(Player);
            PlayerINI.SetSetting(Player.SteamID, "InDM", true);
            PlayerINI.SetSetting(Player.SteamID, "Name", Player.Name);
            PlayerINI.Save();
            GiveKit(Player);
            var CountS = SpawnsINI.GetSetting("Settings", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Spawns", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            Player.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Server.BroadcastFrom("[DeathMatch]", "[COLOR#ff0000]" + Player.Name + " подключился к Арене!");
        } else if (DMPlayers == "True") {
            Player.MessageFrom("[DeathMatch]", "Вы уже вошли на Арену. напишите -dm leave если хотите выйти.");
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM JoinDM");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM JoinDM");
    }
}

function LeaveDM(Player) {
    try {
        var PlayerINI = Plugin.GetIni("N4DM_Players");
        var DMPlayers = PlayerINI.GetSetting(Player.SteamID, "InDM");
        if (!DMPlayers) {
            PlayerINI.AddSetting(Player.SteamID, "InDM", false);
            PlayerINI.Save();
        }
        if (DMPlayers == "True") {
            Player.Inventory.ClearAll();
            var DMPLastKP = PlayerINI.GetSetting(Player.SteamID, "LastKnowPos");
            var DMPLastKPA = DMPLastKP.split(",");
            Player.TeleportTo(DMPLastKPA[0], DMPLastKPA[1], DMPLastKPA[2]);
            LoadPlayerInv(Player);
            PlayerINI.SetSetting(Player.SteamID, "InDM", false);
            PlayerINI.DeleteSetting(Player.SteamID, "LastKnowPos");
            PlayerINI.Save();
            Player.MessageFrom("[DeathMatch]", "Вы вышли с Арены");
            Server.BroadcastFrom("[DeathMatch]", "[COLOR#ff0000]" + Player.Name + " вышел с Арены!");
        } else if (DMPlayers == "False") {
            //Player.MessageFrom("[DeathMatch]", "Сейчас Вы не на Арене!");
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM JoinDM");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM JoinDM");
    }
}

function SavePlayerInv(PtoSave) {
    try {
        if (Plugin.IniExists("PI" + PtoSave.SteamID)) {
            Plugin.DeleteLog("PI" + PtoSave.SteamID);
            Plugin.CreateIni("PI" + PtoSave.SteamID);
        } else {
            Plugin.CreateIni("PI" + PtoSave.SteamID);
        }

        var IniPInv = Plugin.GetIni("PI" + PtoSave.SteamID);
        //var PItem = PtoSave.PlayerItem;
        var i = 0;
        //Saving Internal Items
        for (PItem in PtoSave.Inventory.Items) {
            if (PItem.Name != null) {
                i++
                IniPInv.AddSetting(PtoSave.SteamID, "ItemName" + i, PItem.Name);
                IniPInv.AddSetting(PtoSave.SteamID, "ItemSlot" + i, PItem.Slot);
                IniPInv.AddSetting(PtoSave.SteamID, "ItemQty" + i, PItem.Quantity);
            }
        }
        //Saving BarItems
        for (PItem in PtoSave.Inventory.BarItems) {
            if (PItem.Name != null) {
                i++
                IniPInv.AddSetting(PtoSave.SteamID, "ItemName" + i, PItem.Name);
                IniPInv.AddSetting(PtoSave.SteamID, "ItemSlot" + i, PItem.Slot);
                IniPInv.AddSetting(PtoSave.SteamID, "ItemQty" + i, PItem.Quantity);
            }
        }
        //Saving Armor Items
        for (PItem in PtoSave.Inventory.ArmorItems) {
            if (PItem.Name != null) {
                i++
                IniPInv.AddSetting(PtoSave.SteamID, "ItemName" + i, PItem.Name);
                IniPInv.AddSetting(PtoSave.SteamID, "ItemSlot" + i, PItem.Slot);
                IniPInv.AddSetting(PtoSave.SteamID, "ItemQty" + i, PItem.Quantity);
            }
        }
        IniPInv.AddSetting(PtoSave.SteamID, "Count", i);
        IniPInv.Save();
        PtoSave.Inventory.ClearAll(); // Clear Inventory
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM SavePlayerInv");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM SavePlayerInv");
    }
}

function LoadPlayerInv(PtoLoad) {
    try {
        var IniPInv = Plugin.GetIni("PI" + PtoLoad.SteamID);
        if (!IniPInv) {
            Plugin.Log("DeathMatch", "For some reason the file PI" + PtoLoad.SteamID + " does not exist");
            return;
        }
        var countP = IniPInv.GetSetting(PtoLoad.SteamID, "Count");
        if (!countP) {
            Plugin.Log("DeathMatch", "Player: " + PtoLoad.Name + " for some reason Death Match cant determine number of Items for this Player");
            return;
        }

        for (var i = 1; i <= countP; i++) {
            var ItemName = IniPInv.GetSetting(PtoLoad.SteamID, "ItemName" + i);
            var ItemSlot = IniPInv.GetSetting(PtoLoad.SteamID, "ItemSlot" + i);
            var ItemQty = IniPInv.GetSetting(PtoLoad.SteamID, "ItemQty" + i);
            if ((!ItemName) || (!ItemSlot) || (!ItemQty)) {
                Plugin.Log("DeathMatch", "Player: " + PtoLoad.Name + " for some reason Death Match cant determine a Item property for Item " + i + " Check file: PI" + PtoLoad.SteamID + ".ini");
                break;
            }
            PtoLoad.Inventory.AddItemTo(ItemName, ItemSlot, ItemQty);
        }
        Plugin.DeleteLog("PI" + PtoLoad.SteamID);
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM LoadPlayerInv");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM LoadPlayerInv");
    }
}

function GiveKit(Player) {
    try {
        var LoadOutsINI = Plugin.GetIni("N4DM_loadouts");
        var KitR = getRandomInt(1, 4);
        //add Weapon Kit
        for (var i = 1; i < 5; i++) {
            var KitItem = LoadOutsINI.GetSetting(KitR, "Item" + i);
            var KitSlot = LoadOutsINI.GetSetting(KitR, "Slot" + i);
            var KitQty = LoadOutsINI.GetSetting(KitR, "Qty" + i);
            Player.Inventory.AddItemTo(KitItem, KitSlot, KitQty);
        }
        //add Armor Set
        for (var i = 1; i < 5; i++) {
            var KitItem = LoadOutsINI.GetSetting("Armor", "Item" + i);
            var KitSlot = LoadOutsINI.GetSetting("Armor", "Slot" + i);
            var KitQty = LoadOutsINI.GetSetting("Armor", "Qty" + i);
            Player.Inventory.AddItemTo(KitItem, KitSlot, KitQty);
        }
        //Add Food & Medkit & Other
        for (var i = 1; i < 4; i++) {
            var KitItem = LoadOutsINI.GetSetting("Consumables", "Item" + i);
            var KitSlot = LoadOutsINI.GetSetting("Consumables", "Slot" + i);
            var KitQty = LoadOutsINI.GetSetting("Consumables", "Qty" + i);
            Player.Inventory.AddItemTo(KitItem, KitSlot, KitQty);
        }
        //Add Weapon Mods
        for (var i = 1; i < 5; i++) {
            var KitItem = LoadOutsINI.GetSetting("Mods", "Item" + i);
            var KitSlot = LoadOutsINI.GetSetting("Mods", "Slot" + i);
            var KitQty = LoadOutsINI.GetSetting("Mods", "Qty" + i);
            Player.Inventory.AddItemTo(KitItem, KitSlot, KitQty);
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM GiveKit");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM GiveKit");
    }
}

function SetSpawn(Player, SpawnNumber) {
    try {
        var SpawnsINI = Plugin.GetIni("N4DM_config");
        var CountS = SpawnsINI.GetSetting("Settings", "SpawnCount");
        var shCorr = SpawnsINI.GetSetting("Settings", "SpawnheightCorrection");
        Player.MessageFrom("[DeathMatch]", "У Вас " + parseInt(CountS) + " точек спауна и добавлена еще 1");
        if (SpawnNumber == 0) {
            SpawnNumber = (parseInt(CountS) + 1);
            SpawnsINI.AddSetting("Spawns", "Spawn" + SpawnNumber, Player.X + ", " + (Player.Y + parseInt(shCorr)) + ", " + Player.Z);
            SpawnsINI.SetSetting("Settings", "SpawnCount", (parseInt(CountS) + 1));
            SpawnsINI.Save();
            var Coor = Player.X + ", " + Player.Y + ", " + Player.Z;
            Player.MessageFrom("[DeathMatch]", "Вы добавили точку спауна. Номер: " + SpawnNumber + " @ Координаты " + Coor);
        } else {
            if (SpawnNumber > CountS) { //Check for existing Spawn Point
                Player.MessageFrom("[DeathMatch]", "Точки с таким номером не существует. Сейчас у Вас " + parseInt(CountS) + " Точек.");
                return;
            }
            SpawnsINI.SetSetting("Spawns", "Spawn" + SpawnNumber, Player.X + ", " + (Player.Y + parseInt(shCorr)) + ", " + Player.Z);
            SpawnsINI.Save();
            Player.MessageFrom("[DeathMatch]", "Вы изменили точку спауна Номер: " + SpawnNumber + " @ Координаты " + Player.X + ", " + Player.Y + ", " + Player.Z);
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM SetSpawn");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM SetSpawn");
    }
}

function ScoreBoard(Attacker, Victim) {
    try {
        var N4DMsc = Plugin.GetIni("N4DM_score");
        var N4DMpl = Plugin.GetIni("N4DM_Players");
        var InDM = N4DMpl.GetSetting(Attacker.SteamID, "InDM");
        if (Attacker.SteamID != Victim.SteamID) {
            var score = N4DMsc.GetSetting("Scores", Attacker.SteamID);
            if (score == undefined) {
                N4DMsc.AddSetting("Scores", Attacker.SteamID, 1);
                N4DMsc.Save();
                score = 1;
            } else {
                N4DMsc.SetSetting("Scores", Attacker.SteamID, (parseInt(score) + 1));
                N4DMsc.Save();
                score = (parseInt(score) + 1);
            }
            Server.BroadcastFrom("[DeathMatch]", "[ " + (score) + "  Очков ] " + Attacker.Name + " ► " + Victim.Name);
        }
        if (Attacker.SteamID == Victim.SteamID) {
            var score = N4DMsc.GetSetting("Scores", Attacker.SteamID);
            if (score == undefined) {
                N4DMsc.AddSetting("Scores", Attacker.SteamID, -5);
                N4DMsc.Save();
                score = -5
            } else {
                N4DMsc.SetSetting("Scores", Attacker.SteamID, (parseInt(score) - 5));
                N4DMsc.Save();
                score = (parseInt(score) - 5)
            }
            Server.BroadcastFrom("[DeathMatch]", "[ " + Attacker.Name + " Совершил самоубийство и потерял 5 очков. Сейчас у него " + (parseInt(score)) + " Очков ] ");
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM ScoreBoard");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM ScoreBoard");
    }
}

function Ranking(Player) {
    try {
        var N4DMsc = Plugin.GetIni("N4DM_score");
        Player.MessageFrom("[DeathMatch]", "--- Death Match Ranking ---");
        Player.MessageFrom("[DeathMatch]", "#   Убийств     Имя");
        var scoresA = [];
        var PlayerINI = Plugin.GetIni("N4DM_Players");
        Player.Message("OK A");
        for (var scores in N4DMsc.EnumSection("Scores")) {
            var nameP = PlayerINI.GetSetting(scores, "Name");
            var x = [nameP, parseInt(N4DMsc.GetSetting("Scores", scores))];
            scoresA.push(x);
        }
        Player.Message("OK B");
        scoresA.sort(function(a, b) {
            return a[1] - b[1];
        });
        Player.Message("OK C");
        scoresA.reverse();

        for (var i = 0; i < scoresA.length; i++) {
            if (scoresA[i][1] > 0) {
                var sName = scoresA[i][0];
                var xScore = (scoresA[i][1]).toString();
                xScore = (padding_left(xScore, 5));
                Player.MessageFrom("[DeathMatch]", "#" + (i + 1) + " | " + xScore + "   |   " + sName);
                if (i == 9) {
                    break;
                }
            }
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM Ranking");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM Ranking");
    }
}

function Reward(Player, Reward) {
    try {
        var PlayerINI = Plugin.GetIni("N4DM_Players");
        var N4DMsc = Plugin.GetIni("N4DM_score");
        var N4DMre = Plugin.GetIni("N4DM_Rewards");
        var DMPlayers = PlayerINI.GetSetting(Player.SteamID, "InDM");
        if (DMPlayers == "True") {
            Player.MessageFrom("[DeathMatch]", "Для получения наград необходимо выйти с Арены!");
            return;
        }
        //List Rewards
        if (Reward == 0) {
            Player.MessageFrom("[DeathMatch]", "------Доступные Награды--------");
            var i = 1;
            for (var r in N4DMre.EnumSection("RewardList")) {
                var re = N4DMre.GetSetting("RewardList", r);
                var reA = re.split(",");
                Player.MessageFrom("[DeathMatch]", i + "# - " + reA[0] + "  |  " + reA[1] + "  Pts");
                i++;
            }
        } else {
            //if have arguments find reward
            var chkRew = N4DMre.GetSetting(Reward, "Points");
            if (chkRew == undefined) {
                Player.MessageFrom("[DeathMatch]", "Этой награды нет в списке!");
                return;
            }
            //check scores and points
            var chkPts = N4DMsc.GetSetting("Scores", Player.SteamID);
            var spdPts = PlayerINI.GetSetting(Player.SteamID, "SpendPoints");
            var rewPts = N4DMre.GetSetting(Reward, "Points");
            if ((chkPts - spdPts) < rewPts) {
                Player.MessageFrom("[DeathMatch]", "У Вас только" + (chkPts - spdPts) + "очков, для получения награды Вам нужно " + rewPts + " очков");
                return;
            } else if ((chkPts - spdPts) >= rewPts) {
                for (var it in N4DMre.EnumSection(Reward)) {
                    if (it != "Points") {
                        var Item = N4DMre.GetSetting(Reward, it);
                        var ItemA = Item.split(",");
                        Player.Inventory.AddItem(ItemA[0], ItemA[1]);
                        Player.InventoryNotice(ItemA[1] + " x " + ItemA[0]);
                    }
                }
                var lpoints = (parseInt(chkPts) - (parseInt(spdPts) + parseInt(rewPts)));
                Player.MessageFrom("[DeathMatch]", "Вы получили свою награду! У Вас осталось " + lpoints + " очков.");
                PlayerINI.SetSetting(Player.SteamID, "SpendPoints", (parseInt(spdPts) + parseInt(rewPts)));
                PlayerINI.Save();
            }
        }
    } catch (err) {
        Plugin.Log("DeathMatch", "Exception Message: " + err.message + " on N4DM Reward");
        Plugin.Log("DeathMatch", "Exception Description: " + err.description + " on N4DM Reward");
    }
}

function DMScore(Player) {
    var N4DMsc = Plugin.GetIni("N4DM_score");
    var Score = N4DMsc.GetSetting("Scores", Player.SteamID);
    Player.MessageFrom("[DeathMatch]", "Сейчас Вы имеете " + Score + " Очков.");
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function padding_left(s, n) {
    var c = " ";
    if (!s || !c || s.length >= n) {
        return s;
    }

    var max = (n - s.length) / c.length;
    for (var i = 0; i < max; i++) {
        s = c + s;
    }

    return s;
}
