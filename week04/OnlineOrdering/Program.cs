using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Cook Steak", "Chef Sam", 600);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Tried it—amazing!"));
        video1.AddComment(new Comment("Carol", "Looks delicious."));
        videos.Add(video1);

        Video video2 = new Video("Learn C# in 10 Minutes", "Code Master", 720);
        video2.AddComment(new Comment("Dave", "Very helpful."));
        video2.AddComment(new Comment("Eve", "Can you do Java next?"));
        video2.AddComment(new Comment("Frank", "I passed my test thanks to this!"));
        videos.Add(video2);

        Video video3 = new Video("Top 10 Movies 2023", "Movie Buff", 480);
        video3.AddComment(new Comment("Grace", "Love #3 on the list!"));
        video3.AddComment(new Comment("Heidi", "Not sure about #1 though..."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        foreach (Comment c in _comments)
        {
            Console.WriteLine($"- {c.GetCommenterName()}: {c.GetText()}");
        }
    }
}

class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetText()
    {
        return _text;
    }
}
