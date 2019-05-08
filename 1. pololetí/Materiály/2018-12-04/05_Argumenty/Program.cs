using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argumenty
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Zadejte dva argumenty programu.");
                return;
            }

            Console.WriteLine(Convert.ToInt32(args[0]) + Convert.ToInt32(args[1]));

        }
    }
}
