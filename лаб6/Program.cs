using System.Text.RegularExpressions;
using лаб6;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1. Работа с котами");
            Console.WriteLine("2. Работа с дробями");
            Console.WriteLine("3. Выход");
            Console.Write("Введите номер задачи: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleCats();
                    break;
                case "2":
                    HandleFractions();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    private static bool IsValidCatName(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$");
    }

    private static void HandleCats()
    {
        List<Cat> cats = new List<Cat>();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать нового кота");
            Console.WriteLine("2. Заставить кота мяукать");
            Console.WriteLine("3. Показать количество мяуканий");
            Console.WriteLine("4. Вернуться в главное меню");
            Console.Write("Введите номер действия: ");
            string action = Console.ReadLine();


            switch (action)
            {
                case "1":
                    Console.Write("Введите имя кота: ");
                    string catName = Console.ReadLine();
                    if (IsValidCatName(catName))
                    {
                        cats.Add(new Cat(catName));
                    }
                    else
                    {
                        Console.WriteLine("Имя кота должно состоять только из букв.");
                    }
                    break;
                case "2":
                    if (cats.Count == 0)
                    {
                        Console.WriteLine("Сначала создайте кота.");
                    }
                    else
                    {
                        Console.WriteLine("Список всех котов:");
                        foreach (var cat in cats)
                        {
                            Console.WriteLine(cat.Name);
                        }
                        Console.Write("Введите имя кота: ");
                        string meowCatName = Console.ReadLine();
                        if (IsValidCatName(meowCatName))
                        {
                            Cat meowCat = cats.FirstOrDefault(c => c.Name == meowCatName);
                            if (meowCat != null)
                            {
                                Console.Write("Введите количество мяуканий: ");
                                int meowCount = int.Parse(Console.ReadLine());
                                if (meowCount <= 0)
                                    Console.WriteLine("Количество раз для мяуканья должно быть больше нуля.");
                                else if (meowCount > 1)
                                { meowCat.Meow(meowCount); }
                                else meowCat.Meow();
                            }
                            else
                            {
                                Console.WriteLine("Кот с таким именем не найден.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Имя кота должно состоять только из букв.");
                        }
                    }
                    break;
                case "3":
                    if (cats.Count == 0)
                    {
                        Console.WriteLine("Сначала создайте кота.");
                    }
                    else
                    {
                        Console.WriteLine("Список всех котов:");
                        foreach (var cat in cats)
                        {
                            Console.WriteLine(cat.Name);
                        }
                        Console.Write("Введите имя кота: ");
                        string countCatName = Console.ReadLine();
                        if (IsValidCatName(countCatName))
                        {
                            Cat CountCat = cats.FirstOrDefault(c => c.Name == countCatName);
                            if (CountCat != null)
                            {
                                Console.WriteLine($"{CountCat.Name} мяукал {CountCat.GetMeowCount()} раз.");
                            }
                            else
                            {
                                Console.WriteLine("Кот с таким именем не найден.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Имя кота должно состоять только из букв.");
                        }
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    private static Fraction CreateFraction(string ordinal)
    {
        int numerator, denominator;
        while (true)
        {
            Console.Write($"Введите числитель {ordinal} дроби: ");
            if (int.TryParse(Console.ReadLine(), out numerator))
            {
                break;
            }
            else
            {
                Console.WriteLine("Числитель должен быть целым числом.");
            }
        }

        while (true)
        {
            Console.Write($"Введите знаменатель {ordinal} дроби: ");
            if (int.TryParse(Console.ReadLine(), out denominator) && denominator > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Знаменатель должен быть положительным целым числом.");
            }
        }

        return new Fraction(numerator, denominator);
    }

    private static void HandleFractions()
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать дроби и выполнить операции");
            Console.WriteLine("2. Сравнить две дроби");
            Console.WriteLine("3. Вернуться в главное меню");
            Console.Write("Введите номер действия: ");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    Fraction f1 = CreateFraction("первой");
                    Fraction f2 = CreateFraction("второй");
                    Fraction f3 = CreateFraction("третьей");

                    Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
                    Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
                    Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
                    Console.WriteLine($"{f1} / {f2} = {f1 / f2}");

                    Console.WriteLine($"{f1} + 5 = {f1 + 5}");
                    Console.WriteLine($"{f1} - 5 = {f1 - 5}");
                    Console.WriteLine($"{f1} * 5 = {f1 * 5}");
                    Console.WriteLine($"{f1} / 5 = {f1 / 5}");

                    Fraction result = f1 + f2 / f3 - 5;
                    Console.WriteLine($"{f1} + {f2} / {f3} - 5 = {result}");

                    // Тестирование клонирования
                    Fraction clonedFraction = (Fraction)f1.Clone();
                    Console.WriteLine($"Клонирование дроби f1: {clonedFraction}");

                    // Тестирование кэшированной дроби
                    CachedFraction cachedFraction = new CachedFraction(f1.Numerator, f1.Denominator);
                    Console.WriteLine($"Получение вещеественного числа f1: {cachedFraction.GetRealValue()}");
                    break;
                case "2":
                    Fraction fraction1 = CreateFraction("первой");
                    Fraction fraction2 = CreateFraction("второй");

                    int comparisonResult = fraction1.CompareTo(fraction2);
                    if (comparisonResult == 0)
                    {
                        Console.WriteLine($"{fraction1} равно {fraction2}");
                    }
                    else if (comparisonResult > 0)
                    {
                        Console.WriteLine($"{fraction1} больше {fraction2}");
                    }
                    else
                    {
                        Console.WriteLine($"{fraction1} меньше {fraction2}");
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}