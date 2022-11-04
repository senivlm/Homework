using System.Collections;
using System.Runtime.Serialization.Formatters;

namespace HomeWork_3_Prokopenko_Olexiy;

public class Storage
{
    public List<Product> Products { get; set; }

    public void PrintAllProduct()
        => Products.ForEach(product => Console.WriteLine(product.ToString()));

    public Storage(IEnumerable<Product> products) => Products = products.ToList();
    public void ChangePrice(int countPercent)
    {
        Products.ForEach(product => product.ChangePrice(countPercent));
    }

    public void FindAllMeat()
    {
        Products
            .Where(product => product.GetType() == typeof(Meat))
            .ToList()
            .ForEach(product => Console.WriteLine(product.ToString()));
    }

    public void Sort(IComparer? comparer = null)
    {
        if (comparer is IComparer<Product> comparer1)
        {
            Products.Sort(comparer1);
            return;
        }
        Products.Sort();
    }
    public Product this[int index]
    {
        get => Products[index] ?? throw new IndexOutOfRangeException();
        set
        {
            if (index >= Products.Count)
                throw new IndexOutOfRangeException();
            Products[index] = value;
        }
    }
    public override bool Equals(object? obj)
    {
        var storage = obj as Storage;
        if (storage == null)
        {
            return false;
        }

        return Products.Equals(storage.Products);
    }

    public override int GetHashCode()
    {
        return Products.GetHashCode();
    }
}