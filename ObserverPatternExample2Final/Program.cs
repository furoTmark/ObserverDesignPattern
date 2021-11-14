using System;

namespace ObserverPatternExample2Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EmploymentAgency agency = new EmploymentAgency();
            JobSeeker seeker1 = new JobSeeker("Ana");
            seeker1.Subscribe(agency);
            JobSeeker seeker2 = new JobSeeker("Ion");
            seeker2.Subscribe(agency);

            agency.PostJob(new JobPost("Software Tester"));
            seeker1.Unsubscribe();
            agency.PostJob(new JobPost("Busines Analyst"));
            agency.PostJob(null);
            agency.EndDay();
        }
    }
}
