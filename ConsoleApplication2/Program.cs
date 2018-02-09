using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        private static ThronesTournamentManager manager = new ThronesTournamentManager();
        static void displayHouses()
        {
            Console.WriteLine("-----Houses----");
            foreach (var val in manager.getBigHouses())
            {
                Console.WriteLine(val.Name);
            }
            
        }

        static void displayHeroes()
        {
            Console.WriteLine("-----Characters----");
            foreach (var val in manager.getStrongCharacter())
            {
                Console.WriteLine(val);
            }
            
        }
        static void Main(string[] args)
        {
            /*displayHeroes();*/
            displayHouses();

            Console.ReadKey();
        }
    }
}
