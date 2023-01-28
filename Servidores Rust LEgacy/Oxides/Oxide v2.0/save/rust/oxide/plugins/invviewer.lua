PLUGIN.Title = "Inventory Viewer"
PLUGIN.Description = "Look into somebody's inventory"
PLUGIN.Version = "1.1.0"
PLUGIN.Author = "CareX"

function PLUGIN:Init()

    print( self.Title .. " V" .. self.Version .. " is now loading..." )
    if( api.Exists( "flags" )) then flags_plugin = plugins.Find( "flags" ) self.flags = true print("[Inv Viewer] uses Flags!" ) end
    -- Gets/Creates Data File
    self.DataFile = util.GetDatafile( "IV - Data" )
    local data = self.DataFile:GetText()

    if ( data ~= "" ) then
        self.Data = json.decode( data )
        print( "[ Inv Viewer ] Data file loaded" )
    else
        print( "[ Inv Viewer ] Creating new data File..." )
        self.Data= {}
        self.Data[ "ivflags" ] = {}
        self.Data.ivflags["viewinv"] = "iv"
        self.Data.ivflags["addinv"] = "iv"
        self.Data.ivflags["removeinv"] = "iv"
        self.Data.ivflags["clearinv"] = "iv"
        self.Data.ivflags["searchinv"] = "iv"
        self.Data.ivflags["abi"] = "iv"
        self.Data.ivflags["rbi"] = "iv"
        self.Data.ivflags["ivhelp"] = "iv"
        self.Data.ivflags["delinv"] = "iv"
        self.Data[ "Banned" ] = {}
        self.Data[ "UID" ] = 1
        self.Data[ "temp" ] = {}
        self.Data[ "temptime" ] = 60
        self.Data[ "notify" ] = {}
        self.Data[ "notify" ] = {}
        self.Data.notify[ "banned" ] = true
        self.Data.notify[ "add" ] = true
        self.Data.notify[ "remove" ] = true
        self.Data.notify[ "clear" ] = true
        self:Save()
    end

    if( self.flags ) then
        flags_plugin:AddFlagsChatCommand( self, "viewinv", {self.Data.ivflags.viewinv}, self.cmdViewInv )
        flags_plugin:AddFlagsChatCommand( self, "addinv", {self.Data.ivflags.addinv}, self.cmdAddInv )
        flags_plugin:AddFlagsChatCommand( self, "removeinv", {self.Data.ivflags.removeinv}, self.RemoveInv )
        flags_plugin:AddFlagsChatCommand( self, "clearinv", {self.Data.ivflags.clearinv}, self.ClearInv )
        flags_plugin:AddFlagsChatCommand( self, "searchinv", {self.Data.ivflags.searchinv}, self.cmdSearchInv )
        flags_plugin:AddFlagsChatCommand( self, "abi", {self.Data.ivflags.abi}, self.cmdAddBannedItem )
        flags_plugin:AddFlagsChatCommand( self, "rbi", {self.Data.ivflags.rbi}, self.cmdRemoveBannedItem )
        flags_plugin:AddFlagsChatCommand( self, "delinv", {self.Data.ivflags.delinv}, self.cmdDelInv )
        print( "[ Inventory Viewer ] Flags chat commands loaded" )
    else
        self:AddChatCommand( "viewinv" , self.cmdViewInv )
        self:AddChatCommand( "addinv" , self.cmdAddInv )
        self:AddChatCommand( "removeinv" , self.RemoveInv )
        self:AddChatCommand( "clearinv" , self.ClearInv )
        self:AddChatCommand( "searchinv" , self.cmdSearchInv )
        self:AddChatCommand( "abi" , self.cmdAddBannedItem )
        self:AddChatCommand( "rbi" , self.cmdRemoveBannedItem )
        self:AddChatCommand( "delinv" , self.cmdDelInv )
        print( "[ Inventory Viewer ] Normal chat commands loaded" )
    end

    self:AddChatCommand( "ivhelp" , self.cmdHelp )
    self:AddChatCommand( "bi" , self.cmdBannedItem )
    print( self.Title .. " V" .. self.Version .. " is loaded." )


    --- TEMP UPDATE!
    if( not (self.Data["notify"] )) then
        self.Data["notify"] = {}
        self.Data.notify["banned"] = true
        self.Data.notify["add"] = true
        self.Data.notify["remove"] = true
        self.Data.notify["clear"] = true
        self:Save()
        print( "[ Inventory Viewer ] Updated for the 1.1.1 Patch!" )
    end


