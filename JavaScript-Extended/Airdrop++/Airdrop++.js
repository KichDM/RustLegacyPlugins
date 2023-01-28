
function iniset() {
    return Plugin.GetIni("Settings");
}

function On_PluginInit(){
    if (!Plugin.IniExists("Settings")) {

    var inifile = Plugin.CreateIni("Settings");
        inifile.AddSetting("Settings", "Cooldown", "3600000");
        inifile.AddSetting("Settings", "Players", "8");
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
        Server.Broadcast("✈ Un Airdrop ha caido por el mapa ✈!");
        Server.Broadcast("==========================");
        Util.RunServerCommand("airdrop.drop")
		
    }
    else
    {
        Server.Broadcast("Debe haber 8 jugadores en línea para el Airdrop.");
        Server.Broadcast("Cada 2h se comprobará el recuento de jugadores para airdrop .");
		
    }
       Plugin.KillTimer("GiveUsesTimer");
       Plugin.CreateTimer("GiveUsesTimer", getcooldown).Start();
}


function On_Command(Player, cmd, args) {

	if (cmd == "air" && Player.Admin) {
		if (args.Length == 0)
        {
            Player.MessageFrom("[Airdrops]", "Usa : /airdrop aqui o random");
        }
        if (args.Length == 1)
        {
            if (args[0] == "aqui")
            {

                World.AirdropAtPlayer(Player);
                Player.MessageFrom("klk", "Un AirDrop a Spawneado!" + distance);
            }
            if (args[0] == "random") {

                World.Airdrop();
                Player.MessageFrom("klk", "Un AirDrop a Spawneado!" + distance);
                
            }
        }
	}

    if(cmd == "air")
    {
        
		if(Player.Admin == true)
		{
			if(args[0])
			{
				if(args[0] > 0 && args[0] <= 1800)
				{
					World.Airdrop(args[0]);
                    Player.Message("Airdrops totales  " + args[0] + "Lanzados");

				}
				else
				{
					Player.Message("Usa: /airdrop, y un número del 1 al 5");
					Player.Message("Por ejemplo: /airdrop 3 ");
				}
			}
		}
		else
		{
			Player.Message("No tienes acceso a este comando.");
		}
    }

    if(cmd == "airaqui")
    {

		if(Player.Admin == true)
		{
			if(args[0])
			{
				if(args[0] > 0 && args[0] <= 1800)
				{
					World.AirdropAtPlayer(Player, args[0]);
                    Player.Message("Airdrops totales  " + args[0] + "Lanzados");

				}
				else
				{
					Player.Message("Usa: /airdrop, y un número del 1 al 5");
					Player.Message("Por ejemplo: /airdrop 3 ");
				}
			}
		}
		else
		{
			Player.Message("No tienes acceso a este comando.");
		}
    }
}