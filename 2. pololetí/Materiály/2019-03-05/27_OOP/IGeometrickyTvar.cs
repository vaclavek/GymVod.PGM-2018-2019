using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zkouseni_OOP
{
    interface IGeometrickyTvar
    {
        double GetObsah();
        double GetObvod();
    }

    public class Ctverec : IGeometrickyTvar
    {
        double strana;
        public Ctverec(double strana)
        {
            this.strana = strana;
        }
        public double GetObsah()
        {
            return strana * strana;
        }

        public double GetObvod()
        {
            return strana * 4;
        }
    }

    public class Kruh : IGeometrickyTvar
    {
        double polomer;
        public Kruh(double polomer)
        {
            this.polomer = polomer;
        }
        public double GetObsah()
        {
            return polomer * polomer * Math.PI;
        }

        public double GetObvod()
        {
            return polomer * 2 * Math.PI;
        }
    }

    public class Trojuhelnik : IGeometrickyTvar
    {
        double a;
        double b;
        double c;
        public Trojuhelnik(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double GetObsah()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt((s - a) * (s - b) * (s - c) * s);
        }

        public double GetObvod()
        {
            return a + b + c;
        }
    }
}
