using System;

namespace IsCI.Vendors.PullRequests
{
    public class PullRequestEnvironmentVariableHasValue : ICanDetectPullRequest
    {
        private string _environmentVariableName;
        private string _environmentVariableValue;

        public PullRequestEnvironmentVariableHasValue(string environmentVariableName, string environmentVariableValue)
        {
            _environmentVariableName = environmentVariableName;
            _environmentVariableValue = environmentVariableValue;
        }
        public bool CanDetectPullRequest() => true;

        public bool IsPullRequest()
        {
            var environmentVariableValue = Environment.GetEnvironmentVariable(_environmentVariableName);

            return _environmentVariableValue.Equals(environmentVariableValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
