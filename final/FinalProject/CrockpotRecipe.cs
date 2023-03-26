public class CrockpotRecipe : Recipe {
    
    public CrockpotRecipe() : base(){}
    

    public override void DisplayCookTemp(){
        Console.WriteLine($"Set slow cooker to {_cookTemp} heat\n");
    }    
}