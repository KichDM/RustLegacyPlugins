PLUGIN.Title = "Resource Manager"
PLUGIN.Description = "Multiplies amount of resources collecable in nodes"
PLUGIN.Author = "Adam Mellor"
PLUGIN.Version = "0.9.4"
PLUGIN.ResourceID = 528

local dateTime = util.GetStaticPropertyGetter( System.DateTime, 'Now' )
local objects = {}
objects.FindOfType = util.GetStaticMethod( UnityEngine.Object._type, "FindObjectsOfType" )
objects.Destroy = util.FindOverloadedMethod( UnityEngine.Object._type, "Destroy", bf.public_static, { UnityEngine.Object } )

--local ResourceTargetType = new( cs.gettype( "ResourceTarget+ResourceTargetType, Assembly-CSharp" ) )
local GenericSpawnInstance = cs.gettype( "GenericSpawnerSpawnList+GenericSpawnInstance, Assembly-CSharp" )

local spawnerOffset = 0

local ValidPrefabs = { [ ';res_ore_1' ] = true, [ ';res_ore_2' ] = true, [ ';res_ore_3' ] = true, [ ';res_woodpile' ] = true,
										[ ':wolf_prefab' ] = true, [ ':mutant_wolf' ] = true, [ ':bear_prefab' ] = true, [ ':mutant_bear' ] = true,
										[ ':chicken_prefab' ] = true, [ ':rabbit_prefab_a' ] = true, [ ':boar_prefab' ] = true, [ ':stag_prefab' ] = true,
										[ 'AmmoLootBox' ] = true, [ 'BoxLoot' ] = true, [ 'WeaponLootBox' ] = true, [ 'MedicalLootBox' ] = true,
										[ 'SupplyCrate' ] = true, [ 'C130' ] = true }
										--, [ 'LootSack' ] = true, [ 'AILootSack' ] = true }
local prefabs = {	[ 'woodpile' ] = ';res_woodpile', [ 'ore1' ] = ';res_ore_1', [ 'ore2' ] = ';res_ore_2', [ 'ore3' ] = ';res_ore_3', 
							[ 'wolf' ] = ':wolf_prefab', [ 'mutant_wolf' ] = ':mutant_wolf', [ 'bear' ] = ':bear_prefab', [ 'mutant_bear' ] = ':mutant_bear', 
							[ 'chicken' ] = ':chicken_prefab', [ 'rabbit' ] = ':rabbit_prefab_a', [ 'boar' ] = ':boar_prefab', [ 'stag' ] = ':stag_prefab',
							[ 'AmmoLootBox' ] = 'AmmoLootBox', [ 'BoxLoot' ] = 'BoxLoot', [ 'WeaponLootBox' ] = 'WeaponLootBox', [ 'MedicalLootBox' ] = 'MedicalLootBox',
							[ 'SupplyCrate' ] = 'SupplyCrate', [ 'C130' ] = 'C130'	}
							--, [ 'LootSack' ] = 'LootSack', [ 'AILootSack' ] = 'AILootSack' }
local staticPrefabs = { [ ';res_ore_1' ] = true, [ ';res_ore_2' ] = true, [ ';res_ore_3' ] = true, [ ';res_woodpile' ] = true,
										[ 'AmmoLootBox' ] = true, [ 'BoxLoot' ] = true, [ 'WeaponLootBox' ] = true, [ 'MedicalLootBox' ] = true,
										[ 'SupplyCrate' ] = true }
										--, [ 'LootSack' ] = true, [ 'AILootSack' ] = true }
local nodes = {	[ 'woodpile' ] = 'WoodPile(Clone)', [ 'ore1' ] = 'Ore1(Clone)', [ 'ore2' ] = 'Ore2(Clone)', [ 'ore3' ] = 'Ore3(Clone)' ,
							[ 'wolf' ] = 'Wolf(Clone)', [ 'mutant_wolf' ] = 'MutantWolf(Clone)', [ 'bear' ] = 'Bear(Clone)', [ 'mutant_bear' ] = 'MutantBear(Clone)', 
							[ 'chicken' ] = 'Chicken_A(Clone)', [ 'rabbit' ] = 'Rabbit_A(Clone)', [ 'boar' ] = 'Boar_A(Clone)', [ 'stag' ] = 'Stag_A(Clone)' 	}
local resources = {	[ 'Leather' ] = 'Leather', [ 'Raw Chicken Breast' ] = 'Raw Chicken Breast', [ 'Cloth' ] = 'Cloth', [ 'Animal Fat' ] = 'Animal Fat' ,
							[ 'Sulfur Ore' ] = 'Sulfur Ore', [ 'Stones' ] = 'Stones', [ 'Metal Ore' ] = 'Metal Ore', [ 'Wood' ] = 'Wood', [ 'Blood' ] = 'Blood',
							[ 'leather' ] = 'Leather', [ 'raw_chicken' ] = 'Raw Chicken Breast', [ 'cloth' ] = 'Cloth', [ 'fat' ] = 'Animal Fat' ,
							[ 'sulfur' ] = 'Sulfur Ore', [ 'stones' ] = 'Stones', [ 'metal' ] = 'Metal Ore', [ 'wood' ] = 'Wood', [ 'blood' ] = 'Blood' 	}
local prefabToSimple = {	[ ';res_woodpile' ] = 'woodpile', [ ';res_ore_1' ] = 'ore1', [ ';res_ore_2' ] = 'ore2', [ ';res_ore_3' ] = 'ore3', 
								[ ':wolf_prefab' ] = 'wolf', [ ':mutant_wolf' ] = 'mutant_wolf', [ ':bear_prefab' ] = 'bear', [ ':mutant_bear' ] = 'mutant_bear', 
								[ ':chicken_prefab' ] = 'chicken', [ ':rabbit_prefab_a' ] = 'rabbit', [ ':boar_prefab' ] = 'boar', [ ':stag_prefab' ] = 'stag',
								[ 'AmmoLootBox' ] = 'AmmoLootBox', [ 'BoxLoot' ] = 'BoxLoot', [ 'WeaponLootBox' ] = 'WeaponLootBox', [ 'MedicalLootBox' ] = 'MedicalLootBox',
								[ 'SupplyCrate' ] = 'SupplyCrate', [ 'C130' ] = 'C130' }
								--, [ 'LootSack' ] = 'LootSack', [ 'AILootSack' ] = 'AILootSack' }

function PLUGIN:Init()
	print( self.Title .. " v" .. self.Version .. " Loading..." )

	self:loadSettings()
	if not self.Settings then return end --if Settings has not loaded then something is seriously wrong

	self.spawnListType, self.spawnedType = false, false
	self.SpawnerByPosKey, self.SpawnerByName = {}, {}
	
	oxmin_plugin = plugins.Find("oxmin")
	if ( not oxmin_plugin ) then
		self.oxmin = false
	else
		self.oxmin = true
		self.FLAG_cangive = oxmin.AddFlag("cangive")
		print( self.Title .. ": cangive oxmin flag successfully added!")
	end

	self.Defaults = {}
	self.Stats = {}
	self.Stats.Type = {}

	self:AddChatCommand( "showres", self.cmdShowRes)
	self:AddChatCommand( "resdeclare", self.cmdResDeclare)
	self:AddCommand( "resman", "set", self.ccmdset )
	self:AddCommand( "resman", "update", self.ccmdUpdate )
	self:AddCommand( "resman", "test", self.ccmdTest )
	self:AddCommand( "resman", "saveSpawnPoints", self.saveSpawnPoints )
	self:AddCommand( "resman", "PrintStats", self.ccmdPrintStats )
	self:AddCommand( "resman", "DebugDump", self.ccmdDebugDump )
	
	self:AddCommand( "resman", "del", self.ccmdDel )
	self:AddCommand( "resman", "show", self.ccmdShow )
	
								
print( self.Title .. " v" .. self.Version .. " Loaded." )
end

function PLUGIN:OnServerInitialized()
	print( self.Title .. ": OnServerInitialized Loading..." ) 
	--get the List types in order to create new List objects
	--do this before destroying any Spawners
	self:getListTypes()
	if not self.Settings.SpawnPoints then
		self:saveDefaultSpawnPoints()
	else
		self:setupSpawnPoints()
	end

	self.CleanupTimer = timer.Repeat( 60 , function()
			self:lootCleanup()
		end)
	
	print( self.Title .. ": OnServerInitialized Loaded." ) 
end

function PLUGIN:Unload()
	if (self.CleanupTimer) then
        self.CleanupTimer:Destroy()
    end
end

function PLUGIN:loadSettings()
	self.SettingsFile = util.GetDatafile( "Resource Manager - Settings" )
	local txt = self.SettingsFile:GetText()
	if ( txt ~= "" ) then
		self.Settings = json.decode( txt )
		print( self.Title .. ": Settings file loaded. " )
	else
		print( self.Title .. ": Settings file not found. Creating new Settings file..." )
		self.Settings = {}
	end
	self:updateSettings()
end

