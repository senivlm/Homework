namespace Homework_1_Prokopenko;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Weight { get; set; }

    public Product(string name, decimal price, double weight) =>
        (Name, Price, Weight) = (name, price, weight);
    
    public override string ToString()
    {
        return $"Name: {Name} price: {Price}, weight: {Weight}";
    }
}