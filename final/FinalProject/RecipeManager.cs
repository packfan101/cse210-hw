public class RecipeManager {
    private List<Recipe> _recipes = new List<Recipe>();
    public void AddRecipe(){
        int selection = -1;
        Console.WriteLine("What kind of recipe would you like to add? \n");
        string[] mainMenu = {"Smoker Recipe", "CrockPot Recipe", "Pressure Cooker Recipe", "Oven Recipe", "Stovetop Recipe"};
        for(int index=0; index < mainMenu.Length; index++){
            Console.WriteLine($"{index + 1}. {mainMenu[index]}");
        }
        Console.Write("Select a menu option: ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out selection);

        if (selection == 1){
            SmokerRecipe smokerRecipe = new SmokerRecipe();
            _recipes.Add(smokerRecipe);
        }
        else if (selection == 2){
            CrockpotRecipe crockpotRecipe = new CrockpotRecipe();
            _recipes.Add(crockpotRecipe);
        }
        else if (selection == 3){
            PressureCookerRecipe pressureCookerRecipe = new PressureCookerRecipe();
            _recipes.Add(pressureCookerRecipe);
        }
        else if (selection == 4){
            OvenRecipe ovenRecipe = new OvenRecipe();
            _recipes.Add(ovenRecipe);
        }
        else if (selection == 5){
            StovetopRecipe stovetopRecipe = new StovetopRecipe();
            _recipes.Add(stovetopRecipe);
        }
        else {
            Console.WriteLine("Please choose a valid option.");
        }
    }

    public void DeleteRecipe(){

    }

    public void GetRandomRecipe(){

    }

    public void SearchForRecipe(){
        List<Recipe> searchResults = new List<Recipe>();
        int selection = -1;
        Console.WriteLine("Recipe Search \n");
        string[] mainMenu = {"By Name", "By Ingredient", "By Type"};
        for(int index=0; index < mainMenu.Length; index++){
            Console.WriteLine($"{index + 1}. {mainMenu[index]}");
        }
        Console.Write("How would you like to search? Choose and option: ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out selection);

        if (selection == 1){
            Console.Write("What is the name of the recipe you would like to search for? ");
            string name = Console.ReadLine();
            foreach (Recipe recipe in _recipes){
                string recipeName = recipe.GetName();
                if (recipeName == name){
                    searchResults.Add(recipe);
                }
            }
        }
        else if (selection == 2){
            Console.Write("What ingredient would you like to search for? ");
            string ingredient = Console.ReadLine();
            foreach (Recipe recipe in _recipes){
                recipe.checkIngredients(ingredient);
                if (recipe.GetIngredientExists() == true){
                    searchResults.Add(recipe);
                }
            }
        }
        else if (selection == 3){
            int optionType = -1;
            Console.WriteLine("What kind of recipe would you like to add? \n");
            string[] menuType = {"Smoker Recipe", "CrockPot Recipe", "Pressure Cooker Recipe", "Oven Recipe", "Stovetop Recipe"};
            for(int index=0; index < menuType.Length; index++){
                Console.WriteLine($"{index + 1}. {menuType[index]}");
            }
            Console.Write("Select a menu option: ");
            string typeInput = Console.ReadLine();
            bool typeIsDigit = int.TryParse(typeInput, out optionType);

            if (optionType == 1){
                foreach (SmokerRecipe recipe in _recipes){
                    searchResults.Add(recipe);
                }
            }
            else if (optionType == 2){
                foreach (CrockpotRecipe recipe in _recipes){
                    searchResults.Add(recipe);
                }
            }
            else if (optionType == 3){
                foreach (PressureCookerRecipe recipe in _recipes){
                    searchResults.Add(recipe);
                }
            }
            else if (optionType == 4){
                foreach (OvenRecipe recipe in _recipes){
                    searchResults.Add(recipe);
                }
            }
            else if (optionType == 5){
                foreach (StovetopRecipe recipe in _recipes){
                    searchResults.Add(recipe);
                }
            }
            else {
                Console.WriteLine("That was not a valid option.");
            }
        }

        int option = -1;
        while (option != 0){
            for (int index = 0; index < searchResults.Count(); index++){
                Console.WriteLine($"{index + 1}. {searchResults[index].GetName()}");
            }
            Console.Write("Choose a recipe number to view or type 0 to quit." );
            string input2 = Console.ReadLine();
            bool isDigit2 = int.TryParse(input, out option);
            option -= 1;

            if (option == -1){
                break;
            }
            else {
                searchResults[option].DisplayRecipe();
                Console.Write("Press enter to return to the recipe list. ");
                Console.ReadLine();
            }
        }
        searchResults.Clear();
    }

    public void ListRecipes(){
        int selection = -1;
        while (selection != 0){
            for (int index = 0; index < _recipes.Count(); index++){
                Console.WriteLine($"{index + 1}. {_recipes[index].GetName()}");
            }
            Console.Write("Choose a recipe number to view or type 0 to quit." );
            string input = Console.ReadLine();
            bool isDigit = int.TryParse(input, out selection);
            selection -= 1;

            if (selection == -1){
                break;
            }
            else {
                _recipes[selection].DisplayRecipe();
                Console.Write("Press enter to return to the recipe list. ");
                Console.ReadLine();
            }
        } 
    }

    public void SaveRecipes(){

    }

    public void LoadRecipes(){

    }
}