using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE58
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isPrime = MakeSieve(int.MaxValue/2);
            List<long> diagonals = new List<long>();

            diagonals.Add(1);

            int incr = 2;

            float ratio = 1;
            int pCount = 0;
            for (int i = 0; ratio >= .1; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    diagonals.Add(diagonals[diagonals.Count - 1] + incr);

                    if (isPrime[diagonals[diagonals.Count - 1]])
                    {
                        pCount++;
                    }
                }

                ratio = pCount / (float)diagonals.Count;

                Console.WriteLine(ratio);

                if (ratio < .1)
                {
                    Console.WriteLine("NUM ROWS = " + ((diagonals.Count + 1) / 2));
                    break;
                }

                incr += 2;
            }

          

                Console.Read();

        }

        private static bool[] MakeSieve(int max)
        {
            // Make an array indicating whether numbers are prime.
            bool[] is_prime = new bool[max + 1];
            for (int i = 2; i <= max; i++) is_prime[i] = true;

            // Cross out multiples.
            for (int i = 2; i <= max; i++)
            {
                // See if i is prime.
                if (is_prime[i])
                {
                    // Knock out multiples of i.
                    for (int j = i * 2; j <= max; j += i)
                        is_prime[j] = false;
                }
            }
            return is_prime;
        }

      

    }
}
