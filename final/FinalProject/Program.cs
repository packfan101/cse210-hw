using System;

class Program
{
    static void Main(string[] args)
    {
        int _selection = -1;
        RecipeManager recipeManager = new RecipeManager();
        recipeManager.LoadCookbook();

        while (_selection != 8){
            Console.Clear();
            Console.WriteLine($"Current Cookbook: {recipeManager.GetFileName()}\n");
            Console.WriteLine("Menu Options:");
            string[] mainMenu = {"Create New Recipe", "Delete A Recipe", "Get A Random Recipe", "Search For Recipe", "View Recipes", "Save Recipes", "Change Cookbook", "Quit"};
            for(int index=0; index < mainMenu.Length; index++){
                Console.WriteLine($"{index + 1}. {mainMenu[index]}");
            }
            Console.Write("Select A Menu Option: ");
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
                recipeManager.ChangeCookbook();
            }
            else if (_selection == 8){
                Console.Write("Would you like to save before exiting? (yes/no) ");
                string response = Console.ReadLine();
                if (response.ToLower() == "yes"){
                    recipeManager.SaveRecipes();
                }
                break;
            }
            else {
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }
}