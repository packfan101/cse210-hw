public class Scripture {

    //variables
    private string _verse;
    private string _reference;
    private int _wordHiddenCount = 0;
    private List<Word> _wordList = new List<Word>();
    private string _renderedVerse = string.Empty;
    private List<int> _availableIndex = new List<int>{};
    private Random _random = new Random();

    //Constructors
    public Scripture(string book, int chapter, int verse, string verseText) {
        _verse = verseText;
        Reference reference = new Reference(book, chapter, verse);
        CreateWordList();
        _reference = reference.SingleVerseDisplay();
    }

    public Scripture(string book, int chapter, int verse, int endVerse, string verseText) {
        _verse = verseText;
        Reference reference = new Reference(book, chapter, verse, endVerse);
        CreateWordList();
        _reference = reference.MultipleVerseDisplay();   
    }

    //Behaviors
    private void CreateWordList() {
        string[] words = _verse.Split(' ');
        foreach (var text in words) {
            Word wordEntry = new Word(text);
            _wordList.Add(wordEntry);
        }
    }

    public string DisplayFullScripture() {
        return $"{_reference} - {_verse}";
    }

    public string DisplayRenderedScripture() {
        _renderedVerse = "";
        HideRandomWords();
        GetRenderedVerse();
        return $"{_reference} -{_renderedVerse}";
    }

    private void GetRenderedVerse() {
        foreach (Word word in _wordList) {
            _renderedVerse = _renderedVerse + ' ' + word.GetWord();
        }
    }

    private void HideRandomWords() {
        for (int i = 0; i < 3; i++) {
            if (_availableIndex.Count == 0)
            {
                PopulateRandomOptionsList();
            }
            int index = _random.Next(_availableIndex.Count);
            int listChoice = _availableIndex[index];
            _availableIndex.RemoveAt(index);
            _wordList[listChoice].HideWord();
            if (_wordList[listChoice].GetIsHidden() == true) {
                _wordHiddenCount++;
            }
        }        
    }

    private void PopulateRandomOptionsList()
    {
        for (int i = 0; i < _wordList.Count; i++)
        {
            _availableIndex.Add(i);
        }
    }

    public int GetIsHiddenCount(){
        return _wordList.Count - _wordHiddenCount;
    }
}