using System;

namespace Q03ArrayStack
{
    class Example
    {
        static void Main()
        {
            var arrStack = new ArrayStack<int>();
            
            arrStack.Push(1);
            arrStack.Push(2);
            arrStack.Push(3);
            arrStack.Push(4);
            arrStack.Push(5);
            arrStack.Push(6);

            Console.WriteLine("Count = {0}", arrStack.Count);
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));
            Console.WriteLine("---------------------------");

            var last = arrStack.Pop();
            Console.WriteLine("Last = {0}", last);
            Console.WriteLine("Count = {0}", arrStack.Count);
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));
            Console.WriteLine("---------------------------");

            arrStack.Push(-7);
            arrStack.Push(-8);
            arrStack.Push(-9);
            Console.WriteLine("Count = {0}", arrStack.Count);
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));
            Console.WriteLine("---------------------------");

            last = arrStack.Pop();
            Console.WriteLine("Last = {0}", last);
            Console.WriteLine("Count = {0}", arrStack.Count);
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));
            Console.WriteLine("---------------------------");

            arrStack.Push(-10);
            Console.WriteLine("Count = {0}", arrStack.Count);
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));
            Console.WriteLine("---------------------------");

            last = arrStack.Pop();
            Console.WriteLine("Last = {0}", last);
            Console.WriteLine("Count = {0}", arrStack.Count);
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));
            Console.WriteLine("---------------------------");
        }
    }
}
