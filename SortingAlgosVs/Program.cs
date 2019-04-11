using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingAlgosVs
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice = 'c';
            Console.WriteLine("Hello World!");
            while (choice == 'c')
            {
                SortStuff();
                Console.WriteLine("go again? press c for continue, anything else to cancel");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
        /// <summary>
        /// radix sort can do approx 1039530380 numbers in a minute, 
        /// bubblesort can do approx 306185082 numbers in a minute
        /// 
        /// while using a maximum of 33% of processing power
        /// it does eat up ram like crazy, though
        /// </summary>
        private static void SortStuff()
        {
            int arrlistsize = 0;
            int bubblesortmanaged = 0;
            int radixsortmanaged = 0;
            Console.WriteLine("Hey, please enter how many arrays with 5 to 100 members you wanna have sorted");
            arrlistsize = int.Parse(Console.ReadLine());
            arraylist bal = new arraylist(arrlistsize);

            Stopwatch btimer = new Stopwatch();
            Stopwatch rtimer = new Stopwatch();

            btimer.Start();
            foreach (var item in bal.arrlist)
            {
                BubbleSort(item.arr);
                bubblesortmanaged += item.arr.Length;
            }
            btimer.Stop();
            bal.Destroy();
            arraylist ral = new arraylist(arrlistsize);
            rtimer.Start();
            foreach (var item in ral.arrlist)
            {
                radixsort(item.arr, item.arr.Length-1);
                radixsortmanaged += item.arr.Length;
            }
            rtimer.Stop();
            ral.Destroy();
            Console.WriteLine("Bubblesort managed " + bubblesortmanaged.ToString() + " numbers  in {0} ms", btimer.Elapsed);
            Console.WriteLine("Radixsort managed " + radixsortmanaged.ToString() + " numbers  in {0} ms", rtimer.Elapsed);

        }

        #region radixsort

        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array  
            int i;
            int[] count = new int[10];


            for (i = 0; i < 10; i++)
                count[i] = 0;

            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }
        public static void radixsort(int[] arr, int n)
        {
            int m = getMax(arr, n);
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
        #endregion
        #region bubblesort
        public static void BubbleSort(int[] arr)
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
        #endregion
    }

    class arraylist
    {
        public List<arrays> arrlist;
        public int Length;
        public arraylist(int n)
        {
            Random rand = new Random();
            arrlist = new List<arrays>();
            Length = n;
            for (int i = 0; i < n; i++)
            {
                arrlist.Add(new arrays(rand.Next(5, 100)));
            }
        }

        public void Destroy()
        {
            arrlist.Clear();
            arrlist = null;
            Console.WriteLine("a list of arrays has been destroyed");
        }
    }
    class arrays
    {
        public int[] arr;
        public arrays (int n)
        {
            Random rand = new Random();
            arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(100);
            }            
        }
    }
}
