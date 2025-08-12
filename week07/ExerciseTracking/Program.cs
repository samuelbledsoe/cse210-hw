using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create at least one of each activity
            var activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), minutes: 30, distanceMiles: 3.0),
                new Cycling(new DateTime(2022, 11, 3), minutes: 30, speedMph: 12.0),
                new Swimming(new DateTime(2022, 11, 3), minutes: 30, laps: 64) // 64 laps ~ 1.98 miles with 0.62 factor
            };

            // Polymorphism: one list, same call, different behavior
            foreach (var a in activities)
            {
                Console.WriteLine(a.GetSummary());
            }
        }
    }
}
