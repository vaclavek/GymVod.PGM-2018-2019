using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zkouseni_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Trojuhelnik trojuhelnik = new Trojuhelnik(5, 6, 8);
            Console.WriteLine("Obsah: " + trojuhelnik.GetObsah());
            Console.WriteLine("Obvod: " + trojuhelnik.GetObvod());

            Ctverec ctverec= new Ctverec(7);
            Console.WriteLine("Obsah: " + ctverec.GetObsah());
            Console.WriteLine("Obvod: " + ctverec.GetObvod());

            Kruh kruh = new Kruh(3.5);
            Console.WriteLine("Obsah: " + kruh.GetObsah());
            Console.WriteLine("Obvod: " + kruh.GetObvod());

            IGeometrickyTvar[] poleTvaru = new IGeometrickyTvar[] { trojuhelnik, ctverec, kruh };

            foreach (IGeometrickyTvar tvar in poleTvaru)
            {
                Console.WriteLine("Obsah: " + tvar.GetObsah());
                Console.WriteLine("Obvod: " + tvar.GetObvod());
            }

            Console.ReadKey();
        }
    }
}
