using System;

public class ListingActivity : Activity
{
    private readonly string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            name: "Listing Activity",
            description: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
          )
    { }

    protected override void DoActivity()
    {
        string[] promptBag = (string[])_prompts.Clone();
        Shuffle(promptBag);

        string prompt = promptBag[0];
        Console.WriteLine($"Prompt:\n> {prompt}\n");

        Console.Write("You’ll have a moment to think ");
        SpinnerPause(3);
        Console.Write("\nBegin listing in ");
        Countdown(3);
        Console.WriteLine();

        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("Item: ");
            // If time runs out while typing, the line will still be accepted.
            string item = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(item)) count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
        Logger.AddEntry($"  -> Listing items counted: {count}");
    }
}
