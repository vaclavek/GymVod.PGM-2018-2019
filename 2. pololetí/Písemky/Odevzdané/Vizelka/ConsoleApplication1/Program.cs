using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            long pocet = 0;
            for (long t = 2; t <= 9876543; t++ )
                {
                    long vysledek = proverprvocislo(t);
                    if (vysledek != 0)
                    {
                        pocet++;
                    }
                }

            Console.WriteLine("Pocet prvocisel je " + pocet);
            Console.Read();
        }
        private static long proverprvocislo(long x)
        {
            long i;
            for (i = 2; i < x; i++)
            {
                if (x % i == 0)
                {
                    return 0;
                }
            }
            if (i == x)
            {
                return 1;
            }
            return 0;
        }

    }
}