function PLUGIN:saveSettings()
	self.SettingsFile:SetText( json.encode( self.Settings, {
			indent = true,
			keyorder = {
					'VERSION',
					'Enabled',
					'ChatHandle',
					'Debug',
					'resourceNodes',
						'Bear(Clone)',
						'Boar_A(Clone)',
						'Chicken_A(Clone)',
						'MutantBear(Clone)',
						'MutantWolf(Clone)',
						'Ore1(Clone)',
						'Ore2(Clone)',
						'Ore3(Clone)',
						'Rabbit_A(Clone)',
						'Stag_A(Clone)',
						'WoodPile(Clone)',
						'Wolf(Clone)',
							'attackMin',
							'attackMax',
							'attackRate',
							'dropLootBag',
							'gatherEfficiency',
							'health',
							'resources',
								'Animal Fat',
								'Blood',
								'Cloth',
								'Leather',
								'Metal Ore',
								'Raw Chicken Breast',
								'Stones',
								'Sulfur Ore',
									'Min',
									'Max',
					'SpawnPoints',
						'name',
						'radius',
						'respawnInterval',
						'position',
							'x',
							'y',
							'z',
						'_spawnList',
							':bear_prefab',
							':boar_prefab',
							':chicken_prefab',
							':mutant_bear',
							':mutant_wolf',
							':rabbit_prefab_a',
							';res_ore_1',
							';res_ore_2',
							';res_ore_3',
							';res_woodpile',
							':stag_prefab',
							':wolf_prefab',
								'targetPopulation',
								'spawnsPerInterval'
				}
		} ) )
	self.SettingsFile:Save()
end

function PLUGIN:updateSettings()
		local Defaults = {	[ 'VERSION' ] = 0.80, [ 'Debug' ] = false, [ 'ChatHandle' ] = 'Resource Manager', [ 'Enabled' ] = true,
									[ 'resourceNodes' ] = {
									[ 'Bear(Clone)' ]				= { [ 'gatherEfficiency' ]	= 3, [ 'dropLootBag' ] = false,
																		[ 'health' ] = 250,
																		[ 'attackMin' ] = 30, [ 'attackMax' ] = 30, [ 'attackRate' ] = 1.5,
																		[ 'resources' ] = {
																					[ 'Cloth' ]					= { [ 'Min' ] = 10,	[ 'Max' ] = 10 },
																					[ 'Animal Fat' ]			= { [ 'Min' ] = 10,	[ 'Max' ] = 10 },
																					[ 'Leather' ]				= { [ 'Min' ] = 8,	[ 'Max' ] = 8 },
																					[ 'Blood' ]					= { [ 'Min' ] = 6,	[ 'Max' ] = 6 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 5,	[ 'Max' ] = 10 } } },
									[ 'Boar_A(Clone)' ]			= { [ 'gatherEfficiency' ]	= 2,
																		[ 'health' ] = 120,
																		[ 'resources' ] = { 
																					[ 'Cloth' ]					= { [ 'Min' ] = 4,	[ 'Max' ] = 6 },
																					[ 'Animal Fat' ]			= { [ 'Min' ] = 8,	[ 'Max' ] = 10 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 3,	[ 'Max' ] = 5 } } },
									[ 'Chicken_A(Clone)' ]	= { [ 'gatherEfficiency' ]	= 1,
																		[ 'health' ] = 25,
																		[ 'resources' ]	= { 
																					[ 'Cloth' ]					= { [ 'Min' ] = 1,	[ 'Max' ] = 1 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 2,	[ 'Max' ] = 2 } } },
									[ 'MutantBear(Clone)' ]	= { [ 'gatherEfficiency' ]	= 3, [ 'dropLootBag' ] = true,
																		[ 'health' ] = 200,
																		[ 'attackMin' ] = 30, [ 'attackMax' ] = 45, [ 'attackRate' ] = 1.5,
																		[ 'resources' ] = { 
																					[ 'Leather' ]				= { [ 'Min' ] = 1,	[ 'Max' ] = 3 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 1,	[ 'Max' ] = 2 } } } ,
									[ 'MutantWolf(Clone)' ]	= { [ 'gatherEfficiency' ]	= 2,	[ 'dropLootBag' ] = true,
																		[ 'health' ] = 80,
																		[ 'attackMin' ] = 25, [ 'attackMax' ] = 25, [ 'attackRate' ] = 1,
																		[ 'resources' ] = { 
																					[ 'Cloth' ]					= { [ 'Min' ] = 1,	[ 'Max' ] = 2 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 1,	[ 'Max' ] = 2 } } },
									[ 'Ore1(Clone)' ]				= { [ 'gatherEfficiency' ]	= 3,
																		[ 'resources' ] = { 
																					[ 'Metal Ore' ]			= { [ 'Min' ] = 2,	[ 'Max' ] = 5 },
																					[ 'Stones' ]				= { [ 'Min' ] = 3,	[ 'Max' ] = 4 },
																					[ 'Sulfur Ore' ]			= { [ 'Min' ] = 8,	[ 'Max' ] = 10 } } },
									[ 'Ore2(Clone)' ]				= { [ 'gatherEfficiency' ]	= 3,
																		[ 'resources' ] = { 
																					[ 'Metal Ore' ]			= { [ 'Min' ] = 8,	[ 'Max' ] = 10 },
																					[ 'Stones' ]				= { [ 'Min' ] = 3,	[ 'Max' ] = 4 },
																					[ 'Sulfur Ore' ]			= { [ 'Min' ] = 1,	[ 'Max' ] = 4 } } },
									[ 'Ore3(Clone)' ]				= { [ 'gatherEfficiency' ]	= 3,
																		[ 'resources' ] = {
																					[ 'Metal Ore' ]			= { [ 'Min' ] = 1,	[ 'Max' ] = 3 },
																					[ 'Stones' ]				= { [ 'Min' ] = 10,	[ 'Max' ] = 15 },
																					[ 'Sulfur Ore' ]			= { [ 'Min' ] = 1,	[ 'Max' ] = 3 } } },
									[ 'Rabbit_A(Clone)' ]		= { [ 'gatherEfficiency' ]	= 1,
																		[ 'health' ] = 25,
																		[ 'resources' ] = {
																					[ 'Cloth' ]					= { [ 'Min' ] = 2,	[ 'Max' ] = 4 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 1,	[ 'Max' ] = 1 } } },
									[ 'Stag_A(Clone)' ]			= { [ 'gatherEfficiency' ]	= 2,
																		[ 'health' ] = 80,
																		[ 'resources' ] = { 
																					[ 'Cloth' ]					= { [ 'Min' ] = 8,	[ 'Max' ] = 10 },
																				[ 'Animal Fat' ]				= { [ 'Min' ] = 3,	[ 'Max' ] = 3 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 3,	[ 'Max' ] = 5 } } },
									[ 'Wolf(Clone)' ]				= { [ 'gatherEfficiency' ]	= 2, [ 'dropLootBag' ] = false,
																		[ 'health' ] = 125,
																		[ 'attackMin' ] = 15, [ 'attackMax' ] = 15, [ 'attackRate' ] = 1.5,
																		[ 'resources' ] = { 
																					[ 'Cloth' ]					= { [ 'Min' ] = 20,	[ 'Max' ] = 20 },
																					[ 'Animal Fat' ]			= { [ 'Min' ] = 4,	[ 'Max' ] = 5 },
																					[ 'Blood' ]					= { [ 'Min' ] = 1,	[ 'Max' ] = 3 },
																		[ 'Raw Chicken Breast' ]	= { [ 'Min' ] = 3,	[ 'Max' ] = 5 } } },
									[ 'WoodPile(Clone)' ]		= { [ 'gatherEfficiency' ]	= 10,
																		[ 'resources' ] = { 
																					[ 'Wood' ]				= { [ 'Min' ] = 60,	[ 'Max' ] = 100 } } },
									}
			}
	if ( not self.Settings.VERSION or ( Defaults.VERSION > self.Settings.VERSION ) ) then
		print( self.Title .. ": SettingsDefaults, Settings file is outdated, updating to v" .. Defaults.VERSION )
		for _key1, _value1 in pairs( Defaults ) do
		--	print( type( _value1 ) )
			if _key1 == 'SpawnPoints' then
				--dont change anything in SpawnPoints section
			elseif ( type( _value1 ) == "table" ) then
				if ( not self.Settings[ _key1 ] ) then self.Settings[ _key1 ] = {} end
				for _key2, _value2 in pairs( Defaults[ _key1 ] ) do
					if ( type( _value2 ) == "table" ) then
						if ( not self.Settings[ _key1 ][ _key2 ] ) then self.Settings[ _key1 ][ _key2 ] = {} end
						for _key3, _value3 in pairs( Defaults[ _key1 ][ _key2 ] ) do
							if ( not self.Settings[ _key1 ][ _key2 ][ _key3 ] and self.Settings[ _key1 ][ _key2 ][ _key3 ] == nil  ) then --also test for bool false
								print( self.Title .. ": Adding Key: " .. _key3 .. " with Value: " .. tostring( _value3 ) .. " to group: " .. _key1 .. "." .. _key2 )
								self.Settings[ _key1 ][ _key2 ][ _key3 ] = _value3
							end
						end
					elseif ( not self.Settings[ _key1 ][ _key2 ] and self.Settings[ _key1 ][ _key2 ] == nil  ) then --also test for bool false
						print( self.Title .. ": Adding Key: " .. _key2 .. " with Value: " .. tostring( _value2 ) .. " to group: " .. _key1 )
						self.Settings[ _key1 ][ _key2 ] = _value2
					end
				end
			elseif ( not self.Settings[ _key1 ] and self.Settings[ _key1 ] == nil ) then 
				print( self.Title .. ": Adding Key: " .. _key1 .. " with Value: " .. tostring( _value1 ) )
				self.Settings[ _key1 ] = _value1
			end
		end
		print ( "Removing Obselete Items" )
		for _key1, _value1 in pairs( self.Settings ) do
			if _key1 == 'SpawnPoints' then
				--dont change anything in SpawnPoints section
			elseif ( type( _value1 ) == "table" ) then
				for _key2, _value2 in pairs( self.Settings[ _key1 ] ) do
					if ( type( _value2 ) == "table" ) then
						for _key3, _value3 in pairs( self.Settings[ _key1 ][ _key2 ] ) do
							if ( not Defaults[ _key1 ][ _key2 ][ _key3 ] and Defaults[ _key1 ][ _key2 ][ _key3 ] == nil  ) then --also test for bool false
								print( self.Title .. ": Removing Key: " .. _key3 .. " with Value: " .. tostring( _value3 ) .. " from group: " .. _key1 .. "." .. _key2 )
								self.Settings[ _key1 ][ _key2 ][ _key3 ] = nil
							end
						end
					elseif ( not Defaults[ _key1 ][ _key2 ] and Defaults[ _key1 ][ _key2 ] == nil  ) then --also test for bool false
						print( self.Title .. ": Removing Key: " .. _key2 .. " from group: " .. _key1 )
						self.Settings[ _key1 ][ _key2 ] = nil
					end
				end
			elseif ( not Defaults[ _key1 ] and Defaults[ _key1 ] == nil ) then
				print( self.Title .. ": Removing Key: " .. _key1 )
				self.Settings[ _key1 ] = nil
			end
		end
		self:saveSettings()
	end
