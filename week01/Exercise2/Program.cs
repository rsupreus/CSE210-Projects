using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        string letter;
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Get the last digit of the grade
        int lastDigit = grade % 10;

        // Determine whether the grade has a + or -
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // There is no A+ grade
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // There are no F+ or F- grades
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        // Determine whether the student passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard. You can do better next time.");
        }
    }
}