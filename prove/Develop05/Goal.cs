public abstract class Goal{
//Variables
    private string _name;
    private string _description;
    private int _points;

//Constructor
    public Goal(string name, string description, int points){
        _name = name;
        _description = description;
        _points = points;
    }

//Behaviors
    public int GetPoints(){
        return _points;
    }

    public string DisplayCheckBox(){
        if (IsComplete() == true){
            return "[X]";
        }
        else{
            return "[ ]";
        }
    }

    public string GetGoalName(){
        return _name;
    }

    public string GetGoalDescription(){
        return _description;
    }

//Behaviors eligible to be overridden
    public virtual string GetFormattedGoal(){
        return $"{DisplayCheckBox()} {_name} ({_description})";
    }

//Abstract Behaviors that must be set in child classes.
    public abstract int RecordEvent();
    public abstract bool IsComplete();            
    public abstract string GetStringRepresentation();
}