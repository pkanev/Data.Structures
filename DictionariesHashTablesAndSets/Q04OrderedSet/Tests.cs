using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04OrderedSet
{
    class Tests
    {
        static void Main(string[] args)
        {
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);

            Console.WriteLine("Set contains 12: {0}", set.Contains(12));
            Console.WriteLine("Set contains 123: {0}", set.Contains(123));
            Console.WriteLine("Number of elements: {0}",set.Count);
            Console.WriteLine("=========");
            foreach (var element in set)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("Remove 17:");
            set.Remove(17);
            Console.WriteLine(string.Join(" -> ", set.ToList()));
            Console.WriteLine("=========");
            Console.WriteLine("Set contains 17: {0}", set.Contains(17));
            Console.WriteLine("Number of elements: {0}", set.Count);
            Console.WriteLine("=========");
        }
    }
}
