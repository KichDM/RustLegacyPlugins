//UnlimitedIteminHand.
//Author: CorrosionX
function On_PluginInit(){
    Plugin.CreateTimer("GiveUsesTimer", 1000).Start();
}
function GiveUsesTimerCallback(){
    Server.Players.ForEach(
        function(player) {
            try{
                if (player.Admin && DataStore.Get("unlimitedammo",player.SteamID) == "1") {
                    player.Inventory.InternalInventory.activeItem.SetUses(250);
                    }
            } catch(ignore) { }
        }
    );
       Plugin.KillTimer("GiveUsesTimer");
       Plugin.CreateTimer("GiveUsesTimer", 1000).Start();
}
function On_Command(Player, cmd, args) {
	if (cmd == "uammo") {
		if (DataStore.Get("unlimitedammo",Player.SteamID) == "1")
		{
			DataStore.Add("unlimitedammo", Player.SteamID, 0);
		}
		else
		{
			DataStore.Add("unlimitedammo", Player.SteamID, 1);
		}
	}
}