using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pismeka
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 9876543;
            int min = 1;
            int pocetPrvocisel = 0;
            int pocetDelitelu = 0;

            for (int i = max; i > min; i--)
            {
                
                for (int j = 2; j < i; j++)
                {
                    double me = i % j;
                    if (me == 0)
                    {

                        pocetDelitelu++;
                       
                    }
                    else
                    {

                        pocetPrvocisel++;
                        
                    }
                    Console.WriteLine(pocetPrvocisel);
                }





            }
            Console.WriteLine(pocetPrvocisel);               
        }
    }
}
