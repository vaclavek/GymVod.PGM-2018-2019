using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("zadejte číslo");
            double cislo = Convert.ToDouble(Console.ReadLine());
            double y = Math.Round(Math.Sqrt(cislo));
           int delitelu = 0;
            double x;
           for (int i = 2; i < y; i++)
            {
                if (cislo % i == 0)
                {
                    x = cislo / i;
                    delitelu++;
                    Console.WriteLine(i);
                    Console.WriteLine(x);
                    delitelu++;
                }
                else

                { }
             }

         
            Console.WriteLine("počet dělitelů je " + delitelu);
            Console.ReadKey();

        }
    }
}
