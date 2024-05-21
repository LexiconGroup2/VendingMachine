using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Toy : Product
    {
        public string Material { get; set; }

        public Toy(string name, int price, string material): base(name, price)
        {
            Material = material;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Product: {Name}, Price: {Price:C}, Material: {Material}";
            
        }

        public override string Use()
        {
            return $"You play with the {Name}. Fun!";
        }
    }
}
