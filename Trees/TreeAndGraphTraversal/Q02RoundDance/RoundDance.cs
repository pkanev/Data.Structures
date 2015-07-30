using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Q02RoundDance
{
    class RoundDance
    {
        private static Dictionary<int, List<int>> dancers;
        private static int numOfFriendships;
        private static int start;
        private static List<int> visited;
        private static int length = 0;
        private static int maxLength = 0;

        private static void ReadData()
        {
            dancers = new Dictionary<int, List<int>>();
            visited = new List<int>();
            numOfFriendships = int.Parse(Console.ReadLine());
            start = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfFriendships; i++)
            {
                string[] splitLine = Console.ReadLine().Split(' ');
                int n1 = int.Parse(splitLine[0]);
                int n2 = int.Parse(splitLine[1]);
                if (!dancers.ContainsKey(n1))
                {
                    dancers[n1] = new List<int>();
                }
                if (!dancers.ContainsKey(n2))
                {
                    dancers[n2] = new List<int>();
                }
                dancers[n1].Add(n2);
                dancers[n2].Add(n1);
            }
        }

        private static void FindLongestdance(int dancer)
        {
            if (!visited.Contains(dancer))
            {
                visited.Add(dancer);
                length++;
                if (length > maxLength)
                {
                    maxLength = length;
                }
                foreach (var friend in dancers[dancer])
                {
                    FindLongestdance(friend);
                }
                length --;
            }

        }

        static void Main()
        {
            ReadData();
            FindLongestdance(start);
            Console.WriteLine(maxLength);
        }
    }
}
