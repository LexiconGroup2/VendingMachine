using System;
using System.Collections.Generic;
using VendingMachine;
namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string selectedCategory = ""; // Placeholder for the selected product category
            Dictionary<int, string> productDict = new Dictionary<int, string>();
            string previousChoice = "";
            Console.WriteLine(VendingMachineController.Greeting()); // Greet the customer and display the main menu

            List<Product> products = ProductInserter.GetInitialProducts();

            // Populate the product dictionary with product IDs and names
            for (int i = 0; i < products.Count; i++)
            {
                productDict.Add(i + 1, products[i].Name);
            }

            // Loop until the user decides to exit
            while (true)
            {
                // Display the main menu and get the user's choice
                selectedCategory = VendingMachineController.Menu(selectedCategory);

                // If the selected category is empty, exit the loop
                if (selectedCategory == "")
                {
                    Console.WriteLine("Thank you for using our vending machine. Have a great day!");
                    break;
                }

                // Process the selected category
                // Handle the selected option
                switch (selectedCategory)
                {
                    case "T": // Toy category
                    case "D": // Soft drink category
                    case "S": // Snack category
                              // Process the selected product
                              // Pass the selected product code
                        int selectedOption = VendingMachineController.SubMenu(selectedCategory, previousChoice, productDict, selectedCategory);
                        VendingMachineController.PurchaseProduct(selectedOption);
                        break;
                    case "A": // Add money to the balance
                        VendingMachineController.InsertCoin();
                        break;
                    case "C": // View cart
                        VendingMachineController.ViewCart();
                        break;
                    case "K": // Checkout
                        VendingMachineController.Checkout();
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    }
}


