using System;
using System.Collections.Generic;

namespace Q09SequenceNtoM
{
    class SequenceNtoM
    {
        static public void FindSequence(int start, int end)
        {
            Queue<Node> numbers = new Queue<Node>();

            numbers.Enqueue(new Node(start));
            while (numbers.Count > 0)
            {
                Node currentNode = numbers.Dequeue();
                int currentValue = currentNode.Number;
                if (currentValue < end)
                {
                    numbers.Enqueue(new Node(currentValue + 1, currentNode));
                    numbers.Enqueue(new Node(currentValue + 2, currentNode));
                    numbers.Enqueue(new Node(currentValue * 2, currentNode));
                }
                if (currentValue == end)
                {
                    PrintSolution(currentNode);
                    return;
                }
            }
            Console.WriteLine("(no solution)");
        }

        static public void PrintSolution(Node node)
        {
            Stack<int> numbers = new Stack<int>();
            while (node.PrevNode != null)
            {
                numbers.Push(node.Number);
                node = node.PrevNode;
            }
            numbers.Push(node.Number);
            Console.WriteLine(string.Join(" -> ", numbers.ToArray()));
        }
        static void Main()
        {
            FindSequence(3, 10);
            FindSequence(5, -5);
            FindSequence(10, 30);
        }
    }
}
