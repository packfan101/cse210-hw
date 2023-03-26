public class Instruction {
    private int _stepNumber;
    private string _description;

    public Instruction(int stepNumber){
        SetStepNumber(stepNumber);
        SetDescription();
    }

    public void SetDescription(){
        Console.WriteLine($"What instruction would you like to give for step {_stepNumber}? ");
        _description = Console.ReadLine();
    }

    public string getDescription(){
        return _description;
    }

    public void SetStepNumber(int number){
        _stepNumber = number;
    }

    public string DisplayInstruction(){
        return $"Step {_stepNumber}: {_description}";
    }
}