/*
*Colour Variable List
*By xKieron
*Do not take this author section out
*1.0
*/

// Global Colour Values/Variables For Chat //
var black = "[color#000000]"
var gray = "[color#424242]"
var lightgray = "[color#D8D8D8]"
var white = "[color#FFFFFF]"
var pink = "[color#F781F3]"
var purple = "[color#6A0888]"
var red = "[color#FF0000]"
var blue = "[color#001EFF]"
var green = "[color#00FF40]"
var cyan = "[color#00FFF7]"
var yellow = "[color#FCFF02]"
var orange = "[color#CD8C00]"
var brown = "[color#604200]"
var turqoise = "[color#00FFC0]"

// to add these to your script, do something like this. //

function On_Command(Player, cmd, args){
	switch(cmd){
        case "colours":
            Player.MessageFrom("Colours", yellow+"This is an example Yellow Colour Text!");
            Player.MessageFrom("Colours", cyan+"Or maybe a cyan example! COOL!");
			
	}
}