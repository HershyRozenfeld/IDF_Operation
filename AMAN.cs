public class AMAN
{
    public List<Intel> intels = new List<Intel>();
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

    public Intel target()
    {
        int max = 0;
        int sum = 0;
        Intel tar = new Intel();
        
        string weapon = "";
        foreach (Intel i in intels)
        {
            int weaponRank = 0;
            foreach (string w in i.terrorist.weapon) {
                if (dictionary.ContainsKey(w.ToLower())) {
                    weaponRank += dictionary[weapon.ToLower()];
                }
            }
            sum = i.terrorist.getRank() * weaponRank;
            if (sum > max)
            {
                max = sum;
                tar = i;
            }
            return i;
        }
        return tar;
    }
}