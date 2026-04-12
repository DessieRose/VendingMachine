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

    
}