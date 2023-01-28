var negro = "[color #000000]";
var gris = "[color #424242]";
var grisclaro = "[color #D8D8D8]";
var blanco = "[color #FFFFFF]";
var rosa = "[color #F781F3]";
var morado = "[color #6A0888]";
var rojo = "[color #FF0000]";
var azul = "[color #001EFF]";
var verde = "[color #00FF40]";
var azulclaro = "[color #00FFF7]";
var amarillo = "[color #FCFF02]";
var naranja = "[color #CD8C00]";
var marron = "[color #604200]";
var turquesa = "[color #00FFC0]";

function On_PlayerKilled(DeathEvent) {
try {
  if (DeathEvent.Attacker.SteamID != DeathEvent.Victim.SteamID) {
    var CurrentSpree = GetCurrentKillingSpree(DeathEvent.Attacker.SteamID) + 1;
    SetKillingSpree(DeathEvent.Victim.SteamID, 0);
    SetKillingSpree(DeathEvent.Attacker.SteamID, CurrentSpree);
    ShowKillingSpreeNotification(DeathEvent.Attacker.Name, CurrentSpree)
  }

}
catch (err) {
  Util.LogRojo("ERROR en PLAYERKILLED RachasKills++.js")   
}
}


function On_PlayerDisconnected(Player) {

  var TimeStamp = Math.round(Date.now() / 1000);
  SetLastSeen(Player.SteamID, TimeStamp);
}


function GetLastSeen(SteamID) {
  return Data.GetTableValue("Peak_KS_LastSeen", SteamID);
}

function SetLastSeen(SteamID, LastSeen) {
  Data.AddTableValue("Peak_KS_LastSeen", SteamID, LastSeen);
}

function GetCurrentKillingSpree(SteamID) {

  var KillingSpree = Data.GetTableValue("Peak_KS_CurrentSpree", SteamID);

  if (KillingSpree == null) {
    return 0;
  } else {
    return KillingSpree;
  }
}


function SetKillingSpree(SteamID, Spree) {
  return Data.AddTableValue("Peak_KS_CurrentSpree", SteamID, Spree);
}

function ShowKillingSpreeNotification( Name, CurrentSpree) {
  if (CurrentSpree == 2) {
    Server.BroadcastFrom(rojo + Name +verde + " Racha de" + amarillo + " (2)");
  } else if (CurrentSpree == 3) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (3)");
  } else if (CurrentSpree == 4) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (4)");
  } else if (CurrentSpree == 5) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (5)");
  } else if (CurrentSpree == 6) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (6)");
  } else if (CurrentSpree == 7) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (7)");
  } else if (CurrentSpree == 8) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (8)");
  } else if (CurrentSpree == 9) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (9)");
  }else if (CurrentSpree == 10) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (10)");
  }else if (CurrentSpree == 11) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (11)");
  }else if (CurrentSpree == 12) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (12)");
  }else if (CurrentSpree == 13) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (13)");
  }else if (CurrentSpree == 14) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (14)");
  }else if (CurrentSpree == 15) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (15)");
  }else if (CurrentSpree == 16) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (16)");
  }else if (CurrentSpree == 17) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (17)");
  }else if (CurrentSpree == 18) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (18)");
  }else if (CurrentSpree == 19) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (19)");
  }else if (CurrentSpree == 20) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (20)");
  }else if (CurrentSpree == 21) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (21)");
  }else if (CurrentSpree == 22) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name  +verde + " Esta apunto de sacarse la moab" + amarillo + " (22)");
  }else if (CurrentSpree == 23) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name  +verde + " Le queda 1 para la moab" + amarillo + "(23)");
  }else if (CurrentSpree == 24) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name  +verde + " Se saco la Moab" + amarillo + " (24)");
  }else if (CurrentSpree == 25) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (25)");
  }else if (CurrentSpree == 26) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (26)");
  }else if (CurrentSpree == 27) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (27)");
  }else if (CurrentSpree == 28) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name + verde +  " Esta apunto de sacarse la Nuke" + amarillo + " (28)");
  }else if (CurrentSpree == 29) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name + verde + " Le queda 1 para la Nuke" + amarillo + " (29)");
  }else if (CurrentSpree == 30) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (30)");
  }else if (CurrentSpree == 31) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (31)");
  }else if (CurrentSpree == 32) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (32)");
  }else if (CurrentSpree == 33) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (33)");
  }else if (CurrentSpree == 34) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (34)");
  }else if (CurrentSpree == 35) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (35)");
  }else if (CurrentSpree == 36) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (36)");
  }else if (CurrentSpree == 37) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (37)");
  }else if (CurrentSpree == 38) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (38)");
  }else if (CurrentSpree == 39) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (39)");
  }else if (CurrentSpree == 40) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (40)");
  }else if (CurrentSpree == 41) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (41)");
  }else if (CurrentSpree == 42) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (42)");
  }else if (CurrentSpree == 43) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (43)");
  }else if (CurrentSpree == 44) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (44)");
  }else if (CurrentSpree == 45) {
    Server.BroadcastFrom("Novaland Racha",rojo + Name +verde + " Racha de" + amarillo + " (45)");
  }
}
