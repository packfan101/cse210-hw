public class ListingActivity : Activity {
    private List<string> _userInput = new List<string>{};
    private List<string> _listPrompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();
    private List<int> _availablePromptIndex = new List<int>{};

    public ListingActivity(string name, string description) : base(name, description){}

    public void RunListingActivity() {
        GetStartingMessage();
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        GetCountdownDelay(5);
        Console.WriteLine();
        GetUserInput();
        DisplayInputCount();
        GetFinishMessage();
    }
    private void GetRandomPrompt(){
        if (_availablePromptIndex.Count == 0){
            PopulatePromptList();
        }
        int index = _random.Next(_availablePromptIndex.Count);
        int listChoice = _availablePromptIndex[index];
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {_listPrompts[listChoice]} ---");
        _availablePromptIndex.RemoveAt(index);
    }

    private void PopulatePromptList()
    {
        for (int i = 0; i < _listPrompts.Count; i++)
        {
            _availablePromptIndex.Add(i);
        }
    }

    private void GetUserInput(){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetRunTime());
        do {
            Console.Write(">");
            _userInput.Add(Console.ReadLine());
        }while (DateTime.Now < (endTime));
    }

    private void DisplayInputCount(){
        Console.WriteLine($"You listed {_userInput.Count} items!");
    }
}