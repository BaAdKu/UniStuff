using System;

namespace Uebung_4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = new int[20];
            int[] arr2 = new int[20];
            SortingAlgosChanged algos = new SortingAlgosChanged();
            algos.fillArray(arr);
            algos.printarray(arr);
            algos.RecInsertSort(arr, arr.Length);
            algos.printarray(arr);
            Console.ReadKey();

            algos.fillArray(arr2);
            algos.printarray(arr2);
            algos.ItMergeSort(arr2, 0, arr2.Length - 1);
            algos.printarray(arr2);
            Console.ReadKey();

        }

    }
    class SortingAlgosChanged
    {
        public void printarray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public void fillArray(int[] arr)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 100);
            }
        }

        public void RecInsertSort(int[] arr, int length)
        {
            int last = arr[length - 1];
            int j = length - 2;

            if (length <= 1)
            {
                return;
            }
            RecInsertSort(arr, length - 1);

            while (j >= 0 && arr[j] > last)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = last;
        }


        public void ItMergeSort(int[] arr, int left, int right)
        {
            if (left<right)
            {
                int middle = left + (right - left) / 2;
                ItMergeSort(arr, left, middle);
                ItMergeSort(arr, middle + 1, right);
                ItMerge(arr, left, middle, right);
            }
        }

        private void ItMerge(int[] arr, int left, int middle, int right)
        {
            int leftRun, rightRun, totalRun;
            int sizeLeft = middle - left + 1;
            int sizeRight= right - middle;

            int[] larr = new int[sizeLeft];
            int[] rarr = new int[sizeRight];
            for ( leftRun = 0; leftRun < sizeLeft; leftRun++)
            {
                larr[leftRun] = arr[left + leftRun];
            }
            for ( rightRun = 0; rightRun < sizeRight; rightRun++)
            {
                rarr[rightRun] = arr[middle + rightRun + 1];
            }

            leftRun = rightRun = 0;
            totalRun = left;

            while (leftRun<sizeLeft&&rightRun<sizeRight)
            {
                if(larr[leftRun]<=rarr[rightRun])
                {
                    arr[totalRun] = larr[leftRun];
                    leftRun++;
                }
                else
                {
                    arr[totalRun] = rarr[rightRun];
                    rightRun++;
                }
                totalRun++;
            }

            while (leftRun<sizeLeft)
            {
                arr[totalRun] = larr[leftRun];
                leftRun++;
                totalRun++;
            }
            while (rightRun < sizeRight)
            {
                arr[totalRun] = rarr[rightRun];
                rightRun++;
                totalRun++;
            }
        }
    }
}
