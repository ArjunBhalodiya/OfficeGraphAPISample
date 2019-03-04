using Microsoft.GraphAPI.Messages.Enum;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class FilterConditions
    {
        public Folder Folder { get; set; } = Folder.All;
        public string ConversationId { get; set; }
        public bool IncludeAttachament { get; set; }
        public bool Count { get; set; } = true;
        public int Skip { get; set; } = 0;
        public int Top { get; set; } = 10;
        public OrderByField OrderBy { get; set; } = OrderByField.ReceivedDateTimeDescending;
        public string SearchText { get; set; } = string.Empty;
        public bool? Unread { get; set; }
        public string LastReceivedDateTime { get; set; }
    }
}
