using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Ctverec : Obdelnik
    {
        private readonly int a;

        public Ctverec(int a) : base(a, a)
        {
            this.a = a;
        }

        public override string VratInformace()
        {
            return "Čtverec, strana je " + a;
        }
    }
}
