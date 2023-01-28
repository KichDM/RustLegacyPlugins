//Title: Game and Server Clock
//Developer: Simba
//Version: 1.5
//Description: Displays Server and Game Time 


//Displays Game and Server Time on Player Login
function On_PlayerConnected(Player) {
	
	var time = System.DateTime.Now.toString("hh:mm tt");
	Player.Message("Server time is " + time);
	var gametime = World.Time;
	var hour = Math.floor(gametime);
	var tmp = gametime % 1;
	var tt = " ";
	var min = Math.floor(tmp * 60); 
	//if noon or past noon
	if (hour >= 12){
		tt = "PM";
		if (hour > 12){
			hour = hour - 12;
		}
		if (hour < 10){
					if (min < 10){
						Player.Message("Game time is 0" + hour + ":0" + min + " " + tt);
					}else {
						Player.Message("Game time is 0" + hour + ":" + min + " " + tt);
					}
		}else {
			if (min < 10){
				Player.Message("Game time is " + hour + ":0" + min + " " + tt);
			}else {
				Player.Message("Game time is " + hour + ":" + min + " " + tt);
			}
		}
	}else{
		if (hour == 0){
			hour = 12;
		}
		tt = "AM";
		if (hour < 10){
			Player.Message("Game time is 0" + hour + ":" + min + " " + tt);
		}
	}

		
	
}

//Displays Game Time on command
function On_Command(Player, cmd, args){
	switch (cmd){ 
		case "clock":
			var time = System.DateTime.Now.toString("hh:mm tt");
			Player.Message("Server time is " + time);
			var gametime = World.Time;
			var hour = Math.floor(gametime);
			var tmp = gametime % 1;
			var tt = " ";
			var min = Math.floor(tmp * 60); 
			//if noon or past noon
			if (hour >= 12){
				tt = "PM";
				if (hour > 12){
					hour = hour - 12;
				}
				if (hour < 10){
					if (min < 10){
						Player.Message("Game time is 0" + hour + ":0" + min + " " + tt);
					}else {
						Player.Message("Game time is 0" + hour + ":" + min + " " + tt);
					}
				}else {
					if (min < 10){
						Player.Message("Game time is " + hour + ":0" + min + " " + tt);
					}else {
						Player.Message("Game time is " + hour + ":" + min + " " + tt);
					}
				}
			}else{
				if (hour == 0){
					hour = 12;
				}
				tt = "AM";
				if (hour < 10){
					Player.Message("Game time is 0" + hour + ":" + min + " " + tt);
				}
			}
		break;
	}
}
		