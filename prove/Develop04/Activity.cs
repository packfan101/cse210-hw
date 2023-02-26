public class Activity {
    //variables
    private string _activityName;
    private string _activityDescription;
    private string _finishMessage;
    private int _activityRunTime;

    public Activity(string name, string description) {
        _activityName = name;
        _activityDescription = description;
        _finishMessage = "Excellent Job";
    }

    public int GetRunTime(){
        return _activityRunTime;
    }
    
    public void GetStartingMessage(){
        Console.Clear();
        Console.WriteLine($"{_activityName}\n");
        Console.WriteLine($"{_activityDescription}\n");
        Console.Write("Please enter a length of time (in seconds) to perform this activity: ");
        _activityRunTime = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    public void GetFinishMessage(){
        Console.WriteLine($"\n\n{_finishMessage}");
        GetAnimatedDelay(3);
        Console.WriteLine($"\nYou have completed another {_activityRunTime} Seconds of the {_activityName}");
        GetAnimatedDelay(3);
    }

    public void GetAnimatedDelay(int delayLength){
        DateTime cycleTime = DateTime.Now.AddSeconds(delayLength);
        while (DateTime.Now < cycleTime){
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(200);

                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(200);

                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(200);
            }
            Console.Write("\b \b\n");
    }

    public void GetCountdownDelay(int delayLength){
        for (int i=delayLength; i > 0; i--){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}