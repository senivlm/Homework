namespace HomeWork_3_Prokopenko_Olexiy;

public class Dairy_products : Product
{
    public int ExpirationDay { get; set; }

    public Dairy_products(string name, decimal price, double weight, int expirationDay)
        : base(name, price, weight)
        => ExpirationDay = expirationDay;

    public override void ChangePrice(int countPercent)
    {
        countPercent += (10 - ExpirationDay) * 2;
        base.ChangePrice(countPercent);
    }

    public override string ToString()
    {
        return base.ToString() + $", expiration day: {ExpirationDay}";
    }
    public override bool Equals(object? obj)
    {
        var dairy = obj as Dairy_products;
        if (dairy == null)
        {
            return false;
        }

        return Name.Equals(dairy.Name) && Price.Equals(dairy.Price)
                                       && Weight.Equals(dairy.Weight)
                                       && ExpirationDay.Equals(dairy.ExpirationDay);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}