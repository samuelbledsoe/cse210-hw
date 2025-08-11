using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private readonly List<Goal> _goals = new();
        private readonly PlayerProfile _profile = new();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("==== Eternal Quest ====");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Show Score / Level / Badges");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? "";

                Console.WriteLine();
                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoals(); break;
                    case "3": RecordEvent(); break;
                    case "4": ShowScore(); break;
                    case "5": Save(); break;
                    case "6": Load(); break;
                    case "7": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("  1) Simple (one-and-done)");
            Console.WriteLine("  2) Eternal (repeat forever)");
            Console.WriteLine("  3) Checklist (complete N times, bonus on finish)");
            Console.WriteLine("  4) Progress (earn points each step toward a big goal)");
            Console.WriteLine("  5) Negative (penalty when logged)");
            Console.Write("Type: ");
            string type = Console.ReadLine() ?? "";

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            string desc = Console.ReadLine() ?? "";

            switch (type)
            {
                case "1":
                    Console.Write("Points for completing: ");
                    _goals.Add(new SimpleGoal(name, desc, ReadInt()));
                    break;
                case "2":
                    Console.Write("Points per occurrence: ");
                    _goals.Add(new EternalGoal(name, desc, ReadInt()));
                    break;
                case "3":
                    Console.Write("Points per occurrence: ");
                    int pts = ReadInt();
                    Console.Write("Times required: ");
                    int target = ReadInt();
                    Console.Write("Bonus on completion: ");
                    int bonus = ReadInt();
                    _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
                    break;
                case "4":
                    Console.Write("Points per step: ");
                    int pps = ReadInt();
                    Console.Write("Steps needed to complete: ");
                    int steps = ReadInt();
                    _goals.Add(new ProgressGoal(name, desc, pps, steps));
                    break;
                case "5":
                    Console.Write("Penalty points when logged: ");
                    _goals.Add(new NegativeGoal(name, desc, ReadInt()));
                    break;
                default:
                    Console.WriteLine("Unknown type.");
                    break;
            }

            Console.WriteLine("Goal created!");
        }

        private void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet. Create one!");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record yet.");
                return;
            }

            ListGoals();
            Console.Write("Choose goal number: ");
            int idx = ReadInt() - 1;
            if (idx < 0 || idx >= _goals.Count)
            {
                Console.WriteLine("Invalid goal.");
                return;
            }

            int delta = _goals[idx].RecordEvent();
            _profile.AddPoints(delta);

            string result = delta >= 0 ? $"{delta} points!" : $"{Math.Abs(delta)} point penalty!";
            Console.WriteLine($"Recorded. You {(delta >= 0 ? "earned" : "received a")} {result}");
        }

        private void ShowScore()
        {
            Console.WriteLine($"Score:   {_profile.TotalScore}");
            Console.WriteLine($"Level:   {_profile.Level}");
            Console.WriteLine("Badges:  " + (_profile.Badges.Count == 0 ? "(none yet)" : string.Join(", ", _profile.Badges)));
        }

        private void Save()
        {
            Console.Write("Enter filename to save (e.g., quest.txt): ");
            string? file = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(file)) { Console.WriteLine("Canceled."); return; }

            using var sw = new StreamWriter(file);
            sw.WriteLine(_profile.SerializeHeader());
            foreach (var g in _goals)
                sw.WriteLine(g.GetStringRepresentation());

            Console.WriteLine("Saved!");
        }

        private void Load()
        {
            Console.Write("Enter filename to load: ");
            string? file = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var lines = File.ReadAllLines(file);
            if (lines.Length == 0)
            {
                Console.WriteLine("Empty file.");
                return;
            }

            _goals.Clear();
            _profile.LoadHeader(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                _goals.Add(Goal.FromString(lines[i]));
            }

            Console.WriteLine("Loaded!");
        }

        private int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.Write("Enter a valid integer: ");
            }
        }
    }
}
