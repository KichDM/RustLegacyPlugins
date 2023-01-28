PLUGIN.Title = "GlobalStats"
PLUGIN.Description = "Saves player statistics - version 1.7"
PLUGIN.Author = "M@CH!N3"
PLUGIN.Version = "1.8"
PLUGIN.ConfigFile = "globalwebstats"
--By M@CH!N3

function PLUGIN:Init()
    	print( "Loading Global Stats..." )  
	self:LoadConfig()
	self.DataFile = util.GetDatafile("globalwebstats")
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Data = json.decode( txt )
	else
		self.Data = {}
		self.Data.Users = {}
	end
    
    -- Count and output the number of users
	local cnt = 0
	for _, _ in pairs( self.Data.Users ) do cnt = cnt + 1 end
	print( tostring( cnt ) .. " users are tracked by GobalStats!" )
    
    	self:AddChatCommand("mystats", self.cmdStats)
    	self:AddChatCommand("top", self.cmdRanking)
    	self:AddChatCommand("gshelp", self.cmdShelp)	
end

function PLUGIN:LoadConfig()
	local b, res = config.Read(self.ConfigFile)
	self.Config = res or {}

    -- Config settings
    self.Config.url = self.Config.url or ""
    self.Config.globalurl = self.Config.globalurl or ""	
    self.Config.bushycoin = self.Config.bushycoin or false
    self.Config.bearadd = self.Config.bearadd or 5
    self.Config.wolfadd = self.Config.wolfadd or 4
    self.Config.stagadd = self.Config.stagadd or 3
    self.Config.boaradd = self.Config.boaradd or 2
    self.Config.chickenadd = self.Config.chickenadd or 1
    self.Config.rabbitadd = self.Config.rabbitadd or 1
    self.Config.killadd = self.Config.killadd or 10


    -- Save config
    config.Save(self.ConfigFile)
end


function PLUGIN:SendHelpText( netuser )
    	rust.SendChatToUser( netuser, "Use /gshelp to learn about the leaderboards." )
end

