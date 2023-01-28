-- Written by Reneb

PLUGIN.Title = "R-Remover"
PLUGIN.Description = "Destroy your buildings, get refund, and administrate your server"
PLUGIN.Author = "Reneb"
PLUGIN.Version = "3.2.2"

function PLUGIN:Init()
	self:LoadCFG()
	self:LoadCmd()
	self:LoadAdminStuff()
	self:LoadVars()
	self:LoadItemTable()
	self:LoadShareRemove()
end


local removed = {}
local AllStructures = util.GetStaticPropertyGetter( Rust.StructureMaster, "AllStructures") 
local NetCullRemove = util.FindOverloadedMethod(Rust.NetCull._type, "Destroy", bf.public_static, {UnityEngine.GameObject})
local FindByClass = util.GetStaticMethod( UnityEngine.Resources._type, "FindObjectsOfTypeAll")
local GetDeployableObjectownerID = util.GetFieldGetter( Rust.DeployableObject, "ownerID", true )
local LifeStatusType = cs.gettype( "LifeStatus, Assembly-CSharp" )
typesystem.LoadEnum(LifeStatusType, "LifeStatus" )
local getStructureMasterOwnerId = util.GetFieldGetter(Rust.StructureMaster, "ownerID", true)
local GetComponents, SetComponents = typesystem.GetField( Rust.StructureMaster, "_structureComponents", bf.private_instance )
local getdecay, setdecay = typesystem.GetField( Rust.StructureMaster, "_decayDelayRemaining", bf.private_instance )
local SphereOverlap = util.FindOverloadedMethod( UnityEngine.Physics, "OverlapSphere", bf.public_static, { UnityEngine.Vector3, System.Single } )
local _Euler = util.GetStaticMethod( UnityEngine.Quaternion._type, "Euler" )
local vector3rotation = new(UnityEngine.Vector3)
vector3rotation.x = 0
vector3rotation.y = 0
vector3rotation.z = 0
local vQuaternion = new(UnityEngine.Quaternion)
local createABC = util.FindOverloadedMethod( Rust.NetCull._type, "InstantiateStatic", bf.public_static, { System.String, UnityEngine.Vector3, UnityEngine.Quaternion } )

function string:split(inSplitPattern, outResults)
   if not outResults then
      outResults = {}
   end
   local theStart = 1
   local theSplitStart, theSplitEnd = string.find(self, inSplitPattern, theStart)
     while theSplitStart do
      table.insert(outResults, string.sub(self, theStart, theSplitStart-1))
      theStart = theSplitEnd + 1
      theSplitStart, theSplitEnd = string.find(self, inSplitPattern, theStart)
   end
   table.insert(outResults, string.sub(self, theStart))
   return outResults
end
local function tosteamid(cid)
  local steam64=tonumber(cid:sub(2))
  local a = steam64 % 2 == 0 and 0 or 1
  local b = math.abs(6561197960265728 - steam64 - a) / 2
  local sid = "STEAM_0:" .. a .. ":" .. (a == 1 and b -1 or b)
  return sid
