public abstract class Recipe {
    protected string _name;
    protected string _description;
    protected string _cookTime;
    protected string _cookTemp;
    private bool _ingredientExists = false;
    protected List<Ingredient> _ingredients = new List<Ingredient>();
    protected List<Instruction> _instructions = new List<Instruction>();

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
        while (addIngredient == "yes"){
            AddIngredient();
            Console.Write("Would you like to add another ingredient to this recipe? (yes/no) ");
            addIngredient = Console.ReadLine();
        }

        string addStep = "yes";
        int stepNumber = 1;
        while (addStep == "yes"){
            AddStep(stepNumber);
            stepNumber++;
            Console.Write("Would you like to add another step to the instructions? (yes/no) ");
            addStep = Console.ReadLine();
        }
    }

    public string GetName(){
        return $"{_name}";
    }
    public void AddIngredient(){
        Ingredient ingredient = new Ingredient();
        _ingredients.Add(ingredient);
    }

    public void AddStep(int stepNumber){
        Instruction instruction = new Instruction(stepNumber);
        _instructions.Add(instruction);
    }

    public void checkIngredients(string name){
        foreach (Ingredient ingredient in _ingredients){
            string ingName = ingredient.GetName();
            if (ingName == name){
                _ingredientExists = true;
            }
        }
    }

    public bool GetIngredientExists(){
        return _ingredientExists;
    }

    public virtual void DisplayRecipe(){
        Console.WriteLine($"\n{_name}\n");
        Console.WriteLine($"{_description}\n");
        Console.WriteLine($"Cook Time: {_cookTime}\n");
        DisplayCookTemp();
        Console.WriteLine($"Ingredients:\n");
        foreach(Ingredient ingredient in _ingredients){
            Console.WriteLine($"{ingredient.GetIngredient()}\n");
        }

        foreach(Instruction step in _instructions){
            Console.WriteLine($"{step.DisplayInstruction()}\n");
        }
    }

    public virtual void DisplayCookTemp(){}
}