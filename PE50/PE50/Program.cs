using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE50
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            bool[] isPrime = Enumerable.Repeat(true, 1000000).ToArray();

            for (int i = 2; i < 1000; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < 1000000; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            int maxCount = 0;
            int maxPrime = 0;

         //   List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    int sum = i;
                    int count = 1;
                    for (int j = i + 1; j < isPrime.Length && sum < 1000000; j++)
                    {
                        if (isPrime[j])
                        {

                            if (isPrime[sum])
                            {
                                if(count > maxCount)
                                {
                                    maxCount = count;
                                    maxPrime = sum;

                                }
                              //  pairs.Add(new Tuple<int, int>(count, sum));
                              //  Console.WriteLine(count + " -- " + sum);
                            }

                            sum += j;
                            count++;

                        }
                    }
                }
               
            }

            Console.WriteLine("Max Prime: " + maxPrime);

            Console.Read();
        }
    }
}
