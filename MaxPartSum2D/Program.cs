using System;
using System.Collections.Generic;

namespace MaxPartSum2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Matrix2d matr = new Matrix2d(10, 10);

            matr.RandomizeContent();
            matr.PrintMatrix();
            Console.WriteLine(matr.MaxSum2D().ToString()+" for the upper limit of "+ matr.finalTop + " for the lower limit of " 
                + matr.finalBot + " for the left limit of " + matr.finalLeft + " for the right limit of " + matr.finalRight);
            Console.ReadKey();
        }
    }


    class Matrix2d
    {
     int[,] Matrix;
        private int Row;
        private int Column;
        public int finalTop;
        public int finalBot;
        public int finalLeft;
        public int finalRight;

        Random rand = new Random();
        public Matrix2d(int row, int column)
        {

            Row = row;
            Column = column;
            Matrix = new int[row, column];
        }

        public void RandomizeContent()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Matrix[i,j] = rand.Next(-10, 10);
                }
            }
        }


        public void PrintMatrix()
        {
            for (int i = 0; i < Column; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        private int Kadane(int[] arr, ref int start, ref int finish)
        {
            int sum = 0, maxSum = int.MinValue, i;
            finish = -1;
            int locStart = 0;
            for (i = 0; i < Row; ++i)
            {
                sum += arr[i];
                if (sum < 0)
                {
                    sum = 0;
                    locStart = i + 1;

                }
                else if (sum > maxSum)
                {
                    maxSum = sum;
                    start = locStart;
                    finish = i;
                }

            }

            if (finish != -1)
            {
                return maxSum;
            }

            maxSum = arr[0];
            start = finish = 0;

            for (i = 0; i < Row; i++)
            {
                if (arr[i] > maxSum)
                {
                    maxSum = arr[i];
                    start = finish = i;
                }
            }

            return maxSum;
        }


        public int MaxSum2D()
        {
            int maxSum = int.MinValue;

            int left, right, up=-1, down=-1, i, sum;
            int[] temp = new int[Row];

            for (left = 0; left < Column; ++left)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = 0;
                }
                for (right = left; right < Column; ++right)
                {


                    for (i = 0; i < Row; i++)
                    {
                        temp[i] += Matrix[i,right];
                    }

                    sum = Kadane(temp, start: ref up, finish: ref down);
                    if(sum>maxSum)
                    {
                        maxSum = sum;
                        finalBot = down;
                        finalLeft = left;
                        finalRight = right;
                        finalTop = up;
                    }
                }
            }

            return maxSum;

        }
    }


}