end

function PLUGIN:SendHelpText(netuser)
        rust.SendChatToUser(netuser, "Use /ivhelp to list all the Inventory Viewer commands!")
end

function PLUGIN:cmdHelp( netuser, cmd, args )
    if( ( netuser:CanAdmin() ) or ( flags_plugin and flags_plugin:HasFlag(rust.GetUserID(netuser), self.Data.ivflags.ivhelp ))) then
        rust.SendChatToUser( netuser, "/viewinv \"player name\" to view someone's inventory.")
        rust.SendChatToUser( netuser, "/addinv \"player name\" \"item\" [amount] to ad an item to someone's inventory.")
        rust.SendChatToUser( netuser, "/removeinv  \"player name\" \"item\" [amount]  to remove an item from someone's inventory.")
        rust.SendChatToUser( netuser, "/clearinv \"player name\" to clear someone's inventory.")
        rust.SendChatToUser( netuser, "/searchinv \"player name\" to search someone for banned items.")
        rust.SendChatToUser( netuser, "/abi \"itemname\" to add an item to the banned list.")
        rust.SendChatToUser( netuser, "/rbi \"itemname\" to remove an item to the banned list.")
        rust.SendChatToUser( netuser, "/delinv [UID] to remove banned items from a player.")
    end
        rust.SendChatToUser( netuser, "/bi to get a list of banned items")
end

-- Single line functions
function table.containsval(t,cv) for _, v in ipairs(t) do  if v == cv then return true  end  end return nil end -- return true if value is in said table.
function table.getKey(t, cv) for k, v in ipairs(t) do if v == cv then return k end end return nil end -- Gets key for a certain table
function PLUGIN:getUID() local uid = self.Data.UID self.Data.UID = self.Data.UID + 1 return tostring( uid ) end -- Returns an unique ID
function PLUGIN:cmdBannedItem(netuser,cmd,args) self:ListBannedItems(netuser) end -- Lists all banned items
local unstackable = {"M4", "9mm Pistol", "Shotgun", "P250", "MP5A4","Pipe Shotgun","Bolt Action Rifle"  , "Revolver", "HandCannon", "Research Kit 1" }

function PLUGIN:cmdRemoveBannedItem( netuser, cmd, args)
    if( args[1] ) then
        local item = tostring(args[1])
        local datablock = rust.GetDatablockByName(item)
        if (not datablock) then  rust.Notice(netuser, "No such item!") return end
         local id = table.getKey( self.Data.Banned, item)
         if( not( id )) then self.Notice( netuser, util.QuoteSafe( item ) .. " is not in banned list!") return end
         table.remove( self.Data.Banned, id )
         rust.SendChatToUser( netuser, item .. " is now removed from the banned list!")
         self:Save()
    else
        self:ListBannedItem( netuser )
    end
end

function PLUGIN:cmdAddBannedItem( netuser, cmd, args )
    if( args[1] ) then
        local item = tostring(args[1])
        local datablock = rust.GetDatablockByName(item)
        if (not datablock) then  rust.Notice(netuser, "No such item!") return end
        local Banned = table.containsval(self.Data.Banned ,tostring( item ))
        if( Banned ) then self.Notice( netuser, util.QuoteSafe( item ) .. " is already in banned list!") return end
        if( not self.Data.Banned[ tostring( item ) ] ) then
            table.insert( self.Data.Banned, item)
            rust.SendChatToUser( netuser, item .. " is now on the banned list!")
            self:Save()
        end
    else
        self:ListBannedItem( netuser )
    end
