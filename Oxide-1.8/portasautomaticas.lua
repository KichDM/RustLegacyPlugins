PLUGIN.Title = "Door Closer"
PLUGIN.Description = "Automatic door closer. Players no longer need to close doors behind them."
PLUGIN.Author = "LazyMammal"
PLUGIN.Version = "0.1.1"

-- repeat timer uses global scope to allow smooth "oxide.reload doorcloser"
if DoorCloserSaveTimer then
    print "Door Closer: cancelling old timer"
    DoorCloserSaveTimer:Destroy()
end
DoorCloserSaveTimer = nil

-- Credit to "Door Remote Control" plugin for door state changer
local NullableOfVector3 = typesystem.MakeNullableOf( UnityEngine.Vector3 )
local NullableOfBoolean = typesystem.MakeNullableOf( System.Boolean )
local ToggleStateServer = util.FindOverloadedMethod( Rust.BasicDoor, "ToggleStateServer", bf.private_instance, { NullableOfVector3, System.UInt64, NullableOfBoolean } )
local GetDoorState, SetDoorState = typesystem.GetField( Rust.BasicDoor, "state", bf.private_instance )
local CurrentTime = util.GetStaticPropertyGetter( cs.gettype("NetCull, Assembly-CSharp"), "timeInMillis")
function PLUGIN:close_door(door)
    if (tostring(GetDoorState(door)) == "Opened: 1") then
        local timestamp = CurrentTime()
        local origin = new( UnityEngine.Vector3 )
        local arr = util.ArrayFromTable( System.Object, { new( NullableOfVector3, origin ), timestamp, nil }, 3 )
        cs.convertandsetonarray( arr, 1, timestamp, System.UInt64._type )
        local res= ToggleStateServer:Invoke( door, arr )
    end
end

function PLUGIN:Init()

    -- load config file
    self.cfgfile = "doorcloser"
    local b, res = config.Read(self.cfgfile)
    self.Config = res or {}
    if (not b) or (self.Config.delay == nil) then
        self:LoadDefaultConfig()
        if (res) then config.Save(self.cfgfile) end
    end
    
    -- load player preferences
    self.delayTable = {}
    self.prefsDataFile = util.GetDatafile( "doorcloser_data" )
    local txt = self.prefsDataFile:GetText()
    if txt ~= "" then self.delayTable = json.decode( txt ) end

    -- add chat commands
    self:AddChatCommand( "doorcloser", self.cmdDoorCloser)
    
    -- add timers
    print "Door Closer: initiating save timer"
    DoorCloserSaveTimer = timer.Repeat( self.Config.save_interval, function() self:SavePrefs() end )

end

function PLUGIN:LoadDefaultConfig()
    print "Door Closer: using default config"
    self.Config.delay = 5 -- default delay (seconds)
    self.Config.delay_max = 30 -- maximum delay allowed (seconds)
    self.Config.enabled = false -- is Door Closer enabled by default
    self.Config.save_interval = 310 -- user prefs save frequency (seconds)
end

function PLUGIN:SavePrefs()
    self.prefsDataFile:SetText( json.encode( self.delayTable ) )
    self.prefsDataFile:Save()
end

function PLUGIN:CanOpenDoor(netuser, door) -- called when a user opens door (or at least attempts to)
    local steamID = rust.CommunityIDToSteamID( tonumber(rust.GetUserID(netuser)) )
    local delay = self.delayTable[steamID]
    if delay == nil and self.Config.enabled then -- use default delay if plugin is enabled by default
        delay = self.Config.delay
    end
    
    if delay ~= nil and delay >= 0 then -- don't activate if delay is zero or nil
        if (tostring(GetDoorState(door)) == "Closed: 3") then
            -- come back after short delay to close door
            timer.Once( delay, function() self:DoorCloser(door) end )
        end
    end
end

function PLUGIN:DoorCloser(door)
    local basicdoor = door:GetComponent("BasicDoor")
    if basicdoor ~= nil then -- if (door.name == "MetalDoor(Clone)" or door.name == "WoodenDoor(Clone)") then
        -- close door (if open)
        self:close_door(door)
    end
end

function PLUGIN:cmdDoorCloser(netuser, cmd, args)  -- chat command to change Door Closer setting
    local steamID = rust.CommunityIDToSteamID( tonumber(rust.GetUserID(netuser)) )
    
    if #args > 0 then -- delay specified
        local delay = tonumber(args[1])
        
        if delay == nil or delay <= 0 then -- off
            self.delayTable[steamID] = 0
            rust.Notice(netuser, "Door Closer OFF.")
        else
            delay = math.min( delay, self.Config.delay_max ) -- don't exceed delay_max
            self.delayTable[steamID] = delay
            rust.Notice(netuser, "Door Closer: ".. delay .." seconds")
        end
    
    else -- no arg, toggle
        local delay = self.delayTable[steamID]
        if delay == nil and self.Config.enabled then -- use default delay if plugin is enabled by default
            print "DC: using default"
            delay = self.Config.delay
        end
    
        if delay ~= nil and delay > 0 then -- de-activate if delay is set
            self.delayTable[steamID] = 0
            rust.Notice(netuser, "Door Closer OFF")
        else
            self.delayTable[steamID] = self.Config.delay
            rust.Notice(netuser, "Door Closer ON")
        end
    end
end

function PLUGIN:SendHelpText( netuser )
    rust.SendChatToUser( netuser, "Door Closer: /doorcloser [delay]" )
end
