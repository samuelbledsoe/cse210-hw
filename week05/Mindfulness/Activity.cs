using System;
using System.Threading;

public abstract class Activity
{
    // Encapsulation: fields are protected only where children truly need access.
    protected string _name;
    protected string _description;
    protected int _duration;

    // Shared Random (one per process).
    protected static readonly Random _rand = new Random();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void Run()
    {
        StartMessage();
        DoActivity();     // Child-specific work
        EndMessage();
        // Log the completed run (exceeds)
        Logger.AddEntry($"{DateTime.Now:HH:mm:ss} | Completed: {_name} for {_duration}s");
    }

    protected abstract void DoActivity();

    protected void StartMessage()
    {
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = PromptDuration();

        Console.Write("Prepare to begin ");
        SpinnerPause(3);
        Console.WriteLine("\n");
    }

    protected void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        SpinnerPause(2);
        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        SpinnerPause(2);
        Console.WriteLine();
    }

    protected int PromptDuration()
    {
        while (true)
        {
            Console.Write("Enter duration in seconds (e.g., 30): ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int seconds) && seconds > 0) return seconds;
            Console.WriteLine("Please enter a positive integer.\n");
        }
    }

    // Criterion #9: spinner that uses backspaces to overwrite a single character.
    protected void SpinnerPause(int seconds)
    {
        char[] frames = new[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(120);
            Console.Write('\b'); // Backspace to overwrite next frame
            i++;
        }
    }

    // Countdown that overwrites the digits in place.
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            string digits = i.ToString();
            Console.Write(digits);
            Thread.Sleep(1000);
            Console.Write(new string('\b', digits.Length));
            Console.Write(new string(' ', digits.Length));
            Console.Write(new string('\b', digits.Length));
        }
    }

    // Helper for shuffling lists (Fisher–Yates).
    protected static void Shuffle<T>(T[] items)
    {
        for (int i = items.Length - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            (items[i], items[j]) = (items[j], items[i]);
        }
    }
}
