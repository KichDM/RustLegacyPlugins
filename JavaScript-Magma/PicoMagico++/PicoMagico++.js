//* By KichDM
//*TODO Para NovaLand Zero

function On_PlayerGathering (Player, GatherEvent)
{
    if (Player.Inventory.HasItem("Pick Axe"))
    var MULTIPLICADOR = (GatherEvent.Quantity*(1));
    MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
    {
        switch (GatherEvent.Item)
        {
            case "Sulfur Ore":
            Player.Inventory.AddItem("Sulfur",MULTIPLICADOR);
            Player.InventoryNotice("Sulfur" + " x " + MULTIPLICADOR);
            break;
            case "Metal Ore":
            Player.Inventory.AddItem("Metal Fragments",MULTIPLICADOR);
            Player.InventoryNotice("Metal Fragments" + " x " + MULTIPLICADOR);
            break;
        }
    }
}