using System;

namespace Task_5;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[][] forest = new char[n][];
        for (int i = 0; i < n; i++)
        {
            forest[i] = Console.ReadLine().ToCharArray();
        }
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[3];
        }

        for (int j = 0; j < 3; j++)
        {
            dp[0][j] = forest[0][j] switch
            {
                'C' => 1,
                'W' => int.MinValue,
                '.' => 0,
                _ => dp[0][j]
            };
        }
        
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (forest[i][j])
                {
                    case 'C':
                        dp[i][j] = 1 + dp[i - 1][j];
                        if (j - 1 >= 0)
                        {
                            dp[i][j] = Math.Max(1 + dp[i - 1][j - 1], dp[i][j]);
                        }
                        if (j + 1 < 3)
                        {
                            dp[i][j] = Math.Max(1 + dp[i - 1][j + 1], dp[i][j]);
                        }
                        break;
                    case 'W':
                        dp[i][j] = int.MinValue;
                        break;
                    case '.':
                        dp[i][j] = dp[i - 1][j];
                        if (j - 1 >= 0)
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j - 1], dp[i][j]);
                        }
                        if (j + 1 < 3)
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j + 1], dp[i][j]);
                        }
                        break;
                }
            }
        }

        int maxMushrooms = Math.Max(dp[n-1][0], Math.Max(dp[n-1][1], dp[n-1][2]));
        Console.WriteLine(maxMushrooms);
    }
}