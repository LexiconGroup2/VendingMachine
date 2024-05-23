using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VendingMachineService : IVending
    {
        // List of available products
        List<Product> products = new List<Product>();
        // List representing the shopping cart
        List<Product> shoppingCart = new List<Product>();
        // Current amount of money in the machine
        int moneyPool;

        public VendingMachineService()
        {
            // Initialize the vending machine with initial products
            products = ProductInserter.GetInitialProducts();
            moneyPool = 0;
        }

        // Get details of a product by its ID
        public string Details(int productId)
        {
            // Find the product with the specified ID
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                // Return the product details
                return product.Examine();
            }
            else
            {
                return "Product not found.";
            }
        }

        // End the transaction and return the remaining change
        public Dictionary<int, int> EndTransaction()
        {
            var change = new Dictionary<int, int>();
            int remainingAmount = moneyPool;

            // Calculate change based on the remaining money pool
            foreach (var denomination in Denominations.ValidDenominations.OrderByDescending(d => d))
            {
                if (remainingAmount >= denomination)
                {
                    int count = remainingAmount / denomination;
                    change.Add(denomination, count);
                    remainingAmount %= denomination;
                }
            }

            // Reset the money pool and return the calculated change
            moneyPool = 0;
            return change;
        }

        // Insert money into the vending machine
        public void InsertMoney(int amount)
        {
            if (!Denominations.ValidDenominations.Contains(amount))
            {
                throw new ArgumentException("Invalid denomination.");
            }

            moneyPool += amount;
        }

        // Purchase a product by its ID
        public Product Purchase(int productId)
        {
            // Find the product with the specified ID
            Product product = products.Find(p => p.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Check if there is enough money to purchase the product
            if (product.Price > moneyPool)
            {
                throw new InvalidOperationException("Insufficient funds to purchase the product.");
            }

            // Deduct the cost of the product from the money pool and return the product
            moneyPool -= product.Price;
            return product;
        }

        // Display all available products
        public List<string> ShowAll()
        {
            List<string> productDescriptions = new List<string>();

            // Add each product's description to the list
            foreach (var product in products)
            {
                productDescriptions.Add($"{product.Id}. {product.Name} - {product.Price}kr");
            }

            return productDescriptions;
        }

        // Add a product to the shopping cart by its ID
        public string AddCart(int productId)
        {
            // Find the product with the specified ID
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                // Add the product to the shopping cart and return a success message
                shoppingCart.Add(product);
                return $"{product.Name} added to the cart.";
            }
            else
            {
                return "Product not found.";
            }
        }

        // Remove a product from the shopping cart by its ID
        public string RemoveCart(int productId)
        {
            // Find the product with the specified ID in the shopping cart
            Product product = shoppingCart.Find(p => p.Id == productId);
            if (product != null)
            {
                // Remove the product from the cart and return a success message
                shoppingCart.Remove(product);
                return $"{product.Name} removed from the cart.";
            }
            else
            {
                return "Product not found in the cart.";
            }
        }

        // View the current items in the shopping cart
        public List<string> ViewCart()
        {
            List<string> cartItems = new List<string>();

            // Add each product's description in the cart to the list
            foreach (var product in shoppingCart)
            {
                cartItems.Add($"{product.Id}. {product.Name} - {product.Price}kr");
            }

            return cartItems;
        }

        // Checkout the items in the shopping cart
        public string Checkout()
        {
            // Calculate the total cost of the items in the cart
            decimal totalCost = shoppingCart.Sum(p => p.Price);
            if (totalCost > moneyPool)
            {
                throw new InvalidOperationException("Insufficient funds to complete the purchase.");
            }

            // Deduct the total cost from the money pool and clear the cart
            moneyPool -= (int)totalCost;
            shoppingCart.Clear();
            return "Purchase completed successfully.";
        }
    }
}
