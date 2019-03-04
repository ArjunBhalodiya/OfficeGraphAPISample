namespace Microsoft.GraphAPI.Messages.Models
{
    public class UpdateUserRequest : BaseModel
    {
        public bool AccountEnabled { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string UserPrincipalName { get; set; }
        public PasswordProfile PasswordProfile { get; set; }
    }
}
