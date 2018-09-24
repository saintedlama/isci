using System;
using System.Collections.Generic;
using System.Linq;
using IsCI.Vendors;

namespace IsCI
{
    public static class DetectCI
    {
        public static bool IsPullRequest()
        {
            var vendor = GetCIVendor();

            if (vendor == null)
            {
                return false;
            }

            return vendor.DetectPullRequest.IsPullRequest();
        }

        public static bool IsCI()
        {
            return GetCIVendor() != null;
        }

        public static Vendor GetCIVendor()
        {
            return Vendors.SingleOrDefault(v => v.IsVendor());
        }

        public static List<Vendor> Vendors
        {
            get => VendorDefinitions.Vendors;
        }
    }
}
