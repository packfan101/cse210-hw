public class Journal
{
    public string _fileName;
    public string _username;
    public List<Entry> _entries = new List<Entry>();
    public PromptGenerator _prompt1 = new PromptGenerator();

    public bool _fileIsLoaded = false;

    public void Display()
    {
        foreach (Entry _entry in _entries)
        {
            _entry.DisplayEntry();
        }
    }

    public void SaveToFile()
    {
        if (_fileIsLoaded == false)
        {
            Console.Write("Please provide a filename: ");
            _fileName = _username + Console.ReadLine();
            if (new FileInfo(_fileName).Length == 0)
            {
                using (StreamWriter _outputFile = new StreamWriter(_fileName))
                {
                    foreach (Entry _entry in _entries)
                    {
                        _outputFile.WriteLine($"Date: ~{_entry._date}~ - Prompt: ~{_entry._prompt}~{_entry._response}");
                    }
                }
                Console.WriteLine("\nFile Saved Successfully\n"); 
            }
            else
            {
                Console.Write("This file is not empty. Would you like to (append/overwrite/cancel)? ");
                string _action = Console.ReadLine();
                if (_action == "append")
                {
                    using (StreamWriter _outputFile = new StreamWriter(_fileName, append: true))
                    {
                        foreach (Entry _entry in _entries)
                        {
                            _outputFile.WriteLine($"Date: ~{_entry._date}~ - Prompt: ~{_entry._prompt}~{_entry._response}");
                        }
                    }
                    Console.WriteLine("\nFile Saved Successfully\n"); 
                }

                else if (_action == "overwrite")
                {
                    using (StreamWriter outputFile = new StreamWriter(_fileName))
                    {
                        foreach (Entry _entry in _entries)
                        {
                            outputFile.WriteLine($"Date: ~{_entry._date}~ - Prompt: ~{_entry._prompt}~{_entry._response}");
                        }
                    }
                    Console.WriteLine("\nSave Procedure Cancelled\n"); 
                }
            }
        }
        else
        {
            Console.Write("Would you like to save to the file that was loaded? (y/n) ");
            string _loadNewFile = Console.ReadLine();
            if (_loadNewFile == "y")
            {
                using (StreamWriter _outputFile = new StreamWriter(_fileName))
                {
                    foreach (Entry _entry in _entries)
                    {
                        _outputFile.WriteLine($"Date: ~{_entry._date}~ - Prompt: ~{_entry._prompt}~{_entry._response}");
                    }
                }
            }
            else
            {
                Console.Write("Please provide a filename: ");
                _fileName = _username + Console.ReadLine();
                using (StreamWriter _outputFile = new StreamWriter(_fileName))
                {
                    foreach (Entry _entry in _entries)
                    {
                        _outputFile.WriteLine($"Date: ~{_entry._date}~ - Prompt: ~{_entry._prompt}~{_entry._response}");
                    }
                } 
            }
            Console.WriteLine("\nFile Saved Successfully\n");
            
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Please provide a filename: ");
        _fileName = _username + Console.ReadLine();
        if (File.Exists(_fileName))
        {
            string[] _lines = System.IO.File.ReadAllLines(_fileName);
            foreach (string _line in _lines)
            {
                string[] _parts = _line.Split("~");
                Entry _entryadd = new Entry();
                _entryadd._date = _parts[1];
                _entryadd._prompt = _parts[3];
                _entryadd._response = _parts[4];
                _entries.Add(_entryadd);           
            }
            _fileIsLoaded = true;
            Console.WriteLine("\nFile Loaded Successfully\n");
        }

        else
        {
            Console.WriteLine("\nThat file does not exist. Please try again.\n");
        }
        
    }

    public void AddEntry()
    {
        Entry _entryadd = new Entry();
        _entryadd._prompt = _prompt1.GeneratePrompt();
        DateTime currentTime = DateTime.Now;
        _entryadd._date = currentTime.ToShortDateString();
        Console.Write("> ");
        _entryadd._response = Console.ReadLine();
        _entries.Add(_entryadd);
        Console.WriteLine("\nEntry Successfully Added To Memory\n");
    }
}