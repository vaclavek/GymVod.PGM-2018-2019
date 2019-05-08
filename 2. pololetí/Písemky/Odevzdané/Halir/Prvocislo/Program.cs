using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvocislo
{
    class Program
    {
        static void Main(string[] args)
        {
            int pocetCisel = 0;
            List<Int32> prvocisla = new List<int>();
            bool jePrvocislo= true;
            for(int i=2; i<=9876543;i++)
            { pocetCisel++;
                for(int n=0;n<prvocisla.Count; n++)
                {
                    if (i%prvocisla[n]==0)
                    {
                        pocetCisel--;
                        jePrvocislo = false;
                        break;  
                    }

                }
                if (jePrvocislo == true)
                {
                    prvocisla.Add(i);
                    jePrvocislo = false;
                }
            }
            Console.WriteLine(pocetCisel);
        }
    }
}
