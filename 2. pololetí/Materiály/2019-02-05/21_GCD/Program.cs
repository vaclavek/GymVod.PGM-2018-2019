using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("První číslo:");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Druhé číslo:");
            var y = Convert.ToInt32(Console.ReadLine());
            Console.Write("GCD: ");
            Console.WriteLine(GCD(x, y));
            Console.ReadKey();
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
    }
}
