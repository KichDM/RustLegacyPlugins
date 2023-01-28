function On_Command(Player, cmd, args) 
{
	if(Data.GetConfigValue("ResourceSpawner", "Settings", "enabled") == "true")
	{
		if(cmd == "spawn")
		{
			if(!Player.Admin)
			{
				Player.Message("Вы не имеете доступа к команде!");
			}
			else if(args.Length < 1) 
			{
			    Player.Message("Введите: /spawn [НАЗВАНИЕ]");
			}
			else
			{
				var loc = Player.Location;
				loc.x = loc.x + 5;
				loc.y = World.GetGround(loc.x, loc.z);

				switch(args[0])
				{
					case "Wood":
						World.Spawn(";res_woodpile", loc);
						Player.Notice("\u2714", "Wood Pile заспавнен!", 3);
						break;
					case "Sulfur":
						World.Spawn(";res_ore1", loc); 
						Player.Notice("\u2714", "Sulfur Ore заспавнен!", 3);
						break;
					case "Metal":
						World.Spawn(";res_ore2", loc);
						Player.Notice("\u2714", "Metal Ore заспавнен!", 3);
						break;
					case "Stone":
						World.Spawn(";res_ore3", loc);
						Player.Notice("\u2714", "Stone Ore заспавнен!", 3);
						break;
					case "Stag":
						World.Spawn(":stag_prefab", loc);
						Player.Notice("\u2714", "Stag заспавнен!", 3);
						break;
					case "Chicken":
						World.Spawn(":chicken_prefab", loc);
						Player.Notice("\u2714", "Chicken заспавнен!", 3);
						break;
					case "Rabbit":
						World.Spawn(":rabbit_prefab_a", loc);
						Player.Notice("\u2714", "Rabbit заспавнен!", 3);
						break;
					case "Bear":
						World.Spawn(":bear_prefab", loc);
						Player.Notice("\u2714", "Bear заспавнен!", 3);
						break;
					case "MBear":
						World.Spawn(":mutant_bear", loc);
						Player.Notice("\u2714", "Mutant Bear заспавнен!", 3);
						break;
					case "Pig":
						World.Spawn(":boar_prefab", loc);
						Player.Notice("\u2714", "Pig заспавнен!", 3);
						break;
					case "Wolf":
						World.Spawn(":wolf_prefab", loc);
						Player.Notice("\u2714", "Wolf заспавнен!", 3);
						break;
					case "MWolf":
						World.Spawn(":mutant_wolf", loc);
						Player.Notice("\u2714", "Mutant Wolf заспавнен!", 3);
						break;
					case "Animals":
						var loc1 = Player.Location;
						var zonex = loc1.x;
						var zonez = loc1.z;
						var zoney = World.GetGround(loc1.x,loc1.z);
						
						for(var i=0;i<25;i++)
						{
							loc1.x = zonex + (i*2);	
							loc1.y = World.GetGround(loc1.x,loc1.z);
							World.Spawn(":wolf_prefab", loc1);
							loc1.z = zonez + (i*2);
							loc1.y = World.GetGround(loc1.x,loc1.z);
							World.Spawn(":wolf_prefab", loc1);
							loc1.x = zonex - (i*2);
							loc1.y = World.GetGround(loc1.x,loc1.z);
							World.Spawn(":mutant_wolf", loc1);
							loc1.z = zonez - (i*2);
							loc1.y = World.GetGround(loc1.x,loc1.z);
							World.Spawn(":mutant_wolf", loc1);
						}
						Player.Notice("\u2714", "Animals заспавнен!", 3);
						break;
					case "Airdrop":
						World.AirdropAtPlayer(Player);
						Player.Notice("\u2708", "Airdrop заспавнен!", 3);
						break;
					case "AmmoBox":
						World.Spawn("AmmoLootBox", loc);
						Player.Notice("\u2327", "Ammo Box заспавнен!", 3);
						break;
					case "MedicalBox":
						World.Spawn("MedicalLootBox", loc);
						Player.Notice("\u2327", "Medical Box заспавнен!", 3);
						break;
					case "LootBox":
						World.Spawn("BoxLoot", loc);
						Player.Notice("\u2327", "Loot Box заспавнен!", 3);
						break;
					case "WeaponBox":
						World.Spawn("WeaponLootBox", loc);
						Player.Notice("\u2327", "Weapon Box заспавнен!", 3);
						break;
					case "SupplyCrate":
						World.Spawn("SupplyCrate", loc);
						Player.Notice("\u2327", "SupplyCrate заспавнен!", 3);
						break;
					default:
						Player.Message("СпавнТаблица: Wood, Sulfur, Metal, Stone, Stag, Chicken, Rabbit, Bear, MBear Pig, Wolf, MWolf");
						Player.Message("СпавнТаблица: Animals, Airdrop, AmmoBox, MedicalBox, LootBox, WeaponBox, SupplyCrate");
						break;
				}
			}
		}
	}
	else
	{
		Player.MessageFrom("ResourceSpawner", "Плагин включен!");
	}
}					


