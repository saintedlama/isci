using System;

namespace IsCI.Vendors.PullRequests
{
    public class PullRequestEnvironmentVariableIsDefined : ICanDetectPullRequest
    {
        private readonly string[] _environmentVariables;

        public PullRequestEnvironmentVariableIsDefined(params string[] environmentVariables)
        {
            _environmentVariables = environmentVariables;
        }

        public bool CanDetectPullRequest() => true;

        public bool IsPullRequest()
        {
            foreach (var environmentVariable in _environmentVariables)
            {
                var environmentVariableValue = Environment.GetEnvironmentVariable(environmentVariable);

                if (!String.IsNullOrWhiteSpace(environmentVariableValue))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
