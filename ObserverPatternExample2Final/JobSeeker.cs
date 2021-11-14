using System;

namespace ObserverPatternExample2Final
{
    public class JobSeeker : IObserver<JobPost>
    {
        private IDisposable unsubscriber;

        public string Name { get; set; }
        public JobSeeker(string name)
        {
            Name = name;
        }

        public void Subscribe(IObservable<JobPost> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }
        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Console.WriteLine("{0} has completed the job search", Name);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("{0} has encountered an error", Name);
        }

        public void OnNext(JobPost value)
        {
            Console.WriteLine("{0} has found a job: {1}", Name, value.GetTitle());
        }
    }
}