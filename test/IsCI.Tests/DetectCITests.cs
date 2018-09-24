using System;
using Xunit;
using static IsCI.DetectCI;
using System.Collections.Generic;
using Xunit.Abstractions;
using System.IO;
using System.Linq;

namespace IsCI.Tests
{
    public class DetectCITests : IDisposable
    {
        private Action _unset;
        private readonly ITestOutputHelper _output;

        public DetectCITests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ShouldDetectAppveyor()
        {
            SetEnvironmentVariables(("APPVEYOR", "true"));

            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = GetCIVendor();
            Assert.Equal("APPVEYOR", vendor.Constant);

            var isPr = IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectAppveyorPullRequest()
        {
            SetEnvironmentVariables(("APPVEYOR", "true"), ("APPVEYOR_PULL_REQUEST_NUMBER", "42"));

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldDetectBuildkit()
        {
            SetEnvironmentVariables(("BUILDKITE", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("BUILDKITE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectBuildkitPullRequest()
        {
            SetEnvironmentVariables(("BUILDKITE", "true"), ("BUILDKITE_PULL_REQUEST", "42"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("BUILDKITE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldDetectCircleCi()
        {
            SetEnvironmentVariables(("CIRCLECI", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("CIRCLE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectCircleCiPullRequest()
        {
            SetEnvironmentVariables(("CIRCLECI", "true"), ("CIRCLE_PULL_REQUEST", "42"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("CIRCLE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldDetectCirrusCi()
        {
            SetEnvironmentVariables(("CIRRUS_CI", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("CIRRUS", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectCirrusCiPullRequest()
        {
            SetEnvironmentVariables(("CIRRUS_CI", "true"), ("CIRRUS_PR", "42"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("CIRRUS", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldDetectSemaphore()
        {
            SetEnvironmentVariables(("SEMAPHORE", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("SEMAPHORE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectSemaphorePullRequest()
        {
            SetEnvironmentVariables(("SEMAPHORE", "true"), ("PULL_REQUEST_NUMBER", "42"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("SEMAPHORE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldDetectShippable()
        {
            SetEnvironmentVariables(("SHIPPABLE", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("SHIPPABLE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectShippablePullRequest()
        {
            SetEnvironmentVariables(("SHIPPABLE", "true"), ("IS_PULL_REQUEST", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("SHIPPABLE", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldDetectTravisCI()
        {
            SetEnvironmentVariables(("TRAVIS", "true"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("TRAVIS", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.False(isPr);
        }

        [Fact]
        public void ShouldDetectTravisPullRequest()
        {
            SetEnvironmentVariables(("TRAVIS", "true"), ("TRAVIS_PULL_REQUEST", "42"));
            var ci = DetectCI.IsCI();
            Assert.True(ci);

            var vendor = DetectCI.GetCIVendor();
            Assert.Equal("TRAVIS", vendor.Constant);

            var isPr = DetectCI.IsPullRequest();
            Assert.True(isPr);
        }

        [Fact]
        public void ShouldAllowEnumeratingCiVendors()
        {
            Assert.All(DetectCI.Vendors, vendor => {
                Assert.NotNull(vendor.Name);
                Assert.NotNull(vendor.Constant);
            });

            // This part of the test is for generating the "Supported CI Vendors" README section
            // var markdownLines = DetectCI.Vendors
            //    .OrderBy(v => v.Name)
            //    .Select(vendor => $"{vendor.Name} | {vendor.Constant} | {(vendor.CanDetectPullRequest()?"✅":"🚫")}");
            //
            // File.WriteAllText("supported_cis.md", String.Join("\n", markdownLines));
        }

        private void SetEnvironmentVariables(params ValueTuple<string, string>[] environmentVariables)
        {
            foreach (var environmentVariable in environmentVariables)
            {
                Environment.SetEnvironmentVariable(environmentVariable.Item1, environmentVariable.Item2);
            }

            _unset = () =>
            {
                foreach (var environmentVariable in environmentVariables)
                {
                    Environment.SetEnvironmentVariable(environmentVariable.Item1, null);
                }
            };
        }

        public void Dispose()
        {
            if (_unset != null)
            {
                _unset();
            }
        }
    }
}
