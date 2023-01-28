/**
 *		Homejobs plugin addon written and integrated by BadZombi for HomeSystem V2.0.1 (DreTaX)
 *      TpFriend 2.5.0 Rewrite
 *  	--
 */
var TpFriend = {
    name: 		'TpFriend',
    author: 	'DreTaX',
    version: 	'2.5.3'
};

var BZTJ = {
    name: 		'TPA Jobs',
    author: 	'BadZombi',
    version: 	'0.1.0',
    DStable: 	'BZTPAjobs',
    addJob: function(callback, xtime, params){
        var jobData = {};
        jobData.callback = String(callback);
        jobData.params = String(params);
        var epoch = Plugin.GetTimestamp();
        var exectime = parseInt(epoch) + parseInt(xtime);
        DataStore.Add(this.DStable, exectime, iJSON.stringify(jobData));
        this.startTimer();
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
            var gfjfhg = Data.GetConfigValue("TpFriend", "Settings", "run_timer") * 1000;
            if(!Plugin.GetTimer("TPAJobTimer")){
                Plugin.CreateTimer("TPAJobTimer", gfjfhg).Start();
            }
        } catch(err){
            Util.ConsoleLog(err.message);
        }
    },
    stopTimer: function(P) {
        Plugin.KillTimer("TPAJobTimer");
    },
    clearTimers: function(P){
        P.MessageFrom('meh', "Erasing all example timers.");
        DataStore.Flush(this.DStable);
    }
};

function On_PluginInit() {
    DataStore.Flush("BZTPAjobs");
    Util.ConsoleLog(BZTJ.name + " v" + BZTJ.version + " by " + BZTJ.author + " loaded.", true);
    Util.ConsoleLog(TpFriend.name + " v" + TpFriend.version + " by " + TpFriend.author  + " loaded.", true);
}

function TPAJobTimerCallback(){
    var epoch = Plugin.GetTimestamp();
    if(DataStore.Count(BZTJ.DStable) >= 1){
        var pending = DataStore.Keys(BZTJ.DStable);
        var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
        for (var p in pending){
            if(epoch >= parseInt(p)) {
                var jobData = DataStore.Get(BZTJ.DStable, p);
                var jobxData = iJSON.parse(jobData);
                if(jobxData.params == "undefined")
                {
                    DataStore.Remove(BZTJ.DStable, p);
                    continue;
                }
                var params = iJSON.parse(jobxData.params);
                switch(jobxData.callback) {
                    case "tpfirst":
                        var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
                        var player = FindPlayer(params[0]);
						var fromplayer = FindPlayer(params[1]);
                        if (player != null && fromplayer != null) {
                            fromplayer.TeleportTo(player);
                            BZTJ.addJob('tpsec', checkn, jobxData.params);
                        }
						else {
							BZHJ.killJob(params[0]);
						}
                    break;

                    case "tpsec":
                        var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
                        var player = FindPlayer(params[0]);
						var fromplayer = FindPlayer(params[1]);
						fromplayer.TeleportTo(player);
						fromplayer.MessageFrom(systemname, "You have been teleported here again for safety reasons in: " + checkn + " secs");
                    break;
					
					case "autokill":
						var playerfrom = FindPlayer(params[1]);
						var playerto = FindPlayer(params[0]);
						if (playerfrom != null) {
							Data.AddTableValue("tpfriendpending", params[1], null);
							Data.AddTableValue("tpfriendpending2",  params[1], null);
							Data.AddTableValue("tpfriendcooldown", params[0], 7);
							playerfrom.MessageFrom(systemname, "Teleport request timed out");
						}
						else {
							BZHJ.killJob(params[0]);
						}
                    break;
                }
                DataStore.Remove(BZTJ.DStable, p);
            }
        }
    } else {
        BZTJ.stopTimer();
    }

}

/**
 * Created by DreTaX on 2014.04.18.. V2.2.1
 *
 */

