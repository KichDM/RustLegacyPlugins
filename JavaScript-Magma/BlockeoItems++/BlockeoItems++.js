//* By KichDM
//*TODO Para NovaLand Zero

function On_EntityDeployed(Player, Entity) {
        if (Entity.Name == "SmallStash") {
            Entity.Destroy();
            Player.Inventory.AddItem("Small Stash");
            Player.InventoryNotice("+1 Small Stash");
            Player.MessageFrom("Novaland Zero", "[color#00FFFF]No estan permitidas en el server!!");
        }
}
    