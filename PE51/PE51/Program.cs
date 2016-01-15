using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE51
{
    class Program
    {
        static bool[] isPrime = Enumerable.Repeat(true, 1000000).ToArray();

        static void Main(string[] args)
        {
            
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();


          

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

            for (int i = 1000; i < 1000000; i++)
            {
                if (isPrime[i] && contains2ofDigit(i.ToString()) &&  getMaxNumPrimes(i.ToString()))
                {
                   break;
                }
            }

            Console.WriteLine("Done - " + sw.ElapsedMilliseconds);
            Console.ReadLine();

        }

        static bool contains2ofDigit(string num)
        {
            for (int i = 0; i < num.Length - 1; i++)
            {
                if (num.Substring(i + 1).Contains(num[i].ToString()))
                {
                    return true;
                }
            }

            return false;
        }

       
        static bool getMaxNumPrimes(string s)
        {
            int minPrime = 0;
            int tempCount = 1;
            int maxCount = 1;
            
            
               
                for (int j = 0; j < s.Length; j++)
                {
                    for (int k = j + 1; k < s.Length; k++)
                    {
                        for (int x = k + 1; x < s.Length; x++)
                        {
                            
                                tempCount = 1;
                                HashSet<int> primes = new HashSet<int>();
                                for (int i = 0; i < 10; i++)
                                {
                                    char iLetter = i.ToString()[0];
                                    StringBuilder buffString = new StringBuilder(s);
                                    buffString[j] = iLetter;
                                    buffString[k] = iLetter;
                                    buffString[x] = iLetter;
                                    int newInt = int.Parse(buffString.ToString());

                                    if (newInt < isPrime.Length && isPrime[newInt])
                                    {
                                        if (primes.Count > 0 && primes.Last().ToString().Length != buffString.ToString().Length)
                                        {
                                            primes.Clear();
                                        }
                                        //   isPrime[newInt] = false;
                                        primes.Add(newInt);
                                    }


                                    if (tempCount > maxCount)
                                    {
                                        maxCount = tempCount;
                                        minPrime = int.Parse(s.ToString());
                                    }



                                    if (primes.Count == 8)
                                    {
                                        foreach (int num in primes)
                                        {
                                            Console.WriteLine(num);
                                        }
                                        return true;
                                    }

                                }
                            
                             
                        }
                        
                    }
                }
                return false;   
        }

    }
}
