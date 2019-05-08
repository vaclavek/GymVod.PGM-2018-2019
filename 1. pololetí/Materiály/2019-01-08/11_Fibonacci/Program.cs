using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        // optimalizace prostřednictvím slovníku - vypočtené hodnoty si uchováme a příště použijeme
        private static Dictionary<ulong, ulong> slovnik = new Dictionary<ulong, ulong>();

        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(150));
        }

        // pracujeme s ulong, protože meze rychle rostou a nepotřebujeme záporná čísla
        static ulong Fibonacci(ulong n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (slovnik.ContainsKey(n))
            {
                return slovnik[n];
            }

            ulong vysledek = Fibonacci(n - 1) + Fibonacci(n - 2);
            slovnik.Add(n, vysledek);

            return vysledek;
        }

        public static int FibonacciCycle(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
