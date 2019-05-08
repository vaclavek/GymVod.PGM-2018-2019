using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace csv
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            StreamReader soubor = new StreamReader("C:\\Temp\\data.csv");
            var list = new List<double>();
            string radek;
            while ((radek = soubor.ReadLine()) !=null)
            {
                
                string[] pole = new string[3];
                pole = radek.Split(';');
                Console.WriteLine(radek);
                if (radek == "Datum;Open;Close")
                {
                    continue;
                }
                if (radek == ";;")
                {
                    continue;
                }
                double cislo1 = Convert.ToDouble(pole[1]);
                double cislo2 = Convert.ToDouble(pole[2]);
                double prumer = (cislo1 + cislo2) / 2;
                Console.WriteLine(prumer);
                
                list.Add(prumer);
            }

            double prumervse = list.Average();
            Console.WriteLine(prumervse);
        

            
        }*/

        static void Main(string[] args)
        {
            /*
            string cisloCz = "11,1231";
            string cisloEn = "78.123123";

            double cisloCzDouble = Convert.ToDouble(cisloCz, CultureInfo.GetCultureInfo("cs-CZ"));
            double cisloEnDouble = Convert.ToDouble(cisloEn, CultureInfo.GetCultureInfo("en-US"));

            int cislo = 10000;
            Console.WriteLine(cislo);
            Console.WriteLine(cislo.ToString("c", CultureInfo.GetCultureInfo("cs-CZ")));
            Console.WriteLine(cislo.ToString("c", CultureInfo.GetCultureInfo("en-US")));
            */

            string[] radky = File.ReadAllLines("C:\\Temp\\data.csv");
            double totalAvg = 0;
            int count = 0;
            foreach (string radek in radky)
            {
                var pole = radek.Split(';');
                double cislo1, cislo2;
                if (double.TryParse(pole[1], out cislo1) &&
                    double.TryParse(pole[2], out cislo2))
                {
                    var prumer = (cislo1 + cislo2) / 2;
                    totalAvg += prumer;
                    count++;
                    Console.WriteLine(pole[0] + ": " + (prumer));
                }
            }
            Console.WriteLine("Celkový průměr: " + totalAvg / count);
        }
    }
}
