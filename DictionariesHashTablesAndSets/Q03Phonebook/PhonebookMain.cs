using System;
using Q01Dictionary;

namespace Q03Phonebook
{
    class PhonebookMain
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var phonebook = new HashTable<string, string>();

            while (input != "search")
            {
                string[] record = input.Split( new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                phonebook.AddOrReplace(record[0], record[1]);
                input = Console.ReadLine();
            }
            
            input = Console.ReadLine();
            
            while (input != "")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine("{0} -> {1}", input, phonebook[input]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
