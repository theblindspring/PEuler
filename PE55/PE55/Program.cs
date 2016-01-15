using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE55
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isLychrel = Enumerable.Repeat(true, 10001).ToArray();

          //  isLychrel[0] = false;

            for (int i = 0; i < isLychrel.Length; i++)
            {
                List<int> numAsList = getIntListFromString(i.ToString());

                if (i == 196)
                { 
                
                }

             /*   if (numAsList[numAsList.Count - 1] == 0 || isPalindrome(numAsList))
                {
                    isLychrel[i] = false;
                    continue;
                } */

                int j =0;

                for ( j = 0; j < 50; j++)
                {
                    numAsList = addReverse(numAsList);

                    

                    if (isPalindrome(numAsList))
                    {
                        isLychrel[i] = false;
                        break;
                    }
                }

                if (j == 50)
                {
                    Console.WriteLine(i.ToString());
                }

            }

            int count = 0;
            for (int i = 0; i < isLychrel.Length; i++)
            {
                if (isLychrel[i])
                    count++;
            }
            Console.WriteLine("num llyrchels = " + count);
                //  List<int> test = getIntListFromString("123");
                //    addReverse(test);
                Console.ReadLine();
        }

        public static bool isPalindrome(List<int> inList)
        {
            

            for (int i = 0; i < inList.Count / 2; i++)
            {
                if (inList[i] != inList[inList.Count - 1 - i])
                    return false;
            
            }
            return true;
        }

        public static List<int> getIntListFromString(string s)
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

        public static List<int> addReverse(List<int> inList)
        {
            List<int> reversed = inList.Reverse<int>().ToList();
            List<int> returnList = new List<int>();

            

            if (inList.Count == 0)
                return returnList;

            int carryDigit = 0;

            for (int i = 0; i < inList.Count; i++)
            {
                int sum = inList[i] + reversed[i] + carryDigit;

                returnList.Add(sum % 10);

                carryDigit = sum / 10;


            }

            if (carryDigit != 0)
                returnList.Add(carryDigit);


            returnList.Reverse();

     /*       Console.Write("Sum is ");

            for (int i = 0; i < returnList.Count; i++)
            {
                Console.Write(returnList[i].ToString());
            }
            Console.WriteLine(); */


                return returnList;
        }
    }
}
