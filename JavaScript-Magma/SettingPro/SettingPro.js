var MSData = 
{
	dataStoreKey : "MinimalSettings_Data",
	getDataFieldWithPlayer: function(Player, dataField )
	{
		return Player.SteamID+"_"+dataField;
	},
	SetDataForPlayer: function(Player, dataField, dataValue)
	{
		Data.AddTableValue(this.dataStoreKey, this.getDataFieldWithPlayer(Player, dataField), dataValue);
	},
	GetDataForPlayer: function(Player, dataField)
	{
		return Data.GetTableValue(this.dataStoreKey, this.getDataFieldWithPlayer(Player, dataField ));
	}
}

// array add-ons

Array.prototype.contains = function(obj)
{
    var i = this.length;
    while (i--)
        if (this[i] === obj)
            return true;
	return false;
}

// Hooks

// when player enters known command, perform the command and save settings

function On_Command(Player, cmd, args) 
{
	if( IsCommandSupported(cmd) )
	{
		var command = String( cmd );
		var data = MSData.GetDataForPlayer(Player, command);
		
		//replace nude by nudity for same data-store
		if( command == "nude" )
			command = "nudity";
		
		//check for arguments and use it to store data
		if( args.Length > 0 )
		{
			var argument = String(args[0]);
			if(argument == "on")
			{
				data = true;
			}
			else if(argument == "off")
			{
				data = false;
			}
			else
			{
				Player.Message("Unsupported command arguments! Use on or off");
				data = null;
			}
		}
		else // toggle data
		{
			if( data === null )
				data = true;
			
			data = !data;
		}
	
		if( data !== null )
		{
			performCommandWithValue(Player, command, data);
			MSData.SetDataForPlayer(Player, command, data);
		}
	}
}

// when player connects, restore previous settings

function On_PlayerConnected(Player)
{
	var grass_data = MSData.GetDataForPlayer(Player, "grass");
	var banner_data = MSData.GetDataForPlayer(Player, "banner");
	var nudity_data = MSData.GetDataForPlayer(Player, "nudity");

	// set default values and save them
	if( grass_data === null)
	{
		grass_data = false;
		MSData.SetDataForPlayer(Player, "grass", grass_data);
	}

	if( banner_data === null )
	{
		banner_data = false;
		MSData.SetDataForPlayer(Player, "banner", banner_data);
	}

	if( nudity_data === null )
	{
		nudity_data = false;
		MSData.SetDataForPlayer(Player, "nudity", nudity_data);
	}

	// perform default commands
	performCommandWithValue(Player, "grass", grass_data);
	performCommandWithValue(Player, "banner", banner_data);
	performCommandWithValue(Player, "nudity", nudity_data);	
}

// supported commands

function IsCommandSupported( cmd )
{
	var supportedCommands = ["grass","banner","nudity","nude"];	
	
	return supportedCommands.contains(String(cmd));
}

// perform commands 

function performCommandWithValue(Player, command , value)
{
	if( command == "grass" )
	{
		if(value)
			Player.SendCommand("grass.on true");
		else
			Player.SendCommand("grass.on false");
	}
	
	if( command == "banner" )
	{
		if(value)
			Player.SendCommand("gui.show_branding");
		else
			Player.SendCommand("gui.hide_branding");
	}
	
	if( command == "nudity" || command == "nude" )
	{
		if(value)
			Player.SendCommand("censor.nudity true");
		else
			Player.SendCommand("censor.nudity false");
	}
}