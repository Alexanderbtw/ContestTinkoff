using System;
using System.Linq;

namespace Task_2;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine()!.Split(' ').Select(c => int.Parse(c)).ToArray();
        int n = size[0];
        int m = size[1];
        
        int[,] originalMatrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split(' ');

            for (int j = 0; j < m; j++)
            {
                originalMatrix[i, j] = int.Parse(row[j]);
            }
        }
        
        int[,] rotatedMatrix = new int[m, n];
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                rotatedMatrix[j, n - i - 1] = originalMatrix[i, j];
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(rotatedMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}