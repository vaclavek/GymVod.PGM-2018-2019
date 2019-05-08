using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_vysek
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 1;
            int PocetPrvocisel = 0;
            int a;
            List<int> y; 
            for (x; x <= 9876543; x++)
            {
                y[x-1] = x;
            }
            foreach (int in y)
            {
                if ((y[x] / y[1]) != 0|| ((y[x] / y[x-1]) != 0 || ((y[x] / y[1]) != 0 ||)
                { PocetPrvocisel++; }
                else {
                    y[x]=1;
                }
            }
            Console.WriteLine(PocetPrvocisel);
            Console.ReadKey();
        }
    }
}
