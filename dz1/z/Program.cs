using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Выберите задание (1-4) =====");
            Console.WriteLine("1. Проверить, есть ли в строке буква 'a'");
            Console.WriteLine("2. Проверить, одинаковы ли две строки без учёта регистра");
            Console.WriteLine("3. Вывести строку по буквам (каждая буква с новой строки)");
            Console.WriteLine("4. Вывести каждый чётный символ из строки");
            Console.WriteLine("0. Выйти из программы");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1, 2, 3, 4 или 0.");
                    break;
            }
        }
    }

    static void Task1()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        if (input.Contains("a"))
        {
            Console.WriteLine("Результат: В строке есть буква 'a'");
        }
        else
        {
            Console.WriteLine("Результат: В строке нет буквы 'a'");
        }
    }

    static void Task2()
    {
        Console.Write("Введите первую строку: ");
        string str1 = Console.ReadLine();

        Console.Write("Введите вторую строку: ");
        string str2 = Console.ReadLine();

        bool areEqual = string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

        if (areEqual)
        {
            Console.WriteLine("Результат: Строки одинаковы (без учёта регистра)");
        }
        else
        {
            Console.WriteLine("Результат: Строки разные (даже без учёта регистра)");
        }
    }

    static void Task3()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        Console.WriteLine("Результат (каждая буква с новой строки):");
        foreach (char c in input)
        {
            Console.WriteLine(c);
        }
    }

    static void Task4()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        Console.WriteLine("Результат (каждый чётный символ):");
        for (int i = 1; i < input.Length; i += 2)
        {
            Console.Write(input[i]);
        }
        Console.WriteLine();
    }
}