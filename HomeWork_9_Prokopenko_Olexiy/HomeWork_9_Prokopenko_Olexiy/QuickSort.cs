namespace HomeWork_9_Prokopenko_Olexiy;

public static class QuickSort
{
    static void Swap(ref int x, ref int y)
    {
        (x, y) = (y, x);
    }
    static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }
    
    static int[] Sort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        Sort(array, minIndex, pivotIndex - 1);
        Sort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    static int[] Sort(int[] array)
    {
        return Sort(array, 0, array.Length - 1);
    }

    public static void StartSortRandomArr()
    {
        var rnd = new Random();
        var arr = new int[rnd.Next(30, 50)];
        for (var i = 0; i < arr.Length; ++i)
        {
            arr[i] = rnd.Next(0, 10000);
        }

        Console.WriteLine("Input: {0}", string.Join(", ", arr));
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Result: {0}", string.Join(", ", Sort(arr)));
    }
}