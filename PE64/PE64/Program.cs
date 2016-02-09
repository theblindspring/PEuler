using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE64
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 2; i <= 10000; i++)
            {
                int period = getPeriodOfRootFraction(i);
                if (Math.Sqrt(i) - (int)Math.Sqrt(i) != 0 && period%2 != 0)
                {
                    count++;
                     
                    Console.WriteLine(" period = " + period);
                }

                Console.WriteLine(i + " => " +period);


            }

            Console.WriteLine();
            Console.WriteLine("ANSWER = " + count);
            Console.WriteLine("DONE");
            Console.ReadKey();

        }

        static int nearestSquare;
        static int rootNum;
        static int iteration;

        static int getPeriodOfRootFraction(int rNum)
        {
            iteration = 0;
            rootNum = rNum;


            nearestSquare = (int)Math.Sqrt(rNum);

       /*     Console.WriteLine();
            Console.WriteLine();
            Console.Write(rootNum + " => " + nearestSquare + " => "); */

            return getIteration(nearestSquare, 0, 1);


        }

        static int getIteration(  int addNum, int oldNumerator, int oldDenom)
        { 
            iteration++;
            addNum = oldNumerator - (addNum*oldDenom);

            Console.WriteLine(oldNumerator + " /" + oldDenom);

            if((rootNum - (addNum*addNum))%oldDenom != 0)
            {
                Console.WriteLine("ERROR");
                Console.ReadLine();
            }

            int denominator = (rootNum - (addNum*addNum))/oldDenom;

            if (denominator == 0)
                return 0;

            int numerator = Math.Abs(addNum);

            addNum = (int)(numerator + nearestSquare) / denominator;

           // Console.Write(addNum);


            if (numerator == nearestSquare && denominator == 1 && iteration != 0)
            //if (iteration >= 100)
            {
                return iteration;
            }
            else
            {
            //    Console.Write(", ");
                return getIteration(addNum, numerator, denominator);
            }



        }


    }
}
