namespace Q03CollectionOfProducts
{
    using System;

    class Test
    {
        static void Main()
        {
            var collection = new CollectionOfProducts();
            Console.WriteLine("Adding products to the collection");
            Console.WriteLine(collection.Add(1, "Calculator", "Casio", 25M));
            Console.WriteLine(collection.Add(2, "Calculator", "TI", 50M));
            Console.WriteLine(collection.Add(3, "Calculator", "IBM", 60M));
            Console.WriteLine(collection.Add(4, "MP3 Player", "Sony", 45M));
            Console.WriteLine(collection.Add(5, "MP3 Player", "Sony", 12M));
            Console.WriteLine(collection.Add(6, "MP3 Player", "Sony", 18M));
            Console.WriteLine(collection.Add(7, "MP3 Player", "Sony", 20M));
            Console.WriteLine(collection.Add(8, "MP3 Player", "Casio", 20M));
            Console.WriteLine(collection.Add(9, "Calculator", "Casio", 20M));
            Console.WriteLine();

            Console.WriteLine("Adding an existing id (id=1)");
            Console.WriteLine(collection.Add(1, "Calculator", "XYZ", 25M));
            Console.WriteLine();

            Console.WriteLine("Finding by ID = 2:");
            Console.WriteLine(collection.FindProductById(2));
            Console.WriteLine();

            Console.WriteLine("Finding by title (calculator):");
            foreach (var product in collection.FindProductsByTitle("Calculator"))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Searching by price range (20-50 incl): ");
            var productsInPriceRange = collection.FindProductsByPriceRange(20M, 50M);
            foreach (var product in productsInPriceRange)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Removing product 2 twice");
            Console.WriteLine(collection.DeleteProduct(2));
            Console.WriteLine(collection.DeleteProduct(2));
            Console.WriteLine("Finding by ID = 2:");
            Console.WriteLine(collection.FindProductById(2));
            Console.WriteLine();

            Console.WriteLine("Finding by title (calculator) after deletion:");
            foreach (var product in collection.FindProductsByTitle("Calculator"))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Finding by title (MP3 player) and price (20M): ");
            var mp3PlayersByPriceAndTitle = collection.FindProductsByTitleAndPrice("MP3 Player", 20M);
            foreach (var product in mp3PlayersByPriceAndTitle)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Finding by title (MP3 player) and price range (15M - 40M): ");
            var mp3PlayersByTitleAndPriceRange = collection.FindProductsByTitleAndPriceRange("MP3 Player", 15M, 40M);
            foreach (var product in mp3PlayersByTitleAndPriceRange)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Finding by title (MP3 player) and non-existant price range (150M - 400M): ");
            var falseCollection = collection.FindProductsByTitleAndPriceRange("MP3 Player", 150M, 400M);
            foreach (var product in falseCollection)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Finding by non-existant title (Walkman) and price range (15M - 40M): ");
            falseCollection = collection.FindProductsByTitleAndPriceRange("MP3 Walkman", 15M, 40M);
            foreach (var product in falseCollection)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Finding by supplier (Casio) and price(20M): ");
            var casioProducts = collection.FindProductsBySupplierAndPrice("Casio", 20M);
            foreach (var product in casioProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Finding by supplier (Casio) and price range(20M - 40M): ");
            casioProducts = collection.FindProductsBySupplierAndPriceRange("Casio", 20M, 40M);
            foreach (var product in casioProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }
    }
}
