/*
Creativity and Exceeding Requirements:

1. The program stores the user's mood as additional information with each
   journal entry. The mood is displayed and preserved when saving and loading.

2. The journal is saved as a correctly formatted CSV file that can be opened
   in Excel. Every field is enclosed in quotation marks, and quotation marks
   inside the user's response are escaped by doubling them. The CSV loading
   process also correctly handles commas and quotation marks within entries.

3. The program validates menu choices and filenames and handles file errors
   without crashing.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            DisplayMenu();

            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    SaveJournal(journal);
                    break;

                case "4":
                    LoadJournal(journal);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nThank you for using the journal!");
                    break;

                default:
                    Console.WriteLine(
                        "\nPlease enter a number from 1 through 5.\n"
                    );
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
    }

    static void WriteNewEntry(
        Journal journal,
        PromptGenerator promptGenerator
    )
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");

        string response = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine(
                "Your journal response cannot be empty. Please try again."
            );

            Console.Write("> ");
            response = Console.ReadLine() ?? "";
        }

        Console.Write("How would you describe your mood today? ");
        string mood = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(mood))
        {
            mood = "Not specified";
        }

        Entry newEntry = new Entry();

        newEntry._date = DateTime.Now.ToShortDateString();
        newEntry._promptText = prompt;
        newEntry._entryText = response;
        newEntry._mood = mood;

        journal.AddEntry(newEntry);

        Console.WriteLine("\nYour journal entry was added.\n");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("\nWhat is the filename? ");
        string fileName = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("\nA filename is required.\n");
            return;
        }

        if (!fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".csv";
        }

        journal.SaveToFile(fileName);
    }
  static void LoadJournal(Journal journal)
    {
        Console.Write("\nWhat is the filename? ");
        string fileName = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("\nA filename is required.\n");
            return;
        }

        if (!fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".csv";
        }

        journal.LoadFromFile(fileName);
    }
}