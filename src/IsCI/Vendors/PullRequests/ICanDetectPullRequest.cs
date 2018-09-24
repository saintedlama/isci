namespace IsCI.Vendors.PullRequests
{
    public interface ICanDetectPullRequest
    {
        bool CanDetectPullRequest();

        bool IsPullRequest();
    }
}
