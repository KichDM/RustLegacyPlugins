//Plugin:EasyAirDrops
//Author:CorrosionX
//Version:1.1
function On_PluginInit(){	
	if(!Plugin.IniExists("EasyAirdrops")){
		var setini = Plugin.CreateIni("EasyAirdrops");
		setini.AddSetting("Settings", "PlayersRequired", 3); //Default
		setini.AddSetting("Settings", "DropFrequency", 3600); //In Seconds! 1 hour
		setini.AddSetting("Settings", "DropDuring", "anytime"); //(default) - Can be day/night/anytime
		setini.Save();
	}else{
		var ini = EasyAirdropsIni();
	}
	var Drop_Time = parseInt(ini.GetSetting("Settings", "DropFrequency"),10)*1000;
	DataStore.Add("airdrop", "call", 0);
	Plugin.CreateTimer("AirDropTimer", Drop_Time).Start();
}
function On_PlayerConnected(Player){
	var ini = EasyAirdropsIni();
	var Req_Players = parseInt(ini.GetSetting("Settings", "PlayersRequired"),10);
    if(Req_Players <= Server.Players.Count){	
		DataStore.Remove("airdrop", "call");
		DataStore.Add("airdrop", "call", 1);
		//Server.Broadcast("AirDrops are now being called for!"); //debug
	}
	//Player.Message("Required Players=" + Req_Players); //debug
}
function On_PlayerDisconnected(Player){
	var ini = EasyAirdropsIni();
	var Req_Players = parseInt(ini.GetSetting("Settings", "PlayersRequired"),10);
    if(Req_Players <= Server.Players.Count){
		DataStore.Remove("airdrop", "call");
		DataStore.Add("airdrop", "call", 0);
		//Server.Broadcast("Not enough people online to call airdrops!"); //debug
	}
}
function AirDropTimerCallback(){
	var ini = EasyAirdropsIni();
	var Drop_Time = parseInt(ini.GetSetting("Settings", "DropFrequency"),10)*1000;
	//Server.Broadcast("Timer Completed. Drop Frequency =" + Drop_Time); //debug
	if(DataStore.Get("airdrop", "call") == 1){
		var Drop_During = ini.GetSetting("Settings", "DropDuring");
		if(Drop_During == "anytime"){
			World.Airdrop();
		}
		if(Drop_During == "day" && World.Time < 17.5 && World.Time > 5.5){
			World.Airdrop();
		}
		if(Drop_During == "night" && World.Time > 17.5 && World.Time < 5.5){
			World.Airdrop();
		}
		Server.Broadcast("AirDrop on its way!");
	}
	Plugin.CreateTimer("AirDropTimer", Drop_Time).Start();
}
function EasyAirdropsIni(){
	return Plugin.GetIni("EasyAirdrops"); 
}