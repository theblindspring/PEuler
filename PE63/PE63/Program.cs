using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigNumberLib;

namespace PE63
{
    class Program
    {
        static void Main(string[] args)
        {
            int powDigitCount = 0;
            for (int i = 1; i < 25; i++)
            {
                
                    for (ArbitraryLargeUnsignedInt j = new ArbitraryLargeUnsignedInt("1"); true; j += 1)
                    //for (ulong j = 4; true; j++)
                    {
                      //  Console.WriteLine(j);
                        ArbitraryLargeUnsignedInt num = new ArbitraryLargeUnsignedInt("1");
                        // ulong num = 1;
                        for (int k = 0; k < i; k++)
                        {

                            num *= j;
                        }

                        if (num.ToString().Length > i)
                            break;
                        else if (num.ToString().Length == i)
                        {
                            powDigitCount++;
                            Console.WriteLine(j + "^" + i + " = " + num.ToString() + " LEN => " + num.ToString().Length);
                        }


                    }
            }

            Console.WriteLine("Possible Answer = " + powDigitCount);

            Console.Read();

        }
    }
}
