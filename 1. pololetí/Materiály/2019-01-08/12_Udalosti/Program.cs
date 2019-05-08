using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udalosti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Spuštěna aplikace.");
            var trida = new Trida();
            Console.WriteLine("2) Vytvořena instance.");
            trida.Progress += Trida_Udalost;
            Console.WriteLine("3) Přiřazena událost.");
            trida.Spocitej();
            Console.WriteLine("4) Konec aplikace.");
        }

        private static void Trida_Udalost(object sender, EventArgs e)
        {
            Console.WriteLine("Už je zpracováno " + sender);
        }
    }
}
