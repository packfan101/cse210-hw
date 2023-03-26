public class SmokerRecipe : Recipe {
    private string _pelletType;
    private string _targetTemp;

    public SmokerRecipe() : base(){
        Console.Write("What type of pellets are best for this recipe? ");
        _pelletType = Console.ReadLine();

        Console.Write("What temp will you shoot for on this recipe? ");
        _targetTemp = Console.ReadLine();
    }

    public override void DisplayCookTemp(){
         Console.WriteLine($"Set smoker to indirect heat bring temp up to {_cookTemp} degrees\n");
    }

    public override void DisplayRecipe(){
        Console.WriteLine($"\n{_name}\n");
        Console.WriteLine($"{_description}\n");
        Console.WriteLine($"Recommended Pellets: {_pelletType}\n");
        Console.WriteLine($"Target food temp when done: {_targetTemp}\n");
        Console.WriteLine($"Cook Time: {_cookTime}\n");
        DisplayCookTemp();
        Console.WriteLine($"Ingredients:\n");

        foreach(Ingredient ingredient in _ingredients){
            Console.WriteLine($"{ingredient.GetIngredient()}\n");
        }

        Console.WriteLine($"Instructions:\n");

        foreach(Instruction step in _instructions){
            Console.WriteLine($"{step.DisplayInstruction()}\n");
        }
    }
}