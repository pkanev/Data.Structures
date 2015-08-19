using System;
using Wintellect.PowerCollections;

namespace _02ProductsInPriceRange
{
    class ProductsInPriceRange
    {
        static void Main()
        {
            var mDict = new OrderedMultiDictionary<decimal, Product>(true);
            string[] productNames =
            {
                "Toy", "Food", "Car", "TV", "Computer", "Refrigerator", 
                "Bicylce", "Skateboard", "Bag", "EReader", "Phone", "Guitar", 
            };
            var rand = new Random();
            for (int i = 0; i < 500000; i++)
            {
                decimal price = rand.Next(1, 10000);
                string name = productNames[rand.Next(0, productNames.Length)];
                mDict.Add(price, new Product(name, price));
            }

            var productsInRange = mDict.Range(25, true, 30, true);
            Console.WriteLine("Total products in price range: {0}", productsInRange.KeyValuePairs.Count);
            Console.WriteLine("==================================");
            foreach (var products in productsInRange)
            {
                Console.WriteLine("Price: {0}, Count: {1}", products.Key, productsInRange[products.Key].Count);
                Console.WriteLine("Products: {0}", string.Join(", ", products.Value));
                Console.WriteLine("==================================");
            }
        }
    }
}
