using Godot;
using System.Collections.Generic;

public partial class EnemyListDemo : Node
{
    [Export] public Godot.Collections.Array<string> WaveNames = new();
    private List<Enemy> enemies = new();

    public override void _Ready()
    {
        // 1. uzdevums: pievieno ienaidniekus List<Enemy> sarakstam
        enemies.Add(new Enemy { EnemyName = "Skauts", Position = new Vector2(500, 300) });
        enemies.Add(new Enemy { EnemyName = "Sargs", Position = new Vector2(350, 360) });
        enemies.Add(new Enemy { EnemyName = "Snaiperis", Position = new Vector2(900, 200) });
        enemies.Add(new Enemy { EnemyName = "Smagais", Position = new Vector2(700, 500) });

        GD.Print("Sākuma skaits: ", enemies.Count);
        foreach (Enemy enemy in enemies)
        {
            GD.Print("Ienaidnieks: ", enemy.EnemyName);
        }

        // 2. uzdevums: izņemšana pēc indeksa, robežu pārbaude un droša dzēšana
        enemies.RemoveAt(1); // Izņem "Sargs" (indekss 1)
        GD.Print("Skaits pēc RemoveAt(1): ", enemies.Count);

        int index = 10;
        if (index >= 0 && index < enemies.Count)
            GD.Print(enemies[index].EnemyName);
        else
            GD.Print("Indekss ", index, " ir ārpus robežām (Count = ", enemies.Count, ")");

        List<Enemy> toRemove = new();
        foreach (Enemy enemy in enemies)
        {
            if (enemy.EnemyName == "Skauts")
                toRemove.Add(enemy);
        }
        foreach (Enemy enemy in toRemove)
        {
            enemies.Remove(enemy);
        }
        GD.Print("Skaits pēc drošas dzēšanas: ", enemies.Count);

        // 3. uzdevums: Godot Array un C# List<int> salīdzinājums
        Godot.Collections.Array bullets = new();
        bullets.Add(12);
        bullets.Add("plazma");
        GD.Print("Godot Array skaits: ", bullets.Count);

        List<int> ammoCounts = new();
        ammoCounts.Add(12);
        GD.Print("Tipdroša List<int> skaits: ", ammoCounts.Count);
    }
}