using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani.Algoritmy
{
	internal class Pozpatku : ISifrovaciAlgoritmus
	{
		public string Nazev => "Šifrování pozpátku";

		public string Rozsifruj(string text)
		{
			return VratTextPozpatku(text);
		}

		public string Zasifruj(string text)
		{
			return VratTextPozpatku(text);
		}

		private static string VratTextPozpatku(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
