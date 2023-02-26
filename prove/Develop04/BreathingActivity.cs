public class BreathingActivity : Activity {
    private string _inhale;
    private string _exhale;

    public BreathingActivity(string name, string description) : base(name, description) {
        _inhale = "Breath In";
        _exhale = "Breathe Out";
    }

    public void RunBreathingActivity(){
        GetStartingMessage();
        Console.Write("Get ready....");
        GetAnimatedDelay(5);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetRunTime());
        do {
            Console.Write($"\n\n{_inhale}...");
            GetCountdownDelay(4);            
            Console.Write($"\n{_exhale}...");
            GetCountdownDelay(6);            
        }while (DateTime.Now < (endTime));

        GetFinishMessage();
    }
}