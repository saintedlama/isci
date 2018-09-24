using System;

namespace IsCI.Vendors
{
    public class EnvironmentVariableIsDefined : ICanDetectVendor
    {
        private readonly string[] _environmentVariables;

        public EnvironmentVariableIsDefined(params string[] environmentVariables)
        {
            _environmentVariables = environmentVariables;
        }

        public bool IsVendor()
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
