public class EternalGoal : Goal {
//Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points){
        if (name == ""){
            Console.Write("What is the name of your goal? ");
            _name = Console.ReadLine();

            Console.Write("What is a short description of your goal? ");
            _description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            string input = Console.ReadLine();
            bool isDigit = int.TryParse(input, out _points);
        } 
    }    

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