function On_Command(Player, cmd, args) {
    switch(cmd) {
        case "cleartpatimers":
            if (Player.Admin) {
                BZTJ.clearTimers(Player);
            }
        break;
        case "tpa":
            if (args.Length == 0){
				var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
				Player.MessageFrom(systemname, "Teleport Usage:");
				Player.MessageFrom(systemname, "This will teleport you to another player.");
				Player.MessageFrom(systemname, "\"/tpa [PlayerName]\" to request a teleport.");
				Player.MessageFrom(systemname, "\"/tpaccept\" to accept a requested teleport.");
				Player.MessageFrom(systemname, "\"/tpdeny\" to deny a request.");
				Player.MessageFrom(systemname, "\"/tpcount\" to see how many requests you have remaining.");
			}
			if (args.Length >= 1) {
				var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
				//var playertor = GetPlayer(args[0]);
				var playertor = CheckV(Player, args);
				if (playertor == null) {
					Player.Message("Player " + playertor + " not found!");	
					return;
				}
				if (playertor == Player) {
					Player.MessageFrom(systemname, "Cannot teleport to yourself!");
					return;
				}
				var maxuses = Data.GetConfigValue("TpFriend", "Settings", "Maxuses");
				var cd = Data.GetConfigValue("TpFriend", "Settings", "cooldown");
				var cooldown = parseInt(cd);
				var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
				var stuff = Data.GetConfigValue("TpFriend", "Settings", "timeoutr");
				var time = Data.GetTableValue("tpfriendcooldown", Player.SteamID);
				var usedtp = Data.GetTableValue("tpfriendusedtp", Player.SteamID);
				var calc = System.Environment.TickCount - time;
				if (time == undefined || time == null || calc < 0 || isNaN(calc)) {
					time = Data.AddTableValue("tpfriendcooldown", Player.SteamID, System.Environment.TickCount);
				}
				if (calc >= cooldown || time == 7) {
					if (usedtp == null) {
						Data.AddTableValue("tpfriendusedtp", Player.SteamID, 0);
						usedtp = 0;
					} 
					var maxtpnumber = parseInt(maxuses); 
					var playertpuse = parseInt(usedtp);
					if(maxtpnumber > 0) {
						if (maxtpnumber >= playertpuse) {
							Player.MessageFrom(systemname, "Reached max number of teleport requests!");
							return;
						}
					}
						
					/*if (Data.GetTableValue("tpfriendcooldown", Player.SteamID) != null) {
						Player.Message("You have already requested teleport, and It didn't get accepted/timed out yet!");
						return;
					}*/
					
					Data.AddTableValue("tpfriendcooldown", Player.SteamID, System.Environment.TickCount);
					playertor.MessageFrom(systemname, "Teleport request from " + Player.Name + " to accept write /tpaccept");
					Player.MessageFrom(systemname, "Teleport request sent to " + playertor.Name);
					Data.AddTableValue("tpfriendpending2",  playertor.SteamID, Player.SteamID);
					var jobParams = [];
						jobParams.push(String(Player.SteamID));
						jobParams.push(String(playertor.SteamID));
					BZTJ.addJob('autokill', stuff, iJSON.stringify(jobParams));
				}
				else {
					var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
					Player.MessageFrom(systemname, "You have to wait before teleporting again!");
					var next2 = (calc / 1000) / 60;
					var def2 = (cooldown / 1000) / 60;
					var done = Number(next2).toFixed(2); 
					var done2 = Number(def2).toFixed(2); 
					Player.MessageFrom(systemname, "Time Remaining: " + done + "/" + done2);
				}
			}
		break;
		case "tpaccept":
			var pending = Data.GetTableValue("tpfriendpending2", Player.SteamID);
			if (pending != null) {
				var playerfromm = FindPlayer(pending);
				if (playerfromm != null) {
					BZTJ.killJob(pending);
					var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
					var maxuses = Data.GetConfigValue("TpFriend", "Settings", "Maxuses");
					var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
					var usedtp = Data.GetTableValue("tpfriendusedtp", pending);
					var maxtpnumber = parseInt(maxuses); 
					var playertpuse = parseInt(usedtp);
					var cd = Data.GetConfigValue("TpFriend", "Settings", "cooldown");
					var cooldown = parseInt(cd);
					var tpdelay = Data.GetConfigValue("TpFriend", "Settings", "tpdelay");
					var tpdelayy = parseInt(tpdelay);
					if(maxtpnumber > 0) {
						var uses = playertpuse + 1;
						Data.AddTableValue("tpfriendusedtp", pending, uses);
						playerfromm.MessageFrom(systemname, "Teleport requests used " + String(uses) + " / " + String(maxtpnumber));
					}
					else {
						playerfromm.MessageFrom(systemname, "You have unlimited requests remaining!");
					}
					
					if (tpdelayy > 0) {
						playerfromm.MessageFrom(systemname, "Teleporting you in: " + tpdelayy + " second(s)");
						var jobParams = [];
						jobParams.push(String(Player.SteamID));
						jobParams.push(String(playerfromm.SteamID));
						BZTJ.addJob('tpfirst', tpdelay, iJSON.stringify(jobParams));
					}
					else {
						playerfromm.MessageFrom(systemname, "Teleported!");
						playerfromm.TeleportTo(Player);
						var jobParams = [];
						jobParams.push(String(Player.SteamID));
						jobParams.push(String(playerfromm.SteamID));
						BZTJ.addJob('tpsec', checkn, iJSON.stringify(jobParams));
					}
				} 
				else {
					Player.MessageFrom(systemname, "Player isn't online!");
				}
			}
			else {
				Player.MessageFrom(systemname, "Your request was timed out, or you don't have any.");
			}
		break;
		
		case "tpdeny":
			var pending = Data.GetTableValue("tpfriendpending2", Player.SteamID);
			var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
			if (pending != null) {
				var playerfromm = FindPlayer(pending);
				if (playerfromm != null){
					Data.AddTableValue("tpfriendpending", pending, null);
					Data.AddTableValue("tpfriendcooldown", pending, 7);
					Data.AddTableValue("tpfriendpending2", Player.SteamID, null);
					Player.MessageFrom(systemname, "Request denied!");
					playerfromm.MessageFrom(systemname, "Your request was denied!");
				}
			}else{
				Player.MessageFrom(systemname, "No request to deny.");
			}
			break;
		case "tpcount":
			var maxuses = Data.GetConfigValue("TpFriend", "Settings", "Maxuses");
			var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
			if (maxuses > 0)
			{
				var uses = Data.GetTableValue("tpfriendusedtp", Player.Name);
				if(uses == null){
					uses = 0;
				}
				Player.MessageFrom(systemname, "Teleport requests used " + String(uses) + " / " + String(maxuses));

			}else{
				Player.MessageFrom(systemname, "You have unlimited requests remaining!");
			}
		break;
		
		case "tpresettime":
			if (Player.Admin) {
				Data.AddTableValue("tpfriendcooldown", Player.SteamID, 7);
				Player.Message("Time for you, Reset!");
			}
		break;
    }
}

