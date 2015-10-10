using System;
using System.Collections.Generic;

class Needles
{
    private static int count;

    public static int ScanNumbers(List<int> array, int index, int needle)
    {
        int count = array.Count;
        int tempIndex = index;
        
        while (tempIndex < count)
        {
            if (array[tempIndex] == 0)
            {
                tempIndex++;
                continue;
            }

            if (array[tempIndex] >= needle && array[index] != 0 && index != 0)
            {
                if (array[tempIndex] == needle && array[tempIndex - 1] != 0)
                {
                    if (needle > array[index])
                    {
                        return index + 1;
                    }
                    return index;
                }
                return index + 1;
            }
            if (array[tempIndex] >= needle && array[index] != 0 && index == 0 && array[tempIndex] > array[index])
            {
                return index + 1;
            }
            if (array[tempIndex] >= needle && array[index] != 0 && index == 0)
            {
                return index;
            }

            if (array[tempIndex] >= needle && array[index] == 0)
            {
                return index;
            }
            index = tempIndex;
            tempIndex++;
        }

        if (array[tempIndex - 1] == 0)
        {
            if (array[index] != 0 && array[index] < needle)
            {
                return index + 1;
            }
            return index;
        }
        return tempIndex;
    }

    static void Main()
    {
        Console.ReadLine();

        string[] numbersAsStrings = Console.ReadLine().Split(' ');
        string[] needlesAsString = Console.ReadLine().Split(' ');

        List<int> numbers = new List<int>();
        foreach (var number in numbersAsStrings)
        {
            numbers.Add(int.Parse(number));
        }
        count = numbersAsStrings.Length;
        
        int numNeedles = needlesAsString.Length;
        
        SortedDictionary<int, int> needles = new SortedDictionary<int, int>();
        for (int i = 0; i < numNeedles; i++)
        {
            int num = int.Parse(needlesAsString[i]);
            if (!needles.ContainsKey(num))
            {
                needles[num] = i;
            }
        }

        int start = 0;
        int[] output = new int[numNeedles];
        foreach (var needle in needles)
        {
            start = ScanNumbers(numbers, start, needle.Key);
            output[needle.Value] = start;
        }

        Console.WriteLine(string.Join(" ", output));
    }
}
