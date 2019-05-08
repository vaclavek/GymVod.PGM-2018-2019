using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BubleSort : IRazeni
    {
        public int[] Serad(int[] pole)
        {
            for(int i = 0; i < pole.Length; i++)
            {
                for (int t = 0; t < pole.Length - i - 1; t++)
                {
                    if (pole[t] > pole[t+1]) {
                        int z = pole[t];
                        pole[t] = pole[t+1];
                        pole[t + 1] = z;
                    }    
                } 
            }
            return pole;
        }
    }
}
