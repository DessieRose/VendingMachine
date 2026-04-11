namespace FantasticVendingMachine.Models;

public class Product
{
    // Properties: These represent the "data" of a product
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Constructor: This allows you to create a product easily, e.g., new Product("Cola", 1.50m)
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    // A helper method to make it easy to print the product details later
    public override string ToString()
    {
        return $"{Name} - {Price:C}"; // :C formats the number as Currency (e.g., $1.50)
    }
}