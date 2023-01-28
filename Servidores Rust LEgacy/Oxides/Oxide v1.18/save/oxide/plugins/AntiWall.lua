PLUGIN.Title = "Anti Wallhack bullets"
PLUGIN.Description = "Checks if a player is using wallhack to shoot people through walls"
PLUGIN.Version = "1.2.5"
PLUGIN.Author = "Reneb & Mughisi"

function util.FindOverloadedMethodByRef( typ, method, bindingFlags, typeList )
typ = typesystem.TypeFromMetatype( typ )
    local methods = typ:GetMethods( bindingFlags )
    if (methods.Length == 0) then
        error( "Tried to find overloaded method '" .. name .. "' on type '" .. typ.Name .. "', no candidates found!" )
        return
    end

    for i=1, methods.Length do
        local methodinfo = methods[i - 1]
        if (method and methodinfo.Name == method) then
            local plist = methodinfo:GetParameters()
            if (plist.Length == #typeList) then
                local found = true
                for j=1, plist.Length do
                    local paraminfo = plist[j - 1]
                    local othertype = typesystem.TypeFromMetatype( typeList[j] )
                    if (paraminfo.ParameterType ~= othertype) then
                        if (paraminfo.Name ~= "hit" and paraminfo.Name ~= "hitMergedMeshBatchInstance" and paraminfo.Name ~= "hitInstance" ) then
                            found = false
                            break
                        end
                    end
                end
                if (found) then return methodinfo end
            end
        end
    end
end

function PLUGIN:Init()
	self.Detections = {}
	local b, res = config.Read("r-antiwallhackbullets")
	self.Config = res or {}
	if (not b or not self.Config.Version or (self.Config.Version and self.Config.Version ~= "1.2.2")) then
		self:LoadDefaultConfig()
		config.Save("r-antiwallhackbullets")
	end
	self.DoStuff = {}
end
function PLUGIN:PostInit()
	self.ebs = plugins.Find("EnhancedBanSystem")
end

local LifeStatusType = cs.gettype( "LifeStatus, Assembly-CSharp" )
typesystem.LoadEnum(LifeStatusType, "LifeStatus" )

local typ1 = cs.gettype( "Facepunch.MeshBatch.MeshBatchPhysics, Facepunch.MeshBatch" )
local RefParam2 = cs.gettype("UnityEngine.RaycastHit&, UnityEngine" )
local RefParam3 = cs.gettype("System.Boolean&, System" )
local RefParam4 = cs.gettype("Facepunch.MeshBatch.MeshBatchInstance&, Facepunch.MeshBatch" )
local _MeshBatchPhysics = util.FindOverloadedMethodByRef( typ1, "Raycast", bf.public_static, { UnityEngine.Ray, RefParam2, RefParam3, RefParam4 } )
cs.registerstaticmethod( "tmp", _MeshBatchPhysics )
local MeshBatchPhysics = tmp
tmp = nil

local function TraceEyes( netuser )
    local controllable = netuser.playerClient.controllable
    local char = controllable:GetComponent( "Character" )
    if(not char) then return false end
	local ray = char.eyesRay
	if(not ray) then return false end
    local rep,hits,boolrep,meshbatch = MeshBatchPhysics(ray)
	if(not meshbatch) then 
		if(hits and hits.collider) then
			return hits.distance, tostring(hits.collider.GameObject.Name)
		else
			return false, false
		end
	end
    return hits.distance, tostring(meshbatch.graphicalModel)
end
local StatusIntGetter = util.GetFieldGetter( Rust.DamageEvent, "status", nil, System.Int32 )
local LifeStatus_IsAlive = 0
local LifeStatus_IsDead = 2
local LifeStatus_WasKilled = 1
local LifeStatus_Failed = -1
function PLUGIN:ModifyDamage(takedamage, damage)
	if not (tostring(type(damage) ~= "userdata")) or not (tostring(type(takedamage) ~= "userdata")) then
		return
	end
	if(StatusIntGetter( damage ) == LifeStatus_WasKilled) then
		if (takedamage:GetComponent( "HumanController" )) then
			if(damage.victim.client and damage.attacker.client and damage.extraData) then
				if(damage.victim.client == damage.attacker.client) then return end
				local attackerpos = damage.attacker.client.netUser.playerClient.lastKnownPosition
				local victimpos = damage.victim.client.netUser.playerClient.lastKnownPosition
				local attackereyes, model = TraceEyes(damage.attacker.client.netUser)
				local dist = Rust.TransformHelpers.Dist2D(attackerpos,victimpos)
				if(attackereyes and attackereyes < (dist - 1)) then
					if(string.find(model,"ceiling") or string.find(model,"wall")) then
						local thetype = ""
						if(string.find(model,"ceiling")) then
							thetype = "ceiling"
						else
							thetype = "wall"
						end
						if(self.Config.DenyWallHackKillsThenBanIfPersistant) then
							damage.amount = 0
							damage.status = LifeStatus.IsAlive
							print(damage.attacker.client.netUser.displayName .. " shot " .. damage.victim.client.netUser.displayName .. " through a " .. tostring(thetype) .. " at " ..math.floor(attackereyes) .. "m to hit at " .. math.floor(dist) .. "m" )
							takedamage.health = 10
							local controllable = damage.victim.client.netUser.playerClient.controllable
							local metabolism = controllable:GetComponent("Metabolism")
							local humantakedamage = controllable:GetComponent("HumanBodyTakeDamage")
							humantakedamage:SetBleedingLevel(0)
						end
						self:Detected(damage.attacker.client.netUser,thetype,attackereyes,dist)
						return damage
					--[[elseif(model == "") then
						if(self.Config.DenyWallHackKillsThenBanIfPersistant) then
							damage.amount = 0
							damage.status = LifeStatus.IsAlive
							takedamage.health = 10
							print(damage.attacker.client.netUser.displayName .. " shot " .. damage.victim.client.netUser.displayName .. " through a Rock/tree at " ..math.floor(attackereyes) .. "m to hit at " .. math.floor(dist) .. "m" )
							local controllable = damage.victim.client.netUser.playerClient.controllable
							local metabolism = controllable:GetComponent("Metabolism")
							local humantakedamage = controllable:GetComponent("HumanBodyTakeDamage")
							humantakedamage:SetBleedingLevel(0)
						end
						self:Detected(damage.attacker.client.netUser,"Rock or Tree",attackereyes,dist)
						return damage]]
					end
				end
			end
		end
	end
	return
end
function PLUGIN:Detected(netuser,thetype,attackereyes,dist)
	if(self.Config.DenyWallHackKillsThenBanIfPersistant and self.Detections[netuser] and (util.GetTime() - self.Detections[netuser]) > 0.1) then
		if((util.GetTime() - self.Detections[netuser]) < 3) then
			rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rWallHack\"")
			print(netuser.displayName .. " has been auto banned for wallhacking ")	
			if(self.ebs) then
				local nargs = {}
				nargs[1] = netuser.networkPlayer.externalIP
				nargs[2] = "rWallHack"
				self.ebs:cmdBan(false,nargs)
			end
			rust.BroadcastChat("WallHack","[color #996600]" .. netuser.displayName .. " has been auto banned for Wall-Hacking")
			netuser:Kick(NetError.Facepunch_Kick_Ban, true)	
			return
		end
	end
	self.Detections[netuser] = util.GetTime()
	if(self.Config.SendDetectionsToAdmins) then
		self:SendToAdmins( netuser.displayName .. " shot through a " .. tostring(thetype) .. " at " ..math.floor(attackereyes) .. "m to hit at " .. math.floor(dist) .. "m" )
	end
end
function PLUGIN:LoadDefaultConfig()
	self.Config.chatName = "Anti-Wallhack"
	self.Config.Version = "1.2.2"
	self.Config.SendDetectionsToAdmins = true
	self.Config.DenyWallHackKillsThenBanIfPersistant = true
end

function PLUGIN:SendToAdmins(msg)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		if(targetuser:CanAdmin()) then
			rust.SendChatToUser(targetuser, self.Config.chatName, msg)
		end
	end
end