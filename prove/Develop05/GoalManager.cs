public class GoalManager {
//Variables
    private int _totalPoints = 0;
    private string _fileName;
    private string _loadedFileName;
    List<Goal> _goals = new List<Goal>();

//Behaviors
    public void GetTotalPoints(){
        Console.WriteLine($"\nYou have {_totalPoints} points.\n");
    }

    public void DisplayNewGoalMenu(){
        int _selection = -1;
        Console.WriteLine("The types of Goals are:");
        string[] newGoalMenu = {"Simple Goal", "Eternal Goal", "Checklist Goal"};
        for(int index = 0; index < 3; index++){
            Console.WriteLine($"{index + 1}. {newGoalMenu[index]}");
        }
        Console.Write("Which type of goal would you like to create? ");
        string input = Console.ReadLine();
        bool isDigit = int.TryParse(input, out _selection);
    //Selection Options        
        if (_selection == 1){
            CreateSimpleGoal();
        }
        else if (_selection == 2){
            CreateEternalGoal();
        }
        else if (_selection == 3){
            CreateChecklistGoal();
        }
        else{
            Console.WriteLine("You did not choose a valid option. Please try again.");
        }
    }

    public void DisplayGoals(){
        Console.WriteLine("The goals are:");
        for (int index = 0; index < _goals.Count; index++){
            Console.WriteLine($"{index + 1}. {_goals[index].GetFormattedGoal()}");
        }
        Console.WriteLine();
    }

    public void RecordEvent(){
        Console.WriteLine("The goals are:");
        for (int index = 0; index < _goals.Count; index++){
            Console.WriteLine($"{index + 1}. {_goals[index].GetGoalName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();
        int chosenIndex;
        bool isDigit = int.TryParse(input, out chosenIndex);
        chosenIndex = chosenIndex - 1;
        _totalPoints +=_goals[chosenIndex].RecordEvent();
        Console.WriteLine($"You now have {_totalPoints} points!");
    }

    private void CreateSimpleGoal(){
        SimpleGoal simpleGoal = new SimpleGoal("", "", 0);
        _goals.Add(simpleGoal);
    }

    private void CreateEternalGoal(){
        EternalGoal eternalGoal = new EternalGoal("", "", 0);
        _goals.Add(eternalGoal);
    }

    private void CreateChecklistGoal(){
        ChecklistGoal checklistGoal = new ChecklistGoal("", "", 0, 0, 0);
        _goals.Add(checklistGoal);
    }

    public void SaveGoals(){
        Console.Write("Please enter a filename: ");
        _fileName = Console.ReadLine();

        if (File.Exists(_fileName)){
            if (new FileInfo(_fileName).Length == 0){
            OverwriteFile();
            }
            else {
                if (_fileName == _loadedFileName){
                    OverwriteFile();
                }
                else{
                    Console.Write("This file is not empty. Do you want to overwrite it? (yes/no) ");
                    string overwriteResponse = Console.ReadLine();
                    
                    if (overwriteResponse == "yes"){
                        OverwriteFile();
                    }
                    
                    else if (overwriteResponse == "no"){
                        Console.Write("Would you like to add these goals to the file? (yes/no) ");
                        string appendResponse = Console.ReadLine();
                        
                        if (appendResponse == "yes"){
                            AppendFile();
                            _goals.Clear();
                            _totalPoints = 0;
                            Console.WriteLine("Goal(s) and points have been appended to file. Please load the file to see the changes.");
                        }
                        
                        else{
                            Console.WriteLine("\nFile was not saved\n");
                        }
                    }
                }  
            }
        }
        else {
            OverwriteFile();
        }
    }

    public void LoadGoals(){
        Console.Write("Please enter a filename: ");
        _loadedFileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(_loadedFileName);
        string totalPoints = lines[0];
        _totalPoints = int.Parse(totalPoints);
        char[] delimiters = {':', '|'};
        foreach (string line in lines.Skip(1)){
            string[] parts = line.Split(delimiters);
            string partOne = parts[0];
            string partTwo = parts[1];
            string partThree = parts[2];
            string partFour = parts[3];
            int points = int.Parse(partFour);
            if (partOne == "SimpleGoal"){
                string partFive = parts[4];
                bool completed = bool.Parse(partFive);
                SimpleGoal simpleGoal = new SimpleGoal(partTwo, partThree, points, completed);
                _goals.Add(simpleGoal);
            }
            else if (partOne == "EternalGoal"){
                EternalGoal eternalGoal = new EternalGoal(partTwo, partThree, points);
                _goals.Add(eternalGoal);
            }
            else if (partOne == "ChecklistGoal"){
                string partFive = parts[4];
                string partSix = parts[5];
                string partSeven = parts[6];
                int bonusPoints = int.Parse(partFive);
                int desired = int.Parse(partSix);
                int completed = int.Parse(partSeven);
                ChecklistGoal checklistGoal = new ChecklistGoal(partTwo, partThree, points, bonusPoints, desired, completed);
                _goals.Add(checklistGoal);
            }       
        }
    }

    public void OverwriteFile(){
        using (StreamWriter outputFile = new StreamWriter(_fileName)){
            outputFile.WriteLine(_totalPoints);
            foreach (Goal goal in _goals){
                outputFile.WriteLine($"{goal}:{goal.GetStringRepresentation()}");
            }
        }
    }

    public void AppendFile(){
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        int oldPoints = int.Parse(lines[0]);
        _totalPoints += oldPoints;
        lines[0] = _totalPoints.ToString();
        System.IO.File.WriteAllLines(_fileName, lines);
        using (StreamWriter outputFile = new StreamWriter(_fileName, append: true)){
            foreach (Goal goal in _goals){
                outputFile.WriteLine($"{goal}:{goal.GetStringRepresentation()}");
            }
        }
    }
}