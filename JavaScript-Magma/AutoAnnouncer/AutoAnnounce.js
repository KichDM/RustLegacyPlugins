var AutoAnnounce_namespace = "AutoAnnounce_namespace";
var announce_tag = "[color#FF0000]Server Announce";

function AutoAnnounceCallback(){
	var number_announces = parseInt(Data.GetConfigValue("AutoAnnounce", "Main", "Numberannounces"));
	var curr_announce = parseInt(Data.GetTableValue(AutoAnnounce_namespace, "current_announce"));
	var curr_announce_announceparts = parseInt(Data.GetConfigValue("AutoAnnounce", "announce"+curr_announce, "announceparts"));
	for(var i = 1; i <= curr_announce_announceparts; i++) {
	var announce_announcepart_text = Data.GetConfigValue("AutoAnnounce", "announce"+curr_announce, "announcepart"+i);
	Server.BroadcastFrom(announce_tag, announce_announcepart_text);
}

if(curr_announce == number_announces){
Data.AddTableValue(AutoAnnounce_namespace, "current_announce", 1);
} 

else{
Data.AddTableValue(AutoAnnounce_namespace, "current_announce", curr_announce+1);

}	
}

function On_PluginInit() {
	var tempo = parseInt(Data.GetConfigValue("AutoAnnounce", "Main", "SecondsBetweenannounces"))*1000;
	Data.AddTableValue(AutoAnnounce_namespace, "current_announce", 1);
	Plugin.CreateTimer("AutoAnnounce", tempo).Start();
}