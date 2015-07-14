using System;
using System.Collections.Generic;
using System.Linq;

namespace Q01SumAndAverage
{
    class SumAndAvarage
    {
        /// <summary>
        /// Returns a list of integers or an empty list if not data is entered
        /// </summary>
        static List<int> CreateList()
        {
            List<int> numbers = new List<int>();
            Console.Write("Please enter integers separated by a space: ");
            string line = Console.ReadLine();
            if (line != null)
            {
                string[] input = line.Trim().Split(' ');
                
                int length = input.Length;
                if (length == 1 && input[0] == "")
                {
                    return numbers;
                }
                for (int index = 0; index < length; index++)
                {   
                    numbers.Add(int.Parse(input[index]));
                }
                return numbers;
            }
            else
            {
                return numbers;
            }
        }
        
        /// <summary>
        /// Uses the built in .Sum() and .Average() methods and returns them as a formatted string
        /// </summary>
        static string SumAndAverageToString(List<int> list)
        {
            if (list.Count == 0)
            {
                return "Sum=0; Average=0";
            }
            string output = string.Format("Sum={0}; Average={1}", list.Sum(), list.Average());
            return output;
        }
        static void Main(string[] args)
        {
            List<int> numbers = CreateList();
            Console.WriteLine(SumAndAverageToString(numbers));
        }
    }
}
