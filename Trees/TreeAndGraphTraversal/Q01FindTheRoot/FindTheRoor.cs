using System;
using System.Collections.Generic;
using System.Data;

namespace Q01FindTheRoot
{
    class FindTheRoor
    {
        private static int numNodes;
        private static Node[] nodes;
        private class Node
        {
            public int Value { get; set; }
            public Node Parent { get; set; }
            public IList<Node> Children { get; private set; }

            public Node(int value)
            {
                this.Value = value;
                this.Parent = null;
                this.Children = new List<Node>();
            }

        }

        private static void BuildTree()
        {
            numNodes = int.Parse(Console.ReadLine());
            nodes = new Node[numNodes+1];
            for (int i = 0; i < numNodes; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int parent = int.Parse(nums[0]);
                int child = int.Parse(nums[1]);
                if (nodes[parent] == null)
                {
                    nodes[parent] = new Node(parent);
                }
                if (nodes[child] == null)
                {
                    nodes[child] = new Node(child);
                }
                nodes[parent].Children.Add(nodes[child]);
                nodes[child].Parent = nodes[parent];
            }
        }

        private static List<int> FindRoots()
        {
            List<int> roots = new List<int>();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == null)
                {
                    nodes[i] = new Node(i);
                }
                if (nodes[i].Parent == null)
                {
                    roots.Add(nodes[i].Value);
                }

            }
            return roots;
        }

        private static void PrintRoots()
        {
            List<int> roots = FindRoots();
            if (roots.Count == 0)
            {
                Console.WriteLine("No root");
            }
            else if (roots.Count == 1)
            {
                Console.WriteLine(roots[0]);
            }
            else
            {
                Console.WriteLine("Forest is not a tree!");
            }
        }
        static void Main()
        {
            BuildTree();
            PrintRoots();
        }
    }
}
