using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramováníTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int pocetPrvocisel = 1;

            for (int i = 3; i <= 9876543; i+=2)
            {
                bool jePrvocislo = true;
                
                for (int j = 3; j < i; j++)
                {
                    if (i%j == 0)
                    {
                        jePrvocislo = false;
                        break;
                    }
                }
                if (jePrvocislo == true)
                {
                    pocetPrvocisel++;
                    Console.WriteLine("{0} je", i);
                }
            }

            Console.WriteLine("Pocet prvocisel mezi 1 a 9 876 543 je:");
            Console.WriteLine(pocetPrvocisel); //trvá to déle, ten algoritmus by se dal naprogramovat lépe. Ale postup je podle mě správně =)

            Console.ReadKey();
        }
    }
}
