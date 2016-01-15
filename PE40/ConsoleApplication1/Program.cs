using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            bool done12 = false;
            int mult = 1;
            bool[] done = new bool[7];
            for (int i = 1; i < 1000000; i++)
            {
                count += i.ToString().Length;

                int diff = 0;

                if (count >= 1000000 && !done[6])
                {
                    diff = count - 1000000;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[6] = true;
                }
                else if (count >= 100000 && !done[5])
                {
                    diff = count - 100000;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[5] = true;
                }
                else if (count >= 10000 && !done[4])
                {
                    diff = count - 10000;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[4] = true;
                }
                else if (count >= 1000 && !done[3])
                {
                    diff = count - 1000;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[3] = true;
                }
                else if (count >= 100 && !done[2])
                {
                    diff = count - 100;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[2] = true;
                }
                else if (count >= 10 && !done[1])
                {
                    diff = count - 10;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[1] = true;
                }
                else if (count >= 1 && !done[0])
                {
                    diff = count - 1;
                    mult *= int.Parse(i.ToString()[i.ToString().Length - 1 - diff].ToString());
                    done[0] = true;
                }
            
            }
            Console.WriteLine(mult);
            Console.ReadLine();
        }
    }
}
