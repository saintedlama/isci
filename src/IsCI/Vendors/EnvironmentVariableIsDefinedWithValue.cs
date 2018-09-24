using System;

namespace IsCI.Vendors
{
    public class EnvironmentVariableIsDefinedWithValue : ICanDetectVendor
    {
        private readonly string _environmentVariable;
        private readonly string _environmentVariableValue;

        public EnvironmentVariableIsDefinedWithValue(string environmentVariable, string environmentVariableValue)
        {
            _environmentVariable = environmentVariable;
            _environmentVariableValue = environmentVariableValue;
        }

        public bool IsVendor()
        {
            var environmentVariableValue = Environment.GetEnvironmentVariable(_environmentVariable);

            if (!String.IsNullOrWhiteSpace(environmentVariableValue) && _environmentVariableValue.Equals(environmentVariableValue, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
