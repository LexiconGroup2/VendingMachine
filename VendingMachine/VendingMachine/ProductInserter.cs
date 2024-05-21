using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ProductInserter
    {
        public static List<Product> GetInitialProducts()
        {
            var products = new List<Product>();

            products.Add(new Drink("Coke", 15, 250));
            products.Add(new Snack("Chips", 20, 200));
            products.Add(new Toy("Action Figure", 50, "Plastic"));

            return products;
        }
    }
}
