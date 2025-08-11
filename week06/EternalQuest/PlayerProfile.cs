using System;
using System.Collections.Generic;

namespace EternalQuest
{
    class PlayerProfile
    {
        private int _totalScore;
        private int _level;
        private readonly HashSet<string> _badges = new();
        private int PointsPerLevel => 1000;

        public int TotalScore => _totalScore;
        public int Level => _level;
        public IReadOnlyCollection<string> Badges => _badges;

        public void AddPoints(int delta)
        {
            _totalScore += delta;
            if (_totalScore < 0) _totalScore = 0;

            int newLevel = (_totalScore / PointsPerLevel) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                _badges.Add($"Level {_level} Reached");
                Console.WriteLine($">>> LEVEL UP! You are now Level {_level}!");
            }

            if (_totalScore >= 500 && !_badges.Contains("Bronze 500"))
                _badges.Add("Bronze 500");
            if (_totalScore >= 2000 && !_badges.Contains("Silver 2000"))
                _badges.Add("Silver 2000");
            if (_totalScore >= 5000 && !_badges.Contains("Gold 5000"))
                _badges.Add("Gold 5000");
        }

        public string SerializeHeader()
        {
            string badges = string.Join(',', _badges);
            return $"{_totalScore}|{_level}|{badges}";
        }

        public void LoadHeader(string header)
        {
            var parts = header.Split('|');
            _totalScore = int.Parse(parts[0]);
            _level = int.Parse(parts[1]);

            _badges.Clear();
            if (parts.Length > 2 && parts[2].Length > 0)
            {
                foreach (var b in parts[2].Split(',', StringSplitOptions.RemoveEmptyEntries))
                    _badges.Add(b);
            }
        }
    }
}
