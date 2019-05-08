using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kvadraticka_rovnice
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1;
            double x2;
            double D;
            Console.WriteLine("Vypocitam ti kvadratickou rovnici. Zacni tim, ze zadas koeficienty rovnice ve tvaru ax^2 + bx + c = 0");
            Console.WriteLine("Nejdriv zadej koeficient a");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ted zadej koeficient b");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A nakonec zadej koeficient c");
            double c = Convert.ToInt32(Console.ReadLine());

            if (a == 0)
            {
                Console.WriteLine("Rovnice nema reseni");
            }

            if (b == 0)
            {
                if (a == 1)
                {
                    if (c < 0)
                    {
                        x1 = Math.Sqrt(c * (-1));
                        x2 = x1 * (-1);
                        Console.WriteLine("1. koren rovnice je: " + x1);
                        Console.WriteLine("2. koren rovnice je: " + x2);
                    }
                    else
                    if (c == 0)
                    {
                        Console.WriteLine("Rovnice ma dvojnasobny koren a to 0");
                    }
                    else
                        Console.WriteLine("Rovnice nema reseni");
                }
                else
                if (c < 0)
                {
                    x1 = Math.Sqrt((c * (-1)) / (a));
                    x2 = x1 * (-1);
                    Console.WriteLine("1. koren rovnice je: " + x1);
                    Console.WriteLine("2. koren rovnice je: " + x2);
                }
                else
                if (c == 0)
                {
                    Console.WriteLine("Rovnice ma dvojnasobny koren a to 0");
                }
                else
                    Console.WriteLine("Rovnice nema reseni");
            }

            if (c == 0)
            {
                x1 = (-1) * ((b) / (a));
                x2 = 0;
                Console.WriteLine("1. koren rovnice je: " + x1);
                Console.WriteLine("2. koren rovnice je: " + x2);
            }

            D = (b * b) - 4 * a * c;

            if (D < 0)
            {
                Console.WriteLine("Rovnice nema reseni");
            }
            else
            if (D == 0)
            {
                x1 = (-b) / (2 * a);
                Console.WriteLine("Rovnice ma dvojnasobny koren a to: " + x1);
            }
            else
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("1. koren rovnice je: " + x1);
                Console.WriteLine("2. koren rovnice je: " + x2);
            }

            if (a > 0)
            {
                Console.WriteLine("Grafem teto funkce je konvexni parabola");
            }
            else
                Console.WriteLine("Grafem teto funkce je konkavni parabola");
             Console.ReadKey();
        }
    }
}
