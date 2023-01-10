using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squareNumber = SquareNumber(favoriteNumber);
  
        DisplayResult(userName, squareNumber);
    }
    static void DisplayWelcome()
    {
         Console.WriteLine("Welcome to the Program!");
    }
        
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        return favoriteNumber;
    }

    static int SquareNumber(int favoriteNumber)
    {
        int squareNumber = favoriteNumber * favoriteNumber;
        return squareNumber;
    }

    static void DisplayResult(string name, int number)
    {
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}