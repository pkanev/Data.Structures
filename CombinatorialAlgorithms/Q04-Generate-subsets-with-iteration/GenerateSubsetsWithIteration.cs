namespace Q04_Generate_subsets_with_iteration
{
    using System;
    using System.Collections.Generic;

    class GenerateSubsetsWithIteration
    {
        static void Main()
        {
            Console.Write("s = ");
            string input = Console.ReadLine();
            input = input.Substring(1, input.Length - 2);
            string[] strings = input.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            int n = strings.Length;
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            int count = 0;

            foreach (var combination in Combinations(k, n-1, true))
            {
                var results = new List<string>();
                foreach (var i in combination)
                {
                    results.Add(strings[i]);
                }
                Console.WriteLine("({0})", string.Join(" ", results));
                count++;
            }
            Console.WriteLine("Total number of combinations: {0}", count);
        }

        public static IEnumerable<int[]> Combinations(int m, int n, bool startFromZero = false)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(startFromZero ? 0 : 1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
