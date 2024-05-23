using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace VendingMachine
    {
        public class Drink : Product
        {
            public int Milliliters { get; set; }

            public Drink(string name, int price, string category, int milliliters, string description)
                : base(name, price, category)
            {
                Milliliters = milliliters;
                Description = description;
            }

            public override string Examine()
            {
                return $"Drink: {Name}, Price: {Price}kr, Milliliters: {Milliliters}, Description: {Description}";
            }

            public override string Use()
            {
                return $"Enjoy your {Name}!";
            }
        }

    }



}
