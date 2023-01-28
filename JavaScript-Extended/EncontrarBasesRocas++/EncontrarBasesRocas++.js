//* By KichDM
//*TODO Para NovaLand Zero

    function On_Command(Player, cmd, args) {
        cmd = Data.ToLower(cmd);
        if (cmd == "bajar"){
            if (Player.Admin) {
             var  DiSt = DataStore.Get("RockBaseFinder", "Distance");
              var  YY = (Player.Y);
              var  NewY = (YY - DiSt);
                Player.TeleportTo(Player.X, NewY, Player.Z);
                Player.MessageFrom("Novaland Admin", "Teleported " + (str(DiSt)) +"m below!");
            }
            else {
                Player.Message("You are not allowed to use that command!");
            }
        }
    }

    function On_PluginInit() {
        if (!Plugin.IniExists("Settings")) {
            var inifile = Plugin.CreateIni("Settings");
           inifile.AddSetting ("Config", "Distance", "1");
           var ini = Plugin.GetIni("Settings");
           inifile.Save();
    }
}
