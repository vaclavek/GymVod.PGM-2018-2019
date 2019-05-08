using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvocislo
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo = 0;
            bool test = true;
            for (int i = 3; i < 9876543; i++)
            {
                for (int j = i+1; j < 9876543; j++)
                {
                    if (i % j == 0)
                    {
                        test = false;
                        if ( test == false)
                        { continue; }
                    }
                    else
                    {}
                    
                    if (test == true)
                    { cislo++; }
                        
                    
                }
            }
            Console.WriteLine(cislo);
        }
    }
}
