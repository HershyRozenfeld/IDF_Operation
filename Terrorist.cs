
using System.Xml.Linq;

public class Terrorist
{

    private string name;
    private List<string> weapon = new List<string>
    {
       "Knife",
       "Pistol",
       "Rifle",
       "Sniper",
       "Grenade",
       "Molotov",
       "Rocket Launcher",
       "Shotgun",
       "Crossbow",
       "Sword"
    };
    protected int rank;
    protected bool status = true;
  
    public Terrorist(string name,string weapon,int rank)
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
        return $"Name: {name}, Weapon: {string.Join(", ", weapon)}, Rank: {rank}, Status: {(status ? "Alive" : "Dead")}";
    }


}