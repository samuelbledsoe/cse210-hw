using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        // Store speed as specified for Cycling
        private double _speedMph;

        public Cycling(DateTime date, int minutes, double speedMph)
            : base(date, minutes)
        {
            _speedMph = speedMph;
        }

        public override double GetDistance()
        {
            // distance = speed * time_hours
            return _speedMph * (Minutes / 60.0);
        }

        public override double GetSpeed() => _speedMph;

        public override double GetPace()
        {
            if (_speedMph <= 0) return 0;
            // pace (min/mile) = 60 / speed
            return 60.0 / _speedMph;
        }
    }
}
