function On_Command(Player, cmd, args) {
	try {
		var ListInfo = DataStore.Get("commands", cmd);
		if(ListInfo != undefined){
			var smb = 0;
			var string = "";
			var count = 0;
			var PlayersList = DataStore.Keys(ListInfo.TableName);
			Player.Message(ListInfo.Info);
			for (pl in PlayersList){
				smb = 1;
				count++;
				if (count == ListInfo.InOneString){
					count = 0;
					Player.Message(string);
					string = "";
				}
				string = string + " \""+pl+ "\" ";
			}
			if (smb == 1){
				Player.Message(string);
			}
			else {
				Player.Message(ListInfo.EmptyInfo);
			}
		}
	}
	catch (err) {
            //ErrorFound(err, "OnCommand");
    }
}