using System;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("FpsBooster", "PINK", "0.1.0")]
    class FpsBooster : RustLegacyPlugin
    {
		string chatPrefix = "✯NovaLand✯";

        void OnPlayerConnected(NetUser netuser)
        {
            
                
                rust.RunClientCommand(netuser, "gfx.ssaa False");
               
           
        }

        [ChatCommand("fps")]
        void cmdFps(NetUser netuser, string command, string[] args)
        {
           
                rust.RunClientCommand(netuser, "grass.on False");
                rust.RunClientCommand(netuser, "grass.forceredraw False");
                rust.RunClientCommand(netuser, "grass.displacement True");
                rust.RunClientCommand(netuser, "grass.disp_trail_seconds 0");
                rust.RunClientCommand(netuser, "grass.shadowcast False");
                rust.RunClientCommand(netuser, "grass.shadowreceive False");
                rust.RunClientCommand(netuser, "render.level 0");
                rust.RunClientCommand(netuser, "render.vsync False");
                rust.RunClientCommand(netuser, "footsteps.quality 2");
                rust.RunClientCommand(netuser, "gfx.ssaa False");
                rust.RunClientCommand(netuser, "gfx.bloom False");
                rust.RunClientCommand(netuser, "gfx.grain False");
                rust.RunClientCommand(netuser, "gfx.ssao False");
                rust.RunClientCommand(netuser, "gfx.tonemap False");
                rust.SendChatMessage(netuser, chatPrefix, "[color orange]Seus graficos foram reduzidos com sucesso.");


        }

        [ChatCommand("fps-")]
        void cmdFpsmenos(NetUser netuser, string command, string[] args)
        {
           
                rust.RunClientCommand(netuser, "grass.on False");
                rust.RunClientCommand(netuser, "grass.forceredraw True");
                rust.RunClientCommand(netuser, "grass.displacement True");
                rust.RunClientCommand(netuser, "grass.disp_trail_seconds 0");
                rust.RunClientCommand(netuser, "grass.shadowcast True");
                rust.RunClientCommand(netuser, "grass.shadowreceive True");
                rust.RunClientCommand(netuser, "render.level 10");
                rust.RunClientCommand(netuser, "render.vsync False");
                rust.RunClientCommand(netuser, "footsteps.quality 5");
                rust.RunClientCommand(netuser, "gfx.ssaa false");
                rust.RunClientCommand(netuser, "gfx.bloom True");
                rust.RunClientCommand(netuser, "gfx.grain True");
                rust.RunClientCommand(netuser, "gfx.ssao True");
                rust.RunClientCommand(netuser, "gfx.tonemap True");
                rust.SendChatMessage(netuser, chatPrefix, "[color orange]Seus graficos foram elevados com sucesso.");
            
        }
    }
}