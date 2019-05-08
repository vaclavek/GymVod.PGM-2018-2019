using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Zadej právě jeden parametr.");
                return;
            }

            string prvniVstup = args[0];
            int cislo;
            bool jeCislo = int.TryParse(prvniVstup, out cislo);
            if (!jeCislo)
            {
                Console.WriteLine("Vstup není číslo.");
                return;
            }

            Console.WriteLine("Číslo v šestnáctkové soustavě je: " + cislo.ToString("X"));
            Console.WriteLine("Číslo v šestnáctkové soustavě je: " + Convert.ToString(cislo, 16));

            string binValue = Convert.ToString(cislo, 8);
            Console.WriteLine("Číslo v dvojkové soustavě je: " + binValue);

        }
    }
}
