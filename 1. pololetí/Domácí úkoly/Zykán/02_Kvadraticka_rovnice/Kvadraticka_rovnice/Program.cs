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
            Console.WriteLine("Aplikace pro výpočet kvadratické rovnice.");
            Console.WriteLine("Kvadratická rovnice ve tvaru a*x^2+b*x+c=0");
            Console.Write("Zadejte hodnotu a: ");
            var a = Console.ReadLine();
            double aa = Convert.ToDouble(a);
            Console.Write("Zadejte hodnotu b: ");
            var b = Console.ReadLine();
            double bb = Convert.ToDouble(b);
            Console.Write("Zadejte hodnotu c: ");
            var c = Console.ReadLine();
            double cc = Convert.ToDouble(c);

            var d = Convert.ToDouble(bb * bb - 4 * aa * cc);
            if (d < 0)
            {
                Console.WriteLine("Rovnice nemá řešení");
            }

            else
            {
                if (d == 0)
                {
                    Console.WriteLine("Rovnice má pouze jedno řešení");
                    double x = bb * -1 / 2 * aa;
                    Console.WriteLine("x = " + x);
                }

                else
                {
                    Console.WriteLine("Rovnice má 2 řešení");
                    //Console.WriteLine(Math.Sqrt(d));
                    //Console.WriteLine(aa);
                    //Console.WriteLine(bb);
                    //Console.WriteLine(cc);
                    double x1 = (bb * -1 + Math.Sqrt(d)) / (2 * aa);
                    double x2 = (bb * -1 - Math.Sqrt(d)) / (2 * aa);
                    Console.WriteLine("Kořen x1 = " + x1 + ", kořen x2 = " + x2);
                }

                if (aa > 0)
                {
                    Console.WriteLine("Funkce je konvexní");
                    Console.WriteLine("Funkce je omezená zdola");
                }

                else
                {
                    Console.WriteLine("Funkce je konkávní");
                    Console.WriteLine("Funkce je omezená zhora");
                }
                
                if (bb == 0)
                {
                    Console.WriteLine("Funkce je Sudá");
                }

                else
                {
                    Console.Write("Funkce je lichá");
                }

            }









            Console.ReadKey();
        }
    }
}
