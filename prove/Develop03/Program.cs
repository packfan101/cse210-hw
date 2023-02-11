using System;

class Program
{
    static void Main(string[] args)
    {
        string _continue = "";
        LoadScriptures loadScripture = new LoadScriptures();
        loadScripture.LoadFromFile();
        Scripture scripture = loadScripture.GetRandomScripture();
        
        
        
        Console.Clear();
        Console.WriteLine(scripture.DisplayFullScripture());
        Console.WriteLine();
        Console.Write("Press enter to continue or type 'quit' to finish: ");
        _continue = Console.ReadLine();
        while (_continue != "quit" && scripture.GetIsHiddenCount() !> 0)
         {
            Console.Clear();
            Console.WriteLine(scripture.DisplayRenderedScripture());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            _continue = Console.ReadLine();
        }         
    }
}