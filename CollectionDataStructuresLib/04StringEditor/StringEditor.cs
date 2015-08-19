using System;
using Wintellect.PowerCollections;

class StringEditor
{
    static void Main()
    {
        BigList<char> rope = new BigList<char>();

        //TestRopeEditing(rope, 200);
        //TestRopeEditing(rope, 20000); //You may want to disable (comment) line 74 as t takes forever to print the OK
        
        ReadFromConsole(rope);

        foreach (var ch in rope)
        {
            Console.Write(ch);
        }
        Console.WriteLine();
    }

    private static void TestRopeEditing(BigList<char> rope, int numOfTests)
    {
        for (int i = 0; i < numOfTests; i++)
        {
            Edit("APPEND XXX XXX", rope);
            Edit("INSERT @#$!@#@!#!@#!@#!@#!#!@#!@$@!$@#$#@$#@$ 5", rope);
            Edit("DELETE 35 15", rope);
            Edit("REPLACE 50 1 a", rope);
        }
    }

    private static void ReadFromConsole(BigList<char> rope)
    {
        string line = Console.ReadLine();
        while (line != "PRINT")
        {
            Edit(line, rope);
            line = Console.ReadLine();
        }
    }

    private static void Edit(string line, BigList<char> rope)
    {
        string[] tokens = line.Split(' ');
        string text;
        int index;
        int count;
        bool success = false;
        switch (tokens[0])
        {
            case "INSERT":
                string position = tokens[tokens.Length - 1];
                text = line.Substring(7, line.Length - 8 - position.Length);
                success = InsertInRope(rope, text, int.Parse(position));
                break;
            case "APPEND":
                text = line.Substring(7, line.Length - 7);
                success = AppendToRope(rope, text);
                break;
            case "DELETE":
                index = int.Parse(tokens[1]);
                count = int.Parse(tokens[2]);
                success = DeleteFromRopeAt(rope, index, count);
                break;
            case "REPLACE":
                index = int.Parse(tokens[1]);
                count = int.Parse(tokens[2]);
                text = line.Substring(10 + index.ToString().Length + count.ToString().Length,
                    line.Length - 10 - index.ToString().Length - count.ToString().Length);
                success = ReplaceInRopeAt(rope, text, index, count);
                break;
        }

        Console.WriteLine(success ? "OK" : "ERROR");
    }

    private static bool InsertInRope(BigList<char> rope, string input, int index)
    {
        if (rope.Count >= index)
        {
            var chars = input.ToCharArray();
            rope.InsertRange(index, chars);
            return true;
        }
        return false;
    }

    private static bool AppendToRope(BigList<char> rope, string input)
    {
        var chars = input.ToCharArray();
        rope.AddRange(chars);
        return true;
    }

    private static bool DeleteFromRopeAt(BigList<char> rope, int index, int count)
    {
        if (rope.Count >= index + count)
        {
            rope.RemoveRange(index, count);
            return true;
        }
        return false;
    }

    private static bool ReplaceInRopeAt(BigList<char> rope, string input, int index, int count)
    {
        bool success = DeleteFromRopeAt(rope, index, count);
        if (success)
        {
            success = InsertInRope(rope, input, index);
        }
        return success;
    }
}