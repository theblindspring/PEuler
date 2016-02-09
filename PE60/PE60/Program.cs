using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE60
{
    class Program
    {
        static bool[] isPrime;

        static int minNdx = 0;
        static List<int> primes = new List<int>();
        static void Main(string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            isPrime = MakeSieve(10000);

            

            for (int i = 0; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                    primes.Add(i);
            }

            List<int> answer = null;
            List<List<int>> possible = new List<List<int>>();

            while (primes.Count > 0)
            {
                List<int> check = new List<int>() {primes[0]};
                primes.RemoveAt(0);
                answer = RecurseList(check);
                if (answer != null) 
                {
                    possible.Add(answer);
                    break;
                }
                
            }

            

            for (int i = 0; i < possible.Count; i++)
            {
                if (possible[i].Sum() < possible[minNdx].Sum())
                {
                    minNdx = i;
                }
            }

            for (int i = 0; i < possible[minNdx].Count; i++)
            {
                Console.WriteLine(possible[minNdx][i]);
            }


                Console.WriteLine("ANSWER => " + possible[minNdx].Sum()); 



                Console.WriteLine("DONE");
            Console.Read();

        }

        private static bool isPrimeFunc(int a)
        {
            if (a == 1)
                return false;
            if (a == 2 || a == 3)
                return true;
            if ((a & 1) == 0)
                return false;
            if ((a + 1) % 6 == 0 && (a - 1) % 6 == 0)
                return false;

            int max = (int)Math.Sqrt(a) + 1;
            for (int i = 3; i < max; i+=2)
            {
                if (a % i == 0)
                    return false;
            }

            return true;

        }

        private static List<int> RecurseList(List<int> inList)
        {
            if (inList.Count == 5)
            {
                return inList;
            }
               

            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] > inList[inList.Count - 1])
                {
                  //  inList.Add(primes[i]);
                    List<int> check = new List<int>(inList);
                    check.Add(primes[i]);
                    if (allCombos(check))
                    {
                        var newList = RecurseList(check);
                        if (newList != null)
                            return newList;
                    }
                }
               /* for (int j = i + 1; j < inList.Count; j++)
                {
                    if (!checkCat(inList[i], inList[j]))
                    {
                        inList.RemoveAt(j);
                        return RecurseList(inList);
                    }
                } */
                
            }

         /*   if (inList.Count > 5)
            { 
                inList.RemoveAt(inList.Count-1);
                return RecurseList(inList);
            } */

            return null;

               /* for (int i = 0; i < isPrime.Length; i++)
                {
                    if (isPrime[i])
                    {

                    }
                } */
        }

        private static bool checkCat(int num1, int num2)
        {
            string num1s = num1.ToString();
            string num2s = num2.ToString();

            return (isPrimeFunc(int.Parse(num1s + num2s)) && isPrimeFunc(int.Parse(num2s + num1s)));
        }

       

        private static bool allCombos( List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                   
                        int parsed = int.Parse(input[i].ToString() + input[j].ToString());
                        if ( !isPrimeFunc(parsed))
                            return false;

                        parsed = int.Parse(input[j].ToString() + input[i].ToString());
                        if (!isPrimeFunc(parsed))
                            return false;
                   
                    

                }
            }
            return true;
          /*  int checkNum = int.Parse(v1.ToString() + v2.ToString());
            if (!isPrime[checkNum])
                return false;

            checkNum = int.Parse(v2.ToString() + v1.ToString());
            if (!isPrime[checkNum])
                return false; */


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
