public class JobEventArgs
{
    public JobEventArgs(JobPost jobPost)
    {
        JobPost = jobPost;
    }

    public JobPost JobPost { get; private set; }
}