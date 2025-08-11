using System;
using System.IO;

namespace EternalQuest
{
    abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        public abstract int RecordEvent();
        public abstract bool IsComplete();

        public virtual string GetDetailsString()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) — {Points} pts";
        }

        public abstract string GetStringRepresentation();

        public static Goal FromString(string line)
        {
            var parts = line.Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                case "EternalGoal":
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                case "ChecklistGoal":
                    return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                case "ProgressGoal":
                    return new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]));
                case "NegativeGoal":
                    return new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                default:
                    throw new InvalidDataException($"Unknown goal type: {type}");
            }
        }
    }
}
