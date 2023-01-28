var fix = [
    ["Campfire", "Camp Fire"],
    ["Wood_Shelter", "Wood Shelter"], ["Barricade_Fence_Deployable", "Wood Barricade"],
    ["Wood Spike Wall", "Spike Wall"], ["Large Wood Spike Wall", "Large Spike Wall"],
    ["Wood Box", "Wood Storage Box"],["Wood Box Large", "Large Wood Storage"],

    ["Wood Door Frame", "Wood Doorway"], ["Metal Door Frame", "Metal Doorway"],
    ["Wood Window Frame", "Wood Window"], ["Metal Window Frame", "Metal Window"],
    ["Metal Bars Window", "Metal Window Bars"],
];


function On_EntityHurt(Hurt) {
    if(Hurt.Attacker != null && Hurt.Entity != null)
        if(Hurt.Attacker.PlayerClient.netUser.userID == Hurt.Entity.OwnerID)
            if(GetMode(Hurt.Attacker)) {
                var destItem = StringFix(Hurt.Entity.Name);
                if(destItem != "Metal Window Bars" && IsEligible(Hurt) == true) {
                    Hurt.Entity.Destroy();
                    Hurt.Attacker.Inventory.AddItem(destItem, 1);
                    Rust.Notice.Inventory(Hurt.Attacker.PlayerClient.netPlayer, "1 x " + destItem);
                }
            }
}

function On_Command(Player, cmd, args) {
    switch(cmd) {
        case "re":
            Data.AddTableValue("destroy_mode", Player.SteamID, !GetMode(Player));
            Player.Message("Destroy Mode has been " + (GetMode(Player) ? "enabled." : "disabled."));
    }
}

function GetMode(Player) {
    var destroy = Data.GetTableValue("destroy_mode", Player.SteamID);
    return (destroy ==  null ? false : destroy);
}

function StringFix(str) {
    str = str.replace(/([a-z])([A-Z])/g, '$1 $2');
    for(var i=1; i < fix.length; i++)
        if(str==fix[0])
            return fix[1];

    return str;
}

function IsEligible(HurtEvent){
    try{
        var Eligible = HurtEvent.Entity.Object._master.ComponentCarryingWeight(HurtEvent.Entity.Object);
        return !Eligible;
    }
    catch(err){
        return true;
    }
}