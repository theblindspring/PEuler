using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE67
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int []> lines = new List<int[]>();

            using(System.IO.StreamReader sr = new System.IO.StreamReader("p067_triangle.txt"))
            {
                while(!sr.EndOfStream)
                {
                    lines.Add(Array.ConvertAll(sr.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries), int.Parse));    
                }
            }


          //  int col = 0;
            for (int row = 0; row < lines.Count-1; row++)
            {
                for(int col = 0; col < lines[row].Length; col++)
                {
                    lines[row+1][col+1] += lines[row][col];

                    if(col == 0)
                    {
                    lines[row+1][col] += lines[row][col];
                    }

                    if(col > 0 &&  lines[row + 1][col] < lines[row+1][col] - lines[row][col-1] + lines[row][col])
                    {
                        lines[row+1][col] = lines[row+1][col] - lines[row][col-1] + lines[row][col];

                    }
                }
                
               
            }


            int answer = lines[lines.Count - 1].Max();

            Console.WriteLine("Answer => " + answer);
            Console.ReadLine();


        }
    }
}
