/*@name GatherPlus
@author Henrique Seifarth Lovato
@Server BRRUST
@Date 18/03/2014
@Version 1.1
@From Brazil
*/

function On_PlayerGathering(Player, GatherEvent) {
    var mult = parseInt(Data.GetConfigValue("GatherPlus", "config", "resourcemultplier"));
    Player.Inventory.AddItem(GatherEvent.Item, Math.floor(GatherEvent.Quantity * (mult-1)));
    Player.InventoryNotice(GatherEvent.Quantity * (mult - 1) + " x " + GatherEvent.Item);
}