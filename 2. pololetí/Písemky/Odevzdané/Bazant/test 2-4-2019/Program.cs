using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_2_4_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int pocetD = 0;
            int pocet = 0;
            for (int i = 1; i < 9876544; i++)
            {
                for (int a = i; a > 1; a--)
                {
                    if (i % a == 0)
                    {
                        pocetD++;
                    }
                }
                if (pocetD == 1)
                    pocet++;
                pocetD = 0;
            }
            Console.WriteLine("Mezi 1 a 9 876 543 je " + pocet);
            Console.ReadKey();
        }
    }
}
