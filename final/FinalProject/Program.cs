using System;

class Program
{
    static void Main(string[] args)
    {
        int _selection = -1;
        RecipeManager recipeManager = new RecipeManager();

        while (_selection != 6){
            Console.WriteLine("Menu Options:");
            string[] mainMenu = {"Create New Recipe", "Delete A Recipe", "Get a Random Recipe", "Search For Recipe", "View Recipes", "Save Recipes", "Load Recipes", "Quit"};
            for(int index=0; index < mainMenu.Length; index++){
                Console.WriteLine($"{index + 1}. {mainMenu[index]}");
            }
            Console.Write("Select a menu option: ");
            string input = Console.ReadLine();
            bool isDigit = int.TryParse(input, out _selection);

            if (_selection == 1){
                recipeManager.AddRecipe();
            }
            else if (_selection == 2){
                recipeManager.DeleteRecipe();
            }
            else if (_selection == 3){
                recipeManager.GetRandomRecipe();
            }
            else if (_selection == 4){
                recipeManager.SearchForRecipe();
            }
            else if (_selection == 5){
                recipeManager.ListRecipes();
            }
            else if (_selection == 6){
                recipeManager.SaveRecipes();
            }
            else if (_selection == 7){
                recipeManager.LoadRecipes();
            }
            else if (_selection == 8){
                break;
            }
            else {
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }
}