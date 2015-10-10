namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;
    using Sorters;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        //public List<T> Items { get; } = new List<T>();
        public List<T> Items { get; private set; }

        //public int Count => this.Items.Count;
        public int Count
        {
            get { return this.Items.Count; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return BinarySearchProcedure(item, 0, this.Count - 1);
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }
            
            int midPoint = startIndex + (endIndex - startIndex)/2;

            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, midPoint - 1);
            }
            else if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, midPoint + 1, endIndex);
            }
            return midPoint;
        }

        public int InterpolationSearch<T>(SortableCollection<T> list, T item) where T : IComparable<T>, IInterpolatable<T>
        {
            var sorter = new Quicksorter<T>();
            list.Sort(sorter);
            var sortedArray = list.ToArray();
            return InterpolationSearchProcedure(sortedArray, item);
        }

        public int InterpolationSearch(int[] sortedArray, int key)
        {
            int low = 0;
            int high = sortedArray.Length - 1;
            if (high == -1)
            {
                return -1;
            }
            while (sortedArray[low] <= key && sortedArray[high] >= key)
            {
                int mid = low + ((key - sortedArray[low]) * (high - low))
                  / (sortedArray[high] - sortedArray[low]);
                if (sortedArray[mid] < key)
                    low = mid + 1;
                else if (sortedArray[mid] > key)
                    high = mid - 1;
                else
                    return mid;
            }
            if (sortedArray[low] == key) return low;
            else return -1;
        }

        public int InterpolationSearchProcedure<T>(T[] sortedArray, T key) where T : IComparable<T>, IInterpolatable<T>
        {
            int low = 0;
            int high = sortedArray.Length - 1;
            while (sortedArray[low].CompareTo(key) < 0 && sortedArray[high].CompareTo(key) > 0)
            {
                int mid = key.Interpolate(sortedArray, 0, sortedArray.Length - 1, key);
                
                if (sortedArray[mid].CompareTo(key) < 0)
                {
                    low = mid + 1;
                }
                else if (sortedArray[mid].CompareTo(key) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (sortedArray[low].Equals(key))
            {
                return low;
            }
            return -1;
        }
        
        public void Shuffle()
        {
            Random rnd = new Random();
            var n = this.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange array[i] with random element in array[i … n-1]
                int r = i + rnd.Next(0, n - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }

        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            //return $"[{string.Join(", ", this.Items)}]";
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }        
    }
}