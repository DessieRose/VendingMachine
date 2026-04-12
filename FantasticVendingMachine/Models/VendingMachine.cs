namespace FantasticVendingMachine.Models;

public class VendingMachine
{
    public Inventory Stock { get; private set; } = new Inventory();
    public Bank MachineBank { get; private set; } = new Bank();

    public void PurchaseItem(string itemName, User user)
    {
        Product? product = Stock.GetProductByName(itemName);

        if (product == null || Stock.Stock[product] <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {itemName} is out of stock!");
            Console.ResetColor();
            return;
        }

        if (user.Wallet.Withdraw(product.Price))
        {
            MachineBank.Deposit(product.Price);
            user.PurchasedItems.Add(product);
            Stock.ReduceStock(product);

            StorageService.SaveData(Stock);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Success! You bought {product.Name}. {Stock.Stock[product]} left.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: You don't have enough money for {product.Name}!");
            Console.WriteLine($"Price: {product.Price:C} | Your Balance: {user.Wallet.Balance:C}");
            Console.ResetColor();
        }
    }

    public void ShowInventory()
    {
        var items = Stock.GetAllProducts();
        Console.WriteLine("\n--- Vending Machine Inventory ---");
        
        if (Stock.Stock.Count == 0)
        {
            Console.WriteLine("The machine is currently empty.");
        }
        else
        {
            foreach (var kvp in Stock.Stock)
            {
                Console.WriteLine($"- {kvp.Key.Name}: {kvp.Key.Price:C} ({kvp.Value} left)");
            }
        }
    }
}