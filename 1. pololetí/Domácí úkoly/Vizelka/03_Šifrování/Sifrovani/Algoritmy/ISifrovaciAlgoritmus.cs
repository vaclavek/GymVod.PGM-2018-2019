using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani.Algoritmy
{
	internal interface ISifrovaciAlgoritmus
	{
		string Nazev { get; }

		string Zasifruj(string text);

		string Rozsifruj(string text);
	}
}
