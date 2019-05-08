using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTestík
{
    class Program
    {
        static void Main(string[] args) 
        {
            int max = 9876543;

            int counter = 1; //předem víme že 2 je prvocíšlo, budeme postrupovat jen po lichých, počítáním dvojky by se nám to protáhlo
            for(int procesovaneCilso = 3;procesovaneCilso <= max;procesovaneCilso +=2)
            {
                bool prvocislo = true;
                int odmocina = Convert.ToInt32(Math.Sqrt(procesovaneCilso) + 1);
                for(int i = 3;i <= odmocina;i++)
                {
                    if (procesovaneCilso != i)
                    {
                        if (procesovaneCilso % i == 0)
                        {
                            prvocislo = false;
                        }
                    }
                }
                if(prvocislo == true)
                {
                    counter++;
                    //Console.WriteLine(procesovaneCilso);
                }
            }


            Console.Write("Prvocisel je: " + counter);


            Console.ReadKey();
        }
    }
}
