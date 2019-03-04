using System;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class LicenseDetails : BaseModel
    {
        public Guid? SkuId { get; set; }
        public string SkuPartNumber { get; set; }
    }
}
