namespace HomeWork_2_Prokopenko_Olexiy;

public class Task2
{
    public int[,] Matrix { get; }

    public Task2(int size)
    {
        Matrix = new int[size,size];
        var rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Matrix[i, j] = rnd.Next(5);
            }
        }
    }

    public void FindLine()
    {
        var index = 0;
        var maxLength = 0;
        var maxEl = 0;
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            var arr = new List<int>();
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                arr.Add(Matrix[i,j]);
            }

            var currLength = GetLength(arr.ToArray());
            if (currLength.Item1 > maxLength)
            {
                maxLength = currLength.Item1;
                index = i;
                maxEl = currLength.Item2;
            }
        }

        int startIndex, endIndex, currIndex;
        for (int i = 0; i < Matrix.GetLength(1); i++)
        {
            if (Matrix[index, i] == maxEl)
            {
                startIndex = i;
                currIndex = i;
                endIndex = i;
                while (Matrix[index, currIndex] == maxEl)
                {
                    endIndex++;
                    currIndex++;
                }

                HomeWork_2_Prokopenko_Olexiy.Matrix matrix = new Matrix();
                matrix.Print(Matrix);
                Console.WriteLine($"Max element value: {maxEl}, start: [{index},{startIndex}], end: [{index},{endIndex}], len: {endIndex - startIndex}");
                return;
            }
        }
        
    }

    public (int, int) GetLength(int[] arr)
    {
        int count = 1;
        int longestNum = arr[0];
        int longestCount = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i-1])
            {
                count = 0;
            }

            count++;
            // Have we just found a new longest sequence?
            if (count > longestCount)
            {
                longestCount = count;
                longestNum = arr[i];
            }
        }


        return (longestCount, longestNum);
    }
}