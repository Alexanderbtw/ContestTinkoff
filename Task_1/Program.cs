using System;
using System.Collections.Generic;

namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        if (n < 7)
        {
            Console.WriteLine(-1);
            return;
        }

        var queue = new Queue<char>();
        var fiveCount = 0;
        var maxFiveCount = -1;

        for (int i = 0; i < n; i++)
        {
            char grade = Console.ReadKey().KeyChar;
            if (i != n - 1) 
                _ = Console.ReadKey();
            
            switch (grade)
            {
                case '5':
                    fiveCount++;
                    queue.Enqueue(grade);
                    break;
                case '4':
                    queue.Enqueue(grade);
                    break;
                default:
                    fiveCount = 0;
                    queue.Clear();
                    break;
            }
    
            if (queue.Count == 7)
            {
                if (fiveCount > maxFiveCount)
                {
                    maxFiveCount = fiveCount;
                }
                char prevGrade = queue.Dequeue();
                if (prevGrade == '5')
                    fiveCount--;
            }
        }

        Console.WriteLine("\n{0}", maxFiveCount);
    }
}