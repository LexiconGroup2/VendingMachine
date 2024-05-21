<<<<<<< HEAD
﻿using System;
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

        public Product(string name, int price)
        {
            Id = ++totalProductCount;
            Name = name;
            Price = price;
        }

        public abstract string Examine();
        public abstract string Use();
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{       public abstract class Product
    {
        private static int totalProductCount = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Id = ++totalProductCount;
            Name = name;
            Price = price;
        }

        public abstract string Examine();
        public abstract void Use();
    }

}
>>>>>>> d3b2cb4a9af7b2428e7415940a3e34cbe19022de
