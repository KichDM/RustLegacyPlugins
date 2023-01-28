function iniset() {
    return Plugin.GetIni("Settings");
}

function On_PluginInit(){
    if (!Plugin.IniExists("Settings")) {
        var inifile = Plugin.CreateIni("Settings");

        inifile.AddSetting("Settings", "Cooldown", "900000");
        inifile.AddSetting("Settings", "Players", "15");
        inifile.Save();
    }
    var getinifile = iniset();
    var getcooldown = getinifile.GetSetting("Settings","Cooldown");
    Plugin.CreateTimer("GiveUsesTimer", getcooldown).Start();
}
function GiveUsesTimerCallback(){
    var i = 0;
    var getinifile = iniset();
    var getplayers = getinifile.GetSetting("Settings","Players");
    var getcooldown = getinifile.GetSetting("Settings","Cooldown");
    Server.Players.ForEach(
        function(player) {
            try{
                i++;
                
            } catch(ignore) { }
        }
    );
    if (i >= parseInt(getplayers))
    {
        Server.Broadcast("==========================");
        Server.Broadcast(" One Airdrop havs been randomly spawned on the map !");
        Server.Broadcast("==========================");
        World.Airdrop();
    }
    else
    {
        Server.Broadcast("There must be 15 players online for Airdrop.");
        Server.Broadcast("Every 15 minutes player count will be checked for airdrop.");
    }
       Plugin.KillTimer("GiveUsesTimer");
       Plugin.CreateTimer("GiveUsesTimer", getcooldown).Start();
}
function On_Command(Player, cmd, args) {
	if (cmd == "airdrop") {
		if (args.Length == 0)
        {
            Player.MessageFrom("[Airdrops]", "Usage : /airdrop here/random");
        }
        if (args.Length == 1)
        {
            if (args[0] == "here")
            {
                World.AirdropAtPlayer(Player);
                Player.Notice("klk", "Airdrop has been spawned!", 3);
            }
            if (args[0] == "random") {
                World.Airdrop();
                Player.Notice("klk", "Airdrop has been spawned!", 3);
            }
        }
	}
}