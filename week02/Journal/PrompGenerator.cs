public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I grateful for today?",
        "What is one goal I would like to work on tomorrow?",
        "What was I most grateful for today?",
        "What was a tender mercy I experiences today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int promptIndex = _random.Next(_prompts.Count);
        return _prompts[promptIndex];
    }
}