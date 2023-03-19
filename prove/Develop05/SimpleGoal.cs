public class SimpleGoal : Goal {
//Variables
    private bool _completed = false;

//Constructors
    public SimpleGoal(string name, string description, int points) : base(name, description, points){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();

        Console.Write("What is a short description of your goal? ");
        _description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out _points);
    }

    public SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points){
        _completed = completed;
    }

//Behaviors
    public override int RecordEvent(){
        _completed = true;
        int points = GetPoints();
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        return points;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalName()}|{GetGoalDescription()}|{GetPoints()}|{_completed}";
    }

    public override bool IsComplete(){
        if (_completed == true){
            return true;
        }
        else {
            return false;
        }
    }
}