using Newtonsoft.Json;

namespace BotInCloud.DTO
{
    class Update
    {
        [JsonProperty("update_id")]
        public int UpdateID { get; set; }
        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}
