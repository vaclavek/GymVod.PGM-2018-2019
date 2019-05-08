using System;

namespace GymVod.OOP
{
    class Clovek : IClovek
    {
        public string Jmeno;
        public DateTime DatumNarozeni;
        public string Poloha;

        public int Vek { get; private set; }

        // konstruktor
        public Clovek(string jmeno, DateTime datumNarozeni)
        {
            Jmeno = jmeno;
            DatumNarozeni = datumNarozeni;

            TimeSpan rozdil = DateTime.Now.Subtract(datumNarozeni);
            Vek = Convert.ToInt32(Math.Floor(rozdil.TotalDays / 365));
        }

        // destruktor
        ~Clovek()
        {
        }

        public void Rekni(string comamrict)
        {
            Console.WriteLine(comamrict);
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

        public int Secti(int prvniCislo, int druheCislo)
        {
            return prvniCislo + druheCislo;
        }
    }
}
