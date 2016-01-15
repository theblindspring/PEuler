using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE49
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            bool[] isPrime = Enumerable.Repeat(true, 10000).ToArray();
            int[] differenceCounts = Enumerable.Repeat(0, 10000).ToArray();

            for (int i = 2; i < 100; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < 10000; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 1000; i < isPrime.Length; i++)
            {
                if(isPrime[i])
                {

                    for (int j = i + 1; j < isPrime.Length; j++)
                    { 
                        if(isPrime[j])
                        {
                            int delta = j - i;
                           // for (int k = j + 1; k < isPrime.Length; k++)
                          //  {
                                if (j+delta < isPrime.Length && isPrime[j+delta] && arePermutations(i.ToString(), j.ToString(), (j+delta).ToString()))
                                {

                                    Console.WriteLine(i.ToString() + j.ToString() + (j + delta).ToString());

                                    differenceCounts[delta]++;
                                }
                          //  }
                               
                        }
                
                    }
                }
                
            }

            for (int i = 0; i < differenceCounts.Length; i++)
            {
                if (differenceCounts[i] == 2)
                {
                    Console.WriteLine(i.ToString());
                }
            }

            Console.WriteLine(differenceCounts[3330]);

                stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);

            Console.ReadLine();






        }

        static bool arePermutations(string s1, string s2, string s3)
        {
          //  if (s1.Length != s2.Length || s2.Length != s3.Length || s1.Length != s3.Length)
          //      return false;

            for (int i = 0; i < s1.Length; i++)
            {
                if (!s2.Contains(s1[i]) || !s3.Contains(s1[i]))
                    return false;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!s1.Contains(s2[i]) || !s3.Contains(s2[i]))
                    return false;
            }

            for (int i = 0; i < s3.Length; i++)
            {
                if (!s1.Contains(s3[i]) || !s2.Contains(s3[i]))
                    return false;
            }

            return true;

        }
    }
}
