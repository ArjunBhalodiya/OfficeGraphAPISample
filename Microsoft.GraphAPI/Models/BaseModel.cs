using Newtonsoft.Json;

namespace Microsoft.GraphAPI.Messages.Models
{
    public class BaseModel
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "@odata.type")]
        public string ODataType { get; set; }
    }
}
