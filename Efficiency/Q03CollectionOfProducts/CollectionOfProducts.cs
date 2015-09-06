namespace Q03CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class CollectionOfProducts
    {
        private Dictionary<int, Product> productsById = new Dictionary<int, Product>();
        private OrderedDictionary<decimal, OrderedSet<Product>> productsByPrice = 
            new OrderedDictionary<decimal, OrderedSet<Product>>();

        private Dictionary<string, Set<Product>> productsByTitle =
            new Dictionary<string, Set<Product>>(); //intentionally left unordered

        private Dictionary<string, OrderedDictionary<decimal, OrderedSet<Product>>> productsByTitleAndPrice =
            new Dictionary<string, OrderedDictionary<decimal, OrderedSet<Product>>>();

        private Dictionary<string, OrderedDictionary<decimal, OrderedSet<Product>>> productsBySupplierAndPrice =
            new Dictionary<string, OrderedDictionary<decimal, OrderedSet<Product>>>();

        public bool Add(int id, string title, string supplier, decimal price)
        {
            if (this.FindProductById(id) != null)
            {
                return false;
            }

            Product product = new Product()
            {
                Id = id,
                Title = title,
                Supplier = supplier,
                Price = price
            };

            //Adding to productsById
            this.productsById.Add(id, product);
            //Adding to productsByPrice
            this.productsByPrice.AppendValueToKey(price, product);
            //Adding to productsByTitle
            this.productsByTitle.AppendValueToKey(title, product);
            //Adding to productsByTitleAndPrice
            this.productsByTitleAndPrice.EnsureKeyExists(title);
            this.productsByTitleAndPrice[title].AppendValueToKey(price,product);
            //Adding to productsBySupplierAndPrice
            this.productsBySupplierAndPrice.EnsureKeyExists(supplier);
            this.productsBySupplierAndPrice[supplier].AppendValueToKey(price, product);

            return true;
        }

        public bool DeleteProduct(int id)
        {
            Product product = this.FindProductById(id);
            if (product == null)
            {
                return false;
            }

            var personDeleted = this.productsById.Remove(id);
            this.productsByPrice[product.Price].Remove(product);
            this.productsByTitle[product.Title].Remove(product);
            this.productsByTitleAndPrice[product.Title][product.Price].Remove(product);
            this.productsBySupplierAndPrice[product.Supplier][product.Price].Remove(product);

            return true;
        }

        public Product FindProductById(int id)
        {
            Product product;
            var productExists = this.productsById.TryGetValue(id, out product);
            return product;
        }

        public Set<Product> FindProductsByTitle(string title)
        {
            if (this.productsByTitle.ContainsKey(title))
            {
                return this.productsByTitle[title];
            }
            return null;
        }

        public IEnumerable<Product> FindProductsByPriceRange(decimal lowPrice, decimal highPrice)
        {
            var productsInRange = this.productsByPrice.Range(lowPrice, true, highPrice, true);
            foreach (var productsByTitle in productsInRange)
            {
                foreach (var product in productsByTitle.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                yield break;
            }
            if (!this.productsByTitleAndPrice[title].ContainsKey(price))
            {
                yield break;
            }
            foreach (var product in this.productsByTitleAndPrice[title][price])
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, decimal lowPrice, decimal highPrice)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                yield break;
            }
            var productsInRange = this.productsByTitleAndPrice[title].Range(lowPrice, true, highPrice, true);

            foreach (var pByPrice in productsInRange)
            {
                foreach (var product in pByPrice.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                yield break;
            }
            if (!this.productsBySupplierAndPrice[supplier].ContainsKey(price))
            {
                yield break;
            }
            foreach (var product in this.productsBySupplierAndPrice[supplier][price])
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, decimal lowPrice, decimal highPrice)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                yield break;
            }
            var productsInRange = this.productsBySupplierAndPrice[supplier].Range(lowPrice, true, highPrice, true);

            foreach (var pByPrice in productsInRange)
            {
                foreach (var product in pByPrice.Value)
                {
                    yield return product;
                }
            }
        }
    }
}