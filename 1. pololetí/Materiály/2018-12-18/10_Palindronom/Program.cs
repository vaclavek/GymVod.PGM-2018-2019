using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte text, který otestujeme, zda je palindronom.");
            string text = Console.ReadLine();
            Console.WriteLine("První způsob: " + JePalindronom1(text));
            Console.WriteLine("Druhý způsob: " + JePalindronom2(text));
            Console.ReadKey();
        }

        private static bool JePalindronom1(string text)
        {
            text = text.Replace(" ", "");
            text = text.ToLower();

            int x = 0, y = text.Length - 1;

            while (x < y)
            {
                char a = text[x];
                char b = text[y];
                if (a != b)
                {
                    break;
                }

                x++;
                y--;
            }

            if (x < y)
            {
                return false;
            }


            return true;
        }

        private static bool JePalindronom2(string text)
        {
            text = text.Replace(" ", "").ToLower();
            return text.SequenceEqual(text.Reverse());
        }


    }
}
