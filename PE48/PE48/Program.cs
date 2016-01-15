using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE48
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int [] sum = new int[]{0,0,0,0,0,0,0,0,0,0};

            for (int i = 1; i < 1001; i++)
            {

                sum = addDigits(sum, get10Digits(i));

               /* int [] selfPower = get10Digits(i);

                Console.Write("i = " + i.ToString() + ": ");

                 */
            }

            sum = sum.Reverse().ToArray();


            for (int j = 0; j < sum.Length; j++)
            {
                Console.Write(sum[j]);
            }
            Console.WriteLine("Done");
            
            Console.ReadLine();

        }

        static int[] addDigits(int[] num1, int[] num2)
        {
            int[] returnAr = new int[] { 0,0,0,0,0,0,0,0,0,0};

            int carry = 0;
            for (int i = 0; i < num1.Length; i++)
            {
                int sum = num1[i] + num2[i] + carry;

                returnAr[i] = sum % 10;
                carry = sum / 10;
            }

            return returnAr;
        }

        static int[] multTo10(int[] num1, int[] num2)
        {
            int[] returnAr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            
            for (int i = 0; i < num1.Length; i++)
            {
                int carry = 0;
                for (int j = 0; j + i < 10; j++)
                {
                    int mult = num1[i] * num2[j] + carry;

                   

                    returnAr[j + i] += mult % 10;
                    carry = mult / 10;
                    
                   

                    if (returnAr[j + i] >= 10)
                    {
                        carry += returnAr[j + i] /10;
                        returnAr[j + i] = returnAr[j + i] % 10;
                        
                    }


                }
            }



            return returnAr;

        }

        static int[] get10Digits(int num)
        {
            int saveNum = num;

            bool isEleven = saveNum == 11;

            if (isEleven)
            {
                Console.WriteLine("");
            }

            int[] digits = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnAr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;
            while(num > 0)
            {
            returnAr[count] = digits[count] = num%10;
            count++;
            num/=10;
            }
        //    returnAr = returnAr.Reverse().ToArray(); 
         //   digits.Reverse();

            for (int i = 1; i < saveNum; i++)
            {
                returnAr = multTo10(digits, returnAr);
            }

            return returnAr;


        } 

    }
}