end

function PLUGIN:loadSpawnLists()
end

function PLUGIN:loadDefaultSpawnLists()
end

function PLUGIN:saveSpawnLists()
end

function PLUGIN:saveDefaults()
	self.DefaultsFile = util.GetDatafile( "Resource Manager - Defaults" )
	self.DefaultsFile:SetText( json.encode( self.Defaults, { indent = true } ) )
	self.DefaultsFile:Save()
end

function PLUGIN:saveDefaultSpawnPoints()
	self.Settings.SpawnPoints = self:getSpawners()
	local index = 1
	local _tbl = {}
	for posKey, SpawnPoint in pairs( self.Settings.SpawnPoints ) do
		local Spawner = self.SpawnerByPosKey[ posKey ]
		local newName = false
		if Spawner then
			local place = self:getPlaceName( Spawner.transform.position )
			place = string.gsub( place, " ", "")
			newName = tostring( place .. "_" .. SpawnPoint.name )
		end
		if newName then
			if _tbl[ newName ] then
				_tbl[ newName ] = _tbl[ newName ] + 1
				SpawnPoint.name = tostring( newName .. _tbl[ newName ] )
				--index = index + 1
			else
				SpawnPoint.name = newName
				_tbl[ SpawnPoint.name ] = 1
			end
		elseif _tbl[ SpawnPoint.name ] then
			_tbl[ SpawnPoint.name ] = _tbl[ SpawnPoint.name ] + 1
			SpawnPoint.name = tostring( SpawnPoint.name .. _tbl[ SpawnPoint.name ] )
		else
			_tbl[ SpawnPoint.name ] = 1
		end
	end
	self:saveSettings()
	return true
end

function PLUGIN:getPlaceName( position )
	local LocationPoints = {
            { name = "Hacker Valley South", x = 5907, z = -1848 },
            { name = "Hacker Mountain South", x = 5268, z = -1961 },
            { name = "Hacker Valley Middle", x = 5268, z = -2700 },
            { name = "Hacker Mountain North", x = 4529, z = -2274 },
            { name = "Hacker Valley North", x = 4416, z = -2813 },
            { name = "Wasteland North", x = 3208, z = -4191 },
            { name = "Wasteland South", x = 6433, z = -2374 },
            { name = "Wasteland East", x = 4942, z = -2061 },
            { name = "Wasteland West", x = 3827, z = -5682 },
            { name = "Sweden", x = 3677, z = -4617 },
            { name = "Everust Mountain", x = 5005, z = -3226 },
            { name = "North Everust Mountain", x = 4316, z = -3439 },
            { name = "South Everust Mountain", x = 5907, z = -2700 },
            { name = "Metal Valley", x = 6825, z = -3038 },
            { name = "Metal Mountain", x = 7185, z = -3339 },
            { name = "Metal Hill", x = 5055, z = -5256 },
            { name = "Resource Mountain", x = 5268, z = -3665 },
            { name = "Resource Valley", x = 5531, z = -3552 },
            { name = "Resource Hole", x = 6942, z = -3502 },
            { name = "Resource Road", x = 6659, z = -3527 },
            { name = "Beach", x = 5494, z = -5770 },
            { name = "Beach Mountain", x = 5108, z = -5875 },
            { name = "Coast Valley", x = 5501, z = -5286 },
            { name = "Coast Mountain", x = 5750, z = -4677 },
            { name = "Coast Resource", x = 6120, z = -4930 },
            { name = "Secret Mountain", x = 6709, z = -4730 },
            { name = "Secret Valley", x = 7085, z = -4617 },
            { name = "Factory Radtown", x = 6446, z = -4667 },
            { name = "Small Radtown", x = 6120, z = -3452 },
            { name = "Big Radtown", x = 5218, z = -4800 },
            { name = "Hangar", x = 6809, z = -4304 },
            { name = "Tanks", x = 6859, z = -3865 },
            { name = "Civilian Forest", x = 6659, z = -4028 },
            { name = "Civilian Mountain", x = 6346, z = -4028 },
            { name = "Civilian Road", x = 6120, z = -4404 },
            { name = "Ballzack Mountain", x =4316, z = -5682 },
            { name = "Ballzack Valley", x = 4720, z = -5660 },
            { name = "Spain Valley", x = 4742, z = -5143 },
            { name = "Portugal Mountain", x = 4203, z = -4570 },
            { name = "Portugal", x = 4579, z = -4637 },
            { name = "Lone Tree Mountain", x = 4842, z = -4354 },
            { name = "Forest", x = 5368, z = -4434 },
            { name = "Civ Two", x = 5725, z = -4280 },
            { name = "Rad-Town Valley", x = 5907, z = -3400 },
            { name = "Next Valley", x = 4955, z = -3900 },
            { name = "Silk Valley", x = 5674, z = -4048 },
            { name = "French Valley", x = 5995, z = -3978 },
            { name = "Ecko Valley", x = 7085, z = -3815 },
            { name = "Ecko Mountain", x = 7348, z = -4100 },
            { name = "Middle Mountain", x = 6346, z = -4028 },
            { name = "Zombie Hill", x = 6396, z = -3428 }
        }
		
        local coords = position

        local min = -1
        local minIndex = -1
        for i = 1, #LocationPoints do
           if (minIndex==-1) then
                min = (LocationPoints[i].x-coords.x)^2+(LocationPoints[i].z-coords.z)^2
                minIndex = i
           else
                local dist = (LocationPoints[i].x-coords.x)^2+(LocationPoints[i].z-coords.z)^2
                if (dist<min) then
                    min = dist
                    minIndex = i
                end
           end
        end

        return LocationPoints[minIndex].name
end

function PLUGIN:CanUserAdmin ( netuser )
	if ( netuser:CanAdmin() ) or ( oxmin_Plugin:HasFlag(netuser, self.FLAG_cangive, false) ) then
		return true
	else
		return false
	end
end

function PLUGIN:msgPrint( netuser, msg, sendto )
	if sendto == 'chat' then
		rust.SendChatToUser( netuser, self.Settings.ChatHandle, msg )
	elseif sendto == 'echo' then
		rust.RunClientCommand( netuser, "echo " .. msg  )
	else
		print( msg )
	end
end

function PLUGIN:getSettings( objName, setting, ResourceItemName )
	if not objName then
		return false, nil, tostring( self.Title .. ": getSettings, objName not provided" )
	elseif not setting then
		return false, nil, tostring( self.Title .. ": getSettings, setting not provided" )
	elseif setting == 'gatherEfficiency' then
		local _msg = tostring( "Gather Efficency setting for \"" .. objName .. "\" = " .. self.Settings.resourceNodes[ objName ].gatherEfficiency )
		return true, self.Settings.resourceNodes[ objName ].gatherEfficiency, _msg
	elseif setting == 'minmax' and ResourceItemName then
		local values = self.Settings.resourceNodes[ objName ].resources[ ResourceItemName ]
		local _msg = tostring( "Resource Values for \"" .. objName .. "\", \"" .. ResourceItemName .. "\" = " .. values.Min .. " - " .. values.Max )
		return true, nil, _msg
	elseif self.Settings.resourceNodes[ objName ][ setting ] then
		local _msg = tostring( "Current [ '" .. setting .. "' ] value for \"" .. objName .. "\" = " .. self.Settings.resourceNodes[ objName ][ setting ] )
		return true, self.Settings.resourceNodes[ objName ][ setting ], _msg
	else
		return false, nil, tostring( self.Title .. ": getSettings, Invalid Name provided" )
	end
