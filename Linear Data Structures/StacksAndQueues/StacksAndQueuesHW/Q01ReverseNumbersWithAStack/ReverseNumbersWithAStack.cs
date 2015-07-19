using System;
using System.Collections.Generic;

namespace Q01ReverseNumbersWithAStack
{
    class ReverseNumbersWithAStack
    {
        /// <summary>
        /// Reads N integers, reverses them and prints them to the console.
        /// </summary>
        static void ReverseNums(string input)
        {
            Stack<int> numbers = new Stack<int>();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("(empty)");
                return;
            }
            string[] inputArr = input.Trim().Split(' ');

            foreach (string s in inputArr)
            {
                numbers.Push(int.Parse(s));
            }
            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + " ");
            }
            Console.WriteLine();
        }
        static void Main()
        {
            
            string s1 = "1 2 3 4 5";
            Console.Write("{0} => ", s1);
            ReverseNums(s1); ;
            string s2 = "1";
            Console.Write("{0} => ", s2);
            ReverseNums(s2);
            string s3 = "";
            Console.Write("{0} => ", s3);
            ReverseNums(s3);
            string s4 = "1 -2";
            Console.Write("{0} => ", s4);
            ReverseNums(s4);
            
            Console.WriteLine("Please enter your numbers separated by a space:");
            string line = Console.ReadLine();
            Console.Write("{0} => ", line);
            ReverseNums(line);
        }
    }
}
