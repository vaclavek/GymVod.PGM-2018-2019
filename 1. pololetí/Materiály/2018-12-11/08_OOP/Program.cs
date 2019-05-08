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
            GymVod.OOP.Clovek janaProgramatorka = new GymVod.OOP.Programator();
            // janaProgramatorka.Naprogramuj("domácí úkol");
            janaProgramatorka.Premyslej();

            GymVod.OOP.Ucitel karelUcitel = new GymVod.OOP.Ucitel();
            karelUcitel.Nauc("C#");
            karelUcitel.Premyslej();

        }
    }
}
