using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE47
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

            bool previousHas4 = false;
            int previousCount = 0;
            for (int i = 646; i < 1000000; i++)
            {
                List<int> nums = new List<int>();
                int count = 0 ;
                if ( !isPrime[i])
                {
                    int j = 2;
                    int result = i;
                    while (j <= i/2)
                    {

                           bool added = false;
                           while (result % j == 0 && result > 0)
                           {
                               result = result / j;
                               nums.Add(j);

                               if (!added)
                               {
                                   added = true;
                                   count++;
                               }

                           } 
                        j++;
                        while (!isPrime[j]) j++;
                    }

                   
                    

                    
                }

                if (count == 4)
                {
                    previousCount++;
                    previousHas4 = true;
                }
                else
                {
                    previousCount = 0;
                    previousHas4 = false;
                }

                if (previousCount == 4)
                {
                    Console.WriteLine("INDEX = " + i.ToString());
                    int mult = 1;
                    for (int k = 0; k < nums.Count; k++)
                    {
                        Console.WriteLine(nums[k]);
                        mult *= nums[k];
                    }
                    stopwatch.Stop();
                    Console.WriteLine("------- " + mult + " ------- " + stopwatch.Elapsed + " -------");
                    break;
                }

               

            }

            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
