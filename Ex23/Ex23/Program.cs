using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex23
{
    class Program
    {
        Stack<int> intstack;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.intstack = new Stack<int>();
            string[] input;
            while (true)
            {
                Console.WriteLine("please enter two numbers, divided by a space");
                input = Console.ReadLine().Split();
                Console.WriteLine(p.rek_func(int.Parse(input[0]), int.Parse(input[1])));
                Console.WriteLine("programm ended");
            }
        }


        int rek_func(int n, int m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if(m==0&&n>=1)
            {
                return rek_func(n - 1, 1);
            }
            else
            {
                return rek_func(n - 1, rek_func(n, m - 1));
            }

        }

        //int it_func(int n, int m)
        //{

        //}

    }
}
