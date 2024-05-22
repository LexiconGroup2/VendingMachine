using VendingMachine;

public class Program
{
    public static void Main(string[] args)

    {
        VendingMachineService vending = new VendingMachineService();
       // Ivendending VendingMachine = new VendingMachine();

        while (true)
        {
            Console.WriteLine("Vending MAchine");
            Console.WriteLine("1.Display All The products");
            Console.WriteLine("2.Display product Details");
            Console.WriteLine("3.Insert Money");
            Console.WriteLine("4.My Shopping Cart");
            Console.WriteLine("5.End Transaction");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Select an option");

            string choice = Console.ReadLine();
            {
                switch (choice)
                {
                    case "1":
                        var products = vending.ShowAll;
                        Console.WriteLine(products);
                        break;

                    case "2":

                        //Console.WriteLine("Enter product Id");


                        Console.WriteLine(vending.Details);
                        break;

                    case "3":

                        Console.WriteLine("Enter the amount");

                        int amount = int.Parse(Console.ReadLine());

                        vending.InsertMoney(amount);

                        break;

                    case "4":

                        Console.WriteLine("My Shopping Cart");
                        break;

                    case "5":

                        var change = vending.EndTransaction();

                        Console.WriteLine("Transaction Ended");

                        foreach (var item in change)
                        {
                            Console.WriteLine($"{item.Key}Kr:{item.Value} coins");
                        }


                        break;
                    case "6":
                        return;

                    default:
                        Console.WriteLine("Enter valid opiton");
                        break;






                }
            }

        }



    }
}


