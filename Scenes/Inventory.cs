using Godot;
using System.Collections.Generic;

public partial class Inventory : Node
{
    private Dictionary<string, int> inventory = new();

    public override void _Ready()
    {
        inventory["Health Potion"] = 5;
        inventory["Mana Potion"] = 3;
        inventory["Ammo Pack"] = 20;

        GD.Print("Health Potion: ", inventory["Health Potion"]);
        foreach (var pair in inventory)
        {
            GD.Print(pair.Key, " -> ", pair.Value);
        }

        if (inventory.TryGetValue("Health Potion", out int amount))
        {
            GD.Print("Atrasts Health Potion: ", amount);
        }

        GD.Print("Ammo Pack skaits: ", GetAmount("Ammo Pack"));
        GD.Print("Shield skaits: ", GetAmount("Shield"));
        GD.Print("Vārdnīcas Count: ", inventory.Count);

        Godot.Collections.Dictionary saveData = new();
        saveData["player_name"] = "Anna";
        saveData["level"] = 5;

        if (saveData.ContainsKey("player_name"))
        {
            GD.Print("Spēlētājs: ", saveData["player_name"],
                ", līmenis: ", saveData["level"]);
        }
    }

    public int GetAmount(string name)
    {
        if (inventory.TryGetValue(name, out int amount))
            return amount;
        return 0;
    }
}
