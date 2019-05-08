using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prvocisla
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 9876543, pocitadlo = 0, xx = 2;
            int[] prvocisla = new int[max]; // Najdu-li nove prvocislo, ulozim si ho sem, abych mohl kontrolovat, jestli nejake vyssi cislo nejde vydelit prave timto prvocislem

            for (int i = 3; i < max; i++)
            {
               
                    prvocisla[0] = 2; //Definice prvniho prvocisla

                    for (int a = 1; a < xx; a++)
                    {
                        if (i % prvocisla[a-1] != 0) //Zjisteni, zda-lze vydelit cislo nejakym uz zjistenym prvocislem bezezbytku
                        {
                            prvocisla[a] = i; //Pokud ne, cislo se ulozi jako nove prvocislo a pripocita se do pocitadla
                            pocitadlo++;
                            xx++;
                        }


                    } 


            }

            Console.WriteLine(pocitadlo);
            Console.WriteLine(prvocisla[0]); Console.WriteLine(prvocisla[1]);
            Console.ReadKey();

        }
    }
}
