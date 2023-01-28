/*
Title: Advanced Help Command
Author: BogdanWDK
Description: Replace the /help commands with more descriptive and user-friendly.
Version: 1.3

][ ================================================================================= ][


Settings:

a) Active = true / false
- Turn the plugin on / off

b) Messages = true / false
- Turn the messages on / off

c) Prefix = AHC / anything else
- Chat prefix for messages that appears once player connects to the server

d) Color1 = [color#FF8000]
- This is the color you'll see commands once you'll type /help

e) Color2 = [color#00FFFF]
- This is the color for the explanation text.




Coming soon :
- Multi-Language support
- Converting to C# language

Support me by not changing the "Prefix" setting so the plugin gets popular.Thank you!

][ ================================================================================= ][


*/
/* "Moderator Function" compatibility */
function isMod(id) {
    if (DataStore.ContainsKey("Moderators", id)) return true;
    return false;
}


// Read the .ini file
function iniset() {
    return Plugin.GetIni("ahc_settings");
}


// Make sure to create the .ini file ,just in case it's missing.
function On_PluginInit() {

    if (!Plugin.IniExists("ahc_settings")) {
        var inifile = Plugin.CreateIni("ahc_settings");

        inifile.AddSetting("Settings", "Active", true);

        inifile.AddSetting("Settings", "Messages", true);

        inifile.AddSetting("Settings", "Prefix", "AHC");

        inifile.AddSetting("Settings", "Color1", "[color#FF8000]");

        inifile.AddSetting("Settings", "Color2", "[color#00FFFF]");

        // Adding commands to ini
        inifile.AddSetting("AdminCommands", "/banip <player>", "Bans players UID, Name, and IP");
        inifile.AddSetting("AdminCommands", "/announce <message>", "Broadcast drop down notice");
        inifile.AddSetting("AdminCommands", "/give <player> <itemname> <amount>", "Spawn an item into a player's inv");
        inifile.AddSetting("AdminCommands", "/i <itemname> <amount>", "Spawns an item in your inv");
        inifile.AddSetting("AdminCommands", "/instako", "Admin Remove Tool");
        inifile.AddSetting("AdminCommands", "/kill <player>", "Kill specified player");
        inifile.AddSetting("AdminCommands", "/loadout", "Spawns admin loadout");
        inifile.AddSetting("AdminCommands", "/save", "Saves all world,player and Fougerite Data");
        inifile.AddSetting("AdminCommands", "/kick <player>", "Kicks player for 30 sec");
        inifile.AddSetting("AdminCommands", "/tphere <player>", "Teleports player to you");
        inifile.AddSetting("AdminCommands", "/tpto <player>", "Teleports you to player");
        inifile.AddSetting("AdminCommands", "/god", "Toggles God Mode");
        inifile.AddSetting("AdminCommands", "/owner", "Displays Structure Ownership");
        inifile.AddSetting("AdminCommands", "/ad toggle", "Toggles Admin Door access");
        inifile.AddSetting("AdminCommands", "/p", "Teleports you 50m in the direction you are facing");
        inifile.AddSetting("AdminCommands", "/setTime <0-24>", "Sets server time");

        inifile.Save();
    }
}




// Function for actions once a player connects to the server
function On_PlayerConnected(Player) {
    var getinifile = iniset();

    var messages = getinifile.GetSetting("Settings", "Messages");
    var prefix = getinifile.GetSetting("Settings", "Prefix");

    if (messages) {
        if (Player.Admin || isMod(Player.SteamID)) {
            Player.MessageFrom("[" + prefix + "]", "[color#FF8000]In order to find more about available commands , please type [color#FF8000]/help");
            Player.MessageFrom("[" + prefix + "]", "[color#FF8000]In order to find more about admin commands , please type [color#FF8000]/help admin");
        } else {
            Player.MessageFrom("[" + prefix + "]", "[color#FF8000]In order to find more about available commands , please type [color#FF8000]/help");
        }
    }
}



