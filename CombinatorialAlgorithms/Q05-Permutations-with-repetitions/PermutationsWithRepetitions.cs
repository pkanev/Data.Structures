namespace Q05_Permutations_with_repetitions
{
    using System;

    class PermutationsWithRepetitions
    {
        static void Main()
        {
            Console.Write("s = ");
            string input = Console.ReadLine();
            input = input.Substring(1, input.Length - 2);
            var set = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(set);
            PermuteRep(set, 0, set.Length - 1);
        }
        static void PermuteRep<T>(T[] arr, int start, int end) where T : IComparable
        {
            Print(arr);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (!arr[left].Equals(arr[right]))
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, end);
                    }
                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                    arr[i] = arr[i + 1];
                arr[end] = firstElement;
            }
        }
        private static void Swap<T>(ref T p1, ref T p2)
        {
            T old = p1;
            p1 = p2;
            p2 = old;
        }
        private static void Print<T>(T[] x)
        {
            Console.WriteLine("(" + string.Join(", ", x) + ")");
        }

    }
}
