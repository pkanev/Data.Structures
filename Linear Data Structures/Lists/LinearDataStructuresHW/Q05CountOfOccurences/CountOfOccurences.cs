using System;
using System.Collections.Generic;
using System.Linq;

namespace Q05CountOfOccurences
{
    class CountOfOccurences
    {
        /// <summary>
        /// prints the number of occurendces of every element of the array in a sorted order
        /// </summary>
        static void PrintCount(int[] arr)
        {
            Dictionary<int, int> frequencies = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (!frequencies.ContainsKey(num))
                {
                    frequencies.Add(num, 1);
                }
                else
                {
                    frequencies[num]++;
                }
            }

            foreach (KeyValuePair<int, int> pair in frequencies.OrderBy(v1 => v1.Key))
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
            Console.WriteLine("===============");
        }

        /// <summary>
        /// Allows the user to enter a custom list of integers and then performs on it PrintCount
        /// </summary>
        static void CustomPrintOut()
        {
            Console.WriteLine("Test your own sequence of numbers!");
            Console.Write("Please enter integers separated by a space: ");
            string line = Console.ReadLine();
            if (line != null)
            {
                string[] input = line.Trim().Split(' ');
                int lengthOfInput = input.Length;
                int n;
                if (!((input.Length == 1) && (input[0] == "")))
                {
                    int[] numbers = new int[lengthOfInput];
                    for (int i = 0; i < lengthOfInput; i++)
                    {
                        bool result = int.TryParse(input[i], out n);
                        if (result)
                        {
                            numbers[i] = n;
                        }
                        else
                        {
                            throw new ArgumentException("Please, enter only integers");
                        }
                    }
                    PrintCount(numbers);
                }
                else
                {
                    Console.WriteLine("You did not input any numbers");
                }
            }
            else
            {
                Console.WriteLine("You did not input anything");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                int[][] testArrs = 
                {
                    new int[] {3,4,4,2,3,3,4,3,2},
                    new int[] {1000}, 
                    new int[] {0,0,0}, 
                    new int[] {7,6,5,5,6}
                };
                foreach (var arr in testArrs)
                {
                    PrintCount(arr);
                }
                CustomPrintOut();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
