using System;

public class EmploymentAgency
{
    public event EventHandler<JobEventArgs> Notify;

    public void AddJob(string position)
    {
        if (Notify != null)
        {
            Notify(this, new JobEventArgs(new JobPost(position)));
        }
    }
}