using System.ComponentModel;

namespace Microsoft.GraphAPI.Messages.Enum
{
    public enum OrderByField
    {
        None,
        [Description("receivedDateTime")]
        ReceivedDateTimeAscending,
        [Description("sentDateTime")]
        SentDateTimeAscending,
        [Description("subject")]
        SubjectAscending,
        [Description("sender/emailAddress/address")]
        SenderEmailAddressAscending,
        [Description("from/emailAddress/address")]
        FromEmailAddressAscending,

        [Description("receivedDateTime desc")]
        ReceivedDateTimeDescending,
        [Description("sentDateTime desc")]
        SentDateTimeDescending,
        [Description("subject desc")]
        SubjectDescending,
        [Description("sender/emailAddress/address desc")]
        SenderEmailAddressDescending,
        [Description("from/emailAddress/address desc")]
        FromEmailAddressDescending
    }
}
