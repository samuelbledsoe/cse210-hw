namespace EternalQuest
{
    class ProgressGoal : Goal
    {
        private int _stepsNeeded;
        private int _currentSteps;

        public ProgressGoal(string name, string description, int pointsPerStep, int stepsNeeded, int currentSteps = 0)
            : base(name, description, pointsPerStep)
        {
            _stepsNeeded = stepsNeeded;
            _currentSteps = currentSteps;
        }

        public override int RecordEvent()
        {
            if (IsComplete()) return 0;
            _currentSteps++;
            return Points;
        }

        public override bool IsComplete() => _currentSteps >= _stepsNeeded;

        public override string GetDetailsString()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) — {Points} pts/step (Progress: {_currentSteps}/{_stepsNeeded})";
        }

        public override string GetStringRepresentation()
            => $"ProgressGoal|{Name}|{Description}|{Points}|{_stepsNeeded}|{_currentSteps}";
    }
}
