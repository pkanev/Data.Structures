namespace Q04_Generate_subsets_with_recursion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GenerateSubsetsWithRecursion
    {
        private static int count = 0;
        private static string[] words;
        static void Main()
        {
            Console.Write("s = ");
            string input = Console.ReadLine();
            input = input.Substring(1, input.Length - 2);
            words = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = words.Length;
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            var array = new int[k];

            GenerateCombinations(array, n);
            Console.WriteLine("Total number of combinations: {0}", count);
        }

        private static void GenerateCombinations(int[] array, int sizeOfSet, int index = 0, int start = 1)
        {
            if (index >= array.Length)
            {
                count ++;
                Print(array);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateCombinations(array, sizeOfSet, index + 1, i + 1);
                }
            }
        }

        private static void Print(int[] array)
        {
            var results = array.Select(i => words[i - 1]).ToList();
            Console.WriteLine("({0})", string.Join(" ", results));
        }
    }
}
