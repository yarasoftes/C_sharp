using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class Products
{
    private List<Product> productList;

    public Products()
    {
        productList = new List<Product>
        {
            new Product("Яблоко", 1.5m),
            new Product("Банан", 0.8m),
            new Product("Апельсин", 1.2m),
            new Product("Молоко", 2.5m),
            new Product("Хлеб", 1.8m),
            new Product("Сыр", 3.2m),
            new Product("Колбаса", 4.5m)
        };
    }

    public List<Product> GetAllProducts()
    {
        return productList;
    }

    public Product GetProductByName(string name)
    {
        return productList.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayProducts()
    {
        Console.WriteLine("\nДоступные товары:");
        for (int i = 0; i < productList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productList[i].Name} - {productList[i].Price} руб.");
        }
    }
}

public class Cart
{
    private List<Product> items;

    public Cart()
    {
        items = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product != null)
        {
            items.Add(product);
            Console.WriteLine($"{product.Name} добавлен в корзину.");
        }
    }

    public void RemoveProduct(string productName)
    {
        Product product = items.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            items.Remove(product);
            Console.WriteLine($"{productName} удален из корзины.");
        }
        else
        {
            Console.WriteLine($"{productName} не найден в корзине.");
        }
    }

    public decimal GetTotal()
    {
        return items.Sum(p => p.Price);
    }

    public void DisplayCart()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Корзина пуста.");
            return;
        }

        Console.WriteLine("\nВаша корзина:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} - {item.Price} руб.");
        }
        Console.WriteLine($"Итого: {GetTotal()} руб.");
    }

    public List<Product> GetItems()
    {
        return items;
    }

    public void ClearCart()
    {
        items.Clear();
    }
}

public class Balance
{
    public decimal Amount { get; private set; }

    public Balance(decimal initialBalance)
    {
        Amount = initialBalance;
    }

    public bool CanAfford(decimal amount)
    {
        return Amount >= amount;
    }

    public void Deduct(decimal amount)
    {
        if (CanAfford(amount))
        {
            Amount -= amount;
            Console.WriteLine($"Оплата прошла успешно! Остаток на счете: {Amount} руб.");
        }
        else
        {
            Console.WriteLine($"Недостаточно средств. Не хватает {amount - Amount} руб.");
        }
    }

    public void AddFunds(decimal amount)
    {
        Amount += amount;
        Console.WriteLine($"Добавлено {amount} руб. Новый баланс: {Amount} руб.");
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Текущий баланс: {Amount} руб.");
    }
}

public class Store
{
    private Products products;
    private Cart cart;
    private Balance balance;

    public Store(decimal initialBalance)
    {
        products = new Products();
        cart = new Cart();
        balance = new Balance(initialBalance);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== МАГАЗИН ===");
            Console.WriteLine("1. Посмотреть товары");
            Console.WriteLine("2. Добавить товар в корзину");
            Console.WriteLine("3. Удалить товар из корзины");
            Console.WriteLine("4. Посмотреть корзину");
            Console.WriteLine("5. Оплатить");
            Console.WriteLine("6. Пополнить баланс");
            Console.WriteLine("7. Проверить баланс");
            Console.WriteLine("8. Выйти");
            Console.Write("Выберите опцию: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    products.DisplayProducts();
                    break;
                case "2":
                    Console.Write("Введите название товара: ");
                    string name = Console.ReadLine();
                    Product product = products.GetProductByName(name);
                    if (product != null)
                    {
                        cart.AddProduct(product);
                    }
                    else
                    {
                        Console.WriteLine("Товар не найден.");
                    }
                    break;
                case "3":
                    Console.Write("Введите название товара для удаления: ");
                    string removeName = Console.ReadLine();
                    cart.RemoveProduct(removeName);
                    break;
                case "4":
                    cart.DisplayCart();
                    break;
                case "5":
                    decimal total = cart.GetTotal();
                    if (total == 0)
                    {
                        Console.WriteLine("Корзина пуста. Нечего оплачивать.");
                        break;
                    }
                    Console.WriteLine($"Сумма к оплате: {total} руб.");
                    if (balance.CanAfford(total))
                    {
                        balance.Deduct(total);
                        cart.ClearCart();
                        Console.WriteLine("Покупка завершена!");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Пополните баланс.");
                    }
                    break;
                case "6":
                    Console.Write("Введите сумму для пополнения: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        balance.AddFunds(amount);
                    }
                    else
                    {
                        Console.WriteLine("Неверная сумма.");
                    }
                    break;
                case "7":
                    balance.DisplayBalance();
                    break;
                case "8":
                    Console.WriteLine("Спасибо за покупку!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Store store = new Store(100.0m);
        store.Run();
    }
}