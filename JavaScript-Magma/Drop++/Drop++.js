/*
	Official Magma Plugin
	Brought to you by EquiFox17
	Visit us at gomagma.org !
*/

function On_TablesLoaded(Tables)
{
	if (Data.GetConfigValue("Drop++", "Settings", "enabled") == "false")
	{
		Util.Log("Drop++ is disabled, loading canceled.");
	}
	else
	{
		if (Plugin.CreateDir("Tables") == true)
		{	
			ExtractTables(Tables);
			Util.Log("Drop++ : Extracted new tables.");
		}			
		
		for (var name in Tables.Keys)
		{				
			var table = Plugin.GetIni("Tables\\" + name);
			var realTable = Tables[name];			
			realTable.minPackagesToSpawn = table.GetSetting('TableSettings', 'MinToSpawn');
			realTable.maxPackagesToSpawn = table.GetSetting('TableSettings', 'MaxToSpawn');			
			realTable.spawnOneOfEach = table.GetSetting('TableSettings', 'OneOfEach');
			realTable.noDuplicates = table.GetSetting('TableSettings', 'DuplicatesAllowed');
			realTable.noDuplicates = !realTable.noDuplicates;
						
			var c = table.Count() - 1;
			var packs = new LootSpawnList.LootWeightedEntry[c];
			
			for (var i = 1; i <= c; i++)
			{
				var pack = new LootSpawnList.LootWeightedEntry();
				pack.weight = table.GetSetting('Entry' + i, 'Weight');
				pack.amountMin = table.GetSetting('Entry' + i, 'Min');
				pack.amountMax = table.GetSetting('Entry' + i, 'Max');
				
				var objName = table.GetSetting('Entry' + i, 'Name');	

				if (Tables.ContainsKey(objName))
					pack.obj = Tables[objName];
				else				
					pack.obj = Server.Items.Find(objName);							
				
				packs[i -  1] = pack;
			}
			
			realTable.LootPackages = packs;						
		}
	}
}

function ExtractTables(tbls)
{	
	for (var name in tbls.Keys)
	{
		var table = Plugin.CreateIni("Tables\\" + name);
		table.AddSetting('TableSettings', 'MinToSpawn', tbls[name].minPackagesToSpawn);
		table.AddSetting('TableSettings', 'MaxToSpawn', tbls[name].maxPackagesToSpawn);
		table.AddSetting('TableSettings', 'DuplicatesAllowed', !tbls[name].noDuplicates);
		table.AddSetting('TableSettings', 'OneOfEach', tbls[name].spawnOneOfEach);
				
		var cpt = 1;		
		for (var entry in tbls[name].LootPackages)
		{			
			var n = "Entry" + cpt;
			if(entry.obj != null)
			{
				table.AddSetting(n, 'Name', entry.obj.name);
				table.AddSetting(n, 'Weight', entry.weight);
				table.AddSetting(n, 'Min', entry.amountMin);
				table.AddSetting(n, 'Max', entry.amountMax);
				
				cpt++;
			}
		}		
		table.Save();
	}	
}
