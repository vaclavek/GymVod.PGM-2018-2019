using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Kvadraticka_Rovnice
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Tento program počítá diskriminant v kvadratické rovnici a vyšetřuje její vlastnosti.");
			Console.WriteLine("Rovnice bude zadána ve tvaru a * x^2 + b * x + c = 0.");
			/* 
			 * Např. x^2 + 7 * x + 12 = 0 
			 * a = 1
			 * b = 7
			 * c = 12
			 */
			Console.Write("Zadejte a = ");
			var a = Console.ReadLine();
			Console.Write("Zadejte b = ");
			var b = Console.ReadLine();
			Console.Write("Zadejte c = ");
			var c = Console.ReadLine();

			Console.WriteLine("");

            int aInt;
            int bInt;
            int cInt;

            if (!int.TryParse(a, out aInt)
				|| !int.TryParse(b, out bInt)
				|| !int.TryParse(c, out cInt))
			{
				Console.WriteLine("Všechny koeficienty musí být čísla.");
				return;
			}

			if (aInt == 0)
			{
				Console.WriteLine("Funkce není kvadratická, ale lineární.");
				return;
			}
			else if (aInt > 0)
			{
				Console.WriteLine("Funkce je omezená zdola.");
				Console.WriteLine("Funkce je konvexní.");
			}
			else
			{
				Console.WriteLine("Funkce je omezená zdola (má tvar A)");
				Console.WriteLine("Funkce je konkávní.");
			}

			if (bInt == 0)
			{
				Console.WriteLine("Funkce je sudá.");
			}

			var d = bInt * bInt - 4 * aInt * cInt;
			if (d < 0)
			{
				Console.WriteLine("Rovnice nemá řešení v oboru reálných čísel.");
				return;
			}

			if (d == 0)
			{
				Console.WriteLine("Rovnice má dva stejné reálné kořeny.");
			}
			else
			{
				Console.WriteLine("Rovnice má dva stejné reálné kořeny.");
			}

			var x1 = (-1 * bInt + Math.Sqrt(d)) / (2 * aInt);
			var x2 = (-1 * bInt - Math.Sqrt(d)) / (2 * aInt);

			Console.WriteLine("Rovnice má řešení x1 = " + x1 + ", x2 = " + x2);
		}
	}
}
