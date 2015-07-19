using System;

namespace Q05LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element, firstNode);
            firstNode = newNode;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
            Node<T> result = this.firstNode;
            firstNode = firstNode.NextNode;
            this.Count --;
            return result.Value;
        }

        public T[] ToArray()
        {
            T[] resultArr = new T[this.Count];
            int index = 0;
            Node<T> currentNode = firstNode;
            while (currentNode != null)
            {
                resultArr[index] = currentNode.Value;
                index++;
                currentNode = currentNode.NextNode;
            }
            return resultArr;
        }

        private class Node<T>
        {
            public T Value;
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }

    }
}
