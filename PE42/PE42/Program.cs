using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE42
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] words = System.IO.File.ReadAllText("p042_words.txt").Split(new string[]{"\",\"","\"" }, StringSplitOptions.RemoveEmptyEntries);
            int max = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if(max < words[i].Length)
                {
                    max = words[i].Length;
                }
            }

            int [] maxTerm = new int[25 * max];

        //    List<int> triangleNums = new List<int>();

            for (int i = 1; i < maxTerm.Length; i++)
            {
                maxTerm[i] = ((int)(.5 * i * (i + 1)));
            }

            int numOfTriangles = 0;

            for (int i = 0; i < words.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    sum += (int)words[i][j] - 64;
                }

                if (maxTerm.Contains(sum))
                    numOfTriangles++;


            }
            Console.WriteLine(numOfTriangles);
                Console.ReadLine();
        }
    }
}
