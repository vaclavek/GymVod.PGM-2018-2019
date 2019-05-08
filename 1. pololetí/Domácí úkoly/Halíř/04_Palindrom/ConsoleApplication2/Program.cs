using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napiš text palindronomu");
            string text = Console.ReadLine();
            Console.WriteLine("První způsob: " +JePalindronom1(text));
            Console.WriteLine("Druhý způsob: " + JePalindronom2(text));
            Console.WriteLine("Třetí způsob: " + JePalindronom3(text));
            Console.ReadKey();

        
        }
        private static bool JePalindronom1(string text)
        {
            text = text.Replace(" ", "");
            text = text.ToLower();
            int x=0, y= text.Length-1;

            while (x < y)
            {
                char a, b;
                a = text[x];
                b = text[y];
                if (a != b)
                {
                    return false;
                }
                else
                {
                    x++;
                    y--;
                }
            }
                return true;
        }
        private static bool JePalindronom2(string text)
        {
            text=text.Replace(" ", "").ToLower();
            return text.SequenceEqual(text.Reverse());

        }
        private static bool JePalindronom3 (string text)
        {
            text = text.Replace(" ", "").ToLower();
            for (int i=0; i<(text.Length/2)+1;i++) //řešení i<"hodnota" je zde kvůli ošetření proti lichému počtu znaků a zkrácení procesu
            {
                char a = text[i];
                char b = text[text.Length - i - 1];
                if (a != b)
                    return false;
            }
            return true;



        }
    }
}
