using System;
using System.Collections.Generic;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class UserLicense
    {
        public UserLicense()
        {
            AddLicenses = new List<LicenseDetails>();
            AddLicenses.Add(new LicenseDetails { SkuId = Guid.NewGuid() });
        }
        public IList<LicenseDetails> AddLicenses { get; set; }
        public IList<Guid> RemoveLicenses { get; set; }
    }
}
