//* By KichDM
//*TODO Para NovaLand Zero

var pink = "[color #CC66FF]";
var teal = "[color #00FFFF]";
var green = "[color #009900]";
var purple = "[color #6600CC]";
var white = "[color #FFFFFF]";
var yellow = "[color #F4FA58]";
var orange = "[color #FF8000]";



//Enseña hora cuando entra el jugador
/*
function On_PlayerConnected(Player) {
	
	var time = System.DateTime.Now.toString("hh:mm tt");
	var gametime = World.Time;
	var hour = Math.round(gametime);
	var tmp = gametime % 1;
	var tt = " ";
	var min = Math.round(tmp * 60); 

	if (hour >= 12){
		tt = "PM";
		if (hour > 12){
			hour = hour - 12;
		}
		if (hour < 10){
					if (min < 10){
						Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
					}else {
						Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
					}
		}else {
			if (min < 10){
				Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
			}else {
				Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
			}
		}
	}else{
		if (hour == 0){
			hour = 12;
		}
		tt = "AM";
		if (hour < 10){
			Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
		}
	}

		
	
}
*/
//Activa la hora por comando /tiempo
function On_Command(Player, cmd, args){
	cmd = Data.ToLower(cmd);
	switch (cmd){ 
		case "tiempo":
			var time = System.DateTime.Now.toString("hh:mm tt");
			Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
			Player.MessageFrom("Novaland Time", green+"La hora del host es " + time);
			var gametime = World.Time;
			var hour = Math.round(gametime);
			var tmp = gametime % 1;
			var tt = " ";
			var min = Math.round(tmp * 60); 

			if (hour >= 12){
				tt = "PM";
				if (hour > 12){
					hour = hour - 12;
				}
				if (hour < 10){
					if (min < 10){
						Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
						Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
					}else {
						Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
						Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
					}
				}else {
					if (min < 10){
						Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
						Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
					}else {
						Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
						Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
					}
				}
			}else{
				if (hour == 0){
					hour = 12;
				}
				tt = "AM";
				if (hour < 10){
					Player.MessageFrom("Novaland Zero",orange+"El tiempo de juego es " + hour + ":" + min + " " + tt);
					Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
				}
			}
		break;
	}
}
		