using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymVod.OOP
{
    public class Ucitel : Clovek
    {
        public void Nauc(string co)
        {
            Console.WriteLine("Učím " + co);
            Console.WriteLine(Secti(5, 3));
        }

        public override void Premyslej()
        {
            Console.WriteLine("Přemýšlím, jak učit studenty.");
        }
    }
}
