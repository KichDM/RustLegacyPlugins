PLUGIN.Title = "automessage"
PLUGIN.Description = "Send different messages to the chat with a delay!"
PLUGIN.Version = "1.16.1"
PLUGIN.Author = "rexas  http://rexas.net"

PLUGIN.GetTime = util.GetStaticPropertyGetter( UnityEngine.Time, "realtimeSinceStartup" )

print(PLUGIN.Title .. " plugin loaded")
print("-----------------------")

function PLUGIN:Init()
	self.aDataFile = util.GetDatafile( "automessage" )
	local txt = self.aDataFile:GetText()
	if (txt ~= "") then
		self.aData = json.decode( txt )
	else
		self.aData =
		{
			["ChatName"] = "[SERVER MESSAGE]",
			["MessageDelay"] = 600,
			["SendAllChat"] = true,
			["SendNotice"] = false,
			["SendMessagesInRandomOrder"] = true,
			["LastMessageID"] = 0,
			["MessageList"] =
			{
				{
					"For latest updates and rules visit our website",
					"http://example.com"
				},
				{
					"Need help? Get a admin to help you with /admin"
				},
				{
					"Are your tiered of that connection queue?",
					"Upgrade your account to member on our homepage and reserved slot!",
					"http://example.com"
				}
			}
		};
		-- We run the save to create the save files.
		self:Save();
	end
	
	self.lastMessageTime = self.GetTime()
	
	--self:AddCommand( "automessage", "reload", self.Reload )
	self:AddCommand( "automessage", "sendmessage", self.ForceMessage )
	
	
	-- Make timer
	self.myTimer = timer.Repeat( 1, 0, function() self:SendNextMessage() end )
	
end

function PLUGIN:Save()
	self.aDataFile:SetText( json.encode( self.aData ) )
	self.aDataFile:Save()
end

function PLUGIN:ForceMessage( arg )
	local user = arg.argUser
	if (user and not user:CanAdmin())
	then
		rust.Notice(arg.argUser, "Login to rcon and try again!")
		return
	end
	self:SendNextMessage(true)
end


function PLUGIN:Reload( arg )
	local user = arg.argUser
	if (user and not user:CanAdmin())
	then
		rust.Notice(arg.argUser, "Login to rcon and try again!")
		return
	end
	self.myTimer:Destroy()
	rust.Notice(arg.argUser, "Automessage reloaded!")
	plugins.Reload( "automessage" )
end;

function PLUGIN:Unload()
	self.myTimer:Destroy()
end

function PLUGIN:SendNextMessage(forceSend)
	if forceSend == nil
	then
		forceSend = false
	end
	--print("Trying to send a message, last one was at " .. self.lastMessageTime .. " and delay is " .. self.aData["MessageDelay"] .. ". Current time: " .. self.GetTime())
	if self.lastMessageTime == nil or (self.lastMessageTime + self.aData["MessageDelay"] <= self.GetTime()) or forceSend
	then
		local nameToSend = "";
		local msgToSend = "";
		
		if self.aData["ChatName"] == nil
		then
			nameToSend = "Oxide"
		else
			nameToSend = self.aData["ChatName"]
		end
		
		local tLen = self:TableLen(self.aData["MessageList"]);
		if self.aData["SendMessagesInRandomOrder"]
		then
			msgToSend = self.aData["MessageList"][math.random(1, tLen)]
		else
			if self.aData["LastMessageID"] + 1 > tLen
			then
				msgToSend = self.aData["MessageList"][1]
				self.aData["LastMessageID"] = 1;
			else
				self.aData["LastMessageID"] = self.aData["LastMessageID"] + 1;
				msgToSend = self.aData["MessageList"][self.aData["LastMessageID"]]
			end
		end;
		
		if self.aData["SendAllChat"]
		then
			for k,msg in pairs(msgToSend)
			do
				rust.BroadcastChat( nameToSend, msg )
			end
		end
		
		if self.aData["SendNotice"]
		then
			for k,msg in pairs(msgToSend)
			do
				self:BroadcastNotice( msg )
			end
		end
		
		
		self.lastMessageTime = self.GetTime()
	end
end

function PLUGIN:BroadcastNotice(msg)
	local netUsers = rust.GetAllNetUsers()
	
	for k,netUser in pairs(netUsers)
	do
		rust.Notice( netUser, msg)
	end
end

function PLUGIN:TableLen(t)
	r = 0;
	for k,v in pairs(t)
	do
		r = r + 1;
	end
	return r;
end



-- This should not be needed any more, but it's left in to make sure that it still works if the timer stops working for some reason.
function PLUGIN:OnSpawnPlayer()
	self:SendNextMessage()
end;

function PLUGIN:OnTakeDamage()
	self:SendNextMessage()
end

function PLUGIN:OnDoorToggle()
	self:SendNextMessage()
end

function PLUGIN:OnAirdrop()
	self:SendNextMessage()
end

function PLUGIN:CanClientLogin()
	self:SendNextMessage()
end

function PLUGIN:OnSteamGetTags()
	self:SendNextMessage()
end

function PLUGIN:OnUserConnect()
	self:SendNextMessage()
end

function PLUGIN:OnUserChat()
	self:SendNextMessage()
end