end
	
function PLUGIN:prefabMultipy( netuser, objName, value, sendto )
	local msg = false
	if tonumber( value ) then
		for posKey, SpawnPoint in pairs( self.Settings.SpawnPoints ) do
			if SpawnPoint._spawnList[ objName ] then
				local SpawnTable = SpawnPoint._spawnList[ objName ]
				SpawnTable.targetPopulation = SpawnTable.targetPopulation * value
				msg = tostring( "All " .. objName .. " resource spawns have been increased by " .. value .. " times." )
			end
		end
	end
	if msg then self:msgPrint( netuser, msg, sendto ) end
end

function PLUGIN:ccmdDel( arg )
	local SpawnPointName = tostring( arg:GetString( 0, "text" ) )
	if SpawnPointName == "text" then SpawnPointName = false end
	local posKey = false
		if SpawnPointName and self.SpawnerByName[ SpawnPointName ] then
		local Spawner = self.SpawnerByName[ SpawnPointName ]
		posKey = self:getPositionKey( Spawner.transform.position )
	end
	if not SpawnPointName or SpawnPointName == 'help' then
		local msg = tostring( "\n" .. self.Title .. ": Delete Spawner:\n" ..
			"resman.del \"Spawner Name\"" .. "\n" ..
			"\tDelete Spawner from game and from the configuration." .. "\n" )
		self:msgPrint( netuser, msg, sendto )
	elseif self.SpawnerByName[ SpawnPointName ] or self.Settings.SpawnPoints[ posKey ] then
		self:deleteSpawnerByName( SpawnPointName )
		local msg = tostring( "\n" .. self.Title .. ": Delete Spawner:\n" ..
			"\tSpawner name " .. SpawnPointName .. " deleted." .. "\n" )
		self:msgPrint( netuser, msg, sendto )
	elseif not self.SpawnerByName[ SpawnPointName ] or not self.Settings.SpawnPoints[ posKey ] then
		local msg = tostring( "\n" .. self.Title .. ": Delete Spawner:\n" ..
			"\tSpawner name " .. SpawnPointName .. " not found in the configuration." .. "\n" )
		self:msgPrint( netuser, msg, sendto )
	end
	self:saveSettings()
	return true
end

function PLUGIN:ccmdUpdate( arg )
	print( self.Title .. ": Loading saved config..." )
	self:loadSettings()
	print( self.Title .. ": Updating Spawned Resources..." )
	local resourceTargets = objects.FindOfType( Rust.ResourceTarget._type )
	print( self.Title .. ": Found ".. tostring( resourceTargets.Length ) .. " spawned resources..." )
	for i = 0, tonumber( resourceTargets.Length - 1 ) do
		local resourceTarget = resourceTargets[ i ];
		self:resourceNodeLoaded( resourceTarget, true )
	end
	print( self.Title .. ": Updating Spawnpoints..." )
	self:setupSpawnPoints()
	print( self.Title .. " Updates complete." )
	return true
end

function PLUGIN:ccmdShow( arg )
	local SpawnPointName = tostring( arg:GetString( 0, "text" ) )
	if SpawnPointName == "text" then SpawnPointName = false end
	self:showSpawners( SpawnPointName )
	return true
end

function PLUGIN:nameToPosKey( SpawnPointName )
	local posKey = false
	if SpawnPointName and self.SpawnerByName[ SpawnPointName ] then
		local Spawner = self.SpawnerByName[ SpawnPointName ]
		posKey = self:getPositionKey( Spawner.transform.position )
	end
	return posKey
end

function PLUGIN:showSpawners( SpawnPointName )
	local posKey = self:nameToPosKey( SpawnPointName )
	if not SpawnPointName or SpawnPointName == 'help' then
		local msg = tostring( "\n" .. self.Title .. ": Show Spawners:\n" ..
			"resman.show \"all\"" .. "\n" ..
			"\tList all Spawners." .. "\n" .. "\n" ..
			"resman.show \"Spawner Name\"" .. "\n" ..
			"\tShow Spawner configuration." .. "\n" )
		print( msg )
	elseif SpawnPointName == 'all' then
		print( "Spawnpoints:" )
		for posKey, SpawnPoint in pairs( self.Settings.SpawnPoints ) do
			print( "\t" .. SpawnPoint.name )
		end
	elseif posKey and self.Settings.SpawnPoints[ posKey ] then
		local SpawnPoint = self.Settings.SpawnPoints[ posKey ]
		print( "Spawnpoint: " .. SpawnPoint.name )
		local posKey = self:getPositionKey( SpawnPoint.position )
		print( "\tLocation: " .. posKey )
		print( "\tRadius: " .. SpawnPoint.radius )
		print( "\tRespawn Interval: " .. SpawnPoint.respawnInterval )
		print( "\tResource Spawns: " )
		
		print( string.format("%-45s%-20s%-20s%-25s", "", "Name", "Target Population", "Spawns Per Interval" ) )
		for prefabName, SpawnTable in pairs( SpawnPoint._spawnList ) do
			print( string.format("%-45s%-20s%-20d%-25d", "", prefabToSimple[ prefabName ], SpawnTable.targetPopulation, SpawnTable.spawnsPerInterval ) )
		end
	elseif not posKey then
		local msg = tostring( "\n" .. self.Title .. ": Show Spawners:\n" ..
			"\tSpawner name " .. SpawnPointName .. " not found in the configuration." .. "\n" )
		self:msgPrint( netuser, msg, sendto )
	end
	return true
end

function PLUGIN:updateResourceNumVal( objName, setting, value )
	if objName and prefabs[ objName ] and nodes[ objName ] then objName = nodes[ objName ] end
	if self.Settings.resourceNodes[ objName ] then
		if tonumber( value ) then
			self.Settings.resourceNodes[ objName ][ setting ] = value
		end
		local _b, _value , _msg = self:getSettings( objName, setting )
		if _b then self:msgPrint( netuser, _msg, sendto ) end
	end
end

