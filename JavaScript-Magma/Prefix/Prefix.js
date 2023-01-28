//Prefix v1.2 by glassp

//Special Group List:
//Add STEAMIDs to the list for a new player.

var AdminList = [
STEAMID:000000000,
// Add STEAMIDS of admins here.
];

var VIPList = [
STEAMID:111111111,
// Add STEAMIDS of vips here.
];


// Main function
// Copy the IF statement to add a new prefix.
// You also need to add a array just like above.

function On_Chat(Player, text)
{
	if(AdminList.Contains(Player.SteamID))
	{
		if(text.Contains("!prefixhelp"))
		{
			Player.Message("Prefix v1.3 Commands:");
			Player.Message("!addadmin (STEAMID) - Adds an admin to the list.");
			Player.Message("!addvip (STEAMID) - Adds a vip to the list.");
		}
		if(text.Contains("!addadmin"))
		{
			text = text.replace("!addadmin ", "");
			AdminList.push(text)
		}
		if(text.Contains("!addvip"))
		{
			text = text.replace("!addvip ", "");
			VIPList.push(text)
		}
	}
}

function On_PlayerConnected(Player)
{
	if(AdminList.Contains(Player.SteamID))
	{
		//  Temp Variable   Prefix Color   Prefix  White (For the name)              Chat color 
		var Player.Name = "[color #c0392b] [Admin][color #FFFFFF] " + Player.Name + "[color #e74c3c]"
	}
	if(VIPList.Contains(Player.SteamID))
	{
		var Player.Name = "[color #d35400] [VIP][color #FFFFFF] " + Player.Name + "[color #e67e22]"
	}
}

//This is the best website for finding these colors:
//http://www.colorhexa.com/
//It's best to use a light prefix color then a tad darker chat color. 