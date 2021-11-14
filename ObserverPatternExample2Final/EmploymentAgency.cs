using System;
using System.Collections.Generic;


namespace ObserverPatternExample2Final
{
    public class EmploymentAgency : IObservable<JobPost>
    {
        public EmploymentAgency()
        {
            observers = new List<IObserver<JobPost>>();
        }

        private List<IObserver<JobPost>> observers;

        public IDisposable Subscribe(IObserver<JobPost> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<JobPost>> _observers;
            private IObserver<JobPost> _observer;

            public Unsubscriber(List<IObserver<JobPost>> observers, IObserver<JobPost> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void PostJob(JobPost job)
        {
            foreach (var observer in observers)
            {
                if (job == null)
                    observer.OnError(new Exception());
                else
                    observer.OnNext(job);
            }
        }

        public void EndDay()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}