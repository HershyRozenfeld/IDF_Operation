using System;
using System.Collections.Generic;

public class AMAN
{
    public List<Intel> intels;
    public Dictionary<string, int> dictionary = new Dictionary<string, int>
    {
        { "knife", 2 },
        { "pistol", 4 },
        { "rifle", 6 },
        { "sniper", 7 },
        { "grenade", 5 },
        { "baton", 1 },
        { "sword", 3 },
        { "crossbow", 4 },
        { "molotov", 6 },
        { "rocket launcher", 9 }
    };

    public AMAN(List<Intel> intels)
    {
        this.intels = intels;
    }

    public Intel target()
    {
        int max = 0;
        int sum = 0;
        Intel tar = null;

        foreach (Intel i in intels)
        {
            if (i.terrorist.getStatus())
            {
                int weaponRank = 0;
                foreach (string w in i.terrorist.getWeapon())
                {
                    if (dictionary.ContainsKey(w.ToLower()))
                    {
                        weaponRank += dictionary[w.ToLower()];
                    }
                }
                sum = i.terrorist.getRank() * weaponRank;
                if (sum > max)
                {
                    max = sum;
                    tar = i;
                }
            }
        }
        return tar;
    }

    public override string ToString()
    {
        string result = $"AMAN Intelligence Reports Summary ({intels.Count} reports)\n";
        if (intels.Count == 0)
        {
            result += "No intelligence reports available.\n";
        }
        else
        {
            foreach (Intel i in intels)
            {
                result += $"{i.ToString()}";
            }
        }
        return result;
    }
}