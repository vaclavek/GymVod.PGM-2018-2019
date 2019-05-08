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
            int delitelu = 0;
            int prvocisel = 0;

            for (int i = 2; i <= 9876543; i++)
            {
                int n = 1;

                while (n<i)
                {
                        if ((i % n) == 0)
                        {
                                delitelu++;

                             if (delitelu == 2)
                                 prvocisel++;
                        delitelu = 0;
                        }
                    n++;
                }
                n = 2;
            }

            Console.WriteLine("Od 1 do 9876543 je " +prvocisel);
            Console.ReadKey();
        }
    }
}
