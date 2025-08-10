using System;
using System.IO;

public class Program
{
    /*
     * EXCEEDS REQUIREMENTS:
     * 1) Added a fourth activity: VisualizationActivity.
     * 2) Session logging to /logs/mindfulness_log_YYYYMMDD.txt via Logger.
     * 3) No-repeat prompt/question pools within a run (bags are shuffled and consumed).
     * 4) Backspace spinner and countdown overwrite (criterion #9).
     *
     * STYLE:
     * - Classes in separate files with matching names.
     * - TitleCase for classes/methods; _underscoreCamelCase for fields; camelCase for locals.
     */

    public static void Main()
    {
        Console.Clear();
        Console.WriteLine("Mindfulness Program (W05)\n");

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("  1) Breathing");
            Console.WriteLine("  2) Reflection");
            Console.WriteLine("  3) Listing");
            Console.WriteLine("  4) Visualization (extra)");
            Console.WriteLine("  0) Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            try
            {
                Activity activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => new VisualizationActivity(),
                    "0" => null,
                    _   => throw new ArgumentException("Please choose 0–4.")
                };

                if (activity == null)
                {
                    keepRunning = false;
                    break;
                }

                activity.Run();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}\n");
            }
        }

        // Save session log on exit (exceeds).
        try
        {
            Logger.SaveSessionLog();
            Console.WriteLine("Goodbye!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not write log: {ex.Message}");
        }
    }
}
