using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF_Operation
{
    internal class Program
    {
        static void consoleMenager(int choice, List<Intel> intelReports, List<Weapon> weapons)
        {
            AMAN aMAN = new AMAN(intelReports);
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    break;
                case 3:
                    attack(aMAN.target(), weapons);
                    break;
            }
        }
        static void attack(Intel intel, List<Weapon> weapons)
        {
            foreach (Weapon item in weapons)
            {
                if (item.effective == intel.location)
                {
                    if (item.strikes > 0)
                    {
                        intel.terrorist.dead();
                        item.setStrike(1);
                        Console.WriteLine($"{intel.terrorist.getName()} kiled by {item.name} ");
                    }
                    else
                    {
                        Console.WriteLine($"The {item.name} ammunition ran out ");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<Intel> intelReports = new List<Intel>
            {
                new Intel(new Terrorist("Ali", "knife", 1), "XJwG02", DateTime.Now),
                new Intel(new Terrorist("Omar", "pistol", 2), "vrabJ3", DateTime.Now),
                new Intel(new Terrorist("Yusuf", "rifle", 3), "RC62Cl", DateTime.Now),
                new Intel(new Terrorist("Khalid", "sniper", 4), "8lPANF", DateTime.Now),
                new Intel(new Terrorist("Abu", "grenade", 5), "KA21Rr", DateTime.Now),
                new Intel(new Terrorist("Salim", "baton", 2), "R1aLHC", DateTime.Now),
                new Intel(new Terrorist("Zayd", "sword", 1), "KZLKer", DateTime.Now),
                new Intel(new Terrorist("Tariq", "crossbow", 3), "r9oHAF", DateTime.Now),
                new Intel(new Terrorist("Fahad", "molotov", 4), "ANAb33", DateTime.Now),
                new Intel(new Terrorist("Nabil", "rocket launcher", 5), "z80NqG", DateTime.Now),
                new Intel(new Terrorist("Jamal", "knife", 1), "aBckSJ", DateTime.Now),
                new Intel(new Terrorist("Bilal", "pistol", 2), "sNEgyv", DateTime.Now),
                new Intel(new Terrorist("Imran", "rifle", 3), "cqsgHd", DateTime.Now),
                new Intel(new Terrorist("Rami", "sniper", 4), "j9FoVT", DateTime.Now),
                new Intel(new Terrorist("Saif", "grenade", 5), "vXZfUf", DateTime.Now)
            };

            List<Weapon> weapons = new List<Weapon>
            {
                new F16Fighter(),
                new Hermes460(),
                new M109()
            };

        }
    }
}