function PLUGIN:ccmdset( arg )
	local netuser = arg.argUser
	if ( netuser and not self:CanUserAdmin( netuser ) ) then return false end
	
	local sendto = 'console'
	if netuser then sendto = 'echo' end

	local objName = tostring( arg:GetString( 0, "text" ) )
	local setting = tostring( arg:GetString( 1, "text" ) )
	local value = tostring( arg:GetString( 2, "text" ) )
	local value2 = tostring( arg:GetString( 3, "text" ) )
	if objName == "text" then objName = false end
	if setting == "text" then setting = false end
	if value == "text" then value = false end
	if value2 == "text" then value2 = false end
	value = tonumber( value )
	value2 = tonumber( value2 )

	if setting and resources[ setting ] then setting = resources[ setting ] end

	if not objName or objName == 'help' then
		local msg = tostring( "\n" .. self.Title .. ": Valid options are:\n" .. "\n" ..
				"resman.set \"Spawner Name\" radius [meters]" .. "\n" ..
				"\tChange the Radius for \"Spawner Name\" to [meters]." .. "\n" ..
				"resman.set \"Spawner Name\" interval [seconds]" .. "\n" ..
				"\tChange the respawn interval for \"Spawner Name\" to [seconds]." .. "\n" ..
				"resman.set \"Spawner Name\" \"Node Name\" [Target population] [count per interval]" .. "\n" ..
				"\tSet the number of Resources of \"Node Name\" located at \"Spawner Name\" to [Target population]" .. "\n" ..
				"\tIf the [Target population] is zero, it will remove it from the config altogether." .. "\n" ..
				"\t\tThe [count per interval] sets the most the game will create each respawn interval." .. "\n" ..
				"\t\t This is optional and will default to 1." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" multiply [value]" .. "\n" ..
				"\tMultiply the number of Resources of \"Node Name\" type spawned by [value] times." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" gatherEfficiency [value]" .. "\n" ..
				"\tChange how many resources are collected from \"Node Name\" per swing." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" health [value]" .. "\n" ..
				"\tChange the health of \"Node Name\"." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" attackMin [value]" .. "\n" ..
				"\tChange the Minimum damage done by \"Node Name\" per attack." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" attackMax [value]" .. "\n" ..
				"\tChange the Maximum damage done by \"Node Name\" per attack." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" attackRate [value]" .. "\n" ..
				"\tChange how fast \"Node Name\" will attack, in Seconds." .. "\n" .. "\n" ..
				
				"resman.set \"Node Name\" \"Resource\" [value]" .. "\n" ..
				"\tMultiply the Min and Max values of \"Resource\" gathered from \"Node Name\" by [value] times." .. "\n" .. "\n" ..
				
				 "\n" )
				
				
		self:msgPrint( netuser, msg, sendto )
	elseif self.SpawnerByName[ objName ] then
		local posKey = self:nameToPosKey( objName )
		if not setting then
			self:showSpawners( objName )
		elseif setting == 'radius' then
			if value and value > 0 then
				self.Settings.SpawnPoints[ posKey ].radius = value
				print( "Radius for SpawnPoint: " .. objName .. " updated to " .. self.Settings.SpawnPoints[ posKey ].radius .. " meters." )
			end
		elseif setting == 'interval' then
			if value and value > 0 then
				self.Settings.SpawnPoints[ posKey ].respawnInterval = value
				print( "Respawn Interval for SpawnPoint: " .. objName .. " updated to " .. self.Settings.SpawnPoints[ posKey ].respawnInterval .. " seconds." )
			end
		elseif prefabs[ setting ] then
			local prefabName = prefabs[ setting ]
			if value and value > 0 then
				if not self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ] then
					self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ] = {}
					self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ].targetPopulation = value
					self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ].spawnsPerInterval = value2 or 1
				end
				self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ].targetPopulation = value
				if value2 then
					self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ].spawnsPerInterval = value2
				end
				print( "Will spawn up to " ..
					self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ].targetPopulation .. " x " .. setting ..
					" for Spawnpoint: " .. objName .. "." )
				print( "each interval ( " .. self.Settings.SpawnPoints[ posKey ].respawnInterval .. " seconds ) will spawn up to " ..
					self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ].spawnsPerInterval .. "." )
			elseif value and value == 0 then
				self.Settings.SpawnPoints[ posKey ]._spawnList[ prefabName ] = nil
				print( "Removing " .. prefabs[ setting ] .. " from spawning at Spawnpoint: " .. objName )
			end
		end
	elseif not setting then
	elseif setting == 'multiply' then
		if prefabs[ objName ] then
			if objName and prefabs[ objName ] then objName = prefabs[ objName ] end
			self:prefabMultipy( netuser, objName, value, sendto )
		elseif objName == 'all' then
			--for objName, _ in pairs( self.Settings.prefabMultiplier ) do
			for simple, prefabName in pairs( prefabs ) do
				self:prefabMultipy( netuser, prefabName, value, sendto )
			end
		end
	elseif setting == 'gatherEfficiency' then
		if prefabs[ objName ]  then
			self:updateResourceNumVal( objName, setting, value )
			--[[
			if objName and nodes[ objName ] then objName = nodes[ objName ] end
			if tonumber( value ) then
				self.Settings.resourceNodes[ objName ].gatherEfficiency = value
			end
			local _b, _value , _msg = self:getSettings( objName, setting )
			if _b then self:msgPrint( netuser, _msg, sendto ) end
			]]--
		elseif objName == 'all' then
			for objName, _ in pairs( self.Settings.resourceNodes ) do
				self:updateResourceNumVal( objName, setting, value )
			--[[
				local _b, _value , _msg = self:getSettings( objName, setting )
				if _b then self:msgPrint( netuser, _msg, sendto ) end
			]]--
			end
		end
	elseif setting == 'health' then
		self:updateResourceNumVal( objName, setting, value )
	elseif setting == 'attackMin' then
		self:updateResourceNumVal( objName, setting, value )
	elseif setting == 'attackMax' then
		self:updateResourceNumVal( objName, setting, value )
	elseif setting == 'attackRate' then
		self:updateResourceNumVal( objName, setting, value )
	elseif nodes[ objName ]  and resources[ setting ] then
		if objName and nodes[ objName ] then objName = nodes[ objName ] end
			self:updateItemSettings( objName, setting, value )
		local _b, _value , _msg = self:getSettings( objName, 'minmax', setting )
		if _b then self:msgPrint( netuser, _msg, sendto ) end
	elseif nodes[ objName ] and setting == 'all' then
		if objName and nodes[ objName ] then objName = nodes[ objName ] end
		for setting, _ in pairs( self.Settings.resourceNodes[ objName ].resources ) do
			self:updateItemSettings( objName, setting, value )
			local _b, _value , _msg = self:getSettings( objName, 'minmax', setting )
			if _b then self:msgPrint( netuser, _msg, sendto ) end
		end
	else
		self:msgPrint( netuser, tostring( self.Title .. ": ccmdset, Unknown Error Occured", sendto ) )
	end
	self:saveSettings()
	return true
end

function PLUGIN:updateItemSettings( objName, setting, multiplier )
	if objName and setting and tonumber( multiplier ) then
		if self.Defaults[ objName ] and self.Defaults[ objName ][ 'resources' ][ setting ] then
			self.Settings.resourceNodes[ objName ].resources[ setting ].Min = math.floor( self.Defaults[ objName ].resources[ setting ].Min * multiplier )
			self.Settings.resourceNodes[ objName ].resources[ setting ].Max = math.floor( self.Defaults[ objName ].resources[ setting ].Max * multiplier )
			end
	end
end

function PLUGIN:ccmdTest( arg )
	return true
end

function PLUGIN:ccmdDebugDump( arg )
	local netuser = arg.argUser
	if ( netuser and not self:CanUserAdmin( netuser ) ) then return false end
	
	local sendto = 'console'
	if netuser then sendto = 'echo' end

	local spawnerName = tostring( arg:GetString( 0, "text" ) )
	if spawnerName == "text" then spawnerName = false end

	local line = "\n"
	local GenericSpawners = objects.FindOfType( Rust.GenericSpawner._type )
	print( "Resource Manager, Found: " .. tostring( GenericSpawners.Length ) .. " Spawners." )
	for i = 0, tonumber( GenericSpawners.Length - 1 ) do
		local Spawner = GenericSpawners[ i ]
		local SpawnPoint = self:getSpawnerData( Spawner )
		if not spawnerName or SpawnPoint.name == spawnerName then
			local loc = tostring( Spawner.transform.position.x .. "," .. Spawner.transform.position.y .. "," .. Spawner.transform.position.z )
			local newline = string.format("\n%-5s%-40s\n", i, SpawnPoint.name )
			line = line .. newline
			local newline = string.format("%-10s%-20s%5d\n", "", 'tRadius: ', SpawnPoint.radius )
			line = line .. newline
			local newline = string.format("%-10s%-20s%5d\n", "", 'Respawn Interval: ', SpawnPoint.respawnInterval )
			line = line .. newline
			local newline = string.format("%-10s%-20s%-25s\n", "", 'Location: ', loc )
			line = line .. newline

			local spawnEnum = Spawner._spawnList:GetEnumerator()
			while spawnEnum:MoveNext() do
				local removeList = {}
				local Spawn = spawnEnum.Current
				local newline = string.format("%-35s%-20s%3d/%-3d\n", "", Spawn.prefabName, Spawn.spawned.count, Spawn.targetPopulation )
				line = line .. newline
			end
		end
	end
	print( line )
	return true
end

function PLUGIN:lootCleanup()
	local GenericSpawners = objects.FindOfType( Rust.GenericSpawner._type )
	for i = 0, tonumber( GenericSpawners.Length - 1 ) do
		local Spawner = GenericSpawners[ i ]
		local spawnEnum = Spawner._spawnList:GetEnumerator()
		while spawnEnum:MoveNext() do
			local removeList = {}
			local Spawn = spawnEnum.Current
			--print( "Spawn = " .. tostring( Spawn ) )
			local spawnedEnum = Spawn.spawned:GetEnumerator()
			while spawnedEnum:MoveNext() do
				local spawned = spawnedEnum.Current
				if spawned:ToString() == 'null' then
					table.insert( removeList, spawned )
				end
			end
			if removeList and #removeList > 0 then
				for key, spawned in pairs( removeList ) do
					Spawn.spawned:Remove( spawned )
				end
			end
		end
	end
end

function PLUGIN:ccmdPrintStats( )
	--self:dumpData( 'self.Stats', self.Stats )
	local line = "\n"
	local GenericSpawners = objects.FindOfType( Rust.GenericSpawner._type )
	print( "Resource Manager, Found: " .. tostring( GenericSpawners.Length ) .. " Spawners." )
	for i = 0, tonumber( GenericSpawners.Length - 1 ) do
		local Spawner = GenericSpawners[ i ]
		local SpawnPoint = self:getSpawnerData( Spawner )
		local loc = tostring( Spawner.transform.position.x .. "," .. Spawner.transform.position.y .. "," .. Spawner.transform.position.z )
		local newline = string.format("\n%-5s%-40s\n", i, SpawnPoint.name )
		line = line .. newline
		local newline = string.format("%-5s%-25s%5d\n", "", loc, SpawnPoint.respawnInterval )
		line = line .. newline

		local spawnEnum = Spawner._spawnList:GetEnumerator()
		while spawnEnum:MoveNext() do
			local Spawn = spawnEnum.Current
			local newline = string.format("%-45s%-20s%3d/%-3d\n", "", Spawn.prefabName, Spawn.spawned.count, Spawn.targetPopulation )
			line = line .. newline
		end
	end
	print( line )
	return true
end

