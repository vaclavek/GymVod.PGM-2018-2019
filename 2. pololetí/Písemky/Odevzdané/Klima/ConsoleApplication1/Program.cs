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
            Console.WriteLine("Zadej poslední číslo : ");
            int posledni = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            int pocet = 0;

            for (int i = 1; i <= posledni; i++)
            {
                for (int v = i; v >= 1; v--)
                {
                    if (i % v == 0)
                    {
                        count++;
                    }
                }
                if (count > 2)
                {
                    pocet++;
                }
                count = 0;

                Console.WriteLine(i);
            }

            int celkem = posledni - pocet - 1;
            Console.WriteLine("Počet prvočísel : " + celkem);
            Console.ReadKey();
        }
    }
}
