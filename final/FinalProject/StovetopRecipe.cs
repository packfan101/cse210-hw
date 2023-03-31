public class StovetopRecipe : Recipe {
// Constructors
    public StovetopRecipe(string name, string description, string cookTime, string cookTemp, string ingredientList, string instructionList) : base(name, description, cookTime, cookTemp, ingredientList, instructionList){}
    public StovetopRecipe() : base(){}
    
// Behaviors
    public override void DisplayCookTemp(){
        Console.WriteLine($"Set burner to {_cookTemp} heat");
    }
}