using Godot;
using System.Collections.Generic;

public partial class EnemyListDemo : Node2D
{
    private List<Enemy> enemies = new();

    public override void _Ready()
    {
        int enemyCount = 3;

        for (int i = 1; i <= enemyCount; i++)
        {
            Enemy enemy = new Enemy();
            enemy.Name = "Enemy" + i;
            enemy.Position = new Vector2(100 * i, 200);
            AddChild(enemy);
            enemies.Add(enemy);
        }

        GD.Print("Ienaidnieku skaits: " + enemies.Count);

        foreach (Enemy enemy in enemies)
        {
            GD.Print("Ienaidnieks: " + enemy.Name);
        }

        Vector2 playerPosition = new Vector2(0, 200);
        Enemy nearest = FindNearest(playerPosition);
        if (nearest != null)
        {
            GD.Print("Tuvākais: " + nearest.Name + ", attālums: " + nearest.Position.DistanceTo(playerPosition));
        }

        GD.Print("Izmērs PIRMS dzēšanas: " + enemies.Count);
        enemies.RemoveAt(1);
        GD.Print("Izmērs PĒC dzēšanas: " + enemies.Count);

        int index = 10;
        if (index >= 0 && index < enemies.Count)
        {
            GD.Print(enemies[index].Name);
        }
        else
        {
            GD.Print("Indekss " + index + " nav derīgs, saraksta izmērs: " + enemies.Count);
        }

        List<Enemy> toRemove = new();
        foreach (Enemy enemy in enemies)
        {
            if (enemy == enemies[0]) toRemove.Add(enemy);
        }
        foreach (Enemy enemy in toRemove)
        {
            enemies.Remove(enemy);
        }
        GD.Print("Izmērs pēc drošās dzēšanas: " + enemies.Count);

        Godot.Collections.Array bullets = new();
        bullets.Add(1);
        bullets.Add("paraugs");
        GD.Print("Bullets skaits: " + bullets.Count);
        bullets.RemoveAt(bullets.Count - 1);
        GD.Print("Bullets pēc dzēšanas: " + bullets.Count);
    }

    private Enemy FindNearest(Vector2 playerPosition)
    {
        Enemy nearest = null;
        float best = float.MaxValue;

        foreach (Enemy enemy in enemies)
        {
            float distance = enemy.Position.DistanceTo(playerPosition);
            if (distance < best)
            {
                best = distance;
                nearest = enemy;
            }
        }
        return nearest;
    }
}