using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        const int pocetCisel = 20;

        static void Main(string[] args)
        {
            // zadání: vygenerujte 20 náhodných čísel od 10 do 50, seřaďte je prostřednictvím bubble sort. A vypište do konzole

            var cisla = VygenerujCisla();

            BubbleSort(cisla);



        }

        static int[] VygenerujCisla()
        {
            var random = new Random();
            var cisla = new int[pocetCisel];
            for (int i = 0; i < pocetCisel; i++)
            {
                cisla[i] = random.Next(10, 50);
            }
            return cisla;
        }

        static void BubbleSort(int[] cisla)
        {
            for (int i = 0; i < pocetCisel - 1; i++)
            {
                for (int j = 0; j < pocetCisel - i - 1; j++)
                {
                    if (cisla[j] > cisla[j + 1])
                    {
                        ProhodCisla(cisla, j);
                    }
                }
            }
        }

        private static void ProhodCisla(int[] cisla, int j)
        {
            int vetsiCislo = cisla[j + 1];
            cisla[j + 1] = cisla[j];
            cisla[j] = vetsiCislo;
        }
    }
}
