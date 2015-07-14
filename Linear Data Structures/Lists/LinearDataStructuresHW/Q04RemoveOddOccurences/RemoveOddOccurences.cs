using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04RemoveOddOccurences
{
    class RemoveOddOccurences
    {
        /// <summary>
        /// Returns a list of integers or an empty list if not data is entered
        /// </summary>
        static List<int> CreateList()
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Test your own sequence of numbers!");
            Console.Write("Please enter integers separated by a space: ");
            string line = Console.ReadLine();
            if (line == null) return numbers;
            string[] input = line.Trim().Split(' ');
            int length = input.Length;
            if (length == 1 && input[0] == "")
            {
                return numbers;
            }
            for (int index = 0; index < length; index++)
            {
                numbers.Add(int.Parse(input[index]));
            }
            return numbers;
        }

        /// <summary>
        /// Removes all the odd occurences from the list and returns a transformed list
        /// </summary>
        static List<int> RemoveOddOcc(List<int> numbers)
        {
            Dictionary<int,int> frequencies = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (!frequencies.ContainsKey(num))
                {
                    frequencies.Add(num, 1);
                }
                else
                {
                    frequencies[num] ++;
                }
            }
            List<int> identityList = (from entry in frequencies where entry.Value%2 == 0 select entry.Key).ToList();
            return numbers.Where(num => identityList.Contains(num)).ToList();
        }

        static void Main(string[] args)
        {
            List<int> transformedSequence;
            List<List<int>> testLists = new List<List<int>>()
            {
                new List<int>(){1,2,3,4,1},
                new List<int>(){1,2,3,4,5,3,6,7,6,7,6},
                new List<int>(){1,2,1,2,1,2},
                new List<int>(){3,7,3,3,4,3,4,3,7},
                new List<int>(){1,1},
            };
            foreach (var list in testLists)
            {
                Console.Write(string.Join(" ", list.Select(x => x.ToString()).ToArray()));
                Console.Write(" => ");
                transformedSequence = RemoveOddOcc(list);
                Console.WriteLine(string.Join(" ", transformedSequence.Select(x => x.ToString()).ToArray()));
            }
            List<int> numbers = CreateList();
            transformedSequence = RemoveOddOcc(numbers);
            Console.WriteLine(string.Join(" ", transformedSequence.Select(x => x.ToString()).ToArray()));
        }
    }
}