end

function PLUGIN:ListBannedItems( netuser )
    local count = #self.Data.Banned
    if( count >= 1 ) then
        for _, v in ipairs( self.Data.Banned ) do
            rust.SendChatToUser( netuser, "Banned", tostring( v ))
        end
    else
        rust.SendChatToUser( netuser, "There are currently no items in the banned list." )
    end
end

function PLUGIN:cmdSearchInv( netuser, cmd, args )
    if( (not self.flags) and ( not( netuser:CanAdmin() ))) then rust.Notice( netuser, "You are not an admin!" ) return end
    if( args[1] ) then
        local b, TargUser = rust.FindNetUsersByName( tostring( args[ 1 ] ))
        if( not b ) then  rust.Notice( netuser, "Invalid name" ) return end
        local inv = rust.GetInventory( TargUser )
        local i = 0
        local invtbl = {}
        invtbl[ "items" ] = {}
        local cnt = false
        while( i <= 39 )do
            local b, item = inv:GetItem( i )
            if (b) then

                local s = tostring( item )
                local x = string.find(s, "%(on", 2) -2
                local itemname = string.sub(s, 2, x)
                local isUnstackable = table.containsval( unstackable, itemname )
                local amount = 1
                if( not isUnstackable ) then
                    amount = item.uses
                end
                local Banned = table.containsval(self.Data.Banned ,tostring( itemname ))
                if( Banned ) then
                    if ( invtbl.items[ itemname ] ) then
                     invtbl.items[ itemname ] = invtbl.items[ itemname ] + amount
                    else
                        invtbl.items[ itemname ] = amount
                        cnt = true
                    end
                end
            end
            i = i + 1
        end
        if( not ( cnt )) then rust.SendChatToUser(netuser, TargUser.displayName .. " does not have any banned items on him.") return end
        invtbl[ "TargUser" ] = TargUser.displayName
        rust.SendChatToUser(netuser, "Banned items found:")
        for k,v in pairs(invtbl.items) do
            rust.SendChatToUser(netuser, TargUser.displayName , tostring( v ) .. "x " .. util.QuoteSafe( k ))
        end
        local UID = self:getUID()
        self.Data.temp[ UID ] = invtbl
        self:Save()
        local temptime = self.Data.temptime
        rust.SendChatToUser( netuser, "To delete the banned items from this person, type: /delinv " .. tostring( UID ) .. " within " .. tostring( temptime ) .. " seconds." )
        timer.Once( temptime, function()
            self.Data.temp[ UID ] = nil
            rust.SendChatToUser( netuser,"Inv Viewer", "temp inventory ID: " .. UID ..  " has been deleted!" )
            self:Save()
        end)
    else
        rust.SendChatToUser( netuser, "/searchinv \"player name\" to search for banned items in someone's inventory")
    end
end

