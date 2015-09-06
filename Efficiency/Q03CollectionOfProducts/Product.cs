namespace Q03CollectionOfProducts
{
    using System;
    
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Product otherProduct)
        {
            return this.Id.CompareTo(otherProduct.Id);
        }

        public override string ToString()
        {
            string output = string.Format("ID No. {0}: {1}, Price: {2}, Supplier: {3}", 
                this.Id, this.Title, this.Price, this.Supplier);
            return output;
        }
    }
}