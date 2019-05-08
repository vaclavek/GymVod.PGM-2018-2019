using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Obdelnik : ITvar
    {
        protected int a;
        protected int b;

        public Obdelnik(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public decimal VypoctiObsah()
        {
            return a * b;
        }

        public virtual string VratInformace()
        {
            return "Obdlník, strany jsou" + a + ", " + b;
        }
    }
}
