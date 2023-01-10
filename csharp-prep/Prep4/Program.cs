using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string input;
        int sum = 0;
        int count = 0;
        do
        {
            Console.Write("Enter number: ");
            input = Console.ReadLine();
            if (input != "0")
            {
                numbers.Add(int.Parse(input));
            }
            
        } while (input != "0");

        foreach (int number in numbers)
        {
            sum += number;
            count++;
        }
        float average = ((float)sum) / count;
        int max = numbers.Max();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        Console.WriteLine($"The Count of numbers is: {count}");
    }
}