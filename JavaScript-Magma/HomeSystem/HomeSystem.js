/**
 *		Homejobs plugin addon written and integrated by BadZombi for HomeSystem V2.0.1 (DreTaX)
 *  	--
 */
var HomeSystem = {
    name: 		'HomeSystem',
    author: 	'DreTaX',
    version: 	'2.4.7'
};

var BZHJ = {
    name: 		'Home Jobs',
    author: 	'BadZombi',
    version: 	'0.1.2',
    DStable: 	'BZjobs',
    addJob: function(callback, xtime, params) {
		if (callback && xtime && params) {
			var jobData = {};
			jobData.callback = String(callback);
			jobData.params = String(params);
			var epoch = Plugin.GetTimestamp();
			var exectime = parseInt(epoch) + parseInt(xtime);
			DataStore.Add(this.DStable, exectime, iJSON.stringify(jobData));
			this.startTimer();
		}
    },
    killJob: function(job) {
        var pending = DataStore.Keys(this.DStable);
        for (var p in pending) {
            var jobData = DataStore.Get(this.DStable, p);
            var jobxData = iJSON.parse(jobData);
            var params = iJSON.parse(jobxData.params);
            if (params[0] == job) {
                DataStore.Remove(this.DStable, p);
                break;
            }
        }
    },
    startTimer: function(){
        try {
			var config = HomeConfig();
            var gfjfhg = config.GetSetting("Settings", "run_timer") * 1000;
            if(!Plugin.GetTimer("JobTimer")){
                Plugin.CreateTimer("JobTimer", gfjfhg).Start();
            }
        } catch(err){
            Util.ConsoleLog(err.message);
            //Plugin.Log("HomeSystem", "Crap: " + err.message);
        }
    },
    stopTimer: function(P) {
        Plugin.KillTimer("JobTimer");
    },
	getPlayer: function(stam) {
		try {
			for (var player in Server.Players) {
				//var id = player.SteamID;
				if (player.SteamID == stam) {
					return player;
				}
			}
			return null;
		} catch(err) {
			//Plugin.Log("HomeSystemError", "Error caught at getPlayer method. Player was null, removing it from the timer.");
			return null;
		}
    },
    clearTimers: function(P){
        P.Message("Erasing all example timers.");
        DataStore.Flush(this.DStable);
    }
};

function On_PluginInit() {
    DataStore.Flush("BZjobs");
    Util.ConsoleLog(BZHJ.name + " v" + BZHJ.version + " by " + BZHJ.author + " loaded.", true);
    Util.ConsoleLog(HomeSystem.name + " v" + HomeSystem.version + " by " + HomeSystem.author  + " loaded.", true);
}

