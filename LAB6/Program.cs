using System;

class TCIRCLE<T>
{
    public T radius;
    public Tuple<T, T> center;

    public TCIRCLE()
    {
        radius = default(T);
        center = new Tuple<T, T>(default(T), default(T));
    }

    public TCIRCLE(T radius, Tuple<T, T> center)
    {
        this.radius = radius;
        this.center = center;
    }

    // Конструктор копіювання
    public TCIRCLE(TCIRCLE<T> circle)
    {
        this.radius = circle.radius;
        this.center = circle.center;
    }

    // Введення даних
    public void InputData()
    {
        Console.Write("Введіть радіус круга: ");
        radius = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        Console.Write("Введіть координату X центру кола: ");
        T x = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        Console.Write("Введіть координату Y центру кола: ");
        T y = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        center = new Tuple<T, T>(x, y);
    }

    // Виведення даних
    public void Display()
    {
        Console.WriteLine($"Радіус: {radius}, Центр: {center}");
    }

    // Перевірка належності точки колу
    public bool IsPointInside(Tuple<T, T> point)
    {
        double distance = Math.Sqrt(Math.Pow(Convert.ToDouble(point.Item1) - Convert.ToDouble(center.Item1), 2) + Math.Pow(Convert.ToDouble(point.Item2) - Convert.ToDouble(center.Item2), 2));
        return distance <= Convert.ToDouble(radius);
    }

    // Перевантаження операторів
    public static T operator +(TCIRCLE<T> circle1, TCIRCLE<T> circle2)
    {
        return (T)Convert.ChangeType(Convert.ToDouble(circle1.radius) + Convert.ToDouble(circle2.radius), typeof(T));
    }

    public static T operator -(TCIRCLE<T> circle1, TCIRCLE<T> circle2)
    {
        return (T)Convert.ChangeType(Convert.ToDouble(circle1.radius) - Convert.ToDouble(circle2.radius), typeof(T));
    }

    public static T operator *(TCIRCLE<T> circle, double num)
    {
        return (T)Convert.ChangeType(Convert.ToDouble(circle.radius) * num, typeof(T));
    }
}

class TBALL<T> : TCIRCLE<T>
{
    public TBALL(T radius, Tuple<T, T> center) : base(radius, center) { }

    public double Volume()
    {
        return (4 / 3) * 3.14159 * (Math.Pow(Convert.ToDouble(radius), 3));
    }
}

// Програма клієнт для тестування
class Program
{
    static void Main()
    {
        TCIRCLE<double> circle = new TCIRCLE<double>(5, new Tuple<double, double>(0, 0));
        circle.Display(); // Виведення даних
        Console.WriteLine("Точка (1, 2) належить кругу: " + circle.IsPointInside(new Tuple<double, double>(1, 2))); // Перевірка належності точки колу
        Console.WriteLine("Додавання радіусів: " + (circle + new TCIRCLE<double>(3, new Tuple<double, double>(0, 0)))); // Перевантаження оператора +
        Console.WriteLine("Множення радіуса на число: " + circle * 2); // Перевантаження оператора *

        TBALL<double> ball = new TBALL<double>(5, new Tuple<double, double>(0, 0));
        Console.WriteLine("Об'єм кулі: " + ball.Volume()); // Метод для знаходження об'єму кулі
    }
}
