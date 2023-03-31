public class OvenRecipe : Recipe {
// Variables
    private string _ovenRack;
    private string _cookSetting;

// Constructors
    public OvenRecipe(string name, string description, string cookTime, string cookTemp, string ingredientList, string instructionList, string ovenRack, string cookSetting) : base(name, description, cookTime, cookTemp, ingredientList, instructionList){
        _ovenRack = ovenRack;
        _cookSetting = cookSetting;
    }

    public OvenRecipe() : base(){
        Console.Write("Which oven rack should be used? (center/top/bottom/etc) ");
        _ovenRack = Console.ReadLine();

        Console.Write("Which oven setting should be used? (bake/broil/airfry/convection bake/etc) ");
        _cookSetting = Console.ReadLine();
    }

// Behaviors
    public override void DisplayCookTemp(){
        Console.WriteLine($"Set oven to {_cookTemp} degrees");
    }

    public override void GetTypeSpecificDetails(){
        Console.WriteLine($"Oven Setting: {_cookSetting}");
        Console.WriteLine($"Oven Rack: {_ovenRack}");
    }
    
    public override string GetStringRepresentation(){
        return $"{_name}|{_description}|{_cookTime}|{_cookTemp}|{GetIngredients()}|{GetInstructions()}|{_ovenRack}|{_cookSetting}";
    }
}