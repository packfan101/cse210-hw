using System;

class Program
{
    static void Main(string[] args)
    {

        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");

        ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        //Menu
        int selection = -1;
        while (selection != 4)
        {   
            Console.Clear();
            Console.WriteLine("Menu Options: ");            
            string[] menu = {"Breathing Activity", "Reflection Activity", "Listing Activity", "Quit"};
            for (int index = 0; index < 4; index++)
            {
                Console.WriteLine($"{index + 1}. {menu[index]}");
            }
        //Select menu option    
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            bool isDigit = int.TryParse(input, out selection);
        
            if (selection == 1) {
                breathingActivity.RunBreathingActivity();
            }

            else if (selection == 2) {
                reflectionActivity.RunReflectionActivity();
            }

            else if (selection == 3) {
                listingActivity.RunListingActivity();
            }

            else if (selection == 4) {
                break;
            }

            else {
                Console.WriteLine("\nPlease choose a valid option.");
                Thread.Sleep(1000);
            }
        }
    }
}