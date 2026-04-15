using FantasticVendingMachine.Models;

const int HEADER_ROWS = 11; // rows occupied by the fixed header

VendingMachine machine = new VendingMachine();
User player = new User();

var savedStock = StorageService.LoadData();
if (savedStock.Count > 0)
{
    machine.Stock.Stock = savedStock;
}
else
{
    machine.Stock.AddProduct(new Product("Cola", 1.50m), 5);
    machine.Stock.AddProduct(new Product("Chips", 2.00m), 5);
    machine.Stock.AddProduct(new Product("Cookies", 2.50m), 5);
    machine.Stock.AddProduct(new Product("Candy", 1.50m), 5);
}

player.Wallet.Deposit(10.00m);

Console.Clear();
Console.CursorVisible = true;

bool running = true;

while (running)
{
    DrawHeader(player);
    ClearContentArea();

    Console.SetCursorPosition(0, HEADER_ROWS);
    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    ClearContentArea();
    Console.SetCursorPosition(0, HEADER_ROWS);

    switch (choice)
    {
        case "1":
            machine.ShowInventory();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;

        case "2":
            machine.ShowInventory();
            Console.Write("\nEnter the name of the item you want: ");
            string? itemName = Console.ReadLine();
            if (!string.IsNullOrEmpty(itemName))
            {
                machine.PurchaseItem(itemName, player);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;

        case "3":
            player.ShowPurchasedItems();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;

        case "4":
            Console.Write("How much money do you want to add? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                player.Wallet.Deposit(amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Added {amount:C} to your wallet.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;

        case "5":
            if (machine.Stock.Restock())
            {
                StorageService.SaveData(machine.Stock);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The machine has been restocked!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The machine is already fully stocked!");
            }
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;

        case "6":
            running = false;
            Console.Clear();
            Console.WriteLine("Thanks for using the Fantastic Vending Machine! Goodbye!");
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please pick 1-6.");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;
    }
}

void DrawHeader(User player)
{
    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("======================================");
    Console.WriteLine("  WELCOME TO THE FANTASTIC MACHINE!  ");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"  Your Balance: {player.Wallet.Balance:C}".PadRight(38));
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("======================================");
    Console.ResetColor();
    Console.WriteLine("1. View Available Items               ");
    Console.WriteLine("2. Buy an Item                        ");
    Console.WriteLine("3. Check My Backpack (Purchased Items)");
    Console.WriteLine("4. Add Money to Wallet                ");
    Console.WriteLine("5. Restock Machine                    ");
    Console.WriteLine("6. Exit                               ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("======================================");
    Console.ResetColor();
}

void ClearContentArea()
{
    int width = Math.Max(Console.WindowWidth, 1);
    string blank = new(' ', width);
    for (int row = HEADER_ROWS; row < Console.WindowHeight - 1; row++)
    {
        Console.SetCursorPosition(0, row);
        Console.Write(blank);
    }
}
