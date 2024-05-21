using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Snack : Product
    {
        public int Calories { get; set; }

        public Snack(string name, int price, int calories)
            : base(name, price)
        {
            Calories = calories;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Product: {Name}, Price: {Price:C}, Calories: {Calories}";
        }

        public override void Use()
        {
            Console.WriteLine($"You eat the {Name}. Tasty!");
        }
    }

}