function PLUGIN:OnKilled (takedamage, dmg)
    if (takedamage:GetComponent( "HumanController" )) then
        local victim = takedamage:GetComponent( "HumanController" )
        if (victim) then
            local netplayer = victim.networkViewOwner
            if (netplayer) then
                local netuser = rust.NetUserFromNetPlayer( netplayer )
                if (netuser) then
					if(dmg.attacker.networkView.gameObject:GetComponent("BearAI")) then
                        local killed = netuser
						local datakiller = "bear"
				 	    local datakilled = self:GetUserData( killed )
					    datakilled.Deaths = datakilled.Deaths + 1
						datakilled.Points = (datakilled.Kills * 10) + (datakilled.Bear * 5)+(datakilled.Wolf * 4)+(datakilled.Stag * 3)+(datakilled.Boar * 2) + (datakilled.Chicken) + (datakilled.Rabbit) - (datakilled.Deaths * 5) - (datakilled.Suicides * 5)
				 		self:Save()
				 		self:SendData()
				 end
				 	if(dmg.attacker.networkView.gameObject:GetComponent("WolfAI")) then
                        local killed = netuser
						local datakiller = "wolf"
				 	    local datakilled = self:GetUserData( killed )
					    datakilled.Deaths = datakilled.Deaths + 1
						datakilled.Points = (datakilled.Kills * 10) + (datakilled.Bear * 5)+(datakilled.Wolf * 4)+(datakilled.Stag * 3)+(datakilled.Boar * 2) + (datakilled.Chicken) + (datakilled.Rabbit) - (datakilled.Deaths * 5) - (datakilled.Suicides * 5)
						self:Save()
				 		self:SendData()				
				 end
				 	if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
                        local killer = dmg.attacker.client.netUser
                        local killed = netuser
                        if(killer==killed) then
	                       --SUICIDE
	                       local datakiller = self:GetUserData( killer )
	                       datakiller.Suicides = datakiller.Suicides + 1
						   datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)
	                       self:Save()
						   self:SendData()						   
			     else
				  	    --PVP
				     local datakiller = self:GetUserData( killer )
				     local datakilled= self:GetUserData( killed )
				     datakiller.Kills= datakiller.Kills + 1
				     datakilled.Deaths= datakilled.Deaths + 1
                     datakiller.Kdratio = datakiller.Kills/ datakiller.Deaths
                     datakilled.Kdratio = datakilled.Kills/ datakilled.Deaths
					 datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)
					 datakilled.Points = (datakilled.Kills * 10) + (datakilled.Bear * 5)+(datakilled.Wolf * 4)+(datakilled.Stag * 3)+(datakilled.Boar * 2) + (datakilled.Chicken) + (datakilled.Rabbit) - (datakilled.Deaths * 5) - (datakilled.Suicides * 5)
					 local call, req, res = api.Call ( "bushycoin", "add", killer, 10)					 
				     self:Save()
					 self:SendData()
			     end
                    end
                end
            end
        end
    end
    
    if (takedamage:GetComponent( "ZombieController" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Zombies= datakiller.Zombies + 1
			self:Save()
			self:SendData()
         end
    end
    if (takedamage:GetComponent( "BearAI" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Bear = datakiller.Bear + 1
	        datakiller.Total = datakiller.Bear + datakiller.Wolf + datakiller.Stag + datakiller.Boar + datakiller.Chicken + datakiller.Rabbit		
			datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)
			local call, req, res = api.Call ( "bushycoin", "add", killer, 5)
			self:Save()
			self:SendData()
         end
    end
    if (takedamage:GetComponent( "WolfAI" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Wolf = datakiller.Wolf + 1
	        datakiller.Total = datakiller.Bear + datakiller.Wolf + datakiller.Stag + datakiller.Boar + datakiller.Chicken + datakiller.Rabbit		
			datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)
			local call, req, res = api.Call ( "bushycoin", "add", killer, 4)
			self:Save()
			self:SendData()
         end
    end
    if (takedamage:GetComponent( "StagAI" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Stag = datakiller.Stag + 1
	        datakiller.Total = datakiller.Bear + datakiller.Wolf + datakiller.Stag + datakiller.Boar + datakiller.Chicken + datakiller.Rabbit		
			datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)		
			local call, req, res = api.Call ( "bushycoin", "add", killer, 3)
			self:Save()
			self:SendData()
         end
    end	
    if (takedamage:GetComponent( "BoarAI" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Boar = datakiller.Boar + 1
	        datakiller.Total = datakiller.Bear + datakiller.Wolf + datakiller.Stag + datakiller.Boar + datakiller.Chicken + datakiller.Rabbit		
			datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)			
			local call, req, res = api.Call ( "bushycoin", "add", killer, 2)
			self:Save()
			self:SendData()
         end
    end
    if (takedamage:GetComponent( "ChickenAI" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Chicken = datakiller.Chicken + 1
	        datakiller.Total = datakiller.Bear + datakiller.Wolf + datakiller.Stag + datakiller.Boar + datakiller.Chicken + datakiller.Rabbit		
			datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)
			local call, req, res = api.Call ( "bushycoin", "add", killer, 1)
			self:Save()
			self:SendData()
         end
    end		
    if (takedamage:GetComponent( "RabbitAI" )) then
        -- Do zombie death code here
         if ((dmg.attacker.client) and (dmg.attacker.client.netUser)) then
	        local killer = dmg.attacker.client.netUser
	        local datakiller = self:GetUserData( killer )
	        datakiller.Rabbit = datakiller.Rabbit + 1
	        datakiller.Total = datakiller.Bear + datakiller.Wolf + datakiller.Stag + datakiller.Boar + datakiller.Chicken + datakiller.Rabbit		
			datakiller.Points = (datakiller.Kills * 10) + (datakiller.Bear * 5)+(datakiller.Wolf * 4)+(datakiller.Stag * 3)+(datakiller.Boar * 2) + (datakiller.Chicken) + (datakiller.Rabbit) - (datakiller.Deaths * 5) - (datakiller.Suicides * 5)
			local call, req, res = api.Call ( "bushycoin", "add", killer, 1)
			self:Save()
			self:SendData()
         end
    end
end

-- *******************************************
-- PLUGIN:Save()
-- Saves the player data to file
-- *******************************************
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Data ) )
	self.DataFile:Save()
end


-- *******************************************
-- PLUGIN:GetUserData()
-- Gets a persistent table associated with the given user
-- *******************************************
function PLUGIN:GetUserData( netuser )
	local userID = rust.GetUserID( netuser )
	return self:GetUserDataFromID( userID, netuser.displayName )
end

-- *******************************************
-- PLUGIN:GetUserDataFromID()
-- Gets a persistent table associated with the given user ID
-- *******************************************
function PLUGIN:GetUserDataFromID( userID, name)
	local userentry = self.Data.Users[ userID ]
	if (not userentry) then
		userentry = {}
		userentry.Name = name
		userentry.Kills = 0
		userentry.Deaths = 0
		userentry.Suicides=0
		userentry.Zombies=0
      	userentry.Wolf=0
       	userentry.Bear=0
       	userentry.Boar=0
	    userentry.Stag=0
	    userentry.Chicken=0
	    userentry.Rabbit=0
		userentry.Total=0	
	    userentry.Points=0		
        userentry.Kdratio=0
		self.Data.Users[ userID ] = userentry
		self:Save()
		self:SendData()
	else 
		if (not userentry.Suicides) then
			userentry.Suicides=0
			self:Save()
			self:SendData()
		end
		if (not userentry.Zombies) then
			userentry.Zombies=0
			self:Save()
			self:SendData()
		end
		if (not userentry.Wolf) then
			userentry.Wolf=0
			self:Save()
			self:SendData()
		end
		if (not userentry.Bear) then
			userentry.Bear=0
			self:Save()
			self:SendData()
		end
		if (not userentry.Boar) then
			userentry.Boar=0
			self:Save()
			self:SendData()
		end	
		if (not userentry.Stag) then
			userentry.Stag=0
			self:Save()
			self:SendData()
		end	
		if (not userentry.Chicken) then
			userentry.Chicken=0
			self:Save()
			self:SendData()
		end				
		if (not userentry.Rabbit) then
			userentry.Rabbit=0
			self:Save()
			self:SendData()
		end
		if (not userentry.Total) then
			userentry.Total=0
			self:Save()
			self:SendData()
		end		
		if (not userentry.Points) then
			userentry.Points=0
			self:Save()
			self:SendData()
		end		
        if (not userentry.Kdratio) then
			userentry.Kdratio=0
			self:Save()
			self:SendData()
		end
	end
	return userentry
end

function PLUGIN:cmdStats( netuser, cmd, args )
    if (not args[1]) then
        self:printStats(netuser)
        return
    end
end

function PLUGIN:printStats(netuser)
    rust.SendChatToUser( netuser, "----------# My Stats #--------")
    
    local playerdata = self:GetUserData( netuser )
    
    rust.SendChatToUser( netuser," Player Kills: " .. tostring(playerdata.Kills))
    rust.SendChatToUser( netuser," Deaths: " .. tostring(playerdata.Deaths))
    rust.SendChatToUser( netuser," Suicides: " .. tostring(playerdata.Suicides))
    rust.SendChatToUser( netuser," Wolves: " .. tostring(playerdata.Wolf))
    rust.SendChatToUser( netuser," Bears: " .. tostring(playerdata.Bear))
    rust.SendChatToUser( netuser," Boars: " .. tostring(playerdata.Boar))
	rust.SendChatToUser( netuser," Stags: " .. tostring(playerdata.Stag))
	rust.SendChatToUser( netuser," Chickens: " .. tostring(playerdata.Chicken))
	rust.SendChatToUser( netuser," Rabbits: " .. tostring(playerdata.Rabbit))
	rust.SendChatToUser( netuser," Total Animals: " .. tostring(playerdata.Total))
	rust.SendChatToUser( netuser," Points: " .. tostring(playerdata.Points))

end

function PLUGIN:cmdRanking( netuser, cmd, args )
    if (not args[1]) then
    		rust.SendChatToUser( netuser, "-------------------------- Player Rankings -------------------------------" )
    	 	rust.SendChatToUser( netuser, "/top points = Top 10 most points")
    	 	rust.SendChatToUser( netuser, "/top hunters = Top 10 hunters")
    		rust.SendChatToUser( netuser, "/top killers = Top 10 player killers")
    	 	rust.SendChatToUser( netuser, "/top deaths = Top 10 most deaths")
            rust.SendChatToUser( netuser, "/top bears = Top 10 bear killers")
            rust.SendChatToUser( netuser, "/top wolves = Top 10 wolf killers")
            rust.SendChatToUser( netuser, "/top stags = Top 10 stag killers")
            rust.SendChatToUser( netuser, "/top boars = Top 10 boar killers")
            rust.SendChatToUser( netuser, "/top chickens = Top 10 chicken killers")
            rust.SendChatToUser( netuser, "/top rabbits = Top 10 rabbit killers")			
    	 	rust.SendChatToUser( netuser, "/top suicides = Top 10 most suicidal")
            rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" ) 
        return
    end
    
    if(args[1] == "killers" or args[1] == "hunters" or args[1] == "points" or args[1] == "deaths" or args[1] == "zombies" or args[1] == "suicides" or args[1] == "bears" or args[1] == "wolves" or args[1] == "stags" or args[1] == "boars" or args[1] == "chickens" or args[1] == "rabbits") then
    		tablerank=self:generateRanking(args[1])
             self:printRanking(netuser,tablerank,args[1])
             return
    end
    
    		rust.SendChatToUser( netuser, "-------------------------- Top 10 Players -------------------------------" )
    		rust.SendChatToUser( netuser, "/top points = Top 10 most points")			
    		rust.SendChatToUser( netuser, "/top hunters = Top 10 hunters")			
    		rust.SendChatToUser( netuser, "/top killers = Top 10 player killers")
    	 	rust.SendChatToUser( netuser, "/top deaths = Top 10 most deaths")
    	 	rust.SendChatToUser( netuser, "/top suicides = Top 10 most suicidal")
            rust.SendChatToUser( netuser, "/top bears = Top 10 bear killers")
            rust.SendChatToUser( netuser, "/top wolves = Top 10 wolf killers")
            rust.SendChatToUser( netuser, "/top stags = Top 10 stag killers")
            rust.SendChatToUser( netuser, "/top boars = Top 10 boar killers")
            rust.SendChatToUser( netuser, "/top chickens = Top 10 chicken killers")
            rust.SendChatToUser( netuser, "/top rabbits = Top 10 rabbit killers")			
            rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" ) 
    
end

function PLUGIN:cmdShelp( netuser, cmd, args )
    rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" )
    rust.SendChatToUser( netuser, "------------------------- Player Stats  ----------------------------" )
    rust.SendChatToUser( netuser, "Use /mystats to see your stats and /top to see the top 10" )
    rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" )
end

function PLUGIN:generateRanking(var)

    local allusers = self.Data.Users
    local currentTop={}
    local table = {}
    
    for k,v in pairs(allusers) do
        if(var=="killers") then
            table[k]=v.Kills
        elseif(var=="hunters") then
            table[k]=v.Total			
        elseif(var=="points") then
            table[k]=v.Points			
        elseif(var=="deaths") then
            table[k]=v.Deaths
        elseif(var=="suicides")then
            table[k]=v.Suicides
        elseif(var=="bears")then
            table[k]=v.Bear
        elseif(var=="wolves")then
            table[k]=v.Wolf
		elseif(var=="stags")then
            table[k]=v.Stag
        elseif(var=="boars")then
            table[k]=v.Boar
        elseif(var=="chickens")then
            table[k]=v.Chicken
        elseif(var=="rabbits")then
            table[k]=v.Rabbit
         end
   end
   
   return table
end

function PLUGIN:printRanking(netuser,killertable,var)

    rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" )
    rust.SendChatToUser( netuser, "Top 10 ".. var .. ":")
    rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" )
    
    local count = 1
    local limit = 10
    
    for k,v in spairs(killertable, function(t,a,b) return t[b] < t[a] end) do
         user=self.Data.Users[k]
         
        if(var=="killers") then
            variable=user.Kills
        elseif(var=="hunters") then
            variable=user.Total			
        elseif(var=="points") then
            variable=user.Points			
        elseif(var=="deaths") then
            variable=user.Deaths
        elseif(var=="bears")then
            variable=user.Bear
        elseif(var=="wolves")then
            variable=user.Wolf
        elseif(var=="stags")then
            variable=user.Stag
        elseif(var=="boars")then
            variable=user.Boar
        elseif(var=="chickens")then
            variable=user.Chicken
        elseif(var=="rabbits")then
            variable=user.Rabbit									
		elseif(var=="suicides")then
            variable=user.Suicides
        end

   	   rust.SendChatToUser( netuser, count.. ".   " .. user.Name .. " :   " .. variable)
   	   
   	   if(count >= limit) then
   	       rust.SendChatToUser( netuser, "--------------------------------------------------------------------------------" )
   	   	return
   	   end
   	   count = count +1
    end
    

end


--GENERIC ORDERED PAIRS ITERATOR FROM STACK OVERFLOW 
--http://stackoverflow.com/questions/15706270/sort-a-table-in-lua
function spairs(t, order)
    -- collect the keys
    local keys = {}
    for k in pairs(t) do keys[#keys+1] = k end

    -- if order function given, sort by it by passing the table and keys a, b,
    -- otherwise just sort the keys 
    if order then
        table.sort(keys, function(a,b) return order(t, a, b) end)
    else
        table.sort(keys)
    end

    -- return the iterator function
    local i = 0
    return function()
        i = i + 1
        if keys[i] then
            return keys[i], t[keys[i]]
        end
    end
end

function PLUGIN:SendHelpText( netuser )
	rust.SendChatToUser( netuser, "Use /mystats to list your statistics." )
	rust.SendChatToUser( netuser, "Use /top to list top players." )
end

function PLUGIN:SendData()
	local url = self.Config.url
	local globalurl = self.Config.globalurl
	local data = 'statsdata='..json.encode(self.Data)
	local r = webrequest.Post(url, data, function(code, response)
        -- Debug message
        if(debug == true) then
            print("-------------------------------------------------------")
            print(self.Title..": DEBUG - code: "..tostring(code))
            print(self.Title..": DEBUG - response: "..tostring(response))
        end
        -- Check HTTP-Statuscodes
        if(code == 404) then
            print(self.Title..": ERROR - Webreqquest failed. Script not found, check url")
            return
        elseif(code == 503) then
            print(self.Title..": ERROR - Webrequest failed. Webserver unavailable")
            return
        elseif(code == 200) then
            -- Debug message
            if(debug == true) then
                print(self.Title..": DEBUG - webrequest: Sent successful (code 200)")
            end
        else
            print(self.Title..": ERROR - Webrequest failed. Error code: "..tostring(code))
            return
		end
	end)
	if(not r) then
        print(self.Title..": ERROR - Webrequest failed. Unknown error")
        return
    end
    if(debug == true) then
        print(self.Title..": DEBUG - r: "..tostring(r))
    end
end


function PLUGIN:GetUserDataFromName(name)
    for key,value in pairs(self.Data) do
        if (value.Name == name) then
            return value
        end
    end
    return nil
end