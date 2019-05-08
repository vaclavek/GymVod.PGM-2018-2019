using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocetPrvocisel
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> prvocisla = new List<int>();
            

            for (int i = 2; i < 10; i++)
            {
                for (int j = 2; j < i-1; j++)
                {

                    if (i % j == 0)
                    {
                        prvocisla.Add(1);
                    }
                    
                }
            }

            Console.WriteLine(prvocisla.Count);

        }
    }
}
