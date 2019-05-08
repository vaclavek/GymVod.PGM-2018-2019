using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani.Algoritmy
{
	internal class CezarovaSifra : AlgoritmyPosunu
	{
		public override string Nazev { get; } = "Cézarova šifra";

		public override string Zasifruj(string text)
		{
			return Zasifruj(text, 3);
		}

		public override string Rozsifruj(string text)
		{
			return Rozsifruj(text, 3);
		}
	}
}
