using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani.Algoritmy
{
	internal class Posun : AlgoritmyPosunu
	{
		public override string Nazev { get; } = "Posun o 1 znak";

		public override string Zasifruj(string text)
		{
			return Zasifruj(text, 1);
		}

		public override string Rozsifruj(string text)
		{
			return Rozsifruj(text, 1);
		}
	}
}
