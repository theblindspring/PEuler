using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE59
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] sNum = System.IO.File.ReadAllText("p059_cipher.txt").Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);

            byte[] bytes = new byte[sNum.Length];
            
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(sNum[i]);
            }

            

            Console.WriteLine(bytes[0] + " -- " + bytes[bytes.Length-1]);
           // Console.ReadLine();
            int iterCount = 0;
            byte [] key = new byte[3];

            for(byte i = 97; i < 123; i++)
            {
                for(byte j = 97; j < 123; j++)
                {
                    for(byte k = 97; k < 123; k++)
                    {
                        key[0]=i;
                        key[1] = j;
                        key[2] = k;

                        iterCount++;

                        string keyString = Encoding.ASCII.GetString(key);

                        byte[] testBytes = new byte[bytes.Length];

                         bytes.CopyTo(testBytes, 0);
                       
                       /* for (int y = 0; y < testBytes.Length; y++)
                        {
                            Console.Write(testBytes[y] + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(); */


                        bool shouldContinue = false;
                        for (int x = 0; x < bytes.Length; x++)
                        { 
                        testBytes[x] ^= key[x%3];

                            if (testBytes[x] < 32 && testBytes[x] != 10 && testBytes[x] != 13)
                           // if (!((testBytes[x] >64 && testBytes[x] < 91) || (testBytes[x] > 96 && testBytes[x] < 123) || testBytes[x] == 32 || testBytes[x] == 46))
                            {
                                shouldContinue = true;
                                break;
                            } 
                        
                        }

                        if (shouldContinue)
                            continue;

                       

                        string converted = Encoding.ASCII.GetString(testBytes);

                        if (!converted.Contains('~') && !converted.Contains('|') && !converted.Contains('`'))
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine(converted);

                            int sum = 0;

                            for (int u = 0; u < testBytes.Length; u++)
                            {
                                sum += testBytes[u];
                            }

                            Console.WriteLine(sum);

                        }
                        

                    }

                }

            }
            Console.WriteLine("DONE - Count = " + iterCount);
            Console.ReadLine();

        }
    }
}
