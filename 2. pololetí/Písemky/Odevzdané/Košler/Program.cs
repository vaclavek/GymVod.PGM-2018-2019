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
           
            int pocetPrvocisel = 0;/*

            for(int i = 4; i <= 100; i++)
            {
                for (int j = 3; j < i; j++)
                {
                    if(i % j == 0)
                    {
                        pocetPrvocisel++;
                        Console.WriteLine(i);
                        break;
                    }   
                }   
            }
            Console.WriteLine("prvocisla pocet : " + pocetPrvocisel);
            */

            //tohle je upravený kod
            for(int i = 1; i < 9876543; i++ ) { 
            if (i % 2 == 0) { }
            else
            {
                int q;
                for (int j = 2; i < (Math.Sqrt(i) + 2); i++)
                {
                    q = i % j;
                    if (q == 0) { }
                        else {
                            Console.WriteLine(i);
                        pocetPrvocisel++;
                        }
                    }
                }
            }
            Console.WriteLine(pocetPrvocisel);
        }
    }
}
