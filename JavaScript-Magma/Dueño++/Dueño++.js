function On_PlayerConnected(player)
{
	ResetPlayerData(player);
}

function On_PlayerDisconnected(player)
{
	ResetPlayerData(player);
}

function On_Command(player, cmd, args)
{
	cmd = Data.ToLower(cmd);
	if (cmd == "dueño")
	{
		Set("Enabled", player.SteamID, !Get("Enabled", player.SteamID, false));
		player.Notice("PROPIETARIOS DE LA ESTRUCTURA  - " + (Get("Enabled", player.SteamID, false) ? "ENCENDIDO " : "APAGADO"));
	}
	else if (cmd == "list_ownercache")
	{
		if (player.Admin)
		{
			var index = Get("Index", 0, []);
			if (index.length > 0)
			{
				player.Message("NOMBRES DE LOS DUEÑOS DE LA ESTRUCTURA :");
				for (var i = 0; i < index.length; i++)
					player.Message(Get("Cache", index[i], "Unknown"));
			}
			else
				player.Message("Sin propietarios !");
		}
		else
			player.Message("No tienes acceso al comando.!");
	}
	else if (cmd == "clear_ownercache")
	{
		if (player.Admin)
		{
			var index = Get("Index", 0, []);
			if (index.length > 0)
			{
				for (var i = 0; i < index.length; i++)
					Set("Cache", index[i], null);
				Set("Index", 0, []);
				player.Message("Se borra la memoria caché de los propietarios.!");
			}
			else
				player.Message("La memoria caché de los propietarios ya está vacía !");
		}
		else
			player.Message("No tienes acceso al comando.!");
	}
}

function On_EntityHurt(e)
{
	if (e.Attacker != null && e.Entity != null)
	{
		if (e.Entity.IsStructure() ||  e.Entity.IsDeployableObject())
		{
			if (Get("Enabled", e.Attacker.SteamID, false))
			{
				e.Entity.GetTakeDamage().health += e.DamageAmount * 2;
				e.Entity.UpdateHealth();

				if (e.Entity.OwnerID != null)
				{
					var OwnerID = e.Entity.OwnerID.ToString();
					if (ShouldNotify(e.Attacker.SteamID, OwnerID))
					{
						var name = GetNameByOwnerID(OwnerID);
						if (name == null)
							e.Attacker.Notice("No se pudo encontrar el apodo del propietario !");
						else
							e.Attacker.Notice(e.Entity.Name + " PROPIEDAD DEL JUGADOR : " + name + ".");
					}
				}
			}
		}
	}
}

function ShouldNotify(attackerID, ownerID)
{
	var lastNotice = Get("LastNotice", attackerID, 0);
	var lastOwnerID = Get("LastOwnerID", attackerID, 0);

	var now = System.DateTime.Now.Ticks;
	var diff = (now - lastNotice) / 10000;

	if (lastOwnerID != ownerID || diff >= 5000)
	{
		Set("LastNotice", attackerID, now);
		Set("LastOwnerID", attackerID, ownerID);
		return true;
	}
	else
		return false;
}

function GetNameByOwnerID(OwnerID)
{
	var name = Get("Cache", OwnerID, null);
	if (name == null)
	{
		var xml = Web.GET("http://" + "steamcommunity.com/profiles/" + OwnerID + "/?xml=1\\");
		var start = xml.indexOf("CDATA[") + 6;
		var stop = xml.indexOf("]]>", start);
		name = xml.substring(start, stop);
		AddPlayerToCache(OwnerID, name);
	}
	return name;
}

function ResetPlayerData(player)
{
	AddPlayerToCache(player.SteamID, player.Name);
	Set("Enabled", player.SteamID, false);
	Set("LastNotice", player.SteamID, null);
	Set("LastOwnerID", player.SteamID, null);
}

function AddPlayerToCache(id, name)
{
	Set("Cache", id, name);
	var index = Get("Index", 0, []);
	for (var i = 0; i < index.length; i++)
		if (index[i] == id)
			return;

	index[index.length] = id;
	Set("Index", 0, index);
}

function Get(name, id, defaultValue)
{
	var data = Data.GetTableValue("StructureOwner_" + name, id);
	return (data == null ? defaultValue : data);
}

function Set(name, id, value)
{
	Data.AddTableValue("StructureOwner_" + name, id, value);
}