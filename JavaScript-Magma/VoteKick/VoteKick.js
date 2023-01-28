var VOTE_SUCCESS_PERCENTAGE_REQ = 0.6;
var VOTE_DELAY = 300000;
var gametime = World.Time;

function On_Command(Player, cmd, args) {
	switch(cmd) {
		case "voteday":
			if(Data.GetTableValue("votekick", "target") != null) {
				Player.Message("a Vote is already in progress!");
				break;
			}
			var time = Data.GetTableValue("votekick_delay", Player.SteamID);
			if(time != null && System.Environment.TickCount - time < VOTE_DELAY) {
				Player.Message("Please wait 5 minutes to vote again");
				break;
			}
			var name = "";
			for(var i=0; i < args.Length; i++)
				name += args[i] + " ";
			name = Data.Substring(name, 0, Data.StrLen(name) - 1)		
			var target = Player.Find(name);
			if(target == null) {
				Player.Message("Cant find user: " + name);
				break;
			}
			Data.AddTableValue("votekick_delay", Player.SteamID, System.Environment.TickCount);
			Data.AddTableValue("votekick", "target", target.SteamID);
			Server.Broadcast("----------------------- VOTE -------------------------");
			Server.Broadcast(Player.Name + " has voted to kick " + target.Name);
			Server.Broadcast("Enter /yes to agree, or /no to disagree. You have 60 seconds to vote");
			Server.Broadcast("------------------------------------------------------");
			Plugin.CreateTimer("VKTimer",60000).Start();
			break;

		case "yes":
		case "no":
			var yes = true;
			if(cmd == "no")
				yes = false;
			if(Data.GetTableValue("votekick", "target") == null) {
				Player.Message("There is no vote running");
				break;
			}
			if(Data.GetTableValue("votekick_voted", Player.SteamID) != null) {
				Player.Message("You have already voted");
				break;
			}
			var count = Data.GetTableValue("votekick", cmd);
			if(count == null)
				count = 1;
			else
				count++;
			Data.AddTableValue("votekick", cmd, count);
			Data.AddTableValue("votekick_voted", Player.SteamID, true);
			Player.Message("You have voted: " + cmd);
			break;

		case "votereset":
			if(Player.Admin) {
				Plugin.KillTimer("VKTimer");
				Data.AddTableValue("votekick", "target", null);
				Data.AddTableValue("votekick", "yes", 0);
				Data.AddTableValue("votekick", "no", 0);
				for(var playerr in Server.Players)
					Data.AddTableValue("votekick_voted", playerr.SteamID, null);
				Player.Message("Voting has been reset");
			}
	}
}

function VKTimerCallback()
{
	if(TallyVotes()) {
		var target = Data.GetTableValue("votekick", "target");
		if(target == null)
			break;		
		var pp = null;
		for(var playa in Server.Players) { // Player.Find was not working? 
			if(playa.SteamID == target) {
				pp = playa;
				break;
			}
		}
		if(pp != null) {
			Server.Broadcast(pp.Name + " has been kicked from the server by vote!");
			pp.Disconnect();
		} else {
			Server.Broadcast("Player to be kicked is not online");
		}
	} else {
		Server.Broadcast("Vote failed");
	}
	Plugin.KillTimer("VKTimer");
	Data.AddTableValue("votekick", "target", null);
	Data.AddTableValue("votekick", "yes", 0);
	Data.AddTableValue("votekick", "no", 0);
	for(var playerr in Server.Players)
		Data.AddTableValue("votekick_voted", playerr.SteamID, null);
}

function TallyVotes() {
	var yes = Data.GetTableValue("votekick", "yes");
	var no = Data.GetTableValue("votekick", "no");
	var count = Server.Players.Count;
	return yes > (count * VOTE_SUCCESS_PERCENTAGE_REQ);
}		