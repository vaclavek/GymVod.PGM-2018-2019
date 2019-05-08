using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymVod.OOP
{
    public class Programator : Clovek
    {
        public Programator()
        {
        }

        public Programator(string jmeno, DateTime datumNarozeni) : base(jmeno, datumNarozeni)
        {
        }

        public void Naprogramuj(string co)
        {
            Console.WriteLine("Programuji " + co);
            base.Rekni("Líbilo se mi to!");
        }

        public override void Premyslej()
        {
            Console.WriteLine("Technicky jsem se zamyslel a vymyslel programový kód.");
        }
    }
}
