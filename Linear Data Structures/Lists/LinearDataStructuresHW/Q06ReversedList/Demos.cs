using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06ReversedList
{
    class Demos
    {
        private static void Main(string[] args)
        {
            ReversedList<int> myList = new ReversedList<int>();
            Console.WriteLine("Capacity: {0}; Count: {1}", myList.Capacity, myList.Count);
            for (int i = 0; i < 4; i++)
            {
                myList.Add(i);
                Console.WriteLine(myList.ToString());
            }
            Console.WriteLine("Capacity: {0}; Count: {1}", myList.Capacity, myList.Count);
            myList.Add(4);
            Console.WriteLine(myList.ToString());
            Console.WriteLine("Capacity: {0}; Count: {1}", myList.Capacity, myList.Count);
            myList[1] = 666;
            Console.WriteLine(myList.ToString());
            Console.WriteLine("Capacity: {0}; Count: {1}", myList.Capacity, myList.Count);
            int remNum = myList.RemoveAt(1);
            Console.WriteLine("Removed value: {0}", remNum);
            Console.WriteLine(myList.ToString());
            Console.WriteLine("Capacity: {0}; Count: {1}", myList.Capacity, myList.Count);
        }
    }
}
