using System;

class Words
{
    private static int count = 0;
    static void PermuteRep(char[] arr, int start, int end)
    {
        CheckCondition(arr);
        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
                if (arr[left] != arr[right])
                {
                    Swap(ref arr[left], ref arr[right]);
                    PermuteRep(arr, left + 1, end);
                }
            var firstElement = arr[left];
            for (int i = left; i <= end - 1; i++)
                arr[i] = arr[i + 1];
            arr[end] = firstElement;
        }
    }

    private static void CheckCondition(char[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                return;
            }
        }
        count ++;
    }

    private static void Swap(ref char p1, ref char p2)
    {
        char temp = p1;
        p1 = p2;
        p2 = temp;
    }

    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Array.Sort(input);
        PermuteRep(input, 0, input.Length - 1);
        Console.WriteLine(count);
    }
}