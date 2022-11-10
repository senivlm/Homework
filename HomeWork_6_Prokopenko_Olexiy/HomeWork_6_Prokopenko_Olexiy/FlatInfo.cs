using System.Text;

namespace HomeWork_6_Prokopenko_Olexiy;

public class FlatInfo
{
    public string Owner { get; }
    public int Number { get; }
    public string Address { get; }
    //               date      number of kilowatts
    public Dictionary<DateOnly, double> CounterInfo { get; }

    public FlatInfo(string owner, string address, int number)
    {
        Owner = owner;
        Number = number;
        Address = address;
        CounterInfo = new Dictionary<DateOnly, double>();
    }

    public override string ToString()
    {
        var counterInfoBuilder = new StringBuilder();
        foreach (var pair in CounterInfo)
        {
            counterInfoBuilder.Append(pair.Key.ToString("D")).Append(' ').Append(pair.Value).Append(' ');
        }
        return $"{Number.ToString(), -3} {Owner, -10} {counterInfoBuilder}";
    }
    
    public void PassCountKilowatts(DateOnly date, double count)
    {
        CounterInfo.Add(date, count);
    }
}