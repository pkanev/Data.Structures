using System;

namespace Q03ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] elements;

        public int Count { get; private set; }

        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                Grow();
            }
            this.elements[this.Count] = element;
            this.Count ++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
            T result = this.elements[this.Count - 1];
            this.Count --;
            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            int resultIndex = 0;
            for (int index = this.Count - 1; index >= 0; index--)
            {
                result[resultIndex] = this.elements[index];
                resultIndex++;
            }
            return result;
        }

        private void Grow()
        {
            T[] newElements = new T[2 * this.Count];
            CopyAllElementsTo(newElements);
            this.elements = newElements;
        }

        private void CopyAllElementsTo(T[] resultArr)
        {
            for (int index = 0; index < this.Count; index++)
            {
                resultArr[index] = this.elements[index];
            }
        }

    }
}
