public class CrockpotRecipe : Recipe {
// Constructors
    public CrockpotRecipe(string name, string description, string cookTime, string cookTemp, string ingredients, string instructions) : base (name, description, cookTime, cookTemp, ingredients, instructions){}    
    public CrockpotRecipe() : base(){}   

// Behaviors
    public override void DisplayCookTemp(){
        Console.WriteLine($"Set slow cooker to {_cookTemp} heat");
    }    
}