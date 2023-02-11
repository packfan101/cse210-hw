public class Word {
    
    //Variables
    private string _word;
    private string _renderedWord;
    private bool _isHidden = false;

    //Constructors
    public Word(string text) {
        _word = text;
        _renderedWord = _word;
    }

    //Behaviors
    public void HideWord() {
        _renderedWord = "";
        _isHidden = true;
        int count = _word.Length;
        for (int i = 0; i < count; i++) {
            _renderedWord = _renderedWord + "_";
        }
    }

    public string GetWord() {
        return _renderedWord;
    }

    public bool GetIsHidden() {
        return _isHidden;
    }
}