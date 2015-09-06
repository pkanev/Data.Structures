namespace Q02ImplementBiDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Test
    {
        private static void PrintCollection(ICollection<string> collection)
        {
            if (collection != null)
            {
                Console.WriteLine(string.Join(", ", collection));
            }
            else
            {
                Console.WriteLine("There are no records in such collection");
            }
            Console.WriteLine("------------");
            Console.WriteLine();
        }

        static void Main()
        {
            var collection = new BiDictionary<string, string, string>();
            collection.Add("game", "action", "GTA V");
            collection.Add("game", "rpg", "Pillars of Eternity");
            collection.Add("game", "fps", "Chivalry");
            collection.Add("movie", "action", "Terminator");
            collection.Add("game", "rpg", "Wasteland");
            collection.Add("game", "rpg", "Divinity: Original Sin");
            collection.Add("movie", "comedy", "The Big Lebowski");
            collection.Add("movie", "action", "Kill Those Damned American Bastards");
            collection.Add("movie", "comedy", "IT Crowd");
            collection.Add("movie", "fps", "Doom the movie");
            collection.Add("book", "comedy", "50 shades of Red");
            collection.Add("book", "comedy", "100 shades of Red");
            collection.Add("book", "comedy", "2500 shades of Gayness");

            var comedies = collection.FindElementsByKey2("comedy");
            Console.Write("Comedies: ");
            PrintCollection(comedies);

            var rpgs = collection.FindElementsByKey2("rpg");
            Console.Write("RPGs: ");
            PrintCollection(rpgs);
            
            var games = collection.FindElementsByKey1("game");
            Console.Write("Games: ");
            PrintCollection(games);
            
            var movies = collection.FindElementsByKey1("movie");
            Console.Write("Movies: ");
            PrintCollection(movies);

            var musicRecords = collection.FindElementsByKey1("music records");
            Console.Write("Music records: ");
            PrintCollection(musicRecords);

            var comedyBooks = collection.FindElementsByKey1AndKey2("book", "comedy");
            Console.WriteLine("Comedy Books: ");
            PrintCollection(comedyBooks);
        }
    }
}
