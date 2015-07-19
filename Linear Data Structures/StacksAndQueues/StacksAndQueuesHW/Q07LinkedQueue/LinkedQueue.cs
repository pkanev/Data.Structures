using System;

namespace Q07LinkedQueue
{
    public class LinkedQueue<T>
    {
        public int Count { get; private set; }
        private QueueNode<T> head;
        private QueueNode<T> tail;


        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new QueueNode<T>(element);
            }
            else
            {
                QueueNode<T> newHead = new QueueNode<T>(element, nextNode: this.tail);
                this.tail.PrevNode = newHead;
                this.tail = newHead;
            }
            this.Count ++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            QueueNode<T> resultNode = this.head;
            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.PrevNode;
                this.head.NextNode = null;
            }
            this.Count --;
            return resultNode.Value;
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            int index = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                currentNode = currentNode.PrevNode;
                index++;
            }
            return arr;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode (T value, QueueNode<T> prevNode = null, QueueNode<T> nextNode = null )
            {
                this.Value = value;
                this.NextNode = nextNode;
                this.PrevNode = prevNode;
            }

        }

    }
}