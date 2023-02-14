using System;
using System.Collections.Generic;
using System.Linq;
namespace knightshortestpath
{
    public class Cell
    {
        public int x, y;
        public int dis;
        public List<int> steps;
        public Cell(int x, int y, int dis, List<int> steps)
        {
            this.x = x;
            this.y = y;
            this.dis = dis;
            this.steps = new List<int>(steps);
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("X=");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Y=");
            int y = int.Parse(Console.ReadLine());
            //int M = Math.Max(x, y) +50;
            int M = 10000;

            List<int> list = new List<int>();
            Cell start = new Cell(0, 0, 0, new List<int>());
            Cell end = new Cell(x, y, 0, new List<int>());
            Console.WriteLine("(0 , 0)");
            bfs(start, end, M+1);
        }


        static bool IsInside(int x, int y, int N)
        {
            if (x >= 0 && x <= N+1 && y >= 0 && y <= N+1)
                return true;
            return false;
        }

        static void bfs(Cell start, Cell end, int N)
        {
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(start);
            bool[,] visit = new bool[N + 1, N + 1];
            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= N; j++)
                    visit[i, j] = false;
            visit[start.x, start.y] = true;


            int[] directionX = { -2, -1, 1, 2, -2, -1, 1, 2 };
            int[] directionY = { -1, -2, -2, -1, 1, 2, 2, 1 };


            while (queue.Count > 0)
            {
                Cell current = queue.Dequeue();
                if (current.x == end.x && current.y == end.y)
                {
                 
                    for (int i = 0; i < current.steps.Count; i += 2)
                    {
                        Console.WriteLine($"({current.steps[i]} , {current.steps[i + 1]})");
                    }
                    return;

                }
                for (int i = 0; i < 8; i++)
                {
                    int newx = current.x + directionX[i];
                    int newy = current.y + directionY[i];


                    if (IsInside(newx, newy, N) && !visit[newx, newy])
                    {
                        List<int> temporaryList = new List<int>(current.steps);
                        temporaryList.Add(newx);
                        temporaryList.Add(newy);
                        visit[newx, newy] = true;
                        queue.Enqueue(new Cell(newx, newy, 0, temporaryList));
                    }
                }
            }
        }
    static void DisplayChessBoard()
    {
        Console.WriteLine("ee");
    }
    }
}
