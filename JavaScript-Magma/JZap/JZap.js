// JZap by mikec 16-DEC-2014 for JintPlugin Fougerite 1.0.7
// identify owner by hitting an object
// hit again to zap everything owned by that player
// or repeat command to cancel
var JZap = 'JZap';

function On_ServerShutdown() {
	DataStore.Flush(JZap);
}
function On_ServerInit() {
	DataStore.Flush(JZap);
}
function On_PluginInit() {
	try
	{
		DataStore.Flush(JZap);
	}
	catch(ignore) {}
}
function On_Command(Player, cmd, args) {
    if(Player.Admin && cmd.toUpperCase() == JZap.toUpperCase()) {
		if(DataStore.Get(JZap, 'Active') != null && DataStore.Get(JZap, 'Active') != Player.SteamID) {
			Player.MessageFrom('☒ ', 'Wait a moment, someone else is zapping stuff.');
			return;
		} else if(DataStore.Get(JZap, 'Active') != Player.SteamID) {
			DataStore.Add(JZap, 'Active', Player.SteamID);
			Player.InventoryNotice(JZap + ' is activated!');
		} else {
			DataStore.Flush(JZap);
			Player.InventoryNotice(JZap + ' is de-activated!');
		}
    }
}
var NameLookup = function(uid) {
	var xml = Plugin.GET('http://steamcommunity.com/profiles/' + uid + '/?xml=1');
	var start = xml.indexOf('CDATA[') + 6;
	var stop = xml.indexOf(']]>', start);
	var fromsteam = xml.substring(start, stop);
	if (fromsteam.length > 1) {
		return fromsteam;
	}
	return '¿?Private Profile?¿';
};

function On_EntityHurt(he) {
	var OwnerID = DataStore.Get(JZap, 'Target');
	var emon = '[color#FFA500]';
	var noem = '[color#FFFFFF]';

	if(he.Entity.Health > 0 && he.Attacker.Admin) {
		var name = NameLookup(he.Entity.OwnerID);
		if(DataStore.Get(JZap, 'Active') == he.Attacker.SteamID && OwnerID == null) {
			he.Attacker.MessageFrom('☑ ', 'This thing belongs to  ' + emon + name + noem + ' (' + he.Entity.OwnerID + ').');
			he.Attacker.MessageFrom('☑ ☑ ', 'Hit it once more to zap  ' + emon + name + '\'s' + noem + '  stuff completely off the map.');
			DataStore.Add(JZap, 'Target', he.Entity.OwnerID);
			return;
		} else if(OwnerID == he.Entity.OwnerID) {
			DataStore.Flush(JZap);
			var stuff = World.Entities.ToArray().filter(AllStuff);
			var count = stuff.length;
			for(var i=0; i < count; i++) {
				Zap(stuff.shift());
			}
			he.Attacker.MessageFrom('☑ ☑ ☑ ', emon + count +  noem + '  objects were zapped.');
			he.Attacker.Notice('☠', name.toUpperCase() + '\'S RUST STUFF\'S DUST!', 10);
			he.Attacker.InventoryNotice(JZap + ' is de-activated!');
			return;
		}
		DataStore.Flush(JZap); // just in case. should never reach this
	}

	function AllStuff(e) {
		return (e.Object != null && e.OwnerID == OwnerID && e.Health > 0);
	}
	function Zap(e) {
		try {
			if(e.Object.gameObject != null && e.Health > 0) {
				if(e.IsStructure()) {
					e.Destroy();
				} else {
					Util.DestroyObject(e.Object.gameObject);
				}
			}
		} catch(ignore) {}
	}
}
