using HomeWork_3_Prokopenko_Olexiy.Enums;

namespace HomeWork_3_Prokopenko_Olexiy;

public class Meat : Product
{
    public MeetCategories Category { get; }
    public MeetKinds Kind { get; }

    public Meat(string name, decimal price, double weight, MeetCategories category, MeetKinds kind)
        : base(name, price, weight)
        => (Category, Kind) = (category, kind);

    public override void ChangePrice(int countPercent)
    {
        countPercent += 10 * (int)Category;
        base.ChangePrice(countPercent);
    }
    
    public override string ToString()
    {
        return base.ToString() + $", category: {Category}, kind: {Kind}";
    }
    public override bool Equals(object? obj)
    {
        var meat = obj as Meat;
        if (meat == null)
        {
            return false;
        }

        return Name.Equals(meat.Name) && Price.Equals(meat.Price) 
                                      && Weight.Equals(meat.Weight)
                                      && Category.Equals(meat.Category)
                                      && Kind.Equals(meat.Kind);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}