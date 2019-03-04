using System;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class FileAttachment : BaseModel
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] ContentBytes { get; set; }
        public int? Size { get; set; }
        public bool? IsInline { get; set; }
        public string ContentId { get; set; }
        public string ContentLocation { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
}
