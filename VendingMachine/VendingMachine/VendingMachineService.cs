using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachineService : IVending
    {
        List<Product> products = new List<Product>();
        int moneyPool;
        //static readonly int[] validDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public VendingMachineService()
        {
            // Initialize with initial products
            products = ProductInserter.GetInitialProducts();
            moneyPool = 0;
        }
        public string Details(int productId)
        {
            //Product product = null;
            //foreach (var p in products)
            //{
            //    if (p.Id == productId)
            //    {
            //        product = p;
            //        break;
            //    }
            //}
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                return product.Examine();
            }
            else
            {
                return "Product not found.";
            }

            throw new NotImplementedException();
        }

        public Dictionary<int, int> EndTransaction()
        {
            var change = new Dictionary<int, int>();
            int remainingAmount = moneyPool;

            // Iterate through valid denominations from largest to smallest
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
            throw new NotImplementedException();
        }

        public void InsertMoney(int amount)
        {
            if (!Denominations.ValidDenominations.Contains(amount))
            {
                throw new ArgumentException("Invalid denomination.");
            }
            
            moneyPool += amount;
            throw new NotImplementedException();
        }

        public Product Purchase(int productId)
        {
            Product product = null;
            foreach (var p in products)
            {
                if (p.Id == productId)
                {
                    product = p;
                    break;
                }
            }
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Handle the case where there is insufficient money
            if (product.Price > moneyPool)
            {
                throw new InvalidOperationException("Insufficient funds to purchase the product.");
            }

            // Deduct the cost from the money pool and return the product
            moneyPool -= product.Price;
            return product;
            throw new NotImplementedException();
        }

        public List<string> ShowAll()
        {
            List<string> productDescriptions = new List<string>();

            foreach (var product in products)
            {
                productDescriptions.Add($"{product.Id}. {product.Name} - {product.Price}kr");
            }

            return productDescriptions;
            throw new NotImplementedException();
        }

       
    }
}