function PLUGIN:getListTypes()
	local GenericSpawners = objects.FindOfType( Rust.GenericSpawner._type )
	for i = 0, tonumber( GenericSpawners.Length - 1 ) do
		local Spawner = GenericSpawners[ i ];
		if Spawner and Spawner._spawnList then
			self.spawnListType = Spawner._spawnList:GetType()
			local entries = tonumber( Spawner._spawnList.count ) or 0
			if self.spawnListType and entries > 0 then
				local spawnEnum = Spawner._spawnList:GetEnumerator()
				while spawnEnum:MoveNext() do
					local spawnInstance = spawnEnum.Current
					if spawnInstance.spawned and spawnInstance.spawned ~= 'spawned' then
						self.spawnedType  = spawnInstance.spawned:GetType()
					end
				end
				if self.spawnListType and self.spawnedType then
					break
				end
			end
		end
	end
end

function PLUGIN:newSpawnList()
	if self.spawnListType then
			return new( self.spawnListType )
	else
		self:getListTypes()
		if self.spawnListType then
			return self:newSpawnList()
		end
	end
	return false
end

function PLUGIN:newSpawnedList()
	if self.spawnedType then
		return new( self.spawnedType )
	else
		self:getListTypes()
		if self.spawnedType then
			return self:newSpawnedList()
		end
	end
	return false
end

function PLUGIN:updateSpawnerTables( Spawner )
	local posKey = self:getPositionKey( Spawner.transform.position )
	local SpawnPoint = self.Settings.SpawnPoints[ posKey ]
	if not self.SpawnerByName[ SpawnPoint.name ] then
		self.SpawnerByName[ SpawnPoint.name ] = Spawner
	end
	if not self.SpawnerByPosKey[ posKey ] then
		self.SpawnerByPosKey[ posKey ] = Spawner
	end
end

function PLUGIN:setupSpawnPoints()
	if self.Settings.SpawnPoints then
		local GenericSpawners = objects.FindOfType( Rust.GenericSpawner._type )
		for i = 0, tonumber( GenericSpawners.Length - 1 ) do
			local Spawner = GenericSpawners[ i ];
			local posKey = self:getPositionKey( Spawner.transform.position )
			if self.Settings.SpawnPoints[ posKey ] then
				self:updateSpawnerTables( Spawner )
				self:setSpawnerData( Spawner )
			else
				print( self.Title .. ": setupSpawnPoints, Spawner: " .. tostring( Spawner ) .. ", with posKey: " .. posKey .. ", Is not in the settings. Destroying..." )
				self:disableSpawner( Spawner )
				self:clearSpawner( Spawner )
				self:removeSpawner( Spawner )
			end
		end
		for posKey, SpawnPoint in pairs( self.Settings.SpawnPoints ) do
			if not self.SpawnerByPosKey[ posKey ] then
				local _gameobj = new( UnityEngine.GameObject._type )
				local _transform = _gameobj:GetComponent( "Transform" )
				local position = new( UnityEngine.Vector3 )
				if tonumber( SpawnPoint.position.x ) then position.x = SpawnPoint.position.x else break end
				if tonumber( SpawnPoint.position.y ) then position.y = SpawnPoint.position.y else break end
				if tonumber( SpawnPoint.position.z ) then position.z = SpawnPoint.position.z else break end
				_transform.position = position
				local Spawner = _gameobj:AddComponent("GenericSpawner")
				Spawner.initialSpawn = false
				self:setSpawnerData( Spawner )
				self:updateSpawnerTables( Spawner )
			end
		end
	else
	end
end

function PLUGIN:disableSpawner( Spawner )
	if Spawner and Spawner:IsInvoking() then
		Spawner:CancelInvoke()
	end
end

function PLUGIN:clearSpawner( Spawner )
	if Spawner and Spawner._spawnList ~= '_spawnList' then
		local removeList = {}
		local spawnEnum = Spawner._spawnList:GetEnumerator()
		while spawnEnum:MoveNext() do
			local Spawn = spawnEnum.Current
			self:removeSpawn( Spawn )
			if Spawn.spawned.count == 0 then
				Spawn.spawned:Clear()
				table.insert( removeList, Spawn )
			end
		end
		if removeList and #removeList > 0 then
			for key, Spawn in pairs( removeList ) do
				Spawner._spawnList:Remove( Spawn )
			end
		end
	end
end

function PLUGIN:removeSpawn( Spawn )
	local WildLifeAI = { [ ':rabbit_prefab_a' ] = true, [ ':chicken_prefab' ] = true, [ ':boar_prefab' ] = true, [ ':stag_prefab' ] = true,  
								[ ':wolf_prefab' ] = true, [ ':mutant_wolf' ] = true, [ ':bear_prefab' ] = true, [ ':mutant_bear' ] = true }
	Spawn.targetPopulation = 0
	Spawn.numToSpawnPerTick = 0
	if WildLifeAI[ Spawn.prefabName ] then
		self:removeAISpawn( Spawn )
	else
		self:removeResourceSpawn( Spawn )
	end
end

function PLUGIN:removeAISpawn( Spawn )
	local spawnedEnum = Spawn.spawned:GetEnumerator()
	local i = 10
	while spawnedEnum:MoveNext() do
		local spawned = spawnedEnum.Current
		local WildLifeAI = spawned:GetComponent( "BasicWildLifeAI" )
		local Character = WildLifeAI.gameObject:GetComponent( "Character" )
		local idMain = Character.idMain
		if WildLifeAI.dropOnDeathString ~= 'dropOnDeathString' then 
			WildLifeAI.dropOnDeathString = nil
		end
		Rust.TakeDamage.KillSelf( idMain, nil )
		WildLifeAI:Invoke( "ResourcesDepletedMsg", 0 )
	end
end

function PLUGIN:removeResourceSpawn( Spawn )
	local spawnedEnum = Spawn.spawned:GetEnumerator()
	while spawnedEnum:MoveNext() do
		local spawned = spawnedEnum.Current
		--NetCullDestroy( spawned )
		local ResourceObject = spawned:GetComponent( "ResourceObject" )
		ResourceObject:Invoke( "ResourcesDepletedMsg", 0 )
	end
end

function PLUGIN:deleteSpawnerByName( SpawnPointName )
	local Spawner = false
	local posKey = false
	if self.SpawnerByName[ SpawnPointName ] then
		Spawner = self.SpawnerByName[ SpawnPointName ]
		posKey = self:getPositionKey( Spawner.transform.position )
	end
	if Spawner and posKey then
		self:removeSpawner( Spawner )
		if self.Settings.SpawnPoints[ posKey ] then
			self.Settings.SpawnPoints[ posKey ] = nil
		end
	end
end

function PLUGIN:removeSpawner( Spawner )
	if Spawner and Spawner.gameObject ~= 'gameObject' then
		local posKey = self:getPositionKey( Spawner.transform.position )
		if self.SpawnerByPosKey[ posKey ] then
			self.SpawnerByPosKey[ posKey ] = nil
		end
		if self.Settings.SpawnPoints[ posKey ] and self.Settings.SpawnPoints[ posKey ].name then
			local SpawnPointName = self.Settings.SpawnPoints[ posKey ].name
			if self.SpawnerByName[ SpawnPointName ] then
				self.SpawnerByName[ SpawnPointName ] = nil
			end
		end
		ObjectsDestroy( Spawner.gameObject )
	end
end

function PLUGIN:setSpawnerData( Spawner )
	local posKey = self:getPositionKey( Spawner.transform.position )
	if self.Settings.SpawnPoints[ posKey ] then
		local SpawnPoint = self.Settings.SpawnPoints[ posKey ]
		local changes = false
		if Spawner.radius ~= SpawnPoint.radius then
			Spawner.radius = SpawnPoint.radius
			changes = true
		end
		if Spawner.thinkDelay ~= SpawnPoint.respawnInterval then
			Spawner.thinkDelay = SpawnPoint.respawnInterval
			changes = true
		end
		if Spawner.name ~= SpawnPoint.name then
			Spawner.name = SpawnPoint.name
		end
		local existingPrefabs = {}
		if not Spawner._spawnList or Spawner._spawnList == '_spawnList' then
			Spawner._spawnList = self:newSpawnList()
		end
		local removeList = {}
		local spawnEnum = Spawner._spawnList:GetEnumerator()
		while spawnEnum:MoveNext() do
			local Spawn = spawnEnum.Current
			local prefabName = Spawn.prefabName
			existingPrefabs[ prefabName ] = true
			if SpawnPoint._spawnList[ prefabName ] then
				if Spawn.targetPopulation ~= SpawnPoint._spawnList[ prefabName ].targetPopulation then
					Spawn.targetPopulation = SpawnPoint._spawnList[ prefabName ].targetPopulation
					changes = true
				end
				if Spawn.numToSpawnPerTick ~= SpawnPoint._spawnList[ prefabName ].spawnsPerInterval then
					Spawn.numToSpawnPerTick = SpawnPoint._spawnList[ prefabName ].spawnsPerInterval
					changes = true
				end
			else
				self:removeSpawn( Spawn )
				if Spawn.spawned.count == 0 then
					Spawn.spawned:Clear()
					table.insert( removeList, Spawn )
				end
			end
		end
		if removeList and #removeList > 0 then
			for key, Spawn in pairs( removeList ) do
				Spawner._spawnList:Remove( Spawn )
			end
		end
		for prefabName, SpawnTable in pairs( SpawnPoint._spawnList ) do
			if not existingPrefabs[ prefabName ] then
				local instance = new(  GenericSpawnInstance  )
				if staticPrefabs[ prefabName ] then
					instance.forceStaticInstantiate = true
				else
					instance.forceStaticInstantiate = false
				end
				instance.useNavmeshSample = true
				instance.spawned =  self:newSpawnedList()
				if ValidPrefabs[ prefabName ] then instance.prefabName = prefabName else break end
				if tonumber( SpawnTable.spawnsPerInterval ) then instance.numToSpawnPerTick = SpawnTable.spawnsPerInterval else break end
				if tonumber( SpawnTable.targetPopulation ) then instance.targetPopulation = SpawnTable.targetPopulation else break end
				Spawner._spawnList:Add( instance )
				existingPrefabs[ prefabName ] = true
				changes = true
			end
		end
		if changes then
			self:disableSpawner( Spawner )
			spawnerOffset = spawnerOffset + 2
			Spawner:InvokeRepeating("SpawnThink", Spawner.thinkDelay + spawnerOffset, Spawner.thinkDelay)
			Spawner:SpawnThink()
		end
	else
		print( self.Title .. ": setSpawnerData, no Spawner configuraton for spawner position: " .. posKey )
	end