/**
 * @return {null}
 */
function FindPlayer(id) {
    for (var pl in Server.Players) {
		if (pl.SteamID == id) {
			return pl;
		}
	}
    return null;
}

/**
 * @return {null}
 */
function GetPlayer(name){
    name = Data.ToLower(name);
    for(var pl in Server.Players){
        if(Data.ToLower(pl.Name) == name){
            return pl;
        }
    }
    return null;
}

/*
 *	Provided by SPooCK
 */

function CheckV(Player, args) {
	var target;
	var systemname = Data.GetConfigValue("TpFriend", "Settings", "sysname");
    var Nickname = "";
    for(var i=0; i < args.Length; i++)
    Nickname += args[i] + " ";
    Nickname = Data.Substring(Nickname, 0, Data.StrLen(Nickname) - 1)
    target = Magma.Player.FindByName(Nickname);
    if (target != null) {
        return (target);
    } 
	else {
		var cc = 0;
		for (var all in Server.Players) {
			var name = all.Name.ToLower();
			var check = args[0].ToLower();
			if (name.Contains(check)) {
				var found = all.Name;
				cc++;
			}
		}	
		if (cc == 1) {
			target = Magma.Player.FindByName(found);
			return (target);
		} else if (cc > 1) {
			Player.MessageFrom(systemname, "Found [color#FF0000]" + cc + " players[/color] with similar names. [color#FF0000]Use more correct name !");
			return null;
		} else if (cc == 0) {
			Player.MessageFrom(systemname, "Player [color#00FF00]" + Nickname + "[/color] not found");
			return null;
		}
	}
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