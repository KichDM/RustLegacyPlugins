
function On_ServerInit() {
	Server.server_message_name = Data.GetConfigValue("AlternateSystemName", "Name", "SystemName");
}