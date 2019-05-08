using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Prvocisla
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> prvocisla = new List<int>();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Minioptimalizace: přeskakuje sudá (zrychlení o 200 ms)
            // Stejná optimalizace pro 2 a 3 není o moc rychlejší.
            for (int i = 3; i < 9876543; i+=2)
            {
                bool prvocislo = true;
                foreach (int j in prvocisla)
                {
                    //Pretečení neovlivní a je rychlejší než Math.Sqrt
                    if (i < j*j) break;
                    if (i % j == 0)
                    {
                        prvocislo = false;
                        break;
                    }
                }
                if (prvocislo) prvocisla.Add(i);
            }

            sw.Stop();

            // Přičte 1 za nezapočítanou 2.
            Console.WriteLine("Nalezeno " + (prvocisla.Count + 1) + " prvočísel. Doba trvání " + sw.ElapsedMilliseconds + " ms. Stiskněte jakoukoliv klávesu.");
            Console.ReadKey();
        }
    }
}
