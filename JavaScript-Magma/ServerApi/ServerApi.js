
function On_ServerInit()
{
	if(Data.ToInt(Data.GetConfigValue("ServerApi", "General", "Autostart"))==1)startTimer();
}

function On_Command(Player, cmd, args) {	
	if(cmd == "api"  && Player.Admin == true)
	{
		if(Data.ToInt(Data.GetConfigValue("ServerApi", "General", "Enabled"))==1)
		{
			if(args[0]=='start')
			{
				var secs = startTimer();
				Player.Message("Api data stream started, with interval: "+secs);
			}else if(args[0] == "stop")
			{
				Plugin.KillTimer("sendServerData");
				Player.Message("Api data stream stoped");
			}
		} else {
			Player.Message("Api is not enabled!");
		}
	}
}

function startTimer()
{
	if(Data.ToInt(Data.GetConfigValue("ServerApi", "General", "Enabled"))==1)
	{
		var secs		= Data.ToInt(Data.GetConfigValue("ServerApi", "General", "Request_interval"));
		var interval 	= Data.ToInt(secs*1000);
		Plugin.CreateTimer("sendServerData",interval).Start();
		return secs;
		
	} else {
		return false;
	}
}

function sendServerDataCallback()
{
	var players 		= Server.Players;
	var historycount 	= Data.ToInt(Data.GetConfigValue("ServerApi", "General", "Chat_history"));
	var totalhistory	= Data.ToInt(Server.ChatHistoryUsers.Count);
	var game            = getGameStatus();
	var leaderboard     = getLeaderboard();

	//Server.Broadcast("Leaderboard Data");
	//Server.Broadcast(leaderboard.toString());

	if(historycount>=totalhistory)historycount=totalhistory;
	
	var xml = '<?xml version="1.0" encoding="UTF-8"?><serverstatus>';
		xml +='<modifyDate>'+new Date()+'</modifyDate>';
		xml +='<BR>';
			xml +='<game>'+game+'</game>';
		xml +='</BR>';
		for (var i=0;i<leaderboard.length;i++)
		{
			xml +='<leaderboard>';
			xml += '<pname>'+leaderboard[i][0]+'</pname>';
			xml += '<kills>'+leaderboard[i][1]+'</kills>';
			xml +='</leaderboard>';
		}
		xml +='<server>';
			xml +='<currentTime>'+World.Time+'</currentTime>';
			xml +='<nightLength>'+World.NightLength+'</nightLength>';
			xml +='<dayLength>'+World.DayLength+'</dayLength>';
		xml +='</server>';
		xml +='<players>';
			xml +='<totalPlayers>'+Server.Players.Count+'</totalPlayers>';
		for(var pl in Server.Players) {
			xml +='<player>';
				xml +='<name>'+pl.Name+'</name>';
				xml +='<health>'+pl.Health+'</health>';
				xml +='<location>';
					xml +='<x>'+pl.Location.x+'</x>';
					xml +='<z>'+pl.Location.z+'</z>';
					xml +='<y>'+pl.Location.y+'</y>';
				xml +='</location>';
				xml +='<ping>'+pl.Ping+'</ping>';
				xml +='<SteamID>'+pl.SteamID+'</SteamID>';
				xml +='<isAdmin>'+pl.Admin+'</isAdmin>';
			xml +='</player>';
		}
		xml +='</players>';
		
		xml +='<chatHistory>';
		for (var i = 1; i < historycount; i++) {
       		var user = Server.ChatHistoryUsers[totalhistory - i];
       		var message = Server.ChatHistoryMessages[totalhistory - i];
       		if (user != null) 
       		{
       		 	xml +='<chat>';
       		 		xml +='<name>'+user+'</name>';
       		 		xml +='<message>'+message+'</message>';
                xml +='</chat>';
                    		
			}
		}
		xml +='</chatHistory>';
	xml +='</serverstatus>';
	reponse = Web.POST(Data.GetConfigValue("ServerApi", "General", "Request_url"),xml);
	return reponse;
}

function getGameStatus()
{
	var game = DataStore.Get("BattleRoyale", "Game");
	if (game == null || game == undefined)
		game = false;
	return game;
}

function getLeaderboard()
{
	var leaderboard = DataStore.Get("BattleRoyale", "Leaderboard");
	if (leaderboard == null || leaderboard == undefined)
		leaderboard = "empty";

	//leaderboard = sortLeaderboard(leaderboard);
	//Server.Broadcast(leaderboard.toString());
	return leaderboard;
}

function sortLeaderboard(leaderboard)
{
	leaderboard = leaderboard.sort(function(a,b) {
		return a[0] > b[0];
 	});

 	return leaderboard;
}
