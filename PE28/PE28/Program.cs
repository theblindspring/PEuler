using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE28
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] mat = getNDimensionalSpiral(1001);

            long sum = 0;

            for (int i = 0; i < 1001; i++)
            {
                sum += mat[i, i];
                sum += mat[1000 - i, i];
            }

            sum -= 1;
            Console.WriteLine(sum);

                Console.ReadLine();
        }

        static int[,] getNDimensionalSpiral(int n)
        {
            int[,] mat = new int[n, n];
            int count = 1;
            int maxCount = n * n;
            int shift = 1;

            int row = n/2;
            int col = n/2;

            mat[row, col] = count;
            count++;

            while (count <= maxCount)
            {
                for (int i = 0; count <= maxCount && i < shift; i++)
                {
                    col++;
                    mat[row, col] = count;
                    count++;
                }

                for (int i = 0; count <= maxCount && i < shift; i++)
                {
                    row++;
                    mat[row, col] = count;
                    count++;
                }

                shift++;

                for (int i = 0; count <= maxCount && i < shift; i++)
                {
                    col--;
                    mat[row, col] = count;
                    count++;
                }

                for (int i = 0; count <= maxCount && i < shift; i++)
                {
                    row--;
                    mat[row, col] = count;
                    count++;
                }

                shift++;
            }

            return mat;
        }
    
    }
}
