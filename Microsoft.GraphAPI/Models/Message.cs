using System;
using System.Collections.Generic;
using Microsoft.GraphAPI.Messages.Enum;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class Message : BaseModel
    {
        public IList<OpenTypeExtensionResponse> Extensions { get; set; }
        public IList<FileAttachment> Attachments { get; set; }
        public string WebLink { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsReadReceiptRequested { get; set; }
        public bool? IsDeliveryReceiptRequested { get; set; }
        public ItemBody UniqueBody { get; set; }
        public string ConversationId { get; set; }
        public IList<Recipient> ReplyTo { get; set; }
        public IList<Recipient> BccRecipients { get; set; }
        public IList<Recipient> CcRecipients { get; set; }
        public IList<Recipient> ToRecipients { get; set; }
        public Recipient From { get; set; }
        public Recipient Sender { get; set; }
        public string ParentFolderId { get; set; }
        public MessageImportance? Importance { get; set; }
        public string BodyPreview { get; set; }
        public ItemBody Body { get; set; }
        public string Subject { get; set; }
        public string InternetMessageId { get; set; }
        public bool? HasAttachments { get; set; }
        public DateTimeOffset? SentDateTime { get; set; }
        public DateTimeOffset? ReceivedDateTime { get; set; }

        public Message()
        {
            Attachments = new List<FileAttachment>();
        }
    }
}
