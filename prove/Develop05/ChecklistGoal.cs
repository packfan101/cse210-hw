public class ChecklistGoal : Goal {
//Variables
    private int _quantityDesired = 0;
    private int _quantityCompleted = 0;
    private int _bonusAmount = 0;

//Constructors
    public ChecklistGoal(string name, string description, int points, int quantityDesired, int bonusPoints) : base(name, description, points){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();

        Console.Write("What is a short description of your goal? ");
        _description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out _points);

        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        string input2 = Console.ReadLine();
        bool isDigit2 = int.TryParse(input2, out _quantityDesired);

        Console.Write("What is the bonus for accomplishing it that many times? ");
        string input3 = Console.ReadLine();
        bool isDigit3 = int.TryParse(input3, out _bonusAmount);
    }

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int quantityDesired, int quantityCompleted) : base(name, description, points){
        _quantityDesired = quantityDesired;
        _quantityCompleted = quantityCompleted;
        _bonusAmount = bonusPoints;
    }

//Behaviors
    public override int RecordEvent(){
        int points = GetPoints();
        _quantityCompleted++;
        if (_quantityCompleted == _quantityDesired){
            points += _bonusAmount;
        }
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        return points;
    }

    public override bool IsComplete(){
        if (_quantityCompleted >= _quantityDesired){
            return true;
        }
        else {
            return false;
        }
    }

    public string GetCompletionProgress(){
        return $"-- Currently completed: {_quantityCompleted}/{_quantityDesired}";
    }

    public override string GetFormattedGoal(){
        return $"{DisplayCheckBox()} {GetGoalName()} ({GetGoalDescription()}) {GetCompletionProgress()}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalName()}|{GetGoalDescription()}|{GetPoints()}|{_bonusAmount}|{_quantityDesired}|{_quantityCompleted}";
    }
}