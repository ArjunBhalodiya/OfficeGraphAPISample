using System;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class Subscription
    {
        public string ChangeType { get; set; }
        public string NotificationUrl { get; set; }
        public string Resource { get; set; }
        public string ApplicationId { get; set; }
        public string Id { get; set; }
        public string ClientState { get; set; }
        public string CreatorId { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
