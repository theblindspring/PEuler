using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigNumberLib;

namespace PE57
{
    class Program
    {

        public static Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt> two = new Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt>(new ArbitraryLargeUnsignedInt("2"), new ArbitraryLargeUnsignedInt("1"));

        static void Main(string[] args)
        {
            //float testNum = 1 + (1 / rooting(2));

            //Console.Write(testNum);

            int largeNumCount = 0;

            for (int i = 0; i < 1000; i++)
            {
                Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt> rooted = rootingFrac(i);

                rooted = new Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt>(rooted.Item2, rooted.Item1);

                Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt> frac = new Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt>(rooted.Item1 + rooted.Item2, rooted.Item2);

                Console.WriteLine(" => " + frac.Item1 + "/" + frac.Item2);

                if (frac.Item1.ToString().Length > frac.Item2.ToString().Length)
                    largeNumCount++;

            }

            Console.WriteLine("Larger Numerators = " + largeNumCount);
            
            Console.Read();
        }

        public static float rooting(int iteration)
        {
            if (iteration == 0)
                return 2;
            else
            {
                return 2 + 1 / (rooting(iteration - 1));
            }
        }

        public static Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt> rootingFrac(int iter)
        {
            if (iter == 0)
            {
                return two;
            }
            else
            {
                Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt> rooted = rootingFrac(iter - 1);
                Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt> recip = new Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt>(rooted.Item2, rooted.Item1);

                return new Tuple<ArbitraryLargeUnsignedInt, ArbitraryLargeUnsignedInt>((new ArbitraryLargeUnsignedInt("2") * recip.Item2) + recip.Item1, recip.Item2);


            
            }
        }
    }
}
