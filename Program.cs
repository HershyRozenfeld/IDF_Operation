using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IDF_Operation
{
    internal class Program
    {

        static void consoleMenager(List<Intel> intelReports, List<Weapon> weapons)
        {
            AMAN aMAN = new AMAN(intelReports);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine();
                    break;
                case "3":
                    Intel i = aMAN.target();
                    attack(i, weapons);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
        static void attack(Intel intel, List<Weapon> weapons)
        {
            foreach (Weapon item in weapons)
            {
                if (item.effective.Contains(intel.location))
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
                new Intel(new Terrorist("Ali", "knife", 1), "building", DateTime.Now),
                new Intel(new Terrorist("Omar", "pistol", 2), "vehicles", DateTime.Now),
                new Intel(new Terrorist("Yusuf", "rifle", 3), "open areas", DateTime.Now),
                new Intel(new Terrorist("Khalid", "sniper", 4), "building", DateTime.Now),
                new Intel(new Terrorist("Abu", "grenade", 5), "vehicles", DateTime.Now),
                new Intel(new Terrorist("Salim", "baton", 2), "open areas", DateTime.Now),
                new Intel(new Terrorist("Zayd", "sword", 1), "building", DateTime.Now),
                new Intel(new Terrorist("Tariq", "crossbow", 3), "vehicles", DateTime.Now),
                new Intel(new Terrorist("Fahad", "molotov", 4), "open areas", DateTime.Now),
                new Intel(new Terrorist("Nabil", "rocket launcher", 5), "building", DateTime.Now),
                new Intel(new Terrorist("Jamal", "knife", 1), "vehicles", DateTime.Now),
                new Intel(new Terrorist("Bilal", "pistol", 2), "open areas", DateTime.Now),
                new Intel(new Terrorist("Imran", "rifle", 3), "building", DateTime.Now),
                new Intel(new Terrorist("Rami", "sniper", 4), "vehicles", DateTime.Now),
                new Intel(new Terrorist("Saif", "grenade", 5), "open areas", DateTime.Now)
                };

            List<Weapon> weapons = new List<Weapon>
            {
                new F16Fighter(),
                new Hermes460(),
                new M109()
            };
            consoleMenager(intelReports, weapons);
        }
    }
}