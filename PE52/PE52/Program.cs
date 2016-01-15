using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE52
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 10; i < 1000000; i++)
            {
                string x = i.ToString();
                string xMult;
                int j;
                for (j = 2; j < 7; j++)
                {
                    xMult = (i * j).ToString();
                    if (!hasSameDigits(x, xMult)) break;
                    x = xMult;
                }

                if (j < 7)
                    continue;
                else if (j == 7)
                {
                    Console.WriteLine("DONE: x = " + i.ToString() + " -- " + sw.ElapsedMilliseconds + " ms");
                    Console.Read();
                    break;
                }

            }
        }

        static bool hasSameDigits(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (!s2.Contains(s1[i]))
                    return false;
            }

            if (s1.Length != s1.Length)
            { 
                for(int i =0; i < s2.Length; i++)
                {
                    if (!s1.Contains(s2[i]))
                        return false;
                }
            }
            return true;
        }

    }
}
