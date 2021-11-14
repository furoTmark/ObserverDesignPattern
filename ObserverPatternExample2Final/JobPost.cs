namespace ObserverPatternExample2Final
{
    public class JobPost
    {
        private string _title;

        public JobPost(string title)
        {
            _title = title;
        }

        public string GetTitle() => _title;
    }
}