using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani.Algoritmy
{
	internal abstract class AlgoritmyPosunu : ISifrovaciAlgoritmus
	{
		public abstract string Nazev { get; }

		public abstract string Zasifruj(string text);

		public abstract string Rozsifruj(string text);

		protected virtual string Zasifruj(string text, int posun)
		{
			string output = string.Empty;

			foreach (char ch in text)
				output += PosunoutZnak(ch, posun);

			return output;
		}

		protected virtual string Rozsifruj(string text, int posun)
		{
			return Zasifruj(text, 26 - posun);
		}

		private static char PosunoutZnak(char znak, int key)
		{
			if (char.ToUpper(znak) < 'A' || char.ToUpper(znak) > 'Z')
			{
				return znak;
			}

			char prvniZnakAbecedy = char.IsUpper(znak) ? 'A' : 'a';
			int posunutyZnak = znak + key;
			int cisloPismene = posunutyZnak - prvniZnakAbecedy;
			int mod = cisloPismene % 26;
			int c = mod + prvniZnakAbecedy;
			return (char)c;
		}
	}
}
