using System;

public abstract class Weapon
{
    public string name;
    public string booms;
    public string effective;
    public int strikes;
    public int id;

    public Weapon(string name, string booms, string effective, int strikes)
    {
        this.name = name;
        this.booms = booms;
        this.effective = effective;
        this.strikes = strikes;
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string output = $"│ Weapon: {name}\n";
        output += $"│ - Boom Type: {booms}\n";
        output += $"│ - Effective Area: {effective}\n";
        output += $"│ - Strikes Left: {strikes}\n";
        Console.ResetColor();
        return output;
    }

    public abstract void setStrike(int fgh);
}