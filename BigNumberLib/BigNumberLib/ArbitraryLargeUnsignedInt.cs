using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumberLib
{
    public class ArbitraryLargeUnsignedInt
    {

        public List<int> numList = new List<int>();

        public static bool operator >(ArbitraryLargeUnsignedInt left, ArbitraryLargeUnsignedInt right)
        {
            string leftString = left.ToString();
            string rightString = right.ToString();

            if (leftString.Length > rightString.Length)
            {
                return true;
            }
            else if (leftString.Length < rightString.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < leftString.Length; i++)
                {
                    if (leftString[i] > rightString[i])
                        return true;
                    else if (leftString[i] < rightString[i])
                        return false;
                }

                return false;
            }

        }

        public static bool operator <(ArbitraryLargeUnsignedInt left, ArbitraryLargeUnsignedInt right)
        {
            string leftString = left.ToString();
            string rightString = right.ToString();

            if (leftString.Length < rightString.Length)
            {
                return true;
            }
            else if (leftString.Length > rightString.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < leftString.Length; i++)
                {
                    if (leftString[i] < rightString[i])
                        return true;
                    else if (leftString[i] > rightString[i])
                        return false;
                }

                return false;
            }

        }


        public static bool operator ==(ArbitraryLargeUnsignedInt left, ArbitraryLargeUnsignedInt right)
        {
            return left.ToString() == right.ToString();
        }

        public static bool operator !=(ArbitraryLargeUnsignedInt left, ArbitraryLargeUnsignedInt right)
        {
            return left.ToString() != right.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public static ArbitraryLargeUnsignedInt operator *(ArbitraryLargeUnsignedInt left, ArbitraryLargeUnsignedInt right)
        {
            return new ArbitraryLargeUnsignedInt() { numList = multiplyListsUnreversed(left.numList, right.numList) };
        }

        public static ArbitraryLargeUnsignedInt operator *(ArbitraryLargeUnsignedInt left, ulong right)
        {
            return left * new ArbitraryLargeUnsignedInt(right.ToString());
        }
       

        public static ArbitraryLargeUnsignedInt operator +(ArbitraryLargeUnsignedInt left, int right)
        {
            ArbitraryLargeUnsignedInt rightBig = new ArbitraryLargeUnsignedInt(right.ToString());

            return left + rightBig;
        }

        public static ArbitraryLargeUnsignedInt operator +(ArbitraryLargeUnsignedInt left, ArbitraryLargeUnsignedInt right)
        {
            ArbitraryLargeUnsignedInt returnArb = new ArbitraryLargeUnsignedInt();
            
            int max = Math.Max(left.numList.Count, right.numList.Count);

            for(int i =0; i < max; i++)
            {
                if (i >= left.numList.Count)
                {
                    left.numList.Add(0);
                }
                else if (i >= right.numList.Count)
                {
                    right.numList.Add(0);
                }
            }

            int carryDigit = 0;

            for (int i = 0; i < left.numList.Count; i++)
            {
                int sum = left.numList[i] + right.numList[i] + carryDigit;

                returnArb.numList.Add(sum % 10);

                carryDigit = sum / 10;


            }

            if (carryDigit != 0)
                returnArb.numList.Add(carryDigit);

            return returnArb;
        }

        public ArbitraryLargeUnsignedInt(string s)
        {
            numList = getIntListFromString(s);
        }

        public ArbitraryLargeUnsignedInt()
        {
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


                if (returnList[i] > 9)
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



            return returnList;
        }


        public static List<int> exponentList(List<int> baseNum, int expoNum)
        {

            List<int> product = baseNum;

            for (int i = 1; i < expoNum; i++)
            {
                product = multiplyListsUnreversed(product, baseNum);
            }


            product.Reverse();

            return product;


        }

        public override string ToString()
        {
            string s = "";
            for (int i = numList.Count - 1; i >= 0; i--)
            {
                s += numList[i].ToString();
            }
                return s;
        }

    }
}