function PLUGIN:cmdDelInv( netuser, cmd, args )
    if( args[1] ) then
        local UID = tostring(args[1])
        if( self.Data.temp[ UID ] ) then
            local deltbl = self.Data.temp[ UID ]
            local b, TargUser = rust.FindNetUsersByName( tostring( deltbl.TargUser ))
            if( not b ) then  rust.Notice( netuser, "Invalid name" ) return end
            local inv = rust.GetInventory( TargUser )
            if( not inv ) then rust.Notice( netuser, "Inventory not found!" ) return end
            local count = 0
            for k, v in pairs( deltbl.items ) do
                local itemname = tostring(tostring( k ))
                local datablock = rust.GetDatablockByName(itemname)
                if (not datablock) then  rust.Notice(netuser, "No such item!") return end
                local amount = math.ceil(tonumber( v ))
                if( amount < 1 ) then rust.Notice( netuser, "Invalid Amount" ) return end
                local inv = rust.GetInventory( TargUser )
                if( not inv ) then rust.Notice( netuser, "Inventory not found!" ) return end
                local isUnstackable = table.containsval(unstackable,itemname)
                local i = 0
                local status,item = pcall(function() return inv:FindItem(datablock) end)
                if not status then rust.Notice( netuser,"Inventory not ready. Please try again or reconnect") return end
                if (item) then
                    if (not isUnstackable) then
                        while (i < amount) do
                            if (item.uses > 0) then
                                item:SetUses(item.uses - 1)
                                i = i + 1
                                count = count + 1
                            else
                                inv:RemoveItem(item)
                                item = inv:FindItem(datablock)
                                if (not item) then
                                    break
                                end
                            end
                        end
                    else
                        while (i < amount) do
                            inv:RemoveItem(item)
                            i = i + 1
                            count = count + 1
                            item = inv:FindItem(datablock)
                            if (not item) then
                                break
                            end
                        end
                    end
                else rust.Notice( netuser, "Item not found in inventory!") end
                if ((not isUnstackable) and (item) and (item.uses <= 0)) then
                    inv:RemoveItem(item)
                end
                rust.SendChatToUser( netuser, "Removed banned item from: " .. TargUser.displayName .. " || " .. tostring(i) .. "x " .. util.QuoteSafe( itemname ))

                if( self.Data.notify.banned ) then
                    rust.SendChatToUser( TargUser, netuser.displayName .. " has removed banned item: " .. tostring(i) .. "x " .. util.QuoteSafe( itemname ))
                end
            end
            rust.SendChatToUser( netuser, "A total of: " .. tostring( count ) .. " banned items are deleted" )
        else
            rust.SendChatToUser( netuser,"Temporary inventory table not found! || ID: " .. UID )
        end
    else
        rust.SendChatToUser( netuser, "/delinv UID to remove banned items from a player.")
    end
end

function PLUGIN:cmdViewInv( netuser, cmd, args )
    if( (not self.flags) and ( not( netuser:CanAdmin() ))) then rust.Notice( netuser, "You are not an admin!" ) return end
    if( args[1] ) then
        local b, TargUser = rust.FindNetUsersByName( tostring( args[ 1 ] ))
        if( not b ) then  rust.Notice( netuser, "Invalid name" ) return end
        local inv = rust.GetInventory( TargUser )
        local i = 0
        local viewtbl = {}
        while( i <= 39 )do
            local b, item = inv:GetItem( i )
            if (b) then
                local s = tostring( item )
                local x = string.find(s, "%(on", 2) -2
                local itemname = string.sub(s, 2, x)
                local isUnstackable = table.containsval( unstackable, itemname )
                local amount = 1
                if( not isUnstackable ) then
                    amount = item.uses
                end
                if ( viewtbl[ itemname ] ) then
                    viewtbl[ itemname ] = viewtbl[ itemname ] + amount
                else
                    viewtbl[ itemname ] = amount
                end
            end
            i = i + 1
        end
        print( tostring( viewtbl ) )
        rust.SendChatToUser(netuser, "Items found:")
        for k,v in pairs( viewtbl ) do
            rust.SendChatToUser(netuser, TargUser.displayName , tostring( v ) .. "x " .. util.QuoteSafe( k ))
        end
    else
        rust.SendChatToUser( netuser, "/viewinv \"player name\" to view someone's inventory")
    end
end

