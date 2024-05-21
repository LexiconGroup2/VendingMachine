using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{       public class Drink : Product
    {
        public int Volume { get; set; } // in milliliters

        public Drink(string name, int price, int volume)
            : base(name, price)
        {
            Volume = volume;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Product: {Name}, Price: {Price:C}, Volume: {Volume}ml";
        }

        public override void Use()
        {
            Console.WriteLine($"You drink the {Name}. Refreshing!");
        }
    }

}
