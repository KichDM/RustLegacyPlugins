//requires Lists plugin

function On_PluginInit() {
	var listinfo = {
		TableName: "adminlist",
		Info: "[color#00FF00]Admins online:",
		EmptyInfo: "[color#FF0000]No admins online.",
		InOneString: 5
	}
	Data.AddTableValue("commands", "admins", listinfo);
	for(var pl in Server.Players) {
		if(Player.Admin){
			Data.AddTableValue('adminlist', pl.Name, pl.Name);
		}
	}
}

function On_PlayerConnected(Player){
	if(Player.Admin){
		Data.AddTableValue('adminlist', Player.Name, Player);
	}
}

function On_PlayerDisconnected(Player){
	DataStore.Remove('adminlist', Player.Name);
}