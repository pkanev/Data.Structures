namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 100;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            Console.WriteLine("Sort:");
            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });
            Console.WriteLine(collectionToSort);
            Console.WriteLine("Shuffle:");
            collectionToSort.Shuffle();
            Console.WriteLine(collectionToSort);
            
            Console.WriteLine();
            Console.WriteLine("New collection:");
            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            Console.WriteLine("shuffle #1:");
            collection.Shuffle();
            Console.WriteLine(collection);
            Console.WriteLine("shuffle #2:");
            collection.Shuffle();
            Console.WriteLine(collection);
            Console.WriteLine("shuffle #3:");
            collection.Shuffle();
            Console.WriteLine(collection);

            Console.WriteLine("sort:");
            collection.Sort(new Quicksorter<int>());
            Console.WriteLine(collection);

            Console.WriteLine("shuffle #4:");
            collection.Shuffle();
            Console.WriteLine(collection);
        }
    }
}
