using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VendingMachine
{
    public class VendingMachineController
    {
        private static void sleep() { Thread.Sleep(1000); }
        private static string choice;
        private static VendingMachineService vendingMachineService = new VendingMachineService();

        public static string Greeting()
        {
            Console.WriteLine("\t\tWelcome to the A.O.T. Inc. vending machine!");
            Console.WriteLine("\t\tWe're happy to satisfy your selfish needs.");
            Thread.Sleep(3000);

            choice = Menu();

            return choice;
        }

        public static string Menu(string previousChoice = null)
        {
            Console.Clear();
            Console.WriteLine("\t\tYou're in the MAIN menu.");
            Console.WriteLine();
            Console.WriteLine("\tPlease, choose from the following product categories:");
            Console.WriteLine();
            sleep();
            Console.WriteLine("\t\tPlease press \"T\" if you wanna buy a TOY!");
            Console.WriteLine("\t\tPlease press \"D\" in case of a soft DRINK!");
            Console.WriteLine("\t\tPlease press \"S\" If you're hungry for a SNACK!");
            Console.WriteLine();
            Console.WriteLine("\t\tIf you wanna fill up your balance please press \"A\"!");
            Console.WriteLine();
            Console.WriteLine("\t\tIf you want to view your cart, please press \"C\"!");
            Console.WriteLine("\t\tIf you want to checkout, please press \"K\"!");

            // Show current balance
            Console.WriteLine($"\n\t\tYour current balance: {vendingMachineService.GetBalance()}kr");

            string currentChoice = previousChoice;
            bool scs = false;
            do
            {
                Console.Write("\t\tPlease enter your choice! ");
                currentChoice = ValidCheckLttr(Console.ReadLine()?.ToUpper());

                if (currentChoice == "T")
                {
                    // Display products in the "Toy" category
                    ShowProductsForCategory("Toy");
                    SubMenu("Toy", previousChoice, new Dictionary<int, string>(), currentChoice);

                    scs = true;
                }
                else if (currentChoice == "D")
                {
                    // Display products in the "Drink" category
                    ShowProductsForCategory("Drink");
                    SubMenu("Drink", previousChoice, new Dictionary<int, string>(), currentChoice);
                    scs = true;
                }
                else if (currentChoice == "S")
                {
                    // Display products in the "Snack" category
                    ShowProductsForCategory("Snack");
                    SubMenu("Snack", previousChoice, new Dictionary<int, string>(), currentChoice);
                    scs = true;
                }
                else if (currentChoice == "A")
                {
                    // Add money to the balance
                    InsertCoin();
                    scs = true;
                }
                else if (currentChoice == "C")
                {
                    // View cart
                    ViewCart();
                    scs = true;
                }
                else if (currentChoice == "K")
                {
                    // Checkout
                    Checkout();
                    scs = true;
                }
                else
                {
                    Console.WriteLine("Please choose only from the letters in the menu!");
                }
            } while (!scs);

            return currentChoice;
        }


        public static int SubMenu(string ProductCategory, string previousChoice, Dictionary<int, string> productDict, string selectedCategory)
        {
            var products = vendingMachineService.GetProductsByCategory(ProductCategory);

            if (!products.Any())
            {
                Console.WriteLine($"No products available in the {ProductCategory} category.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return 0; // Return 0 if there are no products
            }
            else
            {
                Console.WriteLine("\t\tNow you can choose from the following products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - {product.Price}kr");
                }
            }

            int selectedOption = 0; // Declare and initialize selectedOption variable

            bool success = false;
            do
            {
                Console.WriteLine("\t\tIf you wanna buy a product, please type in the product code!");
                Console.WriteLine("\t\tTo view product details, type in the product code followed by 'I' (e.g., '1I' for product 1)!");
                Console.WriteLine("\t\tTo go back to the main menu, please press \"B\"!");
                Console.Write("\t\tEnter your choice: ");
                var input = Console.ReadLine();

                if (input?.ToUpper().EndsWith("I") == true && int.TryParse(input[..^1], out int productCode) && products.Any(p => p.Id == productCode))
                {
                    ProductInfo(productCode, selectedOption);
                }
                else if (int.TryParse(input, out productCode) && products.Any(p => p.Id == productCode))
                {
                    // Purchase the product and handle success or failure
                    success = PurchaseProduct(productCode);
                    if (success)
                    {
                        selectedOption = productCode; // Assign product code to selectedOption
                    }
                }
                else if (input?.ToUpper() == "B")
                {
                    previousChoice = ProductCategory; // Update previousChoice to reflect the current product category
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            } while (!success);

            return selectedOption;
        }

        static string ValidCheckLttr(string lttr)
        {
            if (!string.IsNullOrEmpty(lttr) && lttr.Length == 1 && char.IsLetter(lttr[0]))
            {
                return lttr;
            }
            else
            {
                Console.WriteLine("Please choose only from the letters in the menu!");
                return "";
            }
        }

        public static void InsertCoin()
        {
            bool success = false;
            do
            {
                Console.WriteLine("Enter the amount to insert (valid denominations: 1, 5, 10, 20, 50, 100, 200, 500, 1000): ");
                string input = Console.ReadLine();
                Console.WriteLine($"Entered denomination: {input}"); // Debugging output
                if (int.TryParse(input, out int amount))
                {
                    try
                    {
                        vendingMachineService.InsertMoney(amount);
                        Console.WriteLine($"{amount}kr inserted successfully.");
                        Console.WriteLine("Do you want to insert more money or go back to the main menu? (M for more money, B to go back)");
                        string response = Console.ReadLine()?.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(response))
                        {
                            if (response == "B")
                            {
                                // Exit the loop if the user wants to go back to the main menu
                                success = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'M' for more money or 'B' to go back.");
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            } while (!success);
        }


        public static void ShowProductsForCategory(string category)
        {
            List<Product> products = vendingMachineService.GetProductsByCategory(category);
            if (products.Any())
            {
                Console.WriteLine($"Products in the {category} category:");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - {product.Price}kr");
                }
            }
            else
            {
                Console.WriteLine($"No products available in the {category} category.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

       
        public static bool PurchaseProduct(int productCode)
        {
            try
            {
                Product product = vendingMachineService.Purchase(productCode);
                Console.WriteLine($"Purchased: {product.Name} for {product.Price}kr.");
                vendingMachineService.AddCart(productCode);
                return true; // Purchase successful
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "Insufficient balance")
                {
                    Console.WriteLine("Insufficient balance. Please insert money to proceed with the purchase.");
                    InsertCoin(); // Prompt the user to insert money
                    return PurchaseProduct(productCode); // Attempt the purchase again
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    return false; // Purchase failed
                }
            }
        }

        public static void ViewCart()
        {
            List<string> cartItems = vendingMachineService.ViewCart();
            if (cartItems.Any())
            {
                Console.WriteLine("Items in your cart:");
                foreach (string item in cartItems)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); // Wait for user to press any key

            // Clear the console
            Console.Clear();

            // Read the user input again
            Menu();
        }


        public static void Checkout()
        {
            // Check if the cart is empty
            if (vendingMachineService.ViewCart().Count == 0)
            {
                Console.WriteLine("Your cart is empty. Please add items before checking out.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                // Return to the main menu
                Menu();
            }

            try
            {
                string message = vendingMachineService.Checkout();
                Console.WriteLine(message);

                // Display current balance
                Console.WriteLine($"Your current balance: {vendingMachineService.GetBalance()}kr");

                Console.WriteLine("Do you want to buy more items? (Y/N)");
                string response = Console.ReadLine()?.ToUpper();
                if (response == "N")
                {
                    Console.WriteLine("Thank you for using A.O.T. Inc. vending machine!");
                    Environment.Exit(0); // Exit the program
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void ProductInfo(int productId, int selectedOption)
        {
            var product = vendingMachineService.GetProductById(productId);
            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}kr");
                Console.WriteLine($"Description: {product.Description}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
