public class Entry
{
    public string _prompt;
    public string _date;
    public string _response;

    public Entry()
    {  
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"{_response}\n");
    }
}