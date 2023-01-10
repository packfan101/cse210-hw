using System;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying = "yes";

        while (keepPlaying == "yes")
        {
            int guess = -1;
            int count = 0;
            
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,100);
            
            do
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                
                if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                
                else
                {
                    Console.WriteLine("You guessed it!");
                }
                
                count++;
                
            } while (guess != number);

            Console.WriteLine($"It took {count} guesses.");
            Console.Write("Would you like to play again? (yes/no) ");
            keepPlaying = Console.ReadLine();
        }
    }
}