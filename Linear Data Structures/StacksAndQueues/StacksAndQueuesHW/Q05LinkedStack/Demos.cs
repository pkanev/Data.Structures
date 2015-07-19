using System;

namespace Q05LinkedStack
{
    class Demos
    {
        static void Main()
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            var last = stack.Pop();
            Console.WriteLine("Last = {0}", last);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            stack.Push(-7);
            stack.Push(-8);
            stack.Push(-9);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            last = stack.Pop();
            Console.WriteLine("Last = {0}", last);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            stack.Push(-10);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            last = stack.Pop();
            Console.WriteLine("Last = {0}", last);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");
        }
    }
}
