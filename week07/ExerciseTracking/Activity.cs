using System;
using System.Globalization;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        // Encapsulation: member variables are private
        private DateTime _date;
        private int _minutes;

        protected Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Protected getters for derived classes (no public setters)
        protected DateTime Date => _date;
        protected int Minutes => _minutes;

        // Polymorphism: abstract methods must be overridden
        public abstract double GetDistance(); // miles
        public abstract double GetSpeed();    // mph
        public abstract double GetPace();     // minutes per mile

        // Virtual method in base class that uses the abstract methods
        public virtual string GetSummary()
        {
            string dateStr = Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            double distance = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();

            return $"{dateStr} {GetType().Name} ({Minutes} min): " +
                   $"Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
        }
    }
}
