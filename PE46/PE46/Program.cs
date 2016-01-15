using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE46
{
    class Program
    {
        static void Main(string[] args)
        {
           
            bool[] isPrime = Enumerable.Repeat(true, 1000000).ToArray();
            bool[] passesTest = Enumerable.Repeat(true, 1000000).ToArray();

            var mPerTick = 1000f / System.Diagnostics.Stopwatch.Frequency;
            var stopWatch = System.Diagnostics.Stopwatch.StartNew(); 

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

            int notPrimeCount = 0;
            for (int i = 3; i < isPrime.Length; i++)
            {

                
                if (isPrime[i])
                {
                    int ndx;
                    int j = 0;
                    while ((ndx = i + 2*j*j) < isPrime.Length)
                    {
                        passesTest[ndx] = false;
                        j++;
                    }
                }
                
            }

            for (int i = 3; i < isPrime.Length; i++ )
            {
                if (i%2 != 0 && passesTest[i])
                {
                    Console.WriteLine(i.ToString());
                    break;
                }
                
            }
            stopWatch.Stop();
                Console.WriteLine("DONE - " + stopWatch.ElapsedTicks*mPerTick);
            Console.ReadLine();



        }
    }
}
