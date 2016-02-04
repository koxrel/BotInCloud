using Newtonsoft.Json;

namespace BotInCloud.DTO
{
    class Chat
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
