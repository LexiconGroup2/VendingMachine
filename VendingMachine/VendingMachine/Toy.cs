
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine;

namespace VendingMachine
{
    public class Toy : Product
    {
        public string Material { get; set; }
        public string Description { get; set; }

        public Toy(string name, int price, string category, string material, string description)
            : base(name, price, category)
        {
            Material = material;
            Description = description;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Product: {Name}, Price: {Price:C}, Material: {Material}, Description: {Description}";
        }

        public override string Use()
        {
            return $"You play with the {Name}. Fun!";
        }
    }

}
