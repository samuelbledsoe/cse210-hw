using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public void Display()
    {
        Console.WriteLine($"{_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
}
