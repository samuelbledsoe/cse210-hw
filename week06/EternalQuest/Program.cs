using System;

namespace EternalQuest
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Welcome to Eternal Quest! 🌟");
            new GoalManager().Run();
            Console.WriteLine("Goodbye!");
        }
    }
}

/*
===========================
EXCEEDS REQUIREMENTS NOTES
===========================
1) Gamification:
   - Leveling system: Levels increase every 1000 points; "LEVEL UP!" notification.
   - Badges: Bronze(500), Silver(2000), Gold(5000) plus “Level X Reached”.

2) Additional Goal Types:
   - ProgressGoal: earn points per step toward a large target; completes after N steps.
   - NegativeGoal: logs a bad habit and subtracts points.

3) Clean OOP:
   - Inheritance: Goal base class; SimpleGoal, EternalGoal, ChecklistGoal, ProgressGoal, NegativeGoal derive from it.
   - Polymorphism: RecordEvent, IsComplete, GetDetailsString, GetStringRepresentation overridden appropriately.
   - Encapsulation: private fields + public read-only properties; save/load uses factory method.

4) Persistence:
   - Save/Load to plain text with a simple format (first line profile; rest goals).
*/
