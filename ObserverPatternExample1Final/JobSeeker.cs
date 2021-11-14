using System;

public class JobSeeker
{
    public string Name { get; set; }

    public JobSeeker(string name)
    {
        Name = name;
    }

    public void OnJobPosted(object source, JobEventArgs args)
    {
        Console.WriteLine($"{Name} has been notified that the job {args.JobPost.GetTitle()} has been posted");
    }
}