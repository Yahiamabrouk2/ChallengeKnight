using System;
using System.Collections.Generic;
using System.Linq;
namespace knightshortestpath
{
    
    public class Knight
    {
        public int x, y;
        public int dis;
        public List<int> steps;
        public Knight(int x, int y, int dis, List<int> steps)
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
            int x = int.Parse(Console.ReadLine()) ;
            Console.WriteLine("Y=");
            int y = int.Parse(Console.ReadLine());
            //M Should be bigger than the maximum of (x,y)
            int M = Math.Max(x, y) + 10;



            List<int> list = new List<int>();
            Knight start = new Knight(0, 0, 0, new List<int>());
            Knight end = new Knight(x, y, 0, new List<int>());
            Console.WriteLine($"The shortest path to reach the ({x} , {y}) point is : ");
            Console.WriteLine("(0 , 0)");
            ShortestPath(start, end, M + 2);
        }


        static bool IsInside(int x, int y, int N)
        {
            if (x >= 0 && x <= N+1 && y >= 0 && y <= N+1)
                return true;
            return false;
        }

        static void ShortestPath(Knight start, Knight end, int N)
        {
            
            Queue<Knight> queue = new Queue<Knight>();
            queue.Enqueue(start);
            bool[,] visit = new bool[N + 10, N + 10];
            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= N; j++)
                    visit[i, j] = false;
            visit[start.x, start.y] = true;


            int[] directionX = { -2, -1, 1, 2, -2, -1, 1, 2 };
            int[] directionY = { -1, -2, -2, -1, 1, 2, 2, 1 };


            while (queue.Count > 0)
            {
                Knight current = queue.Dequeue();
                if (current.x == end.x && current.y == end.y)
                {
                    string[,] result = new string[N+1, N+1];
                    
                    for (int i = 0;  i< N; ++i)
                    {
                        for (int j = 0; j < N; ++j)
                        {
                            result[i, j] = " * ";
                        }
                    }
                    for (int i = 0; i < current.steps.Count; i += 2)
                    {
                        Console.WriteLine($"({current.steps[i]} , {current.steps[i + 1]})");
                        result[N-current.steps[i + 1] -1 ,current.steps[i] ]  = $" {i} " ;
                        
                    }

                    for(int i = 0; i < N+1; ++i)
                    {
                        for (int j  = 0; j < N+1; ++j)
                        {
                            Console.Write(result[i, j]);
                        }
                        Console.WriteLine();
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
                        queue.Enqueue(new Knight(newx, newy, 0, temporaryList));
                    }
                }
            }
        }
    }
}