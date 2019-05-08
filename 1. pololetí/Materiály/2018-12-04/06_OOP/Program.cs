using GymVod.OOP.Moto;
using System;
using System.Threading;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            DateTime datumNarozeni = new DateTime(2001, 5, 1);

            GymVod.OOP.Clovek karelVomacka = new GymVod.OOP.Clovek("Karel Vomáčka", datumNarozeni);
            Console.WriteLine(karelVomacka.JakSeMas());

            Console.WriteLine(karelVomacka.Jmeno);
            Console.WriteLine(karelVomacka.DatumNarozeni.ToShortDateString());

            // Nalze nastavit vek, protože setter je privátní - zapouzdření
            // karelVomacka.Vek = 99;

            Console.WriteLine(karelVomacka.Vek);
            Console.WriteLine(karelVomacka.KolikTiJe());

            Console.WriteLine();
            GymVod.OOP.Clovek franta = new GymVod.OOP.Clovek("Franta", new DateTime(2002, 1, 1));
            Console.WriteLine(franta.Jmeno);
            Console.WriteLine(franta.DatumNarozeni.ToShortDateString());
            Console.WriteLine(franta.KolikTiJe());
        }
    }
}
