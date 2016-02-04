using Newtonsoft.Json;

namespace BotInCloud.DTO
{
    class Updates
    {
        [JsonProperty("result")]
        public Update[] UpdateArr { get; set; }
    }
}
