using System.Collections;

namespace HomeWork_3_Prokopenko_Olexiy;

public class Product : IComparable, IComparer
{
    public string Name { get; }
    public decimal Price { get; set; }
    public double Weight { get; }

    public Product(string name, decimal price, double weight) =>
        (Name, Price, Weight) = (name, price, weight);

    public virtual void ChangePrice(int countPercent)
    {
        Price -= (int)((double)Price * ((double)countPercent/100));
    }
    public override string ToString()
    {
        return $"Name: {Name} price: {Price}, weight: {Weight}";
    }

    public int Compare(object? x, object? y)
    {
        if (x is not Product product1 || y is not Product product2)
            throw new ArgumentException();
        return (int) (product1.Price - product2.Price);
    }

    public virtual int CompareTo(object? obj) //sort by price
    {
        if (obj is not Product product)
            throw new ArgumentException();
        return Price.CompareTo(product.Price);
    }

    public override bool Equals(object? obj)
    {
        var product = obj as Product;
        if (product == null)
        {
            return false;
        }

        return Name.Equals(product.Name) && Price.Equals(product.Price) && Weight.Equals(product.Weight);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}