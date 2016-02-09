using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE62
{
    class Program
    {
        static void Main(string[] args)
        {

            if (isPermutation(41063625, 56623104))
                Console.WriteLine("PERM");
            else
                Console.WriteLine("NOTPERM");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            ulong[] checkList = getCubes(345, 10000);

            for (int i = 0; i < checkList.Length; i++)
            {
                List<ulong> perms = new List<ulong>();
                perms.Add(checkList[i]);
                for (int j = i + 1; j < checkList.Length; j++)
                {
                    if (isPermutation(checkList[i], checkList[j]))
                    {
                        perms.Add(checkList[j]);
                    }

                    if (perms.Count > 5)
                        break;
                }

                if (perms.Count == 5)
                {

                    for (int x = 0; x < perms.Count; x++)
                    {
                        for (int y = 0; y < perms.Count; y++)
                        {
                            if (!isPermutation(perms[x], perms[y]))
                            {
                                Console.WriteLine("NOT PERM => " + perms[x] + " - " + perms[y]);
                            }
                        }
                    }

                        Console.WriteLine("ANSWER = " + perms.Min());
                    break;
                }
            }

            Console.WriteLine("DONE => " + (sw.ElapsedMilliseconds / 1000));
            Console.ReadLine();

        }

        static ulong[] getCubes(ulong start, ulong end)
        {
            ulong[] returnAr = new ulong[end - start];

            for (ulong i = start; i < end; i++)
            {
                returnAr[i - start] = i * i * i;
            }

            return returnAr;

        }

        static bool isPermutation(ulong in1, ulong in2)
        {
            string num1 = in1.ToString();
            string num2 = in2.ToString();

            if (num1.Length != num2.Length)
            {
                return false;
            }

            for (int i = 0; i < num1.Length; i++)
            {
                int deleteNdx = num2.IndexOf(num1[i]);
                if (deleteNdx == -1)
                    return false;
                else
                   num2 = num2.Remove(deleteNdx, 1);
            }

            if (num2.Length > 0)
                return false;
            
            return true;

        }
    }
}
