using System;

public class VisualizationActivity : Activity
{
    public VisualizationActivity()
        : base(
            name: "Visualization Activity",
            description: "This activity guides a calm visualization to reduce stress and center your focus."
          )
    { }

    protected override void DoActivity()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);

        string[] steps =
        {
            "Picture a peaceful place you know well.",
            "Notice three things you can see there.",
            "Notice two things you can feel (temperature, breeze, surfaces).",
            "Notice one thing you can hear.",
            "Breathe gently and hold that picture in your mind."
        };

        int sIndex = 0;
        while (DateTime.Now < end)
        {
            Console.WriteLine(steps[sIndex % steps.Length]);
            SpinnerPause(6);
            Console.WriteLine();
            sIndex++;
        }
    }
}
