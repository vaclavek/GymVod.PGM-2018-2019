using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymVod.OOP
{
    public static class Konfigurace
    {
        public static string JmenoProgramu { get; set; } = "OOP potřetí a naposledy.";

        public static string Verze { get; set; }

        static Konfigurace()
        {
            Verze = "1.0.0.0";
        }

        public static void VypisKonfiguraci()
        {
            Console.WriteLine("Vítejte v aplikaci: " + Konfigurace.JmenoProgramu);
            Console.WriteLine("Verze aplikace: " + Konfigurace.Verze);
        }
    }
}
