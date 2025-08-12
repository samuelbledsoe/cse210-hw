using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distanceMiles;

        public Running(DateTime date, int minutes, double distanceMiles)
            : base(date, minutes)
        {
            _distanceMiles = distanceMiles;
        }

        public override double GetDistance() => _distanceMiles;

        public override double GetSpeed()
        {
            if (Minutes <= 0) return 0;
            return (_distanceMiles / Minutes) * 60.0;
        }

        public override double GetPace()
        {
            if (_distanceMiles <= 0) return 0;
            return Minutes / _distanceMiles;
        }
    }
}
