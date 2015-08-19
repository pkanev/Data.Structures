using System;

namespace _03BinaryHeap
{
    public class PriorityQueue<T> where T: IComparable<T>
    {
        private const int InitialSize = 16;
        private T[] data;
        private int capacity;
        public int Count { get; private set; }

        public PriorityQueue(int size = InitialSize)
        {
            this.data = new T[size];
            this.Count = 0;
            this.capacity = size;
        }

        public void Enqueue(T element)
        {
            if (this.Count == this.capacity)
            {
                IncreaseCapacity();
            }
            data[Count] = element;
            CompareToParent(Count);
            Count++;

        }

        public T Peek()
        {
            return data[0];
        }
        private void IncreaseCapacity()
        {
            this.capacity *= 2;
            T[] newData = new T[this.capacity];
            for (int i = 0; i < Count; i++)
            {
                newData[i] = data[i];
            }
            this.data = newData;
        }

        private int? GetParentIndex(int index)
        {
            int parentIndex = (index - 1) / 2;
            if (parentIndex != index)
            {
                return parentIndex;
            }
            return null;
        }

        private void CompareToParent(int pointer)
        {
            int? parentIndex = GetParentIndex(pointer);
            if (parentIndex != null)
            {
                int parent = (int)parentIndex;
                if (data[parent].CompareTo(data[pointer]) < 0)
                {
                    //The child is greater than the father
                    T tempValue = data[parent];
                    data[parent] = data[pointer];
                    data[pointer] = tempValue;

                    CompareToParent(parent);
                }
            }
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException("The PriorityQueue is empty.");
            }

            T result = data[0];
            data[0] = data[Count - 1];
            this.Count --;

            CheckOrder(0);

            return result;
        }

        private void CheckOrder(int index)
        {
            int? leftChildIndex = GetLeftChild(index);
            int? rightChildIndex = GetRightChild(index);

            if (leftChildIndex != null && rightChildIndex != null)
            {
                // two children
                int leftIndex = (int)leftChildIndex;
                int rightIndex = (int) rightChildIndex;
                int greater = data[leftIndex].CompareTo(data[rightIndex]) < 0 ? rightIndex : leftIndex;
                if (data[index].CompareTo(data[greater]) < 0)
                {
                    T tempValue = data[greater];
                    data[greater] = data[index];
                    data[index] = tempValue;

                    CheckOrder(greater);
                }
            }
            else if (leftChildIndex != null)
            {
                //only one child, right is always null
                int leftIndex = (int)leftChildIndex;
                if (data[index].CompareTo(data[leftIndex]) < 0)
                {
                    T tempValue = data[leftIndex];
                    data[leftIndex] = data[index];
                    data[index] = tempValue;

                    CheckOrder(leftIndex);
                }
            }
        }

        private int? GetLeftChild(int index)
        {
            int leftChildIndex = 2*index + 1;
            if (leftChildIndex < this.Count)
            {
                return leftChildIndex;
            }
            return null;
        }

        private int? GetRightChild(int index)
        {
            int rightChildIndex = 2 * index + 2;
            if (rightChildIndex < this.Count)
            {
                return rightChildIndex;
            }
            return null;
        }

    }
}