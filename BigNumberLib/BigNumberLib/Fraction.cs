using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumberLib
{
    public class Fraction
    {

        public int numerator, denominator;

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int n, int d)
        {
            numerator = n;
            denominator = d;
        }

       /* public static Fraction operator +(Fraction left, Fraction right)
        {
        
        }*/
        
    }
}
