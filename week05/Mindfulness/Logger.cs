using System;
using System.Collections.Generic;
using System.IO;

public static class Logger
{
    private static readonly List<string> _entries = new List<string>();

    public static void AddEntry(string text)
    {
        _entries.Add(text);
    }

    public static void SaveSessionLog()
    {
        if (_entries.Count == 0) return;

        string folder = Path.Combine(AppContext.BaseDirectory, "logs");
        Directory.CreateDirectory(folder);

        string file = Path.Combine(folder, $"mindfulness_log_{DateTime.Now:yyyyMMdd}.txt");
        using var sw = new StreamWriter(file, append: true);
        sw.WriteLine($"=== Session {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
        foreach (string line in _entries)
        {
            sw.WriteLine(line);
        }
        sw.WriteLine();
    }
}
