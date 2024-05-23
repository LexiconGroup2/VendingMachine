using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VendingMachine
{
    internal class Snack : Product
    {
        public int Calories { get; set; }
        public string Description { get; set; }

        public Snack(string name, int price, string category, int calories, string description)
            : base(name, price, category)
        {
            Calories = calories;
            Description = description;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Product: {Name}, Price: {Price:C}, Calories: {Calories}, Description: {Description}";
        }

        public override string Use()
        {
            return $"You eat the {Name}. Tasty!";
        }
    }

}
