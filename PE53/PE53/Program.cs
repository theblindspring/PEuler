using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE53
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            ulong millCount = 0;
            for (ulong n = 2; n <= 100; n++)
            {
                for (ulong r = 1; r <= n; r++)
                {
                    ulong [] nAr = new ulong[n];
                    ulong[] rAr = new ulong[r];
                    ulong[] diffAr = new ulong[n - r];
                    for (ulong i = 0; i < n; i++)
                    {
                        nAr[i] = i + 1;
                        if (i < r)
                            rAr[i] = i + 1;
                        if (i < n - r)
                            diffAr[i] = i + 1;


                    }

                    ulong answer = solve(nAr, rAr, diffAr);

                    if (answer > 1000000)
                    {
                        millCount += (n - 2 * r) + 1;
                    Console.WriteLine( n + " choose " + r + " = " + answer + " -- millcount = " + millCount);
                //    Console.ReadLine();
                //    millCount++;
                   
                    break;
                    }

                }
            }

               Console.WriteLine("ANSWER = " + millCount + " -- " + sw.ElapsedMilliseconds + " ms");
                Console.ReadLine();
        }

        static ulong solve(ulong[] top, ulong[] bot1, ulong[] bot2)
        {
            for (int i = 0; i < bot1.Length; i++)
            {
                for (int j = 0; j < top.Length; j++)
                {
                    if (bot1[i] != 1 && top[j] % bot1[i] == 0)
                    {
                        top[j] /= bot1[i];
                        bot1[i] = 1;
                        break;
                    }

                }
            }

            for (int i = 0; i < bot2.Length; i++)
            {
                for (int j = 0; j < top.Length; j++)
                {
                    if (bot2[i] != 1 && top[j] % bot2[i] == 0)
                    {
                        top[j] /= bot2[i];
                        bot2[i] = 1;
                        break;
                    }

                }
            }

            ulong topMult = multiplyWhatsLeft(top);
            ulong bot1Mult = multiplyWhatsLeft(bot1);
            ulong bot2Mult = multiplyWhatsLeft(bot2);

            return (topMult / (bot1Mult * bot2Mult));


        }

        static ulong multiplyWhatsLeft(ulong [] inAr)
        {
            ulong mult = 1;
            for (int i = 0; i < inAr.Length; i++)
            { 
            mult*=inAr[i];
            }
            return mult;
        }

    }
}
