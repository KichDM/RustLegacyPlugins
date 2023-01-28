/**
 * Name : AdminChat
 * File : AdminChat.js
 * Author : Snake
 * Creation : 2014.07.10
 * Version : 1.0
 */

//Function to send text only to admins
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

//Function to init plugin ini in case it doesn't exists
function startIni(){
    if(!Plugin.IniExists("adminchat")){
        var ini = Plugin.CreateIni("adminchat");
        ini.AddSetting("settings", "color", "00FF89");
        ini.Save();
    }
}

//Function to check if string is hex
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

//Core of the plugin
function On_Command(Player, cmd, args) {
    if (Player.Admin) {
        var n = "AdminChat";
        cmd = Data.ToLower(cmd);
        if (cmd == "adminchat") {
            switch (args.Length) {
                case 0:
                    Player.MessageFrom(n, "AdminChat 1.0 by Snake");
                    Player.MessageFrom(n, "---------------------------------");
                    Player.MessageFrom(n, "Use '/ac text' to chat with admins");
                    Player.MessageFrom(n, "Use '/adminchat' to see this info");
                    Player.MessageFrom(n, "Use '/adminchat color 00FF00' to change the color (hex)");
                    break;

                /** On Planning Stage
                case 1:
                    switch(args[0]){
                        case "colorlist":
                            Player.MessageFrom(n, "List of Colors for AdminChat");
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
                            Player.MessageFrom(n, "Color changed to " + color);
                        }
                        else{
                            Player.MessageFrom(n, "Not a valid hexadecimal color");
                        }
                    }

                default:
                    Player.MessageFrom(n, "Invalid command");
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
                Player.MessageFrom(n, "No text was provided");
            }
        }
    }
}