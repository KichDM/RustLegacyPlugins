//Title: No Wasteland
//Author: CorrosionX
//Description: Prevents players from building in wasteland
//Idea from Rusty Meatball and his "No Wasteland" Oxide plugin
//Version:1.3.3
var fix = [["Campfire", "Camp Fire"], ["Barricade_Fence_Deployable", "Wood Barricade"], ["Large Wood Spike Wall", "Large Spike Wall"], ["Wood Box", "Wood Storage Box"], ["Wood Box Large", "Large Wood Storage"], ["Wood_Shelter", "Wood Shelter"], ["Metal Bars Window", "Metal Window Bars"], ["Wood Door Frame", "Wood Doorway"], ["Metal Door Frame", "Metal Doorway"], ["Wood Spike Wall", "Spike Wall"], ["Wood Window Frame", "Wood Window"], ["Metal Window Frame", "Metal Window"]];
function On_PluginInit(){
	if (!Plugin.IniExists("NoWasteland")){
		var ini = Plugin.CreateIni("NoWasteland");
		ini.AddSetting("Settings", "RefundPlayer", "true");
		ini.AddSetting("Settings", "EvilMode", "false");
		//ini.AddSetting("Settings", "AdminOverride", "false");
		ini.AddSetting("Settings", "Xcoordinates", 3000);
		ini.AddSetting("Settings", "Zcoordinates", 1300);
		ini.Save();
	}
}
function StringFix(str) {
    str = str.replace(/([a-z])([A-Z])/g, '$1 $2');
    for(var i=1; i < fix.length; i++){
        if(str==fix[0]){
            return fix[1];
		}
    	return str;
    }
}
function On_EntityDeployed(Player,Entity){
	if(Player != null && Entity != null){	
		var ini = Plugin.GetIni("NoWasteland");
		var Refund_Player = ini.GetSetting("Settings", "RefundPlayer");
		var Evil_Mode = ini.GetSetting("Settings", "EvilMode");
		var Ent_Destroyed = StringFix(Entity.Name);
		var X_Coord = parseInt(ini.GetSetting("Settings", "Xcoordinates"),10);
		var Z_Coord = parseInt(ini.GetSetting("Settings", "Zcoordinates"),10);
		if(X_Coord > Entity.X || Z_Coord < Entity.Z){
			Player.Notice("You are not allowed to build in Wasteland.");
			Util.DestroyObject(Entity.Object.gameObject);
			if(Refund_Player == "true"){
            	Player.Inventory.AddItem(Ent_Destroyed, 1);
            	Rust.Notice.Inventory(Player.PlayerClient.netPlayer, "1 x " + Ent_Destroyed);			
			}
			if(Evil_Mode == "true"){
				//World.SpawnAtPlayer(":wolf_prefab",Player); Currently Causes errors in console...disabled but can enable if like.
				Server.Broadcast("[color red]" + Player.Name + " is trying to build in Wastelands! Currently @ " + Player.Location);
			}
		}
	}
}