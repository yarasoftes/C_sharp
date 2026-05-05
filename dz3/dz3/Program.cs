using System;

class Program
{
    static double Distance(double x1, double x2, double y1, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    static int SumOfDigits(int number)
    {
        number = Math.Abs(number);
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static int[] GenerateRandomArray(int size, int min, int max)
    {
        Random rand = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(min, max + 1);
        }
        return array;
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Расстояние между точками");
            Console.WriteLine("2 - Сумма цифр числа");
            Console.WriteLine("3 - Генератор массива случайных чисел");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            switch (choice)
            {
                case "1":
                    Console.Write("Введите x1: ");
                    double x1 = double.Parse(Console.ReadLine());
                    Console.Write("Введите x2: ");
                    double x2 = double.Parse(Console.ReadLine());
                    Console.Write("Введите y1: ");
                    double y1 = double.Parse(Console.ReadLine());
                    Console.Write("Введите y2: ");
                    double y2 = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Расстояние между точками: {Distance(x1, x2, y1, y2)}");
                    break;

                case "2":
                    Console.Write("Введите число: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Сумма цифр числа {num}: {SumOfDigits(num)}");
                    break;

                case "3":
                    Console.Write("Введите количество ячеек массива: ");
                    int size = int.Parse(Console.ReadLine());
                    Console.Write("Введите минимальное значение: ");
                    int minVal = int.Parse(Console.ReadLine());
                    Console.Write("Введите максимальное значение: ");
                    int maxVal = int.Parse(Console.ReadLine());

                    int[] randomArray = GenerateRandomArray(size, minVal, maxVal);
                    Console.WriteLine("Сгенерированный массив: " + string.Join(", ", randomArray));
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}