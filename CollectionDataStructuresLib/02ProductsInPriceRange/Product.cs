using System;

namespace _02ProductsInPriceRange
{
    public class Product : IComparable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            var other = (Product)obj;
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}