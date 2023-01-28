function On_PlayerKilled(DeathEvent) {
  if (DeathEvent.Attacker.SteamID != DeathEvent.Victim.SteamID) {
    var CurrentSpree = GetCurrentKillingSpree(DeathEvent.Attacker.SteamID) + 1;
    SetKillingSpree(DeathEvent.Victim.SteamID, 0);
    SetKillingSpree(DeathEvent.Attacker.SteamID, CurrentSpree);
    ShowKillingSpreeNotification(DeathEvent.Attacker.Name, CurrentSpree)
  }
}

function On_PlayerConnected(Player) {
  var LastSeen = GetLastSeen(Player.SteamID);
  var TimeStamp = Math.round(Date.now() / 1000);
  var CurrentSpree = GetCurrentKillingSpree(Player.SteamID);

  if (LastSeen != null) {
    if (CurrentSpree > 0) {
      if ((TimeStamp - LastSeen) >= 900) {
        SetKillingSpree(Player.SteamID, 0);
        Player.Message("Your killing spree has been reset.");
      }
    }
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

function ShowKillingSpreeNotification(Name, CurrentSpree) {
  if (CurrentSpree == 5) {
    Server.BroadcastNotice(Name + " is on a killing spree!");
  } else if (CurrentSpree == 10) {
    Server.BroadcastNotice(Name + " is on a rampage!");
  } else if (CurrentSpree == 15) {
    Server.BroadcastNotice(Name + " is dominating!");
  } else if (CurrentSpree == 20) {
    Server.BroadcastNotice(Name + " is unstoppable!");
  } else if (CurrentSpree == 25) {
    Server.BroadcastNotice(Name + " is godlike!");
  }
}
