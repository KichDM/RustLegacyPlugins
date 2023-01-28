//* By KichDM
//*TODO Para NovaLand Zero

var blue = "[color #0099FF]";
var red = "[color #FF0000]";
var green = "[color #009900]";
var yellow = "[color #F4FA58]";
var orange = "[color #FF8000]";

function On_Command(Player, cmd, args)

{
cmd = Data.ToLower(cmd);
if(cmd=="fps") { 
Player.MessageFrom("Novaland Zero", red + "----------------------------FPS++ Novaland Zero--------------------------------")
Player.MessageFrom("Novaland Zero", yellow+ "Usa /fps+ para subir los FPS al max");
Player.MessageFrom("Novaland Zero", orange+ "Usa /fps- para subir la calidad del juego al max");
Player.MessageFrom("Novaland Zero", red + "----------------------------FPS++ Novaland Zero--------------------------------")
}

if(cmd=="fps+") {
Player.SendCommand("grass.on false");
Player.SendCommand("grass.forceredraw False");
Player.SendCommand("grass.displacement True");
Player.SendCommand("grass.disp_trail_seconds 0");
Player.SendCommand("grass.shadowcast False");
Player.SendCommand("grass.shadowreceive False");
Player.SendCommand("render.level 0");
Player.SendCommand("render.vsync False");
Player.SendCommand("footsteps.quality 2");
Player.SendCommand("gfx.ssaa False");
Player.SendCommand("gfx.bloom False");
Player.SendCommand("gfx.grain False");
Player.SendCommand("gfx.ssao False");
Player.SendCommand("gfx.shafts false");
Player.SendCommand("gfx.damage false");
Player.SendCommand("gfx.tonemap False");
Player.SendCommand("config.save");
Player.MessageFrom("Novaland Zero", red + "----------------------------FPS++ Novaland Zero--------------------------------")
Player.MessageFrom("Novaland Zero", green+ "Máximos FPS");
Player.MessageFrom("Novaland Zero", red + "----------------------------FPS++ Novaland Zero--------------------------------")

}
if(cmd=="fpsoff") {
Player.SendCommand("grass.on true");
Player.SendCommand("grass.forceredraw true");
Player.SendCommand("grass.displacement false");
Player.SendCommand("grass.disp_trail_seconds 10");
Player.SendCommand("grass.shadowcast true");
Player.SendCommand("grass.shadowreceive true");
Player.SendCommand("render.level 1");
Player.SendCommand("render.vsync true");
Player.SendCommand("footsteps.quality 2");
Player.SendCommand("gfx.ssaa true");
Player.SendCommand("gfx.bloom true");
Player.SendCommand("gfx.grain true");
Player.SendCommand("gfx.ssao true");
Player.SendCommand("gfx.shafts true");
Player.SendCommand("gfx.damage true");
Player.SendCommand("gfx.tonemap true");
Player.SendCommand("config.save");
Player.MessageFrom("Novaland Zero", red + "----------------------------FPS++ Novaland Zero--------------------------------")
Player.MessageFrom("Novaland Zero",green+"Mejores gráficos!");
Player.MessageFrom("Novaland Zero", red + "----------------------------FPS++ Novaland Zero--------------------------------")
}
}
