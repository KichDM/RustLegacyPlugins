PLUGIN.Title = "Boost your FPS"
PLUGIN.Version = V(1, 0, 0)
PLUGIN.Description = "Plugin to boost FPS"
PLUGIN.Author = "PreFiX"

function PLUGIN:Init()
	command.AddChatCommand("fps", self.Plugin, "cmdFPS")
end

function PLUGIN:cmdFPS(player, command, arg)

		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"grass.on false")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"grass.forceredraw False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"grass.displacement True")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"grass.disp_trail_seconds 0")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"grass.shadowcast False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"grass.shadowreceive False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"render.level 0")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"render.vsync False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"footsteps.quality 2")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"gfx.ssaa False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"gfx.bloom False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"gfx.grain False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"gfx.ssao False")
		global.ConsoleNetworker.SendClientCommand(player.networkPlayer,"gfx.tonemap False")
		rust.SendChatMessage( player, "Your FPS \"boosted\"")
		
		
	
end