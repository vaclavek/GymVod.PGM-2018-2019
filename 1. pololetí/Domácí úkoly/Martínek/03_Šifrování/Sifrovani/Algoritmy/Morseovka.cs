using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sifrovani.Algoritmy
{
	internal class Morseovka : ISifrovaciAlgoritmus
	{
		public string Nazev { get; } = "Morseova abeceda";

		public string Rozsifruj(string text)
		{
            string[] znaky = text.Split('/');
            string output = "";

            foreach(string znak in znaky)
            {
                if (znak == "?") output += "?";
                else if (ASCII.Contains<string>(znak))
                {
                    for (int i = 0; i < ASCII.Length; i++) if (ASCII[i] == znak)
                        {
                            output += (char)(i + 32);
                            break;
                        }
                }
                else output += "?";
            }

			return output;
		}

		public string Zasifruj(string text)
		{
            text = text.ToUpper();

            string output = "";

            foreach(char c in text)
            {
                if (c >= 32 && c < 96)
                {
                    int index = c - 32;
                    output += ASCII[index] + "/";
                }
            }

			return output;
		}
        //  32 až 95
        string[] ASCII =
        {
            //20 - 2F
            // MEZ ! " # $
            "","-.-.--",".-..-.","?","...-..-",
            // % & ' ( )
            "?",".-...",".----.","-.--.","-.--.-",
            // * + , - . /
            "?",".-.-.","--..--","-....-",".-.-.-","-..-.",
            //30 - 3F
            // 0 - 9
            "-----",".----","..---","...--","....-",
            ".....","-....","--...","---..","----.",
            //: ; < = >
            "---...","-.-.-.","?","-...-","?","..--..",
            //40 - 5F
            // @ A - Z
            ".--.-.",".-","-...","-.-.","-..",".",
            "..-.","--.","....","..",".---",
            "-.-",".-..","--","-.","---",
            ".--.","--.-",".-.","...","-",
            "..-","...-",".--","-..-","-.--","--..",
            // [ \ ] ^ _
            "?","?","?","?","..--.-"
        };
    }
}
