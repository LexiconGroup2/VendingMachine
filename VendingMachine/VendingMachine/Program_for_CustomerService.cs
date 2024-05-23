using System;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choiceMenu = CustomerService.Greeting();
            Console.WriteLine(choiceMenu);

            Dictionary<int, string> Products = new Dictionary<int, string>();
            Products.Add(1, "Coke");
            Products.Add(2, "Snack");
            Products.Add(3, "Toy");

            switch (choiceMenu)
            {
                case "T" :
                    choiceMenu = "TOYS";
                    break;
                case "S" :
                    choiceMenu = "SNACK";
                    break;
                case "D":
                    choiceMenu = "DRINKS";
                    break;
            }

            int choiceProduct = CustomerService.SubMenu(choiceMenu, Products); // The SubMenu returns the chosen number
            
        }
    }
}
