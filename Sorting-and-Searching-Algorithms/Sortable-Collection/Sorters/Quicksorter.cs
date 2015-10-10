﻿namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private void QuickSort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = array[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    Swap(array, i, storeIndex);
                    storeIndex ++;
                }
            }

            storeIndex --;

            Swap(array, start, storeIndex);
            QuickSort(array, start, storeIndex - 1);
            QuickSort(array, storeIndex + 1, end);
        }

        private static void Swap(List<T> array, int i, int storeIndex)
        {
            T old = array[i];
            array[i] = array[storeIndex];
            array[storeIndex] = old;
        }

        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }       
    }
}
