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
            Console.WriteLine("Zadej prvočíslo");
            int prvocislo = Convert.ToInt32(Console.ReadLine());
            
            int vysledek = 0;
            for (int i = 2; i < prvocislo; i++)
            {
                vysledek = prvocislo % i;
                if (vysledek == 0)
                {
                    Console.WriteLine("není to prvočíslo");
                    return;
                }
                
                    
            } 

        }
    }
}
