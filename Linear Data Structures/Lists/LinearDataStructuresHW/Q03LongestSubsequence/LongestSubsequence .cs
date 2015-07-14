using System;
using System.Collections.Generic;
using System.Linq;

namespace Q03LongestSubsequence
{
    class LongestSubsequence 
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
            if (line != null)
            {
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
            }

            return numbers;
        }

        /// <summary>
        /// Finds the longest subsequence in an integer List and returns it into a new list
        /// </summary>
        static List<int> FindLongestSubsequence(List<int> numbers)
        {
            int maxCount = 0;
            int currCount = 0;
            bool firstRound = true;
            int mostFreqNum = 0;
            int lastNum = 0;
            List<int> longestSequence = new List<int>();
            foreach (int number in numbers)
            {
                if (firstRound)
                {
                    //this will always happen on the first interation
                    mostFreqNum = number;
                    lastNum = number;
                    maxCount = 1;
                    currCount = 1;
                    firstRound = false;
                    continue;
                }
                if (number == lastNum)
                {
                    currCount ++;
                    if (currCount <= maxCount) continue;
                    maxCount = currCount;
                    mostFreqNum = number;
                }
                else
                {
                    currCount = 1;
                    lastNum = number;
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                longestSequence.Add(mostFreqNum);
            }
            return longestSequence;
        }
        static void Main(string[] args)
        {
            List<int> longestSequence;
            List<List<int>> testLists = new List<List<int>>()
            {
                new List<int>(){12,2,7,4,3,3,8},
                new List<int>(){2,2,2,3,3,3},
                new List<int>(){4,4,5,5,5},
                new List<int>(){1,2,3},
                new List<int>(){0},
            };
            foreach (var list in testLists)
            {
                Console.Write(string.Join(" ", list.Select(x => x.ToString()).ToArray()));
                Console.Write(" => ");
                longestSequence = FindLongestSubsequence(list);
                Console.WriteLine(string.Join(" ", longestSequence.Select(x => x.ToString()).ToArray()));
            }
            List<int> numbers = CreateList();
            longestSequence = FindLongestSubsequence(numbers);
            Console.WriteLine(string.Join(" ", longestSequence.Select(x => x.ToString()).ToArray()));
        }
    }
}
