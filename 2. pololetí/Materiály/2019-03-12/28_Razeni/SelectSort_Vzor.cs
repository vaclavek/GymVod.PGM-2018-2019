using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SelectSort_Vzor : IRazeni
    {
        public int[] Serad(int[] pole)
        {
            int temp, min;
            for (int i = 0; i < (pole.Length - 1); i++)
            {
                min = pole.Length - 1;
                // hledani minima
                for (int j = i; j < (pole.Length - 1); j++)
                    if (pole[min] > pole[j])
                        min = j;
                // prohozeni prvku
                temp = pole[min];
                pole[min] = pole[i];
                pole[i] = temp;
            }
            return pole;
        }
    }
}
