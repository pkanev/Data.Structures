namespace Q02_Permutations_with_iteration
{
    // solution based on http://www.quickperm.org/
    using System;
    using System.Linq;

    class PermutationsWithIteration
    {
        private static int permCount = 0;
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();
            var control = Enumerable.Range(0, n+1).ToArray();
            var index = 1;
            
            Print(array);
            permCount ++;

            while (index < n)
            {
                int otherIndex;
                control[index] -= 1;
                if (index % 2 == 1)
                {
                    otherIndex = control[index];
                }
                else
                {
                    otherIndex = 0;
                }
                Swap(ref array[otherIndex], ref array[index]);
                index = 1;
                while (control[index] == 0)
                {
                    control[index] = index;
                    index += 1;
                }
                permCount ++;
                Print(array);
            }
            Console.WriteLine("Total permutations: {0}", permCount);
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
