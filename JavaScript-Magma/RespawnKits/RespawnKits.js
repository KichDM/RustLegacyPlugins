/*@name RespawnKits
@author Henrique Seifarth Lovato
@server BRRUST
@date 17/03/2014
@version 1.0
@from Brazil
*/

function On_ServerInit() {
    Plugin.CreateTimer("AutoUpdate", 1000).Start();
}

function On_PlayerConnected(Player) {
    Data.AddTableValue("DeathPosX", Player.SteamID, 0);
    Data.AddTableValue("DeathPosY", Player.SteamID, 0);
    Data.AddTableValue("DeathPosZ", Player.SteamID, 0);
}

function On_PlayerKilled(DeathEvent) {
    Data.AddTableValue("DeathPosX", DeathEvent.Victim.SteamID, DeathEvent.Victim.X);
    Data.AddTableValue("DeathPosY", DeathEvent.Victim.SteamID, DeathEvent.Victim.Y);
    Data.AddTableValue("DeathPosZ", DeathEvent.Victim.SteamID, DeathEvent.Victim.Z);
}

function On_Command(Player, cmd, args) {
    switch (cmd) {
        case "resetrespawnkits":
            Plugin.CreateTimer("AutoUpdate", 1000).Start();
            break;
    }
}

function AutoUpdateCallback() {
    for (var Player in Server.Players) {
        var DeathPosX = Data.GetTableValue("DeathPosX", Player.SteamID);
        var DeathPosY = Data.GetTableValue("DeathPosY", Player.SteamID);
        var DeathPosZ = Data.GetTableValue("DeathPosZ", Player.SteamID);
        if (DeathPosX != 0 || DeathPosY != 0 || DeathPosZ != 0) {
            if (Player.X != DeathPosX || Player.Y != DeathPosY || Player.Z != DeathPosZ) {
                Data.AddTableValue("DeathPosX", Player.SteamID, 0);
                Data.AddTableValue("DeathPosY", Player.SteamID, 0);
                Data.AddTableValue("DeathPosZ", Player.SteamID, 0);
                OnPlayerSpawn(Player);
            }
        }
    }
}

function OnPlayerSpawn(Player) {
    if (Data.GetConfigValue("RespawnKits", "config", "showrespawn") == "true") {
        Player.Message(Data.GetConfigValue("RespawnKits", "config", "respawn"));
    }

    var itens = getItens();
    var count = 0;
    while (itens['item_name' + count] != null || itens['item_name' + count] != undefined) {
        Player.Inventory.AddItem(itens['item_name' + count], itens['item_amount' + count]);
        count++
    }
}

function getItens() {
    var items = [];
    var countItem = 0;
    while (Data.GetConfigValue("RespawnKits", "kit", "item_name" + countItem) != null) {
        items['item_name' + countItem] = Data.GetConfigValue("RespawnKits", "kit", "item_name" + countItem);
        items['item_amount' + countItem] = Data.GetConfigValue("RespawnKits", "kit", "item_amount" + countItem);
        countItem++;
    }
    return items;
}