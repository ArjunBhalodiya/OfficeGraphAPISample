namespace Microsoft.GraphAPI.Messages.Models
{
    public class Recipient
    {
        public Recipient()
        {
            EmailAddress = new EmailAddress();
        }
        public EmailAddress EmailAddress { get; set; }
    }
}
