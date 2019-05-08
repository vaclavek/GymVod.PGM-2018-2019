using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DatoveTypy
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Zadejte vstup, který program převede na různé datové typy.");

			string vstup = Console.ReadLine();

			ConvertInputToByte(vstup);
			ConvertInputToInt(vstup);
			ConvertInputToLong(vstup);
			ConvertInputToFloat(vstup);
			ConvertInputToDouble(vstup);
			ConvertInputToBool(vstup);
			ConvertInputToChar(vstup);

			Console.WriteLine("Konec programu.");
		}

		static void ConvertInputToByte(string vstup)
		{
			try
			{
				byte vstupByte = Convert.ToByte(vstup);
				Console.WriteLine("Vstup převedený na číslo: " + vstupByte);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není číslo typu byte.");
				return;
			}
		}

		static void ConvertInputToInt(string vstup)
		{
			try
			{
				int vstupInt = Convert.ToInt32(vstup);
				Console.WriteLine("Vstup převedený na číslo: " + vstupInt);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není číslo typu int.");
				return;
			}
		}

		static void ConvertInputToLong(string vstup)
		{
			try
			{
				long vstupLong = Convert.ToInt64(vstup);
				Console.WriteLine("Vstup převedený na číslo: " + vstupLong);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není číslo typu long.");
				return;
			}
		}

		static void ConvertInputToFloat(string vstup)
		{
			try
			{
				float vstupFloat = Convert.ToSingle(vstup);
				Console.WriteLine("Vstup převedený na číslo: " + vstupFloat);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není číslo typu float.");
				return;
			}
		}

		static void ConvertInputToDouble(string vstup)
		{
			try
			{
				double vstupDouble = Convert.ToDouble(vstup);
				Console.WriteLine("Vstup převedený na číslo: " + vstupDouble);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není číslo typu double.");
				return;
			}
		}

		static void ConvertInputToBool(string vstup)
		{
			try
			{
				bool vstupBool = Convert.ToBoolean(vstup);
				Console.WriteLine("Vstup převedený na logickou proměnnou: " + vstupBool);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není typu bool.");
				return;
			}
		}

		static void ConvertInputToChar(string vstup)
		{
			try
			{
				char vstupChar = Convert.ToChar(vstup);
				Console.WriteLine("Vstup převedený na znak: " + vstupChar);
			}
			catch
			{
				Console.WriteLine("Zadaný vstup není typu char.");
				return;
			}
		}
	}
}
