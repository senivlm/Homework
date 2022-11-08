namespace HomeWork_2_Prokopenko_Olexiy;

public class Matrix
{
   // При такому проєктуванню метод мав би буи статичним. Чому не ООП?
    public int[,] VerticalSnake(int n, int m)
    {
        var matrix = new int[n, m];
        var number = 1;
        var positiveDirection = true;
        for (int j = 0; j < m; j++)
        {// лишні умови
            if (positiveDirection)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, j] = number++;
                }
            }
            else
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    matrix[i, j] = number++;
                }
            }

            positiveDirection = !positiveDirection;
        }
        return matrix;
    }

    public int[,] DiagonalSnake(int size)
    {
        var matrix = new int[size,size];
        var number = 1;
        for (int diff = 1 - size; diff <= size - 1; diff++)
        {
            for (int i = 0; i < size; i++)
            {
                int j = i - diff;
                if (j < 0 || j >= size)
                    continue;
                if (((diff+size+1)&1) > 0)    
                    matrix[i, size-1-j] = number++;
                else
                    matrix[size-1-j, i] = number++;
            }
        }
        return matrix;
    }

    public int[,] SpiralSnake(int n, int m)
    {
        int val = 1;
        int[,] matrix = new int[n, m];
        int k = 0, l = 0;
        while (k < m && l < n) {
            for (int i = l; i < n; ++i) {
                matrix[k,i] = val++;
            }
  
            k++;
            
            for (int i = k; i < m; ++i) {
                matrix[i,n - 1] = val++;
            }
            n--;
            
            if (k < m) {
                for (int i = n - 1; i >= l; --i) {
                    matrix[m - 1,i] = val++;
                }
                m--;
            }
            if (l < n) {
                for (int i = m - 1; i >= k; --i) {
                    matrix[i,l] = val++;
                }
                l++;
            }
        }

        return matrix;
    }
//краще ToString
    public void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i,j] + " ");
            Console.WriteLine();
        }
    }
}
