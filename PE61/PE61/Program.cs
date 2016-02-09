using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE61
{
    class Program
    {
        static List<List<int>> polys = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() };
     /*   static List<int> tri = new List<int>();
        static List<int> square = new List<int>();
        static List<int> pent = new List<int>();
        static List<int> hex = new List<int>();
        static List<int> hep = new List<int>();
        static List<int> oct = new List<int>(); */
        static void Main(string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; true; i++)
            {
                int num = i*(3*i-2);
                if (num > 999 && num < 10000)
                {
                    polys[5].Add(num);
                }

                num = i * (5 * i - 3) / 2;

                if (num > 999 && num < 10000)
                {
                    polys[4].Add(num);
                }

                num = i * (2 * i - 1);

                if (num > 999 && num < 10000)
                {
                    polys[3].Add(num);
                }

                num = i * (3 * i - 1) / 2;

                if (num > 999 && num < 10000)
                {
                    polys[2].Add(num);
                }

                num = i * i;

                if (num > 999 && num < 10000)
                {
                    polys[1].Add(num);
                }

                num = i * (i + 1) / 2;

                if (num > 999 && num < 10000)
                {
                    polys[0].Add(num);
                }

                if (num > 9999)
                    break;


            }

            List<int> test = new List<int>(polys[0]);

       /*     for (int i = 0; i < polys[2].Count; i++)
            {
                string lastTwo = polys[2][i].ToString().Substring(2);
                for (int j = 0; j < polys[0].Count; j++)
                {
                    if (lastTwo == polys[0][j].ToString().Substring(0, 2))
                    {
                        test.Add(polys[0][j]);
                        // Console.WriteLine(oct[i] + " => " + tri[j]);
                    }
                }
                // Console.WriteLine(oct[i]);
            }  */

           

            List<int> answer = null;

            List<List<int>> possible = new List<List<int>>();

            while (test.Count > 0)
            {
                answer = recurseList(new List<int>() {test[0] });
                if (answer != null)
                {
                    Console.WriteLine("POSSIBLE");
                    bool[] checkedPoly = Enumerable.Repeat(false, polys.Count).ToArray();
                    for (int j = 0; j < answer.Count; j++)
                    {
                        for (int i = 0; i < polys.Count; i++)
                        {
                            if (!checkedPoly[i] && polys[i].Contains(answer[j]))
                            {
                                checkedPoly[i] = true;
                                Console.WriteLine(i + " => " + answer[j]);
                            }
                        }
                           
                    }
                    Console.WriteLine("SUM = " + answer.Sum());
                        possible.Add(answer);
                }
                
                test.RemoveAt(0);
            }


       /*     for (int i = 0; i < answer.Count; i++)
            {
                Console.WriteLine(answer[i]);
            } */

                /*   for (int i = 0; i < polys[2].Count; i++)
                   {
                       string lastTwo = polys[2][i].ToString().Substring(2);
                       for (int j = 0; j < polys[0].Count; j++)
                       {
                           if (lastTwo == polys[0][j].ToString().Substring(0, 2))
                           {
                               test.Add(polys[0][j]);
                              // Console.WriteLine(oct[i] + " => " + tri[j]);
                           }
                       }
                       // Console.WriteLine(oct[i]);
                   }

                   List<int> answer = null;

                   while (answer == null)
                   {
                       answer = recurseList(test, 0);
                   }

                   for (int i = 0; i < answer.Count; i++)
                   {
                       Console.WriteLine(answer[i]);
                   } */




                /* int count = 0;
                 for (int i = 0; i < oct.Count; i++)
                 {
                     string lastTwo = oct[i].ToString().Substring(2);
                     for (int j = 0; j < tri.Count; j++)
                     {
                         if (lastTwo == tri[j].ToString().Substring(0, 2))
                         {
                             count++;
                             Console.WriteLine(oct[i] + " => " + tri[j]);
                         }
                     }
                    // Console.WriteLine(oct[i]);
                 } */

                Console.WriteLine("DONE => " + (sw.ElapsedMilliseconds/1000));// - combo = " + count);
            Console.Read();


        }


        static List<int> recurseList(List<int> inList)
        {

        //    if (inList.Count > 1 && !IsCycle(inList))
         //       return null;

            if (inList.Count == 6)
            {
                if (IsCycle(inList) && containsPolys(inList))
                    return inList;
                else
                    return null;
            }
            else
            {
                
                for (int i = 0; i < polys.Count; i++)
                {
                    for (int k = 0; k < polys[i].Count; k++)
                    {
                            List<int> newList = new List<int>(inList);
                            string last = newList[newList.Count -1].ToString().Substring(2);
                            if (last == polys[i][k].ToString().Substring(0, 2) && !newList.Contains(polys[i][k]))
                            {
                                newList.Add(polys[i][k]);
                                newList = recurseList(newList);
                                if (newList != null)
                                    return newList;
                            //    return null;
                            }
                    }
                    
                    
                }
            }

            return null;

           /* if (level == 2)
                return inList;
            else
            {
                for (int i = 0; i < inList.Count; i++)
                {
                    List<int> newList = new List<int>();
                    string s = inList[i].ToString().Substring(2, 2);
                    for (int j = 0; j < polys[level+1].Count; j++)
                    {
                        if (s == polys[level+1][j].ToString().Substring(2))
                        {
                            newList.Add(polys[level+1][j]);
                        }
                    }
                    newList = recurseList(newList, level + 1);
                    if (newList != null)
                        return newList;
                }
            }

            return null; */
        }

        static bool containsPolys(List<int> inList)
        {
            bool[] checkedPoly = Enumerable.Repeat(false, inList.Count).ToArray();
            List<int> used = new List<int>();
            for (int i = 0; i < inList.Count; i++)
            {
                int j = 0;
                while (j < inList.Count)
                {
                    
                    if (!used.Contains(inList[j]) && polys[i].Contains(inList[j]) && !checkedPoly[i])
                    {
                        used.Add(inList[j]);
                        checkedPoly[i] = true;
                        break;
                    }
                    
                    
                    j++;
                }

                if (j == inList.Count)
                    return false;

                
            }
            for (int i = 0; i < checkedPoly.Length; i++)
            {
                if (!checkedPoly[i])
                    return false;
            }

                return true;
        }

        static bool IsCycle(List<int> inList)
        {
            List<int> used = new List<int>();
            for (int i = 0; i < inList.Count; i++)
            {
                string last = inList[i].ToString().Substring(2);
                int j = 0;
                while (j < inList.Count)
                {
                    if (j == i)
                    {
                        j++;
                        continue;
                    }

                    if (!used.Contains(j) && last == inList[j].ToString().Substring(0, 2))
                    {
                        used.Add(j);
                        break;
                    }
                    

                    j++;

                }

                if (j == inList.Count)
                    return false;

            }

            return true;

            /*    if (inList[inList.Count - 1].ToString().Substring(2, 2) != inList[0].ToString().Substring(2))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < inList.Count - 1; i++)
                    {
                        if (inList[i].ToString().Substring(2, 2) != inList[i + 1].ToString().Substring(2))
                        {
                            return false;
                        }
                    }
                }

            return true; */
        }

    }
}
