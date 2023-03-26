public class OvenRecipe : Recipe {
    private string _ovenRack;
    private string _cookSetting;

    public OvenRecipe() : base(){
        Console.Write("Which oven rack should be used? (center/top/bottom/etc) ");
        _ovenRack = Console.ReadLine();

        Console.Write("Which oven setting should be used? (bake/broil/airfry/convection bake/etc) ");
        _cookSetting = Console.ReadLine();
    }

    public override void DisplayCookTemp(){
        Console.WriteLine($"Set oven to {_cookTemp} degrees");
    }
    public override void DisplayRecipe(){
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
}