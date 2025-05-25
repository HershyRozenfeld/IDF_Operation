using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF_Operation
{
    internal class Program
    {
        static void consoleMenager(int choice)
        {
            switch(choice)
            {
                case 1:
                    Console.WriteLine();
                    break;
                case 2;
                    Console.WriteLine();
                    break;
                case 3:
                    attack(Intel t.target, List < Weapon > attaktools);
                    break;
            }
        }
        static void attack(Intel intel, List<Weapon> attaktools)
        {
           foreach (Weapon item in attakTools)
            {
                if (item.effective == intel.location)
                {
                    if (item.strikes > 0)
                    {
                        intel.terrorist.dead();
                        item.setStrike();
                        Console.WriteLine($"{intel.terrorist.name} kiled by {item.name} ");
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
            new Intel(new Terrorist("Ali", "knife", 1), 101, DateTime.Now),
            new Intel(new Terrorist("Omar", "pistol", 2), 102, DateTime.Now),
            new Intel(new Terrorist("Yusuf", "rifle", 3), 103, DateTime.Now),
            new Intel(new Terrorist("Khalid", "sniper", 4), 104, DateTime.Now),
            new Intel(new Terrorist("Abu", "grenade", 5), 105, DateTime.Now),
            new Intel(new Terrorist("Salim", "baton", 2), 106, DateTime.Now),
            new Intel(new Terrorist("Zayd", "sword", 1), 107, DateTime.Now),
            new Intel(new Terrorist("Tariq", "crossbow", 3), 108, DateTime.Now),
            new Intel(new Terrorist("Fahad", "molotov", 4), 109, DateTime.Now),
            new Intel(new Terrorist("Nabil", "rocket launcher", 5), 110, DateTime.Now),
            new Intel(new Terrorist("Jamal", "knife", 1), 111, DateTime.Now),
            new Intel(new Terrorist("Bilal", "pistol", 2), 112, DateTime.Now),
            new Intel(new Terrorist("Imran", "rifle", 3), 113, DateTime.Now),
            new Intel(new Terrorist("Rami", "sniper", 4), 114, DateTime.Now),
            new Intel(new Terrorist("Saif", "grenade", 5), 115, DateTime.Now)
        };
        }
    }
}