end

function PLUGIN:getSpawners()
	local GenericSpawners = objects.FindOfType( Rust.GenericSpawner._type )
	local Spawners = {}
	for i = 0, tonumber( GenericSpawners.Length - 1 ) do
		local Spawner = GenericSpawners[ i ]
		local SpawnPoint = self:getSpawnerData( Spawner )
		local posKey = SpawnPoint.posKey
		SpawnPoint.posKey = nil
		Spawners[ posKey ] = SpawnPoint
		if self.Settings.Debug and i < 2 then
			self:dumpData( tostring('Spawner [ ' .. i .. ' ]' ) , Spawner )
			self:dumpData( tostring('Spawner._spawnList [ ' .. i .. ' ]' ) , Spawner._spawnList )
		end
		if not self.SpawnerByPosKey[ posKey ] then
			self.SpawnerByPosKey[ posKey ] = Spawner
		end
		if self.SpawnerByName[ SpawnPoint.name ] then
			self.SpawnerByName[ SpawnPoint.name ] = Spawner
		end
	end
	return Spawners
end

function PLUGIN:getPositionKey( position )
	if position.x and position.y and position.z then
		local key = tostring( position.x .. "," .. position.y .. "," .. position.z )
		return key
	end
	return false
end

function PLUGIN:getSpawnerData( Spawner )
	local SpawnPoint = {}
	SpawnPoint.posKey = self:getPositionKey( Spawner.transform.position )
	SpawnPoint.position = { [ 'x' ] = Spawner.transform.position.x, [ 'y' ] = Spawner.transform.position.y, [ 'z' ] = Spawner.transform.position.z }
	SpawnPoint.name = Spawner.name
	SpawnPoint.radius = Spawner.radius
	SpawnPoint.respawnInterval = Spawner.thinkDelay
	SpawnPoint._spawnList = self:getSpawnListData( Spawner._spawnList )
	return SpawnPoint
end

function PLUGIN:getSpawnListData( spawnList )
	local SpawnTable = {}
	local spawnEnum = spawnList:GetEnumerator()
	while spawnEnum:MoveNext() do
		local Spawn = spawnEnum.Current
		local prefabName = Spawn.prefabName
		SpawnTable[ prefabName ] = {}
		SpawnTable[ prefabName ].spawnsPerInterval = Spawn.numToSpawnPerTick
		SpawnTable[ prefabName ].targetPopulation = Spawn.targetPopulation
	end
	return SpawnTable
end

function PLUGIN:cmdSetRadius( netuser, cmd, args )
	if args[ 1 ] and tostring( args[ 1 ] ) then
		local name = args[ 1 ]
		if args[ 2 ] and tonumber( args[ 2 ] ) then
			local radius = tonumber( args[ 2 ] )
		end
	end
end

function PLUGIN:Unload()
end

function PLUGIN:cmdResDeclare( netuser, cmd, args )
	if not self:CanUserAdmin ( netuser ) then return false end
	if args[ 1 ] and tostring( args[ 1 ] ) then
		local name = args[ 1 ]
		local radius = tonumber( args[ 2 ] ) or 30
		if not self.SpawnerByName[ name ] then
			local SpawnPoint = {}
			SpawnPoint.position = {}
			local lastKnownPosition = netuser.playerClient.lastKnownPosition
			SpawnPoint.position.x = math.ceil( lastKnownPosition.x )
			SpawnPoint.position.y = math.ceil( lastKnownPosition.y )
			SpawnPoint.position.z = math.ceil( lastKnownPosition.z )
			--SpawnPoint.position = { [ 'x' ] = lastKnownPosition.x, [ 'y' ] = lastKnownPosition.y, [ 'z' ] = lastKnownPosition.z }
			local posKey = self:getPositionKey( SpawnPoint.position )
			SpawnPoint.name = name
			SpawnPoint.radius = radius
			SpawnPoint.respawnInterval = 600
			SpawnPoint._spawnList = {}
			self.Settings.SpawnPoints[ posKey ] = SpawnPoint
			self:saveSettings()
			local msg = tostring( "Created Spawn location named: " .. name .. ", at location: " .. posKey )
			self:msgPrint( netuser, msg, 'chat' )
		else
			local msg = tostring( "Spawn location named: " .. name .. " Already exists." )
			self:msgPrint( netuser, msg, 'chat' )
		end
	end
end

function PLUGIN:cmdShowRes( netuser, cmd, args )
	if not self:CanUserAdmin ( netuser ) then return false end
	local object = self:GetRayedObject( netuser )
	if object and object.collider and object.collider.gameObject then
		local resourceTarget = object.collider.gameObject:GetComponent( "ResourceTarget" )
		print( tostring( resourceTarget ) )
		self:showRes( resourceTarget )
	end
end

function PLUGIN:showRes( resourceTarget )
	if resourceTarget then
		print( "gatherEfficiency = " .. tostring( resourceTarget.gatherEfficiencyMultiplier ) )
		local resourcesAvailable = resourceTarget.resourcesAvailable
		if resourcesAvailable then
			print( "resourcesAvailable = " .. tonumber( resourcesAvailable.Count ) )
			local resourceEnum = resourcesAvailable:GetEnumerator()
			while ( resourceEnum:MoveNext() ) do
				local resourceGivePair = resourceEnum.Current
				if resourceGivePair then
					print( "ResourceItemName = " .. tostring( resourceGivePair.ResourceItemName ) )
					print( "amountMin = " .. tostring( resourceGivePair.amountMin ) )
					print( "amountMax = " .. tostring( resourceGivePair.amountMax ) )
					print( "AmountLeft = " .. tostring( resourceGivePair:AmountLeft() ) )
				end
			end
		end
	end
end

