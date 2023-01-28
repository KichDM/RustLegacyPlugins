function On_PlayerConnected(Player){
	
	{
		var ini = Plugin.GetIni("PlayerLogs"); 
		var time = System.DateTime.Now.ToString("d/M HH:mm");
		var count=ini.GetSetting("Players", "count");
		var LogString = Player.Name.replace(/\=/g,"")
		if(count==undefined)
		{
		ini.AddSetting("Players", "count",0);
		count=0;
		}
		var countPlusOne=1+Data.ToInt(count);
		ini.AddSetting("Players", "count",countPlusOne);
		var param="";
		if(args.size>0) param = " Parameters: "+args[0];
		var LogValue=("["+time+"] Player name: " + LogString + ". " + "Player Ip: " + "" + Player.IP + " " + "Steam ID: " +  Player.SteamID  ) ;
		ini.AddSetting("Player ip:", LogValue );
		ini.Save();
	}
}