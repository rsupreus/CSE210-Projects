public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";
    public string _mood = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string GetCsvString()
    {
        return $"{ConvertToCsv(_date)}," +
               $"{ConvertToCsv(_promptText)}," +
               $"{ConvertToCsv(_entryText)}," +
               $"{ConvertToCsv(_mood)}";
    }

    private string ConvertToCsv(string value)
    {
        string escapedValue = value.Replace("\"", "\"\"");

        return $"\"{escapedValue}\"";
    }
}