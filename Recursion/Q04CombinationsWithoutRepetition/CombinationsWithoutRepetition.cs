namespace Q04CombinationsWithoutRepetition
{
    using System;

    class CombinationsWithoutRepetition
    {
        private static void GenerateCombinations(int[] numbers, int index, int startNum, int endNum)
        {
            if (index >= numbers.Length)
            {
                Console.WriteLine("( " + string.Join(" ", numbers) + " )");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    numbers[index] = i;
                    GenerateCombinations(numbers, index + 1, i + 1, endNum);
                }
            }
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            var numbers = new int[k];
            GenerateCombinations(numbers, 0, 1, n);

        }
    }
}
