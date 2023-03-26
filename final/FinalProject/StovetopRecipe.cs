public class StovetopRecipe : Recipe {
    public StovetopRecipe() : base(){}
    
    public override void DisplayCookTemp(){
        Console.WriteLine($"Set burner to {_cookTemp} heat\n");
    }
}