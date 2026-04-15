namespace FantasticVendingMachine.Models;

public class Inventory
{
    public Dictionary<Product, int> Stock { get; set; } = new();

    public void AddProduct(Product product, int quantity)
    {
        if (Stock.ContainsKey(product))
        {
            Stock[product] += quantity;
        }
        else
        {
            Stock[product] = quantity;
        }
    }

    public Product? GetProductByName(string name)
    {
        return Stock.Keys.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void ReduceStock(Product product)
    {
        if (Stock.ContainsKey(product) && Stock[product] > 0)
        {
            Stock[product]--;
        }
    }

    public List<Product> GetAllProducts()
    {
        return Stock.Keys.ToList();
    }

    public bool Restock(int quantity = 5)
    {
        if (Stock.Values.All(q => q >= quantity))
            return false;

        foreach (var product in Stock.Keys.ToList())
        {
            Stock[product] = quantity;
        }
        return true;
    }

    
}