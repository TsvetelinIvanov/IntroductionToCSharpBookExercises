using Magnum.Collections;
using System;
using System.Collections.Generic;

namespace _06SearchProductsByPriceRange
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<decimal, Product> products = new OrderedMultiDictionary<decimal, Product>(true);
            string[] priceRange = Console.ReadLine().Split();
            decimal startPrice = decimal.Parse(priceRange[0]);
            decimal endPrice = decimal.Parse(priceRange[1]);
            int productsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < productsCount; i++)
            {
                string[] productInfo = Console.ReadLine().Split(" | ");
                decimal price = decimal.Parse(productInfo[3]);
                Product product = new Product(productInfo[0], productInfo[1], productInfo[2], price);
                products.Add(price, product);
            }

            OrderedMultiDictionary<decimal, Product>.View searchedProducts = products.Range(startPrice, true, endPrice, true);
            if (searchedProducts.Count == 0)
            {
                Console.WriteLine("There are no products in this range!");
                return;
            }

            foreach (KeyValuePair<decimal, ICollection<Product>> productsWithPrice in searchedProducts)
            {
                foreach (Product product in productsWithPrice.Value)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}