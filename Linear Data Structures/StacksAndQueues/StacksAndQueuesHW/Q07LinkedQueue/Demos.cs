﻿using System;

namespace Q07LinkedQueue
{
    class Demos
    {
        static void Main()
        {
            var queue = new LinkedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            var head = queue.Dequeue();
            Console.WriteLine("Head = {0}", head);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            queue.Enqueue(-7);
            queue.Enqueue(-8);
            queue.Enqueue(-9);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            head = queue.Dequeue();
            Console.WriteLine("Head = {0}", head);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            queue.Enqueue(-10);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            head = queue.Dequeue();
            Console.WriteLine("Head = {0}", head);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");
        }
    }
}
