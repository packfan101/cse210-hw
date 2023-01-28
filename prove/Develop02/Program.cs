using System;
using System.IO;
//I added logic to the save method that checks to see if a file has been loaded already during the session, and then asks if you wish to save to that file, or provide a new filename. If a file has not been loaded, it asks for a filename and then verifies that the file is empty before saving. If the file has content, the program asks if you would like to append to the file, overwrite the file, or cancel the save.

//I added confirmation comments to the screen when you save, load, or add an entry that confirms that the operation has completed successfully.

//I added logic to the load file method that verifies whether the file exists and if it doesn't, it provides a message letting you know the file doesn't exist, and to try again.

//I added logic that asks for the user's name at the beginning of the program. It then uses that name to save files by putting the username at the beginning of the file name. By doing this multiple users can use the same filename of journal.txt, and each of them will have their own file without overwriting another users journal.

//There is currently a journal named journal.txt for the Scott user. If you use the Name of "Scott" and the filename of "journal.txt", you will find my journal entries I used for test.

//I added logic to the prompt generator that prevents me from getting the same prompt twice before all prompts have been used. Prompts are still chosen at random, but once they have been used, they are no longer an option until all have been used.
public class Program
{    
    static void Main(string[] args)
    {
        int selection = -1;
        Journal _journal1 = new Journal();
        Console.WriteLine("Welcome to the Journal Program!\n");
        Console.Write("Please enter your name: ");
        _journal1._username = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"Hello {_journal1._username}, Welcome to your journal. Don't forget to save when finished\n");
        while (selection != 5)
        {
        //Menu
            Console.WriteLine("Please select one of the following choices: ");            
            string[] menu = {"Write", "Display", "Load", "Save", "Quit"};
            for (int index = 0; index < 5; index++)
            {
                Console.WriteLine($"{index + 1}. {menu[index]}");
            }
        //Select menu option    
            Console.Write("What would you like to do? ");
            selection = int.Parse(Console.ReadLine());

        //Menu selection option commands
            if (selection == 1)
            {
                _journal1.AddEntry();
            }

            else if (selection == 2)
            {
                _journal1.Display();
            }

            else if (selection == 3)
            {
                _journal1.LoadFromFile();
            }

            else if (selection == 4)
            {
                _journal1.SaveToFile();
            }

            else
            {
                break;
            }
        }
    }
}