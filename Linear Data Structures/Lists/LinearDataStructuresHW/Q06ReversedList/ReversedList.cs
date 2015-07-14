// This solution is based on the material presented in Chapter 16. Linear Data Structures from 
// the Fundamentals of Programming with C#
// http://www.introprogramming.info/english-intro-csharp-book/read-online/chapter-16-linear-data-structures/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Q06ReversedList
{
    class ReversedList<T> : IEnumerable<T>
    {
        private T[] arr;
        private int count;
        private int capacity;

        /// <summary>Returns the actual list length</summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        /// <summary>Returns the capacity of the present storage array</summary>
        public int Capacity
        {
            get { return this.capacity; }
        }

        private const int INITIAL_CAPACITY = 4;

        /// <summary>
        /// Initializes the array-based list – allocate memory
        /// </summary>
        public ReversedList(int capacity = INITIAL_CAPACITY)
        {
            this.arr = new T[capacity];
            this.count = 0;
            this.capacity = capacity;
        }
        
        /// <summary>Adds element to the list</summary>
        public void Add(T item)
        {
            GrowIfArrIsFull();
            this.arr[this.count] = item;
            this.count++;
        }
        private void GrowIfArrIsFull()
        {
            if (this.count == this.capacity)
            {
                this.capacity *= 2;
                T[] extendedArr = new T[this.capacity];
                Array.Copy(arr, extendedArr, this.count);
                this.arr = extendedArr;
            }
        }

        /// <summary>Indexer: access to element at given index in reversed order</summary>
        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid index: " + index);
                }
                return this.arr[getReversedIndex(index)];
            }
            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid index: " + index);
                }
                this.arr[getReversedIndex(index)] = value;
            }
        }

        /// <summary>Removes the element at the specified index</summary>
        public T RemoveAt(int index) //RemoveAt() is more meaningful than Remoe() for this type of operation
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid index: " + index);
            }
            index = getReversedIndex(index);
            T item = this.arr[index];
            Array.Copy(this.arr, index + 1,
                this.arr, index, this.count - index - 1);
            this.arr[this.count - 1] = default(T);
            this.count--;

            return item;
        }

        /// <summary>
        /// Adjusts the index according to the reversed order
        /// </summary>
        private int getReversedIndex (int index)
        {
            int revIndex = this.count - 1 - index;
            return revIndex;
        }

        /// <summary>
        /// returns a JSON like presentation of the list
        /// </summary>
        public override string ToString()
        {
            string output = "{ ";
            for (int i = this.Count-1, g=0; i >= 0; i--, g++)
            {
                output += string.Format("[{0}] => {1}; ", g, this.arr[i]);
            }
            output += "}";
            return output;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
