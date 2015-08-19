using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var dict = new Dictionary<string, int>();
        //TestingWithFile(dict);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine();
            var words = line.Split(new char[] {' ', '.', '\t', ',', ':'},
                StringSplitOptions.RemoveEmptyEntries);
            AddToDict(dict, words);
        }
        
        n = int.Parse(Console.ReadLine());
        var testWords = new string[n];
        for (int i = 0; i < n; i++)
        {
            testWords[i] = Console.ReadLine();
        }

        foreach (var testWord in testWords)
        {
            Console.WriteLine("{0} -> {1}", testWord, dict[testWord]);
        }
    }

    private static void TestingWithFile(Dictionary<string, int> dict)
    {
        using (var reader = new StreamReader("../../sample.txt"))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                string[] words = line.Split(new char[] {' ', '.', '\t', ',', ':', '<', '>'},
                    StringSplitOptions.RemoveEmptyEntries);
                AddToDict(dict, words);
                line = reader.ReadLine();
            }
        }
        Console.WriteLine("the -> {0}", dict["the"]);
        Console.WriteLine("is -> {0}", dict["is"]);
        Console.WriteLine("by -> {0}", dict["by"]);
        Console.WriteLine("murder -> {0}", dict["murder"]);
    }

    private static void AddToDict(Dictionary<string, int> dict, string[] words)
    {
        foreach (var word in words)
        {
            if (!dict.ContainsKey(word))
            {
                dict[word] = 0;
            }
            dict[word] ++;
        }
    }
}
