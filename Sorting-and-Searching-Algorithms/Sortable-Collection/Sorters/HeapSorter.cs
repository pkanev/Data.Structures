namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap<T>(collection.ToArray());
            collection.Clear();
            while (heap.Count > 0)
            {
                collection.Add(heap.ExtractMin());
            }
        }

    }
}
