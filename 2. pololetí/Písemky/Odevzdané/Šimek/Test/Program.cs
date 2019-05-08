using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int pocetPrvoCisel = 0;
            for (int i = 2; i <= 9876543; i++)
            {
                    if(IsPrime(i)==true)
                    {
                        pocetPrvoCisel++;    
                    }  
            }
            Console.WriteLine("Pocet prvocisel je " + pocetPrvoCisel);
            Console.ReadKey();   
        }
    }
}
