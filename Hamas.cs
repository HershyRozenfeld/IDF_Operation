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

    // Added getter for eliminated terrorists count
    public int GetEliminatedTerroristsCount()
    {
        return killTerrorists.Count;
    }

    public override string ToString()
    {
        string result = $"Hamas Organization: {organiztionName}, Established: {organiztionErection.ToShortDateString()}\n";
        result += $"Active Terrorists: {terrorists.Count}, Eliminated Terrorists: {killTerrorists.Count}\n";

        if (terrorists.Count == 0)
        {
            result += "No active terrorists.\n";
        }
        else
        {
            result += "Active Terrorists List:\n";
            foreach (Terrorist t in terrorists)
            {
                result += $"{t.ToString()}";
            }
        }
        return result;
    }
}