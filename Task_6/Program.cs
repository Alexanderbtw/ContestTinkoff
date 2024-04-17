using System;
using System.Collections.Generic;

namespace Task_6;

// UNSOLVED
#region Task Description
/*Ну и конечно же задача на блуждания коня по шахматной доске размера n×n. Чтобы блуждать не было скучно, на доске разбросаны специальные фишки.

Есть два типа фишек — "K" и "G". При ходе в клетку, в которой лежит фишка "K", фигура превращается в коня. При ходе в клетку, в которой лежит фишка "G", фигура превращается в короля. 
Разумеется, после превращения фигураначинает ходить соответственно своему новому типу. 
Попадание короля в клетку с фишкой "G" или коня в клетку с фишкой "K" ничего не меняет. 
При этом трансформация является обязательной и фигура не может пройти такую клетку с фишкой без превращения в указанный тип.

Ваша задача определить, за какое минимальное количество ходов фигура (возможно в образе коня/короля) доберется до заданной клетки. 
Заметьте, что количество трансформаций считать не нужно.

Формат входных данных

В первой строке задано одно натуральное число n — размер доски (2≤n≤100). 
В следующих n клетках задано описание шахматной доски — по n символов. 
Фишки обозначаются "K" и "G", а пустые клетки за ".". Начальная клетка обозначается "S", а конечная — "F".

Гарантируется, что на начальной и конечной клетках нет фишки.

Формат выходных данных

Выведите единственное число — необходимое количество ходов. 
Если такого пути не существует, то выведите −1.

Замечание

Как и всегда, конь ходит буквой Г, т.е. на одну клетку в одну сторону и две клетки в другую, всего до 8 возможных ходов. 
Король может перейти из текущей клетки в соседнюю по стороне или углу, всего до 8 возможных ходов.*/
#endregion

class Program
{
    static bool IsKing = false;
    static int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] dxK = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int[] dyK = { 2, 1, -1, -2, -2, -1, 1, 2 };

    static bool IsValid(int x, int y, int n)
    {
        return x >= 0 && x < n && y >= 0 && y < n;
    }

    static int BFS(int[][] board, int startX, int startY, int endX, int endY)
    {
        int n = board.Length;
        int[][] dist = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dist[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                dist[i][j] = int.MaxValue;
            }
        }

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startX, startY));
        dist[startX][startY] = 0;

        while (queue.Count > 0)
        {
            var (curX, curY) = queue.Dequeue();

            for (int i = 0; i < 8; i++)
            {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];
                if (IsKing)
                {
                    nextX = curX + dxK[i];
                    nextY = curY + dyK[i];
                }

                if (IsValid(nextX, nextY, n) && dist[nextX][nextY] == int.MaxValue)
                {
                    if (board[nextX][nextY] == 2)
                        IsKing = true;
                    if (board[nextX][nextY] == 1)
                        IsKing = false;
                    dist[nextX][nextY] = dist[curX][curY] + 1;
                    queue.Enqueue((nextX, nextY));
                }
            }
        }

        return dist[endX][endY];
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] board = new int[n][];
        int startX = -1, startY = -1, endX = -1, endY = -1;

        for (int i = 0; i < n; i++)
        {
            string row = Console.ReadLine();
            board[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                switch (row![j])
                {
                    case 'K':
                        board[i][j] = 1;
                        break;
                    case 'G':
                        board[i][j] = 2;
                        break;
                    case 'S':
                        startX = i;
                        startY = j;
                        break;
                    case 'F':
                        endX = i;
                        endY = j;
                        break;
                }
            }
        }

        int minMoves = BFS(board, startX, startY, endX, endY);
        Console.WriteLine(minMoves == int.MaxValue ? -1 : minMoves);
    }
}