using System;
using System.Collections;
using System.Collections.Generic;

namespace Q04OrderedSet
{
    public class Node<T> : IEnumerable<T>, IComparable<Node<T>> where T:IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }
        
        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
        
        public int CompareTo(Node<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override bool Equals(object obj)
        {
            Node<T> other = (Node<T>) obj;
            return this.CompareTo(other) == 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var child in this.LeftChild)
                {
                    yield return child;
                }
            }

            if (this.Value != null)
            {
                yield return Value;    
            }

            if (this.RightChild != null)
            {
                foreach (var child in this.RightChild)
                {
                    yield return child;
                }
            }
        }

        public void ForEach(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                foreach (var child in this.LeftChild)
                {
                    this.LeftChild.ForEach(action);
                }
            }

            if (this.Value != null)
            {
                action(this.Value);
            }

            if (this.RightChild != null)
            {
                foreach (var child in this.RightChild)
                {
                    this.RightChild.ForEach(action);
                }
            }
        }
    }
}
