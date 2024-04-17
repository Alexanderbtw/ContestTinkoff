using System;

namespace Task_4;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        char direction = char.Parse(input[1]);
        
        long[][] matrix = new long[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        }

        Console.WriteLine((n - 1) * 3);
        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - 1 - layer;
            for (int i = first; i < last; i++)
            {
                int offset = i - first;
                long top = matrix[first][i];
                
                if (direction == 'R')
                {
                    matrix[first][i] = matrix[last - offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[i][last];
                    matrix[i][last] = top;
                    Console.WriteLine($"{first} {i} {last - offset} {first}");
                    Console.WriteLine($"{last - offset} {first} {last} {last - offset}");
                    Console.WriteLine($"{last} {last - offset} {i} {last}");
                }
                else if (direction == 'L')
                {
                    matrix[first][i] = matrix[i][last];
                    matrix[i][last] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[last - offset][first];
                    matrix[last - offset][first] = top;
                    Console.WriteLine($"{first} {i} {i} {last}");
                    Console.WriteLine($"{i} {last} {last} {last - offset}");
                    Console.WriteLine($"{last} {last - offset} {last - offset} {first}");
                }
            }
        }
    }
}