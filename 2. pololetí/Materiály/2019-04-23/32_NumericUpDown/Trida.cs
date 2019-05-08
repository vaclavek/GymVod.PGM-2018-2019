using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericUpDown
{
    class Trida
    {
        // field (pole)
        string jmeno;

        // property (vlastnost)
        public string Jmeno { get; set; }

        public void Metoda()
        {
            string retezec = "a5sdfasdfdfsdfasdfasd04212347weč86řtrwščsdfa1sd34";

            string jenCisla = "";
            foreach (var znak in retezec)
            {
                if (znak >= 48 && znak <= 57)
                {
                    jenCisla += znak.ToString();
                }
            }

            var rnd = new Random();
            var cislo = rnd.Next(65, 90);
            char znak2 = (char)cislo;

        }
    }
}
