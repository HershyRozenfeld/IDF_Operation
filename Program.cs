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
        static void printMenu()
        {
            //Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("         IDF OPERATION MENU         ");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Display Intel Reports");
            Console.WriteLine("2. Display Available Weapons");
            Console.WriteLine("3. Execute Attack on Target");
            Console.WriteLine("4. Exit");
            Console.WriteLine("====================================");
            Console.Write("Enter your choice (1-4): ");
        }

        static void consoleMenager(List<Intel> intelReports, List<Weapon> weapons)
        {
            AMAN aMAN = new AMAN(intelReports);
            bool flag = true;
            while (flag)
            {
                printMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(intelReports);
                        foreach (Intel intel in intelReports)
                        {
                            Console.WriteLine(intel); 
                        }
                        break;
                    case "2":
                        Console.WriteLine("Available Weapons:");
                        foreach (Weapon weapon in weapons)
                        {
                            Console.WriteLine(weapon);
                        }
                        break;
                    case "3":
                        Intel i = aMAN.target();
                        attack(i, weapons);
                        break;
                    case "4":
                        flag = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        break;
                }
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
                        intel.terrorist.Kill();

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
            // Currently, the creation of the instances is done in a completely inefficient manner, and is done so only for demonstration purposes.
            List<Intel> intelReports = new List<Intel>
            {
                new Intel(new Terrorist("Ali", "knife", 1), "building", new DateTime(2024, 1, 1)),
                new Intel(new Terrorist("Omar", "pistol", 2), "vehicles", new DateTime(2024, 1, 2)),
                new Intel(new Terrorist("Yusuf", "rifle", 3), "open areas", new DateTime(2024, 1, 3)),
                new Intel(new Terrorist("Khalid", "sniper", 4), "building", new DateTime(2024, 1, 4)),
                new Intel(new Terrorist("Abu", "grenade", 5), "vehicles", new DateTime(2024, 1, 5)),
                new Intel(new Terrorist("Salim", "baton", 2), "open areas", new DateTime(2024, 1, 6)),
                new Intel(new Terrorist("Zayd", "sword", 1), "building", new DateTime(2024, 1, 7)),
                new Intel(new Terrorist("Tariq", "crossbow", 3), "vehicles", new DateTime(2024, 1, 8)),
                new Intel(new Terrorist("Fahad", "molotov", 4), "open areas", new DateTime(2024, 1, 9)),
                new Intel(new Terrorist("Nabil", "rocket launcher", 5), "building", new DateTime(2024, 1, 10)),
                new Intel(new Terrorist("Jamal", "knife", 1), "vehicles", new DateTime(2024, 1, 11)),
                new Intel(new Terrorist("Bilal", "pistol", 2), "open areas", new DateTime(2024, 1, 12)),
                new Intel(new Terrorist("Imran", "rifle", 3), "building", new DateTime(2024, 1, 13)),
                new Intel(new Terrorist("Rami", "sniper", 4), "vehicles", new DateTime(2024, 1, 14)),
                new Intel(new Terrorist("Saif", "grenade", 5), "open areas", new DateTime(2024, 1, 15))
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