using System;

public class TRTriangle
{
    // Поле для зберігання довжини сторін трикутника
    private double sideLength;

    // Конструктор без параметрів (за замовчуванням)
    public TRTriangle()
    {
        sideLength = 1.0; // стандартне значення
    }

    // Конструктор з параметрами
    public TRTriangle(double sideLength)
    {
        this.sideLength = sideLength;
    }

    // Конструктор копіювання
    public TRTriangle(TRTriangle otherTriangle)
    {
        this.sideLength = otherTriangle.sideLength;
    }

    // Метод введення/виведення даних
    public void SetSideLength(double sideLength)
    {
        this.sideLength = sideLength;
    }

    public double GetSideLength()
    {
        return sideLength;
    }

    // Метод визначення площі
    public double CalculateArea()
    {
        return (Math.Sqrt(3) / 4) * Math.Pow(sideLength, 2);
    }

    // Метод визначення периметру
    public double CalculatePerimeter()
    {
        return 3 * sideLength;
    }

    // Порівняння з іншим трикутником
    public bool IsEqualTo(TRTriangle otherTriangle)
    {
        return this.sideLength == otherTriangle.sideLength;
    }

    // Перевантаження операторів + (додавання довжин сторін)
    public static TRTriangle operator +(TRTriangle t1, TRTriangle t2)
    {
        return new TRTriangle(t1.sideLength + t2.sideLength);
    }

    // Перевантаження оператора - (віднімання довжин сторін)
    public static TRTriangle operator -(TRTriangle t1, TRTriangle t2)
    {
        return new TRTriangle(Math.Max(t1.sideLength - t2.sideLength, 0));
    }

    // Перевантаження оператора * (множення сторони на число)
    public static TRTriangle operator *(TRTriangle t, double multiplier)
    {
        return new TRTriangle(t.sideLength * multiplier);
    }

    // Виведення інформації про трикутник
    public void PrintInfo()
    {
        Console.WriteLine($"Сторона трикутника: {sideLength}");
        Console.WriteLine($"Периметр: {CalculatePerimeter()}");
        Console.WriteLine($"Площа: {CalculateArea()}");
    }

    // Метод для введення даних від користувача
    public void InputFromConsole()
    {
        bool isValid = false;
        double input;

        do
        {
            Console.Write("Введiть довжину сторони трикутника: ");
            if (double.TryParse(Console.ReadLine(), out input) && input > 0)
            {
                SetSideLength(input);
                isValid = true;
            }
            else
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            }
        } while (!isValid);
    }
}

public class Program
{
    public static void Main()
    {
        // Тестування класу TRTriangle з введенням даних від користувача

        // Створення трикутника і введення даних через консоль
        TRTriangle triangle1 = new TRTriangle();
        Console.WriteLine("Трикутник 1:");
        triangle1.InputFromConsole();
        triangle1.PrintInfo();

        // Створення другого трикутника
        TRTriangle triangle2 = new TRTriangle();
        Console.WriteLine("\nТрикутник 2:");
        triangle2.InputFromConsole();
        triangle2.PrintInfo();

        // Операції над трикутниками
        TRTriangle triangleSum = triangle1 + triangle2;
        Console.WriteLine("\nРезультат додавання трикутникiв 1 i 2:");
        triangleSum.PrintInfo();

        TRTriangle triangleDiff = triangle1 - triangle2;
        Console.WriteLine("\nРезультат вiднiмання трикутника 2 вiд трикутника 1:");
        triangleDiff.PrintInfo();

        TRTriangle triangleMult = triangle1 * 2;
        Console.WriteLine("\nРезультат множення трикутника 1 на 2:");
        triangleMult.PrintInfo();

        // Порівняння трикутників
        Console.WriteLine($"\nТрикутник 1 дорiвнює трикутнику 2: {triangle1.IsEqualTo(triangle2)}");
    }
}
