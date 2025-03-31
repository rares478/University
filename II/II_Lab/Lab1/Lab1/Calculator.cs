namespace Lab1;

public abstract class Calculator
{
    private static double Add(double a, double b)
    {
        return a + b;
    }

    private static double Subtract(double a, double b)
    {
        return a - b;
    }

    private static double Multiply(double a, double b)
    {
        return a * b;
    }

    private static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }

    public static void DisplayResults(double a, double b)
    {
        Console.WriteLine($"Addition: {Add(a, b)}");
        Console.WriteLine($"Subtraction: {Subtract(a, b)}");
        Console.WriteLine($"Multiplication: {Multiply(a, b)}");
        Console.WriteLine($"Division: {Divide(a, b)}");
    }
}