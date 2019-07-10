using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string feeling=string.Empty;
            bool choice = true;
            while (choice)
            {
                Console.WriteLine("Hello there, whats your name?");
                name = Console.ReadLine();
                Console.WriteLine("Hello, " + name + ", how are you today?");
                feeling = Console.ReadLine();
                if (feeling == "fine")
                {
                    Console.WriteLine("That's nice to hear!");
                }
                else if (feeling == "bad")
                {
                    Console.WriteLine("Oh no, thats aweful");
                }
                else
                {
                    Console.WriteLine("Huh, Cool");
                    choice = false;
                }
            }
        }
    }
}
