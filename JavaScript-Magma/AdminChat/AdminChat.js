
//Funcion de enviar texto solo a admins
function sendAdminText(name, text){
    startIni();
    var ini = Plugin.GetIni("adminchat");
    var color = ini.GetSetting("settings", "color");
    for(var pl in Server.Players){
        if(pl.Admin){
            pl.MessageFrom("[AdminChat] " + name, "[color#" + color + "]" + text);
        }
    }
}

//Función para iniciar el complemento ini en caso de que no exista 
function startIni(){
    if(!Plugin.IniExists("adminchat")){
        var ini = Plugin.CreateIni("adminchat");
        ini.AddSetting("settings", "color", "00FF89");
        ini.Save();
    }
}

//Función para verificar si la cadena es hexadecimal
function isHex(string){
    var i;
    if (string.length!=6){
        return false;
    }
    for (i=0; i<6; i++){
        if (isNaN(parseInt(string.charAt(i), 16))){
            return false;
        }
    }
    return true;
}

//El nucleo tt
function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    if (Player.Admin) {
        var n = "AdminChat";
        cmd = Data.ToLower(cmd);
        if (cmd == "adminchat") {
            switch (args.Length) {
                case 0:
                    Player.MessageFrom(n, "AdminChat 2.0 Novaland Zero");
                    Player.MessageFrom(n, "---------------------------------");
                    Player.MessageFrom(n, "Usa '/ac texto' para chatear con los admins");
                    Player.MessageFrom(n, "Usa '/adminchat' para ver la info");
                    Player.MessageFrom(n, "Usa '/adminchat color 00FF00' para cambiar el color del chat (hex)");
                    break;

                /** para el futuro
                case 1:
                    switch(args[0]){
                        case "colorlist":
                            Player.MessageFrom(n, "Lista de colores para el chat admin");
                            Player.MessageFrom(n, "[color#00FFFF]Cyan [color#32CD32]Lime [color#ADD8E6]LightBlue")
                            break;
                    }
                    break;
                */

                case 2:
                    if(args[0] == "color"){
                        args[1] = args[1].toUpperCase();
                        if(isHex(args[1])){
                            startIni();
                            var ini = Plugin.GetIni("adminchat");
                            var color = "[color#" + args[1] + "]" + args[1];
                            ini.AddSetting("settings", "color", args[1]);
                            ini.Save();
                            Player.MessageFrom(n, "Color fue aplicado a " + color);
                        }
                        else{
                            Player.MessageFrom(n, "No es un color hexadecimal válido");
                        }
                    }

                default:
                    Player.MessageFrom(n, "Comando invalido");
                    break;
            }
        }
        else if(cmd == "ac"){
            var length = args.Length;
            if(length>0){
                var text = "";
                var i;
                for(i=0;i<length;i++){
                    text = text + args[i] + " ";
                }
                sendAdminText(Player.Name, text);
            }
            else{
                Player.MessageFrom(n, "No se proporcionó texto");
            }
        }
    }
}