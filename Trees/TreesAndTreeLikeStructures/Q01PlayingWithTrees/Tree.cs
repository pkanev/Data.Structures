﻿using System.Collections.Generic;

namespace Q01PlayingWithTrees
{
    public class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public IList<Tree<T>> Children { get; set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }
    }
}