PLUGIN.Title = "Web Chat"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "1.1"
PLUGIN.Description = "Sends ingame chat to an external script"
PLUGIN.ResourceId = "466"
PLUGIN.ConfigFile = "webchat"
PLUGIN.DataFile = "webchatdata"

-- changelog
-- config bugfix
-- code improvements



-- Debug mode
local debug = false
--

-- ****************************
-- Init
-- ****************************
function PLUGIN:Init()
	self:LoadConfig()
	self:LoadDataFile()
    print(self.Title.." v"..self.Version.." loaded")
end
function PLUGIN:LoadConfig()
	local b, res = config.Read(self.ConfigFile)
	self.Config = res or {}
    -- Config settings
    self.Config.maxlines = self.Config.maxlines or 10
    self.Config.url = self.Config.url or ""
    self.Config.logSayMsg = self.Config.logSayMsg or "false"
    -- Old settings
    self.Config.version = nil -- removed in v1.0
    -- Save config
    config.Save(self.ConfigFile)
end
function PLUGIN:LoadDataFile()
	self.ChatFile = util.GetDatafile(self.DataFile)
	local data = self.ChatFile:GetText()
	if(data == "") then
		self.ChatData = {}
	else
		self.ChatData = json.decode(data)
	end
end
function PLUGIN:Save()
    self.ChatFile:SetText(json.encode(self.ChatData))
    self.ChatFile:Save()
end

-- ****************************
-- OnUserChat()
-- Triggered when someone chats
-- ****************************
function PLUGIN:OnUserChat(netuser, name, msg)
	if(msg:sub( 1, 1 ) ~= "/") then
		local timestamp = util.GetTime()
        local steamID64 = rust.GetLongUserID(netuser)
		local newChatline = {timestamp, netuser.displayName, msg, steamID64 }
		-- Debug messages
		if(debug) then
            print(self.Title.." ----- DEBUG OnUserChat() -----")
            print("timestamp: "..tostring(timestamp))
            print("communityId: "..tostring(steamID64))
            print("msg: "..tostring(msg))
            print("name: "..netuser.displayName)
            print("------------------------------")
        end
		-- Remove first line if maxlines are exceeded
		if(#self.ChatData >= self.Config.maxlines) then
			table.remove(self.ChatData, 1)
        end
        -- Insert new data, save the file and send it
		table.insert(self.ChatData, newChatline)
		self:Save()
		self:SendChat()
    end
end

-- ****************************
-- OnRunCommand()
-- Triggeres on console commands
-- ****************************
function PLUGIN:OnRunCommand(arg, wantreply)
    if(self.Config.logSayMsg == "true") then
        -- Only process say command
        if(arg.Class == "global" and arg.Function == "say") then
            local timestamp = util.GetTime()
            local name
            local steamID64 = 0
            local msg = arg.ArgsStr
            -- Check if message is nestled with "" and remove them if yes
            if(string.sub(msg, 1, 1) == '"' and string.sub(msg, -1) == '"') then
                msg = string.sub(msg, 2, (string.len(msg) - 1))
            end
            -- Check if command is sent by clientconsole or remote console
            if(arg.argUser ~= nil) then
                name = arg.argUser.displayName
                steamID64 = rust.GetLongUserID(arg.argUser)
            else
                name = "SERVER CONSOLE"
            end
            local newChatline = {timestamp, name, msg, steamID64 }
            -- Debug messages
            if(debug) then
                print(self.Title.." ----- DEBUG OnRunCommand() -----")
                print("timestamp: "..tostring(timestamp))
                print("communityId: "..tostring(steamID64))
                print("msg: "..tostring(msg))
                print("name: "..tostring(name))
                print("--------------------------------")
            end
            -- Remove first line if maxlines are exceeded
            if(#self.ChatData >= self.Config.maxlines) then
                table.remove(self.ChatData, 1)
            end
            -- Insert new data, save the file and send it
            table.insert(self.ChatData, newChatline)
            self:Save()
            self:SendChat()
        end
    end
end

-- ****************************
-- SendChat()
-- Sends the chat to the external script
-- ****************************
function PLUGIN:SendChat()
	local url = self.Config.url
	local data = "chatdata="..json.encode(self.ChatData)
	local r = webrequest.Post(url, data, function(code, response)
        -- Debug
        if(debug) then
            print(self.Title.." ----- DEBUG SendChat() -----")
            print("code: "..tostring(code))
            print("response: "..tostring(response))
        end
        -- Check HTTP-Statuscodes
        if(code == 404) then
            print(self.Title..": ERROR - Webreqquest failed. Script not found, check url")
            return
        elseif(code == 503) then
            print(self.Title..": ERROR - Webrequest failed. Webserver unavailable")
            return
        elseif(code == 200) then
            -- Debug
            if(debug) then
                print("webrequest: Sent successful (code 200)")
            end
        else
            print(self.Title..": ERROR - Webrequest failed. Error code: "..tostring(code))
            return
		end
	end)
    -- Webrequest wasnt sent
	if(not r) then
        print(self.Title..": ERROR - Couldnt send webrequest")
        return
    end
    -- Debug
    if(debug) then
        print("r: "..tostring(r))
        print("--------------------------------")
    end
end

