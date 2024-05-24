using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Product
    {
        private static int totalProductCount = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public Product(string name, int price, string category)
        {
            Id = ++totalProductCount;
            Name = name;
            Price = price;
            Category = category;
        }

        public abstract string Examine();
        public abstract string Use();
    }
}
