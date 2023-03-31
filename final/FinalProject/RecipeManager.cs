public class RecipeManager {
// Variables
    private List<Recipe> _recipes = new List<Recipe>();
    private string _fileName = "cookbook.txt";

// Constructors
    public RecipeManager(){}

// Behaviors
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
        int selection = -10;
        for (int index = 0; index < _recipes.Count(); index++){
            Console.WriteLine($"{index + 1}. {_recipes[index].GetName()}");
        }
        Console.Write("Which recipe would you like to delete? Type 0 to cancel.");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out selection);
        selection -= 1;

        if (selection == -1){
            Console.WriteLine("Delete operation cancelled.");
        }

        else if (selection < 0 || selection >= _recipes.Count()){
            Console.WriteLine("That was not a valid option.\nDelete operation cancelled.\n");
        }

        else {
            Console.Write($"Are you sure you wish to delete {_recipes[selection].GetName()}? This cannot be undone. (yes/no) ");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes"){
                _recipes.Remove(_recipes[selection]);
            }
        }
    }

    public void GetRandomRecipe(){
        Random random = new Random();
        int index = random.Next(_recipes.Count());
        _recipes[index].DisplayRecipe();
    }

    public void SearchForRecipe(){
        List<Recipe> searchResults = new List<Recipe>();
        int selection = -1;
        
    // Search Menu
        Console.WriteLine("Recipe Search \n");
        string[] mainMenu = {"By Name", "By Ingredient", "By Type"};
        for(int index=0; index < mainMenu.Length; index++){
            Console.WriteLine($"{index + 1}. {mainMenu[index]}");
        }
        Console.Write("How would you like to search? Choose an option: ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out selection);

    // Search By Name
        if (selection == 1){
            Console.Write("What is the name of the recipe you would like to search for? ");
            string name = Console.ReadLine();
            foreach (Recipe recipe in _recipes){
                string recipeName = recipe.GetName();
                if (recipeName.ToLower().Contains(name.ToLower())){
                    searchResults.Add(recipe);
                }
            }
        }

    // Search By Ingredient
        else if (selection == 2){
            Console.Write("What ingredient would you like to search for? ");
            string ingredient = Console.ReadLine();
            foreach (Recipe recipe in _recipes){
                recipe.CheckIngredients(ingredient);
                if (recipe.GetIngredientExists() == true){
                    searchResults.Add(recipe);
                }
            }
        }

    // Search By Recipe Type
        else if (selection == 3){
            int optionType = -1;
            Console.WriteLine("What kind of recipe would you like to find? \n");
            string[] menuType = {"Smoker Recipe", "CrockPot Recipe", "Pressure Cooker Recipe", "Oven Recipe", "Stovetop Recipe"};
            for(int index=0; index < menuType.Length; index++){
                Console.WriteLine($"{index + 1}. {menuType[index]}");
            }
            Console.Write("Select a menu option: ");
            string typeInput = Console.ReadLine();
            bool typeIsDigit = int.TryParse(typeInput, out optionType);

            if (optionType == 1){
                IEnumerable<SmokerRecipe> smokerSearchResults = _recipes.OfType<SmokerRecipe>();
                foreach ( SmokerRecipe smokerRecipe in smokerSearchResults){
                    searchResults.Add(smokerRecipe);
                }
                if (searchResults.Count() == 0){
                    Console.WriteLine($"\n NO RESULTS FOUND!\n");
                }
            }
            else if (optionType == 2){
                IEnumerable<CrockpotRecipe> crockpotSearchResults = _recipes.OfType<CrockpotRecipe>();
                foreach ( CrockpotRecipe crockpotRecipe in crockpotSearchResults){
                    searchResults.Add(crockpotRecipe);
                }
                if (searchResults.Count() == 0){
                    Console.WriteLine($"\n NO RESULTS FOUND!\n");
                }
            }
            else if (optionType == 3){
                IEnumerable<PressureCookerRecipe> pressureCookerSearchResults = _recipes.OfType<PressureCookerRecipe>();
                foreach ( PressureCookerRecipe pressureCookerRecipe in pressureCookerSearchResults){
                    searchResults.Add(pressureCookerRecipe);
                }
                if (searchResults.Count() == 0){
                    Console.WriteLine($"\n NO RESULTS FOUND!\n");
                }
            }
            else if (optionType == 4){
                IEnumerable<OvenRecipe> ovenSearchResults = _recipes.OfType<OvenRecipe>();
                foreach ( OvenRecipe ovenRecipe in ovenSearchResults){
                    searchResults.Add(ovenRecipe);
                }
                if (searchResults.Count() == 0){
                    Console.WriteLine($"\n NO RESULTS FOUND!\n");
                }
            }
            else if (optionType == 5){
                IEnumerable<StovetopRecipe> stovetopSearchResults = _recipes.OfType<StovetopRecipe>();
                foreach (StovetopRecipe stovetopRecipe in stovetopSearchResults){
                    searchResults.Add(stovetopRecipe);
                }
                if (searchResults.Count() == 0){
                    Console.WriteLine($"\n NO RESULTS FOUND!\n");
                }
            }
            else {
                Console.WriteLine("That was not a valid option.");
            }
        }

    // Display Search Results
        int option = -10;
        while (option != -1){
            for (int index = 0; index < searchResults.Count(); index++){
                Console.WriteLine($"{index + 1}. {searchResults[index].GetName()}");
            }
            Console.Write("Choose a recipe number to view or type 0 to quit." );
            string input2 = Console.ReadLine();
            bool isDigit2 = int.TryParse(input2, out option);
            option = option - 1;

            if (option == -1){
                break;
            }
            else {
                searchResults[option].DisplayRecipe();
            }
        }
        searchResults.Clear();
    }

    public void ListRecipes(){
        int selection = -10;
        while (selection != -1){
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
            }
        } 
    }

    public void SaveRecipes(){
        using (StreamWriter outputFile = new StreamWriter(_fileName)){
            foreach (Recipe recipe in _recipes){
                outputFile.WriteLine($"{recipe}:{recipe.GetStringRepresentation()}");
            }
        }
        Console.WriteLine($"\nSave Successful\n");
        Thread.Sleep(1000);
    }

    public void LoadCookbook(){
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        char[] delimiters = {':', '|'};
        foreach (string line in lines){
            string[] parts = line.Split(delimiters);
            string recipeType = parts[0];
            string recipeName = parts[1];
            string recipeDescription = parts[2];
            string cookTime = parts[3];
            string cookTemp = parts[4];
            string ingredientList = parts[5];
            string instructionList = parts[6];
            if (recipeType == "SmokerRecipe"){
                string pelletType = parts[7];
                string targetTemp = parts[8];
                SmokerRecipe smokerRecipe = new SmokerRecipe(recipeName, recipeDescription, cookTime, cookTemp, ingredientList, instructionList, pelletType, targetTemp);
                _recipes.Add(smokerRecipe);
            }
            else if (recipeType == "CrockpotRecipe"){
                CrockpotRecipe crockpotRecipe = new CrockpotRecipe(recipeName, recipeDescription, cookTime, cookTemp, ingredientList, instructionList);
                _recipes.Add(crockpotRecipe);
            }
            else if (recipeType == "PressureCookerRecipe"){
                string pressure = parts[7];
                int naturalReleaseTime = int.Parse(parts[8]);
                PressureCookerRecipe pressureCookerRecipe = new PressureCookerRecipe(recipeName, recipeDescription, cookTime, cookTemp, ingredientList, instructionList, pressure, naturalReleaseTime);
                _recipes.Add(pressureCookerRecipe);
            }
            else if (recipeType == "OvenRecipe"){
                string ovenRack = parts[7];
                string cookSetting = parts[8];
                OvenRecipe ovenRecipe = new OvenRecipe(recipeName, recipeDescription, cookTime, cookTemp, ingredientList, instructionList, ovenRack, cookSetting);
                _recipes.Add(ovenRecipe);
            }
            else if (recipeType == "StovetopRecipe"){
                StovetopRecipe stovetopRecipe = new StovetopRecipe(recipeName, recipeDescription, cookTime, cookTemp, ingredientList, instructionList);
                _recipes.Add(stovetopRecipe);
            }
        }
    }

    public void ChangeCookbook(){
        _recipes.Clear();
        Console.Write("What is the filename for your cookbook? ");
        _fileName = Console.ReadLine();
        if (File.Exists(_fileName)){
            LoadCookbook();
        }
        else {
            File.Create(_fileName).Close();
            LoadCookbook();
        }
        Console.Write($"\n{_fileName} Cookbook has been loaded successfully.");
        Thread.Sleep(2000);
    }
    
    public string GetFileName(){
        return _fileName;
    }
}