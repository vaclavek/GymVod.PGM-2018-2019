using System;

namespace GymVod.OOP
{
    public abstract class Clovek : IClovek
    {
        public string Jmeno;
        public DateTime DatumNarozeni;
        public string Poloha;

        public int Vek { get; set; }

        // konstruktor
        public Clovek()
        {
        }

        public Clovek(string jmeno, DateTime datumNarozeni)
        {
            Jmeno = jmeno;
            DatumNarozeni = datumNarozeni;

            TimeSpan rozdil = DateTime.Now.Subtract(datumNarozeni);
            Vek = Convert.ToInt32(Math.Floor(rozdil.TotalDays / 365));
        }

        // destruktor / finalizer
        ~Clovek()
        {
        }

        public abstract void Premyslej();

        public void Rekni(string comamrict)
        {
            Console.WriteLine(comamrict);
        }

        public void Rekni(string prvni, string druhy)
        {
            Console.WriteLine(prvni);
            Console.WriteLine(druhy);
        }

        public void Rekni(string prvni, string druhy, string treti)
        {
            Console.WriteLine(prvni);
            Console.WriteLine(druhy);
            Console.WriteLine(treti);
        }

        public void Lehni(string kam)
        {
            Poloha = kam;
        }

        public void Jez(string co)
        {
            // TODO: Dodělat
        }

        public int KolikTiJe()
        {
            return Vek;
        }

        public string JakSeMas()
        {
            return "dobře!";
        }

        protected int Secti(int prvniCislo, int druheCislo)
        {
            return prvniCislo + druheCislo;
        }
    }
}
