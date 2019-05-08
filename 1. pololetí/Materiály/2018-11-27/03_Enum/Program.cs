using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum DnyVTydnu : int
    {
        Pondeli = 1,
        Utery = 2,
        Streda = 3,
        Ctvrtek = 4,
        Patek = 5,
        Sobota = 6,
        Nedele = 7
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej den v týdnu: ");
            string zadanyDen = Console.ReadLine();
            int zadanyDenInt = Convert.ToInt32(zadanyDen);

            DnyVTydnu tentoden = (DnyVTydnu)zadanyDenInt;
            Console.WriteLine("Zadal jsi: " + tentoden.ToString());
        }
    }
}
