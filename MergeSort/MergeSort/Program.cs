using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MergeSort
    {
        public int[] array { get; set; }

        public MergeSort(int[] arr)
        {
            array = arr;
        }

        public MergeSort()
        {

        }

        public void sort()
        {
            sort(0, array.Length - 1);
        }
        public void sort(int f, int l )
        {
            if (f < l)
            {
                int m = (f + l + 1) / 2;
                sort(f, m - 1);
                sort(m, l);
                merge(f, l, m);
            }
        }

        private void merge(int f, int l, int m)
        {
            int i, n = l - f + 1;
            int a1f = f, a1l = m - 1;
            int a2f = m, a2l = l;
            int[] arrnew = new int[n];

            for (i = 0; i < n; i++)
            {
                if(a1f<a1l)
            }
            
        }
    }
}
