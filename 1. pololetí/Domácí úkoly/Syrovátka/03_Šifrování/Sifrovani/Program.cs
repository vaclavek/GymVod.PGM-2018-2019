using Sifrovani.Algoritmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani
{
	class Program
	{
		static void Main(string[] args)
		{
            start:
			Console.WriteLine("Zvol šifrovací algoritmus. Podporované jsou níže uvedené možnosti:");
			Console.WriteLine("1) Šifrování pozpátku");
			Console.WriteLine("2) Posun o 1 znak");
			Console.WriteLine("3) Cézarova šifra");
            Console.WriteLine("4) Morseovka");

            int cisloZvolenehoAlgoritmu;
            if (!int.TryParse(Console.ReadLine(), out cisloZvolenehoAlgoritmu)
				|| cisloZvolenehoAlgoritmu < 1
				|| cisloZvolenehoAlgoritmu > 4)
			{
				Console.WriteLine("Zadaný vstup není platný");
                goto start;
			}

			ISifrovaciAlgoritmus zvolenyAlgoritmus;
			switch (cisloZvolenehoAlgoritmu)
			{
				case 1:
					zvolenyAlgoritmus = new Pozpatku();
					break;

				case 2:
					zvolenyAlgoritmus = new Posun();
					break;

				case 3:
					zvolenyAlgoritmus = new CezarovaSifra();
					break;

                case 4:
                    zvolenyAlgoritmus = new Morseovka();
                    break;

				default:
					Console.WriteLine("Neznámý algoritmus.");
					return;
			}

			Console.WriteLine("Zvolený algoritmus: " + zvolenyAlgoritmus.Nazev);
			Console.WriteLine();
			Console.WriteLine("Zadej text na zašifrování:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Používejte pouze malá/velká písmena anglické abecedy a mezery");
			Console.ForegroundColor = ConsoleColor.Yellow;
			var textNaZasifrovani = Console.ReadLine();
			Console.ResetColor();

			var zasifrovanyText = zvolenyAlgoritmus.Zasifruj(textNaZasifrovani);
			Console.WriteLine();
			Console.WriteLine("Zašifrovaný text: ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(zasifrovanyText);
			Console.ResetColor();
			Console.WriteLine();

			var rozsifrovanyText = zvolenyAlgoritmus.Rozsifruj(zasifrovanyText);
			Console.WriteLine("Rozšifrovaný text: ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(rozsifrovanyText);
			Console.ResetColor();
			Console.WriteLine();


            Console.ReadKey();  
		}
	}
}
