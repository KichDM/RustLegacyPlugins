// TPMaster v1.9 by sleepy
// updated from 1.8 for Fougerite by mikec
// Teleport On Hit function (stp) borrowed from UltimateTeleport by k2b
// playerSelect function modified from Online Player function by Five
// StructureMaster and RaycastAll code thanks to mikec

function On_Command(Player, cmd, args){
	cmd = Data.ToLower(cmd);
	var tpmCFG = Plugin.GetIni("TPMasterCFG");
	if(tpmCFG.GetSetting("settings", "admin_use_only") == "off" || Player.Admin){
		switch(cmd){					
			case "p":
				if(Player.Admin){
					var location;
					var distArray = [];
					var hits = UnityEngine.Physics.RaycastAll(Player.PlayerClient.controllable.character.eyesRay);
					if(hits.Length > 0){						
						for(var i=0; i < hits.Length ; i++ ){
							distArray.push(Math.ceil(hits[i].distance));							
						}
						var mindist = Math.min.apply(Math, distArray);
						Player.SafeTeleportTo(Util.Infront(Player, mindist));
					}
				}
				break;
			case "tpt":	
				if(Player.Admin){
					if(args.Length != 0){
						var pl = getPlayer(Player, cmd, args);
						if(pl == "selectedself"){return;}
						else if(pl == false){
							Player.Message("[color#FFA500]No player with that name found, please select from the list");
							playerSelect(Player, cmd);
						} else {
							DataStore.Add("tpmaster_tpb", Player.SteamID, Math.floor(Player.X).toString() + "|" + Math.floor(Player.Y + 3).toString() + "|" + Math.floor(Player.Z).toString());
							Player.TeleportTo(pl);
						}						
					} else {
						playerSelect(Player, cmd);
					}
				}
				break;	
			case "tph":
				if(Player.Admin){
					if(args.Length != 0){						
						var pl = getPlayer(Player, cmd, args);
						if(pl == "selectedself"){return;}
						else if(pl == false){
							Player.Message("[color#FFA500]No player with that name found, please select from the list");
							playerSelect(Player, cmd);
						} else {
							DataStore.Add("tpmaster_tpb", pl.SteamID, Math.floor(pl.X).toString() + "|" + Math.floor(pl.Y + 3).toString() + "|" + Math.floor(pl.Z).toString());
							pl.TeleportTo(Player, 5);							
						}						
					} else {
						playerSelect(Player, cmd);
					}
				}
				break;
			case "tpe":
				if(Player.Admin){
					if(args.Length != 0){
						Player.Message("Type [color#6AFB92]/tpe [color#FFFFFF]alone to teleport everybody on the map to you");
					}
					else{
						var pl;
						for(pl in Server.Players){
							if(!pl.Admin){
								DataStore.Add("tpmaster_tpb", pl.SteamID, Math.floor(pl.X).toString() + "|" + Math.floor(pl.Y + 3).toString() + "|" + Math.floor(pl.Z).toString());
								pl.TeleportTo(Player, 5);								
							}
						}
					}
				}
				break;
			case "tpb":
				if(Player.Admin){
					if(args.Length != 0){
						if(args.Length == 1 && Data.ToLower(args[0]) == "all"){
							var pl;
							for(pl in Server.Players){
								if(DataStore.Get("tpmaster_tpb", pl.SteamID) != undefined && !pl.Admin){
									var tpCoords = DataStore.Get("tpmaster_tpb", pl.SteamID);
									var coordArr = tpCoords.split("|");
									pl.SafeTeleportTo(coordArr[0], coordArr[1], coordArr[2]);
									DataStore.Remove("tpmaster_tpb", pl.SteamID);
								}
							}
						}
						else{
							var pl = getPlayer(Player, cmd, args);
							if(pl == false){
								Player.Message("[color#FFA500]No player with that name found, please select from the list");
								playerSelect(Player, cmd);
							}
							else{
								if(DataStore.Get("tpmaster_tpb", pl.SteamID) == undefined){
									Player.Message("[color#FFA500]There is no return data for this player");
								}
								else{
									var tpCoords = DataStore.Get("tpmaster_tpb", pl.SteamID);
									var coordArr = tpCoords.split("|");
									pl.SafeTeleportTo(coordArr[0], coordArr[1], coordArr[2]);
									DataStore.Remove("tpmaster_tpb", pl.SteamID);
								}
							}
						}
					}										
					else	playerSelect(Player, cmd);
				}
				break;
			case "stp":
				if(Player.Admin){
					if(args.Length != 0){
						Player.Message("Type [color#6AFB92]/stp [color#FFFFFF]and shoot structure to TP through");						
					}					
					else if(DataStore.Get("stp_toggle", Player.SteamID) == 0 || DataStore.Get("stp_toggle", Player.SteamID) == undefined){
						DataStore.Add("stp_toggle", Player.SteamID, 1);
						Player.Notice("Shoot-TelePort activated!");
					}
					else{
						DataStore.Add("stp_toggle", Player.SteamID, 0);
						Player.Notice("Shoot-TelePort de-activated!");
					}
				}
				break;
			case "tpfwd":
				if(Player.Admin){
					if(args.Length != 1 || args[0].match(/[^0-9]/g)){
						Player.Message("Type [color#6AFB92]/tpfwd # [color#FFFFFF]where # is the number of meters you want to move forward");
					}
					else {
						Player.SafeTeleportTo(Util.Infront(Player, args[0]));
					}
				}
				break;
			case "tpadd":
				if(Player.Admin){
					if(args.Length != 0){						
						var name = "";	
						for(var i=0;i<args.Length;i++){
							name += Data.ToLower(args[i]) + " ";					
						}
						name = Data.Substring(name, 0, Data.StrLen(name) - 1);
						addLocation(Player, name);
						Player.Message("[color#FFA500]tp location: [color#FFFFFF]" + name + "[color#FFA500] @ [color#FFFFFF]" + Player.Location.ToString());
					}
					else{
						Player.Message("[color#FFA500]Type [color#FFFFFF]/tpadd location-name [color#FFA500]to add a teleport location");
					}
				}
				break;
			case "tprem":				
			case "tp":
				if(Player.Admin){
					if(args.Length != 0){					
						var location, name = "";	
						for(var i=0;i<args.Length;i++){
							name += Data.ToLower(args[i]) + " ";					
						}
						name = Data.Substring(name, 0, Data.StrLen(name) - 1);					
						location = getLocation(Player, name);
						if(String(location).indexOf('null') != -1 || String(location).indexOf('undefined') != -1){
							Player.Message("[color#FFA500]" + name + " is not a stored location, please select from the list");
							listSelect(Player, cmd);
						}
						else if(cmd == "tprem"){
							removeLocation(Player, name);
							Player.Message("[color#FFFFFF]" + name + "[color#FFA500] has been removed from your teleport list");							
						}
						else if(cmd == "tp"){							
							Player.SafeTeleportTo(location[0], location[1], location[2]);
						}
					}
					else{
						listSelect(Player, cmd);					
					}
				}
				break;
			case "tps":
				if(Player.Admin){
					if(defineStructOwner(Player, cmd) == false){return;}
					else if(args.Length != 0){				
						var pl = getPlayerB(Player, cmd, args);					
						if(pl == false){						
							Player.Message("[color#FFFF00]No player with that name found, please select from the player list");						
							listSelect(Player, cmd);						
						}
						else{
							DataStore.Add("struct_owner_selected", Player.SteamID, pl);
							structSelect(Player, "ss");
						}
					}
					else{					
						listSelect(Player, cmd);
					}
				}
				break;
			case "tphelp":				
				if(Player.Admin){
					Player.Message("Type [color#6AFB92]/tpt [color#FFFFFF]to teleport to a player");
					Player.Message("Type [color#6AFB92]/tph [color#FFFFFF]to teleport a player to you");
					Player.Message("Type [color#6AFB92]/tpe [color#FFFFFF]to teleport all players to you");
					Player.Message("Type [color#6AFB92]/tpb [color#FFFFFF]to return player to prior location");
					Player.Message("Type [color#6AFB92]/tpb all [color#FFFFFF]to return all players to prior location");
					Player.Message("Type [color#6AFB92]/tpy # [color#FFFFFF]to throw player # meters in air");
					Player.Message("Type [color#6AFB92]/stp [color#FFFFFF]to enter where you shoot a building");
					Player.Message("Type [color#6AFB92]/tpfwd # [color#FFFFFF]to teleport # meters forward");
					Player.Message("Type [color#6AFB92]/tpadd location name [color#FFFFFF]to add location to personal tp list");
					Player.Message("Type [color#6AFB92]/tp [color#FFFFFF]to teleport to location on personal tp list");
					Player.Message("Type [color#6AFB92]/tps [color#FFFFFF]to teleport to a players structure");
					Player.Message("[color#FFA500]All commands except /tpy, /stp, and /tpfwd can be typed with name to bypass list");
					Player.Message("[color#FFA500]EXAMPLE: [color#6AFB92]/tpt jimmy [color#FFA500]will teleport you to jimmy");
				}				
				Player.Message("Type [color#6AFB92]/tpfadd [color#FFFFFF]to add a player to your teleport friends list");
				Player.Message("Type [color#6AFB92]/tpfrem [color#FFFFFF]to remove a player from your teleport friends list");
				Player.Message("Type [color#6AFB92]/tpf [color#FFFFFF]to teleport to a friend or to cancel queued teleport");
				Player.Message("Type [color#6AFB92]/tpr [color#FFFFFF]to request teleport to a player or to cancel ignored request");
				Player.Message("Type [color#6AFB92]/tpa [color#FFFFFF]to accept a teleport request from a player");
				Player.Message("Type [color#6AFB92]/tpd [color#FFFFFF]to deny a teleport request from a player");
				Player.Message("Type [color#6AFB92]/tpc [color#FFFFFF]to cancel a queued teleport");				
				break;
			case "tpfadd":				
				if(args.Length != 0){
					var pl = getPlayer(Player, cmd, args);
					if(pl == "selectedself"){return;}
					if(pl == false){
						Player.Message("[color#FFA500]No player with that name found, please select from the list");
						playerSelect(Player, cmd);
					}
					else{
						addFriend(Player, pl);
					}						
				}										
				else{
					playerSelect(Player, cmd);
				}
				break;
			case "tpr":				
				if(DataStore.Get("tpa_pending_" + Player.SteamID, Player.SteamID) != undefined){
					var reqSteamID = DataStore.Get("tpa_pending_" + Player.SteamID, Player.SteamID);					
					var reqLog = Plugin.GetIni("TPRequests\\" + reqSteamID);
					reqLog.DeleteSetting("tprequests", Player.Name);
					reqLog.Save();
					Player.Message("[color#FFA500]Your teleport request has been canceled" );
					DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
					DataStore.Remove("tpmaster_queue", Player.SteamID);
				}
				else if(DataStore.Get("tpmaster_cooldown", Player.SteamID) != undefined){
					Player.Notice("You are still on cooldown due to recent TP or PVP action");
					var cycles = parseInt(DataStore.Get("tpmaster_cooldown", Player.SteamID), 10);
					var currCycle = Math.floor(Plugin.GetTimer("TPMasterTimer").TimeLeft/1000);
					var timeLeft = (cycles * 30) + currCycle;
					if(currCycle < 0){
						Plugin.KillTimer("TPMasterTimer");
						Plugin.CreateTimer("TPMasterTimer", 30000).Start();
						timeLeft = (cycles * 30) + 30;
					}
					Player.Message("[color#FFA500]You can teleport again in " + timeLeft + " seconds");
					return;
				}
				else if(tpMasterFundsCheck(Player) == false){
					return;
				}
				else if(args.Length != 0){					
					var pl = getPlayer(Player, cmd, args);
					if(pl == "selectedself"){return;}
					else if(pl == false){
						Player.Message("[color#FFA500]No player with that name found, please select from the list");
						playerSelect(Player, cmd);
					}
					else{
						tpRequest(Player, pl);
					}					
				}				
				else{					
					playerSelect(Player, cmd);
				}
				break;
			case "tpfrem":
				if(args.Length != 0){
					if(!Plugin.IniExists("TPFriends\\" + Player.SteamID)){						
						Player.Message("[color#FFA500]You dont have a TP Friends list yet!");
						return;
					}
					var pl = getFriend(Player, cmd, args);
					if(pl == "selectedself"){return;}
					else if(pl == false){
						Player.Message("[color#FFA500]No player with that name found, please select from the list");
						listSelect(Player, cmd);
					}					
					else{
						Player.Message("[color#FFA500]" + name + " was removed from your TP Friends list");
					}					
				}				
				else{
					listSelect(Player, cmd);
				}
				break;
			case "tpf":				
				if(DataStore.Get("tpf_pending_" + Player.SteamID, Player.SteamID) != undefined){					
					Player.Message("[color#FFA500]Your teleport request has been canceled" );
					DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
					DataStore.Remove("tpmaster_queue", Player.SteamID);
				}
				else if(DataStore.Get("tpmaster_cooldown", Player.SteamID) != undefined){
					Player.Notice("You are still on cooldown due to recent TP or PVP action");
					var cycles = parseInt(DataStore.Get("tpmaster_cooldown", Player.SteamID), 10);
					var currCycle = Math.floor(Plugin.GetTimer("TPMasterTimer").TimeLeft/1000);
					var timeLeft = (cycles * 30) + currCycle;
					if(currCycle < 0){
						Plugin.KillTimer("TPMasterTimer");
						Plugin.CreateTimer("TPMasterTimer", 30000).Start();
						timeLeft = (cycles * 30) + 30;
					}
					Player.Message("You can teleport again in " + timeLeft + " seconds");
					return;
				}
				else if(tpMasterFundsCheck(Player) == false){
					return;
				}
				else if(args.Length != 0){
					var pl = getFriend(Player, cmd, args);
					if(pl == "selectedself"){return;}
					else if(pl == false){
						Player.Message("[color#FFA500]No player with that name found, please select from the list");
						listSelect(Player, cmd);
					}
				}				
				else{					
					listSelect(Player, cmd);
				}
				break;
			case "tpa":
			case "tpd":
				if(args.Length != 0){
					var pl = getFriend(Player, cmd, args);
					if(pl == "selectedself"){return;}
					else if(pl == false){
						Player.Message("[color#FFA500]No player with that name found, please select from the list");
						listSelect(Player, cmd);
					}
				}
				else{					
					listSelect(Player, cmd);
				}
				break;			
			case "tpc":
				if(args.Length != 0){
					Player.Message("Type [color#6AFB92]/" + cmd + " [color#FFFFFF]to cancel teleport to player");
					Player.Message("Type or to clear pending teleport requests");
				}				
				else{
					cancelTP(Player);
					Player.Message("[color#FFA500]Pending teleport canceled");
				}
				break;
		}
	}
}

