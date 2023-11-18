using System;

class TSMATRIX<T>
{
    public T[,] matrix;
    public int rows;
    public int columns;

    public TSMATRIX()
    {
        rows = 0;
        columns = 0;
        matrix = new T[rows, columns];
    }

    public TSMATRIX(T[,] elements)
    {
        rows = elements.GetLength(0);
        columns = elements.GetLength(1);
        matrix = elements;
    }

    public TSMATRIX(TSMATRIX<T> other)
    {
        rows = other.rows;
        columns = other.columns;
        matrix = other.matrix;
    }

    public void InputData()
    {
        Console.WriteLine("Введiть розмiрнiсть матрицi:");
        Console.Write("Рядки: ");
        rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Стовпцi: ");
        columns = Convert.ToInt32(Console.ReadLine());

        matrix = new T[rows, columns];

        Console.WriteLine("Введіть елементи матрицi:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Елемент [{i},{j}]: ");
                matrix[i, j] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            }
        }
    }

    public void Display()
    {
        Console.WriteLine("Матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public T FindMaxElement()
    {
        T max = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (Comparer<T>.Default.Compare(matrix[i, j], max) > 0)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }

    public T FindMinElement()
    {
        T min = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (Comparer<T>.Default.Compare(matrix[i, j], min) < 0)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }

    public dynamic CalculateSumOfElements()
    {
        dynamic sum = default(T);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }

    public static TSMATRIX<T> operator +(TSMATRIX<T> matrix1, TSMATRIX<T> matrix2)
    {
        T[,] result = new T[matrix1.rows, matrix1.columns];

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                dynamic value1 = matrix1.matrix[i, j];
                dynamic value2 = matrix2.matrix[i, j];
                result[i, j] = value1 + value2;
            }
        }

        return new TSMATRIX<T>(result);
    }

    public static TSMATRIX<T> operator -(TSMATRIX<T> matrix1, TSMATRIX<T> matrix2)
    {
        T[,] result = new T[matrix1.rows, matrix1.columns];

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                dynamic value1 = matrix1.matrix[i, j];
                dynamic value2 = matrix2.matrix[i, j];
                result[i, j] = value1 - value2;
            }
        }

        return new TSMATRIX<T>(result);
    }
}

class TDeterminant2 : TSMATRIX<int>
{
    public TDeterminant2(int[,] elements) : base(elements) { }

    public int CalculateDeterminant()
    {
        if (rows != 2 || columns != 2)
        {
            Console.WriteLine("Визначник можна знайти лиш для  2x2 матрицi.");
            return 0;
        }

        return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
    }
}

class Program
{
    static void Main()
    {
        TSMATRIX<int> matrix1 = new TSMATRIX<int>();
        matrix1.InputData();
        matrix1.Display();

        Console.WriteLine($"Max element: {matrix1.FindMaxElement()}");
        Console.WriteLine($"Min element: {matrix1.FindMinElement()}");
        Console.WriteLine($"Sum of elements: {matrix1.CalculateSumOfElements()}");

        TSMATRIX<int> matrix2 = new TSMATRIX<int>();
        matrix2.InputData();
        matrix2.Display();

        TSMATRIX<int> sum = matrix1 + matrix2;
        Console.WriteLine("Сума:");
        sum.Display();

        TSMATRIX<int> difference = matrix1 - matrix2;
        Console.WriteLine("Рiзниця:");
        difference.Display();

        TDeterminant2 determinant = new TDeterminant2(new int[,] { { 2, 3 }, { 1, 4 } });
        int result = determinant.CalculateDeterminant();
        Console.WriteLine($"Визначник: {result}");
    }
}
