function On_Chat(Player, ChatMessage) {
	var ChatString = ChatMessage.OriginalMessage;
	var string = "";
	if (ChatString.length > 47){
		var Posted = false;
		var Name = Player.Name;
		for (var i = 1; i <= ChatString.length - 2; i++){
			string = string + ChatString.charAt(i);
			if (((string.length > 35) && (string.charAt(string.length) == " ")) || (string.length > 45)){
				Server.BroadcastFrom(Name, string);
				Name = ":";
				string = "";
			}
		}	
		Server.BroadcastFrom(Name, string);			
		ChatMessage.NewText = "";
	}
}