function On_Command(Player, cmd, args) {
    if (Data.ToLower(cmd) == "sethome") {
        if (args.Length == 0) { Player.MessageFrom("Homes", "/sethome <HomeName>"); return; }
        if (args.Length >= 2) { Player.MessageFrom("Homes", "Homes can not contain spaces."); return; }
        Sethome(Player, args[0]);
    }
    if (Data.ToLower(cmd) == "delhome") {
        if (args.Length == 0) { Player.MessageFrom("Homes", "/delhome <HomeName>"); return; }
        if (args.Length >= 2) { Player.MessageFrom("Homes", "Homes can not contain spaces."); return; }
        Delhome(Player, args[0]);
    }
    if (Data.ToLower(cmd) == "home") {
        if (args.Length == 0) { Player.MessageFrom("Homes", "/home <HomeName>"); return; }
        if (args.Length >= 2) { Player.MessageFrom("Homes", "Homes can not contain spaces."); return; }
        Home(Player, args[0]);
    }
}
function Sethome(Player, HomeName) {
    if (TotalHomes(Player) <= MaxHomes() - 1) {
        if (!Plugin.IniExists("Homes\\" + Player.SteamID + "\\" + HomeName)) { Plugin.CreateDir("Homes\\" + Player.SteamID); Plugin.CreateIni("Homes\\" + Player.SteamID + "\\" + HomeName); var ini = Plugin.GetIni("Homes\\Count"); var HomeCount = TotalHomes(Player); HomeCount++; ini.AddSetting("HomeCount", Player.SteamID, HomeCount); ini.Save(); Player.MessageFrom("Homes", HomeName + " saved as a home! " + HomeCount + " of " + MaxHomes() + " homes used!"); var ini2 = Plugin.GetIni("Homes\\" + Player.SteamID + "\\" + HomeName); ini2.AddSetting(HomeName, "Enabled", "true"); ini2.AddSetting(HomeName, "PosX", Player.X); ini2.AddSetting(HomeName, "PosY", Player.Y); ini2.AddSetting(HomeName, "PosZ", Player.Z); ini2.Save(); }
        else { Player.MessageFrom("Homes", HomeName + " already defined!"); }
    }
    else { Player.MessageFrom("Homes", "Max homes (" + MaxHomes() + ") reached! Delete homes with /delhome <HomeName>"); }
}
function Delhome(Player, HomeName) {
    if (Plugin.IniExists("Homes\\" + Player.SteamID + "\\" + HomeName)) { Plugin.CreateDir("Homes\\" + Player.SteamID); Plugin.CreateIni("Homes\\" + Player.SteamID + "\\" + HomeName); var ini = Plugin.GetIni("Homes\\Count"); var HomeCount = TotalHomes(Player); HomeCount--; ini.AddSetting("HomeCount", Player.SteamID, HomeCount); ini.Save(); Player.MessageFrom("Homes", HomeName + " removed from homes! " + HomeCount + " of " + MaxHomes() + " homes used!"); var ini2 = Plugin.GetIni("Homes\\" + Player.SteamID + "\\" + HomeName); ini2.DeleteSetting(HomeName, "Enabled"); ini2.Save(); }
    else { Player.MessageFrom("Homes", HomeName + " is  undefined!"); }
}
function Home(Player, HomeName) {
    var ini = Plugin.GetIni("Homes\\" + Player.SteamID + "\\" + HomeName); if (ini.GetSetting(HomeName, "Enabled") == "true") { var X = ini.GetSetting(HomeName, "PosX"); var Y = ini.GetSetting(HomeName, "PosY"); var Z = ini.GetSetting(HomeName, "PosZ"); Player.TeleportTo(X, Y, Z); }
    else { Player.MessageFrom("Homes", "Home not found!"); }
}
function TotalHomes(Player) {
    var ini = Plugin.GetIni("Homes\\Count"); if (!Plugin.IniExists("Homes\\count")) { Plugin.CreateDir("Homes\\"); Plugin.CreateIni("Homes\\Count"); ini.AddSetting("HomeCount", Player.SteamID, 0); ini.Save(); }
    if (ini.GetSetting("HomeCount", Player.SteamID) == null || ini.GetSetting("HomeCount", Player.SteamID) == undefined) { ini.AddSetting("HomeCount", Player.SteamID, 0); ini.Save(); }
    return ini.GetSetting("HomeCount", Player.SteamID);
}
function MaxHomes() { return Data.GetConfigValue("Homes", "Homes", "Max_Homes"); }