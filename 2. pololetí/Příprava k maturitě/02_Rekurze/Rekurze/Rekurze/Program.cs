using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekurze
{
    class Program
    {
        private static int zapamatovanecislo = 0;

        static void Main(string[] args)
        {
            // Vygenerujte Fibonacciho posloupnost pro čísla od 1 do 40
            int maxCislo = 40;

            for (int i = 1; i <= maxCislo; i++)
            {
                Console.WriteLine("Fibonacci pro " + i + " je " + Fibonacci(i));
            }
            Console.WriteLine("Zapamatovane cislo: " + zapamatovanecislo);
        }

        static int Fibonacci(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 1;
            if (n == 3)
            {
                zapamatovanecislo++;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
