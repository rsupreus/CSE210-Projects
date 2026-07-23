using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the constructor with no parameters
        Fraction fraction1 = new Fraction();

        // Test the constructor with one parameter
        Fraction fraction2 = new Fraction(5);

        // Test the constructor with two parameters
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);

        DisplayFraction(fraction1);
        DisplayFraction(fraction2);
        DisplayFraction(fraction3);
        DisplayFraction(fraction4);

        Console.WriteLine();

        // Test the getters
        Console.WriteLine($"Top number: {fraction3.GetTop()}");
        Console.WriteLine($"Bottom number: {fraction3.GetBottom()}");

        // Test the setters
        fraction3.SetTop(6);
        fraction3.SetBottom(7);

        Console.WriteLine();
        Console.WriteLine("After using the setters:");
        DisplayFraction(fraction3);
    }

    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(
            $"{fraction.GetFractionString()} = " +
            $"{fraction.GetDecimalValue()}"
        );
    }
}