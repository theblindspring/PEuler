using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE43
{
    class Program
    {
        static long sum = 0;
        static void Main(string[] args)
        {
            GetPerms();
            Console.WriteLine(sum);

            Console.Read();
        }

        static bool checkForPattern(string s)
        {
            if (int.Parse(s.Substring(1,3))%2 != 0)
                return false;
            if (int.Parse(s.Substring(2, 3)) % 3 != 0)
                return false;
            if (int.Parse(s.Substring(3, 3)) % 5 != 0)
                return false;
            if (int.Parse(s.Substring(4, 3)) % 7 != 0)
                return false;
            if (int.Parse(s.Substring(5, 3)) % 11 != 0)
                return false;
            if (int.Parse(s.Substring(6, 3)) % 13 != 0)
                return false;
            if (int.Parse(s.Substring(7, 3)) % 17 != 0)
                return false;

            return true;

        }

        static string makeStringNumber(int[] inAr)
        {
            string s = "";
            for (int i = 0; i < inAr.Length; i++)
            {
                s += inAr[i].ToString();
            }

            return s;

        }

        static long makeLongNumber(int[] inAr)
        {
            string s = "";
            for (int i = 0; i < inAr.Length; i++)
            {
                s += inAr[i].ToString();
            }

            return long.Parse(s);

        }

        static List<long> GetPerms()
        {
            int[] lexBase = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<long> perms = new List<long>();



            int k;

            while (true)
            {


                k = lexBase.Length - 2;

                if(checkForPattern(makeStringNumber(lexBase)))
                {
                    sum += makeLongNumber(lexBase);
                }
                
                while (lexBase[k] > lexBase[k + 1])
                {
                    k--;

                    if (k == -1)
                        return perms;
                }

                int i = lexBase.Length - 1;

                while (lexBase[k] > lexBase[i] && i > k)
                {
                    i--;
                }

                int temp = lexBase[i];
                lexBase[i] = lexBase[k];
                lexBase[k] = temp;
                int[] subset = lexBase.Skip(k + 1).ToArray();
                subset = subset.Reverse().ToArray();


                for (int x = k + 1; x < 10; x++)
                {
                    //  Console.Write(lexBase[x] + "\r\n");
                    lexBase[x] = subset[x - (k + 1)];
                    //  Console.Write(lexBase[x] + "\r\n");
                }

                //      perms.Add(makeNumber(lexBase));

                if (perms.Count >= 999999 && perms.Count < 1000005)
                {

                    Console.WriteLine((perms.Count - 1) + " -- " + perms[perms.Count - 1]);
                }

                // Console.WriteLine("-----\r\n" + makeNumber(lexBase) + " -- " + makeNumber(subset) + "\r\n-----");

                // for(int i)


                //  Console.WriteLine();


            }

        }
    }
}
