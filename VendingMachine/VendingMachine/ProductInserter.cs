using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.VendingMachine;

namespace VendingMachine
{
    public class ProductInserter
    {
        public static List<Product> GetInitialProducts()
        {
            var products = new List<Product>();

            products.Add(new Drink("Coke", 15, "Drink", 250, "Refreshing cola drink"));
            products.Add(new Drink("Pepsi", 20, "Drink", 300, "Classic cola drink"));
            products.Add(new Drink("Fanta", 18, "Drink", 200, "Fruity orange soda"));

            products.Add(new Snack("Chips", 20, "Snack", 200, "Delicious crispy chips"));
            products.Add(new Snack("Chocolate", 25, "Snack", 150, "Creamy milk chocolate bar"));
            products.Add(new Snack("Popcorn", 30, "Snack", 180, "Buttery popcorn"));

            products.Add(new Toy("Spider man", 50, "Toy", "Plastic", "Cool action figure"));
            products.Add(new Toy("Batman", 100, "Toy", "Plastic", "Dark knight action figure"));
            products.Add(new Toy("Transformers", 80, "Toy", "Metal", "Transforming robot toy"));

            return products;
        }
    }

}
