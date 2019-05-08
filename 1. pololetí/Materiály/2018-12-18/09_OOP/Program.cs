using GymVod.OOP;
using GymVod.OOP.Moto;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Konfigurace.VypisKonfiguraci();

            var janaProgramatorka = new GymVod.OOP.Programator();
            janaProgramatorka.Premyslej();
            janaProgramatorka.Rekni("Neco");

            int vek = janaProgramatorka.KolikTiJe();

        }
    }
}
