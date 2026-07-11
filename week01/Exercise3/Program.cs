using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();

        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a random number from 1 to 100
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int guessCount = 0;

            // Continue looping until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You guessed the number in {guessCount} guesses.");

            Console.Write("Would you like to play again? (yes/no) ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}