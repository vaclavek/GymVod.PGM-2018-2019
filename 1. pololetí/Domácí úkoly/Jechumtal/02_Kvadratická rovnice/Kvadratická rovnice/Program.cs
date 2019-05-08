using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kvadratická_rovnice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Progam pro výpočet kvadratické rovnice");
            Console.WriteLine("Zadávej proměné podle vzoru: ax^2 + bx + c");
            double x1;
            double x2;
            string pokracovat = "A";

            while (pokracovat == "A")
            {
                Console.WriteLine("Zadej číslo a");
                int a;
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Nezadal jsi číslo");
                    Console.WriteLine("Zadej číslo a");
                }

                Console.WriteLine("Zadej číslo b");
                int b;
                while (!int.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Nezadal jsi číslo");
                    Console.WriteLine("Zadej číslo b");
                }

                Console.WriteLine("Zadej číslo c");
                int c;
                while (!int.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Nezadal jsi číslo");
                    Console.WriteLine("Zadej číslo c");
                }

                double Diskriminant = b * b - 4 * (a) * (c);
                double OdmDiskriminantu = Math.Sqrt(Diskriminant);

                if (OdmDiskriminantu == 0)
                {
                    x1 = -(b) / 2 * (a);
                    Console.WriteLine("Rovnice má jeden dvojnásobný kořen " + x1);
                }
                else
                {
                    if (OdmDiskriminantu > 0)
                    {
                        x1 = (-(b) + (OdmDiskriminantu)) / (2 * (a));
                        x2 = (-(b) - (OdmDiskriminantu)) / (2 * (a));
                        Console.WriteLine("Rovnice má dvojnásobný kořen, x1 = {0} x2 = {1}", x1, x2);
                    }
                    else
                    {
                        Console.WriteLine("Rovnice nemá řešení");
                    }
                }
                Console.WriteLine("Přejte si pokračovat A/N");
                pokracovat = Console.ReadLine().ToUpper();
            }            
        }
    }
}
