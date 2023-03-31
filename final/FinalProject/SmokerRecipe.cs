public class SmokerRecipe : Recipe {
// Variables
    private string _pelletType;
    private string _targetTemp;

// Constructors
    public SmokerRecipe(string name, string description, string cookTime, string cookTemp, string ingredientList, string instructionList, string pelletType, string targetTemp) : base(name, description, cookTime, cookTemp, ingredientList, instructionList){
        _pelletType = pelletType;
        _targetTemp = targetTemp;
    }

    public SmokerRecipe() : base(){
        Console.Write("What type of pellets are best for this recipe? ");
        _pelletType = Console.ReadLine();

        Console.Write("What temp will you shoot for on this recipe? ");
        _targetTemp = Console.ReadLine();
    }

// Behaviors
    public override void DisplayCookTemp(){
         Console.WriteLine($"Set smoker to indirect heat bring temp up to {_cookTemp} degrees");
    }

    public override void GetTypeSpecificDetails(){
        Console.WriteLine($"Recommended Pellets: {_pelletType}");
        Console.WriteLine($"Target food temp when done: {_targetTemp}");
    }
    
    public override string GetStringRepresentation(){
        return $"{_name}|{_description}|{_cookTime}|{_cookTemp}|{GetIngredients()}|{GetInstructions()}|{_pelletType}|{_targetTemp}";
    }
}