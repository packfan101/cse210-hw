using System;

class Program
{
    static void Main(string[] args)
    {
        //Declare Variables
        string letter;
        string sign;
        
        //Get input from user and convert to a float
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percent = int.Parse(input);

        //Calculate letter grade
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //Calculate sign
        if ((percent % 10) >= 7)
        {
            sign = "+";
        }
        else if ((percent % 10) < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        //Eliminate A+, F+, and F-
        if (percent < 60 || percent > 93)
        {
            sign = "";
        }

        //Output
        Console.WriteLine($"Grade: {letter}{sign}");

        //Provide Pass/Fail message
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Sorry, you needed at least a C- to pass the class. Don't give up, you will do better next time.");
        }
    }
}