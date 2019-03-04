using System.Collections.Generic;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class User : BaseModel
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string UserPrincipalName { get; set; }
        public string UserType { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public bool AccountEnabled { get; set; }
        public PasswordProfile PasswordProfile { get; set; }
        public IList<LicenseDetails> LicenseDetails { get; set; }
    }
}
