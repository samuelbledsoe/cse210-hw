using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // Using miles per the assignment hint (0.62 ≈ miles per km)
            // distance (miles) = laps * 50 / 1000 * 0.62
            return _laps * 50.0 / 1000.0 * 0.62;
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            if (Minutes <= 0) return 0;
            return (distance / Minutes) * 60.0;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            if (distance <= 0) return 0;
            return Minutes / distance;
        }
    }
}
