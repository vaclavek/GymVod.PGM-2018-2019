using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zkouseni_DEC_to_BIN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej cislo");
            string binNum = Console.ReadLine();
            int decimalNum = Convert.ToInt32(Console.ReadLine());
            string bin2Num = DesitkovaDoDvojkove(decimalNum);
            Console.WriteLine(bin2Num);

            Console.WriteLine(DvojkovaDoDesitkove(binNum));
        }

        private static string DvojkovaDoDesitkove(string binNum)
        {
            double decimalNum = 0;

            for (int i = 0; i < binNum.Length; i++)
            {
                int konstanta = binNum[binNum.Length - i - 1] == '1' ? 1 : 0;
                decimalNum += konstanta * Math.Pow(2, i);
            }
            return decimalNum.ToString();
        }

        private static string DesitkovaDoDvojkove(int decimalNum)
        {
            string binNum = "";
            do
            {
                binNum = (decimalNum % 2) + binNum;
                decimalNum = decimalNum / 2;
            }
            while (decimalNum >= 1);

            return binNum;
        }
    }
}
