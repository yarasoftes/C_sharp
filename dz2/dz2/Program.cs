using System;
using System.Collections.Generic;
using System.Linq;

namespace StringAndArrayTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1. Шифр Цезаря для массива строк");
                Console.WriteLine("2. Сортировка массива строк по количеству гласных");
                Console.WriteLine("3. Сортировка численного массива по частоте дубликатов");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите задание (0-3): ");

                string choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Task1_CaesarCipher();
                        break;
                    case "2":
                        Task2_SortByVowels();
                        break;
                    case "3":
                        Task3_SortByDuplicateFrequency();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Task1_CaesarCipher()
        {
            Console.Clear();
            Console.WriteLine("=== ЗАДАНИЕ 1: ШИФР ЦЕЗАРЯ ===\n");

            string[] strings = GetStringArrayFromUser();

            if (strings.Length == 0)
            {
                Console.WriteLine("Массив пуст. Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.Write("\nВведите сдвиг (целое число, может быть отрицательным): ");
            if (!int.TryParse(Console.ReadLine(), out int shift))
            {
                Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nВыберите режим:");
            Console.WriteLine("1. Зашифровать");
            Console.WriteLine("2. Расшифровать");
            Console.Write("Ваш выбор: ");
            string mode = Console.ReadLine();

            if (mode == "2") shift = -shift;

            string[] result = new string[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                result[i] = CaesarCipher(strings[i], shift);
            }

            Console.WriteLine("\n=== РЕЗУЛЬТАТ ===");
            Console.WriteLine("Исходный массив: " + string.Join(", ", strings));
            Console.WriteLine($"Результат (сдвиг {(mode == "2" ? -shift : shift)}): " + string.Join(", ", result));

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static string CaesarCipher(string input, int shift)
        {
            shift = shift % 26;
            char[] result = input.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                {
                    char offset = char.IsUpper(result[i]) ? 'A' : 'a';
                    result[i] = (char)(((result[i] - offset + shift + 26) % 26) + offset);
                }
            }

            return new string(result);
        }

        static void Task2_SortByVowels()
        {
            Console.Clear();
            Console.WriteLine("=== ЗАДАНИЕ 2: СОРТИРОВКА ПО ГЛАСНЫМ ===\n");

            string[] strings = GetStringArrayFromUser();

            if (strings.Length == 0)
            {
                Console.WriteLine("Массив пуст. Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nВыберите направление сортировки:");
            Console.WriteLine("1. По возрастанию (меньше гласных -> больше гласных)");
            Console.WriteLine("2. По убыванию (больше гласных -> меньше гласных)");
            Console.Write("Ваш выбор: ");
            string direction = Console.ReadLine();

            var sorted = strings
                .Select(s => new { Str = s, VowelCount = CountVowels(s) })
                .OrderBy(x => direction == "2" ? -x.VowelCount : x.VowelCount)
                .Select(x => x.Str)
                .ToArray();

            Console.WriteLine("\n=== РЕЗУЛЬТАТ ===");
            Console.WriteLine("Исходный массив: " + string.Join(", ", strings));
            Console.WriteLine("\nПодробная статистика по гласным:");
            foreach (var s in strings)
            {
                Console.WriteLine($"  \"{s}\" -> {CountVowels(s)} гласных");
            }

            Console.WriteLine($"\nОтсортированный массив ({(direction == "2" ? "убывание" : "возрастание")}):");
            Console.WriteLine(string.Join(", ", sorted));

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static int CountVowels(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                              'a', 'e', 'i', 'o', 'u', 'y' };

            return str.ToLower().Count(c => vowels.Contains(c));
        }

        static void Task3_SortByDuplicateFrequency()
        {
            Console.Clear();
            Console.WriteLine("=== ЗАДАНИЕ 3: СОРТИРОВКА ПО ЧАСТОТЕ ДУБЛИКАТОВ ===\n");

            int[] numbers = GetIntArrayFromUser();

            if (numbers.Length == 0)
            {
                Console.WriteLine("Массив пуст. Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nВыберите направление сортировки:");
            Console.WriteLine("1. По возрастанию частоты (редкие -> частые)");
            Console.WriteLine("2. По убыванию частоты (частые -> редкие)");
            Console.Write("Ваш выбор: ");
            string direction = Console.ReadLine();

            var frequency = numbers
                .GroupBy(n => n)
                .ToDictionary(g => g.Key, g => g.Count());

            var sorted = direction == "2"
                ? numbers.OrderByDescending(n => frequency[n]).ThenBy(n => n).ToArray()
                : numbers.OrderBy(n => frequency[n]).ThenBy(n => n).ToArray();

            Console.WriteLine("\n=== РЕЗУЛЬТАТ ===");
            Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));

            Console.WriteLine("\nСтатистика частоты:");
            foreach (var kvp in frequency.OrderBy(kvp => kvp.Value))
            {
                Console.WriteLine($"  Число {kvp.Key} встречается {kvp.Value} раз(а)");
            }

            Console.WriteLine($"\nОтсортированный массив ({(direction == "2" ? "убывание" : "возрастание")} частоты):");
            Console.WriteLine(string.Join(", ", sorted));

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static string[] GetStringArrayFromUser()
        {
            Console.WriteLine("Введите строки для массива (разделитель - запятая):");
            Console.Write("Пример: яблоко,банан,вишня,арбуз\n> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return new string[0];

            return input.Split(',')
                        .Select(s => s.Trim())
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToArray();
        }

        static int[] GetIntArrayFromUser()
        {
            Console.WriteLine("Введите числа для массива (разделитель - запятая):");
            Console.Write("Пример: 5,3,8,3,9,1,5,5\n> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return new int[0];

            var numbers = new List<int>();
            foreach (var token in input.Split(','))
            {
                if (int.TryParse(token.Trim(), out int num))
                    numbers.Add(num);
                else
                    Console.WriteLine($"Предупреждение: '{token}' не является числом и будет пропущен");
            }

            return numbers.ToArray();
        }
    }
}