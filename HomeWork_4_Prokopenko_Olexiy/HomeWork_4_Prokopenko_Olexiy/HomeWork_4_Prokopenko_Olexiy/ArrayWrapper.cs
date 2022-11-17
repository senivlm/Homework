namespace HomeWork_3_Prokopenko_Olexiy;

public class ArrayWrapper
{// Не побачила знаходження 2 найдовших послідовностей.
    private int[] _arr;
    public ArrayWrapper(int min, int max)
    {// 10 винести в параметри методу size
        _arr = new int[10];
        var rnd = new Random();
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] = rnd.Next(min, max);
        }
    }
    private bool IsSimple(int num)
    {// Можна скоротити кількість операцій
        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
    // треба не просто знайти різні, а й порахувати частоту їх появи. І друкувати не тут.
    public void PrintDistinct()
    {
        foreach (var i in _arr.Distinct())
        {
            Console.Write($"{i}  ");
        }

        Console.WriteLine();
    }
    public int this[int index]
    {
        get
        {
            if (_arr.Length >= index && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _arr[index];
        }
        set
        {
            if (_arr.Length >= index && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _arr[index] = value;
        }
    }
}
