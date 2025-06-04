using System;
using System.Collections.Generic;
using System.Linq;

namespace IDF_Operation
{
    internal class Program
    {
        static void printMenu()
        {
            ConsolePrinter.ClearScreen();
            string separator = "=============================================================";
            ConsolePrinter.PrintHeader(separator, ConsoleColor.Magenta);
            ConsolePrinter.PrintHeader("                   IDF OPERATION MENU                         ", ConsoleColor.Magenta);
            ConsolePrinter.PrintHeader(separator, ConsoleColor.Magenta);

            ConsolePrinter.PrintText("1. Display Intelligence Reports");
            ConsolePrinter.PrintText("2. Display Available Weapons");
            ConsolePrinter.PrintText("3. Execute Attack on Target");
            ConsolePrinter.PrintText("4. Exit");

            ConsolePrinter.PrintHeader(separator, ConsoleColor.Magenta);
            ConsolePrinter.PrintPrompt("Enter your choice (1-4): ");
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
                        ConsolePrinter.PrintAmanReports(intels);
                        Console.ReadKey();
                        break;
                    case "2":
                        ConsolePrinter.PrintHeader("=== Available Weapons ===", ConsoleColor.Cyan);
                        if (weapons.Count == 0)
                        {
                            ConsolePrinter.PrintText("No weapons available.");
                        }
                        else
                        {
                            foreach (Weapon weapon in weapons)
                            {
                                ConsolePrinter.PrintWeaponInfo(weapon);
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Intel target = intels.target();
                        if (target == null)
                        {
                            ConsolePrinter.PrintWarning("No living targets available.");
                        }
                        else
                        {
                            ConsolePrinter.PrintHeader("=== Selected Target ===", ConsoleColor.Yellow);
                            ConsolePrinter.PrintIntelInfo(target);
                            Attack(target, hamas, weapons, intels);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        flag = false;
                        ConsolePrinter.PrintText("Exiting IDF Operation System...", ConsoleColor.Magenta);
                        break;
                    default:
                        ConsolePrinter.PrintFailure("Invalid input. Please enter a number between 1 and 4.");
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
                        // It's generally safer to remove from a list after iterating,
                        // but AMAN.intels is distinct from the iteration here.
                        // However, ensure AMAN.target() logic handles a shrinking intels list if re-called.
                        intels.intels.Remove(intel);
                        ConsolePrinter.PrintSuccess($"SUCCESS: {intel.terrorist.getName()} eliminated by {item.name}.");
                        attackSuccessful = true;
                        if (item.strikes == 0)
                        {
                            weaponToRemove.Add(item);
                        }
                        break;
                    }
                    else
                    {
                        ConsolePrinter.PrintFailure($"FAILURE: {item.name} ammunition depleted.");
                    }
                }
            }
            foreach (Weapon w in weaponToRemove)
            {
                weapons.Remove(w);
                ConsolePrinter.PrintWarning($"Weapon {w.name} has been depleted and removed.");
            }

            if (!attackSuccessful && intel.terrorist.getStatus()) // Check if terrorist is still alive
            {
                // This message should only appear if no weapon was effective or available with ammo
                // and the target was not eliminated by a previous weapon in the loop (which 'break' prevents here).
                bool suitableWeaponExistsButNoAmmo = false;
                bool noSuitableWeaponAtAll = true;
                foreach (Weapon item in weapons) // Re-check or rely on a flag
                {
                    if (item.effective.Contains(intel.location))
                    {
                        noSuitableWeaponAtAll = false;
                        if (item.strikes == 0) suitableWeaponExistsButNoAmmo = true;
                        else suitableWeaponExistsButNoAmmo = false; // Found one with ammo
                        break;
                    }
                }
                if (noSuitableWeaponAtAll)
                    ConsolePrinter.PrintFailure($"No suitable weapon found for location: {intel.location}.");
                // else if (suitableWeaponExistsButNoAmmo) 
                // this case is covered by "ammunition depleted" inside the loop for the first such weapon.
                // However, if ALL suitable weapons are out of ammo, that message is also relevant.
                // The current logic prints "ammunition depleted" for the first one encountered.
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
            foreach (Terrorist terrorist in hamas.GetTerrorists().Where(t => t.getStatus()))
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


            AMAN intels = new AMAN(intelReports);
            consoleMenager(intels, hamas, weapons);
        }
    }
}