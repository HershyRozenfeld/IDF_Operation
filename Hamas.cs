using System;
using System.Collections.Generic;

public class Hamas
{
    public string organiztionName;
    public DateTime organiztionErection;
    private List<Terrorist> terrorists { get; set; }
    private List<Terrorist> killTerrorists { get; set; }

    public Hamas(string organiztionName, DateTime organiztionErection)
    {
        this.organiztionName = organiztionName;
        this.organiztionErection = organiztionErection;
        this.terrorists = new List<Terrorist>();
        this.killTerrorists = new List<Terrorist>();
    }

    public void AddTerrorist(Terrorist terrorist)
    {
        terrorists.Add(terrorist);
    }

    public List<Terrorist> GetTerrorists()
    {
        return terrorists;
    }

    public void RemoveTerrorist(Terrorist terrorist)
    {
        if (terrorists.Remove(terrorist))
        {
            killTerrorists.Add(terrorist);
        }
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        string result = $"┌════════════════════ Hamas Organization ══════════════════┐\n";
        result += $"│ Name: {organiztionName}\n";
        result += $"│ Established: {organiztionErection.ToShortDateString()}\n";
        result += $"│ Active Terrorists: {terrorists.Count}\n";
        result += $"│ Eliminated Terrorists: {killTerrorists.Count}\n";
        result += $"└══════════════════════════════════════════════════════════┘\n";
        Console.ForegroundColor = ConsoleColor.Yellow;
        result += $"┌════════════════ Active Terrorists List ══════════════════┐\n";
        Console.ResetColor();
        if (terrorists.Count == 0)
        {
            result += "│ No active terrorists.\n";
        }
        else
        {
            foreach (Terrorist t in terrorists)
            {
                result += $"{t.ToString()}";
            }
        }
        result += "└══════════════════════════════════════════════════════════┘";
        return result;
    }
}