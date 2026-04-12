using System.Collections.Generic;

namespace FantasticVendingMachine.Models;

public class User
{
    public Bank Wallet { get; private set; } = new Bank();

    public List<Product> PurchasedItems { get; private set; } = new List<Product>();

    public void ShowPurchasedItems()
    {
        Console.WriteLine("\n--- Your Items ---");
        if (PurchasedItems.Count == 0)
        {
            Console.WriteLine("You haven't bought anything yet!");
        }
        else
        {
            foreach (var item in PurchasedItems)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}