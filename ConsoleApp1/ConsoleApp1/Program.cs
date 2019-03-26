using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice = ' ';
            string[] tokens;
            int a, b;
            char choicerec = ' ';
            ggt g;
            kgv k;
            eras e;
            while (choice != 'x')
            {
                Console.WriteLine("\nHai. Whatcha wanna do?\npress 'k' for kgv, 'g' for ggt, 'e' for erastothenes, 'x' to exit");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case 'k':
                        Console.WriteLine("\nplz enter two numbers to compute");
                        tokens = Console.ReadLine().Split();

                        a = int.Parse(tokens[0]);
                        b = int.Parse(tokens[1]);
                        k = new kgv(a, b);
                        Console.WriteLine("\nthe smallest common multiple is " + k.calc().ToString());
                        break;
                    case 'g':
                        Console.WriteLine("\nplz enter two numbers to compute");
                        tokens = Console.ReadLine().Split();

                        a = int.Parse(tokens[0]);
                        b = int.Parse(tokens[1]);

                        Console.WriteLine("\nwanna do recursive stuff? y/n");
                        choicerec = Console.ReadKey().KeyChar;
                        if (choicerec == 'y')
                        {
                            g = new ggt(a, b, true);
                        }
                        else
                        {
                            g = new ggt(a, b);
                        }
                        Console.WriteLine("\nthe largest common divisor is " + g.calc().ToString());
                        break;
                    case 'e':

                        Console.WriteLine("\nWhats the limit?");
                        tokens = Console.ReadLine().Split();
                        a = int.Parse(tokens[0]);
                        e = new eras(a);

                        Console.WriteLine("\nThe Prime numbers are: ");
                        int i = 0;
                        foreach (int item in e.Calc())
                        {
                            if (i != 0 && i % 10 == 0)
                            {
                                Console.Write('\n');
                            }

                            Console.Write(item.ToString() + " ");
                            i++;
                        }
                        break;
                    default:
                        Console.WriteLine("huh, what? try again");
                        break;
                }
            }
        }
    }

    /// <summary>
    /// a class to compute the smallest common multiplier. simply the product of the both numbers divided by largest common divisor
    /// </summary>
    class kgv
    {
        private int a;
        private int b;

        public kgv(int A, int B)
        {
            a = A;
            b = B;
        }

        public int calc()
        {
            ggt ggt = new ggt(a, b);
            return a * b / ggt.calc();
        }
    }
    /// <summary>
    /// a class to compute largest common divisor. recursive is better if you have more space, iterative if time is a non-issue
    /// </summary>
    class ggt
    {
        private int a;
        private int b;
        private bool rec;

        /// <summary>
        /// initiates this class with the numbers A, B and a bool to indicate if recursive or iterative method is desired
        /// </summary>
        /// <param name="A">first variable</param>
        /// <param name="B">second variable</param>
        /// <param name="Rec">method switch -> true is recursive, false is iterative</param>
        public ggt(int A, int B, bool Rec = false)
        {
            if (A > B)
            {
                a = A;
                b = B;
            }
            else
            {
                a = B;
                b = A;
            }
            rec = Rec;
        }

        public int calc()
        {
            if (rec)
                return calc_rec(a, b, a % b);
            else
                return calc_it();
        }

        private int calc_it()
        {
            int r = a % b;
            int a_temp = a;
            int b_temp = b;
            do
            {
                r = a_temp % b_temp;
                a_temp = b_temp;
                b_temp = r;
            }
            while (r != 0);
            return a_temp;
        }

        private int calc_rec(int a_temp, int b_temp, int r)
        {
            if (r == 0)
                return a_temp;
            else
                return calc_rec(b_temp, r, a_temp % b_temp);
        }
    }

    class eras
    {
        private int max;
        /// <summary>
        /// preps for the sieve of eratosthenes
        /// </summary>
        /// <param name="M"></param>
        public eras(int M)
        {
            max = M;
         
        }

        public List<int> Calc()
        {

            List<Tuple<int, bool>> res = PrepareList();

            int tempint = 0;

            int maxchecked = (int)Math.Sqrt(max);

            for (int i = 1; i < maxchecked; i++)
            {
                if (res[i].Item2 == true)
                {
                    for (int j = res[i].Item1* res[i].Item1-1; j < res.Count; j += res[i].Item1)
                    {
                        if (res[j].Item2)
                        {
                            tempint = res[j].Item1;
                            res[j] = new Tuple<int, bool>(tempint, false);
                        }
                    }
                }
            }
            return Res_PostProcess(res);
        }

        private List<int> Res_PostProcess(List<Tuple<int, bool>> res)
        {
            List<int> newres = new List<int>();
            foreach (var item in res)
            {
                if (item.Item2)
                {
                    newres.Add(item.Item1);
                }
            }
            return newres;
        }

        private List<Tuple<int, bool>> PrepareList()
        {
            List<Tuple<int, bool>> res = new List<Tuple<int, bool>>();
            for (int i = 1; i <= max; i++)
            {
                res.Add(new Tuple<int, bool>(i, true));
            }

            return res;
        }
    }
}
