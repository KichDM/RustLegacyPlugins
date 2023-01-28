var _isInUse;
var _fromPlayer;
var _toPlayer;

function On_Command(Player, cmd, args) {
	if(Data.GetConfigValue("TpFriend", "Settings", "enabled") == "false"){
		return;
	}
	switch(cmd) {
		case "tpa":
			if (args.Length == 0){
				Player.Message("Teleport Usage:");
				Player.Message("This will teleport you to another player.");
				Player.Message("\"/tpa [PlayerName]\" to request a teleport.");
				Player.Message("\"/tpaccept\" to accept a requested teleport.");
				Player.Message("\"/tpcount\" to see how many requests you have remaining.");
				Player.Message("\"/tpreset\" resets your request counter when ready.");
			}
			if (args.Length >= 1){
				var max_uses = Data.GetConfigValue("TpFriend", "Settings", "max_uses");
				var cooldown = Data.GetConfigValue("TpFriend", "Settings", "cooldown");
				if(cooldown > 0){
					var time = Data.GetTableValue("tp_cooldown3", Player.SteamID);
					var calc = System.Environment.TickCount - time;
					if (calc < 0) {
						time = Data.AddTableValue("tp_cooldown3", Player.SteamID, System.Environment.TickCount);
					}
					if (calc >= cooldown) {
						Data.AddTableValue("tp_da", Player.SteamID, 0);
						var playerName = args[0];
						for(var i=1; i < args.Length; i++)
							playerName += " " + args[i];

						if (playerName == null) {
							Player.Notice("You have to enter a name!");
							return;
						}

						t_player = Player.Find(playerName);

						if (t_player == null) {
							Player.Notice("No players found with that name!");
							return;
						}
						if (t_player == Player) {
							Player.Notice("Cannot teleport to yourself!");
							return;
						}

						if(max_uses > 0){
							var uses = Data.GetTableValue("tp_uses", Player.Name);
							if (uses == null) {
								Data.AddTableValue("tp_uses", Player.Name, 0);
								uses = 0;
							}

							if (uses >= max_uses) {
								Player.Notice("Reached max number of teleport requests!");
								return;
							}
						}

						t_player.Notice("Teleport request from " + Player.Name + " to accept write /tpaccept");
						Player.Notice("Teleport request sent to " + t_player.Name);
						Data.AddTableValue("tp_pending", t_player.Name, Player.Name);
					}
					else {
						Data.AddTableValue("tp_da", Player.SteamID, 0);
						Player.Notice("You have to wait before teleporting again!");
						var next = calc / 1000;
						var next2 = next / 60;
						var done = Number(next2).toFixed(2); 
						Player.Message("Time: " + done + " /20mins");
					}
				}
				else{
					var t_player = Player.Find(args[0]);

					if (t_player == null) {
						Player.Notice("No players found with that name!");
						return;
					}
					if (t_player == Player) {
						Player.Notice("Cannot teleport to yourself!");
						return;
					}

					if(max_uses > 0){
						var uses = Data.GetTableValue("tp_uses", Player.Name);
						if (uses == null) {
							Data.AddTableValue("tp_uses", Player.Name, 0);
							uses = 0;
						}

						if (uses >= max_uses) {
							Player.Notice("Reached max number of teleport requests!");
							return;
						}
					}

					t_player.Notice("Teleport request from " + Player.Name + " to accept write /tpaccept");
					Player.Notice("Teleport request sent to " + t_player.Name);
					Data.AddTableValue("tp_pending", t_player.Name, Player.Name);
				}
			}
			break;
		case "tpaccept":
			var f_name = Data.GetTableValue("tp_pending", Player.Name);
			if(f_name != null){
				var f_player = Player.Find(f_name);
				if(f_player != null){
					if(_isInUse == null){

						var max_uses = Data.GetConfigValue("TpFriend", "Settings", "max_uses");
						if(max_uses > 0){
							var uses = Data.GetTableValue("tp_uses", f_name) + 1;
							Data.AddTableValue("tp_uses", f_name, uses);
						}

						Data.AddTableValue("tp_pending", Player.Name, null);
						Data.AddTableValue("tp_cooldown3", f_player.SteamID, System.Environment.TickCount);
						var cooldown = Data.GetTableValue("tp_resetcooldown", f_player.SteamID);

						if(cooldown != null){
							if(cooldown > 0){
								Data.AddTableValue("tp_resetcooldown", f_player.SteamID, System.Environment.TickCount);
							}
						}

						var timetogo = Data.GetConfigValue("TpFriend", "Settings", "timetogo");
						if(timetogo > 0){
							_isInUse == true;
							_fromPlayer = f_player;
							_toPlayer = Player;
							f_player.Notice("You will be teleported in " + timetogo + " seconds!");
							var resetInterval = timetogo + 2;
							Plugin.CreateTimer("teleportDelay",timetogo * 1000).Start();
							Plugin.CreateTimer("resetTeleport", resetInterval * 1000).Start();
						}else{
							var x = Player.X;
							var y = Player.Y + 3;
							var z = Player.Z;
							f_player.TeleportTo(x,y,z);
							Data.AddTableValue("tp_da", f_player.SteamID, 1);
						}

						if(max_uses > 0){
							f_player.Notice("Teleport requests used " + String(uses) + " / " + String(max_uses));
						}else{
							f_player.Notice("You have unlimited requests remaining!");
						}
					}else{
						f_player.Notice("Another player is currently teleporting please wait!");
					}
				}else{
					Player.Notice("User is not connected please try again later.");
				}
			}else{
				Player.Notice("No teleport request pending!");
			}
			break;
		case "tpdeny":
			var playerName = Data.GetTableValue("tp_pending", Player.Name);
			if(playerName != null){
				var fromPlayer = Player.Find(playerName);
				if (fromPlayer != null){
					Data.AddTableValue("tp_pending", Player.Name, null);
					Player.Notice("Request denied!");
					fromPlayer.Notice("Your request was denied!");
				}
			}else{
				Player.Notice("No request to deny.");
			}
		break;
		case "tpreset":
			var resetCooldown = Data.GetConfigValue("TpFriend", "Settings", "resetcooldown");
			if(resetCooldown > 0){
				var time = Data.GetTableValue("tp_resetcooldown", Player.SteamID);
				var calc = System.Environment.TickCount - time;
				if (calc >= resetCooldown) {
					Player.Notice("Teleport Requests Reset!");
					Data.AddTableValue("tp_resetcooldown", f_player.SteamID, 0);
				}else{
					Player.Notice("You cant reset your request counter yet!");
				}
			}
			else{
				Player.Notice("Request reset is disabled!");
			}
			break;
		case "tpcount":
			var max_uses = Data.GetConfigValue("TpFriend", "Settings", "max_uses");
			if (max_uses > 0)
			{
				var uses = Data.GetTableValue("tp_uses", Player.Name);
				if(uses == null){
					uses = 0;
				}
				Player.Notice("Teleport requests used " + String(uses) + " / " + String(max_uses));

			}else{
				Player.Notice("You have unlimited requests remaining!");
			}
			break;
	}
}

function teleportDelayCallback()
{
	var coordinates = GetHome(_toPlayer);
	if(coordinates != 0){
		//var z = coordinates[2] - 10; Fixes falling though objects but can randomly crash client
		//basically raises player above their home to allow objects to load = wont fall through.
		var x = _toPlayer.X;
		var y = _toPlayer.Y + 3;
		var z = _toPlayer.Z;
		_fromPlayer.TeleportTo(x,y,z);
		Data.AddTableValue("tp_cooldown3", _fromPlayer.SteamID, System.Environment.TickCount);
		_isInUse = null;
	}
	Plugin.KillTimer("teleportDelay");
}

function resetTeleportCallback(){
	_isInUse = null;
	Plugin.KillTimer("resetTeleport");
}

function On_PlayerDisconnected(Player){
	if(Player == _fromPlayer){
		_isInUse = null;
	}
}

function On_PlayerConnected(Player) {
	Data.AddTableValue("tp_da", Player.SteamID, 0);
}
