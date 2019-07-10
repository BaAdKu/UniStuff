using System;
using System.Collections.Generic;

namespace randomizer
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                int choice = 0;
                Console.WriteLine("Enter max int");
                choice = int.Parse(Console.ReadLine());
                randomizer rando = new randomizer(choice);
                for (int i = 0; i < choice; i++)
                {
                    Console.WriteLine(rando.randomlist[i]);
                }
            }
        }
    }
    class randomizer
    {
        public List<int> randomlist;
        public randomizer(int max)
        {
            randomlist = new List<int>(max);
            Random r = new Random(45233);
            int placeholder = 0;
            for (int i = 0; i < max; i++)
            {
                placeholder = r.Next(max)+1;
                while (randomlist.Contains(placeholder))
                {
                    placeholder = r.Next(max)+1;
                }
                randomlist.Add(placeholder);
            }
        }
    }
}
