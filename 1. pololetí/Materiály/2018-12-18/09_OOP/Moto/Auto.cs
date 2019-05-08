using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymVod.OOP.Moto
{
    public abstract class Zvirata
    {
        public string Jmeno { get; set; }

        public abstract void VydejZvuk();

        public void Lehni()
        {
            // neco
        }
    }
}
