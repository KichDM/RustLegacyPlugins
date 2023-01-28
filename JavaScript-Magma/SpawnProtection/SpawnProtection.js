var BZSJ = {
    name: 		'SpawnProtection Jobs',
    author: 	'BadZombi',
    version: 	'0.1.2',
    DStable: 	'BZSJ',
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
            var gfjfhg = 2 * 1000;
            if(!Plugin.GetTimer("SPAJobTimer")){
                Plugin.CreateTimer("SPAJobTimer", gfjfhg).Start();
            }
        } catch(err){
            Util.ConsoleLog(err.message);
        }
    },
    stopTimer: function(P) {
        Plugin.KillTimer("SPAJobTimer");
    },
	getPlayer: function(stam) {
		try {
			for (var player in Server.Players) {
				var id = player.SteamID;
				if (id == stam && player != null) {
					return player;
				}
			}
			return null;
		} catch(err) {
			Plugin.Log("SpawnProtection", "Error detectado en el método getPlayer. El jugador era nulo, eliminándolo del temporizador .");
			return null;
		}
    },
    clearTimers: function(P){
        P.MessageFrom('klk', "Borrar todos los temporizadores de ejemplo.");
        DataStore.Flush(this.DStable);
    }
};

function SPAJobTimerCallback(){
    var epoch = Plugin.GetTimestamp();
    if(DataStore.Count(BZSJ.DStable) >= 1){
		var pending = DataStore.Keys(BZSJ.DStable);
        for (var p in pending){
            if(epoch >= parseInt(p)) {
                var jobData = DataStore.Get(BZSJ.DStable, p);
                var jobxData = iJSON.parse(jobData);
                if(jobxData.params == "undefined")
                {
                    DataStore.Remove(BZSJ.DStable, p);
                    continue;
                }
                var params = iJSON.parse(jobxData.params);
                switch(jobxData.callback) {
                    case "protectdelay":
						var player = BZSJ.getPlayer(params[0]);
						if (player != null) {
							DataStore.Remove("Protected", params[0]);
							player.Message("Tu protección contra el desove ha desaparecido ");
						}
						else {
							BZSJ.killJob(params[0]);
						}
                    break;
				}
				DataStore.Remove(BZSJ.DStable, p);
			}
		}
	}
	else {
        BZSJ.stopTimer();
    }
}

function On_PluginInit() {
    DataStore.Flush("BZSJ");
	DataStore.Flush("Protected");
}

function On_PlayerHurt(HurtEvent) {
	if (HurtEvent.Attacker != null && HurtEvent.Victim != null) {
		var id = HurtEvent.Attacker.SteamID;
		var idv = HurtEvent.Victim.SteamID;
		if (DataStore.Get("Protected", idv)) {
			HurtEvent.DamageAmount = 0;
			HurtEvent.Attacker.Message("Player is under spawn protection");
			return;
		}
		if (DataStore.Get("Protected", id)) {
			HurtEvent.DamageAmount = 0;
			HurtEvent.Attacker.Message("You are under spawn protection");
			return;
		}
	}
}


function On_PlayerSpawned(Player, SpawnEvent) {
	var id = Player.SteamID;
	if (DataStore.Get("Protected", id) == undefined || !DataStore.Get("Protected", id)) {
		var jobParams = [];
        jobParams.push(String(id));
		DataStore.Add("Protected", id, "protected");
		BZSJ.addJob('protectdelay', 10, iJSON.stringify(jobParams));
		Player.Message("You are protected for 10 seconds!");
		Player.Message("You cannot kill or be killed by anyone till that time!"); 
	}	
}


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