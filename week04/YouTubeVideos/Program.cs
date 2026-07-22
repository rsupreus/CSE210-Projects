using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "How to Learn C#",
            "Code Academy",
            620
        );

        video1.AddComment(
            new Comment("Maria", "This explanation was very helpful!")
        );
        video1.AddComment(
            new Comment("James", "Can you make a video about classes next?")
        );
        video1.AddComment(
            new Comment("Taylor", "I finally understand variables.")
        );

        Video video2 = new Video(
            "Easy Chocolate Cake Recipe",
            "Baking with Sarah",
            480
        );

        video2.AddComment(
            new Comment("Linda", "I made this cake and my family loved it.")
        );
        video2.AddComment(
            new Comment("Robert", "Can I use almond milk instead?")
        );
        video2.AddComment(
            new Comment("Emily", "The instructions were easy to follow.")
        );
        video2.AddComment(
            new Comment("David", "This is now my favorite cake recipe!")
        );

        Video video3 = new Video(
            "Beginner Home Workout",
            "Healthy Living",
            900
        );

        video3.AddComment(
            new Comment("Chris", "This was a great workout.")
        );
        video3.AddComment(
            new Comment("Angela", "I appreciate the beginner-friendly exercises.")
        );
        video3.AddComment(
            new Comment("Michael", "I completed the entire workout today!")
        );

        Video video4 = new Video(
            "Top 10 Travel Destinations",
            "Adventure World",
            750
        );

        video4.AddComment(
            new Comment("Sophia", "Japan is at the top of my travel list.")
        );
        video4.AddComment(
            new Comment("Daniel", "I would love to visit Iceland.")
        );
        video4.AddComment(
            new Comment("Olivia", "These locations are beautiful!")
        );

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}