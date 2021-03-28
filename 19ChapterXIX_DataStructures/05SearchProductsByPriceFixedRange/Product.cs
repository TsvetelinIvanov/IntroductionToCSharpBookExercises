using System;

namespace _05SearchProductsByPriceFixedRange
{
    public class Product : IComparable<Product>
    {
        private string barcode;
        private string vendor;
        private string name;
        private decimal price;

        public Product(string barcode, string vendor, string name, decimal price)
        {
            this.barcode = barcode;
            this.vendor = vendor;
            this.name = name;
            this.price = price;
        }

        public decimal Price => this.price;
        

        public override string ToString()
        {
            return $"Name: {this.name}, Price: {this.price:f2}, Barcode: {this.barcode}, Vendor: {this.vendor}.";
        }

        public int CompareTo(Product product)
        {            
            return this.price.CompareTo(product.price);
        }
    }
}