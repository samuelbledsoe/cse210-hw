using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            name: "Breathing Activity",
            description: "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
          )
    { }

    protected override void DoActivity()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);

        // Typical pacing (can be adjusted): in 4s, out 6s.
        int inSeconds = 4;
        int outSeconds = 6;

        while (DateTime.Now < end)
        {
            Console.Write("Breathe in... ");
            Countdown(inSeconds);
            Console.WriteLine();

            if (DateTime.Now >= end) break;

            Console.Write("Breathe out... ");
            Countdown(outSeconds);
            Console.WriteLine();
        }
    }
}
