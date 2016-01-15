using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
         


            long max = 0;
            for (long i = 7654321; i >= 0; i-=2)
            {
                if (IsPrime(i))
                {
                    string s = i.ToString() + " is pandigital";
                    if (isPandigital(i))
                    {
                        s += " and prime";
                        Console.WriteLine(s);
                    }
                    
                    max = i;
                }
            }
            Console.WriteLine(max); 
            Console.WriteLine("done");
                Console.ReadLine(); 

        }

        static bool IsPrime(long number)
        {	// Given:   num an integer > 1
            // Returns: true if num is prime
            // 			false otherwise.

            long i;

            for (i = 2; i < number/2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static bool isPandigital(long input)
        {
            string s = input.ToString();
          

            for (int i = 1; i <= s.Length; i++)
            {
                if (!s.Contains(i.ToString()))
                    return false;
            }

         
            
            return true;

        }



        

    }
}
