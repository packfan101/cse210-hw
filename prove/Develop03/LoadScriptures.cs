public class LoadScriptures {

    //Variables
    private List<Scripture> scriptureList = new List<Scripture>();
    private string _fileName;
    private Random _random = new Random();
    private List<int> _availableIndex = new List<int>{};

    //Behaviors
    private void AddScripture(string book, int chapter, int verse, string verseText) {
        Scripture newScripture = new Scripture(book, chapter, verse, verseText);
        scriptureList.Add(newScripture);
    }
    
    private void AddMultiVerseScripture(string book, int chapter, int verse, int endVerse, string verseText) {
        Scripture newScripture = new Scripture(book, chapter, verse, endVerse, verseText);
        scriptureList.Add(newScripture);
    }
    
    public void LoadFromFile(){
        _fileName = "scriptures.txt";
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines) {
            string[] parts = line.Split("~");
            int chapter = int.Parse(parts[1]);
            int verse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            if (endVerse == 0){
                AddScripture(parts[0], chapter, verse, parts[4]);
            } else{
                AddMultiVerseScripture(parts[0], chapter, verse, endVerse, parts[4]);
            }
        }
    }

    public Scripture GetRandomScripture() {
        if (_availableIndex.Count == 0)
            {
                PopulateRandomOptionsList();
            }
            int index = _random.Next(_availableIndex.Count);
            int listChoice = _availableIndex[index];
            _availableIndex.RemoveAt(index);
            return scriptureList[listChoice];
    }
    private void PopulateRandomOptionsList()
    {
        for (int i = 0; i < scriptureList.Count; i++)
        {
            _availableIndex.Add(i);
        }
    }
}