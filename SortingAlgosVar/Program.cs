using System;

namespace SortingAlgosVar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[30];
            Random ran = new Random();
            SortingAlgos.algos input = SortingAlgos.algos.d;
            SortingAlgos Algorithm = new SortingAlgos();
            char inputc;
            bool cont = true;
            while (cont)
            {
                for (int i = 0; i < 29; i++)
                {
                    arr[i] = ran.Next(100);
                }
                //    Console.WriteLine("please decide on sorting algo. \nb for bubble, \ni for insertion, \nq for Quicksort, \nor the large letter for the adapted algo \npress x to exit");

                //    inputc = Console.ReadKey().KeyChar;
                //    switch (inputc)
                //    {
                //        case 'i':
                //            input = SortingAlgos.algos.i;
                //            break;
                //        case 'I':
                //            input = SortingAlgos.algos.I;
                //            break;
                //        case 'b':
                //            input = SortingAlgos.algos.b;
                //            break;
                //        case 'B':
                //            input = SortingAlgos.algos.B;
                //            break;
                //        case 's':
                //            input = SortingAlgos.algos.s;
                //            break;
                //        case 'S':
                //            input = SortingAlgos.algos.S;
                //            break;
                //        case 'q':
                //            input = SortingAlgos.algos.q;
                //            break;
                //        case 'Q':
                //            input = SortingAlgos.algos.Q;
                //            break;
                //        case 'x':
                //            cont = false;
                //            break;
                //        default:
                //            break;
                //    }
                //    Console.WriteLine();
                //    Algorithm.printArray(arr, arr.Length);
                //    switch (input)
                //    {
                //        case SortingAlgos.algos.b:
                //            Algorithm.BubbleSort(arr);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.i:
                //            Algorithm.InsertionSort(arr);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.s:
                //            Algorithm.SelectionSort(arr);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.q:
                //            Algorithm.QuickSort(arr, 0, arr.Length - 1);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.B:
                //            Algorithm.BubbleSortRev(arr);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.I:
                //            Algorithm.InsertionSortRev(arr);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.S:
                //            Algorithm.SelectionSortRev(arr);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.Q:
                //            Algorithm.QuickSortRand(arr, 0, arr.Length - 1);
                //            Algorithm.printArray(arr, arr.Length);
                //            break;
                //        case SortingAlgos.algos.d:
                //        default:
                //            break;
                //    }
                //    Console.ReadKey();


                Algorithm.printArray(arr, arr.Length);
                Console.WriteLine("please enter an integer to be checked if it can be built as a sum by the members of the array");
                int sum = int.Parse(Console.ReadLine());
                if (Algorithm.SumCheck(arr, sum))
                    Console.WriteLine("yep");
                else
                    Console.WriteLine("nope");
            }
        }
    }

    class SortingAlgos
    {

        public enum algos { b, i, s, q, B, I, S, Q, d }
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            int temp;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = key;
            }
        }
        public void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            int temp;
            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                    temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
        }
        public void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int PartIn = QuickSortPart(arr, low, high);
                QuickSort(arr, low, PartIn - 1);
                QuickSort(arr, PartIn + 1, high);

            }
        }

        private int QuickSortPart(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }
        public void BubbleSortRev(int[] arr)
        {
            int n = arr.Length;
            int temp;
            for (int i = n; i >= 0; i--)
            {
                for (int j = n; j > i + 1; j--)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
        public void InsertionSortRev(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = key;
            }
        }
        public void SelectionSortRev(int[] arr)
        {
            int n = arr.Length;
            int temp;
            for (int i = 0; i < n; i++)
            {
                int max = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] > arr[max])
                    {
                        max = j;
                    }
                    temp = arr[max];
                    arr[max] = arr[i];
                    arr[i] = temp;
                }
            }
        }
        public void QuickSortRand(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int PartIn = QuickSortRandPart(arr, low, high);
                QuickSortRand(arr, low, PartIn - 1);
                QuickSortRand(arr, PartIn + 1, high);
            }
        }
        private int QuickSortRandPart(int[] arr, int low, int high)
        {
            Random rand = new Random();
            int pivot = arr[rand.Next(low + 1, high)];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }

        public void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// This will first sort by using Quicksort (which has n*log(n)), and then iterate over array once (n), to find if a sum match is possible. 
        /// Runtime-> Theta(n*log(n))
        /// </summary>
        /// <param name="arr">the array</param>
        /// <param name="sum">the sum to be searched for</param>
        /// <returns></returns>
        public bool SumCheck(int[] arr, int sum)
        {
            QuickSort(arr, 0, arr.Length-1);
            for (int f = 0, l = arr.Length - 1; f < l;)
            {
                if (arr[f] + arr[l] < sum)
                {
                    f++;
                }
                else if (arr[f] + arr[l] > sum)
                {
                    l--;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

    }
}
