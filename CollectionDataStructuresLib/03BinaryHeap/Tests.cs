using System;

namespace _03BinaryHeap
{
    class Tests
    {
        static void Main()
        {
            var heap = new PriorityQueue<int>();
            var r = new Random();
            for (int i = 0; i < 500; i++)
            {
                heap.Enqueue(r.Next(1, 101));
            }
            Console.WriteLine("Peek: {0}", heap.Peek());
            try
            {
                for (int i = 501; i > 0; i--)
                {
                    // one extra iteration so that an exception is thrown
                    Console.Write("|{0}|", heap.Dequeue());
                }
            }
            catch (NullReferenceException nr)
            {
                Console.WriteLine(nr.Message);
            }
            
        }
    }
}
