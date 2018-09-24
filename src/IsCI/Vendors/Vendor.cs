using System;
using System.Collections.Generic;
using IsCI.Vendors.PullRequests;

namespace IsCI.Vendors
{
    public class Vendor : ICanDetectVendor, ICanDetectPullRequest
    {
        public string Name { get; set; }
        public string Constant { get; set; }
        public ICanDetectVendor DetectVendor { get; set; }
        public ICanDetectPullRequest DetectPullRequest { get; set; }

        public Vendor()
        {
            DetectVendor = new CannotDetectVendor();
            DetectPullRequest = new CannotDetectPullRequests();
        }

        public bool IsVendor() => DetectVendor.IsVendor();
        
        public bool CanDetectPullRequest() => DetectPullRequest.CanDetectPullRequest();
        
        public bool IsPullRequest() => DetectPullRequest.IsPullRequest();

        class CannotDetectVendor : ICanDetectVendor
        {
            public bool IsVendor() => false;
        }

        class CannotDetectPullRequests : ICanDetectPullRequest
        {
            public bool CanDetectPullRequest() => false;
            public bool IsPullRequest() => false;
        }
    }
}
