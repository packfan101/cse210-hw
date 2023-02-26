public class ReflectionActivity : Activity {
    private List<string> _prompts = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    
    private Random _random = new Random();
    private List<int> _availablePromptIndex = new List<int>{};
    private List<int> _availableQuestionIndex = new List<int>{};
    public ReflectionActivity(string name, string description) : base(name, description){}

    public void RunReflectionActivity() {
        GetStartingMessage();
        GetRandomPrompt();
        Console.Write("\nWhen you have an experience in mind, press enter to continue. ");
        Console.ReadLine();
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetRunTime());
        do {
            GetRandomQuestion();
            GetAnimatedDelay(10);
        }while (DateTime.Now < (endTime));

        GetFinishMessage();
    }

    private string GetRandomPrompt(){
        if (_availablePromptIndex.Count == 0){
            PopulatePromptList();
        }
        int index = _random.Next(_availablePromptIndex.Count);
        int listChoice = _availablePromptIndex[index];
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"{_prompts[listChoice]}");
        _availablePromptIndex.RemoveAt(index);
        return _prompts[listChoice];
    }

    private string GetRandomQuestion() {
        if (_availableQuestionIndex.Count == 0){
            PopulateQuestionList();
        }
        int index = _random.Next(_availableQuestionIndex.Count);
        int listChoice = _availableQuestionIndex[index];
        Console.WriteLine(_questions[listChoice]);
        _availableQuestionIndex.RemoveAt(index);
        return _questions[listChoice];
    }
    
    private void PopulatePromptList()
    {
        for (int i = 0; i < _prompts.Count; i++)
        {
            _availablePromptIndex.Add(i);
        }
    }    

    private void PopulateQuestionList()
    {
        for (int i = 0; i < _questions.Count; i++)
        {
            _availableQuestionIndex.Add(i);
        }
    }    
}