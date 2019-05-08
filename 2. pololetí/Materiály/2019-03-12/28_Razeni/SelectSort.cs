using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SelectSort : IRazeni
    {
        int[] IRazeni.Serad(int[] pole)
        {
            int nejvetsi = int.MinValue;
            int indexNejvetsi = 0;

            for (int i = 0; i < pole.Length - 1; i++)
            {
                nejvetsi = int.MinValue;
                for (int j = i; j < pole.Length; j++)
                {
                    if (pole[j] > nejvetsi)
                    {
                        nejvetsi = pole[j];
                        indexNejvetsi = j;
                    }
                }
                pole[indexNejvetsi] = pole[i];
                pole[i] = nejvetsi;
            }
            return pole;
        }
    }
}
