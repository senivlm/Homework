using System.Text;

namespace Homework_1_Prokopenko;

public class Buy
{// Тут не добре. порушується інкапсуляція
    public Dictionary<Product, int> Products { get; }

    public Buy()
    {
        Products = new Dictionary<Product, int>();
    }
    
    public decimal GetAmount()
    {
        return Products.Sum(p => p.Key.Price * p.Value);
    }
    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        foreach (var (product, count) in Products)
        {
            str.Append($"{product.ToString()}, count: {count}\n");
        }
        str.Append($"=======Total: {GetAmount()}=======");
        return str.ToString();
    }
}
