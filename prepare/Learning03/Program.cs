using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);
        Fraction fraction4 = new Fraction();

        Console.WriteLine($"Fraction1: {fraction1.GetTop()}/{fraction1.GetBottom()}");
        Console.WriteLine($"Fraction2: {fraction2.GetTop()}/{fraction2.GetBottom()}");
        Console.WriteLine($"Fraction3: {fraction3.GetTop()}/{fraction3.GetBottom()}");
        Console.WriteLine($"Fraction4: {fraction4.GetTop()}/{fraction4.GetBottom()}");

        fraction1.SetTop(1);
        fraction1.SetBottom(1);
        fraction2.SetTop(5);
        fraction2.SetBottom(1);
        fraction3.SetTop(3);
        fraction3.SetBottom(4);
        fraction4.SetTop(1);
        fraction4.SetBottom(3);

        Console.WriteLine($"Fraction1: {fraction1.GetTop()}/{fraction1.GetBottom()}");
        Console.WriteLine($"Fraction2: {fraction2.GetTop()}/{fraction2.GetBottom()}");
        Console.WriteLine($"Fraction3: {fraction3.GetTop()}/{fraction3.GetBottom()}");
        Console.WriteLine($"Fraction4: {fraction4.GetTop()}/{fraction4.GetBottom()}");

        Console.WriteLine();
        Console.WriteLine($"{fraction1.GetFractionString()}");
        Console.WriteLine($"{fraction1.GetDecimalValue()}\n");

        Console.WriteLine($"{fraction2.GetFractionString()}");
        Console.WriteLine($"{fraction2.GetDecimalValue()}\n");

        Console.WriteLine($"{fraction3.GetFractionString()}");
        Console.WriteLine($"{fraction3.GetDecimalValue()}\n");

        Console.WriteLine($"{fraction4.GetFractionString()}");
        Console.WriteLine($"{fraction4.GetDecimalValue()}\n");

    }
}