function On_Chat(Player, ChatString){
	if(DataStore.Get("tpt_pending", Player.SteamID) == true){
		var toggle = 0;
		for(pl in Server.Players){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpt_numselected_" + Player.SteamID);		
				DataStore.Remove("tpt_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpt_numselected_" + Player.SteamID);		
				DataStore.Remove("tpt_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				playerSelect(Player, "tpt");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpt_numselected_" + Player.SteamID, pl.SteamID) + '"'){
				DataStore.Add("tpmaster_tpb", Player.SteamID, Math.floor(Player.X).toString() + "|" + Math.floor(Player.Y).toString() + "|" + Math.floor(Player.Z).toString());
				Player.SafeTeleportTo(pl.X, pl.Y, pl.Z);
				DataStore.Flush("tpt_numselected_" + Player.SteamID);		
				DataStore.Remove("tpt_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}		
	}
	else if(DataStore.Get("tph_pending", Player.SteamID) == true){
		var toggle = 0;
		for(pl in Server.Players){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tph_numselected_" + Player.SteamID);		
				DataStore.Remove("tph_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tph_numselected_" + Player.SteamID);		
				DataStore.Remove("tph_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				playerSelect(Player, "tph");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tph_numselected_" + Player.SteamID, pl.SteamID) + '"'){
				DataStore.Add("tpmaster_tpb", pl.SteamID, Math.floor(pl.X).toString() + "|" + Math.floor(pl.Y).toString() + "|" + Math.floor(pl.Z).toString());
				pl.SafeTeleportTo(Player.X, Player.Y, Player.Z);
				DataStore.Flush("tph_numselected_" + Player.SteamID);		
				DataStore.Remove("tph_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpb_pending", Player.SteamID) == true){
		var toggle = 0;
		for(pl in Server.Players){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpb_numselected_" + Player.SteamID);		
				DataStore.Remove("tpb_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpb_numselected_" + Player.SteamID);		
				DataStore.Remove("tpb_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				playerSelect(Player, "tpb");
				break;
			}
			else if(ChatString == '"flush"'){
				DataStore.Flush("tpmaster_tpb");
				Player.Message("tpb data flushed");
				DataStore.Flush("tpb_numselected_" + Player.SteamID);		
				DataStore.Remove("tpb_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpb_numselected_" + Player.SteamID, pl.SteamID) + '"'){
				var tpCoords = DataStore.Get("tpmaster_tpb", pl.SteamID);
				var coordArr = tpCoords.split("|");
				pl.SafeTeleportTo(coordArr[0], coordArr[1], coordArr[2]);
				DataStore.Remove("tpmaster_tpb", pl.SteamID);
				DataStore.Flush("tpb_numselected_" + Player.SteamID);		
				DataStore.Remove("tpb_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpfadd_pending", Player.SteamID) == true){
		var toggle = 0;
		for(pl in Server.Players){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpfadd_numselected_" + Player.SteamID);		
				DataStore.Remove("tpfadd_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpfadd_numselected_" + Player.SteamID);		
				DataStore.Remove("tpfadd_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				playerSelect(Player, "tpfadd");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpfadd_numselected_" + Player.SteamID, pl.SteamID) + '"'){
				addFriend(Player, pl);
				DataStore.Flush("tpfadd_numselected_" + Player.SteamID);		
				DataStore.Remove("tpfadd_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpfrem_pending", Player.SteamID) == true){
		var toggle = 0;
		var tpfLog = Plugin.GetIni("TPFriends\\" + Player.SteamID);
		var tpfriends = tpfLog.EnumSection("tpfriends");		
		var key, ids;
		for(key in tpfriends){
			ids = tpfLog.GetSetting("tpfriends", key);
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpfrem_numselected_" + Player.SteamID);		
				DataStore.Remove("tpfrem_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpfrem_numselected_" + Player.SteamID);		
				DataStore.Remove("tpfrem_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				listSelect(Player, "tpfrem");
				break;
			}	
			else if(ChatString == '"' + DataStore.Get("tpfrem_numselected_" + Player.SteamID, ids) + '"'){
				tpfLog.DeleteSetting("tpfriends", key);	
				Player.Message("[color#FFA500]" + key + " was removed from your TP Friends list");
				tpfLog.Save();
				DataStore.Flush("tpfrem_numselected_" + Player.SteamID);		
				DataStore.Remove("tpfrem_pending", Player.SteamID);	
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}		
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpf_pending", Player.SteamID) == true){
		var toggle = 0;
		var tpfLog = Plugin.GetIni("TPFriends\\" + Player.SteamID);
		var tpfriends = tpfLog.EnumSection("tpfriends");
		var key, ids;
		for(key in tpfriends){
			ids = tpfLog.GetSetting("tpfriends", key);
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpf_numselected_" + Player.SteamID);		
				DataStore.Remove("tpf_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpf_numselected_" + Player.SteamID);		
				DataStore.Remove("tpf_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				listSelect(Player, "tpf");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpf_numselected_" + Player.SteamID, ids) + '"'){
				var friend = Magma.Player.FindBySteamID(ids);
				if(friend == undefined){
					Player.Message("[color#FFA500]Your friend is not currently online");					
				}
				else{
					friendCheck(Player, friend);					
				}
				DataStore.Flush("tpf_numselected_" + Player.SteamID);		
				DataStore.Remove("tpf_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}		
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpr_pending", Player.SteamID) == true){
		var toggle = 0;
		for(pl in Server.Players){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpr_numselected_" + Player.SteamID);		
				DataStore.Remove("tpr_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpr_numselected_" + Player.SteamID);		
				DataStore.Remove("tpr_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				playerSelect(Player, "tpr");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpr_numselected_" + Player.SteamID, pl.SteamID) + '"'){				
				tpRequest(Player, pl);
				DataStore.Flush("tpr_numselected_" + Player.SteamID);		
				DataStore.Remove("tpr_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;				
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpa_pending", Player.SteamID) == true){
		var toggle = 0;
		var reqLog = Plugin.GetIni("TPRequests\\" + Player.SteamID);
		var tprequests = reqLog.EnumSection("tprequests");
		var key, ids;
		for(key in tprequests){
			ids = reqLog.GetSetting("tprequests", key);
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpa_numselected_" + Player.SteamID);		
				DataStore.Remove("tpa_pending", Player.SteamID);				
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpa_numselected_" + Player.SteamID);		
				DataStore.Remove("tpa_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				listSelect(Player, "tpa");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpa_numselected_" + Player.SteamID, ids) + '"'){
				var friend = Magma.Player.FindBySteamID(ids);
				if(friend == undefined){
					Player.Message("[color#FFA500]Your friend is not currently online");					
				}
				else{
					tpfriend(friend, Player);
					reqLog.DeleteSetting("tprequests", key);										
				}
				reqLog.Save();
				DataStore.Remove("tpa_pending_" + friend.SteamID, friend.SteamID);
				DataStore.Flush("tpa_numselected_" + Player.SteamID);		
				DataStore.Remove("tpa_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("tpd_pending", Player.SteamID) == true){
		var toggle = 0;
		var reqLog = Plugin.GetIni("TPRequests\\" + Player.SteamID);
		var tprequests = reqLog.EnumSection("tprequests");
		var key, ids;
		for(key in tprequests){
			ids = reqLog.GetSetting("tprequests", key);
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Flush("tpd_numselected_" + Player.SteamID);		
				DataStore.Remove("tpd_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
			else if(ChatString == '"r"'){
				DataStore.Flush("tpd_numselected_" + Player.SteamID);		
				DataStore.Remove("tpd_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				listSelect(Player, "tpd");
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tpd_numselected_" + Player.SteamID, ids) + '"'){	
				var friend = Magma.Player.FindBySteamID(ids);
				reqLog.DeleteSetting("tprequests", key);
				DataStore.Remove("tpa_pending_" + friend.SteamID, friend.SteamID);
				Player.Message("[color#FFA500]" + key + "'s teleport request was denied");
				friend.Message("[color#FFA500]" + Player.Name + " denied your teleport request");
				reqLog.Save();
				DataStore.Flush("tpd_numselected_" + Player.SteamID);		
				DataStore.Remove("tpd_pending", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "          ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	if(DataStore.Get("tprem_pending", Player.SteamID) == true){
		var key;
		var toggle = 0;
		var locations = DataStore.Keys("tp_locations" + Player.SteamID);
		for(key in locations){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Remove("tprem_pending", Player.SteamID);
				DataStore.Flush("tprem_numselected_" + Player.SteamID);
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"r"'){				
				DataStore.Remove("tprem_pending", Player.SteamID);
				DataStore.Flush("tprem_numselected_" + Player.SteamID);
				toggle = 1;
				listSelect(Player, "tprem");
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tprem_numselected_" + Player.SteamID, key) + '"'){
				DataStore.Remove("tp_locations" + Player.SteamID, key);
				DataStore.Remove("tprem_pending", Player.SteamID);
				DataStore.Flush("tprem_numselected_" + Player.SteamID);
				Player.Message("[color#FFA500]" + key + " has been removed from teleport list");
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a location from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist locations");
		}
	}
	else if(DataStore.Get("tp_pending", Player.SteamID) == true){
		var key;
		var toggle = 0;
		var locations = DataStore.Keys("tp_locations" + Player.SteamID);
		for(key in locations){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Remove("tp_pending", Player.SteamID);
				DataStore.Flush("tp_numselected_" + Player.SteamID);
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"r"'){				
				DataStore.Remove("tp_pending", Player.SteamID);
				DataStore.Flush("tp_numselected_" + Player.SteamID);
				toggle = 1;
				listSelect(Player, "tp");
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tp_numselected_" + Player.SteamID, key) + '"'){				
				DataStore.Remove("tp_pending", Player.SteamID);
				DataStore.Flush("tp_numselected_" + Player.SteamID);
				var loc = DataStore.Get("tp_locations" + Player.SteamID, key);
				Player.SafeTeleportTo(loc[0], loc[1], loc[2]);
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a location from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist locations");
		}
	}
	else if(DataStore.Get("tps_pending", Player.SteamID) == true){
		var key;
		var toggle = 0;
		var locations = DataStore.Keys("tpmaster_player");
		for(key in locations){
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Remove("tps_pending", Player.SteamID);
				DataStore.Flush("tps_numselected_" + Player.SteamID);
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"r"'){				
				DataStore.Remove("tps_pending", Player.SteamID);
				DataStore.Flush("tps_numselected_" + Player.SteamID);
				toggle = 1;
				listSelect(Player, "tps");
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"' + DataStore.Get("tps_numselected_" + Player.SteamID, key) + '"'){				
				DataStore.Remove("tps_pending", Player.SteamID);
				DataStore.Flush("tps_numselected_" + Player.SteamID);
				DataStore.Add("struct_owner_selected", Player.SteamID, key);
				structSelect(Player, "ss");
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please select a player from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist players");
		}
	}
	else if(DataStore.Get("ss_pending", Player.SteamID) == true){
		var masters, type, x, z, gg;
		var toggle = 0;
		Util.TryFindType('StructureMaster', type);
		masters = UnityEngine.Object.FindObjectsOfType(type);
		for(var i=0; i < masters.Length; i++){		
			if(ChatString == '"c"'){
				Player.Message("[color#FFA500]Selection canceled");
				DataStore.Remove("ss_pending", Player.SteamID);
				DataStore.Flush("ss_numselected_" + Player.SteamID);
				DataStore.Remove("struct_owner_selected", Player.SteamID);
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"r"'){				
				DataStore.Remove("ss_pending", Player.SteamID);
				DataStore.Flush("ss_numselected_" + Player.SteamID);
				toggle = 1;
				structSelect(Player, "ss");
				ChatString.NewText = "    ";
				break;
			}
			else if(ChatString == '"' + DataStore.Get("ss_numselected_" + Player.SteamID, String(masters[i].containedBounds.max)) + '"'){				
				DataStore.Remove("ss_pending", Player.SteamID);
				DataStore.Flush("ss_numselected_" + Player.SteamID);
				DataStore.Remove("struct_owner_selected", Player.SteamID);
				x = masters[i].containedBounds.max.x;				
				z = masters[i].containedBounds.max.z;
				Player.SafeTeleportTo(x,y,z);
				toggle = 1;
				ChatString.NewText = "    ";
				break;
			}
		}
		if(toggle == 0){
			Player.Message("[color#FFFF00]Please make a selection from the list");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]c [color#FFFF00]to cancel");
			Player.Message("[color#FFFF00]or type [color#FFFFFF]r [color#FFFF00]to relist selections");
		}
	}
}

var friendCheck = function(Player, friend){
	if(!Plugin.IniExists("TPFriends\\" + friend.SteamID)){
		Player.Message("[color#6AFB92]" + friend.Name + " doesn't have you in their friends list");
		return;
	}
	else{
		var friendCheckLog = Plugin.GetIni("TPFriends\\" + friend.SteamID);
		var tpfriends = friendCheckLog.EnumSection("tpfriends");
		var key, ids;
		for(key in tpfriends){
			ids = friendCheckLog.GetSetting("tpfriends", key);
			if(Player.SteamID == ids){
				DataStore.Add("tpf_pending_" + Player.SteamID, Player.SteamID, friend.SteamID);
				tpfriend(Player, friend);				
				return;
			}
		}
		Player.Message("[color#6AFB92]" + friend.Name + " doesn't have you in their friends list");
		return;
	}
};

var tpfriend = function(Player, friend){
	var friendVector = Util.CreateVector(friend.X, friend.Y, friend.Z);
	var friendSet = Math.floor(friend.X).toString() + "|" + Math.floor(friend.Y + 3).toString() + "|" + Math.floor(friend.Z).toString();
	if(DataStore.Get("Event Points", Player.SteamID) != undefined || DataStore.Get("Event Points", friend.SteamID) != undefined){
		Player.Notice("No teleporting in or out of an event");
		friend.Notice("No teleporting in or out of an event");
		DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
		DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
		return;
	}
	if(DataStore.Get("com.eightd.arena++.pltoa", Player.SteamID) != undefined || DataStore.Get("com.eightd.arena++.pltoa", friend.SteamID) != undefined){
		Player.Notice("No teleporting in or out of an event");
		friend.Notice("No teleporting in or out of an event");
		DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
		DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
		return;
	}
	if(DataStore.Get("tpmaster_cooldown", Player.SteamID) != undefined){
		Player.Notice("You are still on cooldown due to recent TP or PVP action");
		DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
		DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
		return;
	}	
	var tpmCFG = Plugin.GetIni("TPMasterCFG");
	if(tpmCFG.GetSetting("settings", "structure_proximity_detection") == "on"){
		var masters, type;
		Util.TryFindType('StructureMaster', type);
		masters = UnityEngine.Object.FindObjectsOfType(type);
		if(masters.Length > 0){
			for(var i=0; i < masters.Length; i++){
				if(Player.SteamID != masters[i].ownerID.ToString() && friend.SteamID != masters[i].ownerID.ToString()){
					if(System.Math.Sqrt(masters[i].containedBounds.SqrDistance(friendVector)) < 10){
						Player.Message("[color#6AFB92]" + friend.Name + " is too close to another players building");
						Player.Message("[color#6AFB92]Once " + friend.Name + " is 10 meters away from building try again");
						friend.Message("[color#6AFB92]" + Player.Name + " is trying to teleport to you, but you are");
						friend.Message("[color#6AFB92]too close to another players building. Move 10 meters away from");
						friend.Message("[color#6AFB92]other player buildings for him to teleport to you");
						DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
						DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
						return;
					}
				}
			}
		}		
	}
	if(tpmCFG.GetSetting("settings", "instant_player_teleport") == "on"){
		DataStore.Remove("tpmaster_queue", Player.SteamID);
		DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
		DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);					
		if(tpMasterFundsRemove(Player) == false){
			return;
		}			
		var cycles = tpmCFG.GetSetting("settings", "tp_cooldown_cycles");
		var coordArr = friendSet.split("|");
		Player.SafeTeleportTo(coordArr[0], coordArr[1], coordArr[2]);                
		if(tpmCFG.GetSetting("settings", "tp_cooldown") == "on"){
			DataStore.Add("tpmaster_cooldown", Player.SteamID, cycles);	
		}
		return;
	}
	Player.Message("[color#6AFB92]Your trip to " + friend.Name + " is set");
	var timeLeft = Math.floor(Plugin.GetTimer("TPMasterTimer").TimeLeft/1000);
	if(timeLeft < 0){
		Plugin.KillTimer("TPMasterTimer");
		Plugin.CreateTimer("TPMasterTimer", 30000).Start();
		timeLeft = 30;
	}
	Player.Message("[color#6AFB92]You will be teleported in " + timeLeft + " seconds");
	friend.Message("[color#6AFB92]" + Player.Name + " will be teleported in " + timeLeft + " seconds");
	DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
	DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
	DataStore.Add("tpmaster_queue", Player.SteamID, friendSet);
	return;
};

var addFriend = function(Player, pl){		
	if(!Plugin.IniExists("TPFriends\\" + Player.SteamID)){
		var tpfLog = Plugin.CreateIni("TPFriends\\" + Player.SteamID);
	}
	else{
		var tpfLog = Plugin.GetIni("TPFriends\\" + Player.SteamID);
	}	
	tpfLog.AddSetting("tpfriends", pl.Name, pl.SteamID);
	tpfLog.Save();
	Player.Message(pl.Name + " added to your teleport friends list");
	return;
};

var playerSelect = function(Player, cmd){	
	Player.Message("Type number in chat to select player");
	Player.Message("or type [color#6AFB92]c [color#FFFFFF]to cancel the selection");
	Player.Message("or type [color#6AFB92]r [color#FFFFFF]to relist the selection");
	if(cmd == "tpb"){
		Player.Message("or type [color#6AFB92]flush [color#FFFFFF]to flush return data");
	}
	Player.Message("#########################################");
	var count = 0,
		totalcount = 0,
		num = 1;
	var str = "";
	for (var pl in Server.Players) {
		if((cmd == "tpb" && DataStore.Get("tpmaster_tpb", pl.SteamID) != undefined) || cmd == "tpt" || cmd == "tph" || cmd == "tpy" || cmd == "tpfadd" || cmd == "tpr"){
			//totalcount++;
			if (totalcount >= 90) {
				count = 0;
				break;
			}
			if(((cmd == "tpt" || cmd == "tph" || cmd == "tpfadd" || cmd == "tpr") && Player.SteamID != pl.SteamID) || cmd == "tpb" || cmd == "tpy"){
				totalcount++;
				str += "[color#6AFB92][" + num + "] [color#FFFFFF]" + pl.Name + "  ";
				DataStore.Add(cmd + "_numselected_" + Player.SteamID, pl.SteamID, num);
				if (count == 5) {
					count = 0;
					num++;
					Player.Message(Data.Substring(str, 0, Data.StrLen(str) - 1));					
					str = "";				
				} else {					
					count++;									
					num++;				
				}
			}
		}
	}
	if (count != 0){
		Player.Message(Data.Substring(str, 0, Data.StrLen(str) - 1));
	}
	if(totalcount == 0){
		Player.Message("[color#FFA500]There are no selections to be made");
		return;
	}		
	DataStore.Add(cmd + "_pending", Player.SteamID, true);
	return;
};

var listSelect = function(Player, cmd){
	if(cmd == "tpf" || cmd == "tpfrem"){
		if(!Plugin.IniExists("TPFriends\\" + Player.SteamID)){
			Player.Message("[color#FFA500]You dont have a TP Friends list yet!");
			return;
		}
		else{
			var tpfLog = Plugin.GetIni("TPFriends\\" + Player.SteamID);
		}
		var logsection = tpfLog.EnumSection("tpfriends");
		if(logsection.Length == 0){
			Player.Message("[color#FFA500]You dont have any friends on your list");
			return;
		}
	}
	else if(cmd == "tpa" || cmd == "tpd"){
		if(!Plugin.IniExists("TPRequests\\" + Player.SteamID)){
			Player.Message("[color#FFA500]You dont have any requests yet!");
			return;
		}
		else{
			var reqLog = Plugin.GetIni("TPRequests\\" + Player.SteamID);
		}
		var logsection = reqLog.EnumSection("tprequests");
	}
	else if((cmd == "tprem" || cmd == "tp") && DataStore.Count("tp_locations" + Player.SteamID) == 0){ 
		Player.Message("[color#FFA500]You don't have any locations stored");
		return;
	}
	else if(cmd == "tp" || cmd == "tprem"){var logsection = DataStore.Keys("tp_locations" + Player.SteamID);} 
	else if(cmd == "tps"){var logsection = DataStore.Keys("tpmaster_player");}
	var key, ids;
	Player.Message("Type number in chat to make selection");
	Player.Message("or type [color#6AFB92]c [color#FFFFFF]to cancel the selection");
	Player.Message("or type [color#6AFB92]r [color#FFFFFF]to relist selection");	
	Player.Message("#########################################");
	var count = 0,
		totalcount = 0,
		num = 1;
	var str = "";	
	for(key in logsection) {		
		totalcount++;
		if (totalcount >= 90) {
			count = 0;
			break;
		}
		if(cmd == "tpf" || cmd == "tpfrem"){
			ids = tpfLog.GetSetting("tpfriends", key);
			str += "[color#6AFB92][" + num + "] [color#FFFFFF]" + key + "  ";
			DataStore.Add(cmd + "_numselected_" + Player.SteamID, ids, num);
		}
		else if(cmd == "tpa" || cmd == "tpd"){
			ids = reqLog.GetSetting("tprequests", key);
			str += "[color#6AFB92][" + num + "] [color#FFFFFF]" + key + "  ";
			DataStore.Add(cmd + "_numselected_" + Player.SteamID, ids, num);
		}
		else if(cmd == "tp" || cmd == "tprem"){
			str += "[color#6AFB92][" + num + "] [color#FFFFFF]" + key + "  ";
			DataStore.Add(cmd + "_numselected_" + Player.SteamID, key, num);
		}
		else if(cmd == "tps"){
			if(DataStore.Get("tpmaster_homes", key) != undefined){
				str += "[color#6AFB92][" + num + "] [color#FFFFFF]" + DataStore.Get("tpmaster_player", key) + "  ";
				DataStore.Add(cmd + "_numselected_" + Player.SteamID, key, num);
			}
			else{
				num--;
				count--;
			}
		}		
		if (count == 5) {
			num++;
			count = 0;
			Player.Message(Data.Substring(str, 0, Data.StrLen(str) - 1));
			str = "";				
		} else {
			count++;							
			num++;				
		}		
	}
	if (count != 0){
		Player.Message(Data.Substring(str, 0, Data.StrLen(str) - 1));
	}
	DataStore.Add(cmd + "_pending", Player.SteamID, true);
	return;
};

function On_EntityHurt(Hurt) {
	if(Hurt.Attacker != null && Hurt.Entity != null && Hurt.Attacker.Admin) {
		if(DataStore.Get("stp_toggle", Hurt.Attacker.SteamID) == 1) {
			Hurt.Attacker.SafeTeleportTo(Hurt.Entity.X, Hurt.Entity.Y+2, Hurt.Entity.Z);
		}
	}				
}

function On_PlayerHurt(he){	
	if (he.Attacker.SteamID != null && he.WeaponName != null) {        
        var tpmCFG = Plugin.GetIni("TPMasterCFG");
		if(tpmCFG.GetSetting("settings", "pvp_cooldown") == "on"){
			var cycles = tpmCFG.GetSetting("settings", "pvp_cooldown_cycles");			
			var AttackerID = he.Attacker.SteamID;
			var AttackedID = he.Victim.SteamID;	
			var AttCoolLeft = DataStore.Get("tpmaster_cooldown", AttackerID);
			var VicCoolLeft = DataStore.Get("tpmaster_cooldown", AttackedID);
			if(AttCoolLeft <= cycles){
				DataStore.Add("tpmaster_cooldown", AttackerID, cycles);					
			}
			if(VicCoolLeft <= cycles){
				DataStore.Add("tpmaster_cooldown", AttackedID, cycles);
			}
			if(DataStore.Get("tpmaster_queue", AttackerID) != undefined){
				he.Attacker.Notice("You can't teleport during PVP altercation");
				DataStore.Remove("tpmaster_queue", AttackerID);
				DataStore.Remove("tpf_pending_" + AttackerID, AttackerID);
				DataStore.Remove("tpa_pending_" + AttackerID, AttackerID);
			}
			if(DataStore.Get("tpmaster_queue", AttackedID) != undefined){
				he.Victim.Notice("You can't teleport during PVP altercation");
				DataStore.Remove("tpmaster_queue", AttackedID);
				DataStore.Remove("tpf_pending_" + AttackedID, AttackedID);
				DataStore.Remove("tpa_pending_" + AttackedID, AttackedID);
			}
		}
    }
}

function TPMasterTimerCallback() {
	Plugin.KillTimer("TPMasterTimer");
        for (pl in Server.Players) {
            var friendSet = DataStore.Get("tpmaster_queue", pl.SteamID);
			if(DataStore.Get("tpmaster_cooldown", pl.SteamID) >= 1){
				DataStore.Add("tpmaster_cooldown", pl.SteamID, DataStore.Get("tpmaster_cooldown", pl.SteamID) - 1);
			}			
			else if(DataStore.Get("tpmaster_cooldown", pl.SteamID) == 0){
				DataStore.Remove("tpmaster_cooldown", pl.SteamID);				
			}			
            else if (friendSet != undefined) {
				var tpmCFG = Plugin.GetIni("TPMasterCFG");
				if(tpmCFG.GetSetting("settings", "instant_player_teleport") != "on"){
					DataStore.Remove("tpmaster_queue", pl.SteamID);
					DataStore.Remove("tpf_pending_" + pl.SteamID, pl.SteamID);
					DataStore.Remove("tpa_pending_" + pl.SteamID, pl.SteamID);					
					if(tpMasterFundsRemove(pl) == false){
						Plugin.CreateTimer("TPMasterTimer", 30000).Start();
						return;
					}
					if(DataStore.Get("Event Points", pl.SteamID) != undefined || DataStore.Get("com.eightd.arena++.pltoa", pl.SteamID) != undefined){
						pl.Notice("No teleporting in or out of an event");		
						Plugin.CreateTimer("TPMasterTimer", 30000).Start();
						return;
					}					
					var cycles = tpmCFG.GetSetting("settings", "tp_cooldown_cycles");
					var coordArr = friendSet.split("|");
					pl.SafeTeleportTo(coordArr[0], coordArr[1], coordArr[2]);                
					if(tpmCFG.GetSetting("settings", "tp_cooldown") == "on"){
						DataStore.Add("tpmaster_cooldown", pl.SteamID, cycles);	
					}
				}
            }
        }
		Plugin.CreateTimer("TPMasterTimer", 30000).Start();
    }

function On_PluginInit(){
	if(!Plugin.CreateDir("TPFriends")){
		Plugin.CreateDir("TPFriends");
	}
	if(!Plugin.CreateDir("TPRequests")){
		Plugin.CreateDir("TPRequests");
	}
	if(!Plugin.CreateDir("TPLocations")){
		Plugin.CreateDir("TPLocations");
	}
	if(!Plugin.IniExists("TPMasterCFG")){
		var tpmCFG = Plugin.CreateIni("TPMasterCFG");
		tpmCFG.AddSetting("settings", "structure_proximity_detection", "on");
		tpmCFG.AddSetting("settings", "instant_player_teleport", "off");
		tpmCFG.AddSetting("settings", "admin_use_only", "off");
		tpmCFG.AddSetting("settings", "pvp_cooldown", "on");
		tpmCFG.AddSetting("settings", "pvp_cooldown_cycles", 2);
		tpmCFG.AddSetting("settings", "tp_cooldown", "on");
		tpmCFG.AddSetting("settings", "tp_cooldown_cycles", 10);
		tpmCFG.AddSetting("settings", "economy_enabled", "off");		
		tpmCFG.AddSetting("economy", "magma_dollar", 0);
		tpmCFG.AddSetting("economy", "KKMoney", 0);
		tpmCFG.AddSetting("economy", "RustMoney", 0);
		tpmCFG.AddSetting("economy", "RustMoneyGiQ", 0);
		tpmCFG.Save();		
	}
	Plugin.CreateTimer("TPMasterTimer", 30000).Start();
}

function On_PlayerConnected(Player){
	DataStore.Add("tpmaster_player", Player.SteamID, Player.Name);
}

function On_PlayerDisconnected(Player){
	cancelTP(Player);
}

var cancelTP = function(Player){
	var pname = Player.Name;
	var sid = Player.SteamID;
	var reqLoga = Plugin.GetIni("TPRequests\\" + sid);
	var logsection = [];
	if (reqLoga != null) {
		logsection = reqLoga.EnumSection("tprequests");
	}
	var key;
	if(logsection.Length > 0){
		for(key in logsection){
			reqLoga.DeleteSetting("tprequests", key);
		}
		reqLoga.Save();
	}
	if(DataStore.Get("tpa_pending_" + Player.SteamID, Player.SteamID) != undefined){
		var reqSteamID = DataStore.Get("tpa_pending_" + Player.SteamID, Player.SteamID);					
		var reqLogb = Plugin.GetIni("TPRequests\\" + reqSteamID);
		reqLogb.DeleteSetting("tprequests", Player.Name);
		reqLogb.Save();		
		DataStore.Remove("tpa_pending_" + Player.SteamID, Player.SteamID);
		DataStore.Remove("tpmaster_queue", Player.SteamID);
	}
	if(DataStore.Get("tpa_pending", Player.SteamID) != undefined){
		DataStore.Flush("tpa_numselected_" + Player.SteamID);
		DataStore.Remove("tpa_pending", Player.SteamID);
	}
	if(DataStore.Get("tpd_pending", Player.SteamID) != undefined){
		DataStore.Flush("tpd_numselected_" + Player.SteamID);
		DataStore.Remove("tpd_pending", Player.SteamID);
	}
	if(DataStore.Get("tpf_pending", Player.SteamID) != undefined){
		DataStore.Flush("tpf_numselected_" + Player.SteamID);
		DataStore.Remove("tpf_pending", Player.SteamID);
	}
	if(DataStore.Get("tpr_pending", Player.SteamID) != undefined){
		DataStore.Flush("tpr_numselected_" + Player.SteamID);
		DataStore.Remove("tpr_pending", Player.SteamID);
	}
	if(DataStore.Get("tpf_pending_" + Player.SteamID, Player.SteamID) != undefined){		
		DataStore.Remove("tpf_pending_" + Player.SteamID, Player.SteamID);
		DataStore.Remove("tpmaster_queue", Player.SteamID);
	}
	if(DataStore.Get("tpfadd_pending", Player.SteamID) != undefined){
		DataStore.Flush("tpfadd_numselected_" + Player.SteamID);
		DataStore.Remove("tpfadd_pending", Player.SteamID);
	}
	if(DataStore.Get("tpfrem_pending", Player.SteamID) != undefined){
		DataStore.Flush("tpfrem_numselected_" + Player.SteamID);
		DataStore.Remove("tpfrem_pending", Player.SteamID);
	}
	if(DataStore.Get("tpmaster_tpb", Player.SteamID) != undefined){
		DataStore.Remove("tpmaster_tpb", Player.SteamID);
	}
	if(DataStore.Get("tpmaster_queue", Player.SteamID) != undefined){
		DataStore.Remove("tpmaster_queue", Player.SteamID);
	}
};

var getPlayer = function(Player, cmd, args){
	var name = "";	
	for(var i=0;i<args.Length;i++){
		name += args[i] + " ";					
	}
	name = Data.Substring(name, 0, Data.StrLen(name) - 1);
	if(cmd != "tpb" && cmd != "tpy"){
		if(Data.ToLower(Player.Name) == Data.ToLower(name)){
			Player.Message("[color#FFA500]You can't select yourself!!");
			return "selectedself";
		}
	}
	for(var pl in Server.Players){
		if(Data.ToLower(pl.Name) == Data.ToLower(name)) {
			return pl;			
		}
	}
	return false;
};

var getPlayerB = function(Player, cmd, args){
	var name = "";
	var key, keyname;
	var values = DataStore.Keys("tpmaster_player");
	for(var i=0;i<args.Length;i++){
		name += args[i] + " ";					
	}
	name = Data.Substring(name, 0, Data.StrLen(name) - 1);	
	for(key in values){
		keyname = DataStore.Get("tpmaster_player", key);
		if(Data.ToLower(keyname) == Data.ToLower(name)) {
			return key;			
		}
	}
	return false;
};

var getFriend = function(Player, cmd, args){
	var name = "";	
	for(var i=0;i<args.Length;i++){
		name += args[i] + " ";					
	}
	name = Data.Substring(name, 0, Data.StrLen(name) - 1);	
	if(Data.ToLower(Player.Name) == Data.ToLower(name)){
		Player.Message("[color#FFA500]You can't select yourself!!");
		return "selectedself";
	}	
	if(cmd == "tpf" || cmd == "tpfrem"){
		if(!Plugin.IniExists("TPFriends\\" + Player.SteamID)){
			Player.Message("[color#FFA500]You dont have a TP Friends list yet!");
			return;
		}
		else{
			var tpfLog = Plugin.GetIni("TPFriends\\" + Player.SteamID);
		}
		var logsection = tpfLog.EnumSection("tpfriends");
		var sid = "tpfriends";
	}
	else if(cmd == "tpa" || cmd == "tpd"){
		if(!Plugin.IniExists("TPRequests\\" + Player.SteamID)){
			Player.Message("[color#FFA500]You dont have any requests yet!");
			return;
		}
		else{
			var reqLog = Plugin.GetIni("TPRequests\\" + Player.SteamID);
		}
		var logsection = reqLog.EnumSection("tprequests");
		var sid = "tprequests";
	}
	var key, ids;
	for(key in logsection){
		if(cmd == "tpf" || cmd == "tpfrem"){
			ids = tpfLog.GetSetting("tpfriends", key);
		}
		else if(cmd == "tpa" || cmd == "tpd"){
			ids = reqLog.GetSetting("tprequests", key);
		}
		if(Data.ToLower(key) == Data.ToLower(name)){
			if(cmd == "tpfrem"){
				tpfLog.DeleteSetting("tpfriends", key);	
				tpfLog.Save();				
				return name;
			}
			else if(cmd == "tpf"){
				var friend = Magma.Player.FindBySteamID(ids);
				if(friend == undefined){
					Player.Message("[color#FFA500]Your friend is not currently online");
					return;
				}
				else{
					friendCheck(Player, friend);					
					return;
				}
			}
			else if(cmd == "tpa"){
				var friend = Magma.Player.FindBySteamID(ids);
				if(friend == undefined){
					Player.Message("[color#FFA500]Your friend is not currently online");
					return;
				}
				else{
					tpfriend(friend, Player);
					reqLog.DeleteSetting("tprequests", key);
					DataStore.Remove("tpa_pending_" + friend.SteamID, friend.SteamID);
					reqLog.Save();
					return;
				}
			}
			else if(cmd == "tpd"){
				var friend = Magma.Player.FindBySteamID(ids);
				if(friend == undefined){
					Player.Message("[color#FFA500]Your friend is not currently online");
					return;
				}
				else{
					reqLog.DeleteSetting("tprequests", key);
					DataStore.Remove("tpa_pending_" + friend.SteamID, friend.SteamID);
					Player.Message("[color#FFA500]" + key + "'s teleport request was denied");
					friend.Message("[color#FFA500]" + Player.Name + " denied your teleport request");
					reqLog.Save();
					return;
				}
			}			
		}
	}
	return false;	
};

var tpRequest = function(Player, pl){
	if(!Plugin.IniExists("TPRequests\\" + pl.SteamID)){
		var reqLog = Plugin.CreateIni("TPRequests\\" + pl.SteamID);
	}
	else{
		var reqLog = Plugin.GetIni("TPRequests\\" + pl.SteamID);
	}
	Player.Message("[color#6AFB92]Teleport request sent to " + pl.Name);
	pl.Notice(Player.Name + " has requested to teleport to you");
	pl.Message("[color#6AFB92]Type [color#FFFFFF]/tpa [color#6AFB92]to accept, or [color#FFFFFF]/tpd [color#6AFB92]to deny");				
	DataStore.Add("tpa_pending_" + Player.SteamID, Player.SteamID, pl.SteamID);
	reqLog.AddSetting("tprequests", Player.Name, Player.SteamID);
	reqLog.Save();
	return;
};

var tpMasterFundsCheck = function(Player){
	var tpmCFG = Plugin.GetIni("TPMasterCFG");
	if(tpmCFG.GetSetting("settings", "economy_enabled") == "on"){
		var mdTPcost = parseInt(tpmCFG.GetSetting("economy", "magma_dollar"));
		var kkTPcost = parseInt(tpmCFG.GetSetting("economy", "KKMoney"));
		var rmTPcost = parseInt(tpmCFG.GetSetting("economy", "RustMoney"));
		var rmgiqTPcost = parseInt(tpmCFG.GetSetting("economy", "RustMoneyGiQ"));
		if(mdTPcost > 0){
			if(GetMoney(Player) < mdTPcost){
				Player.Notice("You need another $" + (mdTPcost - GetMoney(Player)) + " before you can TP");
				return false;
			}
			else{
				Player.Message("You will be charged $" + mdTPcost + " when you teleport");
				return true;
			}
		}
		else if(kkTPcost > 0){
			if(PullMoney(Player) < kkTPcost){
				Player.Notice("You need another $" + (kkTPcost - PullMoney(Player)) + " before you can TP");
				return false;
			}
			else{
				Player.Message("You will be charged [color #00FFFF]$" + kkTPcost + " [color #FFFFFF]when you teleport");
				return true;
			}
		}
		else if(rmTPcost > 0){
			if(RmGetBank(Player) < rmTPcost){
				Player.Notice("You need another $" + (rmTPcost - RmGetBank(Player)) + " before you can TP");
				return false;
			}
			else{				
				Player.Message("You will be charged $" + rmTPcost + "when you teleport");
				return true;
			}
		}
		else if(rmgiqTPcost > 0){
			if(RmGetBank(Player) < rmgiqTPcost){
				Player.Notice("You need another $" + (rmgiqTPcost - RmGetBank(Player)) + " before you can TP");
				return false;
			}
			else{				
				Player.Message("You will be charged $" + rmgiqTPcost + "when you teleport");
				return true;
			}
		}
	}
	else{
		return true;
	}
};

var tpMasterFundsRemove = function(pl){
	var tpmCFG = Plugin.GetIni("TPMasterCFG");
	if(tpmCFG.GetSetting("settings", "economy_enabled") == "on"){
		var mdTPcost = parseInt(tpmCFG.GetSetting("economy", "magma_dollar"));
		var kkTPcost = parseInt(tpmCFG.GetSetting("economy", "KKMoney"));
		var rmTPcost = parseInt(tpmCFG.GetSetting("economy", "RustMoney"));
		var rmgiqTPcost = parseInt(tpmCFG.GetSetting("economy", "RustMoneyGiQ"));
		if(mdTPcost > 0){
			if(GetMoney(pl) < mdTPcost){
				pl.Notice("You need another $" + (mdTPcost - GetMoney(pl)) + " before you can TP");
				return false;
			}
			else{
				RemoveMoney(pl, mdTPcost);
				pl.Message("You have been charged $" + mdTPcost + "for this teleport");
				return true;
			}
		}
		else if(kkTPcost > 0){
			if(PullMoney(pl) < kkTPcost){
				pl.Notice("You need another $" + (kkTPcost - PullMoney(pl)) + " before you can TP");
				return false;
			}
			else{
				pl.Message("You have been charged [color #00FFFF]$" + kkTPcost + " [color #FFFFFF]for this teleport");
				RemoveMoney(pl, kkTPcost);
				return true;
			}
		}
		else if(rmTPcost > 0){
			if(RmGetBank(pl) < rmTPcost){
				pl.Notice("You need another $" + (rmTPcost - RmGetBank(pl)) + " before you can TP");
				return false;
			}
			else{
				RmRemoveBank(pl, rmTPcost);
				pl.Message("You have been charged $" + rmTPcost + "for this teleport");
				return true;
			}
		}
		else if(rmgiqTPcost > 0){
			if(RmGetBank(pl) < rmgiqTPcost){
				pl.Notice("You need another $" + (rmgiqTPcost - RmGetBank(pl)) + " before you can TP");
				return false;
			}
			else{
				RmRemoveBank(pl, rmgiqTPcost);
				pl.Message("You have been charged $" + rmgiqTPcost + "for this teleport");
				return true;
			}
		}
	}
	else{
		return true;
	}
};

var defineStructOwner = function(Player, cmd){
	var masters, type;
    var xml, start, stop, name;    
    Util.TryFindType('StructureMaster', type);
    masters = UnityEngine.Object.FindObjectsOfType(type);
	if(masters.Length < 1) { Player.Message('No structures found. Weird.'); return false; }
	Player.Message("[color#FFFF00]" + masters.Length + " structures found");
	DataStore.Flush("tpmaster_homes");
	for(var i=0; i < masters.Length; i++) {
		if(DataStore.Get("tpmaster_homes", masters[i].ownerID.ToString()) == undefined){
			DataStore.Add("tpmaster_homes", masters[i].ownerID.ToString(), 1);
		}
        name = DataStore.Get("tpmaster_player", masters[i].ownerID.ToString()); 
        if(String(name).indexOf('null') != -1 || String(name).indexOf('undefined') != -1) { // nothing stored yet
			if(RustPP.Core.userCache != null) {
				Plugin.Log('structOwner', 'Checking Rust++ userCache names for ' + masters[i].ownerID.ToString());
				for(var key in RustPP.Core.userCache.Keys) {
					if(key.Equals(masters[i].ownerID)) {
						name = RustPP.Core.userCache[key];
						DataStore.Add("tpmaster_player", masters[i].ownerID.ToString(), name);
					}
				}				
			}
		}
        if(String(name).indexOf('null') != -1 || String(name).indexOf('undefined') != -1) { // still nothing
            Plugin.Log('structOwner', 'Getting name for ' + masters[i].ownerID.ToString() + ' from Steam API');
            xml = String(Web.GET('http://' + 'steamcommunity.com/profiles/' + masters[i].ownerID.ToString() + '/?xml=1\\'));
            start = xml.indexOf('CDATA[') + 6;
            stop = xml.indexOf(']]>', start);
            name = xml.substring(start, stop);
			if(name === '' && xml.indexOf('<privacyMessage>') != -1){
                name = '(no public profile)';
            }
            DataStore.Add("tpmaster_player", masters[i].ownerID.ToString(), name); 
        }		
    }
	return;
};

var structSelect = function(Player, cmd){
	Player.Message("Type number in chat to make selection");
	Player.Message("or type [color#6AFB92]c [color#FFFFFF]to cancel the selection");
	Player.Message("or type [color#6AFB92]r [color#FFFFFF]to relist selection");
	Player.Message("#########################################");
	var masters, type, ownerID;
	var num = 0;
	var str = "";
	Util.TryFindType('StructureMaster', type);
    masters = UnityEngine.Object.FindObjectsOfType(type);
	ownerID = DataStore.Get("struct_owner_selected", Player.SteamID);
	for(var i=0; i < masters.Length; i++) {
		if(masters[i].ownerID.ToString() == ownerID){
			num++;
			Player.Message("[color#6AFB92][" + num + "] [color#FFFFFF]" + DataStore.Get("tpmaster_player", ownerID) + "s  structure # " + num);			
			DataStore.Add(cmd + "_numselected_" + Player.SteamID, String(masters[i].containedBounds.max), num);			
		}
	}
	DataStore.Add(cmd + "_pending", Player.SteamID, true);
	return;
};

var addLocation = function(Player, locationName) {
	var loc = [ Player.X, Player.Y + 2, Player.Z ];
	DataStore.Add("tp_locations" + Player.SteamID, locationName, loc);
	var ini;
	if(!Plugin.IniExists("TPLocations\\" + Player.SteamID)) {
		ini = Plugin.CreateIni("TPLocations\\" + Player.SteamID);
		ini.Save();
	}
	ini = Plugin.GetIni("TPLocations\\" + Player.SteamID);
	ini.AddSetting("locations", locationName, Player.Location.ToString());
	ini.Save();
};

var getLocation = function(Player, locationName) {
	var loc = DataStore.Get("tp_locations" + Player.SteamID, locationName);
	var ini, keys, vstr, varr;
	if(!loc && Plugin.IniExists("TPLocations\\" + Player.SteamID)) {
		ini = Plugin.GetIni("TPLocations\\" + Player.SteamID);
		keys = ini.EnumSection("locations");
		for(var i=0; i < keys.Length; i++) {
			vstr = ini.GetSetting("locations", keys[i]);
			varr = vstr.replace(/[() ]/g, "").split(",");			
			loc = [ parseFloat(varr[0]), parseFloat(varr[1]), parseFloat(varr[2]) ];
			DataStore.Add("tp_locations" + Player.SteamID, keys[i], loc);
		}
		loc = DataStore.Get("tp_locations" + Player.SteamID, locationName);
	}
	return loc;
};

var removeLocation = function(Player, locationName) {
	if(!Plugin.IniExists("TPLocations\\" + Player.SteamID)) {
		return;
	}
	var ini = Plugin.GetIni("TPLocations\\" + Player.SteamID);
	ini.DeleteSetting("locations", locationName);
	ini.Save();
	DataStore.Remove("tp_locations" + Player.SteamID, locationName);
};
