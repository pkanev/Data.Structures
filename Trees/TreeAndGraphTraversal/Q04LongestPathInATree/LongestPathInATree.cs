using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Q04LongestPathInATree
{
    internal class LongestPathInATree
    {
        private static int numOfNodes;
        private static int numOfEdges;
        private static int maxSum = int.MinValue;
        private static Dictionary<int, Node> nodes;
        private static List<Node> leaves;
        private static Node root;


        private class Node
        {
            public int Value { get; set; }
            public Node Parent { get; set; }
            public IList<Node> Children { get; private set; }

            public Node(int value, params Node[] children)
            {
                this.Value = value;
                this.Children = new List<Node>();
                foreach (var child in children)
                {
                    this.Children.Add(child);
                }
                this.Parent = null;
            }
        }

        private static void ReadData()
        {
            nodes = new Dictionary<int, Node>();
            numOfNodes = int.Parse(Console.ReadLine());
            numOfEdges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfEdges; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int n1 = int.Parse(nums[0]);
                int n2 = int.Parse(nums[1]);
                if (!nodes.ContainsKey(n1))
                {
                    nodes[n1] = new Node(n1);
                }
                if (!nodes.ContainsKey(n2))
                {
                    nodes[n2] = new Node(n2);
                }
                nodes[n1].Children.Add(nodes[n2]);
                nodes[n2].Parent = nodes[n1];
            }
        }

        private static void GetLeaves()
        {
            leaves = new List<Node>();
            foreach (var node in nodes.Values)
            {
                if (node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }
        }

        private static List<int> GetBranch(Node node)
        {
            List<int> branch = new List<int>();
            while (node.Parent != null)
            {
                branch.Add(node.Value);
                node = node.Parent;
            }
            branch.Add(node.Value);
            return branch;
        }

        private static int FindMaxSumOfBranchUnion(List<List<int>> branches)
        {
            for (int i = 0; i < branches.Count - 1; i++)
            {
                for (int j = i + 1; j < branches.Count; j++)
                {
                    List<int> unionList = new List<int>();
                    foreach (var vertex in branches[i])
                    {
                        unionList.Add(vertex);
                    }
                    foreach (var vertex in branches[j])
                    {
                        if (!unionList.Contains(vertex))
                        {
                            unionList.Add(vertex);
                        }
                    }
                    int sum = unionList.Sum();
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }

        private static List<List<int>> GetAllBranches()
        {
            List<List<int>> allBranches = new List<List<int>>();
            foreach (var leaf in leaves)
            {
                List<int> branch = GetBranch(leaf);
                allBranches.Add(branch);
            }
            return allBranches;
        }
        static void Main()
        {
            ReadData();
            GetLeaves();
            int sum = FindMaxSumOfBranchUnion(GetAllBranches());
            Console.WriteLine(sum);
        }

    }
}