function JobTimerCallback(){
    var epoch = Plugin.GetTimestamp();
	if(DataStore.Count(BZHJ.DStable) >= 1) {
        var pending = DataStore.Keys(BZHJ.DStable);
		var config = HomeConfig();
        var homesystemname = config.GetSetting("Settings", "homesystemname");
		for (var p in pending) {
			if (epoch >= parseInt(p)) {
				var jobData = DataStore.Get(BZHJ.DStable, p);
				var jobxData;
				var params;
				try {
					jobxData = iJSON.parse(jobData);
					// Lets do the shitty checks here
					if(jobxData.params == "undefined" || jobxData.params == undefined || jobxData.params == null)
					{
						DataStore.Remove(BZHJ.DStable, p);
						continue;
					}
					params = iJSON.parse(jobxData.params);
				} catch(err) {
					if (DataStore.Get(BZHJ.DStable, p)) {
                        DataStore.Remove(BZHJ.DStable, p);
                    }
					continue;
				}
				//try {
					switch(jobxData.callback) {
						case "jointpdelay":
							//var checkn = config.GetSetting("Settings", "safetpcheck");
							var joinplayer = BZHJ.getPlayer(params[0]);
							if (joinplayer != null) {
								DataStore.Add("homesystemautoban", params[0], "using");
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								joinplayer.SafeTeleportTo(loc);
                                DataStore.Add("homesystemautoban", params[0], "none");
								//BZHJ.addJob('jointp', checkn, jobxData.params);
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "jointp":
							var checkn = config.GetSetting("Settings", "safetpcheck");
							var joinplayer = BZHJ.getPlayer(params[0]);
							if (joinplayer != null) {
								DataStore.Add("homesystemautoban", params[0], "using");
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								joinplayer.SafeTeleportTo(loc);
								joinplayer.MessageFrom(homesystemname, "You have been teleported here again for safety reasons in: " + checkn + " secs");
                                DataStore.Add("homesystemautoban", params[0], "none");
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "mytestt":
							var checkn = config.GetSetting("Settings", "safetpcheck");
							var _fromPlayer = BZHJ.getPlayer(params[0]);
							if (_fromPlayer != null) {
								//DataStore.Add("homesystemautoban", params[0], "using");
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								_fromPlayer.SafeTeleportTo(loc);
								_fromPlayer.MessageFrom(homesystemname, "You have been teleported here again for safety reasons in: " + checkn + " secs");
                                DataStore.Add("homesystemautoban", params[0], "none");
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "randomtp":
							var checkn = config.GetSetting("Settings", "safetpcheck");
							var rplayer = BZHJ.getPlayer(params[0]);
							if (rplayer != null) {
								DataStore.Add("homesystemautoban", params[0], "using");
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								rplayer.SafeTeleportTo(loc);
								rplayer.MessageFrom(homesystemname, "You have been teleported here again for safety reasons in: " + checkn + " secs");
                                DataStore.Add("homesystemautoban", params[0], "none");
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "delay":
						    //var checkn = config.GetSetting("Settings", "safetpcheck");
							var _fromPlayer = BZHJ.getPlayer(params[0]);
							var movec = config.GetSetting("Settings", "movecheck");
							if (_fromPlayer != null) {
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								if (movec == 1) {
									var location = _fromPlayer.Location;
									var before = params[4];
									if (before != location) {
										_fromPlayer.Notice("You were moving!");
										//Data.AddTableValue("home_cooldown", _fromPlayer.SteamID, 7);
										DataStore.Add("home_cooldown", params[0], 7);
										BZHJ.killJob(params[0]);
									}
									else {
										DataStore.Add("homesystemautoban", params[0], "using");
										_fromPlayer.SafeTeleportTo(loc);
										_fromPlayer.Notice("You have been teleported home.");
                                        DataStore.Add("homesystemautoban", params[0], "none");
										//BZHJ.addJob('mytestt', checkn, jobxData.params);
									}
								}
								else {
									DataStore.Add("homesystemautoban", params[0], "using");
									_fromPlayer.SafeTeleportTo(loc);
									_fromPlayer.Notice("You have been teleported home.");
                                    DataStore.Add("homesystemautoban", params[0], "none");
									//BZHJ.addJob('mytestt', checkn, jobxData.params);
								}
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "randomtpdelay":
							var checkn = config.GetSetting("Settings", "safetpcheck");
							var rplayer = BZHJ.getPlayer(params[0]);
							if (rplayer != null) {
								DataStore.Add("homesystemautoban", params[0], "using");
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								rplayer.SafeTeleportTo(loc);
								rplayer.MessageFrom(homesystemname, "You have been teleported to a random location!");
								rplayer.MessageFrom(homesystemname, "Type /setdefaulthome HOMENAME");
								rplayer.MessageFrom(homesystemname, "To spawn at your home!");
                                DataStore.Add("homesystemautoban", params[0], "none");
								//BZHJ.addJob('randomtp', checkn, jobxData.params);
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "spawndelay":
							var checkn = config.GetSetting("Settings", "safetpcheck");
							var spawntpplayer = BZHJ.getPlayer(params[0]);
							if (spawntpplayer != null) {
								DataStore.Add("homesystemautoban", params[0], "using");
								var loc = Util.CreateVector(params[1], params[2], params[3]);
								spawntpplayer.SafeTeleportTo(loc);
								spawntpplayer.MessageFrom(homesystemname, "You have been teleported here again for safety reasons in: " + checkn + " secs");
                                DataStore.Add("homesystemautoban", params[0], "none");
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;

						case "ByPassRoof":
							var joinp = BZHJ.getPlayer(params[0]);
							if (joinp != null) {
								var cooldown = config.GetSetting("Settings", "rejoincd");
								//var time = Data.GetTableValue("home_joincooldown", joinp.SteamID);
								var time = DataStore.Get("home_joincooldown", params[0]);
								var calc = System.Environment.TickCount - time;
								if (time == undefined || time == null || calc < 0 || isNaN(calc)) {
									//time = Data.AddTableValue("home_cooldown", Player.SteamID, System.Environment.TickCount);
									time = DataStore.Add("home_cooldown", params[0], System.Environment.TickCount);
								}
								if (System.Environment.TickCount <= time + cooldown * 1000){
									var calc2 = cooldown * 1000;
									var calc3 = (calc2 - calc) / 1000;
									var done = Number(calc3).toFixed(2);
									BZHJ.killJob(params[0]);
									joinp.MessageFrom(homesystemname, "There is a " + cooldown + " cooldown at join. You can't join till: " + done + " more seconds.");
									joinp.Disconnect();
									// I THINK this will work. removing the current job rather than killing the timer.
									// Plugin.KillTimer("ByPassRoof");
								}
								if (System.Environment.TickCount > time + cooldown * 1000 || time == null) {
									DataStore.Add("homesystemautoban", params[0], "using");
									var randomloc = config.GetSetting("Settings", "randomlocnumber");
									//Data.AddTableValue("home_joincooldown", joinp.SteamID, null);
									DataStore.Add("home_joincooldown", params[0], 7);
									var random = Math.floor((Math.random() * randomloc) + 1);
									var ini = Homes();
									var getdfhome = ini.GetSetting("DefaultHome", params[0]);
									var checkn = config.GetSetting("Settings", "safetpcheck");
									var tpdelay = config.GetSetting("Settings", "jointpdelay");
									if (getdfhome != null) {
										var home = HomeOf(joinp, getdfhome);
										// first test of jobs:
										var jobParams = [];
										jobParams.push(String(params[0]));
										jobParams.push(String(home[0]));
										jobParams.push(String(home[1]));
										jobParams.push(String(home[2]));

										BZHJ.addJob('jointpdelay', tpdelay, iJSON.stringify(jobParams));
									}
									else {
										var ini2 = DefaultLoc();
										var loc = ini2.GetSetting("DefaultLoc", random);
										var c = loc.replace("(", "");
										c = c.replace(")", "");
										var tp = c.split(",");

										var jobParams = [];
										jobParams.push(String(params[0]));
										jobParams.push(String(tp[0]));
										jobParams.push(String(tp[1]));
										jobParams.push(String(tp[2]));

										BZHJ.addJob('randomtpdelay', tpdelay, iJSON.stringify(jobParams));
									}
								}
							}
							else {
								DataStore.Add("homesystemautoban", params[0], "none");
								BZHJ.killJob(params[0]);
							}
						break;
						
					}
					DataStore.Remove(BZHJ.DStable, p);
				/*} catch(err) {
					BZHJ.killJob(params[0]);
					//Plugin.Log("HomeSystemError", "Error caught at Jobtimer method. Job removed.");
				}*/
			}
		}
    } else {
        BZHJ.stopTimer();
    }
}

/**
 * Created by DreTaX on 2014.04.18.. V2.2.2
 *
 */

function On_Command(Player, cmd, args) {
    switch(cmd) {
        case "cleartimers":
            if (Player.Admin) {
                BZHJ.clearTimers(Player);
            }
        break;
		
        case "home":
            if (args.Length == 0 || args.Length > 1) {
				var config = HomeConfig();
                var homesystemname = config.GetSetting("Settings", "homesystemname");
                Player.MessageFrom(homesystemname, "---HomeSystem---");
                Player.MessageFrom(homesystemname, "/home name - Teleport to Home");
                Player.MessageFrom(homesystemname, "/sethome name - Save Home");
                Player.MessageFrom(homesystemname, "/delhome name - Delete Home");
                Player.MessageFrom(homesystemname, "/setdefaulthome name - Default Spawn Point");
                Player.MessageFrom(homesystemname, "/homes - List Homes");
                Player.MessageFrom(homesystemname, "/addfriendh name - Adds Player To Distance Whitelist");
                Player.MessageFrom(homesystemname, "/delfriendh name - Removes Player From Distance Whitelist");
                Player.MessageFrom(homesystemname, "/listwlh - List Players On Distance Whitelist");
            }
            else if (args.Length > 0) {
				var config = HomeConfig();
                var homesystemname = config.GetSetting("Settings", "homesystemname");
                var home = args[0].toString();
                var check = HomeOf(Player, home);
                var id = Player.SteamID;
				var loc = Player.Location;
                if (check == null) {
                    Player.MessageFrom(homesystemname, "You don't have a home called: " + home);
                }
                else {
                    //try {
                        var cooldown = config.GetSetting("Settings", "Cooldown");
                        //var time = Data.GetTableValue("home_cooldown", Player.SteamID);
						var time = DataStore.Get("home_cooldown", id);
                        var tpdelay = config.GetSetting("Settings", "tpdelay");
                        var calc = System.Environment.TickCount - time;
                        if (time == undefined || time == null || calc < 0 || isNaN(calc) || isNaN(time)) {
                            //time = Data.AddTableValue("home_cooldown", Player.SteamID, null);
							time = DataStore.Add("home_cooldown", id, 7);
							calc = 0;
                        }

                        if (calc >= cooldown || calc == 0) {
                            var checkn = config.GetSetting("Settings", "safetpcheck");
                            var jobParams = [];
                            jobParams.push(String(id));
                            jobParams.push(String(check[0]));
                            jobParams.push(String(check[1]));
                            jobParams.push(String(check[2]));
                            jobParams.push(String(loc));

                            if (tpdelay == 0) {
								DataStore.Add("homesystemautoban", id, "using");
                                var loc = Util.CreateVector(check[0], check[1], check[2]);
								Player.SafeTeleportTo(loc);
                                //Data.AddTableValue("home_cooldown", Player.SteamID, System.Environment.TickCount);
								DataStore.Add("home_cooldown", id, System.Environment.TickCount);
                                Player.MessageFrom(homesystemname, "Teleported to home!");
                                DataStore.Add("homesystemautoban", id, "none");
                                //BZHJ.addJob('mytestt', checkn, iJSON.stringify(jobParams));
                            }
                            else {
                                //Data.AddTableValue("home_cooldown", Player.SteamID, System.Environment.TickCount);
								DataStore.Add("home_cooldown", id, System.Environment.TickCount);
                                BZHJ.addJob('delay', tpdelay, iJSON.stringify(jobParams));
                                Player.MessageFrom(homesystemname, "Teleporting you to home in: " + tpdelay + " seconds");
                            }
                        } 
						else {
                            Player.Notice("You have to wait before teleporting again!");
                            var next = calc / 1000;
                            var next2 = next / 60;
                            var def = cooldown / 1000;
                            var def2 = def / 60;
                            var done = Number(next2).toFixed(2);
                            var done2 = Number(def2).toFixed(2);
                            Player.MessageFrom(homesystemname, "Time: " + done + "/" + done2);
                        }
                    /*} catch(err) {
                        if (Player.Admin) {
                            Player.Message("Console Errors Logged!");
                            Player.Message(err.message);
                            Player.Message(err.description);
                        }
                        Util.ConsoleLog(err.message + " : " + err.description);
                    }*/
                }
            }
        break;
		
        case "sethome":
            //try {
				if (args.Length == 0 || args.Length > 1) {
					var config = HomeConfig();
					var homesystemname = config.GetSetting("Settings", "homesystemname");
					Player.MessageFrom(homesystemname, "Usage: /sethome name");
					return;
				}
                else if (args.Length > 0) {
					var config = HomeConfig();
                    var homesystemname = config.GetSetting("Settings", "homesystemname");
                    var home = args[0].toString();
                    var ini = Homes();
                    var id = Player.SteamID;
                    var maxh = DonatorRankCheck(id);
                    //var maxh = config.GetSetting("Settings", "Maxhomes");
                    var checkforit = config.GetSetting("Settings", "DistanceCheck");
					var checkwall = config.GetSetting("Settings", "CheckCloseWall");
					// Check if this shit is null before making mistakes -.-
					if (!CheckIfEmpty(id)) {
						if (checkforit == 1) {
                            var checkdist = ini.EnumSection("HomeNames");
                            var counted = checkdist.Length;
                            var i = 0;
                            var maxdist = config.GetSetting("Settings", "Distance");
                            maxdist = parseInt(maxdist);
                            if (checkwall == 1) {
                                for (var entity in World.Entities) {
                                    if (entity.Name == "MetalWall" || entity.Name == "WoodWall") {
                                        var loc = Util.CreateVector(entity.X, entity.Y, entity.Z);
                                        var distance = Util.GetVectorsDistance(loc, Player.Location);
                                        if (distance <= 1.50) {
                                            Player.MessageFrom(homesystemname, "You can't set home near walls!");
                                            return;
                                        }
                                    }
                                }
                            }
                            if (counted > 0 && checkdist) {
                                for (var idof in checkdist) {
                                    i++;
                                    var homes = ini.GetSetting("HomeNames", idof);
                                    if (homes) {
                                        homes = homes.replace(",", "");
                                        var check = HomeOfID(idof, homes);
                                        var vector = Util.CreateVector(check[0], check[1], check[2]);
                                        var dist = Util.GetVectorsDistance(vector, Player.Location);
                                        if (dist <= maxdist && !FriendOf(idof, id) && idof != id) {
                                            Player.MessageFrom(homesystemname, "There is a home within: " + maxdist + "m!");
                                            return;
                                        }
                                        if (i == counted) {
                                            //var homes = ini.GetSetting("HomeNames", id, home);
											var homes = ini.GetSetting("HomeNames", id);
                                            var n = homes + "" + home + ",";
                                            ini.AddSetting(id, home, Player.Location.toString());
                                            ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
                                            ini.Save();
                                            Player.MessageFrom(homesystemname, "Home Saved");
											return;
                                        }
                                    }
									else {
										ini.DeleteSetting("HomeNames", idof);
										ini.Save();
									}
                                }
                            } else {
                                //var homes = ini.GetSetting("HomeNames", id, home);
								var homes = ini.GetSetting("HomeNames", id);
                                var n = homes + "" + home + ",";
                                ini.AddSetting(id, home, Player.Location.toString());
                                ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
                                ini.Save();
                                Player.MessageFrom(homesystemname, "Home Saved");
								return;
                            }
                        }
                        else {
                            if (checkwall == 1) {
                                for (var entity in World.Entities) {
                                    if (entity.Name == "MetalWall" || entity.Name == "WoodWall") {
                                        var loc = Util.CreateVector(entity.X, entity.Y, entity.Z);
                                        var distance = Util.GetVectorsDistance(loc, Player.Location);
                                        if (distance <= 1.50) {
                                            Player.MessageFrom(homesystemname, "You can't set home near walls!");
                                            return;
                                        }
                                    }
                                }
                            }
							var homes = ini.GetSetting("HomeNames", id);
							var n = homes + "" + home + ",";
							ini.AddSetting(id, home, Player.Location.toString());
                            ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
                            ini.Save();
                            Player.MessageFrom(homesystemname, "Home Saved");
							return;
                        }
					}
					else {
						var homel = ini.EnumSection(id);
						var count = homel.Length;
						var parsed = parseInt(count);
						var parsedd = parseInt(maxh);
						if (parsed >= parsedd) {
							Player.MessageFrom(homesystemname, "You reached the max home limit. (" + maxh + ")");
							return;
						}
						else {
							if (checkforit == 1) {
								var checkdist = ini.EnumSection("HomeNames");
								var counted = checkdist.Length;
								var i = 0;
								var maxdist = config.GetSetting("Settings", "Distance");
								maxdist = parseInt(maxdist);
								if (checkwall == 1) {
									for (var entity in World.Entities) {
										if (entity.Name == "MetalWall" || entity.Name == "WoodWall") {
											var loc = Util.CreateVector(entity.X, entity.Y, entity.Z);
											var distance = Util.GetVectorsDistance(loc, Player.Location);
											if (distance <= 1.50) {
												Player.MessageFrom(homesystemname, "You can't set home near walls!");
												return;
											}
										}
									}
								}
								if (counted > 0) {
									for (var idof in checkdist) {
										i++;
										var homes = ini.GetSetting("HomeNames", idof);
										if (homes) {
											var splitit = homes.split(',');
											if (splitit.length >= 2) {
												for (var inter = 0; inter < splitit.length; inter++){
													var check = HomeOfID(idof, splitit[inter]);
													var vector = Util.CreateVector(check[0], check[1], check[2]);
													var dist = Util.GetVectorsDistance(vector, Player.Location);
													if (dist <= maxdist && !FriendOf(idof, id) && idof != id) {
														Player.MessageFrom(homesystemname, "There is a home within: " + maxdist + "m!");
														return;
													}
													if (i == counted) {
														//var homes = ini.GetSetting("HomeNames", id, home);
														var homes = ini.GetSetting("HomeNames", id);
														var n = homes + "" + home + ",";
														ini.AddSetting(id, home, Player.Location.toString());
														ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
														ini.Save();
														Player.MessageFrom(homesystemname, "Home Saved");
														return;
													}
												}
											}
											else {
												homes = homes.replace(",", "");
												var check = HomeOfID(idof, homes);
												var vector = Util.CreateVector(check[0], check[1], check[2]);
												var dist = Util.GetVectorsDistance(vector, Player.Location);
												if (dist <= maxdist && !FriendOf(idof, id) && idof != id) {
													Player.MessageFrom(homesystemname, "There is a home within: " + maxdist + "m!");
													return;
												}
												if (i == counted) {
													//var homes = ini.GetSetting("HomeNames", id, home);
													var homes = ini.GetSetting("HomeNames", id);
													var n = homes + "" + home + ",";
													ini.AddSetting(id, home, Player.Location.toString());
													ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
													ini.Save();
													Player.MessageFrom(homesystemname, "Home Saved");
												}
											}
										}
										else {
											ini.DeleteSetting("HomeNames", idof);
											ini.Save();
										}
									}
								} else {
									var homes = ini.GetSetting("HomeNames", id);
									var n = homes + "" + home + ",";
									ini.AddSetting(id, home, Player.Location.toString());
									ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
									ini.Save();
									Player.MessageFrom(homesystemname, "Home Saved");
								}
							}
							else {
								if (checkwall == 1) {
									for (var entity in World.Entities) {
										if (entity.Name == "MetalWall" || entity.Name == "WoodWall") {
											var loc = Util.CreateVector(entity.X, entity.Y, entity.Z);
											var distance = Util.GetVectorsDistance(loc, Player.Location);
											if (distance <= 1.50) {
												Player.MessageFrom(homesystemname, "You can't set home near walls!");
												return;
											}
										}
									}
								}
								//var homes = ini.GetSetting("HomeNames", id, home);
								var homes = ini.GetSetting("HomeNames", id);
								var n = homes + "" + home + ",";
								ini.AddSetting(id, home, Player.Location.toString());
								ini.AddSetting("HomeNames", id, n.replace("undefined", ""));
								ini.Save();
								Player.MessageFrom(homesystemname, "Home Saved");
							}
						}
					}
                }
            /*} catch(err) {
                if (Player.Admin) {
                    Player.Message("Console Errors Logged!");
                    Player.Message(err.message);
                    Player.Message(err.description);
                }
                Util.ConsoleLog(err.message + " : " + err.description);
                //Plugin.Log("HomeSystem", "Crap: " + err.message + " : " + err.description);
            }*/
        break;
		
        case "setdefaulthome":
            if (args.Length > 0) {
				var config = HomeConfig();
                var homesystemname = config.GetSetting("Settings", "homesystemname");
                var home = args[0].toString();
                var check = HomeOf(Player, home);
                var id = Player.SteamID;
                if (check == null) {
                    Player.MessageFrom(homesystemname, "You don't have a home called: " + home);
                    return;
                }
                var ini = Homes();
                ini.AddSetting("DefaultHome", id, home);
                ini.Save();
                Player.MessageFrom(homesystemname, "Default Home Set!");
            }
            else {
				var config = HomeConfig();
				var homesystemname = config.GetSetting("Settings", "homesystemname");
                Player.MessageFrom(homesystemname, "Usage: /setdefaulthome name");
            }
        break;
		
        case "delhome":
            if (args.Length == 1){
				var config = HomeConfig();
                var homesystemname = config.GetSetting("Settings", "homesystemname");
                var home = args[0].toString();
                var ini = Homes();
                var id = Player.SteamID;
                var check = ini.GetSetting(id, home);
                var ifdfhome = ini.GetSetting("DefaultHome", id);
                if (check != null) {
                    if (ifdfhome != null) {
                        ini.DeleteSetting("DefaultHome", id);
                    }
                    var homes = ini.GetSetting("HomeNames", id);
					var second = homes.replace(home+",", "");
                    ini.DeleteSetting(id, home);
					if (!second) {
						ini.DeleteSetting("HomeNames", id);
					}
					else {
						ini.AddSetting("HomeNames", id, second);
					}
                    ini.Save();
                    Player.MessageFrom(homesystemname, "Home: " + home + " Deleted");
                }
                else {
                    Player.MessageFrom(homesystemname, "Home: " + home + " doesn't exists!");
                }
            } else {
				var config = HomeConfig();
                var homesystemname = config.GetSetting("Settings", "homesystemname");
                Player.MessageFrom(homesystemname, "Usage: /delhome name");
            }
        break;
		
        case "homes":
			var config = HomeConfig();
            var homesystemname = config.GetSetting("Settings", "homesystemname");
            var ini = Homes();
            var id = Player.SteamID;
            if (ini.GetSetting("HomeNames", id) != null) {
                var homes = ini.GetSetting("HomeNames", id).split(',');
                for(var h in homes) {
                    Player.MessageFrom(homesystemname, "Homes: " + homes[h]);
                }
            }
            else {
                Player.MessageFrom(homesystemname, "You don't have homes!");
            }
        break;
		
        case "deletebeds":
			var config = HomeConfig();
            var homesystemname = config.GetSetting("Settings", "homesystemname");
            var antihack = config.GetSetting("Settings", "Antihack");
            if (Player.Admin && antihack == "1") {
                for (var x in World.Entities) {
                    if (x.Name == "SleepingBagA" || x.Name == "SingleBed") {
                        x.Destroy();
                        Player.MessageFrom(homesystemname, "Deleted one");
                    }
                }
            }
        break;
		
        case "addfriendh":
			var config = HomeConfig();
            var homesystemname = config.GetSetting("Settings", "homesystemname");
            if (args.Length == 0) {
                Player.MessageFrom(homesystemname, "Usage: /addfriendh playername");
                return;
            }
            else if (args.Length > 0) {
                var playertor = GetPlayer(args[0]);
                if (playertor != null && playertor != Player) {
                    var ini = Wl();
                    var id = Player.SteamID;
                    ini.AddSetting(id, playertor.SteamID, playertor.Name);
                    ini.Save();
                    Player.MessageFrom(homesystemname, "Player Whitelisted");
                }
                else {
                    Player.MessageFrom(homesystemname, "Player doesn't exist, or you tried to add yourself!");
                }
            }
        break;
		
        case "delfriendh":
			var config = HomeConfig();
            var homesystemname = config.GetSetting("Settings", "homesystemname");
            if (args.Length == 0) {
                Player.MessageFrom(homesystemname, "Usage: /delfriendh playername");
                return;
            }
            else if (args.Length > 0) {
                var name = args[0].toString();
                var ini = Wl();
                var id = Player.SteamID;
                var players = ini.EnumSection(id);
                var i = 0;
                var counted = players.Length;
                name = Data.ToLower(name);
                for (var playerid in players) {
                    i++;
                    var nameof = ini.GetSetting(id, playerid);
                    var lowered = Data.ToLower(nameof);
                    if (lowered == name) {
                        ini.DeleteSetting(id, playerid);
                        ini.Save();
                        Player.MessageFrom(homesystemname, "Player Removed from Whitelist");
                        return;
                    }
                    if (i == counted) {
                        Player.MessageFrom(homesystemname, "Player doesn't exist!");
                        return;
                    }
                }
            }
        break;
		
        case "listwlh":
			var config = HomeConfig();
            var homesystemname = config.GetSetting("Settings", "homesystemname");
            var ini = Wl();
            var id = Player.SteamID;
            var players = ini.EnumSection(id);
            for (var playerid in players) {
                var nameof = ini.GetSetting(id, playerid);
                Player.MessageFrom(homesystemname, "Whitelisted: " + nameof);
            }
        break;
    }
}

function Homes(){
    if(!Plugin.IniExists("Homes")) {
        var homes = Plugin.CreateIni("Homes");
        homes.Save();
    }
    return Plugin.GetIni("Homes");
}

function FriendOf(id, selfid){
    var ini = Wl();
    var check = ini.GetSetting(id, selfid);
    if (check != null) {
        return true;
    }
    return false;
}

function Wl(){
    if(!Plugin.IniExists("WhiteListedPlayers")) {
        var homes = Plugin.CreateIni("WhiteListedPlayers");
        homes.Save();
    }
    return Plugin.GetIni("WhiteListedPlayers");
}

function DefaultLoc(){
    if(!Plugin.IniExists("DefaultLoc")) {
        var loc = Plugin.CreateIni("DefaultLoc");
        loc.Save();
    }
    return Plugin.GetIni("DefaultLoc");
}

/**
 * @return {null}
 */
function HomeOf(Player, Home){
    var ini = Homes();
    var check = ini.GetSetting(Player.SteamID, Home);
    if (check != null){
        var c = check.replace("(", "");
        c = c.replace(")", "");
        return c.split(",");
    }
    return null;
}

/**
 * @return {null}
 */
function HomeOfID(id, Home){
    var ini = Homes();
    var check = ini.GetSetting(id, Home);
    if (check != null){
        var c = check.replace("(", "");
        c = c.replace(")", "");
        return c.split(",");
    }
    return null;
}

function HomeConfig(){
    if(!Plugin.IniExists("HomeConfig")) {
        var homes = Plugin.CreateIni("HomeConfig");
        homes.Save();
    }
    return Plugin.GetIni("HomeConfig");
}

/**
 * @return {null}
 */
function GetPlayer(name){
    name = Data.ToLower(name);
    for(pl in Server.Players){
        if(Data.ToLower(pl.Name) == name){
            return pl;
        }
    }
    return null;
}

function CheckIfEmpty(id) {
	var ini = Homes();
	var checkdist = ini.EnumSection(id);
	for (var home in checkdist) {
		var homes = ini.GetSetting(id, home);
		if (homes && homes != null) {
            return true;
        }
		return false;
	}
}

function DonatorRankCheck(id) {
    if (DataStore.Get("MaxHomes", id) != null) {
        var maxh = DataStore.Get("MaxHomes", id);
        return maxh;
    } else {
        if (DataStore.Get("DonatorRank", "PlayerHomesMax") != null) {
            var maxh = DataStore.Get("DonatorRank", "PlayerHomesMax");
            return maxh;
        } else {
            var config = HomeConfig();
            var maxh = config.GetSetting("Settings", "Maxhomes");
            return maxh;
        }
    }
}

function On_EntityDeployed(Player, Entity) {
	var config = HomeConfig();
    var antihack = config.GetSetting("Settings", "Antihack");
    var homesystemname = config.GetSetting("Settings", "homesystemname");
	if (Entity != null && Player != null) {
		if (antihack == "1") {
			var inventory = Player.Inventory;
			if (Entity.Name == "SleepingBagA") {
				Player.MessageFrom(homesystemname, "Sleeping bags are banned from this server!");
				Player.MessageFrom(homesystemname, "Use /home");
				Player.MessageFrom(homesystemname, "We disabled Beds, so players can't hack in your house!");
				Player.MessageFrom(homesystemname, "You received 15 Cloth.");
				Entity.Destroy();
				inventory.AddItem("Cloth", 15);
			}
			if (Entity.Name == "SingleBed") {
				Player.MessageFrom(homesystemname, "Beds are banned from this server!");
				Player.MessageFrom(homesystemname, "Use /home");
				Player.MessageFrom(homesystemname, "We disabled Beds, so players can't hack in your house!");
				Player.MessageFrom(homesystemname, "You received 40 Cloth and 100 Metal Fragments.");
				Entity.Destroy();
				inventory.AddItem("Cloth", 40);
				inventory.AddItem("Metal Fragments", 100);
			}
		}
    }
}

function On_PlayerSpawned(Player, SpawnEvent) {
	var config = HomeConfig();
    var camp = SpawnEvent.CampUsed;
    var checkn = config.GetSetting("Settings", "safetpcheck");
    var homesystemname = config.GetSetting("Settings", "homesystemname");
    if (camp) {
		var id = Player.SteamID;
        var cooldown = config.GetSetting("Settings", "Cooldown");
        var time = Data.GetTableValue("home_cooldown", id);
        var calc = System.Environment.TickCount - time;
        if (time == undefined || time == null || calc < 0 || isNaN(calc)) {
            //time = Data.AddTableValue("home_cooldown", id, System.Environment.TickCount);
			time = DataStore.Add("home_cooldown", id, System.Environment.TickCount);
        }
        if (calc >= cooldown) {
            var ini = Homes();
            var check = ini.GetSetting("DefaultHome", id);
            if (check != null) {
                //Data.AddTableValue("home_cooldown", id, System.Environment.TickCount);
				DataStore.Add("home_cooldown", id, System.Environment.TickCount);
                var home = HomeOf(Player, check);

                var jobParams = [];
                jobParams.push(String(id));
                jobParams.push(String(home[0]));
                jobParams.push(String(home[1]));
                jobParams.push(String(home[2]));

                Player.TeleportTo(home[0], home[1], home[2]);
                Player.MessageFrom(homesystemname, "Spawned at home!");
                BZHJ.addJob('spawndelay', checkn, iJSON.stringify(jobParams));
            }
        }
    }
}

function On_PlayerConnected(Player) {
	var config = HomeConfig();
	var jobParams = [];
	var jointpdelay = config.GetSetting("Settings", "jointpdelay");
	var id;
	try {
		id = Player.SteamID;
	}
	catch(err) {
		//Plugin.Log("HomeSystemError", "Error caught at conn method.");
        return
	}
	jobParams.push(String(id));
	BZHJ.addJob('ByPassRoof', jointpdelay, iJSON.stringify(jobParams));
}

function On_PlayerDisconnected(Player) {
	var config = HomeConfig();
	var antiroof = config.GetSetting("Settings", "antiroofdizzy");
	var cooldown = config.GetSetting("Settings", "rejoincd");
	try {
		var id = Player.SteamID;
		if (antiroof == 1) {
			if (!Player.Admin) {
				var time = DataStore.Get("home_joincooldown", id);
				if (time == null) {
					//Data.AddTableValue('home_joincooldown', Player.SteamID, System.Environment.TickCount);
					DataStore.Add("home_joincooldown", id, System.Environment.TickCount);
				}
			}
		}
	}
	catch(ignore) {
		//Plugin.Log("HomeSystemError", "Error caught at disc method.");
	}
}

function isEmpty(str) {
    return (!str || 0 === str.length);
}

// In Rust We Trust JSON serializer adapted (by mikec) from json2.js 2014-02-04 Public Domain.
// Most recent version from https://github.com/douglascrockford/JSON-js/blob/master/json2.js
var iJSON = {};
(function () {
    'use strict';
    function f(n) {
        return n < 10 ? '0' + n : n;
    }
    var cx,	escapable, gap, indent,	meta, rep;
    function quote(string) {
        escapable.lastIndex = 0;
        return escapable.test(string) ? '"' + string.replace(escapable, function (a) {
            var c = meta[a];
            return typeof c === 'string' ? c : '\\u' + ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
        }) + '"' : '"' + string + '"';
    }
    function str(key, holder) {
        var i, k, v, length, mind = gap, partial, value = holder[key];
        if (value && typeof value === 'object' && typeof value.toJSON === 'function') {
            value = value.toJSON(key);
        }
        switch (typeof value) {
            case 'string':
                return quote(value);
            case 'number':
                return isFinite(value) ? String(value) : 'null';
            case 'boolean':
            case 'null':
                return String(value);
            case 'object':
                if (!value) { return 'null'; }
                gap += indent;
                partial = [];
                if (Object.prototype.toString.apply(value) === '[object Array]') {
                    length = value.length;
                    for (i = 0; i < length; i += 1) {
                        partial[i] = str(i, value) || 'null';
                    }
                    v = partial.length === 0 ? '[]' : gap ? '[ ' + gap + partial.join(', ' + gap) + ' ' + mind + ']' : '[' + partial.join(',') + ']';
                    // v = partial.length === 0 ? '[]' : gap ? '[\n' + gap + partial.join(',\n' + gap) + '\n' + mind + ']' : '[' + partial.join(',') + ']';
                    gap = mind;
                    return v;
                }
                for (k in value) {
                    if (Object.prototype.hasOwnProperty.call(value, k)) {
                        v = str(k, value);
                        if (v) { partial.push(quote(k) + (gap ? ': ' : ':') + v); }
                    }
                }
                v = partial.length === 0 ? '{}' : gap ? '{ ' + gap + partial.join(', ' + gap) + ' ' + mind + '}' : '{' + partial.join(',') + '}';
                // v = partial.length === 0 ? '{}' : gap ? '{\n' + gap + partial.join(',\n' + gap) + '\n' + mind + '}' : '{' + partial.join(',') + '}';
                gap = mind;
                return v;
        }
    }
    if (typeof iJSON.stringify !== 'function') {
        escapable = /[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g;
        meta = { '\b': '\\b', '\t': '\\t', '\n': '\\n', '\f': '\\f', '\r': '\\r', '"' : '\\"', '\\': '\\\\' };
        iJSON.stringify = function (value) { gap = ''; indent = ''; return str('', {'': value}); };
    }
    if (typeof iJSON.parse !== 'function') {
        cx = /[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g;
        iJSON.parse = function (text, reviver) {
            var j;
            function walk(holder, key) {
                var k, v, value = holder[key];
                if (value && typeof value === 'object') {
                    for (k in value) {
                        if (Object.prototype.hasOwnProperty.call(value, k)) {
                            v = walk(value, k);
                            if (v !== undefined) {
                                value[k] = v;
                            } else {
                                delete value[k];
                            }
                        }
                    }
                }
                return reviver.call(holder, key, value);
            }
            text = String(text);
            cx.lastIndex = 0;
            if (cx.test(text)) {
                text = text.replace(cx, function (a) {
                    return '\\u' +
                        ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
                });
            }
            if (/^[\],:{}\s]*$/
                .test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, '@')
                    .replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']')
                    .replace(/(?:^|:|,)(?:\s*\[)+/g, ''))) {
                j = eval('(' + text + ')');
                return typeof reviver === 'function'
                    ? walk({'': j}, '')
                    : j;
            }
            throw new SyntaxError('JSON.parse');
        };
    }
}());