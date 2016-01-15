using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE24
{
    class Program
    {
        static void Main(string[] args)
        {


            List<long> permList = GetPerms();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine( permList[i]);
            }
            Console.WriteLine((permList.Count - 1) + " -- " + permList[permList.Count - 1]);
            Console.WriteLine("Done");
                Console.Read();
                


        }

        static List<long> GetPerms()
        {
            int[] lexBase = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<long> perms = new List<long>();

           

            int k; 

            while (true)
            {
                k = lexBase.Length - 2;
                perms.Add(makeNumber(lexBase));
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
                int[] subset = lexBase.Skip(k+1).ToArray();
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
                        
                        Console.WriteLine((perms.Count-1) + " -- " + perms[perms.Count - 1]);
                    }

               // Console.WriteLine("-----\r\n" + makeNumber(lexBase) + " -- " + makeNumber(subset) + "\r\n-----");

               // for(int i)
              

              //  Console.WriteLine();


            }
           
        }

        static long makeNumber(int[] inAr)
        {
            string s = "";
            for (int i = 0; i < inAr.Length; i++)
            {
                s += inAr[i].ToString();
            }

            return long.Parse(s);

        }

    }
}
