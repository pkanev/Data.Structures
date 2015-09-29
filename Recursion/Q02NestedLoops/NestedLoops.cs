namespace Q02NestedLoops
{
    using System;
    using System.Linq;

    class NestedLoops
    {
        static void GenerateNestedLoops(int index, int[] numbers, int end)
        {
            if (index < 0)
            {
                PrintNumbers(numbers);
            }
            else
            {
                for (int i = 1; i <= end; i++)
                {
                    numbers[index] = i;
                    GenerateNestedLoops(index - 1, numbers, end);
                }
            }
        }

        private static void PrintNumbers(int[] numbers)
        {
            var revNumbers = numbers.Reverse();
            foreach (var number in revNumbers)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            GenerateNestedLoops(n-1, numbers, n);
        }
    }
}
