using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VendingMachineService : IVending
    {
        List<Product> products = new List<Product>();
        List<Product> shoppingCart = new List<Product>();
        int moneyPool;
        private int balance = 0;
        public VendingMachineService()
        {
            products = ProductInserter.GetInitialProducts();
            moneyPool = 0;
        }

        public string Details(int productId)
        {
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                return product.Examine();
            }
            else
            {
                return "Product not found.";
            }
        }

        public Dictionary<int, int> EndTransaction()
        {
            var change = new Dictionary<int, int>();
            int remainingAmount = moneyPool;

            foreach (var denomination in Denominations.ValidDenominations.OrderByDescending(d => d))
            {
                if (remainingAmount >= denomination)
                {
                    int count = remainingAmount / denomination;
                    change.Add(denomination, count);
                    remainingAmount %= denomination;
                }
            }

            moneyPool = 0;
            return change;
        }

        public void InsertMoney(int amount)
        {
            if (!Denominations.ValidDenominations.Contains(amount))
            {
                throw new ArgumentException("Invalid denomination.");
            }

            moneyPool += amount;
            balance += amount;
        }
        // Method to get the current balance
        public int GetBalance()
        {
            return balance;
        }


        public Product Purchase(int productId)
        {
            Product product = products.Find(p => p.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            if (product.Price > moneyPool)
            {
                throw new InvalidOperationException("Insufficient funds to purchase the product.");
            }

            moneyPool -= product.Price;
            return product;
        }

        public List<string> ShowAll()
        {
            List<string> productDescriptions = new List<string>();

            foreach (var product in products)
            {
                productDescriptions.Add($"{product.Id}. {product.Name} - {product.Price}kr");
            }

            return productDescriptions;
        }

        public string AddCart(int productId)
        {
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                shoppingCart.Add(product);
                return $"{product.Name} added to the cart.";
            }
            else
            {
                return "Product not found.";
            }
        }

        public string RemoveCart(int productId)
        {
            Product product = shoppingCart.Find(p => p.Id == productId);
            if (product != null)
            {
                shoppingCart.Remove(product);
                return $"{product.Name} removed from the cart.";
            }
            else
            {
                return "Product not found in the cart.";
            }
        }

        public List<string> ViewCart()
        {
            List<string> cartItems = new List<string>();

            foreach (var product in shoppingCart)
            {
                cartItems.Add($"{product.Id}. {product.Name} - {product.Price}kr");
            }

            return cartItems;
        }

        public string Checkout()
        {
            decimal totalCost = shoppingCart.Sum(p => p.Price);
            if (totalCost > moneyPool)
            {
                throw new InvalidOperationException("Insufficient funds to complete the purchase.");
            }

            // Deduct the total cost from the balance
            balance -= (int)totalCost;

            // Clear the shopping cart
            shoppingCart.Clear();

            return "Purchase completed successfully.";
        }

        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
