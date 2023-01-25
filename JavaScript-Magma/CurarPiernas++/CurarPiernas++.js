//* By KichDM
//*TODO Para NovaLand Zero
var red = "[color #FF0000]";
var  blue = "[color #81F7F3]";
var  green = "[color #82FA58]";
var  yellow = "[color #F4FA58]";
var  orange = "[color #FF8000]";

function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    var user = Users.GetBySteamID(Player.SteamID);
    var dinero = Economy.GetBalance(Player.SteamID);
    if (cmd == "curar") {
        if (dinero >= 100)
        {
        if(user.Rank >= 5 && user.Rank <= 8)
        {
        Player.MessageFrom("Novaland Zero", green +"Espera 5s y sus piernas estaran curadas.");
        Data.AddTableValue("Piernas1",Player.SteamID, 1);
        Plugin.CreateTimer("Piernas1Timer", 5000).Start();
        Economy.BalanceSub(Player.SteamID,100);
       
       }
       if(user.Rank >= 9 && user.Rank <= 15)
       {
        Player.IsInjured = false;
        Player.Message(blue + "Tu piernas ha sido curada con exito tt");
      }
      if(user.Rank <= 0) 
      {
        Player.MessageFrom("Novaland Zero",green + "Espera 10s y sus piernas estaran curadas.");
        Data.AddTableValue("Piernas",Player.SteamID, 1);
        Plugin.CreateTimer("PiernasTimer", 100).Start();
       }
    }
    else {
        Player.MessageFrom("Novaland Zero", yellow + "No tienes dinero necesitas"+ red + "100" + yellow +"minimo.");
        Player.MessageFrom("Novaland Zero", yellow + " Dinero actual " + "["+ blue +dinero+yellow+"]");
    }
}
}


function PiernasTimerCallback(){
    for (var pl in Server.Players){
        if (Data.GetTableValue("Piernas", pl.SteamID) != null) {
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.IsInjured = false;
            pl.MessageFrom("Novaland Zero", rojo + "-100"+ green+ " de dinero quitado" + yellow + " Dinero actual " + "["+blue +dinero+yellow+"]");
            pl.Message(blue + "Tu piernas ha sido curada con exito tt");
            Data.AddTableValue("Piernas",pl.SteamID, null);
            break;
        }
    }
    Plugin.KillTimer("PiernasTimer");
}


function Piernas1TimerCallback(){
    for (var pl in Server.Players){
        if (Data.GetTableValue("Piernas1", pl.SteamID) != null) {
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.IsInjured = false;
            pl.MessageFrom("Novaland Zero", rojo + "-100"+ green+ " de dinero quitado" + yellow + " Dinero actual " + "["+blue +dinero+yellow+"]");
            pl.Message(blue + "Tu piernas ha sido curada con exito tt");
            Data.AddTableValue("Piernas1",pl.SteamID, null);
            break;
        }
    }
    Plugin.KillTimer("Piernas1Timer");
}
