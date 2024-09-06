using Interfaces;
using Newtonsoft.Json;

namespace DbModels
{
    public class TodoItem : ITodoItem
    {
        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Completed { get; set; }
    }

}
