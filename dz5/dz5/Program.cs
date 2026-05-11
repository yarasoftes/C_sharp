using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            {3, 1, 4},
            {1, 5, 9},
            {2, 6, 5}
        };

        double product = MultiplyAllElements(matrix);
        Console.WriteLine($"1. Product of all elements: {product}");

        int[,] sortedMatrix = Sort2DArray(matrix);
        Console.WriteLine("2. Sorted 2D array:");
        PrintMatrix(sortedMatrix);

        int diagonalSum = SumMainDiagonal(matrix);
        Console.WriteLine($"3. Sum of main diagonal: {diagonalSum}");
    }

    static double MultiplyAllElements(int[,] arr)
    {
        double product = 1;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                product *= arr[i, j];
            }
        }
        return product;
    }

    static int[,] Sort2DArray(int[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        int[] flat = new int[rows * cols];

        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flat[index++] = arr[i, j];
            }
        }

        Array.Sort(flat);

        int[,] result = new int[rows, cols];
        index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = flat[index++];
            }
        }
        return result;
    }

    static int SumMainDiagonal(int[,] arr)
    {
        int sum = 0;
        int size = Math.Min(arr.GetLength(0), arr.GetLength(1));
        for (int i = 0; i < size; i++)
        {
            sum += arr[i, i];
        }
        return sum;
    }

    static void PrintMatrix(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}