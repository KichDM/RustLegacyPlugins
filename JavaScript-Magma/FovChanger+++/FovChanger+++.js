//* By KichDM
//*TODO Para NovaLand Zero

var verde = "[color #00FF40]";
var amarillo = "[color #FCFF02]";

function On_Command(Player, cmd, args) {
	cmd = Data.ToLower(cmd);
	if(cmd == "fov")
		{
				Player.SendCommand("render.fov " + args[0]);
				Player.MessageFrom("Novaland Fov", rojo + "---------------------------- Fov Novaland Zero--------------------------------")
				Player.MessageFrom("Novaland Fov", verde + "Tu  FOV  fue aplicado.")
				Player.MessageFrom("Novaland Fov", verde +	"Ahora tienes el Fov en   " +  amarillo + args[0])
				Player.SendCommand("config.save");
				Player.MessageFrom("Novaland Fov", rojo + "-------------------------------------------------------------------------------")
			}	
		}