end
local function GetConnectedComponents( master )
    local hashset = GetComponents( master )
    local tbl = {}
    local it = hashset:GetEnumerator()
    while (it:MoveNext()) do
        tbl[ #tbl + 1 ] = it.Current
    end
    return tbl
end

function RemoveObject(object)
	if removed[object] then return end
	removed[object] = true
	if object.name == "name" then return end
	if object == "GameObject" then return end
	
    local objs = util.ArrayFromTable(cs.gettype("System.Object"), {object})
    cs.convertandsetonarray( objs, 0, object , UnityEngine.GameObject._type )
    NetCullRemove:Invoke(nil, objs) 
end

function placeStructure( netuser, themaster, objectpos, prefabname , objectrot )
	local arr = util.ArrayFromTable( cs.gettype( "System.Object" ), { prefabname, objectpos, objectrot } )
	cs.convertandsetonarray( arr, 0, prefabname, System.String._type )
	
	local xgameObject = createABC:Invoke( nil, arr )
	themaster:SetupCreator(netuser.playerclient.controllable)
	themaster:AddStructureComponent(xgameObject:GetComponent("StructureComponent"))
end
function placeObject( netuser, objectpos, prefabname , objectrot )
	local arr = util.ArrayFromTable( cs.gettype( "System.Object" ), { prefabname, objectpos, objectrot } )
	cs.convertandsetonarray( arr, 0, prefabname, System.String._type )
	
	local xgameObject = createABC:Invoke( nil, arr )
	local ngameObject = xgameObject:GetComponent("DeployableObject")
	timer.Once(2, function() 
		ngameObject:SetupCreator(netuser.playerclient.controllable)
		ngameObject:GrabCarrier() 
	end )
end
local function removeallstructure( master )
	local hashset = GetComponents( master )
	local tbl = {}
    local it = hashset:GetEnumerator()
    while (it:MoveNext()) do
		table.insert(tbl,it.Current.GameObject)
    end
	for k,v in pairs(tbl) do
		RemoveObject(v)
	end
end
local function removeallsteamid(steamid)
	local tab = {}
	for i=0, AllStructures().Count-1 do
		if( rust.CommunityIDToSteamID( getStructureMasterOwnerId( AllStructures()[i] )) == steamid ) then
			removeallstructure( AllStructures()[i] )
		end
	end	
	local deployableobjects = FindByClass(Rust.DeployableObject._type)
	for i = 0, tonumber(deployableobjects.Length-1) do
		if( rust.CommunityIDToSteamID(GetDeployableObjectownerID( deployableobjects[i] )) == steamid ) then
			RemoveObject(deployableobjects[i].GameObject)
		end
	end
end
function PLUGIN:cmdProd(netuser, cmd, args)
	local isAdmin = self:isAdmin(netuser)
	if(self.Config.prod.onlyadminprod and not isAdmin) then
		rust.Notice(netuser, "You are not allowed to use this command")
		return
	end
	if(self.Prod[netuser]) then
		rust.Notice(netuser, "Prod deactivated")
		rust.SendChatToUser(netuser, self.Config.ChatName, "Prod deactivated")
		self.Prod[netuser] = nil
	else
		rust.Notice(netuser, "Prod activated")
		rust.SendChatToUser(netuser, self.Config.ChatName, "Prod activated")
		self.Prod[netuser] = true
	end
end
function PLUGIN:cmdUndo(netuser, cmd, args)
	if(not self.Config.undo.allowcmd) then
		rust.Notice(netuser, "This command has been deactivated")
		return
	end
	local isAdmin = self:isAdmin(netuser)
	if(not isAdmin) then
		rust.Notice(netuser, "You are not allowed to use this command")
		return
	end
	local targetuser = false
	if(args[1] and isAdmin) then
		targetuser = self:FindPlayer(netuser,args[1])
		if(targetuser) then
			rust.SendChatToUser(netuser, self.Config.ChatName, "You have forced the undo on: " .. targetuser.displayName )
		else
			rust.SendChatToUser(netuser, self.Config.ChatName, "Couldn't find target user" )
			return
		end
	else
		targetuser = netuser
	end
	if(not self.Undo[targetuser]) then
		rust.SendChatToUser(netuser, self.Config.ChatName, "Can not undo, last remove action was too long ago")
		return
	end
	
	
	
	
	local inv = rust.GetInventory(targetuser)
	local masteridtomaster = {}
	for i=0,AllStructures().Count-1 do
		local structureMasterID = tostring(AllStructures()[i]:GetMasterID())
		if(structureMasterID) then
			masteridtomaster[structureMasterID] = AllStructures()[i]
		end
	end
	
	for i,obj in pairs(self.Undo[targetuser]) do
		if(not obj.master) then
			if(self.PrefabTable[obj.name] and self.ItemTable[obj.name]) then
				local invitem = inv:FindItem( rust.GetDatablockByName( self.ItemTable[obj.name] ) )
				if(invitem and invitem ~= nil) then
					if(invitem.uses == 1) then
						inv:RemoveItem(invitem)
					else
						invitem:SetUses( invitem.uses - 1 )
					end
					placeObject( targetuser, obj.pos, self.PrefabTable[obj.name] , obj.rot )
					if(self.Config.undo.log) then
						print(targetuser.displayName .. " used undo for " .. self.PrefabTable[obj.name] .. " @ ", obj.pos)
					end
				else
					rust.SendChatToUser(targetuser, self.Config.ChatName, self.ItemTable[obj.name] .. " was not placed as you don't have it in your inventory anymore")
				end
			end
		elseif(masteridtomaster[obj.master]) then
			if(self.PrefabTable[obj.name] and self.ItemTable[obj.name]) then
				local invitem = inv:FindItem( rust.GetDatablockByName( self.ItemTable[obj.name] ) )
				if(invitem and invitem ~= nil) then
					if(invitem.uses == 1) then
						inv:RemoveItem(invitem)
					else
						invitem:SetUses( invitem.uses - 1 )
					end
					placeStructure( targetuser, masteridtomaster[obj.master], obj.pos, self.PrefabTable[obj.name] , obj.rot )
					if(self.Config.undo.log) then
						print(targetuser.displayName .. " used undo for " .. self.PrefabTable[obj.name] .. " @ ", obj.pos)
					end
				else
					rust.SendChatToUser(targetuser, self.Config.ChatName, self.ItemTable[obj.name] .. " was not placed as you don't have it in your inventory anymore")
				end
			end
		else
			rust.SendChatToUser(targetuser, self.Config.ChatName, "You may not undo when you removed all the structure, Sorry!")
			break
		end
	end
	self.Undo[targetuser] = nil
end
function PLUGIN:cmdRemove(netuser, cmd, args)
	local isAdmin = self:isAdmin(netuser)
	local kind = false
	if(args[1] and self:isAdmin(netuser)) then
		kind = args[1]
	end
	if(self.Remove[netuser]) then
		self:DeactivateRemove(netuser)
		return
	else
		if(not kind) then
			if(self.Config.remove.log) then
				print(netuser.displayName .. " ran the command: /" .. cmd)
			end
			if(self.Config.remove.onlyadminremove and not isAdmin) then
				rust.SendChatToUser(netuser, self.Config.ChatName, "Remove has been deactivated, only admins are allowed to use it")
				return
			end
			rust.SendChatToUser(netuser, self.Config.ChatName, "Remove will auto-disable in ".. self.Config.remove.autodeactivatetime .. " seconds")
			rust.Notice(netuser, "Remove on. You will now remove your buildings parts.")
			self:ActivateRemoveTimer(netuser,"normal")
		else
			if(self.Config.remove.log) then
				print(netuser.displayName .. " ran the command: /" .. cmd .. " " .. kind)
			end
			if(kind == "admin") then
				self:ActivateRemoveTimer(netuser,"admin")
				rust.SendChatToUser(netuser, self.Config.ChatName, "Remove admin on for " .. self.Config.remove.autodeactivatetime .. " seconds")
				rust.Notice(netuser, "Remove ADMIN on")
			elseif(kind == "all") then
				self:ActivateRemoveTimer(netuser,"all")
				rust.SendChatToUser(netuser, self.Config.ChatName, "Remove ALL on for " .. self.Config.remove.autodeactivatetime .. " seconds")
				rust.Notice(netuser, "Remove ALL on")
			elseif(kind == "steam") then
				if(not args[2]) then
					rust.SendChatToUser(netuser, self.Config.ChatName, "Wrong Arguments: /remove steam STEAMID64")
					return
				end
				local removesteam = args[2]
				self:DoRemoveSteam(removesteam)
			else
				local name = args[1]
				local targetuser = self:FindPlayer(netuser,name)
				if(targetuser) then
					rust.Notice(targetuser, "Remove on. You will now remove your buildings parts.")
					self:ActivateRemoveTimer(targetuser,"normal")
					rust.SendChatToUser(netuser, self.Config.ChatName, targetuser.displayName .. " may now remove his structures for " .. self.Config.remove.autodeactivatetime .. " seconds" )
				end
			end
		end
	end
end
function PLUGIN:DoRemoveSteam(removesteam)
	if(not string.find(removesteam,":")) then
		removesteam = tosteamid(removesteam)
	end
	removeallsteamid(removesteam)
end
function PLUGIN:OnHurt(takedamage, damage)
	if not (tostring(type(damage) ~= "userdata")) or not (tostring(type(takedamage) ~= "userdata")) then
		return
	end
	if(damage.attacker and damage.attacker.client and damage.attacker.client.netUser and damage.extraData and damage.extraData.dataBlock) then
		local attackerNetuser = damage.attacker.client.netUser
		if(self.Prod[attackerNetuser]) then
			if takedamage.gameObject and takedamage.gameObject.Name then
				self:DoProd(takedamage,damage,attackerNetuser)
			end
		end
		if(self.Remove[attackerNetuser] and self.Remove[attackerNetuser].kind) then
			if takedamage.gameObject and takedamage.gameObject.Name then
				
				self:DoRemove(takedamage,damage,attackerNetuser)
			end
		elseif(damage.amount > 0 and self.Config.remove.antiremoveduringraid) then
			local structureComponent = takedamage.GameObject:GetComponent("StructureComponent")
			if(structureComponent) then
				self:AddAntiRemove(structureComponent)
			end
		elseif(damage.amount == 0) then
			if(self.Config.UberHatchetCanDestroy and damage.extraData.dataBlock.name == "Uber Hatchet") then
				local structureComponent = takedamage.GameObject:GetComponent("StructureComponent")
				local deplayableComponent = takedamage.GameObject:GetComponent("DeployableObject")
				if(structureComponent) then
					damage.status = LifeStatus.WasKilled
					damage.amount = 10000
					return damage
				elseif(deplayableComponent) then
					plugins.Call( "DeployableRemove", takedamage.gameObject.Name, deplayableComponent:GetComponent("Transform").position )
					timer.Once(0.5, function() RemoveObject(takedamage.GameObject) end)
					damage.status = LifeStatus.IsAlive
					damage.amount = 0
					return damage
				end
			end
		end
	end
	return
end
function PLUGIN:DoProd(takedamage,damage,netuser)
	local structureComponent = takedamage.GameObject:GetComponent("StructureComponent")
	local deplayableComponent = takedamage.GameObject:GetComponent("DeployableObject")
	if(structureComponent and structureComponent._master) then
		local structureMaster = structureComponent._master
		local structureOwnerId = tostring(getStructureMasterOwnerId(structureMaster))
		self:GetProd(netuser,structureOwnerId,structureMaster)
	elseif(deplayableComponent) then
		local structureOwnerId = tostring(GetDeployableObjectownerID(deplayableComponent))
		self:GetProd(netuser,structureOwnerId,false)
	end
end

function PLUGIN:GetProd(netuser,ownerid,structureMaster)
	if(self.oxmin_plugin) then
		self.dataFile = util.GetDatafile("oxmin")
		local txt = self.dataFile:GetText()
		if (txt ~= "") then
			self.data = json.decode(txt)
		else
			self.data = {}
			self.data.Users = {}
		end
		local steamid = self:ToSteamID64( rust.CommunityIDToSteamID( tonumber(ownerid) ) )
		ownerDetails = self:GetUserDetailsByCommunityId(ownerid)
		if(ownerDetails and ownerDetails.Name) then
			rust.SendChatToUser(netuser, "This is owned by "..ownerDetails.Name .. " - " .. tostring(steamid) .."!")
		else
			if(self.Config.prod.SteamAPIKey and self.Config.prod.SteamAPIKey ~= "" ) then
				local url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" .. self.Config.prod.SteamAPIKey .. "&steamids=" .. steamid
				local request = webrequest.Send(url, function(code, response)
					 if (code == 200 and response ~= "") then
						local json = json.decode(response)
						if (json.response.players[1]) then
							if(json.response.players[1]['personaname']) then
								rust.SendChatToUser(netuser, "This is owned by ".. json.response.players[1]['personaname'] .." - " .. tostring(steamid) .."!")
							else
								rust.SendChatToUser(netuser, "Sorry, don't know who owns this (steamprofile doesn't exist) - " .. steamid)
							end
						end
					end
				end)
			else
				rust.SendChatToUser(netuser, self.Config.ChatName, "Couldn't find the structure owner, maybe you want to install the SteamAPIKey?" )
			end
		end
	elseif(self.Config.prod.SteamAPIKey and self.Config.prod.SteamAPIKey ~= "" ) then
		local steamid = self:ToSteamID64( rust.CommunityIDToSteamID( tonumber(ownerid) ) )
		local url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" .. self.Config.prod.SteamAPIKey .. "&steamids=" .. steamid
		local request = webrequest.Send(url, function(code, response)
			 if (code == 200 and response ~= "") then
				local json = json.decode(response)
				if (json.response.players[1]) then
					if(json.response.players[1]['personaname']) then
						rust.SendChatToUser(netuser, "This is owned by ".. json.response.players[1]['personaname'] .." - " .. tostring(steamid) .."!")
					else
						rust.SendChatToUser(netuser, "Sorry, don't know who owns this (steamprofile doesn't exist) - " .. steamid)
					end
				end
			end
		end)
	else
		rust.SendChatToUser(netuser, self.Config.ChatName, "Can't prod: You might consider using oxmin or the SteamAPIKey?" )
	end
	if(self.Config.prod.ShowLastUsed) then
		if(structureMaster) then
			local currentdecay = getdecay(structureMaster)
			local maxdecay = structureMaster:GetDecayDelay()
			if(not currentdecay or not maxdecay) then print("couldn't get the last time this building was used") return end
			if(maxdecay > currentdecay) then
				local lasttouched = self:SecsToTime(maxdecay - currentdecay)
				local decayingin = self:SecsToTime(currentdecay)
				if(currentdecay == 0) then
					rust.SendChatToUser( netuser, "This building was last used more than " .. lasttouched .. "ago and started decaying" )
				else
					rust.SendChatToUser( netuser, "This building was last used: " .. lasttouched .. "ago and is decaying in " .. decayingin )
				end
			end
		end
	end
end
function PLUGIN:GetUserDetailsByCommunityId(communityId)
	local details = self.data.Users[""..communityId]
	if(details) then
		return details
	end
	return nil
end
function PLUGIN:AddAntiRemove(structureComponent)
	if(structureComponent._master) then
		local structuremaster = structureComponent._master
		self.underattack[structuremaster] = util.GetTime()
	end
end

function PLUGIN:DoRemove(takedamage,damage,netuser)
	local structureComponent = takedamage.GameObject:GetComponent("StructureComponent")
	local deplayableComponent = takedamage.GameObject:GetComponent("DeployableObject")
	if(structureComponent and structureComponent._master) then
		local structureMaster = structureComponent._master
		local structureOwnerId = tostring(getStructureMasterOwnerId(structureMaster))
		local structureMasterID = tostring(structureMaster:GetMasterID())
		local userid = tostring(rust.GetUserID( netuser ))
		if(self:CanRemove(self.Remove[netuser].kind, userid, structureOwnerId)) then
			local allowremove, err = self:CheckIfAllowedToRemoveStructure(structureComponent,takedamage,damage,netuser)
			if(not allowremove) then
				if(err) then
					rust.SendChatToUser(netuser, self.Config.ChatName, "ERROR: " .. err )
				end
				return
			end
			local refund = {}
			if(self.Remove[netuser].kind == "normal" or self.Remove[netuser].kind == "admin") then
				if(self.Config.remove.refund) then
					local rawname = takedamage.gameObject.Name
					if(rawname) then
						local realname = self.ItemTable[takedamage.gameObject.Name]
						if(realname) then
							if(not refund[realname]) then refund[realname] = 0 end
							refund[realname] = refund[realname] + 1
							if(realname == "Wood Doorway" or realname == "Metal Doorway") then
								local radius = 0.04
								local arr = util.ArrayFromTable( System.Object, { structureComponent:GetComponent("Transform").position, radius } , 2 )
								cs.convertandsetonarray( arr, 1, radius, System.Single._type )
								local colliders = SphereOverlap:Invoke(nil, arr)
								local tbl = cs.createtablefromarray( colliders )
								for k,v in pairs(tbl) do
									if(tostring(v.GameObject.Name) == "MetalDoor(Clone)") then
										if(not refund["Metal Door"]) then refund["Metal Door"] = 0 end
										refund["Metal Door"] = refund["Metal Door"] + 1
										if(self.Config.undo.allowcmd) then
											if(not self.Undo[netuser]) then self.Undo[netuser] = {} end
											table.insert(self.Undo[netuser],{
												name=v.GameObject.Name,
												pos=v.GameObject.transform.position,
												rot=v.GameObject.transform.rotation,
											})
											if(self.undotimer[netuser]) then self.undotimer[netuser]:Destroy() end
											self.undotimer[netuser] = timer.Once( self.Config.undo.timesaved, function() self.Undo[netuser] = nil end )
										end
									end
								end
							elseif(realname == "Wood Window" or realname == "Metal Window") then
								local radius = 0.2
								local pos = structureComponent:GetComponent("Transform").position
								pos.y = pos.y + 0.482
								local arr = util.ArrayFromTable( System.Object, { pos, radius } , 2 )
								cs.convertandsetonarray( arr, 1, radius, System.Single._type )
								local colliders = SphereOverlap:Invoke(nil, arr)
								local tbl = cs.createtablefromarray( colliders )
								for k,v in pairs(tbl) do
									if(tostring(v.GameObject.Name) == "MetalBarsWindow(Clone)") then
										if(not refund["Metal Window Bars"]) then refund["Metal Window Bars"] = 0 end
										refund["Metal Window Bars"] = refund["Metal Window Bars"] + 1
										if(self.Config.undo.allowcmd) then
											if(not self.Undo[netuser]) then self.Undo[netuser] = {} end
											table.insert(self.Undo[netuser],{
												name=v.GameObject.Name,
												pos=v.GameObject.transform.position,
												rot=v.GameObject.transform.rotation,
											})
											if(self.undotimer[netuser]) then self.undotimer[netuser]:Destroy() end
											self.undotimer[netuser] = timer.Once( self.Config.undo.timesaved, function() self.Undo[netuser] = nil end )
										end
									end
								end
							end
						end
					end
				end
				if(self.Config.remove.log) then
					if(self.ItemTable[takedamage.gameObject.Name]) then
						print(netuser.displayName .. " removed a " .. self.ItemTable[takedamage.gameObject.Name] )
					end
				end
				local structureComponenttransform = structureComponent:GetComponent("Transform")
				damage.status = LifeStatus.WasKilled
				damage.amount = 10000
				plugins.Call( "StructureRemove", takedamage.gameObject.Name, structureComponenttransform.position, structureOwnerId, structureMasterID )
				if(self.Config.undo.allowcmd) then
					if(not self.Undo[netuser]) then self.Undo[netuser] = {} end
					table.insert(self.Undo[netuser],{
						name=takedamage.gameObject.Name,
						pos=structureComponenttransform.position,
						rot=structureComponenttransform.rotation,
						master=structureMasterID
					})
					if(self.undotimer[netuser]) then self.undotimer[netuser]:Destroy() end
					self.undotimer[netuser] = timer.Once( self.Config.undo.timesaved, function() self.Undo[netuser] = nil end )
				end
			elseif(self.Remove[netuser].kind == "all") then
				if(self.lastRemove[structureMaster]) then
					return
				end
				self.lastRemove[structureMaster] = true
				
				timer.Once( 2, function() self.lastRemove[structureMaster] = nil end )
				for k,v in pairs (GetConnectedComponents(structureMaster) ) do
					if(v.Name) then
						if(self.Config.remove.refund) then
							local realname = self.ItemTable[v.Name]
							if(realname) then
								if(not refund[realname]) then refund[realname] = 0 end
								refund[realname] = refund[realname] + 1
							end
						end
					end
					plugins.Call( "StructureRemove", v.Name, v:GetComponent("Transform").position, structureOwnerId, structureMasterID )
					timer.Once(0.5, function()  RemoveObject(v.GameObject) end)
				end
				if(self.Config.remove.log) then
					print(netuser.displayName .. " used remove all")
				end
			end
			if(self.Config.remove.refund) then
				for daname,theamount in pairs(refund) do
					local inv = rust.GetInventory( netuser )
					if(inv) then
						local dataname = rust.GetDatablockByName( daname )
						local pref = rust.InventorySlotPreference(InventorySlotKind.Default, false, InventorySlotKindFlags.Belt)
						if(dataname) then
							inv:AddItemAmount( dataname, theamount )
							rust.InventoryNotice( netuser, theamount .. "x " .. daname )
						end
					end
				end
			end
		end
	elseif(deplayableComponent) then
		local structureOwnerId = tostring(GetDeployableObjectownerID(deplayableComponent))
		local userid = tostring(rust.GetUserID( netuser ))
		if(self:CanRemove(self.Remove[netuser].kind, userid, structureOwnerId)) then
			local allowremove, err = self:CheckIfAllowedToRemoveDeployable(deplayableComponent,takedamage,damage,netuser)
			if(not allowremove) then
				if(err) then
					rust.SendChatToUser(netuser, self.Config.ChatName, "ERROR: " .. err )
				end
				return
			end			
			if(self.Config.remove.log) then
				if(self.ItemTable[takedamage.gameObject.Name]) then
					print(netuser.displayName .. " removed a " .. self.ItemTable[takedamage.gameObject.Name] )
				end
			end
			if(self.Config.remove.refund) then
				local inv = rust.GetInventory( netuser )
				if(inv) then
					local realname = self.ItemTable[takedamage.gameObject.Name]
					if(realname) then
						local dataname = rust.GetDatablockByName( realname )
						local pref = rust.InventorySlotPreference(InventorySlotKind.Default, false, InventorySlotKindFlags.Belt)
						if(dataname) then
							inv:AddItemAmount( dataname, 1 )
							rust.InventoryNotice( netuser, "1x " .. realname )
						end
					end
				end
			end
			self.lastRemove[takedamage.GameObject] = true
			local deplayableComponenttransform = deplayableComponent:GetComponent("Transform")
			if(self.Config.undo.allowcmd) then
				if(not self.Undo[netuser]) then self.Undo[netuser] = {} end
				table.insert(self.Undo[netuser],{
					name=takedamage.gameObject.Name,
					pos=deplayableComponenttransform.position,
					rot=deplayableComponenttransform.rotation,
				})
				if(self.undotimer[netuser]) then self.undotimer[netuser]:Destroy() end
				self.undotimer[netuser] = timer.Once( self.Config.undo.timesaved, function() self.Undo[netuser] = nil end )
			end
			timer.Once( 1, function() self.lastRemove[takedamage.GameObject] = nil end )
			plugins.Call( "DeployableRemove", takedamage.gameObject.Name, deplayableComponenttransform.position )
			timer.Once(0.05, function() RemoveObject(takedamage.GameObject) end )
		end
	end
end
function PLUGIN:CheckIfAllowedToRemoveDeployable(deplayableComponent,takedamage,damage,netuser)
	if removed[takedamage.GameObject] then return false end
	if(self.lastRemove[takedamage.GameObject]) then return false end
	if(damage.extraData and damage.extraData.dataBlock) then
		local weapon = damage.extraData.dataBlock.name
		if(weapon == "Shotgun") or (weapon == "Pipe Shotgun") or (weapon == "HandCannon") then
			return false, "You are not allowed to use this gun to remove"
		end
	end
	local kind = self.Remove[netuser].kind
	if(kind == "admin" or kind == "all") then
		return true
	else
		if(not takedamage.gameObject.Name) then
			return false, "This object has no name"
		else
			if(self.ItemTable[takedamage.gameObject.Name]) then
				if(not self.Config.removable[self.ItemTable[takedamage.gameObject.Name]]) then
					return false, "You are not allowed to remove this"
				end
			else
				return false, "This object is missing from the ItemTable"
			end
		end
	end
	return true
end
function PLUGIN:CheckIfAllowedToRemoveStructure(structureComponent,takedamage,damage,netuser)
	if removed[takedamage.GameObject] then return false end
	if(damage.extraData and damage.extraData.dataBlock) then
		local weapon = damage.extraData.dataBlock.name
		if(weapon == "Shotgun") or (weapon == "Pipe Shotgun") or (weapon == "HandCannon") then
			return false, "You are not allowed to use this gun to remove"
		end
	end
	local kind = self.Remove[netuser].kind
	if(kind == "admin" or kind == "all") then
		return true
	else
		if(self.underattack[structureComponent._master]) then
			if(util.GetTime() > (self.underattack[structureComponent._master] + self.Config.remove.antiremoveduringraidtime)) then
				self.underattack[structureComponent._master] = nil
			else
				return false, "You are under attack, you must wait " .. math.abs(util.GetTime() - (self.underattack[structureComponent._master] + self.Config.remove.antiremoveduringraidtime)) .. "s before being able to remove"
			end
		end
		if(self.Config.remove.antifloat) then
			if(structureComponent._master:ComponentCarryingWeight(structureComponent)) then
				return false, "The structure is carrying something on him"
			end
		end
		if(not takedamage.gameObject.Name) then
			return false, "This object has no name"
		else
			if(self.ItemTable[takedamage.gameObject.Name]) then
				if(not self.Config.removable[self.ItemTable[takedamage.gameObject.Name]]) then
					return false, "You are not allowed to remove this"
				end
			else
				return false, "This object is missing from the ItemTable"
			end
		end
		
		-- Add other stuff liek anti raid
	end
	return true
end
function PLUGIN:CanRemove(kind,userid,ownerid)
	if(userid == ownerid) then
		return true
	else
		if(kind == "all") then
			return true
		elseif(kind == "admin") then
			return true
		else
			if(self.groups) then
				local ownergroup = self.groups:checkPlayerGroup(ownerid)
				local usergroup = self.groups:checkPlayerGroup(userid)
				if(ownergroup ~= 0 and ownergroup == usergroup) then
					return true
				end
			end
			if(self.factions) then
				if(self.factions:inSameFaction(ownerid,userid)) then
					return true
				end
			end
			if(self.doorshare) then
				self.DoorShareDataFile = util.GetDatafile( "doorshare" )
				local txt = self.DoorShareDataFile:GetText()
				if (txt ~= "") then
					self.DoorShareData = json.decode( txt )
				else
					self.DoorShareData = {}
				end
				local sharedata = self.DoorShareData[ ownerid ]
				if (sharedata) then
					if (sharedata.Allowed) then 
						if (sharedata.Allowed[ userid ]) then 
							return true
						end
					end
				end
			end
		end
	end
	return false
end

function PLUGIN:ActivateRemoveTimer(netuser,kind)
	if(self.timer[netuser]) then self.timer[netuser]:Destroy() end 
	self.timer[netuser] = timer.Once(self.Config.remove.autodeactivatetime, function() self:DeactivateRemove(netuser) end)
	self.Remove[netuser] = {}
	self.Remove[netuser].kind = kind
end
function PLUGIN:DeactivateRemove(netuser)
	if(not netuser) then return end
	if(self.timer[netuser]) then self.timer[netuser]:Destroy() end 
	rust.Notice(netuser, "Remove deactivated")
	rust.SendChatToUser(netuser, self.Config.ChatName, "Remove deactivated")
	self.Remove[netuser] = {}
	self.Remove[netuser] = nil
end

function PLUGIN:LoadVars()
	self.Remove = {}
	self.timer = {}
	self.undotimer = {}
	self.underattack = {}
	self.lastRemove = {}
	self.Prod = {}
	self.Undo = {}
end
function PLUGIN:isAdmin(netuser)
	if(netuser:CanAdmin()) then return true end
	if(self.oxmin_plugin and self.oxmin_plugin:HasFlag( netuser, 13 )) then return true end
	if(self.flags_plugin and self.flags_plugin:HasFlag(tostring( rust.GetLongUserID(netuser) ), self.Config.flagsplugin_flag )) then return true end
	return false
end
function PLUGIN:FindPlayer(netuser,name)
	local b, targetuser = rust.FindNetUsersByName(name)
	if (not b) then
		if (targetuser == 0) then
			rust.Notice(netuser, "No players found with that name!")
		else
			rust.Notice(netuser, "Multiple players found with that name!")
		end
		return false
	end
	return targetuser
end
function PLUGIN:LoadAdminStuff()
	self.oxmin_plugin = plugins.Find("oxmin")
	self.flags_plugin = plugins.Find("flags")
end
function PLUGIN:LoadCFG()
	local b, res = config.Read( "r-remover" )
	self.Config = res or {}
	if (not b or not self.Config.Version or ( self.Config.Version and self.Config.Version ~= "3.2")) then
		print("r-remover: Loading Default Configs")
		self:LoadDefaultCFG()
	end
end
function PLUGIN:LoadCmd()
	if(self.Config.remove.allowcmd) then
		self:AddChatCommand( "remove", self.cmdRemove )
	end
	if(self.Config.undo.allowcmd) then
		self:AddChatCommand( "undo", self.cmdUndo )
	end
	if(self.Config.prod.allowcmd) then
		self:AddChatCommand( "prod", self.cmdProd )
	end
	
end
function PLUGIN:LoadShareRemove()
	if (self.Config.remove.shared.groups) then
		self.groups = plugins.Find( "groups" )
	end
	if (self.Config.remove.shared.doorshare) then
		self.doorshare = plugins.Find( "doorshare" )
	end
	if (self.Config.remove.shared.factions) then
		self.factions = plugins.Find( "Factions_basics" )
	end
end
function PLUGIN:ToSteamID64(steamID)
    local A,B
    local id = steamID:split(":")
    if tonumber(id[2]) > tonumber(id[3]) then
        A = id[3]
        B = id[2]
    else
        A = id[2]
        B = id[3]
    end
    id = (((B * 2) + A) + 1197960265728)
    id = "7656" .. id
    return id
end
function PLUGIN:Unload()
	for netuser,d in pairs(self.timer) do
		self.timer[netuser]:Destroy()
	end
end
function PLUGIN:SecsToTime(timestamp)
	local days = math.floor(timestamp / 86400)
	local msg = ""
	if(days >= 1) then
		msg = days .. "d "
		timestamp = timestamp - (days*86400)
	end
	local hours = math.floor(timestamp / 3600)
	if(hours >= 1) then
		msg = msg .. hours .. "h "
		timestamp = timestamp - (hours * 3600)
	end
	local mins = math.floor(timestamp / 60)
	if(mins >= 1) then
		msg = msg .. mins .. "mins "
		timestamp = timestamp - (mins * 60)
	end
	local secs = math.floor(timestamp)
	if(secs >= 1) then
		msg = msg .. secs .. "secs "
	end
	return msg
end
function PLUGIN:OnUserDisconnect( networkplayer )
    local netuser = networkplayer:GetLocalData()
	self.Remove[netuser] = {}
	self.Remove[netuser] = nil
	if(self.timer[netuser]) then
		self.timer[netuser]:Destroy()
		self.timer[netuser] = nil
	end
end

function PLUGIN:LoadDefaultCFG()
	self.Config.Version = "3.2"
	self.Config.flagsplugin_flag = "ban"
	
	self.Config.remove = {}
	self.Config.remove.refund = true
	self.Config.remove.log = true
	self.Config.remove.allowcmd = true
	self.Config.remove.onlyadminremove = false
	self.Config.remove.antifloat = true
	self.Config.remove.autodeactivatetime = 30
	self.Config.remove.antiremoveduringraid = true
	self.Config.remove.antiremoveduringraidtime = 120
	self.Config.remove.shared = {}
	self.Config.remove.shared.doorshare = true
	self.Config.remove.shared.factions = false
	self.Config.remove.shared.groups = true
	
	self.Config.undo = {}
	self.Config.undo.log = true
	--self.Config.undo.onlyadminundo = true
	self.Config.undo.allowcmd = true
	self.Config.undo.timesaved = 320 
	
	self.Config.prod = {}
	self.Config.prod.allowcmd = true
	self.Config.prod.onlyadminprod = true
	self.Config.prod.SteamAPIKey = ""
	self.Config.prod.ShowLastUsed = true
	
	self.Config.removable = {}
	self.Config.removable["Wood Barricade"] = true
	self.Config.removable["Camp Fire"] = false
	self.Config.removable["Sleeping Bag"] = false
	self.Config.removable["Wood Shelter"] = true
	self.Config.removable["Furnace"] = true
	self.Config.removable["Workbench"] = true
	self.Config.removable["Bed"] = false
	self.Config.removable["Repair Bench"] = true
	self.Config.removable["Large Spike Wall"] = true
	self.Config.removable["Spike Wall"] = true
	self.Config.removable["Wood Gateway"] = true
	self.Config.removable["Wood Gate"] = true
	self.Config.removable["Large Wood Storage"] = true
	self.Config.removable["Wood Storage Box"] = true
	self.Config.removable["Small Stash"] = true
	self.Config.removable["Wooden Door"] = true
	self.Config.removable["Wood Foundation"] = true
	self.Config.removable["Wood Window"] = true
	self.Config.removable["Wood Doorway"] = true
	self.Config.removable["Wood Wall"] = true
	self.Config.removable["Wood Ceiling"] = true
	self.Config.removable["Wood Ramp"] = true
	self.Config.removable["Wood Stairs"] = true
	self.Config.removable["Wood Pillar"] = true
	self.Config.removable["Metal Foundation"] = true
	self.Config.removable["Metal Window"] = true
	self.Config.removable["Metal Doorway"] = true
	self.Config.removable["Metal Wall"] = true
	self.Config.removable["Metal Ceiling"] = true
	self.Config.removable["Metal Ramp"] = true
	self.Config.removable["Metal Stairs"] = true
	self.Config.removable["Metal Pillar"] = true
	self.Config.removable["Metal Window Bars"] = true
	self.Config.removable["Metal Door"] = true
	
	self.Config.refund = {}
	self.Config.refund["Wood Barricade"] = { item = "Wood Barricade", amount = 1}
	self.Config.refund["Camp Fire"] = { item = "Wood", amount = 5}
	self.Config.refund["Sleeping Bag"] = { item = "Sleeping Bag", amount = 1}
	self.Config.refund["Wood Shelter"] = { item = "Wood Shelter", amount = 1}
	self.Config.refund["Furnace"] = { item = "Furnace", amount = 1}
	self.Config.refund["Workbench"] = { item = "Workbench", amount = 1}
	self.Config.refund["Bed"] = { item = "Bed", amount = 1}
	self.Config.refund["Repair Bench"] = { item = "Repair Bench", amount = 1 }
	self.Config.refund["Large Spike Wall"] = { item = "Large Spike Wall", amount = 1 }
	self.Config.refund["Spike Wall"] = { item = "Spike Wall", amount = 1 }
	self.Config.refund["Wood Gateway"] = { item = "Wood Gateway", amount = 1 }
	self.Config.refund["Wood Gate"] = { item = "Wood Gate", amount = 1 }
	self.Config.refund["Large Wood Storage"] = { item = "Large Wood Storage", amount = 1 }
	self.Config.refund["Wood Storage Box"] = { item = "Wood Storage Box", amount = 1 }
	self.Config.refund["Small Stash"] = { item = "Small Stash", amount = 1 }
	self.Config.refund["Wooden Door"] = { item = "Wooden Door", amount = 1 }
	self.Config.refund["Wood Foundation"] = { item = "Wood Foundation", amount = 1 }
	self.Config.refund["Wood Window"] = { item = "Wood Window", amount = 1 }
	self.Config.refund["Wood Doorway"] = { item = "Wood Doorway", amount = 1 }
	self.Config.refund["Wood Wall"] = { item = "Wood Wall", amount = 1 }
	self.Config.refund["Wood Ceiling"] = { item = "Wood Ceiling", amount = 1 }
	self.Config.refund["Wood Ramp"] = { item = "Wood Ramp", amount = 1 }
	self.Config.refund["Wood Stairs"] = { item = "Wood Stairs", amount = 1 }
	self.Config.refund["Wood Pillar"] = { item = "Wood Pillar", amount = 1 }
	self.Config.refund["Metal Foundation"] = { item = "Metal Foundation", amount = 1 }
	self.Config.refund["Metal Window"] = { item = "Metal Window", amount = 1 }
	self.Config.refund["Metal Doorway"] = { item = "Metal Doorway", amount = 1 }
	self.Config.refund["Metal Wall"] = { item = "Metal Wall", amount = 1 }
	self.Config.refund["Metal Ceiling"] = { item = "Metal Ceiling", amount = 1 }
	self.Config.refund["Metal Ramp"] = { item = "Metal Ramp", amount = 1 }
	self.Config.refund["Metal Stairs"] = { item = "Metal Stairs", amount = 1 }
	self.Config.refund["Metal Pillar"] = { item = "Metal Pillar", amount = 1 }
	self.Config.refund["Metal Window Bars"] = { item = "Metal Window Bars", amount = 1 }
	self.Config.refund["Metal Door"] = { item = "Metal Door", amount = 1 }
	
	self.Config.UberHatchetCanDestroy = true
	self.Config.ChatName = "Remover"
	config.Save( "r-remover" )
end

function PLUGIN:LoadItemTable()
	self.ItemTable = {}
	self.ItemTable["Wood_Shelter(Clone)"] = "Wood Shelter"
	self.ItemTable["Campfire(Clone)"] = "Wood"
	self.ItemTable["Furnace(Clone)"] = "Furnace"
	self.ItemTable["Workbench(Clone)"] = "Workbench"
	self.ItemTable["SleepingBagA(Clone)"] = "Sleeping Bag"
	self.ItemTable["SingleBed(Clone)"] = "Bed"
	self.ItemTable["RepairBench(Clone)"] = "Repair Bench"
	-- Attack and protect
	self.ItemTable["LargeWoodSpikeWall(Clone)"] = "Large Spike Wall"
	self.ItemTable["WoodSpikeWall(Clone)"] = "Spike Wall"
	self.ItemTable["Barricade_Fence_Deployable(Clone)"] = "Wood Barricade"
	self.ItemTable["WoodGateway(Clone)"] = "Wood Gateway"
	self.ItemTable["WoodGate(Clone)"] = "Wood Gate"
	-- Storage
	self.ItemTable["WoodBoxLarge(Clone)"] = "Large Wood Storage"
	self.ItemTable["WoodBox(Clone)"] = "Wood Storage Box"
	self.ItemTable["SmallStash(Clone)"] = "Small Stash"
	-- Structure Wood
	self.ItemTable["WoodFoundation(Clone)"] = "Wood Foundation"
	self.ItemTable["WoodWindowFrame(Clone)"] = "Wood Window"
	self.ItemTable["WoodDoorFrame(Clone)"] = "Wood Doorway"
	self.ItemTable["WoodWall(Clone)"] = "Wood Wall"
	self.ItemTable["WoodenDoor(Clone)"] = "Wooden Door"
	self.ItemTable["WoodCeiling(Clone)"] = "Wood Ceiling"
	self.ItemTable["WoodRamp(Clone)"] = "Wood Ramp"
	self.ItemTable["WoodStairs(Clone)"] = "Wood Stairs"
	self.ItemTable["WoodPillar(Clone)"] = "Wood Pillar"
	-- Structure Metal
	self.ItemTable["MetalFoundation(Clone)"] = "Metal Foundation"
	self.ItemTable["MetalWall(Clone)"] = "Metal Wall"
	self.ItemTable["MetalDoorFrame(Clone)"] = "Metal Doorway"
	self.ItemTable["MetalDoor(Clone)"] = "Metal Door"
	self.ItemTable["MetalCeiling(Clone)"] = "Metal Ceiling"
	self.ItemTable["MetalStairs(Clone)"] = "Metal Stairs"
	self.ItemTable["MetalRamp(Clone)"] = "Metal Ramp"
	self.ItemTable["MetalBarsWindow(Clone)"] = "Metal Window Bars"
	self.ItemTable["MetalWindowFrame(Clone)"] = "Metal Window"
	self.ItemTable["MetalPillar(Clone)"] = "Metal Pillar"
	
	self.PrefabTable = {}
	self.PrefabTable["WoodFoundation(Clone)"] = ";struct_wood_foundation"
	self.PrefabTable["WoodWindowFrame(Clone)"] = ";struct_wood_windowframe"
	self.PrefabTable["WoodDoorFrame(Clone)"] = ";struct_wood_doorway"
	self.PrefabTable["WoodWall(Clone)"] = ";struct_wood_wall"
	self.PrefabTable["WoodCeiling(Clone)"] = ";struct_wood_ceiling"
	self.PrefabTable["WoodRamp(Clone)"] = ";struct_wood_ramp"
	
	self.PrefabTable["WoodStairs(Clone)"] = ";struct_wood_stairs"
	self.PrefabTable["WoodPillar(Clone)"] = ";struct_wood_pillar"
	
	--- Structure Metal ---
	self.PrefabTable["MetalFoundation(Clone)"] = ";struct_metal_foundation"
	self.PrefabTable["MetalWall(Clone)"] = ";struct_metal_wall"
	self.PrefabTable["MetalDoorFrame(Clone)"] = ";struct_metal_doorframe"
	self.PrefabTable["MetalCeiling(Clone)"] = ";struct_metal_ceiling"
	self.PrefabTable["MetalStairs(Clone)"] = ";struct_metal_stairs"
	self.PrefabTable["MetalWindowFrame(Clone)"] = ";struct_metal_windowframe"
	self.PrefabTable["MetalRamp(Clone)"] = ";struct_metal_ramp"
	self.PrefabTable["MetalPillar(Clone)"] = ";struct_metal_pillar"
	
	---- Allowed to copy items ----
	self.PrefabTable["WoodBoxLarge(Clone)"] = ";deploy_wood_storage_large"
	self.PrefabTable["WoodBox(Clone)"] = ";deploy_wood_box"
	self.PrefabTable["SmallStash(Clone)"] = ";deploy_small_stash"
	self.PrefabTable["Wood_Shelter(Clone)"] = ";deploy_wood_shelter"
	self.PrefabTable["Campfire(Clone)"] = ";deploy_camp_bonfire"
	self.PrefabTable["Furnace(Clone)"] = ";deploy_furnace"
	self.PrefabTable["Workbench(Clone)"] = ";deploy_workbench"
	self.PrefabTable["SleepingBagA(Clone)"] = ";deploy_camp_sleepingbag"
	self.PrefabTable["SingleBed(Clone)"] = ";deploy_singlebed"
		--self.ItemTable["RepairBench(Clone)"] = "Repair Bench"
	
	self.PrefabTable["LargeWoodSpikeWall(Clone)"] = ";deploy_largewoodspikewall"
	self.PrefabTable["WoodSpikeWall(Clone)"] = ";deploy_woodspikewall"
	self.PrefabTable["Barricade_Fence_Deployable(Clone)"] = ";deploy_wood_barricade"
	self.PrefabTable["WoodGateway(Clone)"] = ";deploy_woodgate"
	self.PrefabTable["WoodGate(Clone)"] = ";deploy_woodgateway"
	self.PrefabTable["WoodenDoor(Clone)"] = ";deploy_wood_door"
	self.PrefabTable["MetalDoor(Clone)"] = ";deploy_metal_door"
	self.PrefabTable["MetalBarsWindow(Clone)"] = ";deploy_metalwindowbars"

end

function PLUGIN:SendHelpText( netuser )
	if(not self.Config.remove.onlyadminremove) then
		rust.SendChatToUser( netuser, "Use /remove to activate the remover tool" )
	else
		if self:isAdmin(netuser) then
			rust.SendChatToUser( netuser, "Use /remove to activate the remover tool" )
		end
	end
	if self:isAdmin(netuser) then
		rust.SendChatToUser( netuser, "Use /remove admin, to activate the admin remover" )
		rust.SendChatToUser( netuser, "Use /remove STEAMID/COMMUNITYID, to remove all structures from a steam user" )
		rust.SendChatToUser( netuser, "Use /remove all, to activate remove the entire structure" )
		rust.SendChatToUser( netuser, "Use /remove PLAYER, to activate the remover tool on a player" )
	end
	if(not self.Config.prod.onlyadminprod) then
		rust.SendChatToUser( netuser, "Use /prod, to see who the structure belongs to" )
	else
		if self:isAdmin(netuser) then
			rust.SendChatToUser( netuser, "Use /prod, to see who the structure belongs to" )
		end
	end
end