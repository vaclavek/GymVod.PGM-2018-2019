using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ref_klicove_slovo
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo = 3;
            Console.WriteLine(cislo);

            ZvetsCislo(ref cislo);

            Console.WriteLine(cislo);
        }

        static void ZvetsCislo(ref int x)
        {
            x = x + 5;
        }
    }
}
