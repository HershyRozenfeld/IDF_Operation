using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF_Operation
{
    public static class ConsolePrinter
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void PrintHeader(string text, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public static void PrintPrompt(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void PrintObject(object obj, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj.ToString());
            Console.ResetColor();
        }

        public static void PrintSuccess(string message)
        {
            PrintText(message, ConsoleColor.Green);
        }

        public static void PrintFailure(string message)
        {
            PrintText(message, ConsoleColor.Red);
        }

        public static void PrintWarning(string message)
        {
            PrintText(message, ConsoleColor.Yellow);
        }

        public static void PrintWeaponInfo(Weapon weapon)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(weapon.ToString());
            Console.ResetColor();
        }

        public static void PrintIntelInfo(Intel intel)
        {
            Console.WriteLine($"│ Target Intel");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"│ Location: {intel.location}");
            Console.WriteLine($"│ Date: {intel.date.ToShortDateString()} {intel.date.ToShortTimeString()}");
            Console.ResetColor();

            Console.WriteLine($"│ Terrorist Info:"); 
            PrintObject(intel.terrorist, ConsoleColor.Red);
        }

        public static void PrintAmanReports(AMAN aman)
        {
            PrintHeader($"┌═══════════════ AMAN Intelligence Reports ════════════════┐", ConsoleColor.Green);

            if (aman.intels.Count == 0)
            {
                PrintText("│        No intelligence reports available."); 
            }
            else
            {
                foreach (Intel i in aman.intels)
                {
                    PrintIntelInfo(i);
                }
            }
            PrintText("└══════════════════════════════════════════════════════════┘");
        }

        public static void PrintHamasInfo(Hamas hamas)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string header = $"┌════════════════════ Hamas Organization ══════════════════┐\n";
            header += $"│ Name: {hamas.organiztionName}\n";
            header += $"│ Established: {hamas.organiztionErection.ToShortDateString()}\n";
            header += $"│ Active Terrorists: {hamas.GetTerrorists().Count}\n";
            header += $"│ Eliminated Terrorists: {hamas.GetEliminatedTerroristsCount()}\n";
            header += $"└══════════════════════════════════════════════════════════┘";
            Console.WriteLine(header);
            Console.ResetColor();

            PrintHeader($"┌════════════════ Active Terrorists List ══════════════════┐", ConsoleColor.Yellow);

            if (hamas.GetTerrorists().Count == 0)
            {
                PrintText("│ No active terrorists.");
            }
            else
            {
                foreach (Terrorist t in hamas.GetTerrorists())
                {
                    PrintObject(t, ConsoleColor.Red);
                }
            }
            PrintText("└══════════════════════════════════════════════════════════┘");
        }
    }
}