using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
    //Variables
        int _selection = -1;
        GoalManager goalManager = new GoalManager();

        
    //Main Menu Loop (runs until quit)
        while (_selection != 6){
            goalManager.GetTotalPoints();
            Console.WriteLine("Menu Options:");
            string[] mainMenu = {"Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit"};
            for(int index = 0; index < mainMenu.Length; index++){
                Console.WriteLine($"{index + 1}. {mainMenu[index]}");
            }
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            bool isDigit = int.TryParse(input, out _selection);
    //Menu Options        
            if (_selection == 1){
                goalManager.DisplayNewGoalMenu();
            }
            else if (_selection == 2){
                goalManager.DisplayGoals();
            }
            else if (_selection == 3){
                goalManager.SaveGoals();
            }
            else if (_selection == 4){
                goalManager.LoadGoals();
            }
            else if (_selection == 5){
                goalManager.RecordEvent();
            }
            else if (_selection == 6){
                break;
            }
            else {
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }
}