using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigNumberLib;
using System.Numerics;

namespace PE66
{
    class Program
    {

        //static ArbitraryLargeUnsignedInt[] squares;
        static BigInteger[] squares;

        static void Main(string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Tuple<uint, BigInteger> max = new Tuple<uint, BigInteger>(0, 0);
            for (uint i = 2; i <= 1000; i++)
            {
                if ((uint)Math.Sqrt(i) != Math.Sqrt(i))
                {
                    BigInteger xSolution = getMinimumSolution((int)i);
                    if (xSolution > max.Item2)
                    {
                        max = new Tuple<uint, BigInteger>(i, xSolution);
                    }
                  //  Console.WriteLine(i + " => " + xSolution);
                }
                
            }

            Console.WriteLine("Answer = " + max.Item1 + " => " + max.Item2);
            Console.WriteLine("DONE in " + sw.ElapsedMilliseconds + " s" );
                Console.ReadKey();
            

         

        }

        static int nearestSquare;
        static int rootNum;
        static int iteration;

        static List<int> getPeriodOfRootFraction(int rNum)
        {
            iteration = 0;
            rootNum = rNum;


            nearestSquare = (int)Math.Sqrt(rNum);

            /*     Console.WriteLine();
                 Console.WriteLine();
                 Console.Write(rootNum + " => " + nearestSquare + " => "); */

            return getIteration(nearestSquare, 0, 1, new List<int>());


        }

        static List<int> getIteration(int addNum, int oldNumerator, int oldDenom, List<int> period)
        {
            iteration++;
            addNum = oldNumerator - (addNum * oldDenom);

            //Console.WriteLine(oldNumerator + " /" + oldDenom);

            if ((rootNum - (addNum * addNum)) % oldDenom != 0)
            {
                Console.WriteLine("ERROR");
                Console.ReadLine();
            }

            int denominator = (rootNum - (addNum * addNum)) / oldDenom;

            //if (denominator == 0)
            //    return 0;

            int numerator = Math.Abs(addNum);

            addNum = (int)(numerator + nearestSquare) / denominator;

            // Console.Write(addNum);

            period.Add(addNum);

            if (numerator == nearestSquare && denominator == 1 && iteration != 0)
            //if (iteration >= 100)
            {
                return period;
            }
            else
            {
                //    Console.Write(", ");
                return getIteration(addNum, numerator, denominator, period);
            }



        }

        static BigInteger getMinimumSolution(int d)
        {
            Tuple<BigInteger, BigInteger> current = new Tuple<BigInteger, BigInteger>(3, 1), back1 = new Tuple<BigInteger, BigInteger>((int)Math.Sqrt(d), 1), back2 = new Tuple<BigInteger, BigInteger>(1, 0);
            ulong k = 1;

            List<int> mults = getPeriodOfRootFraction(d);

         //   current = new Tuple<BigInteger, BigInteger>(back1.Item1 * 1 + back2.Item1, 1 * back1.Item2 + back2.Item2);
         //   back2 = back1;
         //   back1 = current;

            for (int i = 0; true; i= (i+1)%mults.Count)
            {
          /*      ulong multiplier;
                if (i % 3 == 0)
                {
                    multiplier = (2 * k);
                    k++;
                }
                else
                {
                    multiplier = 1;
                } */
                current = new Tuple<BigInteger, BigInteger>(back1.Item1 * mults[i] + back2.Item1, mults[i] * back1.Item2 + back2.Item2);
                back2 = back1;
                back1 = current;


                if ((current.Item1 * current.Item1) - (d * current.Item2 * current.Item2) == 1)
                {
                    return current.Item1;
                }

             //   Console.WriteLine(current.Item1 + "/" + current.Item2);

            }
               
        }

      


    }
}
