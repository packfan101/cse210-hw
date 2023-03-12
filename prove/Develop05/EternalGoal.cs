public class EternalGoal : Goal {
//Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points){}

//Behaviors
    public override int RecordEvent(){
        int points = GetPoints();
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        return points;
    }

    public override bool IsComplete(){
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalName()}|{GetGoalDescription()}|{GetPoints()}";
    }
}