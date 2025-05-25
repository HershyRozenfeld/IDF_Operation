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
                        Consol.WriteLine($"{intel.terrorist.name} kiled by {item.name} ");
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
        }
    }
}
