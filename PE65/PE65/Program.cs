using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigNumberLib;
using System.Numerics;

namespace PE65
{
    class Program
    {
        static void Main(string[] args)
        {

            Tuple<BigInteger, BigInteger> current = new Tuple<BigInteger, BigInteger>(3, 1), back1 = new Tuple<BigInteger, BigInteger>(2, 1), back2 = new Tuple<BigInteger, BigInteger>(1, 0);
            ulong k = 1;
            
            for (ulong i = 2; i <= 100; i++)
            {
                ulong multiplier;
                if (i % 3 == 0)
                {
                    multiplier = (2 * k);
                    k++;
                }
                else
                {
                    multiplier = 1;
                } 
                current = new Tuple<BigInteger,BigInteger>(back1.Item1 * multiplier + back2.Item1, multiplier*back1.Item2 + back2.Item2);
                back2 = back1;
                back1 = current;

                Console.WriteLine(current.Item1 + "/" +current.Item2);

            }

            string digits = current.ToString();
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += int.Parse(digits[i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ANSWER => " + sum);

                Console.WriteLine("DONE");
            Console.Read();
        }



      
    }
}
