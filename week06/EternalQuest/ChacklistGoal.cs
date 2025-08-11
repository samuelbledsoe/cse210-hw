namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _bonus;
        private int _currentCount;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonus = bonus;
            _currentCount = currentCount;
        }

        public override int RecordEvent()
        {
            if (IsComplete()) return 0;

            _currentCount++;
            int earned = Points;

            if (IsComplete())
            {
                earned += _bonus;
            }

            return earned;
        }

        public override bool IsComplete() => _currentCount >= _targetCount;

        public override string GetDetailsString()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) — {Points} pts (Completed {_currentCount}/{_targetCount}, Bonus: {_bonus})";
        }

        public override string GetStringRepresentation()
            => $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}
