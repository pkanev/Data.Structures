using System;
using System.Collections.Generic;

namespace Q02CalculateSequenceWithAQueue
{
    class CalcSequence
    {
        /// <summary>
        /// Prints the first 50 terms of a sequence N, N + 1, 2*N + 1, N + 2...
        /// </summary>
        /// <param name="n">Starting term of the sequence</param>
        static void PrintSequence(int n)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int counter = 0;
            int currentNumber, numA, numB, numC;
            while (counter < 50)
            {
                currentNumber = queue.Dequeue();
                numA = currentNumber + 1;
                numB = 2*currentNumber + 1;
                numC = currentNumber + 2;
                queue.Enqueue(numA);
                queue.Enqueue(numB);
                queue.Enqueue(numC);
                Console.Write("{0} ", currentNumber);
                counter++;
            }
            Console.WriteLine();
        }
        static void Main()
        {
            PrintSequence(2);
            PrintSequence(-1);
            PrintSequence(1000);
        }
    }
}
