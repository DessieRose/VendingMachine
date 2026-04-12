using FantasticVendingMachine.Models;

VendingMachine machine = new VendingMachine();
User player = new User();

machine.Stock.AddProduct(new Product("Cola", 1.50m));
machine.Stock.AddProduct(new Product("Chips", 2.00m));
machine.Stock.AddProduct(new Product("Cookies", 2.50m));
machine.Stock.AddProduct(new Product("Candy", 1.50m));


player.Wallet.Deposit(10.00m);

bool running = true;

while (running)
{
    Console.WriteLine("\n======================================");
    Console.WriteLine("  WELCOME TO THE FANTASTIC MACHINE!");
    Console.WriteLine($"  Your Balance: {player.Wallet.Balance:C}");
    Console.WriteLine("======================================");
    Console.WriteLine("1. View Available Items");
    Console.WriteLine("2. Buy an Item");
    Console.WriteLine("3. Check My Backpack (Purchased Items)");
    Console.WriteLine("4. Add Money to Wallet");
    Console.WriteLine("5. Exit");
    Console.Write("\nChoose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            machine.ShowInventory();
            break;

        case "2":
            machine.ShowInventory();
            Console.Write("\nEnter the name of the item you want: ");
            string? itemName = Console.ReadLine();
            if (!string.IsNullOrEmpty(itemName))
            {
                machine.PurchaseItem(itemName, player);
            }
            break;

        case "3":
            player.ShowPurchasedItems();
            break;

        case "4":
            Console.Write("How much money do you want to add? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                player.Wallet.Deposit(amount);
                Console.WriteLine($"Added {amount:C} to your wallet.");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
            break;

        case "5":
            running = false;
            Console.WriteLine("Thanks for using the Fantastic Vending Machine! Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid choice. Please pick 1-5.");
            break;
    }
}