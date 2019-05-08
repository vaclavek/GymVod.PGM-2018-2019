using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani.Algoritmy
{
    internal class Morseovka : ISifrovaciAlgoritmus
    {
        public string Nazev { get; } = "Morseova abeceda";

        Dictionary<string, string> DictMorse = new Dictionary<string, string>()
        {
            {"a" , ".-"},
            {"b" , "-..." },
            {"c" , "-.-." },
            {"d" , "-.."},
            {"e" , "."},
            {"f" , "..-."},
            {"g" , "--."},
            {"h" , "...."},
            {"i" , ".."},
            {"j" , ".---"},
            {"k" , "-.-"},
            {"l" , ".-.."},
            {"m" , "--"},
            {"n" , "-."},
            {"o" , "---"},
            {"p" , ".--."},
            {"q" , "--.-"},
            {"r" , ".-."},
            {"s" , "..."},
            {"t" , "-"},
            {"u" , "..-"},
            {"v" , "...-"},
            {"w" , ".--"},
            {"x" , "-..-"},
            {"y" , "-.--"},
            {"z" , "--.."},
        };
        
        

        
		public string Rozsifruj(string text)
		{
            string output = string.Empty;
            string cell = string.Empty;
            bool skip = false;

            foreach(char ch in text)
            {
                if (!skip)
                {
                    switch (ch)
                    {
                        case '.':
                            cell += ".";
                            break;

                        case '-':
                            cell += "-";
                            break;

                        case '?':
                            {
                                output += "?";
                                skip = true;
                            }
                            break;

                        case '/':
                            {
                                output += " ";
                            }
                            break;

                        case ' ':
                            {
                                output += DictMorse.FirstOrDefault(x => x.Value == cell).Key;  //použito stackoverflow
                                cell = string.Empty;
                            }
                            break;
                    }
                }
                else
                {
                    skip = false;
                }
            }


			// TODO: Domácí úkol :)
			return output;
		}

		public string Zasifruj(string text)
		{

            string output = string.Empty;

            foreach(char ch in text)
            {

                if (Char.IsWhiteSpace(ch))
                {
                    output += "/ ";
                }
                else
                {
                    char lowch = char.ToLower(ch);

                    if (DictMorse.ContainsKey(Convert.ToString(lowch)))
                    {
                        output += DictMorse[Convert.ToString(lowch)] + " ";
                    }
                    else
                    {
                        output += "? ";
                    } 
                }
            }

			return output;
		}
	}
}
