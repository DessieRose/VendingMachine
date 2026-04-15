using System.Text.Json;

namespace FantasticVendingMachine.Models;

public static class StorageService
{
    private const string FileName = "vending_data.json";

    private class StockEntry
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public static void SaveData(Inventory inventory)
    {
        var entries = inventory.Stock
            .Select(kvp => new StockEntry { Name = kvp.Key.Name, Price = kvp.Key.Price, Quantity = kvp.Value })
            .ToList();

        string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, jsonString);
    }

    public static Dictionary<Product, int> LoadData()
    {
        if (!File.Exists(FileName))
        {
            return new Dictionary<Product, int>();
        }

        string jsonString = File.ReadAllText(FileName);
        var entries = JsonSerializer.Deserialize<List<StockEntry>>(jsonString) ?? new List<StockEntry>();

        return entries.ToDictionary(
            e => new Product(e.Name, e.Price),
            e => e.Quantity
        );
    }
}
