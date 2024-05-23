//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace VendingMachine
//{
//    public class CustomerService
//    {
//        private static void sleep() { Thread.Sleep(1000); }
//        private static string choice;

//        public static string Greeting()                     // Greeting the customer
//        {
//            Console.WriteLine("\t\tWelcome to the A.O.T. Inc. vending machine!");
//            Console.WriteLine("\t\tWe're happy to satisfy your selfish needs.");
//            Thread.Sleep(3000);
            
//            string choice = MainMenu();                // Calling for the Main menu


//            return choice;
//        }

//        public static string MainMenu()         // Main menu communication
//        {
            
//            Console.Clear();
//            Console.WriteLine("\t\tYou're in the MAIN menu.");
//            Console.WriteLine();
//            Console.WriteLine("\tPlease, choose from the following product categories:");
//            Console.WriteLine();
//            sleep();
//            Console.WriteLine("\t\tPlease press \"T\" if you wanna buy a TOY!");
//            Console.WriteLine("\t\tPlease press \"D\" in case of a soft DRINK!");
//            Console.WriteLine("\t\tPlease press \"S\" If you're hungry for a SNACK!");
//            Console.WriteLine();
//            Console.WriteLine("\t\tIf you wanna fill up your saldo please press \"A\"!");
//            Console.WriteLine();

//            bool scs = false;
//            do
//            {
//                Console.Write("\t\tPlease enter your choice! ");
//                choice = ValidCheckLttr(Console.ReadLine().ToUpper());
                
//                if (choice =="T" ||  choice =="D" ||  choice == "S")
//                {
//                    scs = true;
//                }
//                else { Console.WriteLine("Please choose only from the letters in the menu!"); }
//            }
//            while (!scs);

//            return choice;
//        }

//        public static int SubMenu(string ProductCategory, Dictionary<int, string> ProductList)
//        {
//            PrintSubMenu(ProductCategory, ProductList);
            
//            int nmr = 0;
//            bool scces = false;

//            do
//            {
//                ConsoleKeyInfo PressedKey = Console.ReadKey();
//                char keyChar = PressedKey.KeyChar;

//                if (Char.IsLetter(keyChar))
//                {
//                    switch (keyChar)
//                    {
//                        case 'a' :
//                            //InsertCoin();                                     // The account method
//                            //choice = keyChar.ToString();                        // You can ignore this
//                            scces = true;
//                            break;
//                        case 'i' :
//                            ProductInfo(ProductCategory, ProductList);          // The product info page
//                            //choice = keyChar.ToString();                        // You can ignore this
//                            scces |= false;
//                            break;
//                        default :
//                            Console.WriteLine($"\nYou pressed a wrong key. Try again!");
//                            break;
//                    }
//                }
//                else if (Char.IsDigit(keyChar))
//                {
//                    scces = true;
//                    nmr = keyChar - '0';
//                }
//                else
//                {
//                    Console.WriteLine($"\nYou pressed a wrong key. Try again!");
//                }
//            }
//            while (!scces);

//            return nmr;
//        }

//        public static void ProductInfo(string ProductCategory, Dictionary<int, string> ProductList)
//        {
//            Console.Clear();
//            Console.WriteLine("COKE: A popular soft drink made primerily from chemicals and other unhealthy substances.");
//            Console.WriteLine("SNACKS: An artifical food without nutritional value. Sad little bags of lies and regrets.");
//            Console.WriteLine("TOYS: If I have to explain it to you, you are not even authorized to use the vending machine!");
//            while (true)
//            {
//                var key = Console.ReadKey(intercept: true);
//                if (key.Key == ConsoleKey.Escape) break;
//            }
//            PrintSubMenu(ProductCategory, ProductList);
//        }

//        public static void PrintSubMenu(string ProductCategory, Dictionary<int, string> ProductList)
//        {
//            Console.Clear();
//            Console.WriteLine($"\t\tYou're in the {ProductCategory} menu.");
//            Console.WriteLine();
//            Console.WriteLine("\t\tNow you can choose from the following products:");
//            Console.WriteLine();
//            sleep();
//            foreach (KeyValuePair<int, string> kvp in ProductList)
//            {
//                Console.Write($"\t\tCode: {kvp.Key} - {kvp.Value}");
//                Console.WriteLine();
//            }

//            Console.WriteLine();
//            Console.WriteLine("\t\tIf you wanna buy a product, please type in the product code!");
//            Console.WriteLine("\t\tFor more detailed product information, please press \"i\"!");

//            Console.WriteLine();
//            Console.WriteLine("\t\tIf you wanna fill up your saldo press \"A\"!");
//            Console.WriteLine();
//        }








//        static string ValidCheckLttr(string lttr)
//        {
//            try
//            {
//               lttr = Convert.ToString(lttr);
//            }
//            catch (Exception FormatException)
//            {
//                Console.WriteLine("Please choose only from the letters in the menu!");
//                return "";
//            }
//            return lttr;
//        }
//    }
//}
