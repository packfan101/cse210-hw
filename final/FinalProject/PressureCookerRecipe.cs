public class PressureCookerRecipe : Recipe {
    private string _pressure;
    private int _naturalReleaseTime;

    public PressureCookerRecipe() : base(){
        Console.Write("Does this recipe call for high or low pressure? (high/low) ");
        _pressure = Console.ReadLine();

        Console.Write("How many minutes should you allow pressure to naturally release? (enter 0 if you wish to release immediately.) ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out _naturalReleaseTime);
    }
    
    public override void DisplayRecipe(){
        Console.WriteLine($"\n{_name}\n");
        Console.WriteLine($"{_description}\n");
        Console.WriteLine($"Cook Time: {_cookTime}\n");
        Console.WriteLine($"Set the pressure cooker to {_pressure} pressure");
        if (_naturalReleaseTime > 0){
            Console.WriteLine($"Allow the pressure to naturally release for {_naturalReleaseTime} minutes");
        }
        else {
            Console.WriteLine("You can release pressure immediately at the end of the cook time.");
        }
        
        
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