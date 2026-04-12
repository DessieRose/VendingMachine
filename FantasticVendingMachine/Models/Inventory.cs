using System.Collections.Generic;

namespace FantasticVendingMachine.Models;

public class Inventory
{
    private List<Product> _products = new List<Product>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product? GetProductByName(string name)
    {
        return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}