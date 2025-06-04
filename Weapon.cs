using System;

public abstract class Weapon
{
    public string name;
    public string booms;
    public string effective;
    public int strikes;
    public int id; // not initialized or used in the constructor or methods.

    public Weapon(string name, string booms, string effective, int strikes)
    {
        this.name = name;
        this.booms = booms;
        this.effective = effective;
        this.strikes = strikes;
    }
    public abstract void setStrike(int fgh);
    public override string ToString()
    {
        string output = $"│ Weapon: {name}\n";
        output += $"│ - Boom Type: {booms}\n";
        output += $"│ - Effective Area: {effective}\n";
        output += $"│ - Strikes Left: {strikes}\n";
        return output;
    }
}