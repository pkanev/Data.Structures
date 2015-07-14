using System;
using System.Collections.Generic;
using System.Linq;

namespace Q02SortWords
{
    class SortWords
    {
        /// <summary>
        /// Returns a list of strings or an empty list if no data is entered
        /// </summary>
        static List<string> CreateStringList()
        {
            List<string> words = new List<string>();
            Console.Write("Please enter words separated by a space: ");
            string line = Console.ReadLine();
            if (line != null)
            {
                string[] input = line.Split(' ');
                int length = input.Length;
                if (length == 1 && input[0] == "")
                {
                    return words;
                }
                words.AddRange(input);
            }
            return words;
        }

        /// <summary>
        /// returns a string of sorted words separated by a space or a message that the list is empty
        /// </summary>
        static string SortedWordsToString(List<string> words)
        {
            string output = "";
            if (words.Count > 0)
            {
                words.Sort();
                output = words.Aggregate(output, (current, word) => current + (word + " "));
            }
            else
            {
                output = "The list is empty!";
            }
            return output;
        }
        static void Main(string[] args)
        {
            List<string> words = CreateStringList();
            Console.WriteLine(SortedWordsToString(words));
        }
    }
}
