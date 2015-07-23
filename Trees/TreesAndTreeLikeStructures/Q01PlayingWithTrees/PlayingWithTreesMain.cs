using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01PlayingWithTrees
{
    class PlayingWithTreesMain
    {
        static Dictionary<int, Tree<int>> allNodes = new Dictionary<int, Tree<int>>();

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!allNodes.ContainsKey(value))
            {
                allNodes.Add(value, new Tree<int>(value));
            }
            return allNodes[value];
        }

        public static Tree<int> FindRootNode()
        {
            var rootNode = allNodes.Values.FirstOrDefault(n => n.Parent == null);
            return rootNode;
        }

        public static List<Tree<int>> FindLeaves()
        {
            var leaves = allNodes.Values.Where(n => n.Parent != null && n.Children.Count == 0)
                .OrderBy(n => n.Value).ToList();
            return leaves;
        }

        public static List<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = allNodes.Values
                .Where(n => n.Parent != null && n.Children.Count > 0)
                .OrderBy(n => n.Value)
                .ToList();
            return middleNodes;
        }

        private static int maxLength = 0;
        private static readonly List<Tree<int>> LongestPath = new List<Tree<int>>();

        private static void FindLongestPath(Tree<int> node, int initLength = 0)
        {
            int currentLength = initLength;
            if (node.Children.Count == 0)
            {
                currentLength++;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    LongestPath.Clear();
                    while (node.Parent != null)
                    {
                        LongestPath.Add(node);
                        node = node.Parent;
                    }
                    LongestPath.Add(node);
                    LongestPath.Reverse();
                }
                currentLength--;
                return;
            }

            Tree<int> child = null;
            currentLength ++;
            foreach (var c in node.Children)
            {
                FindLongestPath(c, currentLength);
            }
            currentLength--;
        }

        public static void PrintLongestPath()
        {
            Tree<int> root = FindRootNode();
            FindLongestPath(root);
            Console.WriteLine("Longest path:");
            Console.Write(string.Join(" -> ", LongestPath.Select(n=>n.Value)));
            Console.WriteLine(" (length = {0})", maxLength);
        }

        public static string calcPathSum(int targetSum)
        {
            string output = string.Format("Paths of sum {0}:", targetSum);
            bool hasAnswer = false;
            foreach (var leaf in FindLeaves())
            {
                int pathSum = 0;
                Stack<int> nums = new Stack<int>();
                var node = leaf;
                while (node.Parent != null)
                {
                    pathSum += node.Value;
                    nums.Push(node.Value);
                    node = node.Parent;
                }
                pathSum += node.Value;
                nums.Push(node.Value);
                if (pathSum == targetSum)
                {
                    output += "\n" + (string.Join(" -> ", nums.ToArray()));
                    hasAnswer = true;
                }
            }
            if (hasAnswer == false)
            {
                output += "\nThere are no paths with such value";
            }
            return output;
        }

        public static void calcSumOfSubtrees(Tree<int> startNode, int targetSum)
        {
            int currentSum = 0;
            currentSum += startNode.Value;
            //bool foundAnswer = false;
            List<int> nums = new List<int>();
            nums.Add(startNode.Value);
            if (startNode.Children.Count > 0)
            {
                foreach (var child in startNode.Children)
                {
                    currentSum += child.Value;
                    nums.Add(child.Value);
                }
            }
            if (currentSum == targetSum)
            {
                Console.WriteLine(string.Join(" + ", nums));
            }
            foreach (var child in startNode.Children)
            {
                calcSumOfSubtrees(child, targetSum);
            }
        }

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount - 1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }
            int pathSum = int.Parse(Console.ReadLine());
            int subTreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Root node: {0}", FindRootNode().Value);
            Console.WriteLine();
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", FindLeaves().Select(l => l.Value)));
            Console.WriteLine();
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", FindMiddleNodes().Select(n => n.Value)));
            Console.WriteLine();
            PrintLongestPath();
            Console.WriteLine();
            Console.WriteLine(calcPathSum(27));
            Console.WriteLine(calcPathSum(28));
            Console.WriteLine(calcPathSum(100));
            Console.WriteLine();
            Console.WriteLine("Subtrees of sum 43:");
            calcSumOfSubtrees(FindRootNode(), 43);
            Console.WriteLine("Subtrees of sum 1:");
            calcSumOfSubtrees(FindRootNode(), 1);
            Console.WriteLine("Subtrees of sum 63:");
            calcSumOfSubtrees(FindRootNode(), 63);
        }
    }
}
