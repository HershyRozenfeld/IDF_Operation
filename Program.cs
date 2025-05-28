using System;
using System.Collections.Generic;
using System.Linq;

namespace IDF_Operation
{
    internal class Program
    {
        static void printMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=============================================================");
            Console.WriteLine("                   IDF OPERATION MENU                         ");
            Console.WriteLine("=============================================================");
            Console.ResetColor();
            Console.WriteLine("1. Display Intelligence Reports");
            Console.WriteLine("2. Display Available Weapons");
            Console.WriteLine("3. Execute Attack on Target");
            Console.WriteLine("4. Exit");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=============================================================");
            Console.ResetColor();
            Console.Write("Enter your choice (1-4): ");
        }

        static void consoleMenager(AMAN intels, Hamas hamas, List<Weapon> weapons)
        {
            bool flag = true;
            while (flag)
            {
                printMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(intels.ToString());
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=== Available Weapons ===");
                        Console.ResetColor();
                        if (weapons.Count == 0)
                        {
                            Console.WriteLine("No weapons available.");
                        }
                        else
                        {
                            foreach (Weapon weapon in weapons)
                            {
                                Console.WriteLine(weapon.ToString());
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Intel target = intels.target();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (target == null)
                        {
                            Console.WriteLine("No living targets available.");
                        }
                        else
                        {
                            Console.WriteLine("=== Selected Target ===");
                            Console.WriteLine(target.ToString());
                            Attack(target, hamas, weapons, intels);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        flag = false;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Exiting IDF Operation System...");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Attack(Intel intel, Hamas hamas, List<Weapon> weapons, AMAN intels)
        {
            bool attackSuccessful = false;
            List<Weapon> weaponToRemove = new List<Weapon>();
            foreach (Weapon item in weapons)
            {
                if (item.effective.Contains(intel.location))
                {
                    if (item.strikes > 0)
                    {
                        intel.terrorist.Kill();
                        hamas.RemoveTerrorist(intel.terrorist);
                        item.setStrike(1);
                        intels.intels.Remove(intel);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"SUCCESS: {intel.terrorist.getName()} eliminated by {item.name}.");
                        Console.ResetColor();
                        attackSuccessful = true;
                        if (item.strikes == 0)
                        {
                            weaponToRemove.Add(item); // I used a temporary list (weaponsToRemove) to avoid removing items while looping over weapons, it's better not to cause errors
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"FAILURE: {item.name} ammunition depleted.");
                        Console.ResetColor();
                    }
                }
            }
            foreach (Weapon w in weaponToRemove)
            {
                weapons.Remove(w);
                Console.WriteLine($"Weapon {w.name} has been depleted and removed.");
            }
            if (!attackSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No suitable weapon found for location: {intel.location}.");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Hamas hamas = new Hamas("Hamas", new DateTime(1987, 12, 14));
            List<Terrorist> terroristList = new List<Terrorist>
            {
                new Terrorist("Ali", "knife", 1),
                new Terrorist("Omar", "pistol", 2),
                new Terrorist("Yusuf", "rifle", 3),
                new Terrorist("Khalid", "sniper", 4),
                new Terrorist("Abu", "grenade", 5),
                new Terrorist("Salim", "baton", 2),
                new Terrorist("Zayd", "sword", 1),
                new Terrorist("Tariq", "crossbow", 3),
                new Terrorist("Fahad", "molotov", 4),
                new Terrorist("Nabil", "rocket launcher", 5),
                new Terrorist("Jamal", "knife", 1),
                new Terrorist("Bilal", "pistol", 2),
                new Terrorist("Imran", "rifle", 3),
                new Terrorist("Rami", "sniper", 4),
                new Terrorist("Saif", "grenade", 5)
            };
            foreach (Terrorist t in terroristList)
            {
                hamas.AddTerrorist(t);
            }
            List<string> locations = new List<string> { "building", "vehicles", "open areas" };

            List<Intel> intelReports = new List<Intel>();
            Random random = new Random();
            foreach (Terrorist terrorist in hamas.GetTerrorists())
            {
                string location = locations[random.Next(locations.Count)];
                DateTime date = DateTime.Now.AddDays(-random.Next(365));
                Intel intel = new Intel(terrorist, location, date);
                intelReports.Add(intel);
            }
            List<Weapon> weapons = new List<Weapon>
            {
                new F16Fighter(),
                new F16Fighter(),
                new F16Fighter(),
                new Hermes460(),
                new M109()
            };

            // The system will now receive an updated terrorist list at the time of object creation, but it will not be updated if new changes are made or if terrorists are removed from the Hamas terrorist list.
            AMAN intels = new AMAN(intelReports);
            consoleMenager(intels, hamas, weapons);
        }
    }
}