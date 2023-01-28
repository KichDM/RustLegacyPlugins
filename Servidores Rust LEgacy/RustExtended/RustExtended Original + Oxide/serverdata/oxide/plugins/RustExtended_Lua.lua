PLUGIN.Title = "RustExtended (LUA) Example"
PLUGIN.Version = V(1, 0, 0)
PLUGIN.Description = "Shows information about RustExtended from Oxide2."
PLUGIN.Author = "Breaker"
PLUGIN.Url = "http://rust-extended/"
PLUGIN.ResourceId = 0

local function Log(message)
    local array = util.TableToArray({ message })
    UnityEngine.Debug.Log.methodarray[0]:Invoke(nil, array)
end

local function LogWarning(message)
    local array = util.TableToArray({ message })
    UnityEngine.Debug.LogWarning.methodarray[0]:Invoke(nil, array)
end

local function LogError(message)
    local array = util.TableToArray({ message })
    UnityEngine.Debug.LogError.methodarray[0]:Invoke(nil, array)
end

function PLUGIN:Init()
	Log("[Demo Plugin] RustExtended Version: "..RustExtended.Core.Version:ToString().." ("..RustExtended.Core.VersionName..")")

	local languages = ""
	for i = 0, RustExtended.Core.Languages.Length - 1 do
		languages = languages .. ", " .. RustExtended.Core.Languages[i]	
	end
	Log("[Demo Plugin] RustExtended Languages: " .. string.gsub(languages, "^, ", ""))
end
