using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigNumberLib;


namespace PE56
{
    class Program
    {
        static ulong largestSum = 0;

        static void Main(string[] args)
        {

           
            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    //List<int> product = BigNumberFunctions.exponentList(BigNumberFunctions.getIntListFromString(i.ToString()), j);
                    ArbitraryLargeUnsignedInt baseNum = new ArbitraryLargeUnsignedInt(i.ToString());
                    ArbitraryLargeUnsignedInt prod = baseNum;
                    for (int k = 1; k < j; k++)
                    {
                        prod *= baseNum;
                    }

                        setLargest(prod.numList);
                }
            } 


            Console.WriteLine(largestSum);
               

            Console.WriteLine();

            Console.ReadLine();


        }

    /*    public static List<int> getIntListFromString(string s)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    returnList.Clear();
                    return returnList;
                }
                else
                {
                    returnList.Add((int)(s[i] - 48));
                }
            }

            returnList.Reverse();
            return returnList;
        }

        public static List<int> multiplyListsUnreversed(List<int> num1, List<int> num2)
        {
            List<int> returnList = new List<int>();

           

            for (int i = 0; i < num1.Count; i++)
            {

                int multCarry = 0;

                for (int j = 0; j < num2.Count; j++)
                {
                    int total = (num1[i] * num2[j]) + multCarry;

                    int digit = total % 10;

                    multCarry = total / 10;

                    if (i + j >= returnList.Count)
                    {
                        returnList.Add(digit);
                    }
                    else
                    {
                        returnList[i + j] += digit;
                    }


                }


                if (multCarry != 0)
                {
                    returnList.Add(multCarry);
                }

                


            }

           

            for (int i = 0; i < returnList.Count; i++)
            {
                

                if (returnList[i] > 9 )
                {
                    int addNum = returnList[i] / 10;

                    if (i + 1 < returnList.Count)
                    {
                        returnList[i + 1] += addNum;
                    }
                    else
                    {
                        returnList.Add(addNum);
                    }

                    returnList[i] = returnList[i] % 10;

                }
                
            }

          //      returnList.Reverse();

            return returnList;

        }


        public static List<int> exponentList(List<int> baseNum, int expoNum)
        {
           // List<int> returnList = new List<int>();

            List<int> product = baseNum;

            for (int i = 1; i < expoNum; i++)
            {
                product = multiplyListsUnreversed(product, baseNum);
            }


            product.Reverse();

            return product;


        } */

        public static void setLargest(List<int> toCheck)
        {
             while(toCheck.Remove(0));

             if (largestSum / (ulong)toCheck.Count > 9)
                 return;
             else
             {
                 ulong sum = 0;
                 for (int i = 0; i < toCheck.Count; i++)
                 {
                     sum += (ulong)toCheck[i];
                 }

                 if (sum > largestSum)
                     largestSum = sum;

             }

        
        }

    }
}
