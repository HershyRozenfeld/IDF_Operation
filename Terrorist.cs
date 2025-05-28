using System;
using System.Collections.Generic;

public class Terrorist
{
    private string name;
    private List<string> weapon { get; set; } = new List<string>();
    protected int rank;
    protected bool status = true;

    public Terrorist(string name, string weapon, int rank)
    {
        this.name = name;
        this.weapon.Add(weapon);
        this.rank = rank;
    }

    public void Kill()
    {
        this.status = false;
    }

    public string getName()
    {
        return name;
    }

    public List<string> getWeapon()
    {
        return weapon;
    }

    public void SetWeapon(string weapon)
    {
        this.weapon.Add(weapon);
    }

    public int getRank()
    {
        return rank;
    }

    public bool getStatus()
    {
        return status;
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string output = $"  Terrorist: {name}\n" +
                        $"  - Weapons: {string.Join(", ", weapon)}\n" +
                        $"  - Rank: {rank}\n" +
                        $"  - Status: {(status ? "Alive" : "Dead")}\n";
        Console.ResetColor();
        return output;
    }
}