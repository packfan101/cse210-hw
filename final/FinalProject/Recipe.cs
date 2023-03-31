public abstract class Recipe {
// Variables
    protected string _name;
    protected string _description;
    protected string _cookTime;
    protected string _cookTemp;
    private bool _ingredientExists = false;
    protected List<Ingredient> _ingredients = new List<Ingredient>();
    protected List<Instruction> _instructions = new List<Instruction>();

// Constructors
    public Recipe(string name, string description, string cookTime, string cookTemp, string ingredients, string instructions){
        _name = name;
        _description = description;
        _cookTime = cookTime;
        _cookTemp = cookTemp;
        LoadIngredients(ingredients);
        LoadInstructions(instructions);   
    }
    public Recipe(){
        Console.Write($"What is the name of your recipe? ");
        _name = Console.ReadLine();

        Console.Write("Please provide a description of the recipe: ");
        _description = Console.ReadLine();

        Console.Write("What is the cook time? ");
        _cookTime = Console.ReadLine();

        Console.Write("At what temperature do you cook this? ");
        _cookTemp = Console.ReadLine();

        Console.WriteLine("Let's add some ingredients!");

        string addIngredient = "yes";
        while (addIngredient.ToLower() == "yes"){
            AddIngredient();
            Console.Write("Would you like to add another ingredient to this recipe? (yes/no) ");
            addIngredient = Console.ReadLine();
        }

        string addStep = "yes";
        int stepNumber = 1;
        while (addStep.ToLower() == "yes"){
            AddStep(stepNumber);
            stepNumber++;
            Console.Write("Would you like to add another step to the instructions? (yes/no) ");
            addStep = Console.ReadLine();
        }
    }

// Behaviors
    public string GetName(){
        return $"{_name}";
    }

    private void AddIngredient(){
        Ingredient ingredient = new Ingredient();
        _ingredients.Add(ingredient);
    }

    private void AddStep(int stepNumber){
        Instruction instruction = new Instruction(stepNumber);
        _instructions.Add(instruction);
    }

    public void CheckIngredients(string name){
        foreach (Ingredient ingredient in _ingredients){
            string ingName = ingredient.GetName();
            if (ingName.ToLower().Contains(name.ToLower())){
                _ingredientExists = true;
            }
        }
    }

    public bool GetIngredientExists(){
        return _ingredientExists;
    }

    public void DisplayRecipe(){
        Console.WriteLine($"\n{_name}");
        Console.WriteLine($"{_description}\n");
        GetTypeSpecificDetails();
        Console.WriteLine($"Cook Time: {_cookTime}");
        DisplayCookTemp();
        Console.WriteLine($"\nIngredients:\n");
        foreach(Ingredient ingredient in _ingredients){
            Console.WriteLine($"{ingredient.GetIngredient()}");
        }
        Console.WriteLine($"\nInstructions:\n");
        foreach(Instruction step in _instructions){
            Console.WriteLine($"{step.DisplayInstruction()}");
        }
        Console.Write("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
    // Two behaviors intentionally left as virtual because not all classes want a response from these behaviors. These are overridden in the classes that use them.
    public virtual void DisplayCookTemp(){}

    public virtual void GetTypeSpecificDetails(){}

    public virtual string GetStringRepresentation(){
        return $"{_name}|{_description}|{_cookTime}|{_cookTemp}|{GetIngredients()}|{GetInstructions()}";
    }

    public string GetIngredients(){
        string ingredientString = "";
        foreach (Ingredient ingredient in _ingredients){
            ingredientString += $"{ingredient.GetName()};{ingredient.GetQuantity()};{ingredient.GetUnitOfMeasure()};";
        }
        return ingredientString;
    }

    public string GetInstructions(){
        string instructionString = "";
        foreach (Instruction step in _instructions){
            instructionString += $"{step.GetStepNumber()};{step.getDescription()};";
        }
        return instructionString;
    }

    // Next three sections: Tied to load operation. Takes the arrays of ingredients and instructions, breaks them into parts and extracts them to place them in their respective classes under the proper variable names.
    private static List<string> EveryNthElement(string[] parts, int n){
            List<string> result = new List<string>();
            for (int i = 0; i < parts.Count(); i++){
                if ((i % n) == 0){
                    result.Add(parts[i]);
                }
            }
            return result;
        }

    private void LoadIngredients(string ingredients){
        List<string> ingNames = new List<string>();
        List<string> ingVolumes = new List<string>();
        List<string> ingUnitOfMeasure = new List<string>();
        string[] ingParts = ingredients.Split(";");
        
        var result = EveryNthElement(ingParts, 3);
        foreach (string piece in result){
            ingNames.Add(piece);
        }

        string[] ingParts2 = ingParts.Skip(1).ToArray();
        var result2 = EveryNthElement(ingParts2, 3);
        foreach (string piece in result2){
            ingVolumes.Add(piece);
        }   

        string[] ingParts3 = ingParts.Skip(2).ToArray();
        var result3 = EveryNthElement(ingParts3, 3);
        foreach (string piece in result3){
            ingUnitOfMeasure.Add(piece);
        }

        for (int i = 0; i < ingVolumes.Count(); i++){
            Ingredient ingredient = new Ingredient(ingNames[i], ingVolumes[i], ingUnitOfMeasure[i]);
            _ingredients.Add(ingredient);
        }
    }

    private void LoadInstructions(string instructions){
        List<int> stepNumber = new List<int>();
        List<string> stepDescription = new List<string>();
        string[] stepParts = instructions.Split(";");

        var result = EveryNthElement(stepParts, 2);
        foreach (string piece in result){
            int step;
            bool isDigit = int.TryParse(piece, out step);
            stepNumber.Add(step);
        }

        string[] stepParts2 = stepParts.Skip(1).ToArray();
        var result2 = EveryNthElement(stepParts2, 2);
        foreach (string piece in result2){
            stepDescription.Add(piece);
        }

        for (int i = 0; i < stepDescription.Count(); i++){
            Instruction instruction = new Instruction(stepNumber[i], stepDescription[i]);
            _instructions.Add(instruction);
        }
    }
}