// Help command
function On_Command(Player, cmd, args) {
    var getinifile = getinifile();
    var active = getinifile.GetSetting("Settings", "Active");
    var inienum = getinifile.EnumSection("AdminCommands");
    var color1 = getinifile.GetSetting("Settings", "Color1");
    var color2 = getinifile.GetSetting("Settings", "Color2");
    if (active) {

        if (cmd == "help") {
            if (args.Length == 0) {
                Player.MessageFrom("[Location]", "[color#00FFFF]Type [color#FF8000]/location [color#00FFFF]for informations about [color#FF8000]your location on map.");
                Player.MessageFrom("[Starter]", "[color#00FFFF]Type [color#FF8000]/starter [color#00FFFF]to get [color#FF8000]Starter Items");
                Player.MessageFrom("[Ping]", "[color#00FFFF]Type [color#FF8000]/ping [color#00FFFF]for informations about [color#FF8000]Your Ping.");
                Player.MessageFrom("[Destroy]", "[color#00FFFF]Type [color#FF8000]/destroy [color#00FFFF]for informations about [color#FF8000]destroy");
                Player.MessageFrom("[PM]", "[color#00FFFF]Type [color#FF8000]/help pm [color#00FFFF]for informations about [color#FF8000]Private Messages");
                Player.MessageFrom("[PM]", "[color#00FFFF]Type [color#FF8000]/help friends [color#00FFFF]for informations about [color#FF8000]Friend System");
                Player.MessageFrom("[Door Share]", "[color#00FFFF]Type [color#FF8000]/help share [color#00FFFF]for informations about [color#FF8000]Door Sharing");
                if (Player.Admin || isMod(Player.SteamID)) {
                    Player.MessageFrom("[Admin Tool]", "[color#00FFFF]Type [color#FF8000]/help admin [color#00FFFF]for informations about [color#FF8000]admin commands.");
                    Player.MessageFrom("[Admin Tool]", "[color#00FFFF]Type [color#FF8000]/help save [color#00FFFF]for informations about [color#FF8000]Saving MAP");
                }
            }
            if (args.Length == 1) {
                if (args[0] == "admin") {
                    if (Player.Admin || isMod(Player.SteamID)) {
                        Player.MessageFrom("[Admin CMD]", " =============ADMINISTRATION COMMANDS=============");
                        for (var option in inienum) {
                            var name = getinifile.GetSetting("AdminCommands", option);

                            Player.MessageFrom("[Admin CMD]", color1 + option + color2 + " | " + name);
                        }
                    } else {
                        Player.MessageFrom("[Denied]", "[color#FF8000]YOU DO NOT HAVE PERMISSION TO VIEW THIS PAGE !");
                    }
                } else if (args[0] == "friends") {
                    Player.MessageFrom("[Friends]", " =============FRIENDS COMMANDS=============");
                    Player.MessageFrom("[Friends]", " [color#FF8000]/friends  [color#00FFFF]| Displays list of your friends.");
                    Player.MessageFrom("[Friends]", " [color#FF8000]/addfriend <Player>  [color#00FFFF]| Adds player to your friend list.");
                    Player.MessageFrom("[Friends]", " [color#FF8000]/unfriend <Player>  [color#00FFFF]| Removes player from your friends list.");
                } else if (args[0] == "pm") {
                    Player.MessageFrom("[PM INFO]", " =============PRIVATE MESSAGING=============");
                    Player.MessageFrom("[PM INFO]", " [color#FF8000]/pm <Player> <Message>  [color#00FFFF]| Send player a private message.");
                    Player.MessageFrom("[PM INFO]", " [color#FF8000]/r  [color#00FFFF]| Reply to incoming Private message.");
                } else if (args[0] == "share") {
                    Player.MessageFrom("[Door Sharing]", " =============DOOR SHARING=============");
                    Player.MessageFrom("[Door Sharing]", " [color#FF8000]/share <Player>  [color#00FFFF]| Share all doors with player.");
                    Player.MessageFrom("[Door Sharing]", " [color#FF8000]/unshare <Player>  [color#00FFFF]| Unshare all doors with player.");
                } else if (args[0] == "save") {
                    Player.MessageFrom("[Server SAVE]", " =============SERVER SAVE===============");
                    Player.MessageFrom("[Server SAVE]", " [color#FF8000]/save [color#00FFFF]| Save the map and player inventories.");
                }
            }
        }

        if (cmd == "save") {
            if (Player.Admin || isMod(Player.SteamID)) {
                Server.Save();
                Server.Broadcast("[color#00FF00]â˜¢ [color#FFFF00]- Admin executed save command. Data successfully saved! - [color#00FF00]â˜¢");
            } else {
                Player.MessageFrom("[AHC]", "[color#FF8000]Permission Denied.");
            }
        }
    } else {
        Player.MessageFrom("[AHC]", "[color#FF8000]The Plugin is offline.");
    }
}