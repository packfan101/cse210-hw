public class Instruction {
// Variables
    private int _stepNumber;
    private string _description;

// Constructors
    public Instruction(int stepNumber, string stepDescription){
        _stepNumber = stepNumber;
        _description = stepDescription;
    }
    
    public Instruction(int stepNumber){
        _stepNumber = stepNumber;
        SetDescription();
    }

// Behaviors
    public void SetDescription(){
        Console.WriteLine($"What instruction would you like to give for step {_stepNumber}? ");
        _description = Console.ReadLine();
    }

    public string GetStepNumber(){
        return _stepNumber.ToString();
    }

    public string getDescription(){
        return _description;
    }

    public string DisplayInstruction(){
        return $"Step {_stepNumber}: {_description}";
    }
}