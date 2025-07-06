using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); 

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Guess the Magic Number (1–100)!");

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
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
            Console.WriteLine();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
