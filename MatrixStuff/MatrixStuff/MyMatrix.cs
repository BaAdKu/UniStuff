using System;
using System.Collections.Generic;

namespace MatrixStuff
{
    class MyMatrix
    {
        private List<List<int>> matrix;
        private int x;
        private int y;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public List<List<int>> Matrix { get { return matrix; } set { matrix = value; } }


        public MyMatrix(int _x, int _y)
        {
            matrix = new List<List<int>>();
            for (int i = 0; i < x; i++)
            {
                matrix.Add(new List<int>(y));
            }
            x = _x;
            y = _y;
        }

        public void Init()
        {
            foreach (List<int> item in matrix)
            {
                for (int i = 0; i < item.Capacity; i++)
                {
                    item[i] = 0;
                }
            }
        }

        public void FillRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i][j] = rnd.Next(0, 9);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(matrix[i][j] + "    ");
                }
            }
        }

        public void Input()
        {
            Console.WriteLine("\nplease start entering the matrix");
            string[] tokens = Console.ReadLine().Split();

            if(tokens.Length>(x*y))
            {
                Console.WriteLine("Matrices not compatible. sorry");
                return;
            }
            int xway = 0, yway = 0;
            foreach (string item in tokens)
            {
                matrix[xway][yway] = int.Parse(item);
                if (xway < x - 1)
                {
                    xway++;
                }
                else
                {
                    yway++;
                    xway = 0;
                }
            }
        }


        public MyMatrix Add(MyMatrix m)
        {
            int start_timer, elapsed_time;
            start_timer = DateTime.Now.Millisecond;
            int counter = 0;
            if (m.Y != y && m.X != x)
            {
                Console.WriteLine("Matrices not compatible. sorry");
                return null;
            }
            MyMatrix res = new MyMatrix(x, y);
            res.Init();

            for (int _x = 0; _x < x; _x++)
            {
                for (int _y = 0; _y < y; _y++)
                {
                    res.Matrix[_x][_y] = m.Matrix[_x][_y] + matrix[_x][_y];
                    counter+=2;
                }
                counter++;
            }
            elapsed_time = DateTime.Now.Millisecond - start_timer;
            Console.WriteLine("\nThis Operation took " + elapsed_time.ToString() + "and took " + counter.ToString() + " Steps");

            return res;
            
        }


        public MyMatrix Mult(MyMatrix m)
        {
            int start_timer, elapsed_time;
            start_timer = DateTime.Now.Millisecond;
            int counter = 0;
            if (y != m.X)
            {
                Console.WriteLine("Matrices not compatible. sorry");
                return null;
            }

            MyMatrix res = new MyMatrix(x, m.Y);
            res.Init();

            for (int i = 0; i < res.Y; i++)
            {
                for (int j = 0; j < res.X; j++)
                {
                    int sum=0;
                    for (int k = 0; k < x; k++)
                    {
                        sum += matrix[k][i] + m.Matrix[j][k];
                        counter+=2;
                    }
                    counter++;
                }
                counter++;
            }
            elapsed_time = DateTime.Now.Millisecond - start_timer;
            Console.WriteLine("\nThis Operation took " + elapsed_time.ToString() + "and took " + counter.ToString() + " Steps");
            return res;
        }

    }
}
