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


