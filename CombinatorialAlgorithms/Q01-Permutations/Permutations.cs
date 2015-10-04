namespace Q01_Permutations
{
    using System;
    using System.Linq;

    class Permutations
    {
        private static int countOfPermutations = 0;
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            var array = Enumerable.Range(1, n).ToArray();
            Permutate(array);
            Console.WriteLine("Total permutations: {0}", countOfPermutations);

        }

        private static void Permutate(int[] array, int startIndex = 0)
        {
            if (startIndex >= array.Length - 1)
            {
                countOfPermutations++;
                Print(array);
            }
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    Permutate(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }
        }

        private static void Swap<T>(ref T i, ref T j) where T : IComparable
        {
            if (i.Equals(j))
            {
                return;
            }
            T old = i;
            i = j;
            j = old;
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
