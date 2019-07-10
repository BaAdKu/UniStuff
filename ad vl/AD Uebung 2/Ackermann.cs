using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex23
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();            
            string[] input;
            char choice= ' ';
            while (true)
            {
                Console.WriteLine("please enter two numbers, divided by a space");
                input = Console.ReadLine().Split();
                Console.WriteLine("please enter r for recursive algo, i for iterative");                
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (choice == 'r')
                {
                    Console.WriteLine(p.rek_func(int.Parse(input[0]), int.Parse(input[1])));
                }
                else if(choice=='i')
                {
                    Console.WriteLine(p.it_func(int.Parse(input[0]), int.Parse(input[1])));
                }
                Console.WriteLine("programm ended");
            }
        }

        /// <summary>
        ///           / m+1                if n=0
        /// f(n, m)= {  f(n-1, 1)          if m=0&&n>=1
        ///           \ f(n-1, f(n, m-1)   rest
        /// </summary>  
        
        int rek_func(int n, int m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if (m == 0 && n >= 1)
            {
                return rek_func(n - 1, 1);
            }
            else
            {
                return rek_func(n - 1, rek_func(n, m - 1));
            }
        }

        int it_func(int n, int m)
        {
            int[] Stack = new int[3000];
            int stackpointer = 0;
            Stack[0] = n;
            Stack[1] = m;

            while (true)
            {
                if (Stack[stackpointer] == 0)
                {
                    if (stackpointer == 0)
                    {
                        Stack[stackpointer+1]++;//case 1 and return
                        break;
                    }
                    else
                    {
                        Stack[stackpointer - 1] = (Stack[stackpointer + 1] + 1);//case 1 and continue
                        stackpointer -= 2;
                    }
                }
                else if (Stack[stackpointer + 1] == 0)
                {
                    Stack[stackpointer]--;//case 2
                    Stack[stackpointer + 1] = 1;
                }
                else
                {
                    stackpointer += 2;//new stackpair
                    Stack[stackpointer] = Stack[stackpointer - 2];//funccall in funccall
                    Stack[stackpointer + 1] = --Stack[stackpointer - 1];//funccall in funccall
                    Stack[stackpointer - 2]--;//first funccall
                }
            }
            return Stack[1];

        }

    }
}
