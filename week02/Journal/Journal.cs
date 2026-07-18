using System.Text;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal does not contain any entries.\n");
            return;
        }

        Console.WriteLine();

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using StreamWriter outputFile = new StreamWriter(fileName);

            // CSV column headings
            outputFile.WriteLine("Date,Prompt,Response,Mood");

            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetCsvString());
            }

            Console.WriteLine(
                $"\nJournal successfully saved to {fileName}.\n"
            );
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"\nThe journal could not be saved: {exception.Message}\n"
            );
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);

            _entries.Clear();

            // Start at 1 to skip the CSV header row.
            for (int i = 1; i < lines.Length; i++)
            {
                List<string> values = ParseCsvLine(lines[i]);

                if (values.Count == 4)
                {
                    Entry entry = new Entry();

                    entry._date = values[0];
                    entry._promptText = values[1];
                    entry._entryText = values[2];
                    entry._mood = values[3];

                    _entries.Add(entry);
                }
            }

            Console.WriteLine(
                $"\nJournal successfully loaded from {fileName}."
            );

            Console.WriteLine(
                $"{_entries.Count} journal entries were loaded.\n"
            );
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(
                $"\nThe file \"{fileName}\" could not be found.\n"
            );
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"\nThe journal could not be loaded: {exception.Message}\n"
            );
        }
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> values = new List<string>();
        StringBuilder currentValue = new StringBuilder();

        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char currentCharacter = line[i];

            if (currentCharacter == '"')
            {
                // Two quotation marks inside a quoted field represent
                // one quotation mark in the original text.
                if (
                    insideQuotes &&
                    i + 1 < line.Length &&
                    line[i + 1] == '"'
                )
                {
                    currentValue.Append('"');
                    i++;
                }
                else
                {
                    insideQuotes = !insideQuotes;
                }
            }
            else if (currentCharacter == ',' && !insideQuotes)
            {
                values.Add(currentValue.ToString());
                currentValue.Clear();
            }
            else
            {
                currentValue.Append(currentCharacter);
            }
        }

        values.Add(currentValue.ToString());

        return values;
    }
}