using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07ImplementALinkedList
{
    class Demos
    {
        static void Main(string[] args)
        {
            LinkedList<int> myList = new LinkedList<int>(){1, 2, 3, 4, 5, 2, 2, 6};
            myList.Add(6);
            int n = myList.RemoveAt(6);
            Console.WriteLine(n); // n = 2
            Console.WriteLine(myList.FirstIndexOf(2)); // should be 1
            Console.WriteLine(myList.FirstIndexOf(7)); // should be -1
            Console.WriteLine(myList.LastIndexOf(6)); // should be 7
            Console.WriteLine(myList.LastIndexOf(7)); // should be -1
        }
    }
}