-- /addinv "player name" "item name" "amount"
function PLUGIN:cmdAddInv( netuser, cmd, args )
    if( (not self.flags) and ( not( netuser:CanAdmin() ))) then rust.Notice( netuser, "You are not an admin!" ) return end
    if( args[1] and (args[2]) and (args[3])) then
        local b, TargUser = rust.FindNetUsersByName( tostring( args[1] ))
        if( not b ) then  rust.Notice( netuser, "Invalid name" ) return end
        local item = tostring(args[2])
        local datablock = rust.GetDatablockByName(item)
        if (not datablock) then  rust.Notice(netuser, "No such item!") return end
        local amount = math.ceil(tonumber( args[3] ))
        if( amount < 1 ) then rust.Notice( netuser, "Invalid Amount" ) return end
        local inv = rust.GetInventory( TargUser )
        inv:AddItemAmount( datablock, amount )
        rust.SendChatToUser(netuser, "Gave " .. TargUser.displayName .. " " .. tostring(amount) .. "x " .. util.QuoteSafe( item ))
        if( self.Data.notify.add ) then
            rust.SendChatToUser(TargUser, "Received from " .. netuser.displayName .. ": " .. tostring(amount) .. "x " .. util.QuoteSafe( item ))
        end
    else
        rust.SendChatToUser( netuser, "/addinv \"player name\" \"item\" [amount] to ad an item to someone's inventory")
    end
end

function PLUGIN:RemoveInv( netuser, cmd, args )
    if( (not self.flags) and ( not( netuser:CanAdmin() ))) then rust.Notice( netuser, "You are not an admin!" ) return end
    if( args[1] and (args[2]) and (args[3])) then
        local b, TargUser = rust.FindNetUsersByName( tostring( args[1] ))
        if( not b ) then  rust.Notice( netuser, "Invalid name" ) return end
        local itemname = tostring(args[2])
        local datablock = rust.GetDatablockByName(itemname)
        if (not datablock) then  rust.Notice(netuser, "No such item!") return end
        local amount = math.ceil(tonumber( args[3] ))
        if( amount < 1 ) then rust.Notice( netuser, "Invalid Amount" ) return end
        local inv = rust.GetInventory( TargUser )
        local isUnstackable = table.containsval(unstackable,itemname)
        local i = 0
        local status,item = pcall(function() return inv:FindItem(datablock) end)
        if not status then   rust.Notice( netuser,"Inventory not ready. Please try again or reconnect") return end
        if (item) then
            if (not isUnstackable) then
                while (i < amount) do
                    if (item.uses > 0) then
                        item:SetUses(item.uses - 1)
                        i = i + 1
                    else
                        inv:RemoveItem(item)
                        item = inv:FindItem(datablock)
                        if (not item) then
                            break
                        end
                    end
                end
            else
                while (i < amount) do
                    inv:RemoveItem(item)
                    i = i + 1
                    item = inv:FindItem(datablock)
                    if (not item) then
                        break
                    end
                end
            end
        else rust.Notice( netuser, "Item not found in inventory!") end
        if ((not isUnstackable) and (item) and (item.uses <= 0)) then
            inv:RemoveItem(item)
        end
        rust.SendChatToUser( netuser, "Removed from: " .. TargUser.displayName .. " || " .. tostring(i) .. "x " .. util.QuoteSafe( itemname ))
        if( self.Data.notify.remove ) then
            rust.SendChatToUser( TargUser, netuser.displayName .. " has removed: " .. tostring(i) .. "x " .. util.QuoteSafe( itemname ))
        end
    else
        rust.SendChatToUser( netuser, "/removeinv  \"player name\" \"item\" [amount]  to remove an item from someone's inventory")
    end
end

function PLUGIN:ClearInv( netuser, cmd, args ) -- Done
    if( (not self.flags) and ( not( netuser:CanAdmin() ))) then rust.Notice( netuser, "You are not an admin!" ) return end
    if( args[1] ) then
        local b, TargUser = rust.FindNetUsersByName( tostring( args[ 1 ] ))
        if( not b ) then  rust.Notice( netuser, "Invalid name" ) return end
        local inv = rust.GetInventory( TargUser )
        inv:Clear()
        if( self.Data.notify.clear ) then
            rust.SendChatToUser( TargUser, netuser.displayName .. " has cleared your inventory." )
        end
    else
        rust.SendChatToUser( netuser, "/clearinv \"player name\" to clear someone's inventory")
    end
end

function PLUGIN:Save()
    self.DataFile:SetText( json.encode( self.Data, { indent = true } ) )
    self.DataFile:Save()
end