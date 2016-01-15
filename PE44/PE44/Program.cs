using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE44
{
    public class ThreePur
    {
        public int index;
        public int addedFromLast;
        public int pentNum;

        public ThreePur(int ndx)
        {
            index = ndx + 1;
            addedFromLast = 1 + 3 * (index);
            pentNum = index * (3 * index - 1) / 2;
        }

        public void printContents()
        {
            Console.WriteLine(index + " - " + addedFromLast + " - " + pentNum);
        }

    }

    class Program
    {
        public static List<ThreePur> data = new List<ThreePur>();

        public static bool isPent(int num)
        { 
            double evaluation = (Math.Sqrt(24*num+1) + 1)/6;

            int outNum;

            if (int.TryParse(evaluation.ToString(), out outNum))
                return true;
            else
                return false;

        }

     //   static long lowestNumber =0;
        static void Main(string[] args)
        {
           
            for (int i = 0; i < 100000; i++)
            {
                data.Add(new ThreePur(i));
            }

            for (int i = 1; i < data.Count-2; i++)
            {
                if (data[i].pentNum % 5 != 0)
                    continue;
                    for (int j = i+1; j < data.Count -1; j++)
                    {
                        if (data[j].pentNum % 5 != 0)
                            continue;

                        int sum = data[j].pentNum + data[i].pentNum;
                        int diff = data[j].pentNum - data[i].pentNum;
                        if ( sum < data[j + 1].pentNum || diff > data[j - 1].pentNum )
                            continue;
                        else if(isPent(sum) && isPent(diff))
                        {

                            Console.WriteLine(diff);
                            

                           

                        }

                      
                    }
                
                
              
            }


                Console.WriteLine("DONE");
            Console.Read();

        }

        static int indexOfInData(int start, int count, int numInQuestion)
        {
            for (int i = start; i < start + count; i++)
            {
                if (data[i].pentNum == numInQuestion)
                    return i;
                else if (data[i].pentNum > numInQuestion)
                    return -1;
            }
           
            return -1;
        }

        static long getNPent(int n)
        {
            return n * (3 * n - 1) / 2;
        }
    }
}
