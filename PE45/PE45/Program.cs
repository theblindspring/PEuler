using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE45
{
    class Program
    {
        static void Main(string[] args)
        {

            for (long i =1000; i < int.MaxValue; i++)
            {
                long hexNum = i * (2 * i - 1);

                if (isPent(hexNum) && isTri(hexNum))
                {
                    Console.WriteLine(hexNum);
                    break;
                }
                

                

            }
            Console.WriteLine("DONE");
            Console.Read();
        }

        public static bool isPent(long num)
        {
            double evaluation = (Math.Sqrt(24 * num + 1) + 1) / 6;

            return evaluation - (int)evaluation == 0;

            

        }

        public static bool isTri(long num)
        { 
        double evaluation = (Math.Sqrt(8*num+1)-1)/2;
        return evaluation - (int)evaluation == 0;
      
        }
    }
}
