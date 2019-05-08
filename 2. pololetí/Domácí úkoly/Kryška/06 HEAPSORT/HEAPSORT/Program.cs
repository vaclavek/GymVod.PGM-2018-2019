using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HEAPSORT
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader soubor = new StreamReader("C:\\Temp\\data.csv");
            string radek;
            while ((radek = soubor.ReadLine()) !=null)
                {
                    string[] pole = new string[3]; 
                    pole = radek.Split(';');
                    Console.Write(radek);
                    if(radek == "Datum;Open;Close")
                    {
                        continue;
                    }
                    double cislo1 = Convert.ToDouble(pole[1].Replace(',';','));
                    double cislo2 = Convert.ToDouble(pole[2].Replace(',';','));
                    double prumer = (cislo1 + cislo2) / 2;
                    Console.WriteLine(prumer);

                    list.Add(prumer
                }

        }
    }
}
