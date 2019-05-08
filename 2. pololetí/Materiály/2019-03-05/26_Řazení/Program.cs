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
            var list = new List<int>();
            Random rnd = new Random();
            for (int h = 0 ; h<1000; h++) {
              
                int e = rnd.Next(1, 99);
                list.Add(e);
            }

            BubleSort a = new BubleSort();
            int[] j = a.Serad(list.ToArray());
            for (int delka = 0; delka < j.Length; delka++)
            {
                Console.Write(j[delka] + " ");
            }
      
            Console.Read();
        }
    }
}
