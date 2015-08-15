using System;
using System.Collections.Generic;
using System.Linq;
using Q01Dictionary;

namespace Q02CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string input1 = "SoftUni rocks";
            string input2 = "Did you know Math.Round rounds to the nearest even integer?";
            Console.WriteLine(input1);
            PrintCountedSymbols(input1);
            Console.WriteLine("==========");
            Console.WriteLine(input2);
            PrintCountedSymbols(input2);
            Console.WriteLine("==========");
            Console.WriteLine("Please enter a sentence:");
            string input3 = Console.ReadLine();
            PrintCountedSymbols(input3);
        }

        private static void PrintCountedSymbols(string input)
        {
            char[] arr = input.ToCharArray();
            var dictionary = new HashTable<char, int>();
            foreach (var c in arr)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary.Add(c, 0);
                }
                dictionary[c] ++;
            }
            var list = dictionary.ToList().OrderBy(k => k.Key);
            foreach (var keyValue in list)
            {
                Console.WriteLine("{0}: {1}", keyValue.Key, keyValue.Value);
            }
        }
    }
}
