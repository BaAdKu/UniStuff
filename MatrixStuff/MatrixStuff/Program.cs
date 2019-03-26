using System;

namespace MatrixStuff
{
    class Program
    {

        private enum choices
        {
            print = 'p',
            init = 'i',
            fillrandom = 'r',
            input = 'f',
            addition = 'a',
            multiply = 'm',
            def = ' ',
            exit = 'x',
            cancel = 'c'
        }
        static void Main(string[] args)
        {
            choices choice = choices.def;
            string[] tokens;

            MyMatrix matr1, matr2, matr3;

            while (choice != choices.exit)
            {
                Console.WriteLine("Hey, please enter size for new matrix ");

                tokens = Console.ReadLine().Split();

                matr1 = new MyMatrix(int.Parse(tokens[0]), int.Parse(tokens[1]));
                Console.WriteLine("\nGreat. whatcha wanna do? 'a' for add, 'm' for multiplication, 'f' for fill, 'p' for print, 'i' for init, 'r' for fillrandom, 'f' to fill in from input, or 'x' to exit, and 'c' to cancel " +
                    "working on a matrix ");
                while (choice != choices.cancel)
                {
                    choice = (choices)Console.ReadKey().KeyChar;
                    switch (choice)
                    {
                        case choices.print:
                            matr1.Print();
                            break;
                        case choices.init:
                            matr1.Init();
                            break;
                        case choices.fillrandom:
                            matr1.FillRandom();
                            break;
                        case choices.input:
                            matr1.Input();
                            break;
                        case choices.addition:
                            {
                                matr2 = new MyMatrix(matr1.X, matr1.Y);
                                matr2.Init();
                                Console.WriteLine("Great. Please enter how you wanna fill that other matrix. f for regular input, r for random");
                                if (Console.ReadKey().KeyChar == 'f')
                                {
                                    matr2.Input();
                                    matr3 = matr1.Add(matr2);
                                    matr3.Print();
                                }
                                else if (Console.ReadKey().KeyChar == 'r')
                                {
                                    matr2.FillRandom();
                                    matr3 = matr1.Add(matr2);
                                    matr3.Print();
                                }
                                else
                                    Console.WriteLine("Well darn. that didn't work;");
                            }
                            break;
                        case choices.multiply:
                            Console.WriteLine("how large should that other one be? one num please");

                            matr2 = new MyMatrix(int.Parse(Console.ReadLine().Split()[0]), matr1.Y);
                            matr2.Init();
                            Console.WriteLine("Great. Please enter how you wanna fill that other matrix. f for regular input, r for random");
                            if (Console.ReadKey().KeyChar == 'f')
                            {
                                matr2.Input();
                                matr3 = matr1.Mult(matr2);
                                matr3.Print();
                            }
                            else if (Console.ReadKey().KeyChar == 'r')
                            {
                                matr2.FillRandom();
                                matr3 = matr1.Mult(matr2);
                                matr3.Print();
                            }
                            else
                                Console.WriteLine("Well darn. that didn't work;");
                            break;                                         
                        default:
                            break;
                    }
                }
            }



        }
    }
}
