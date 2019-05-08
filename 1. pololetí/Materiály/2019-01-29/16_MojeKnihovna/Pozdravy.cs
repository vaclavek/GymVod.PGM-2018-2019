using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeKnihovna
{
    public class Pozdravy
    {
        public void RekniAhoj(string jazyk)
        {
            switch (jazyk)
            {
                case "cs":
                    Console.WriteLine("Ahoj");
                    break;

                case "en":
                    Console.WriteLine("Hello");
                    break;

                case "es":
                    Console.WriteLine("Holla!");
                    break;

                case "de":
                    Console.WriteLine("Hallo");
                    break;

                case "fr":
                    Console.WriteLine("Salut!");
                    break;

                case "cn":
                    Console.WriteLine("Ni hao!");
                    break;

                default:
                    break;
            }

        }
    }
}
