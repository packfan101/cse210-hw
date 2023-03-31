public class PressureCookerRecipe : Recipe {
// Variables
    private string _pressure;
    private int _naturalReleaseTime;

// Constructors
    public PressureCookerRecipe(string name, string description, string cookTime, string cookTemp, string ingredientList, string instructionList, string pressure, int naturalReleaseTime) : base(name, description, cookTime, cookTemp, ingredientList, instructionList){
        _pressure = pressure;
        _naturalReleaseTime = naturalReleaseTime;
    }

    public PressureCookerRecipe() : base(){
        Console.Write("Does this recipe call for high or low pressure? (high/low) ");
        _pressure = Console.ReadLine();

        Console.Write("How many minutes should you allow pressure to naturally release? (enter 0 if you wish to release immediately.) ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out _naturalReleaseTime);
    }

// Behaviors
    public override void GetTypeSpecificDetails(){
        Console.WriteLine($"Set the pressure cooker to {_pressure} pressure");
        if (_naturalReleaseTime > 0){
            Console.WriteLine($"Allow the pressure to naturally release for {_naturalReleaseTime} minutes");
        }
        else {
            Console.WriteLine("You can release pressure immediately at the end of the cook time.");
        }
    }
    
    public override string GetStringRepresentation(){
        return $"{_name}|{_description}|{_cookTime}|{_cookTemp}|{GetIngredients()}|{GetInstructions()}|{_pressure}|{_naturalReleaseTime}";
    }
}