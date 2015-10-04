namespace Q03_Combinations_with_iteration
{
    using System;
    using System.Collections.Generic;

    class CombinationsWithIterations
    {
        // solution based on http://rosettacode.org/wiki/Combinations#C.23
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            int count = 0;

            foreach (var combination in Combinations(k, n))
            {
                Console.WriteLine(string.Join(", ", combination));
                count ++;
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
