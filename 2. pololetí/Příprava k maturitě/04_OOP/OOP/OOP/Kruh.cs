using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Kruh : ITvar
    {
        private int polomer;

        public Kruh(int polomer)
        {
            this.polomer = polomer;
        }

        public string VratInformace()
        {
            return "Kruh, polomě je " + polomer;
        }

        public decimal VypoctiObsah()
        {
            return Convert.ToDecimal(Math.PI * polomer * polomer);
        }


    }
}
