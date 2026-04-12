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
            Console.WriteLine($"Error: {itemName} is out of stock!");
            return;
        }

        if (user.Wallet.Withdraw(product.Price))
        {
            MachineBank.Deposit(product.Price);
            user.PurchasedItems.Add(product);
            Stock.ReduceStock(product);

            StorageService.SaveData(Stock);
            
            Console.WriteLine($"Success! You bought {product.Name}. {Stock.Stock[product]} left.");
        }
        else
        {
            Console.WriteLine($"Error: You don't have enough money for {product.Name}!");
            Console.WriteLine($"Price: {product.Price:C} | Your Balance: {user.Wallet.Balance:C}");
        }
    }

    public void ShowInventory()
    {
        var items = Stock.GetAllProducts();
        Console.WriteLine("\n--- Vending Machine Inventory ---");
        
        if (items.Count == 0)
        {
            Console.WriteLine("The machine is currently empty.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Name}: {item.Price:C}");
            }
        }
    }
}