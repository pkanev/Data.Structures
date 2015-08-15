using Q01Dictionary;

namespace Q04OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> :IEnumerable<T> where T : IComparable<T>, IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
        private HashTable<T, bool> containedValues { get; set; }
        
        public OrderedSet()
        {
            this.Root = null;
            this.Count = 0;
            this.containedValues = new HashTable<T, bool>();
        }

        public void Add(T element)
        {
            if (containedValues.ContainsKey(element))
            {
                return;
            }
            containedValues.Add(element, true);
            this.Count ++;
            if (this.Root == null)
            {
                this.Root = new Node<T>(element);
                return;
            }
            var currentNode = this.Root;
            bool added = false;
            while (added != true)
            {
                int compare = element.CompareTo(currentNode.Value);
                if (compare < 0)
                {
                    //go left
                    if (currentNode.LeftChild == null)
                    {
                        //add the element
                        Node<T> newNode = new Node<T>(element);
                        newNode.Parent = currentNode;
                        currentNode.LeftChild = newNode;
                        added = true;
                    }
                    else
                    {
                        currentNode = currentNode.LeftChild;
                    }
                }
                if (compare > 0)
                {
                    //go right
                    if (currentNode.RightChild == null)
                    {
                        //add the element
                        Node<T> newNode = new Node<T>(element);
                        newNode.Parent = currentNode;
                        currentNode.RightChild = newNode;
                        added = true;
                    }
                    else
                    {
                        currentNode = currentNode.RightChild;
                    }
                }
            }



            //this.Root = Insert(element, null, Root);

        }

        public bool Contains(T element)
        {
            return containedValues.ContainsKey(element);
        }

        private Node<T> Find(T value)
        {
            Node<T> currNode = this.Root;

            while (currNode != null)
            {
                int compareTo = value.CompareTo(currNode.Value);
                if (compareTo < 0)
                {
                    currNode = currNode.LeftChild;
                }
                else if (compareTo > 0)
                {
                    currNode = currNode.RightChild;
                }
                else
                {
                    break;
                }
            }
            return currNode;
        }

        public void Remove(T value)
        {
            if (!this.containedValues.ContainsKey(value))
            {
                return;
            }
            Node<T> nodeToDelete = Find(value);
            //node is a leaf
            if (nodeToDelete.LeftChild == null && nodeToDelete.RightChild == null)
            {
                if (nodeToDelete.Parent != null)
                {
                    if (IsLeftChild(nodeToDelete))
                    {
                        nodeToDelete.Parent.LeftChild = null;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = null;
                    }
                }
                else
                {
                    this.Root = null;
                }
            }
            //node has a single left child
            else if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild == null)
            {
                if (nodeToDelete.Parent != null)
                {
                    if (IsLeftChild(nodeToDelete))
                    {
                        nodeToDelete.Parent.LeftChild = nodeToDelete.LeftChild;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = nodeToDelete.LeftChild;
                    }
                }
                else
                {
                    nodeToDelete.LeftChild.Parent = null;
                    Root = nodeToDelete.LeftChild;
                }
            }
            //node has a single right child
            else if (nodeToDelete.LeftChild == null && nodeToDelete.RightChild != null)
            {
                if (nodeToDelete.Parent != null)
                {
                    if (IsLeftChild(nodeToDelete))
                    {
                        nodeToDelete.Parent.LeftChild = nodeToDelete.RightChild;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = nodeToDelete.RightChild;
                    }
                }
                else
                {
                    nodeToDelete.RightChild.Parent = null;
                    Root = nodeToDelete.RightChild;
                }
            }
            //node has two children
            else
            {
                var nextNode = nodeToDelete.RightChild;
                while (nextNode.LeftChild != null)
                {
                    nextNode = nextNode.LeftChild;
                }
                if (nodeToDelete.Parent != null)
                {
                    if (IsLeftChild(nextNode))
                    {
                        nextNode.Parent.LeftChild = null;
                    }
                    else
                    {
                        nextNode.Parent.RightChild = null;
                    }
                    
                    if (IsLeftChild(nodeToDelete))
                    {
                        nodeToDelete.Parent.LeftChild = nextNode;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = nextNode;
                    }
                 
                    nextNode.LeftChild = nodeToDelete.LeftChild;
                    if (nextNode.LeftChild != null)
                    {
                        nextNode.LeftChild.Parent = nextNode;
                    }
                    nextNode.RightChild = nodeToDelete.RightChild;
                    if (nextNode.RightChild != null)
                    {
                        nextNode.RightChild.Parent = nextNode;    
                    }
                    nextNode.Parent = nodeToDelete.Parent;
                }
                else
                {
                    //the parent is the root
                    if (IsLeftChild(nextNode))
                    {
                        nextNode.Parent.LeftChild = null;
                    }
                    else
                    {
                        nextNode.Parent.RightChild = null;
                    }
                    if (nodeToDelete.LeftChild != null)
                    {
                        nodeToDelete.LeftChild.Parent = nextNode;
                        nextNode.LeftChild = nodeToDelete.LeftChild;
                    }
                    if (nodeToDelete.RightChild != null)
                    {
                        nodeToDelete.RightChild.Parent = nextNode;
                        nextNode.RightChild = nodeToDelete.RightChild;
                    }
                    nextNode.Parent = null;
                    Root = nextNode;
                }
                
            }
            
            this.containedValues.Remove(value);
            this.Count--;
        }

        private bool IsLeftChild(Node<T> node)
        {
            if (node.Parent.LeftChild != null &&
                node.Parent.LeftChild.Equals(node))
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}