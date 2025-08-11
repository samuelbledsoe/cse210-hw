namespace EternalQuest
{
    class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int penaltyPoints)
            : base(name, description, -System.Math.Abs(penaltyPoints)) { }

        public override int RecordEvent() => Points;
        public override bool IsComplete() => false;

        public override string GetDetailsString()
            => $"[ ] {Name} ({Description}) — PENALTY {System.Math.Abs(Points)} pts";

        public override string GetStringRepresentation()
            => $"NegativeGoal|{Name}|{Description}|{System.Math.Abs(Points)}";
    }
}
