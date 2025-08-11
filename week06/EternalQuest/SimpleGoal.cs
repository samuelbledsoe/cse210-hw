namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (_isComplete) return 0;
            _isComplete = true;
            return Points;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStringRepresentation()
            => $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }
}
