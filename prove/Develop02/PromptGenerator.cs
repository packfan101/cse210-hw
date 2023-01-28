public class PromptGenerator
{
    Random _random = new Random();

    public List<string> _prompts = new List<string> 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Did I find someone I can serve today?",
        "Did I meet anyone new today?",
        "Did I do anything fun with my kids today?",
        "Did I work on any special projects today?"
    };

    public List<int> _availableIndex = new List<int>{};

    public void PopulateList()
    {
        for (int i = 0; i < _prompts.Count; i++)
        {
            _availableIndex.Add(i);
        }
    }    
    public string GeneratePrompt()
    {
        if (_availableIndex.Count == 0)
        {
            PopulateList();
        }
        int index = _random.Next(_availableIndex.Count);
        int listChoice = _availableIndex[index];
        Console.WriteLine(_prompts[listChoice]);
        _availableIndex.RemoveAt(index);
        return _prompts[listChoice];
    }
}