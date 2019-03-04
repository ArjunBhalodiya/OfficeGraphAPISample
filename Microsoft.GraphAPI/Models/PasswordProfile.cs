namespace Microsoft.GraphAPI.Messages.Models
{
    public class PasswordProfile
    {
        public string Password { get; set; }
        public bool ForceChangePasswordNextSignIn { get; set; }
    }
}
