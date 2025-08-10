using System;

public class ReflectionActivity : Activity
{
    private readonly string[] _prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] _questions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than times you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this that applies to other situations?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base(
            name: "Reflection Activity",
            description: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
          )
    { }

    protected override void DoActivity()
    {
        // No-repeat within this run (exceeds): shuffle then iterate.
        string[] promptBag = (string[])_prompts.Clone();
        Shuffle(promptBag);

        string[] questionBag = (string[])_questions.Clone();
        Shuffle(questionBag);

        // Show one prompt.
        string prompt = promptBag[0];
        Console.WriteLine($"Prompt:\n> {prompt}\n");
        Console.Write("Focus on this experience ");
        SpinnerPause(5);
        Console.WriteLine("\n");

        DateTime end = DateTime.Now.AddSeconds(_duration);
        int qIndex = 0;

        while (DateTime.Now < end)
        {
            if (qIndex >= questionBag.Length)
            {
                // Re-shuffle when we exhaust the bag (still no immediate repeats within a cycle).
                Shuffle(questionBag);
                qIndex = 0;
            }

            string question = questionBag[qIndex++];
            Console.WriteLine(question);
            SpinnerPause(6); // pause to reflect
            Console.WriteLine();
        }
    }
}
