namespace HomeWork_6_Prokopenko_Olexiy;

public class Flats
{// Не побачила роботи з культурою при визначенні дат, що дозволило б виводити назву місяця, зручну для користувача.
    public List<FlatInfo> FlatInfos { get; set; }
    public int Quarter { get; set; }
    public int FlatCount { get; set; }
    public Flats(string path)
    {
        FlatInfos = new List<FlatInfo>();
        try
        {
            using var reader = new StreamReader(path);
            var firstLine = reader.ReadLine();
            ValidFirstLine(firstLine);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                FlatInfos.Add(DeserializeFlatInfo(line));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
    }
    public void PrintFlatInfo(int number)
    {
        var flatInfo = FlatInfos.FirstOrDefault(info => info.Number == number);
        if (flatInfo == null)
            throw new ArgumentException();
        Console.WriteLine(flatInfo);
    }

    public void PrintAllFlatsInFile(string path)
    {
        try
        {
            using var writer = new StreamWriter(File.Create(path));
            FlatInfos.ForEach(info => writer.WriteLine(info.ToString()));
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public void PrintNonElectricFlat()
    {
        var flatInfo = FlatInfos.FirstOrDefault(info => info.CounterInfo.ContainsValue(0));
        if (flatInfo == null)
        {
            Console.WriteLine("All flats use electric");
        }
        Console.WriteLine(flatInfo);
    }

    private void ValidFirstLine(string line)
    {
        if (line == null)
        {
            throw new ArgumentNullException();
        }
        if (!int.TryParse(line.Split(" ")[0], out var flatCount)) throw new ArgumentException(nameof(FlatCount));
        if (flatCount < 0)
        {
            throw new ArgumentException(nameof(FlatCount));
        }
        if (!int.TryParse(line.Split(" ")[1], out var quarter)) throw new ArgumentException(nameof(Quarter));
        if (quarter is < 1 or > 4)
        {
            throw new ArgumentException(nameof(Quarter));
        }
        FlatCount = flatCount;
        Quarter = quarter;
    }

    private FlatInfo DeserializeFlatInfo(string line)
    {
        var aboutFlat =  line.Split("||")[0];
        var counterInfo = line.Split("||")[1];
        int.TryParse(aboutFlat.Split("|")[0], out var flatNumber);
        var address = aboutFlat.Split("|")[1];
        var owner = aboutFlat.Split("|")[2];
        var flatInfo = new FlatInfo(owner, address, flatNumber);
        var indexes = counterInfo.Split("|");
        foreach (var index in indexes)
        {
            if (!double.TryParse(index.Split(" ")[1], out var countKilowatts))
                throw new ArgumentException();
            if (!DateOnly.TryParseExact(index.Split(" ")[0], "dd.mm", out var date))
                throw new ArgumentException();
            flatInfo.PassCountKilowatts(date, countKilowatts);
        }

        return flatInfo;
    }
}