function PLUGIN:modObject( resourceTarget, force )
	if self.Settings.Debug then 
		print( "resourceTarget = " .. tostring( resourceTarget ) )
	end
	local timeStart = dateTime()
	local objName = tostring( resourceTarget.Name )
	if not self.Stats.Type[ objName ] then self.Stats.Type[ objName ] = 0 end
	self.Stats.Type[ objName ] = self.Stats.Type[ objName ] + 1
	
	local resourceTakeDamage = resourceTarget:GetComponent( "TakeDamage" )
	if resourceTakeDamage and resourceTakeDamage.health and resourceTakeDamage.maxHealth then
		if resourceTakeDamage.health > 0 and self.Settings.resourceNodes[ objName ].health then
			if resourceTakeDamage.health ~= self.Settings.resourceNodes[ objName ].health then
				resourceTakeDamage.health = self.Settings.resourceNodes[ objName ].health
				resourceTakeDamage.maxHealth = self.Settings.resourceNodes[ objName ].health
				if self.Settings.Debug then 
					print( "resourceTakeDamage.health = " .. tostring( resourceTakeDamage.health ) )
					print( "resourceTakeDamage.maxHealth = " .. tostring( resourceTakeDamage.maxHealth ) )
				end
			end
		end
	end
	
	local WildLifeAI = resourceTarget:GetComponent( "HostileWildlifeAI" )
	if WildLifeAI then
		if WildLifeAI.dropOnDeathString ~= 'dropOnDeathString' then
			if self.Settings.resourceNodes[ objName ].dropLootBag and WildLifeAI.dropOnDeathString ~= ';drop_lootsack_zombie' then
				WildLifeAI.dropOnDeathString = ';drop_lootsack_zombie'
			elseif not self.Settings.resourceNodes[ objName ].dropLootBag then
				WildLifeAI.dropOnDeathString = nil
			end
		end
		if WildLifeAI.attackRate and self.Settings.resourceNodes[ objName ].attackRate then
			if WildLifeAI.attackRate ~= self.Settings.resourceNodes[ objName ].attackRate then
				WildLifeAI.attackRate = self.Settings.resourceNodes[ objName ].attackRate
			end
		end
		if WildLifeAI.attackDamageMin and self.Settings.resourceNodes[ objName ].attackMin then
			if WildLifeAI.attackDamageMin ~= self.Settings.resourceNodes[ objName ].attackMin then
				WildLifeAI.attackDamageMin = self.Settings.resourceNodes[ objName ].attackMin
			end
		end
		if WildLifeAI.attackDamageMax and self.Settings.resourceNodes[ objName ].attackMax then
			if WildLifeAI.attackDamageMax ~= self.Settings.resourceNodes[ objName ].attackMax then
				WildLifeAI.attackDamageMax = self.Settings.resourceNodes[ objName ].attackMax
			end
		end
		if self.Settings.Debug then 
			print( "WildLifeAI = " .. tostring( WildLifeAI ) )
			print( "WildLifeAI.dropOnDeathString = " .. tostring( WildLifeAI.dropOnDeathString ) )
			print( "WildLifeAI.attackRate = " .. tostring( WildLifeAI.attackRate ) )
			print( "WildLifeAI.attackDamageMin = " .. tostring( WildLifeAI.attackDamageMin ) )
			print( "WildLifeAI.attackDamageMax = " .. tostring( WildLifeAI.attackDamageMax ) )
		end
	end
	if self.Settings.resourceNodes[ objName ].gatherEfficiency and self.Settings.resourceNodes[ objName ].gatherEfficiency > 0 then
		if force or resourceTarget.gatherEfficiencyMultiplier ~= self.Settings.resourceNodes[ objName ].gatherEfficiency then
			resourceTarget.gatherEfficiencyMultiplier = self.Settings.resourceNodes[ objName ].gatherEfficiency
			if self.Settings.Debug then 
				print( tostring( objName ), tostring( resourceTarget.gatherEfficiencyMultiplier ) )
			end
			local resourcedAdded = {}
			local resourcesAvailable = resourceTarget.resourcesAvailable
			if resourcesAvailable then
				local resourceEnum = resourcesAvailable:GetEnumerator()
				while ( resourceEnum:MoveNext() ) do
					local resourceGivePair = resourceEnum.Current
					if resourceGivePair then
						local ResourceItemName = resourceGivePair.ResourceItemName
						if self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ] then
							local _newMin = self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ].Min
							local _newMax = self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ].Max
							resourceGivePair.amountMin = _newMin
							resourceGivePair.amountMax = _newMax
							resourceGivePair:CalcAmount()
							resourcedAdded[ ResourceItemName ] = true
							if self.Settings.Debug then 
								print( ".                          ." .. tostring( resourceGivePair.ResourceItemName ), tostring( resourceGivePair.amountMin ), tostring( resourceGivePair.amountMax ), tostring( resourceGivePair:AmountLeft() ) )
							end
						end
					end
				end
			end
			for ResourceItemName, value in pairs( self.Settings.resourceNodes[ objName ][ 'resources' ] ) do
				if not resourcedAdded[ ResourceItemName ] then
					local resourceGivePair = new( Rust.ResourceGivePair )
					resourceGivePair.amountMin = value.Min
					resourceGivePair.amountMax = value.Max
					resourceGivePair.ResourceItemName = ResourceItemName
					resourceTarget.resourcesAvailable:Add( resourceGivePair )
				end
			end
			resourceTarget:Awake()
			if self.Settings.Debug then 
				local timeEnd = dateTime()
				self.Stats.Duration = timeEnd:Subtract( timeStart ).Ticks / 10000
				print( "Duration = " .. tostring( self.Stats.Duration ) .. "\n" )
			end
		end
	end
end

function PLUGIN:getDefaultValues( resourceTarget )
	local objName = tostring( resourceTarget.Name )
	if self.Defaults[ objName ] then return false end
	local isDefault = true
	self.Defaults[ objName ] = {}
	self.Defaults[ objName ][ 'gatherEfficiency' ] = resourceTarget.gatherEfficiencyMultiplier
	self.Defaults[ objName ][ 'resources' ] = {}
	local resourceEnum = resourceTarget.resourcesAvailable:GetEnumerator()
	while ( resourceEnum:MoveNext() ) do
		local resourceGivePair = resourceEnum.Current
		local ResourceItemName = resourceGivePair.ResourceItemName
		self.Defaults[ objName ][ 'resources' ][ ResourceItemName ] = {}
		self.Defaults[ objName ][ 'resources' ][ ResourceItemName ][ 'Min' ] = resourceGivePair.amountMin
		self.Defaults[ objName ][ 'resources' ][ ResourceItemName ][ 'Max' ] = resourceGivePair.amountMax
		if isDefault then
			if not self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ] or
					( self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ].Max and ( self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ].Max ~= resourceGivePair.amountMax ) ) or
					( self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ].Min and ( self.Settings.resourceNodes[ objName ][ 'resources' ][ ResourceItemName ].Min ~= resourceGivePair.amountMin ) ) then
				isDefault = false
			end
		end
	end
	if self.Defaults[ objName ].gatherEfficiency and self.Settings.resourceNodes[ objName ].gatherEfficiency then
		if self.Defaults[ objName ].gatherEfficiency == self.Settings.resourceNodes[ objName ].gatherEfficiency then
			if isDefault then
				print( self.Title .. ": getDefaultValues, Resource Node '" .. objName .. "' setting for 'gatherEfficiency' is unchanged, Resource will not be modified." )
			else
				self.Settings.resourceNodes[ objName ].gatherEfficiency = self.Settings.resourceNodes[ objName ].gatherEfficiency + 1
				print( self.Title .. ": getDefaultValues, Resource Node '" .. objName .. "' has custom values, changing 'gatherEfficiency' to '" .. self.Settings.resourceNodes[ objName ].gatherEfficiency .. "." )
			end
		end
	end
end

function PLUGIN:OnResourceNodeLoaded( resourceTarget )
	self:resourceNodeLoaded( resourceTarget )
end

function PLUGIN:resourceNodeLoaded( resourceTarget, force )
	if not self.Defaults[ resourceTarget.Name ] then
		self:getDefaultValues( resourceTarget )
	end
	self:modObject( resourceTarget, force )
end

function PLUGIN:dumpData( key, value, oldvalue )
		local _type = type( value )
		if _type == 'table' then
			print( "[ " .. tostring( key ) .. " ] : ( " .. type( value ) .. " ), has " .. tostring( #value ) .. " entries" )
			for key2, value2 in pairs( value ) do
				self:dumpData( key2, value2 )
			end
		elseif _type == 'userdata' then
			print( "[ " .. tostring( key ) .. " ] : ( " .. type( value ) .. " ) = " .. tostring( value ) )
			if not oldvalue then
				local _GetType = value:GetType()
				if _GetType then
					print( "[ " .. tostring( key ) .. " ] : ( " .. type( value ) .. " ) : ( " .. _GetType.Name .. " ) = " .. tostring( value ) )
					local getType_metatable = getmetatable( _GetType )
					print( "[ " .. tostring( _GetType.Name ) .. " ] : ( " .. type( getType_metatable ) .. " ) = " .. tostring( getType_metatable ) )
					for key3, value3 in pairs( getType_metatable ) do
						if type( value3 ) == 'table' then
					--		self:dumpData( tostring( key .. "." .. key3 ), value3, value )
							print( "[ " .. tostring( key3 ) .. " ] : ( " .. type( value3 ) .. " ) = " .. tostring( value3 ) )
						else
							print( "[ " .. tostring( key3 ) .. " ] : ( " .. type( value3 ) .. " ) = " .. tostring( value3 ) )
						end
					end
				--	self:dumpData( tostring( _GetType.Name ), getType_metatable, value )
				end
			end
		else
			print( "[ " .. tostring( key ) .. " ] : ( " .. type( value ) .. " ) = " .. tostring( value ) )
		end
end

function ObjectsDestroy( object )
	local arr = util.ArrayFromTable( cs.gettype( "System.Object" ), { object } )  ;
	cs.convertandsetonarray( arr, 0, object , UnityEngine.GameObject._type )
	objects.Destroy:Invoke( nil, arr )
end

local Raycast = util.FindOverloadedMethod( UnityEngine.Physics, "RaycastAll", bf.public_static, { UnityEngine.Ray } )
cs.registerstaticmethod( "tmp", Raycast )
local RaycastAll = tmp
tmp = nil
function PLUGIN:GetRayedObject( netuser )
	local ray = netuser.playerClient.controllable.character.eyesRay
    local hits = RaycastAll( ray )
    local tbl = cs.createtablefromarray( hits )
    if (#tbl == 0) then return end
    local closest = tbl[1]
    local closestdist = closest.distance
    for i=2, #tbl do
        if (tbl[i].collider.gameObject.name ~= 'Terrain') and (tbl[i].collider.gameObject.name ~= '__MESHBATCH_PHYSICAL_OUTPUT') and (tbl[i].collider.gameObject.name ~= '') then
            closest = tbl[i]
            closestdist = closest.distance
        end
    end
    return closest
end